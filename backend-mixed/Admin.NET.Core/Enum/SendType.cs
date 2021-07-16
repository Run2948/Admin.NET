using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.NET.Core
{
    /// <summary>
    /// 发送类型
    /// </summary>
    public enum SendType
    {
        /// <summary>
        /// 未发送
        /// </summary>
        [Description("未发送")]
        UNSENT = 0,

        /// <summary>
        /// 发送成功
        /// </summary>
        [Description("发送成功")]
        SUCCESS = 1,

        /// <summary>
        /// 发送失败
        /// </summary>
        [Description("发送失败")]
        FAILURE = 2,

        /// <summary>
        /// 失效
        /// </summary>
        [Description("失效")]
        INVALID = 3,
    }
}
