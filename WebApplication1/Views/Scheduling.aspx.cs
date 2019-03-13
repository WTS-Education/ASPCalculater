﻿using System;
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
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = (String)Session["userName"];
            Label2.Text = (String)Session["userName"];
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
            Button button = (Button)sender;
            string buttonId = button.ID;

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

                int scheduleId = (int)Session["schedule_id"];
                int insertOrUpdateUser = int.Parse((String)Session["userId"]);
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
                        titleColor, description, note, editAuthority, scheduleId);
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
            string title, int titleColor, string description, string note, int editAuthority,
            int scheduleId)
        {
            DateTime updateTime = DateTime.Now;
            string updateQuery = "UPDATE T_SCHEDULE SET START_TIMESTAMP = " + "'" + startTime + "', " +
                "END_TIMESTAMP = " + "'" + endTime + "', " + "TITLE = " + "'" + title + "', " + "TITLE_COLOR = " + "'" +
                titleColor + "', " + "DESCRIPTION = " + "'" + description + "', " + "NOTE = " + "'" + note + "', " +
                "EDIT_AUTHORITY = " + "'" + editAuthority + "', " + "RELEASE_FLG = " + "'0', " + "UPDATE_DATE = " +
                "'" + updateTime + "', " + "UPDATE_USER = " + "'" + scheduleId + "', " + "DELETE_FLG = " + "'0' " +
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