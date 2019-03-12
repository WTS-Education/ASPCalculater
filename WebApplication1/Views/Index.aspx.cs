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
                string loginID = LoginID.Text;
                string password = Request["password"];
                con.Open();
                string query = "select * from M_User where LOGIN_ID='" + loginID + "' and PASSWORD='" + password + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.Read())
                {
                    //ログイン成功
                    String userName = sdr["USER_NAME"].ToString();
                    String userId = sdr["USER_ID"].ToString();
                    Session["userName"] = userName;
                    Session["userId"] = userId;
                    Server.Transfer("~/Views/ToDo.aspx");
                }
                else
                {
                    //ログイン失敗
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }      
    }
}
