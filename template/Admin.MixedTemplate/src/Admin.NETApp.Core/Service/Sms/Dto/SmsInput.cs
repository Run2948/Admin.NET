using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.NETApp.Core.Service
{
    /// <summary>
    /// 短信历史参数
    /// </summary>
    public class SmsPageInput : PageInputBase
    {
        /// <summary>
        /// 手机号
        /// </summary>
        public string PhoneNumbers { get; set; }

        /// <summary>
        /// 发送状态
        /// </summary>
        public SendType? Status { get; set; }

        /// <summary>
        /// 来源
        /// </summary>
        public SmsSendSource? Source { get; set; }
    }
}
