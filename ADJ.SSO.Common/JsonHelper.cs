using Newtonsoft.Json;

namespace ADJ.SSO.Common
{
    public static class JsonHelper
    {
        /// <summary>   
        /// 对象转换为JSON字符串
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static string ObjectToJson(object item)
        {
            string res = JsonConvert.SerializeObject(item);
            return res;
        }
        /// <summary>
        /// JSON转换为对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="jsonString"></param>
        /// <returns></returns>
        public static T JsonToObject<T>(string jsonString)
        {
            T res = JsonConvert.DeserializeObject<T>(jsonString);
            return res;
        }
    }
}