using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.NET.Core
{
    /// <summary>
    /// 短信发送来源
    /// </summary>
    public enum SmsSendSource
    {
        /// <summary>
        /// app
        /// </summary>
        [Description("app")]
        APP = 1,

        /// <summary>
        /// pc
        /// </summary>
        [Description("pc")]
        PC = 2,

        /// <summary>
        /// 其他
        /// </summary>
        [Description("其他")]
        OTHER = 3
    }
}
