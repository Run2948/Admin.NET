﻿using System;
using System.Reflection;

namespace Admin.NET.Core
{
    /// <summary>
    /// 反射工具
    /// </summary>
    public static class ReflectionUtil
    {
        /// <summary>
        /// 获取字段特性
        /// </summary>
        /// <param name="field"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T GetDescriptionValue<T>(this FieldInfo field) where T : Attribute
        {
            // 获取字段的指定特性，不包含继承中的特性
            object[] customAttributes = field.GetCustomAttributes(typeof(T), false);

            // 如果没有数据返回null
            return customAttributes.Length > 0 ? (T)customAttributes[0] : null;
        }

        /// <summary>
        /// 获取类型的特性
        /// </summary>
        /// <param name="field"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T GetDescriptionValue<T>(this Type field) where T : Attribute
        {
            // 获取字段的指定特性，不包含继承中的特性
            object[] customAttributes = field.GetCustomAttributes(typeof(T), false);

            // 如果没有数据返回null
            return customAttributes.Length > 0 ? (T)customAttributes[0] : null;
        }
    }
}