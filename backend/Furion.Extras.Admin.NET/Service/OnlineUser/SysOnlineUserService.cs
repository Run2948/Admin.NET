using System;
using Furion.DatabaseAccessor;
using Furion.DependencyInjection;
using Furion.DynamicApiController;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mapster;
using Microsoft.AspNetCore.SignalR;

namespace Furion.Extras.Admin.NET.Service
{
    /// <summary>
    /// 在线用户服务
    /// </summary>
    [ApiDescriptionSettings(Name = "OnlineUser", Order = 100)]
    public class SysOnlineUserService : ISysOnlineUserService, IDynamicApiController, ITransient
    {
        private readonly ISysCacheService _sysCacheService;
        private readonly IRepository<SysUser> _sysUerRep;// 用户表仓储
        private readonly IRepository<SysTenant, MultiTenantDbContextLocator> _sysTenantRep;// 租户仓储
        private readonly IUserManager _userManager;
        private readonly IHubContext<ChatHub, IChatClient> _chatHubContext;

        public SysOnlineUserService(ISysCacheService sysCacheService, IRepository<SysUser> sysUerRep,
            IRepository<SysTenant, MultiTenantDbContextLocator> sysTenantRep, IUserManager userManager,
            IHubContext<ChatHub, IChatClient> chatHubContext)
        {
            _sysCacheService = sysCacheService;
            _sysUerRep = sysUerRep;
            _sysTenantRep = sysTenantRep;
            _userManager = userManager;
            _chatHubContext = chatHubContext;
        }

        /// <summary>
        /// 分页获取在线用户信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet("/sysOnlineUser/page")]
        public async Task<dynamic> QueryOnlineUserPageList([FromQuery] PageInputBase input)
        {
            var pageIndex = input.PageNo;
            var pageSize = input.PageSize;

            var onlineUsers = await _sysCacheService.GetAsync<List<OnlineUser>>(CommonConst.CACHE_KEY_ONLINE_USER) ?? new List<OnlineUser>();
            var onlineUserOutputs = onlineUsers
                .Where(!_userManager.SuperAdmin, o => o.TenantId == _userManager.User.TenantId)
                .Where(!string.IsNullOrWhiteSpace(input.SearchValue), o => o.Account.Contains(input.SearchValue) || o.Name.Contains(input.SearchValue))
                .Select(o => o.Adapt<OnlineUserOutput>())
                .ToList();

            var totalCount = onlineUserOutputs.Count;
            var list = onlineUserOutputs.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            var num = (int)Math.Ceiling((double)totalCount / pageSize);

            //填充租户名称
            var tenants = await _sysTenantRep.DetachedEntities.ToListAsync();
            list.ForEach(o => o.TenantName = tenants.FirstOrDefault(p => p.Id == o.TenantId)?.Name);

            return XnPageResult<OnlineUserOutput>.PageResult(new PagedList<OnlineUserOutput>
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
                Items = list,
                TotalCount = totalCount,
                TotalPages = num,
                HasNextPages = pageIndex < num,
                HasPrevPages = pageIndex - 1 > 0
            });
        }

        /// <summary>
        /// 获取在线用户信息
        /// </summary>
        /// <returns></returns>
        [HttpGet("/sysOnlineUser/list")]
        public async Task<List<OnlineUserOutput>> List()
        {
            var onlineUsers = await _sysCacheService.GetAsync<List<OnlineUser>>(CommonConst.CACHE_KEY_ONLINE_USER) ?? new List<OnlineUser>();
            var onlineUserOutputs = onlineUsers
                .Where(!_userManager.SuperAdmin, o => o.TenantId == _userManager.User.TenantId)
                .Select(o => o.Adapt<OnlineUserOutput>())
                .ToList();

            //填充租户名称
            var tenants = await _sysTenantRep.DetachedEntities.ToListAsync();
            onlineUserOutputs.ForEach(o => o.TenantName = tenants.FirstOrDefault(p => p.Id == o.TenantId)?.Name);

            return onlineUserOutputs;
        }

        /// <summary>
        /// 强制下线
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost("/sysOnlineUser/forceExist")]
        public async Task ForceExist([FromBody] OnlineUser user)
        {
            await _chatHubContext.Clients.Client(user.ConnectionId).ForceExist();
        }
    }
}