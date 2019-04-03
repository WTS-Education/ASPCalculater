using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Linq;

namespace WebApplication1.Views
{
    public partial class DeleteCheck : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Yes_Click(object sender, EventArgs e)
        {
            int scheduleId = (int)Session["scheduleId"];

            var db = new DataClasses1DataContext(ConfigurationManager.ConnectionStrings["connection"].ToString());
            var existingSchedule =
                from schedule in db.T_SCHEDULE
                where schedule.SCHEDULE_ID == scheduleId
                select schedule;
            foreach(var schedule in existingSchedule)
            {
                db.T_SCHEDULE.DeleteOnSubmit(schedule);
            }
            try
            {
                db.SubmitChanges();
                Server.Transfer("~/Views/DeletingIsOk.aspx");
            }
            catch (Exception deleteError)
            {
                DeleteError.Text = "削除エラーが発生しました";
            }

            //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connection"].ToString());
            //try
            //{
            //    SqlCommand cmd;
            //    SqlDataAdapter adapter = new SqlDataAdapter();
                
            //    con.Open();
            //    string deleteQuery = "DELETE FROM T_SCHEDULE WHERE SCHEDULE_ID = " + scheduleId + ";";
            //    cmd = new SqlCommand(deleteQuery, con);
            //    adapter.DeleteCommand = new SqlCommand(deleteQuery, con);
            //    adapter.DeleteCommand.ExecuteNonQuery();
            //    cmd.Dispose();
            //}
            //catch (Exception exception)
            //{
            //    Console.WriteLine(exception.Message);
            //    throw;
            //}
            //finally
            //{
            //    con.Close();
            //    Server.Transfer("~/Views/DeletingIsOk.aspx");
            //}
            
        }

        protected void No_Click(object sender, EventArgs e)
        {
            Server.Transfer("~/Views/Scheduling.aspx");
        }
    }
}