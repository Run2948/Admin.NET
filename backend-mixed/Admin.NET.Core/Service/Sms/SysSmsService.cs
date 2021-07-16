using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Furion.DatabaseAccessor;
using Furion.DependencyInjection;
using Furion.DynamicApiController;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Admin.NET.Core.Service
{
    /// <summary>
    /// 短信发送服务
    /// </summary>
    [ApiDescriptionSettings(Name = "Sms", Order = 100)]
    public class SysSmsService : ISysSmsService, IDynamicApiController, ITransient
    {
        private readonly IRepository<SysSms> _sysSmsInfoRep;

        public SysSmsService(IRepository<SysSms> sysSmsInfoRep)
        {
            _sysSmsInfoRep = sysSmsInfoRep;
        }

        /// <summary>
        /// 分页获取短信发送列表
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet("/sms/page")]
        public async Task<dynamic> QuerySmsPageList([FromQuery] SmsPageInput input)
        {
            var phoneNumbers = !string.IsNullOrEmpty(input.PhoneNumbers?.Trim());
            var items = await _sysSmsInfoRep.DetachedEntities
                .Where(phoneNumbers, u => EF.Functions.Like(u.PhoneNumbers, $"%{input.PhoneNumbers.Trim()}%"))
                .Where(input.Status.HasValue, u => u.Status == input.Status.Value)
                .Where(input.Status.HasValue, u => u.Source == input.Source.Value)
                .Select(u => u.Adapt<SmsOutput>())
                .ToPagedListAsync(input.PageNo, input.PageSize);
            return XnPageResult<SmsOutput>.PageResult(items);
        }
    }
}
