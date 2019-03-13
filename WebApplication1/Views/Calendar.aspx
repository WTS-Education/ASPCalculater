<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Calendar.aspx.cs" Inherits="WebApplication1.WebForm3" %>
<%@ Import Namespace="System"%>
<%@ Import Namespace="System.Collections.Generic" %>
<%@ Import Namespace="WebApplication1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<link href="~/Contents/css/calendar_style.css" type="text/css" rel="stylesheet" />
    <title>カレンダー</title>
    <style type="text/css">
        .auto-style1 {
            width: 16px;
            height: 15px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div style="height: 487px">
        <table border="1" class="calendar_titleAndBtn">
		<tr>
			<td><asp:Image ID="Image1" runat="server" ImageUrl="~/Contents/image/header_schedule_01.gif" />
                <span class="title_string">スケジュール[月間]</span> <br>
			</td>
		</tr>
        <tr>
            <td>
                <% int[] yearAndMonth = (int[])Session["yearAndMonth"]; %> 
                <%= yearAndMonth[0] %>年<%= yearAndMonth[1] %>月
                <div class="btn">
                    <asp:ImageButton ID="ImageButton3" runat="server"  ImageUrl="~/Contents/image/arrow2_l.gif" OnClick="ImageButton3_Click" />
                    <asp:Button ID="Insert" runat="server" Text="今月" CssClass="thisMonth_btn" OnClick="Insert_Click" />
                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Contents/image/arrow2_r.gif" OnClick="ImageButton1_Click" />
                </div>
            </td>
        </tr>
        </table>
            
                <br />
            
                <table border="1" style="width: 80%; height: 388px;">
                    <colgroup span="1" class="sunday"></colgroup>
			        <colgroup span="5"></colgroup>
			        <colgroup span="1" class="saturday"></colgroup>
                    <tr class="dayOfTheWeek">
				        <th style="color: red">日</th>
				        <th>月</th>
				        <th>火</th>
				        <th>水</th>
				        <th>木</th>
				        <th>金</th>
				        <th style="color: blue">土</th>
			        </tr>
                    <%  List<List<int>> dayListDividedBy5or6weeks = new List<List<int>>();
                        dayListDividedBy5or6weeks = (List<List<int>>)Session["dayListDividedBy5or6weeks"];
                        foreach (List<int> week in dayListDividedBy5or6weeks)
                        {
                    %>
                    <tr align="right" valign="top">
                        <% foreach (int day in week)
                            {
                        %>
                            <td class="dayOfMonth">
							    <span class="btn">
                                    <button type="submit" runat="server" name="selectedDay" value="<%= day %>" class="schedule_btn" onserverclick="Scadd_Click">
								        <asp:Image ID="Image2" ImageUrl="~/Contents/image/scadd.gif" runat="server" />
							        </button>
							    </span>
                                <%= day %>
                                <br><br>
                                <% for (int i = 0; i < scheduleList.Count; i++)
                                    { %>
                                       <%  schedule = scheduleList[i];
                                           if (yearAndMonth[0] == schedule.startDateTime.Year && yearAndMonth[1] == schedule.startDateTime.Month && day == schedule.startDateTime.Day) {%>
                                            <% if (schedule.titleColor == 0)
                                                {%>
                                                <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" CssClass="blueLink">
                                                    <%= schedule.startDateTime.Hour %>:<%= schedule.startDateTime.Minute %>~<%= schedule.endDateTime.Hour  %>:<%= schedule.endDateTime.Minute %><br>
                                                    <%= schedule.title %>
                                                </asp:LinkButton>
                                            <% }else if (schedule.titleColor == 1){ %>
                                                <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton1_Click"  CssClass="redLink" CommandArgument="<%= schedule.scheduleId %>">
                                                    <%= schedule.startDateTime.Hour %>:<%= schedule.startDateTime.Minute %>~<%= schedule.endDateTime.Hour  %>:<%= schedule.endDateTime.Minute %><br>
                                                    <%= schedule.title %>
                                                </asp:LinkButton>
                                            <% }else if (schedule.titleColor == 2){ %>
                                                <asp:LinkButton ID="LinkButton3" runat="server" OnClick="LinkButton1_Click"  CssClass="greenLink" CommandArgument="<%= schedule.scheduleId %>">
                                                    <%= schedule.startDateTime.Hour %>:<%= schedule.startDateTime.Minute %>~<%= schedule.endDateTime.Hour  %>:<%= schedule.endDateTime.Minute %><br>
                                                    <%= schedule.title %>
                                                </asp:LinkButton>
                                            <% }else if (schedule.titleColor == 3){ %>
                                                <asp:LinkButton ID="LinkButton4" runat="server" OnClick="LinkButton1_Click"  CssClass="orangeLink" CommandArgument="<%= schedule.scheduleId %>">
                                                    <%= schedule.startDateTime.Hour %>:<%= schedule.startDateTime.Minute %>~<%= schedule.endDateTime.Hour  %>:<%= schedule.endDateTime.Minute %><br>
                                                    <%= schedule.title %>
                                                </asp:LinkButton>
                                            <% }else if (schedule.titleColor == 4){ %>
                                                <asp:LinkButton ID="LinkButton5" runat="server" OnClick="LinkButton1_Click"  CssClass="blackLink" CommandArgument="<%= schedule.scheduleId %>">
                                                    <%= schedule.startDateTime.Hour %>:<%= schedule.startDateTime.Minute %>~<%= schedule.endDateTime.Hour  %>:<%= schedule.endDateTime.Minute %><br>
                                                    <%= schedule.title %>
                                                </asp:LinkButton>
                                            <% } %>
                                        <% } else{ } %>
                                <% } %>
                            </td>
                            <% } %>
                        <% } %>
                </table>
            </form>
        </div>
    </form>
</body>
</html>