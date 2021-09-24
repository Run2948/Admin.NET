using Furion.DependencyInjection;
using Furion.JsonSerialization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Furion.Extras.Admin.NET
{
    /// <summary>
    /// �Զ������л��ṩ��Newtonsoft
    /// </summary>
    public class NewtonsoftJsonSerializerProvider : IJsonSerializerProvider, ISingleton
    {
        /// <summary>        
        /// ���л�����        
        /// </summary>        
        /// <param name="value"></param>        
        /// <param name="jsonSerializerOptions"></param>        
        /// <returns></returns>        
        public string Serialize(object value, object jsonSerializerOptions = null)
        {
            return JsonConvert.SerializeObject(value, (jsonSerializerOptions ?? GetSerializerOptions()) as JsonSerializerSettings);
        }
        /// <summary>        
        /// �����л��ַ���        
        /// </summary>        
        /// <typeparam name="T"></typeparam>        
        /// <param name="json"></param>        
        /// <param name="jsonSerializerOptions"></param>        
        /// <returns></returns>        
        public T Deserialize<T>(string json, object jsonSerializerOptions = null)
        {
            return JsonConvert.DeserializeObject<T>(json, (jsonSerializerOptions ?? GetSerializerOptions()) as JsonSerializerSettings);
        }
        /// <summary>        
        /// ���ض�ȡȫ�����õ� JSON ѡ��        
        /// </summary>        
        /// <returns></returns>        
        public object GetSerializerOptions()
        {
            return App.GetOptions<MvcNewtonsoftJsonOptions>()?.SerializerSettings;
        }
    }
}
