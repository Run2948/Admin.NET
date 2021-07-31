﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace Admin.NET.Core.Service
{
    public interface ISysOnlineUserService
    {
                /// <summary>
        /// 分页获取在线用户信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<dynamic> QueryOnlineUserPageList(PageInputBase input);

        /// <summary>
        /// 获取在线用户信息
        /// </summary>
        /// <returns></returns>
        Task<List<OnlineUserOutput>> List();

        /// <summary>
        /// 强制下线
        /// </summary>
        /// <param name="onlineUser">在线用户信息</param>
        /// <returns></returns>
        Task ForceExist(SysOnlineUser onlineUser);
    }
}