using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furion.Extras.Admin.NET.Service
{
    public class SmsOutput
    {
        /// <summary>
        /// 短信信息Id
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        public string PhoneNumbers { get; set; }

        /// <summary>
        /// 短信验证码
        /// </summary>
        public string ValidateCode { get; set; }

        /// <summary>
        /// 短信模板ID
        /// </summary>
        public string TemplateCode { get; set; }

        /// <summary>
        /// 发送状态（字典 0 未发送，1 发送成功，2 发送失败，3 失效）
        /// </summary>
        public SendType Status { get; set; }

        /// <summary>
        /// 来源（字典 1 app， 2 pc， 3 其他）
        /// </summary>
        public SmsSendSource Source { get; set; }

        /// <summary>
        /// 失效时间
        /// </summary>
        public DateTime? InvalidTime { get; set; }
    }
}
