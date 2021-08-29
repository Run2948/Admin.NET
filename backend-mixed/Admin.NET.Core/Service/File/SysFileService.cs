using Furion;
using Furion.DatabaseAccessor;
using Furion.DatabaseAccessor.Extensions;
using Furion.DependencyInjection;
using Furion.DynamicApiController;
using Furion.FriendlyException;
using Furion.RemoteRequest.Extensions;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OnceMi.AspNetCore.OSS;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Authorization;

namespace Admin.NET.Core.Service
{
    /// <summary>
    /// 文件服务
    /// </summary>
    [ApiDescriptionSettings(Name = "File", Order = 100)]
    public class SysFileService : ISysFileService, IDynamicApiController, ITransient
    {
        private readonly IRepository<SysFile> _sysFileInfoRep;  // 文件信息表仓储

        private readonly IConfiguration _configuration;

        private readonly IOSSServiceFactory _ossServiceFactory;

        private readonly string bucketName = "bucketName";

        public SysFileService(IRepository<SysFile> sysFileInfoRep,
                              IConfiguration configuration,
                              IOSSServiceFactory ossServiceFactory)
        {
            _sysFileInfoRep = sysFileInfoRep;
            _configuration = configuration;
            _ossServiceFactory = ossServiceFactory;
        }

        /// <summary>
        /// 分页获取文件列表
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet("/sysFileInfo/page")]
        public async Task<dynamic> QueryFileInfoPageList([FromQuery] FilePageInput input)
        {
            var fileBucket = !string.IsNullOrEmpty(input.FileBucket?.Trim());
            var fileOriginName = !string.IsNullOrEmpty(input.FileOriginName?.Trim());
            var files = await _sysFileInfoRep.DetachedEntities
                                             .Where(input.FileLocation > 0, u => u.FileLocation == input.FileLocation)
                                             .Where(fileBucket, u => EF.Functions.Like(u.FileBucket, $"%{input.FileBucket.Trim()}%"))
                                             .Where(fileOriginName, u => EF.Functions.Like(u.FileOriginName, $"%{input.FileOriginName.Trim()}%"))
                                             .Select(u => u.Adapt<FileOutput>())
                                             .ToPagedListAsync(input.PageNo, input.PageSize);
            return XnPageResult<FileOutput>.PageResult(files);
        }

        /// <summary>
        /// 获取文件列表
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet("/sysFileInfo/list")]
        public async Task<List<SysFile>> GetFileInfoList([FromQuery] FileOutput input)
        {
            return await _sysFileInfoRep.DetachedEntities.ToListAsync();
        }

        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("/sysFileInfo/delete")]
        public async Task DeleteFileInfo(DeleteFileInfoInput input)
        {
            var file = await _sysFileInfoRep.FirstOrDefaultAsync(u => u.Id == input.Id);
            if (file != null)
            {
                await file.DeleteAsync();

                switch (file.FileLocation)
                {
                    case (int)FileLocation.MINIO:
                        await _ossServiceFactory.Create().RemoveObjectAsync(file.FileBucket, string.Concat(file.FilePath, "/", file.FileObjectName));
                        break;

                    case (int)FileLocation.ALIYUN:
                        await _ossServiceFactory.Create("Aliyun").RemoveObjectAsync(file.FileBucket, string.Concat(file.FilePath, "/", file.FileObjectName));
                        break;

                    case (int)FileLocation.TENCENT:
                        await _ossServiceFactory.Create("QCloud").RemoveObjectAsync(file.FileBucket, string.Concat(file.FilePath, "/", file.FileObjectName));
                        break;

                    default:
                        var filePath = Path.Combine(App.WebHostEnvironment.WebRootPath, file.FilePath, file.FileObjectName);
                        if (File.Exists(filePath))
                            File.Delete(filePath);
                        break;
                }
            }
        }

        /// <summary>
        /// 获取文件详情
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet("/sysFileInfo/detail")]
        public async Task<SysFile> GetFileInfo([FromQuery] QueryFileInfoInput input)
        {
            var file = await _sysFileInfoRep.FirstOrDefaultAsync(u => u.Id == input.Id);
            if (file == null)
                throw Oops.Oh(ErrorCode.D8000);
            return file;
        }

        /// <summary>
        /// 预览文件
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet("/sysFileInfo/preview")]
        public async Task<IActionResult> PreviewFileInfo([FromQuery] QueryFileInfoInput input)
        {
            return await DownloadFileInfo(input);
        }

        /// <summary>
        /// 下载文件
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet("/sysFileInfo/download")]
        public async Task<IActionResult> DownloadFileInfo([FromQuery] QueryFileInfoInput input)
        {
            var file = await GetFileInfo(input);
            var fileName = HttpUtility.UrlEncode(file.FileOriginName, Encoding.GetEncoding("UTF-8"));

            switch (file.FileLocation)
            {
                case (int)FileLocation.ALIYUN:
                    var filePath = string.Concat(file.FilePath, "/", file.FileObjectName);
                    var stream1 = await (await _ossServiceFactory.Create("Aliyun").PresignedGetObjectAsync(bucketName, filePath, 5)).GetAsStreamAsync();
                    return new FileStreamResult(stream1, "application/octet-stream") { FileDownloadName = fileName };

                case (int)FileLocation.TENCENT:
                    var filePath1 = string.Concat(file.FilePath, "/", file.FileObjectName);
                    var stream2 = await (await _ossServiceFactory.Create("QCloud").PresignedGetObjectAsync(bucketName, filePath1, 5)).GetAsStreamAsync();
                    return new FileStreamResult(stream2, "application/octet-stream") { FileDownloadName = fileName };

                case (int)FileLocation.MINIO:
                    var filePath2 = string.Concat(file.FilePath, "/", file.FileObjectName);
                    var stream3 = await (await _ossServiceFactory.Create().PresignedGetObjectAsync(file.FileBucket, filePath2, 5)).GetAsStreamAsync();
                    return new FileStreamResult(stream3, "application/octet-stream") { FileDownloadName = fileName };

                default:
                    var filePath4 = Path.Combine(file.FilePath, file.FileObjectName);
                    var path = Path.Combine(App.WebHostEnvironment.WebRootPath, filePath4);
                    return new FileStreamResult(new FileStream(path, FileMode.Open), "application/octet-stream") { FileDownloadName = fileName };
            }
        }

        /// <summary>
        /// 公开文件
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet("/sysFileInfo/public")]
        public async Task<PublicFileOutput> PublicFileInfo([FromQuery] QueryFileInfoInput input)
        {
            var file = await GetFileInfo(input);
            return await PublicFilePath(file);
        }

        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        [HttpPost("/sysFileInfo/upload")]
        public async Task<long> UploadFileDefault([Required] IFormFile file)
        {
            // 可以读取系统配置来决定将文件存储到什么地方
            return await UploadFile(file, _configuration["UploadFile:Default:path"], FileLocation.LOCAL);
        }

        /// <summary>
        /// 上传文件后公开路径
        /// </summary>
        /// <param name="files"></param>
        /// <param name="pathType"></param>
        /// <returns></returns>
        [HttpPost("/sysFileInfo/uploadPublic")]
        public async Task<List<PublicFileOutput>> UploadFilePublic(string pathType = "Default", [Required] params IFormFile[] files)
        {
            var list = new List<PublicFileOutput>();
            foreach (var file in files)
            {
                var newFile = await UploadFilePublic(file, _configuration[$"UploadFile:{pathType}:path"], FileLocation.LOCAL);
                list.Add(await PublicFilePath(newFile));
            }
            return list;
        }

        /// <summary>
        /// 上传头像
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        [HttpPost("/sysFileInfo/uploadAvatar")]
        public async Task<long> UploadFileAvatar([Required] IFormFile file)
        {
            return await UploadFile(file, _configuration["UploadFile:Avatar:path"]);
        }

        /// <summary>
        /// 上传文档
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        [HttpPost("/sysFileInfo/uploadDocument")]
        public async Task UploadFileDocument([Required] IFormFile file)
        {
            await UploadFile(file, _configuration["UploadFile:Document:path"]);
        }

        /// <summary>
        /// 上传商店图片
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        [HttpPost("/sysFileInfo/uploadShop")]
        public async Task UploadFileShop([Required] IFormFile file)
        {
            await UploadFile(file, _configuration["UploadFile:Shop:path"]);
        }

        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="file">文件</param>
        /// <param name="pathType">存储路径</param>
        /// <param name="fileLocation">文件存储位置</param>
        /// <returns></returns>
        private async Task<SysFile> UploadFilePublic(IFormFile file, string pathType, FileLocation fileLocation = FileLocation.LOCAL)
        {
            var fileSizeKb = (long)(file.Length / 1024.0); // 文件大小KB
            var originalFilename = file.FileName; // 文件原始名称
            var fileSuffix = Path.GetExtension(file.FileName).ToLower(); // 文件后缀

            // 先存库获取Id
            var newFile = await new SysFile
            {
                FileLocation = (int)fileLocation,
                FileBucket = bucketName,
                //FileObjectName = finalName,
                FileOriginName = originalFilename,
                FileSuffix = fileSuffix.TrimStart('.'),
                FileSizeKb = fileSizeKb.ToString(),
                FilePath = pathType
            }.InsertNowAsync();

            var finalName = newFile.Entity.Id + fileSuffix; // 生成文件的最终名称
                                                            // newFile.Entity.FileObjectName = finalName;
            switch (fileLocation)
            {
                case FileLocation.ALIYUN:
                    var filePath = string.Concat(pathType, "/", finalName);
                    var stream = file.OpenReadStream();
                    await _ossServiceFactory.Create("aliyun").PutObjectAsync(bucketName, filePath, stream);
                    break;

                case FileLocation.TENCENT:
                    var filePath1 = string.Concat(pathType, "/", finalName);
                    var stream1 = file.OpenReadStream();
                    await _ossServiceFactory.Create("qcloud").PutObjectAsync(bucketName, filePath1, stream1);
                    break;

                case FileLocation.MINIO:
                    var filePath2 = string.Concat(pathType, "/", finalName);
                    var stream2 = file.OpenReadStream();
                    await _ossServiceFactory.Create().PutObjectAsync(bucketName, filePath2, stream2);
                    break;

                default:
                    var filePath4 = Path.Combine(App.WebHostEnvironment.WebRootPath, pathType);
                    if (!Directory.Exists(filePath4))
                        Directory.CreateDirectory(filePath4);
                    using (var stream4 = File.Create(Path.Combine(filePath4, finalName)))
                    {
                        await file.CopyToAsync(stream4);
                    }
                    break;
            }
            newFile.Entity.FileObjectName = finalName;
            return newFile.Entity;
        }

        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="file">文件</param>
        /// <param name="pathType">存储路径</param>
        /// <param name="fileLocation">文件存储位置</param>
        /// <returns></returns>
        private async Task<long> UploadFile(IFormFile file, string pathType, FileLocation fileLocation = FileLocation.LOCAL)
        {
            var newFile = await UploadFilePublic(file, pathType, fileLocation);
            return newFile.Id; // 返回文件唯一标识
        }

        /// <summary>
        /// 公开文件路径
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        private async Task<PublicFileOutput> PublicFilePath(SysFile file)
        {
            string fileUrl;
            switch (file.FileLocation)
            {
                case (int)FileLocation.ALIYUN:
                    var filePath = string.Concat(file.FilePath, "/", file.FileObjectName);
                    fileUrl = await _ossServiceFactory.Create("Aliyun").PresignedGetObjectAsync(bucketName, filePath, 5);
                    break;

                case (int)FileLocation.TENCENT:
                    var filePath1 = string.Concat(file.FilePath, "/", file.FileObjectName);
                    fileUrl = await _ossServiceFactory.Create("QCloud").PresignedGetObjectAsync(bucketName, filePath1, 5);
                    break;

                case (int)FileLocation.MINIO:
                    var filePath2 = string.Concat(file.FilePath, "/", file.FileObjectName);
                    fileUrl = await _ossServiceFactory.Create().PresignedGetObjectAsync(file.FileBucket, filePath2, 5);
                    break;

                default:
                    var filePath4 = Path.Join("/", file.FilePath, "/", file.FileObjectName);
                    fileUrl = filePath4.Replace(@"\\", "/"); // Path.Combine(App.WebHostEnvironment.WebRootPath, filePath4);
                    break;
            }

            return new PublicFileOutput { Id = file.Id, Name = file.FileObjectName, Url = fileUrl };
        }
    }
}