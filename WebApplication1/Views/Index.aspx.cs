using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;

namespace WebApplication1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        string userName;
        int userId;

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //ログイン成功
            if (IsValidUser(LoginId.Text, Request["password"]))
            {
                Server.Transfer("~/Views/ToDo.aspx");
            }
            //ログイン失敗
            else
            {
                Label1.Text = "ユーザＩＤまたはパスワードが不正です。入力内容を確認し再度ログインしてください。";
            }
        }

        protected bool IsValidUser(string loginID, string password)
        {
            string basedir = AppDomain.CurrentDomain.BaseDirectory;
            var db = new DataClasses1DataContext(ConfigurationManager.ConnectionStrings["connection"].ToString());
            var userData =
                from user in db.M_User
                where user.LOGIN_ID.Equals(loginID) && user.PASSWORD.Equals(password)
                select new { userName = user.USER_NAME, userId = user.USER_ID };

            if (userData.Any())
            {
                foreach(var user in userData)
                {
                    Session["userName"] = user.userName;
                    Session["userId"] = user.userId;
                }
                return true;
            } else {
                return false;
            }
        }
    }
}
