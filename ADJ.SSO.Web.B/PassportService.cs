using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using ADJ.SSO.Common;
using ADJ.SSO.Web.B.Models;
using ServiceStack.Redis;

namespace ADJ.SSO.Web.B
{
    public class PassportService
    {
        public static string TokenReplace()
        {
            string strHost = HttpContext.Current.Request.Url.Host;
            string strPort = HttpContext.Current.Request.Url.Port.ToString();
            string url = String.Format("http://{0}:{1}{2}", strHost, strPort, HttpContext.Current.Request.RawUrl);
            url = Regex.Replace(url, @"(\?|&)Token=.*", "", RegexOptions.IgnoreCase);
            return ConfigurationManager.AppSettings["UserAuthUrl"] + "?backurl=" + url.Encrypt();
        }
        public void Run()
        {
            var token = Common.Common.GetCookie("token");

            RedisClient client = new RedisClient(ConfigurationManager.AppSettings["RedisServer"], 6379);

            UserInfo userInfo = client.Get<UserInfo>(token);
            if (userInfo == null)
            {
                //令牌错误,重新登录
                Common.Common.AddCookie("token", token, -1);
                HttpContext.Current.Response.Redirect(TokenReplace(), false);
            }
            else
            {
                Common.Common.AddCookie("token", token, Int32.Parse(ConfigurationManager.AppSettings["Timeout"]));
            }
        }

        public UserInfo GetUserInfo()
        {
            var token = Common.Common.GetCookie("token");
            RedisClient client = new RedisClient(ConfigurationManager.AppSettings["RedisServer"], 6379);
            return client.Get<UserInfo>(token) ?? new UserInfo();
        }
    }
}