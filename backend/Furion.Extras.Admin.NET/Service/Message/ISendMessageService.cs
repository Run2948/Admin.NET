using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Furion.Extras.Admin.NET.Service
{
    public interface ISendMessageService
    {
        /// <summary>
        /// ������Ϣ��ĳ����
        /// </summary>
        /// <param name="title">���ͱ���</param>
        /// <param name="message">��������</param>
        /// <param name="userId">������</param>
        /// <param name="type">��Ϣ����</param>
        /// <returns></returns>
        Task SendMessageToUser(string title, string message, MessageType type, long userId);

        /// <summary>
        /// ������Ϣ��ĳЩ��
        /// </summary>
        /// <param name="title">���ͱ���</param>
        /// <param name="message">��������</param>
        /// <param name="userId">�������б�</param>
        /// <param name="type">��Ϣ����</param>
        /// <returns></returns>
        Task SendMessageToUsers(string title, string message, MessageType type, List<long> userId);

        /// <summary>
        /// ������Ϣ��������
        /// </summary>
        /// <param name="title">���ͱ���</param>
        /// <param name="message">��������</param>
        /// <param name="type">��Ϣ����</param>
        /// <returns></returns>
        Task SendMessageToAllUser(string title, string message, MessageType type);

        /// <summary>
        /// ������Ϣ�����˷����˵�������
        /// </summary>
        /// <param name="title">���ͱ���</param>
        /// <param name="message">��������</param>
        /// <param name="userId">������</param>
        /// <param name="type">��Ϣ����</param>
        /// <returns></returns>
        Task SendMessageToOtherUser(string title, string message, MessageType type, long userId);
    }
}