﻿using Furion.DatabaseAccessor;
using Furion.DatabaseAccessor.Extensions;
using Furion.DependencyInjection;
using Furion.DynamicApiController;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Furion.Extras.Admin.NET.Service
{
    /// <summary>
    /// 代码生成详细配置服务
    /// </summary>
    [ApiDescriptionSettings(Name = "CodeGenConfig", Order = 100)]
    public class CodeGenConfigService : ICodeGenConfigService, IDynamicApiController, ITransient
    {
        private readonly IRepository<SysCodeGen> _sysCodeGenRep; // 代码生成器仓储
        private readonly IRepository<SysCodeGenConfig> _sysCodeGenConfigRep; // 代码生成详细配置仓储

        public CodeGenConfigService(IRepository<SysCodeGenConfig> sysCodeGenConfigRep, IRepository<SysCodeGen> sysCodeGenRep)
        {
            _sysCodeGenConfigRep = sysCodeGenConfigRep;
            _sysCodeGenRep = sysCodeGenRep;
        }

        /// <summary>
        /// 代码生成详细配置列表
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet("/sysCodeGenerateConfig/list")]
        public async Task<List<CodeGenConfig>> List([FromQuery] CodeGenConfig input)
        {
            var result = await _sysCodeGenConfigRep.DetachedEntities
                                             .Where(u => u.CodeGenId == input.CodeGenId && u.WhetherCommon != YesOrNot.Y.ToString())
                                             .Select(u => u.Adapt<CodeGenConfig>()).ToListAsync();
            await DtoMapper(result);
            return result;
        }

        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [NonAction]
        public async Task Add(CodeGenConfig input)
        {
            var codeGenConfig = input.Adapt<SysCodeGenConfig>();
            await codeGenConfig.InsertAsync();
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="codeGenId"></param>
        /// <returns></returns>
        [NonAction]
        public async Task Delete(long codeGenId)
        {
            var codeGenConfigList = await _sysCodeGenConfigRep.Where(u => u.CodeGenId == codeGenId).ToListAsync();
            await _sysCodeGenConfigRep.DeleteAsync(codeGenConfigList);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="inputList"></param>
        /// <returns></returns>
        [HttpPost("/sysCodeGenerateConfig/edit")]
        public async Task Update(List<CodeGenConfig> inputList)
        {
            if (inputList == null || inputList.Count < 1) return;
            inputList.ForEach(u =>
            {
                var codeGenConfig = u.Adapt<SysCodeGenConfig>();
                codeGenConfig.Update(true);
            });
            await Task.CompletedTask;
        }

        /// <summary>
        /// 详情
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet("/sysCodeGenerateConfig/detail")]
        public async Task<SysCodeGenConfig> Detail([FromQuery] CodeGenConfig input)
        {
            return await _sysCodeGenConfigRep.FirstOrDefaultAsync(u => u.Id == input.Id);
        }

        /// <summary>
        /// 批量增加
        /// </summary>
        /// <param name="tableColumnOutputList"></param>
        /// <param name="codeGenerate"></param>
        [NonAction]
        public void AddList(List<TableColumnOutput> tableColumnOutputList, SysCodeGen codeGenerate)
        {
            if (tableColumnOutputList == null) return;

            foreach (var tableColumn in tableColumnOutputList)
            {
                var codeGenConfig = new SysCodeGenConfig();

                var yesOrNo = YesOrNot.Y.ToString();
                if (Convert.ToBoolean(tableColumn.ColumnKey))
                {
                    yesOrNo = YesOrNot.N.ToString();
                }

                if (CodeGenUtil.IsCommonColumn(tableColumn.ColumnName))
                {
                    codeGenConfig.WhetherCommon = YesOrNot.Y.ToString();
                    yesOrNo = YesOrNot.N.ToString();
                }
                else
                {
                    codeGenConfig.WhetherCommon = YesOrNot.N.ToString();
                }

                codeGenConfig.CodeGenId = codeGenerate.Id;
                codeGenConfig.ColumnName = tableColumn.ColumnName;
                codeGenConfig.ColumnComment = tableColumn.ColumnComment;
                codeGenConfig.NetType = CodeGenUtil.ConvertDataType(tableColumn.DataType);
                codeGenConfig.WhetherRetract = YesOrNot.N.ToString();

                codeGenConfig.WhetherRequired = YesOrNot.N.ToString();
                codeGenConfig.QueryWhether = yesOrNo;
                codeGenConfig.WhetherAddUpdate = yesOrNo;
                codeGenConfig.WhetherTable = yesOrNo;
                codeGenConfig.WhetherOrderBy = yesOrNo;

                codeGenConfig.ColumnKey = tableColumn.ColumnKey;

                codeGenConfig.DataType = tableColumn.DataType;
                codeGenConfig.EffectType = CodeGenUtil.DataTypeToEff(codeGenConfig.NetType);
                codeGenConfig.QueryType = "=="; // QueryTypeEnum.eq.ToString();

                codeGenConfig.InsertAsync();
            }
        }

        /// <summary>
        /// 映射主表
        /// </summary>
        /// <param name="rows"></param>
        /// <returns></returns>
        private async Task DtoMapper(ICollection<CodeGenConfig> rows)
        {
            var codeGen = await _sysCodeGenRep.FirstOrDefaultAsync(x => x.Id == rows.First().CodeGenId);
            foreach (var item in rows)
            {
                item.CodeGen = codeGen.Adapt<CodeGenOutput>();
                //item.CodeGenTestName = (await _codeGenTestRep.FirstOrDefaultAsync(e => e.Id == item.CodeGenId))?.Name;
            }
        }

    }
}