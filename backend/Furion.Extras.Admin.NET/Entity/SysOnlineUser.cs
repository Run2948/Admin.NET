using Furion.DatabaseAccessor;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Furion.Extras.Admin.NET
{
    /// <summary>
    /// 在线用户表
    /// </summary>
    [Table("sys_online_user")]
    [Comment("在线用户表")]
    public class OnlineUser //: IEntity, IEntityTypeBuilder<OnlineUser>
    {
        /// <summary>
        /// 连接Id
        /// </summary>
        [Comment("连接Id")]
        public string ConnectionId { get; set; }

        /// <summary>
        /// 用户Id
        /// </summary>
        [Comment("用户Id")]
        public long UserId { get; set; }

        /// <summary>
        /// 账号
        /// </summary>
        [Comment("账号")]
        [Required, MaxLength(20)]
        public string Account { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        [Comment("姓名")]
        [MaxLength(20)]
        public string Name { get; set; }

        /// <summary>
        /// 最后连接时间
        /// </summary>
        [Comment("最近时间")]
        public DateTime LastTime { get; set; }

        /// <summary>
        /// 最后登录IP
        /// </summary>
        [Comment("最后登录IP")]
        [MaxLength(50)]
        public string LastLoginIp { get; set; }

        /// <summary>
        /// 最后登录所用浏览器
        /// </summary>
        [Comment("最后登录所用浏览器")]
        [MaxLength(20)]
        public string LastLoginBrowser { get; set; }

        /// <summary>
        /// 最后登录所用系统
        /// </summary>
        [Comment("最后登录所用系统")]
        [MaxLength(20)]
        public string LastLoginOs { get; set; }

        /// <summary>
        /// 租户id
        /// </summary>
        [Comment("租户id")]
        public long TenantId { get; set; }

        public void Configure(EntityTypeBuilder<OnlineUser> entityBuilder, DbContext dbContext, Type dbContextLocator)
        {
            entityBuilder.HasKey(c => new { c.UserId });
        }
    }
}