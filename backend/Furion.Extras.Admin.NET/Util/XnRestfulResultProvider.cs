﻿using Furion;
using Furion.DataValidation;
using Furion.DependencyInjection;
using Furion.UnifyResult;
using Furion.UnifyResult.Internal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Furion.Extras.Admin.NET
{
    /// <summary>
    /// 规范化RESTful风格返回值
    /// </summary>
    [UnifyModel(typeof(XnRestfulResult<>))]
    public class XnRestfulResultProvider : IUnifyResultProvider
    {
        /// <summary>
        /// 异常返回值
        /// </summary>
        /// <param name="context"></param>
        /// <param name="metadata"></param>
        /// <returns></returns>
        public IActionResult OnException(ExceptionContext context, ExceptionMetadata metadata)
        {
            return new JsonResult(new XnRestfulResult<object>
            {
                Code = metadata.StatusCode,
                Success = false,
                Data = null,
                Message = metadata.Errors,
                Extras = UnifyContext.Take(),
                Timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()
            });
        }

        /// <summary>
        /// 成功返回值
        /// </summary>
        /// <param name="context"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public IActionResult OnSucceeded(ActionExecutedContext context, object data)
        {
            return new JsonResult(new XnRestfulResult<object>
            {
                Code = context.Result is EmptyResult ? StatusCodes.Status204NoContent : StatusCodes.Status200OK,  // 处理没有返回值情况 204
                Success = true,
                Data = data,
                Message = "请求成功",
                Extras = UnifyContext.Take(),
                Timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()
            });
        }

        /// <summary>
        /// 验证失败返回值
        /// </summary>
        /// <param name="context"></param>
        /// <param name="metadata"></param>
        /// <returns></returns>
        public IActionResult OnValidateFailed(ActionExecutingContext context, ValidationMetadata metadata)
        {
            return new JsonResult(new XnRestfulResult<object>
            {
                Code = StatusCodes.Status400BadRequest,
                Success = false,
                Data = null,
                Message = metadata.ValidationResult,
                Extras = UnifyContext.Take(),
                Timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()
            });
        }

        /// <summary>
        /// 处理输出状态码
        /// </summary>
        /// <param name="context"></param>
        /// <param name="statusCode"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public async Task OnResponseStatusCodes(HttpContext context, int statusCode, UnifyResultStatusCodesOptions options)
        {
            // 设置响应状态码
            UnifyContext.SetResponseStatusCodes(context, statusCode, options);

            switch (statusCode)
            {
                // 处理 401 状态码
                case StatusCodes.Status401Unauthorized:
                    await context.Response.WriteAsJsonAsync(new XnRestfulResult<object>
                    {
                        Code = StatusCodes.Status401Unauthorized,
                        Success = false,
                        Data = null,
                        Message = "401 登录已过期，请重新登录",
                        Extras = UnifyContext.Take(),
                        Timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()
                    }, App.GetOptions<JsonOptions>()?.JsonSerializerOptions);
                    break;
                // 处理 403 状态码
                case StatusCodes.Status403Forbidden:
                    await context.Response.WriteAsJsonAsync(new XnRestfulResult<object>
                    {
                        Code = StatusCodes.Status403Forbidden,
                        Success = false,
                        Data = null,
                        Message = "403 禁止访问，没有权限",
                        Extras = UnifyContext.Take(),
                        Timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()
                    }, App.GetOptions<JsonOptions>()?.JsonSerializerOptions);
                    break;

                default:
                    break;
            }
        }
    }

    /// <summary>
    /// RESTful风格---XIAONUO返回格式
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class XnRestfulResult<T>
    {
        /// <summary>
        /// 执行成功
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// 状态码
        /// </summary>
        public int? Code { get; set; }

        /// <summary>
        /// 错误信息
        /// </summary>
        public object Message { get; set; }

        /// <summary>
        /// 数据
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// 附加数据
        /// </summary>
        public object Extras { get; set; }

        /// <summary>
        /// 时间戳
        /// </summary>
        public long Timestamp { get; set; }
    }
}