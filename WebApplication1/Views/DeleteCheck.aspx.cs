using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.Views
{
    public partial class DeleteCheck : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Yes_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connection"].ToString());
            try
            {
                SqlCommand cmd;
                SqlDataAdapter adapter = new SqlDataAdapter();
                int scheduleId = (int)Session["schedule_id"];
                con.Open();
                string deleteQuery = "DELETE FROM T_SCHEDULE WHERE SCHEDULE_ID = " + scheduleId + ";";
                cmd = new SqlCommand(deleteQuery, con);
                adapter.DeleteCommand = new SqlCommand(deleteQuery, con);
                adapter.DeleteCommand.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                throw;
            }
            finally
            {
                con.Close();
                Server.Transfer("~/Views/DeletingIsOk.aspx");
            }
            
        }

        protected void No_Click(object sender, EventArgs e)
        {
            Server.Transfer("~/Views/Scheduling.aspx");
        }
    }
}