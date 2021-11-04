using Admin.NETApp.Core.Service;
using Furion.DataEncryption;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Furion;
using Microsoft.AspNetCore.Http;
using UAParser;

namespace Admin.NETApp.Core
{
    /// <summary>
    /// 聊天集线器
    /// </summary>
    public class ChatHub : Hub<IChatClient>
    {
        private readonly ISysCacheService _cache;
        private readonly ISendMessageService _sendMessageService;

        public ChatHub(ISysCacheService cache, ISendMessageService sendMessageService)
        {
            _sendMessageService = sendMessageService;
        }

        /// <summary>
        /// 连接
        /// </summary>
        /// <returns></returns>
        public override async Task OnConnectedAsync()
        {
            var token = Context.GetHttpContext().Request.Query["access_token"];
            var claims = JWTEncryption.ReadJwtToken(token)?.Claims;

            var client = Parser.GetDefault().Parse(Context.GetHttpContext().Request.Headers["User-Agent"]);
            var loginBrowser = client.UA.Family + client.UA.Major;
            var loginOs = client.OS.Family + client.OS.Major;

            var userId = claims.FirstOrDefault(e => e.Type == ClaimConst.CLAINM_USERID)?.Value;
            var account = claims.FirstOrDefault(e => e.Type == ClaimConst.CLAINM_ACCOUNT)?.Value;
            var name = claims.FirstOrDefault(e => e.Type == ClaimConst.CLAINM_NAME)?.Value;
            var tenantId = claims.FirstOrDefault(e => e.Type == ClaimConst.TENANT_ID)?.Value;
            var onlineUsers = await _cache.GetAsync<List<SysOnlineUser>>(CommonConst.CACHE_KEY_ONLINE_USER) ?? new List<SysOnlineUser>();
            onlineUsers.Add(new SysOnlineUser
            {
                ConnectionId = Context.ConnectionId,
                UserId = long.Parse(userId),
                LastTime = DateTime.Now,
                LastLoginIp = App.HttpContext.GetRemoteIpAddressToIPv4(),
                LastLoginBrowser = loginBrowser,
                LastLoginOs = loginOs,
                Account = account,
                Name = name,
                TenantId = Convert.ToInt64(tenantId),
            });
            await _cache.SetAsync(CommonConst.CACHE_KEY_ONLINE_USER, onlineUsers);
        }

        /// <summary>
        /// 断开
        /// </summary>
        /// <param name="exception"></param>
        /// <returns></returns>
        public override async Task OnDisconnectedAsync(Exception exception)
        {
            if (!string.IsNullOrEmpty(Context.ConnectionId))
            {
                var onlineUsers = await _cache.GetAsync<List<SysOnlineUser>>(CommonConst.CACHE_KEY_ONLINE_USER);
                if (onlineUsers == null) return;

                onlineUsers.RemoveAll(u => u.ConnectionId == Context.ConnectionId);
                await _cache.SetAsync(CommonConst.CACHE_KEY_ONLINE_USER, onlineUsers);
            }
        }

        /// <summary>
        /// 前端调用发送方法
        /// 发送信息给某个人
        /// </summary>
        /// <param name="_message"></param>
        /// <returns></returns>
        public async Task ClientsSendMessage(MessageinputDto _message)
        {
            await _sendMessageService.SendMessageToUser(_message.title, _message.message, _message.messageType, _message.userId);
        }

        /// <summary>
        /// 前端调用发送方法
        /// 发送信息给所有人
        /// </summary>
        /// <param name="_message"></param>
        /// <returns></returns>
        public async Task ClientsSendMessagetoAll(MessageinputDto _message)
        {
            await _sendMessageService.SendMessageToAllUser(_message.title, _message.message, _message.messageType);
        }

        /// <summary>
        /// 前端调用发送方法
        /// 发送消息给除了发送人的其他人
        /// </summary>
        /// <param name="_message"></param>
        /// <returns></returns>
        public async Task ClientsSendMessagetoOther(MessageinputDto _message)
        {
            // _message.userId为发送人ID
            await _sendMessageService.SendMessageToOtherUser(_message.title, _message.message, _message.messageType, _message.userId);
        }

        /// <summary>
        /// 前端调用发送方法
        /// 发送消息给某些人
        /// </summary>
        /// <param name="_message"></param>
        /// <returns></returns>
        public async Task ClientsSendMessagetoUsers(MessageinputDto _message)
        {
            await _sendMessageService.SendMessageToUsers(_message.title, _message.message, _message.messageType, _message.userIds);
        }
    }
}