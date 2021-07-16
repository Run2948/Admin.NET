﻿using System;

namespace Furion.Extras.Admin.NET.Service
{
    /// <summary>
    /// 通知公告接收参数
    /// </summary>
    public class NoticeReceiveOutput : NoticeBase
    {
        /// <summary>
        /// Id
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 阅读状态（字典 0未读 1已读）
        /// </summary>
        public NoticeUserStatus ReadStatus { get; set; }

        /// <summary>
        /// 阅读时间
        /// </summary>
        public DateTimeOffset? ReadTime { get; set; }
    }
}