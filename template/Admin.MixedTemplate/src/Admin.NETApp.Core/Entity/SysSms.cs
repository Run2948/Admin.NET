using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Admin.NETApp.Core
{
    /// <summary>
    /// 文件信息表
    /// </summary>
    [Table("sys_sms")]
    [Comment("短信信息发送表")]
    public class SysSms : DEntityBase
    {
        /// <summary>
        /// 手机号
        /// </summary>
        [Comment("手机号")]
        [MaxLength(200)]
        public string PhoneNumbers { get; set; }

        /// <summary>
        /// 短信验证码
        /// </summary>
        [Comment("短信验证码")]
        public string ValidateCode { get; set; }

        /// <summary>
        /// 短信模板ID
        /// </summary>
        [Comment("短信模板ID")]
        public string TemplateCode { get; set; }

        /// <summary>
        /// 回执id，可根据该id查询具体的发送状态
        /// </summary>
        [Comment("回执 ID")]
        public string BizId { get; set; }

        /// <summary>
        /// 发送状态（字典 0 未发送，1 发送成功，2 发送失败，3 失效）
        /// </summary>
        [Comment("发送状态-未发送_0、发送成功_1、发送失败_2、失效_3")]
        public SendType Status { get; set; }

        /// <summary>
        /// 来源（字典 1 app， 2 pc， 3 其他）
        /// </summary>
        [Comment("来源-App_1、PC_2、其他_3")]
        public SmsSendSource Source { get; set; }

        /// <summary>
        /// 失效时间
        /// </summary>
        [Comment("失效时间")]
        public DateTime? InvalidTime { get; set; }
    }
}
