using Furion.Extras.Admin.NET;
using Furion.Extras.Admin.NET.Service;
using Furion;
using Furion.Extras.Admin.NET.Options;
using Furion.Authorization;
using Furion.DataEncryption;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Admin.NETApp.Web.Core
{
    public class JwtHandler : AppAuthorizeHandler
    {
        /// <summary>
        /// 重写 Handler 添加自动刷新
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override async Task HandleAsync(AuthorizationHandlerContext context)
        {
            // 自动刷新Token
            if (JWTEncryption.AutoRefreshToken(context, context.GetCurrentHttpContext(),
                App.GetOptions<JWTSettingsOptions>().ExpiredTime,
                App.GetOptions<RefreshTokenSettingOptions>().ExpiredTime))
            {
                await AuthorizeHandleAsync(context);
            }
            else
            {
                context.Fail(); // 授权失败
                DefaultHttpContext currentHttpContext = context.GetCurrentHttpContext();
                if (currentHttpContext == null)
                    return;
                currentHttpContext.SignoutToSwagger();
            }
        }

        /// <summary>
        /// 授权判断逻辑，授权通过返回 true，否则返回 false
        /// </summary>
        /// <param name="context"></param>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        public override async Task<bool> PipelineAsync(AuthorizationHandlerContext context, DefaultHttpContext httpContext)
        {
            // 此处已经自动验证 Jwt Token的有效性了，无需手动验证
            return await CheckAuthorizeAsync(httpContext);
        }

        /// <summary>
        /// 检查权限
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        private static async Task<bool> CheckAuthorizeAsync(DefaultHttpContext httpContext)
        {
            // 管理员跳过判断
            var userManager = App.GetService<IUserManager>();
            if (userManager.SuperAdmin) return true;

            // 路由名称
            var routeName = httpContext.Request.Path.Value.Substring(1).Replace("/", ":");

            // 默认路由(获取登录用户信息)
            var defalutRoute = new List<string>()
            {
                "getLoginUser"
            };

            if (defalutRoute.Contains(routeName)) return true;

            // 获取用户权限集合（按钮或API接口）
            var allPermissionList = await App.GetService<ISysMenuService>().GetAllPermissionList();
            allPermissionList.Add("sysUser:selector");//为所有用户添加用户选择器权限

            var permissionList = await App.GetService<ISysMenuService>().GetLoginPermissionList(userManager.UserId);

            // 检查授权
            // 菜单中没有配置按钮权限，则不限制
            return allPermissionList.All(u => u != routeName) || permissionList.Contains(routeName);
        }
    }
}