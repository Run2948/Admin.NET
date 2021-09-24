using System.Collections.Generic;

namespace Admin.NET.Core
{
    public class MessageinputDto
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public long userId { get; set; }

        /// <summary>
        /// 用户ID列表
        /// </summary>
        public List<long> userIds { get; set; }

        /// <summary>
        /// 消息标题
        /// </summary>
        public string title { get; set; }

        /// <summary>
        /// 消息内容
        /// </summary>
        public string message { get; set; }

        /// <summary>
        /// 消息类型
        /// </summary>
        public MessageType messageType { get; set; }
    }
}
