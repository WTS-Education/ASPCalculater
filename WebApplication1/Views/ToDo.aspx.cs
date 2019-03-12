using System;
using System.Collections.Generic;

namespace WebApplication1
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["id"] != null)
            {
                Label1.Text = (string)Session["id"];
            }

        }

        protected void Calendar_Click(object sender, EventArgs e)
        {
            Server.Transfer("~/Views/Calendar.aspx");
        }
    }
}