using System;
using Furion.DatabaseAccessor;
using Furion.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Furion.Extras.Admin.NET.Service
{
    /// <summary>
    /// 角色菜单
    /// </summary>
    public class SysRoleMenuService : ISysRoleMenuService, ITransient
    {
        private readonly IRepository<SysRoleMenu> _sysRoleMenuRep;  // 角色菜单表仓储
        private readonly IRepository<SysMenu> _sysMenuRep;  // 菜单表仓储
        private readonly ISysCacheService _sysCacheService;

        public SysRoleMenuService(IRepository<SysRoleMenu> sysRoleMenuRep, IRepository<SysMenu> sysMenuRep, ISysCacheService sysCacheService)
        {
            _sysRoleMenuRep = sysRoleMenuRep;
            _sysMenuRep = sysMenuRep;
            _sysCacheService = sysCacheService;
        }

        /// <summary>
        /// 获取角色的菜单Id集合
        /// </summary>
        /// <param name="roleIdList"></param>
        /// <returns></returns>
        public async Task<List<long>> GetRoleMenuIdList(List<long> roleIdList)
        {
            return await _sysRoleMenuRep.DetachedEntities
                                        .Where(u => roleIdList.Contains(u.SysRoleId))
                                        .Select(u => u.SysMenuId).ToListAsync();
        }

        /// <summary>
        /// 授权角色菜单
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [UnitOfWork]
        public async Task GrantMenu(GrantRoleMenuInput input)
        {
            var roleMenus = await _sysRoleMenuRep.DetachedEntities.Where(u => u.SysRoleId == input.Id).ToListAsync();
            await _sysRoleMenuRep.DeleteAsync(roleMenus);

            // 确保对按钮菜单的父级菜单能正确的授权，发现前端构造的数据会丢弃了按钮菜单的父级菜单
            var roleMenuPidsList = await _sysMenuRep.DetachedEntities.Where(u => input.GrantMenuIdList.Contains(u.Id))
                .Select(u => u.Pids).ToListAsync();
            var roleMenuSplitPids = roleMenuPidsList
                .SelectMany(u => u.Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Select(v => long.Parse(v[1..^1]))
                .Where(v => v != 0))
                .Union(input.GrantMenuIdList);

            var menus = roleMenuSplitPids.Select(u => new SysRoleMenu
            {
                SysRoleId = input.Id,
                SysMenuId = u
            }).ToList();
            await _sysRoleMenuRep.InsertAsync(menus);

            // 清除缓存
            await _sysCacheService.DelByPatternAsync(CommonConst.CACHE_KEY_MENU);
            await _sysCacheService.DelByPatternAsync(CommonConst.CACHE_KEY_PERMISSION);
        }

        /// <summary>
        /// 根据菜单Id集合删除对应的角色-菜单表信息
        /// </summary>
        /// <param name="menuIdList"></param>
        /// <returns></returns>
        public async Task DeleteRoleMenuListByMenuIdList(List<long> menuIdList)
        {
            var roleMenus = await _sysRoleMenuRep.DetachedEntities.Where(u => menuIdList.Contains(u.SysMenuId)).ToListAsync();
            await _sysRoleMenuRep.DeleteAsync(roleMenus);
        }

        /// <summary>
        /// 根据角色Id删除对应的角色-菜单表关联信息
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public async Task DeleteRoleMenuListByRoleId(long roleId)
        {
            var roleMenus = await _sysRoleMenuRep.DetachedEntities.Where(u => u.SysRoleId == roleId).ToListAsync();
            await _sysRoleMenuRep.DeleteAsync(roleMenus);
        }
    }
}