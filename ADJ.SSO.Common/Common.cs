using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ADJ.SSO.Common
{
    public static class Common
    {
        public static void AddCookie(string key, string value, int expires)
        {
            var acookie = new HttpCookie(key);
            acookie.Value = value;
            acookie.Domain = ".a.com";
            acookie.Path = "/";
            acookie.Expires = DateTime.Now.AddMinutes(expires);
            HttpContext.Current.Response.Cookies.Add(acookie);
        }

        public static string GetCookie(string key)
        {
            var httpCookie = HttpContext.Current.Request.Cookies[key];

            if (httpCookie != null)
            {
                return httpCookie.Value;
            }
            return "";
        }

        /// <summary>
        /// 字符串加密
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string Encrypt(this string s)
        {
            return DESEncrypt.Encrypt(s);
        }
        /// <summary>
        /// 字符串解密
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string Decrypt(this string s)
        {
            return DESEncrypt.Decrypt(s);
        }
    }
}