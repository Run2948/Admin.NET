﻿using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Admin.NET.Core.OAuth
{
    /// <summary>
    /// 微信用户参数
    /// </summary>
    public class UserInfoModel
    {
        [JsonPropertyName("nickname")]
        public string Name { get; set; }

        [JsonPropertyName("headimgurl")]
        public string Avatar { get; set; }

        [JsonPropertyName("language")]
        public string Language { get; set; }

        [JsonPropertyName("openid")]
        public string Openid { get; set; }

        [JsonPropertyName("sex")]
        public int Sex { get; set; }

        [JsonPropertyName("province")]
        public string Province { get; set; }

        [JsonPropertyName("city")]
        public string City { get; set; }

        [JsonPropertyName("country")]
        public string Country { get; set; }

        /// <summary>
        /// 用户特权信息，json 数组，如微信沃卡用户为（chinaunicom）
        /// </summary>
        [JsonPropertyName("privilege")]
        public List<string> Privilege { get; set; }

        [JsonPropertyName("unionid")]
        public string UnionId { get; set; }

        [JsonPropertyName("errmsg")]
        public string ErrorMessage { get; set; }
    }

    public static class UserInfoModelExtensions
    {
        /// <summary>
        /// 获取的用户是否包含错误
        /// </summary>
        /// <param name="userInfoModel"></param>
        /// <returns></returns>
        public static bool HasError(this UserInfoModel userInfoModel)
        {
            return userInfoModel == null ||
                   string.IsNullOrEmpty(userInfoModel.Name) ||
                   !string.IsNullOrEmpty(userInfoModel.ErrorMessage);
        }
    }
}