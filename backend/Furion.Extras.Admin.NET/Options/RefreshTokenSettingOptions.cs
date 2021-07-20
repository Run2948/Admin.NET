using Furion.ConfigurableOptions;

namespace Furion.Extras.Admin.NET.Options
{
    /// <summary>
    /// 刷新令牌设置
    /// </summary>
    public sealed class RefreshTokenSettingOptions : IConfigurableOptions
    {
        /// <summary>
        /// 令牌过期时间（分钟）
        /// </summary>
        public int ExpiredTime { get; set; } = 43200;
    }
}