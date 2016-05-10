using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ADJ.SSO.Common;
using ADJ.SSO.Web.Models;
using ServiceStack;
using ServiceStack.Redis;

namespace ADJ.SSO.Web
{
    public partial class Index : System.Web.UI.Page
    {
        //定义属性
        public string StrTip { get; set; }
        public string UserName { get; set; }
        public string PassWork { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                ValidateUser();
            }
        }

        //登录验证
        private void ValidateUser()
        {
            var username = Request.Form["userName"];
            if (username.Equals(""))
            {
                StrTip = "请输入用户名";
                return;
            }
            var password = Request.Form["passWord"];
            if (password.Equals(""))
            {
                StrTip = "请输入密码";
                return;
            }

            //模拟登录
            if (username == "admin" && password == "admin")
            {
                UserInfo userInfo=new UserInfo()
                {
                    UserName = "admin",PassWord = "admin",Info ="登录模拟" 
                };

                //生成token
                var token = Guid.NewGuid().ToString();
                //写入token
                Common.Common.AddCookie("token", token, Int32.Parse(ConfigurationManager.AppSettings["Timeout"]));
                //写入凭证
                RedisClient client = new RedisClient(ConfigurationManager.AppSettings["RedisServer"], 6379);
                client.Set<UserInfo>(token, userInfo);


                //跳转回分站
                if (Request.QueryString["backurl"] != null)
                {
                    Response.Redirect(Request.QueryString["backurl"].Decrypt(), false);
                }
                else
                {
                    Response.Redirect(ConfigurationManager.AppSettings["DefaultUrl"], false);
                }
            }
            else
            {
                StrTip = "用户名或密码有误!";
                return; 
            }

        }
    }
}