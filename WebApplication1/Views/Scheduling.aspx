﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Scheduling.aspx.cs" Inherits="WebApplication1.Scheduling" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>スケジュール</title>
    <link href="../Contents/css/scheduling_style.css"
	type="text/css" rel="stylesheet" />
    <link href="../Contents/css/jquery-ui.min.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript" src="../Js/jquery1.12.4.js"></script>
    <script type="text/javascript" src="../Js/jquery-ui.min.js"></script>
    <script type="text/javascript" src="../Js/Scheduling_javascript.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div align="center">
		<table border="1" class="calender_config_title">
		<tr>
		<td class="auto-style2">
			<asp:Image ID="Image1" runat="server" ImageUrl="~/Contents/image/header_schedule_01.gif" /><span class="title_string">スケジュール[スケジュール登録]</span>
			<br>
		</td>
		</tr>

		<tr>
		<td class="auto-style2" style="text-align:right">
		 <% if (scheduleId == null)
            { %>
                <asp:Button ID="Insert" runat="server" Text="登録"  OnClick="Insert_Click" CssClass="insert_btn"/>
         <%  }
            else
            { %>
                <asp:Button ID="Update" runat="server" Text="更新"  OnClick="Insert_Click" CssClass="update_btn"/>
                <asp:Button ID="Delete" runat="server" Text="削除"  OnClick="Delete_Click" CssClass="delete_btn"/>
           <% } %>	
                <asp:Button ID="Return" runat="server" OnClick="Return_Click" Text="戻る"  CssClass="return_btn" />
		</td>
		</tr>
		</table><br>
            <asp:Label ID="StartTimeError" runat="server" Text="" CssClass="errorMessage"></asp:Label>
            <asp:Label ID="EndTimeError" runat="server" Text="" CssClass="errorMessage"></asp:Label>
            <asp:Label ID="InsertError" runat="server" Text="" CssClass="errorMessage"></asp:Label>
            <asp:Label ID="UpdateError" runat="server" Text="" CssClass="errorMessage"></asp:Label>
		<table border="1" class="scheduleTable">
			<colgroup span="1" class="tableHeading"></colgroup>
			<colgroup span="1" class="tableContent"></colgroup>
			<tr>
				<th class="heading">名前</th>
				<td class="auto-style1">
                    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                </td>
			</tr>

			<tr>
				<th class="key">開始<span style="color:red">※</span></th>
				<td class="auto-style1">
				<!-- 開始年 -->
				<select name="startYear"  class="startYear">
                    <% int[] yearAndMonth = (int[])Session["yearAndMonth"]; %>                    
                    <% for (int year = 2018; year <= 2022; year++) { %>
                        <% if (scheduleId != null && year == existingStartTime[0])
                            { %>
                            <option value="<%= year %>" selected="selected"><%= year %>年</option>
                        <% } else if (year == yearAndMonth[0]) { %>
							<option value="<%= year %>" selected="selected"><%= year %>年</option>
                        <% } else { %>
							<option value="<%= year %>"><%= year %>年</option>
                        <% } %>
                    <% } %>
				</select>
				<!-- 開始月 -->
				<select name="startMonth" class="startMonth">
                    <% for (int month = 1; month <= 12; month++) { %> 
                        <% if (scheduleId != null && month == existingStartTime[1])
                            { %>
                            <option value="<%= month %>" selected="selected"><%= month %>月</option>
                        <% } else if (month == yearAndMonth[1]) {  %>
							<option value="<%= month %>" selected="selected"><%= month %>月</option>
                        <% } else { %>
							<option value="<%= month %>"><%= month %>月</option>
                        <% } %>
                    <% } %>
				</select>
				<!-- 開始日 -->
				<select name="startDay" class="startDay">
                    <% for (int day = 1; day <= yearAndMonth[2]; day++) { %>
                        <% if (scheduleId != null && day == existingStartTime[2])
                            { %>
                            <option value="<%= day %>" selected="selected"><%= day %>日</option>
                        <% } else if (day == selectedDay) { %>
                            <option value="<%= day %>" selected="selected"><%= day %>日</option>
                        <% } else { %>
                            <option value="<%= day %>"><%= day %>日</option>
                        <% } %>
                    <% } %>
				</select>
                <!-- datepicker -->
                    <input type="button" name="startDatepicker" value="Cal" class="startDatepicker_btn"/>
				<!-- 開始時 -->
				<select name="startOclock">
                        <option value="未設定">未設定</option>
                    <%for (int oclock = 0; oclock <= 23; oclock++) { %>
                        <% if (scheduleId != null && oclock == existingStartTime[3])
                            { %>
                            <option value="<%= oclock %>" selected="selected"><%= oclock %></option>
                        <% } else if (scheduleId == null && oclock == 9) {%>
                            <option value="<%= oclock %>" selected="selected">9</option>
                        <% } else { %>
                            <option value="<%= oclock %>"><%= oclock %></option>
                        <% } %>
                    <% } %>
				</select>時
				<!-- 開始分 -->
				<select name="startMinute">
                    <option value="未設定">未設定</option>
                    <%for (int minute = 0; minute <= 45; minute += 15) { %>
                        <% if (scheduleId != null && minute == existingStartTime[4]) {
                                if (minute == 0)
                                { %>
                                    <option value="<%= minute %>" selected="selected">00</option>
                                <% } else { %>
                                    <option value="<%= minute %>" selected="selected"><%= minute %></option>
                                <% } %>
                        <% } else if (minute == 0) { %>
                            <option value="<%= minute %>" selected="selected">00</option>
                        <% } else { %>
                            <option value="<%= minute %>"><%= minute %></option>
                        <% } %>
                    <% } %>
				</select>分　
			</tr>

			<tr>
				<th>終了<span style="color:red">※</span></th>
				<td class="auto-style1">
				<!-- 終了年 -->
				<select name="endYear" class="endYear">
                    <% for (int year = 2018; year <= 2022; year++) { %>
                        <% if (scheduleId != null && year == existingEndTime[0])
                            { %>
                            <option value="<%= year %>" selected="selected"><%= year %>年</option>
                        <% } else if (year == yearAndMonth[0]) { %>
							<option value="<%= year %>" selected="selected"><%= year %>年</option>
                        <% } else { %>
							<option value="<%= year %>"><%= year %>年</option>
                        <% } %>
                    <% } %>
				</select>
				<!-- 終了月 -->
				<select name="endMonth" class="endMonth">
                    <% for (int month = 1; month <= 12; month++) { %> 
                        <% if (scheduleId != null && month == existingEndTime[1])
                            { %>
                            <option value="<%= month %>" selected="selected"><%= month %>月</option>
                        <% } else if (month == yearAndMonth[1]) {  %>
							<option value="<%= month %>" selected="selected"><%= month %>月</option>
                        <% } else { %>
							<option value="<%= month %>"><%= month %>月</option>
                        <% } %>
                    <% } %>
				</select>
				<!-- 終了日 -->
				<select name="endDay" class="endDay">
                    <% for (int day = 1; day <= yearAndMonth[2]; day++) { %>
                        <% if (scheduleId != null && day == existingEndTime[2])
                            { %>
                            <option value="<%= day %>" selected="selected"><%= day %>日</option>
                        <% } else if (day == selectedDay) { %>
                            <option value="<%= day %>" selected="selected"><%= day %>日</option>
                        <% } else { %>
                            <option value="<%= day %>"><%= day %>日</option>
                        <% } %>
                    <% } %>
				</select>
                <!-- datepicker -->
                <input type="button" name="endDatepicker" value="Cal" class="endDatepicker_btn"/>
			    <!-- 終了時 -->
				<select name="endOclock">
                    <option value="未設定">未設定</option>
                    <%for (int endOclock = 0; endOclock <= 23; endOclock++) { %>
                        <% if (scheduleId != null && endOclock == existingEndTime[3])
                            { %>
                            <option value="<%= endOclock %>" selected="selected"><%= endOclock %></option>
                        <% } else if (scheduleId == null && endOclock == 18) {%>
                            <option value="<%= endOclock %>" selected="selected">18</option>
                        <% } else { %>
                            <option value="<%= endOclock %>"><%= endOclock %></option>
                        <% } %>
                    <% } %>
                </select>時
				<!-- 終了分 -->
				<select name="endMinute">
                    <option value="未設定">未設定</option>
                    <%for (int minute = 0; minute <= 45; minute += 15) { %>
                        <% if (scheduleId != null && minute == existingEndTime[4])
                            { %>
                            <% if (minute == 0)
                                { %>
                                    <option value="<%= minute %>" selected="selected">00</option>
                                <% } else { %>
                                    <option value="<%= minute %>" selected="selected"><%= minute %></option>
                                <% } %>
                        <% } else if (minute == 0) { %>
                            <option value="<%= minute %>" selected="selected">00</option>
                        <% } else { %>
                            <option value="<%= minute %>"><%= minute %></option>
                        <% } %>
                    <% } %>
				</select>分  期間：一日間
			</tr>

			<tr>
				<th>タイトル<span style="color:red">※</span></th>
				<td class="auto-style1">
                    <input type="text" name="title" value="<%= existingTitle %>"   class="title_textbox" />
                    <span class="title_length" style="color:red"></span>
                </td>
			</tr>

			<tr>
				<th>タイトル色</th>
				<td class="auto-style1">
					
				    <span class="radio_01"> <input type="radio"
										name="titleColor" checked="checked" value="1">
							</span> <label for="titleColor_01" class="titleColor_text">訪問</label>
                    <span class="radio_02"> <input type="radio"
										name="titleColor" value="2">
							</span> <label for="titleColor_02" class="titleColor_text">勤怠</label>
                    <span class="radio_03"> <input type="radio"
										name="titleColor"  value="3">
							</span> <label for="titleColor_03" class="titleColor_text">来客</label>
                    <span class="radio_04"> <input type="radio"
										name="titleColor"  value="4">
							</span> <label for="titleColor_04" class="titleColor_text">面談・面接</label>
                    <span class="radio_05"> <input type="radio"
										name="titleColor"  value="5">
							</span> <label for="titleColor_05" class="titleColor_text">私用</label>
					
				</td>
			</tr>

			<tr>
				<th class="auto-style5">内容</th>
				<td class="auto-style6">
                    <textarea name="description" rows="8" cols="50" class="textarea_description"><%= existingDescription %></textarea>
                    <br>
					MAX1000文字<span class="description_length" style="color:red"></span>
				</td>
			</tr>

			<tr>
				<th class="auto-style8">備考</th>
				<td class="auto-style9">
                    <textarea name="note" rows="8" cols="50" class="textarea_note"><%= existingNote %></textarea>
                    <br>
					MAX1000文字 <span class="note_length" style="color:red"></span>
				</td>
			</tr>

            <tr class="configAtSameTimeLine">
                <th class="auto-style10">同時登録</th>
                <td class="configAtSameTime" style="height: 111px">
                <br />
                <span class="configAtSameTimeMessage">[他のユーザへも同じ登録が出来ます]</span>
                    <table style="height: 100px;border-color:white;" class="configAtSameTimeTable">
                        <tr>
                        <td style="width:260px;" class="configAtSameTime">
                            宛先<br />
                            <select multiple="multiple" style="width:250px" class="selectedMembersList">
                            </select>
                        </td>
                        <td style="width:70px;" class="configAtSameTime">
                            <br />
                            <button type="button" class="insertMember">追加</button>
                            <br />
                            <br />
                            <button type="button" class="deleteMember">削除</button>
                        </td>
                        <td style="width:260px;" class="configAtSameTime">
                            <br />
                            <select multiple="multiple" style="width:250px" class="membersList">
                                <% foreach (KeyValuePair<int, string> user in userMap) { %>
                                    <option value="<%= user.Key %>"><%= user.Value %></option>
                                <% } %>
                            </select>
                        </td>
                        </tr>
                    </table>
                </td>
            </tr>

			<tr>
				<th class="auto-style3">登録者</th>
				<td class="auto-style4">
                    <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                </td>
                
			</tr>

		</table>
	</div>
    </form>
</body>
</html>