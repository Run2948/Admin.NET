using Admin.NET.Core.Service;
using Furion.DataEncryption;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Furion;
using Microsoft.AspNetCore.Http;
using UAParser;

namespace Admin.NET.Core
{
    /// <summary>
    /// 聊天集线器
    /// </summary>
    public class ChatHub : Hub<IChatClient>
    {
        private readonly ISysCacheService _cache;

        public ChatHub(ISysCacheService cache)
        {
            _cache = cache;
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
    }
}