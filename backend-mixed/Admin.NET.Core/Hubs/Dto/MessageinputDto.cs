using System.Collections.Generic;

namespace Admin.NET.Core
{
    public class MessageinputDto
    {
        /// <summary>
        /// �û�ID
        /// </summary>
        public long userId { get; set; }

        /// <summary>
        /// �û�ID�б�
        /// </summary>
        public List<long> userIds { get; set; }

        /// <summary>
        /// ��Ϣ����
        /// </summary>
        public string title { get; set; }

        /// <summary>
        /// ��Ϣ����
        /// </summary>
        public string message { get; set; }

        /// <summary>
        /// ��Ϣ����
        /// </summary>
        public MessageType messageType { get; set; }
    }
}
