using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Linq;

namespace WebApplication1
{
    public partial class Scheduling : System.Web.UI.Page
    {
        public int? selectedDay;

        public int? scheduleId;
        public int[] existingStartTime = new int[5];
        public int[] existingEndTime = new int[5];
        public string existingTitle;
        public int existingTitleColor;
        public string existingDescription;
        public string existingNote;

        public IDictionary<int, string> userMap = new Dictionary<int, string>();

        /**
         *  ページ読み込み時
         **/
        protected void Page_Load(object sender, EventArgs e)
        {
            var db = new DataClasses1DataContext(ConfigurationManager.ConnectionStrings["connection"].ToString());

            //スケジュール登録ボタン押下→日付取得→取得した日付で開始日時・終了日時表示
            if (Request["day"] != null)
            {
            selectedDay = int.Parse(Request["day"]);
            }
            //スケジュールリンク押下→スケジュールID取得→既存スケジュール表示
            if (Request["id"] != null)
            {
                scheduleId = int.Parse(Request["id"]);

                //既存スケジュール検索
                var allSchedule = from schedule in db.T_SCHEDULE
                                  where schedule.SCHEDULE_ID == scheduleId
                                  select schedule;
                foreach(var schedule in allSchedule)
                {
                    DateTime startDateTime = schedule.START_TIMESTAMP;
                    existingStartTime[0] = startDateTime.Year;
                    existingStartTime[1] = startDateTime.Month;
                    existingStartTime[2] = startDateTime.Day;
                    existingStartTime[3] = startDateTime.Hour;
                    existingStartTime[4] = startDateTime.Minute;
                    DateTime endDateTime = schedule.END_TIMESTAMP;
                    existingEndTime[0] = endDateTime.Year;
                    existingEndTime[1] = endDateTime.Month;
                    existingEndTime[2] = endDateTime.Day;
                    existingEndTime[3] = endDateTime.Hour;
                    existingEndTime[4] = endDateTime.Minute;

                    existingTitle = schedule.TITLE;
                    if (existingTitle.Contains("&"))
                    {
                        existingTitle = Regex.Replace(existingTitle, "&", "&amp;");
                    }
                    if (existingTitle.Contains("\""))
                    {
                        existingTitle = Regex.Replace(existingTitle, "\"", "&quot;");
                    }
                    if (existingTitle.Contains("'"))
                    {
                        existingTitle = Regex.Replace(existingTitle, "'", "&#39;");
                    }

                    existingDescription = schedule.DESCRIPTION;
                    if (existingDescription.Contains("&"))
                    {
                        existingDescription = Regex.Replace(existingDescription, "&", "&amp;");
                    }
                    if (existingDescription.Contains("\""))
                    {
                        existingDescription = Regex.Replace(existingDescription, "\"", "&quot;");
                    }
                    if (existingDescription.Contains("'"))
                    {
                        existingDescription = Regex.Replace(existingDescription, "'", "&#39;");
                    }

                    existingNote = schedule.NOTE;
                    if (existingNote.Contains("&"))
                    {
                        existingNote = Regex.Replace(existingNote, "&", "&amp;");
                    }
                    if (existingNote.Contains("\""))
                    {
                        existingNote = Regex.Replace(existingNote, "\"", "&quot;");
                    }
                    if (existingNote.Contains("'"))
                    {
                        existingNote = Regex.Replace(existingNote, "'", "&#39;");
                    }
                }
                //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connection"].ToString());
                //try
                //{
                //    con.Open();
                //    string query = "select START_TIMESTAMP, END_TIMESTAMP,TITLE, TITLE_COLOR, DESCRIPTION, NOTE" +
                //        " from T_SCHEDULE where SCHEDULE_ID = " + scheduleId;
                //    SqlCommand cmd = new SqlCommand(query, con);
                //    SqlDataReader sdr = cmd.ExecuteReader();
                }
            else
            {
            }

            Label1.Text = (string)Session["userName"];
            Label2.Text = (string)Session["userName"];

            //同時登録ユーザ検索
            var allUser = from user in db.M_User
                          select user;
            foreach(var user in allUser)
            {
                int userId = user.USER_ID;
                string userName = user.USER_NAME;
                userMap.Add(userId, userName);
            }
        }
        /**
         * 戻るボタン押下時
         **/ 
        protected void Return_Click(object sender, EventArgs e)
        {
            Server.Transfer("~/Views/Calendar.aspx");
        }

        /**
        * 登録又は更新ボタン押下時
        **/
        protected void Insert_Click(object sender, EventArgs e)
        {
            StartTimeError.Text = "";
            EndTimeError.Text = "";

            //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connection"].ToString());
            //SqlCommand cmd;
            //SqlDataAdapter adapter = new SqlDataAdapter();

            string buttonId = ((Button)sender).ID;
            string id = buttonId;
            int startYear = Convert.ToInt32(Request["startYear"]);
            int startMonth = Convert.ToInt32(Request["startMonth"]);
            int startDay = Convert.ToInt32(Request["startDay"]);
            int startOclock = Convert.ToInt32(Request["startOclock"]);
            int startMinute = Convert.ToInt32(Request["startMinute"]);

            int endYear = int.Parse(Request["endYear"]);
            int endMonth = int.Parse(Request["endMonth"]);
            int endDay = int.Parse(Request["endDay"]);
            int endOclock = int.Parse(Request["endOclock"]);
            int endMinute = int.Parse(Request["endMinute"]);

            string title = Request["title"];
            if (title.Contains("'"))
            {
                title = Regex.Replace(title, "'", "''");
            }

            int titleColor = int.Parse(Request["titleColor"]);

            string description = Request["description"];
            if (description.Contains("'"))
            {
                description = Regex.Replace(description, "'", "''");
            }

            string note = Request["note"];
            if (note.Contains("'"))
            {
                note = Regex.Replace(note, "'", "''");
            }

            int insertOrUpdateUser = (int)Session["userId"];
            int editAuthority = insertOrUpdateUser;

            if (startDay <= DateTime.DaysInMonth(startYear, startMonth) && endDay <= DateTime.DaysInMonth(endYear, endMonth))
            {
                //try
                //{
                    DateTime startTime = new DateTime(startYear, startMonth, startDay, startOclock, startMinute, 00, 00);
                    DateTime endTime = new DateTime(endYear, endMonth, endDay, endOclock, endMinute, 00, 00);
                    DateTime now = DateTime.Now;

                    //con.Open();
                    //登録ボタン押下時
                    if (buttonId == "Insert")
                    {
                        var db = new DataClasses1DataContext(ConfigurationManager.ConnectionStrings["connection"].ToString());

                        T_SCHEDULE scedule = new T_SCHEDULE
                        {
                            START_TIMESTAMP = startTime,
                            END_TIMESTAMP = endTime,
                            TITLE = title,
                            TITLE_COLOR = titleColor,
                            DESCRIPTION = description,
                            NOTE = note,
                            EDIT_AUTHORITY = editAuthority,
                            RELEASE_FLG = '0',
                            INSERT_DATE = now,
                            INSERT_USER = insertOrUpdateUser,
                            DELETE_FLG = '0'
                        };

                        db.T_SCHEDULE.InsertOnSubmit(scedule);
                        try
                        {
                            db.SubmitChanges();
                            Server.Transfer("~/Views/SchedulingIsOk.aspx");
                        }
                        catch (Exception insertError)
                        {
                            InsertError.Text = "登録エラーが発生しました";
                            db.SubmitChanges();
                        }

                    ////INSERT SQL文
                    //string insertQuery = "INSERT INTO T_SCHEDULE (" +
                    //"START_TIMESTAMP, END_TIMESTAMP, TITLE, TITLE_COLOR, DESCRIPTION, NOTE, " +
                    //"EDIT_AUTHORITY, RELEASE_FLG, INSERT_DATE, INSERT_USER, DELETE_FLG " +
                    //")" +
                    //" VALUES (" +
                    //"'" + startTime + "', '" + endTime + "', '" + title + "', '" + titleColor + "', '" + description + "', '" + note + "', '" +
                    //editAuthority + "'," + "0, '" + now + "', '" + insertOrUpdateUser + "'," + "0" +
                    //");";

                    //cmd = new SqlCommand(insertQuery, con);


                    //adapter.InsertCommand = new SqlCommand(insertQuery, con);
                    ////sql実行
                    //adapter.InsertCommand.ExecuteNonQuery();
                    //cmd.Dispose();
                    }
                    //更新ボタン押下時
                    else if (buttonId == "Update")
                    {
                        Update_Click(startTime, endTime, title,
                            titleColor, description, note, editAuthority);
                    }
                //}
                //catch (Exception exception)
                //{
                //    Console.WriteLine(exception.Message);
                //    throw;
                //}
                //finally
                //{
                //    con.Close();
                //    Server.Transfer("~/Views/SchedulingIsOk.aspx");
                //}
            } else
            {
                //存在しない日付が選択された場合(EX.2月31日)
                if (DateTime.DaysInMonth(startYear, startMonth) < startDay)
                {
                    StartTimeError.Text = "[開始日]は存在しない日付です。正しい日付を入力してください。";
                }
                if (DateTime.DaysInMonth(endYear, endMonth) < endDay)
                {
                    EndTimeError.Text = "[終了日]は存在しない日付です。正しい日付を入力してください。";
                }
            }
        }
        /**
         *  　スケジュール更新
         **/
        protected void Update_Click(DateTime startTime, DateTime endTime, string title, 
            int titleColor, string description, string note, int editAuthority)
        {
            DateTime updateTime = DateTime.Now;

            var db = new DataClasses1DataContext(ConfigurationManager.ConnectionStrings["connection"].ToString());
            var existingSchedule =
                from schedule in db.T_SCHEDULE
                where schedule.SCHEDULE_ID == scheduleId
                select schedule;
            foreach(T_SCHEDULE schedule in existingSchedule)
            {
                schedule.START_TIMESTAMP = startTime;
                schedule.END_TIMESTAMP = endTime;
                schedule.TITLE = title;
                schedule.TITLE_COLOR = titleColor;
                schedule.DESCRIPTION = description;
                schedule.NOTE = note;
                schedule.EDIT_AUTHORITY = editAuthority;
                schedule.RELEASE_FLG = '0';
                schedule.UPDATE_DATE = updateTime;
                schedule.UPDATE_USER = editAuthority;
                schedule.DELETE_FLG = '0';
            }

            try
            {
                db.SubmitChanges();
                Server.Transfer("~/Views/SchedulingIsOk.aspx");
            }
            catch (Exception updateError)
            {
                InsertError.Text = "更新エラーが発生しました";
                db.SubmitChanges();
            }

            //UPDATE SQL文
            //string updateQuery = "UPDATE T_SCHEDULE SET START_TIMESTAMP = " + "'" + startTime + "', " +
            //    "END_TIMESTAMP = " + "'" + endTime + "', " + "TITLE = " + "'" + title + "', " + "TITLE_COLOR = " + "'" +
            //    titleColor + "', " + "DESCRIPTION = " + "'" + description + "', " + "NOTE = " + "'" + note + "', " +
            //    "EDIT_AUTHORITY = " + "'" + editAuthority + "', " + "RELEASE_FLG = " + "'0', " + "UPDATE_DATE = " +
            //    "'" + updateTime + "', " + "UPDATE_USER = " + "'" + editAuthority + "', " + "DELETE_FLG = " + "'0' " +
            //    "WHERE SCHEDULE_ID = " + scheduleId + ";";
            //SqlCommand cmd = new SqlCommand(updateQuery, con);
            //adapter.UpdateCommand = new SqlCommand(updateQuery, con);
            //adapter.UpdateCommand.ExecuteNonQuery();
            //cmd.Dispose();
        }

        /**
         *   削除ボタンクリック→削除確認ページ
         **/
        protected void Delete_Click(object sender, EventArgs e)
        {
            Session["scheduleId"] = scheduleId;
            Server.Transfer("~/Views/DeleteCheck.aspx");
        }
    }
}