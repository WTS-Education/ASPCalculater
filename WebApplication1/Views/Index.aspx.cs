using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace WebApplication1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connection"].ToString());

            try
            {
                string loginID = LoginId.Text;
                string password = Request["password"];
                con.Open();
                string query = "select * from M_User where LOGIN_ID='" + loginID + "' and PASSWORD='" + password + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.Read())
                {
                    //ログイン成功
                    string userName = sdr["USER_NAME"].ToString();
                    int userId = (int)sdr["USER_ID"];
                    Session["userName"] = userName;
                    Session["userId"] = userId;
                    Server.Transfer("~/Views/ToDo.aspx");
                }
                else
                {
                    //ログイン失敗
                    Label1.Text = "ユーザＩＤまたはパスワードが不正です。入力内容を確認し再度ログインしてください。";
                }
            }
            catch (Exception ex)
            {
                Label1.Text = "ユーザＩＤまたはパスワードが不正です。入力内容を確認し再度ログインしてください。";
            }
            finally
            {
                con.Close();
            }
        }
    }
}
