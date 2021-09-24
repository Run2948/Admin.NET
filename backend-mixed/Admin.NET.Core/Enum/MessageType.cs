using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.NET.Core
{
    public enum MessageType
    {
        /// <summary>
        /// ��ͨ��Ϣ
        /// </summary>
        [Description("��Ϣ")]
        Info = 0,

        /// <summary>
        /// �ɹ���ʾ
        /// </summary>
        [Description("�ɹ�")]
        Success = 1,

        /// <summary>
        /// ������ʾ
        /// </summary>
        [Description("����")]
        Warning = 2,

        /// <summary>
        /// ������ʾ
        /// </summary>
        [Description("����")]
        Error = 3

    }
}
