using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.Views;

namespace WebApplication1
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int year, month, firstDayOfWeek;
            DateTime dateTime = DateTime.Now;

            /* 現在表示されている年、月を格納する配列 [0] = 年 [1] = 月 */
            int[] yearAndMonth = (int[])Session["yearAndMonth"];
            if (yearAndMonth == null)
            {
                yearAndMonth = new int[3];
                yearAndMonth[0] = dateTime.Year;
                yearAndMonth[1] = dateTime.Month;
            }
            year = yearAndMonth[0];
            month = yearAndMonth[1];

            /* 月の値を加算減算 */
            if (Session["previous"] != null)
            {
                if (month == 1)
                {
                    year -= 1;
                    month = 12;
                    yearAndMonth[0] = year;
                }
                else
                {
                    month -= 1;
                }
                Session["previous"] = null;
            }
            else if (Session["next"] != null)
            {
                if (month == 12)
                {
                    year += 1;
                    month = 1;
                    yearAndMonth[0] = year;
                }
                else
                {
                    month += 1;
                }

                Session["next"] = null;
            }
            yearAndMonth[1] = month;

            /* 先月最終日 */
            int previousMonthlastDay;
            if (month == 1)
            {
                previousMonthlastDay = DateTime.DaysInMonth(year, 12);
            } else
            {
                previousMonthlastDay = DateTime.DaysInMonth(year, month - 1);
            }
            /* 今月最終日 */
            int thisMonthlastDay = DateTime.DaysInMonth(year, month);
            yearAndMonth[2] = thisMonthlastDay;
            /* 今月ついたちは何曜日?(日:0～土:6) */
            DateTime dateTime2 = new DateTime(year, month, 1);
            firstDayOfWeek = (int)dateTime2.DayOfWeek + 1;

            Session["yearAndMonth"] = yearAndMonth;

            /* 35日分(1週間 * 5)の配列 */
            var dayList = new List<int>();

            /* 先月分の日付 */
            for (int i = firstDayOfWeek - 2; i >= 0; i--)
            {
                dayList.Add(previousMonthlastDay - i);
            }

            /* 今月の日付 */
            for (int i = 1; i <= thisMonthlastDay; i++)
            {
                dayList.Add(i);
            }
            /* 来月分の日付 */
            int nextMonthDay = 1;
            while (dayList.Count < 42)
            {
                dayList.Add(nextMonthDay++);
            }

            int count = 0;
            var dayListDividedBy5or6weeks = new List<List<int>>();

            for (int i = 0; i < 6; i++)
            {
                var dayOfWeek = new List<int>();
                for (int j = 0; j < 7; j++)
                {
                    int oneWeek = dayList[count++];
                    dayOfWeek.Add(oneWeek);
                }
                dayListDividedBy5or6weeks.Add(dayOfWeek);
                if (i == 4 && dayOfWeek.Contains(thisMonthlastDay))
                {
                    break;
                }
            }

            /* 日付配列をセッションスコープに格納 */
            Session["dayListDividedBy5or6weeks"] = dayListDividedBy5or6weeks;

            //スケジュール検索
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connection"].ToString());
            try
            {
                con.Open();
                string query = "select * from T_SCHEDULE";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader sdr = cmd.ExecuteReader();
                List<T_SCHEDULE> scheduleList = new List<T_SCHEDULE>();

                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        int scheduleId = (int)sdr["SCHEDULE_ID"];
                        Session["schedule_id"] = scheduleId;
                        int titleColor = (int)sdr["titleColor"];
                        string title = (string)sdr["TITLE"];
                        Session["title"] = title;
                        string description = (string)sdr["DESCRIPTION"];
                        string note = (string)sdr["NOTE"];
                        DateTime start = (DateTime)sdr["START_TIMESTAMP"];
                        int startYear = start.Year;
                        int startMonth = start.Month;
                        int startDay = start.Day;
                        int startOclock = start.Hour;
                        int startMinute = start.Minute;
                        int[] startTime = { startYear, startMonth, startDay, startOclock, startMinute };
                        Session["startTime"] = startTime;
                        DateTime end = (DateTime)sdr["END_TIMESTAMP"];
                        int endOclock = end.Hour;
                        int endMinute = end.Minute;
                        int[] endTime = { endOclock, endMinute };
                        Session["endTime"] = endTime;
                        T_SCHEDULE schedule = new T_SCHEDULE(scheduleId, start, end, title, titleColor, description, note);
                        scheduleList.Add(schedule);
                    }
                    Session["scheduleList"] = scheduleList;
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

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Insert_Click(object sender, EventArgs e)
        {
            Session["yearAndMonth"] = null;
            Server.Transfer("~/Views/Calendar.aspx");
        }

        protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
        {
            Session["previous"] = "previous";
            Server.Transfer("~/Views/Calendar.aspx");
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Session["next"] = "next";
            Server.Transfer("~/Views/Calendar.aspx");
        }

        protected void Scadd_Click(object sender, EventArgs e)
        {
            Server.Transfer("~/Views/Scheduling.aspx");
        }

        protected void Scadd_command(object sender, CommandEventArgs e)
        {
            int selectedDay = int.Parse(e.CommandArgument.ToString());
            Server.Transfer("~/Views/Calendar.aspx");
        }

    }
}