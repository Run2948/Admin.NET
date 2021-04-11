﻿using Furion.DatabaseAccessor;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dilon.Core
{
    /// <summary>
    /// 操作日志表
    /// </summary>
    [Table("sys_log_op")]
    [Comment("操作日志表")]
    public class SysLogOp : EntityBase
    {
        /// <summary>
        /// 名称
        /// </summary>
        [Comment("名称")]
        public string Name { get; set; }

        /// <summary>
        /// 操作类型（0其他 1增加 2删除 3编辑）（见LogAnnotionOpTypeEnum）
        /// </summary>
        [Comment("操作类型")]
        public int? OpType { get; set; }

        /// <summary>
        /// 是否执行成功（Y-是，N-否）
        /// </summary>
        [Comment("是否执行成功")]
        public string Success { get; set; }

        /// <summary>
        /// 具体消息
        /// </summary>
        [Comment("具体消息")]
        public string Message { get; set; }

        /// <summary>
        /// IP
        /// </summary>
        [Comment("IP")]
        public string Ip { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        [Comment("地址")]
        public string Location { get; set; }

        /// <summary>
        /// 浏览器
        /// </summary>
        [Comment("浏览器")]
        public string Browser { get; set; }

        /// <summary>
        /// 操作系统
        /// </summary>
        [Comment("操作系统")]
        public string Os { get; set; }

        /// <summary>
        /// 请求地址
        /// </summary>
        [Comment("请求地址")]
        public string Url { get; set; }

        /// <summary>
        /// 类名称
        /// </summary>
        [Comment("类名称")]
        public string ClassName { get; set; }

        /// <summary>
        /// 方法名称
        /// </summary>
        [Comment("方法名称")]
        public string MethodName { get; set; }

        /// <summary>
        /// 请求方式（GET POST PUT DELETE)
        /// </summary>
        [Comment("请求方式")]
        public string ReqMethod { get; set; }

        /// <summary>
        /// 请求参数
        /// </summary>
        [Comment("请求参数")]
        public string Param { get; set; }

        /// <summary>
        /// 返回结果
        /// </summary>
        [Comment("返回结果")]
        public string Result { get; set; }

        /// <summary>
        /// 耗时（毫秒）
        /// </summary>
        [Comment("耗时")]
        public long ElapsedTime { get; set; }

        /// <summary>
        /// 操作时间
        /// </summary>
        [Comment("操作时间")]
        public DateTimeOffset OpTime { get; set; }

        /// <summary>
        /// 操作人
        /// </summary>
        [Comment("操作人")]
        public string Account { get; set; }
    }
}
