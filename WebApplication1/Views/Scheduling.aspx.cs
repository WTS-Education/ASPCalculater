using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Scheduling : System.Web.UI.Page
    {
        public int? scheduleId;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["id"] != null)
            {
                scheduleId = int.Parse(Request["id"]);
                Session["scheduleId"] = scheduleId;
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connection"].ToString());
                try
                {
                    con.Open();
                    string query = "select * from T_SCHEDULE where SCHEDULE_ID = " + scheduleId;
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataReader sdr = cmd.ExecuteReader();

                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            DateTime startDatetime = (DateTime)sdr["START_TIMESTMP"];
                            int[] startTime = { startDatetime.Year, startDatetime.Month, startDatetime.Day, startDatetime.Hour, startDatetime.Minute };
                            DateTime endDatetime = (DateTime)sdr["END_TIMESTMP"];
                            int[] endTime = { endDatetime.Year, endDatetime.Month, endDatetime.Day, endDatetime.Hour, endDatetime.Minute };
                            string title = (string)sdr["TITLE"];
                            int titleColor = (int)sdr["TITLE_COLOR"];
                            string description = (string)sdr["DESCRIPTION"];
                            string note = (string)sdr["NOTE"];
                        }
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
            else
            {
            }
            
            Label1.Text = (string)Session["userName"];
            Label2.Text = (string)Session["userName"];
        }

        protected void Return_Click(object sender, EventArgs e)
        {
            Server.Transfer("~/Views/Calendar.aspx");
        }

        /**
        * 登録ボタンクリック→スケジュール登録→登録完了ページ
        **/
        protected void Insert_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connection"].ToString());
            SqlCommand cmd;
            SqlDataAdapter adapter = new SqlDataAdapter();
            string buttonId = ((Button)sender).ID;
            string id = buttonId;

            try
            {
                int startYear = Convert.ToInt32(Request["startYear"]);
                int startMonth = Convert.ToInt32(Request["startMonth"]);
                int startDay = Convert.ToInt32(Request["startDay"]);
                int startOclock = Convert.ToInt32(Request["startOclock"]);
                int startMinute = Convert.ToInt32(Request["startMinute"]);
                DateTime startTime = new DateTime(startYear, startMonth, startDay, startOclock, startMinute, 00, 00);

                int endYear = int.Parse(Request["endYear"]);
                int endMonth = int.Parse(Request["endMonth"]);
                int endDay = int.Parse(Request["endDay"]);
                int endOclock = int.Parse(Request["endOclock"]);
                int endMinute = int.Parse(Request["endMinute"]);
                DateTime endTime = new DateTime(endYear, endMonth, endDay, endOclock, endMinute, 00, 00);

                DateTime now = DateTime.Now;

                string title = Title.Text;

                int titleColor = int.Parse(Request["titleColor"]);

                string description = Description.Text;

                string note = Note.Text;

                int insertOrUpdateUser = (int)Session["userId"];
                int editAuthority = insertOrUpdateUser;
                con.Open();
                if (buttonId == "Insert")
                {
                    string insertQuery = "INSERT INTO T_SCHEDULE (" +
                    "START_TIMESTAMP, END_TIMESTAMP, TITLE, TITLE_COLOR, DESCRIPTION, NOTE, " +
                    "EDIT_AUTHORITY, RELEASE_FLG, INSERT_DATE, INSERT_USER, DELETE_FLG " +
                    ")" +
                    " VALUES (" +
                    "'" + startTime + "', '" + endTime + "', '" + title + "', '" + titleColor + "', '" + description + "', '" + note + "', '" +
                    editAuthority + "'," + "0, '" + now + "', '" + insertOrUpdateUser + "'," + "0" +
                    ");";
                    cmd = new SqlCommand(insertQuery, con);
                    adapter.InsertCommand = new SqlCommand(insertQuery, con);
                    adapter.InsertCommand.ExecuteNonQuery();
                    cmd.Dispose();
                }
                else if (buttonId == "Update")
                {
                    Update_Click(con, adapter, startTime, endTime, title,
                        titleColor, description, note, editAuthority);
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                throw;
            }
            finally
            {
                con.Close();
                Server.Transfer("~/Views/SchedulingIsOk.aspx");
            }

        }
        /**
         *   更新ボタンクリック→スケジュール更新→更新完了ページ
         **/
        protected void Update_Click(SqlConnection con, SqlDataAdapter adapter, DateTime startTime, DateTime endTime,
            string title, int titleColor, string description, string note, int editAuthority)
        {
            DateTime updateTime = DateTime.Now;
            string updateQuery = "UPDATE T_SCHEDULE SET START_TIMESTAMP = " + "'" + startTime + "', " +
                "END_TIMESTAMP = " + "'" + endTime + "', " + "TITLE = " + "'" + title + "', " + "TITLE_COLOR = " + "'" +
                titleColor + "', " + "DESCRIPTION = " + "'" + description + "', " + "NOTE = " + "'" + note + "', " +
                "EDIT_AUTHORITY = " + "'" + editAuthority + "', " + "RELEASE_FLG = " + "'0', " + "UPDATE_DATE = " +
                "'" + updateTime + "', " + "UPDATE_USER = " + "'" + editAuthority + "', " + "DELETE_FLG = " + "'0' " +
                "WHERE SCHEDULE_ID = " + scheduleId + ";";
            SqlCommand cmd = new SqlCommand(updateQuery, con);
            adapter.UpdateCommand = new SqlCommand(updateQuery, con);
            adapter.UpdateCommand.ExecuteNonQuery();
            cmd.Dispose();
        }

        /**
         *   削除ボタンクリック→削除確認ページ
         **/
        protected void Delete_Click(object sender, EventArgs e)
        {
            Server.Transfer("~/Views/DeleteCheck.aspx");
        }
    }
}