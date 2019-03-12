﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Scheduling.aspx.cs" Inherits="WebApplication1.Scheduling" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>スケジュール</title>
    <link href="../Contents/css/scheduling_style.css"
	type="text/css" rel="stylesheet" />
    <style type="text/css">
        .auto-style1 {
            width: 611px;
        }
        .auto-style2 {
            width: 690px;
        }
        .auto-style3 {
            height: 37px;
        }
        .auto-style4 {
            width: 611px;
            height: 37px;
        }
        .auto-style5 {
            height: 157px;
        }
        .auto-style6 {
            width: 611px;
            height: 157px;
        }
        .auto-style7 {
            margin-top: 0px;
        }
        .auto-style8 {
            height: 164px;
        }
        .auto-style9 {
            width: 611px;
            height: 164px;
        }
    </style>
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
			
		    <asp:Button ID="Insert" runat="server" Text="登録" CssClass="insert_btn" OnClick="Insert_Click" />
            <asp:Button ID="Update" runat="server" Text="更新" CssClass="update_btn" OnClick="Insert_Click" />
            <asp:Button ID="Delete" runat="server" Text="削除" CssClass="delete_btn" OnClick="Delete_Click" />
            <asp:Button ID="Return" runat="server" OnClick="Return_Click" Text="戻る" CssClass="return_btn" />
			
		</td>
		</tr>
		</table><br>


		<table border="1">
			<colgroup span="1" class="tableHeading"></colgroup>
			<colgroup span="1" class="tableContent"></colgroup>
			<tr>
				<th class="heading">名前</th>
				<td class="auto-style1">
                    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                </td>
			</tr>

			<tr>
				<th class="key">開始</th>
				<td class="auto-style1">
				<!-- 開始年 -->
				<select name="startYear">
                    <% int[] yearAndMonth = (int[])Session["yearAndMonth"]; %>                    
                    <% for (int year = 2018; year <= 2022; year++) { %>                        
                        <%if (year == yearAndMonth[0])
                        { %>
							<option value="<%= year %>" selected><%= year %>年</option>
                        <% } else { %>
							<option value="<%= year %>"><%= year %>年</option>
                        <% } %>
                    <% } %>
				</select>
				<!-- 開始月 -->
				<select name="startMonth">
                    <% for (int month = 1; month <= 12; month++) { %>                    
                        <%  if (month ==  yearAndMonth[1]) { %>
							<option value="<%= month %>" selected><%= month %>月</option>
                        <% } else { %>
							<option value="<%= month %>"><%= month %>月</option>
                        <% } %>
                    <% } %>
				</select>
				<!-- 開始日 -->
				<select name="startDay">
                    <% for (int day = 1; day <= yearAndMonth[2]; day++) { %>                       
                        <% if (Session["selectedDay"] != null && day == (int)Session["selectedDay"]) { %>
							<option value="<%= day %>" selected><%= day %>日</option>
                        <% } else { %>
                            <option value="<%= day %>"><%= day %>日</option>
                        <% } %>                    
                    <% } %>
				</select>
				<!-- 開始時 -->
				<select name="startOclock">
                    <%for (int oclock = 0; oclock <= 23; oclock++) { %>
                        <option value="<%= oclock %>"><%= oclock %></option>
                    <% } %>
				</select>時
				<!-- 開始分 -->
				<select name="startMinute">
                    <%for (int minute = 0; minute <= 45; minute += 15) { %>
                        <option value="<%= minute %>"><%= minute %></option>
                    <% } %>
				</select>分　
			</tr>

			<tr>
				<th>終了</th>
				<td class="auto-style1">
				<!-- 終了年 -->
				<select name="endYear">
                    <% for (int year = 2018; year <= 2022; year++) { %>                        
                        <%if (year == yearAndMonth[0]) { %>
							<option value="<%= year %>" selected><%= year %>年</option>
                        <% } else { %>
							<option value="<%= year %>"><%= year %>年</option>
                        <% } %>
                    <% } %>
				</select>
				<!-- 終了月 -->
				<select name="endMonth">
                    <% for (int month = 1; month <= 12; month++) { %>                    
                        <%  if (month ==  yearAndMonth[1]) { %>
							<option value="<%= month %>" selected><%= month %>月</option>
                        <% } else { %>
							<option value="<%= month %>"><%= month %>月</option>
                        <% } %>
                    <% } %>
				</select>
				<!-- 終了日 -->
				<select name="endDay">
                    <% for (int day = 1; day <= yearAndMonth[2]; day++) { %>                        
                        <% if (Session["selectedDay"] != null && day == (int)Session["selectedDay"]) { %>
							<option value="<%= day %>" selected><%= day %>日</option>
                        <% } else { %>
                            <option value="<%= day %>"><%= day %>日</option>
                        <% } %>                    
                    <% } %>
				</select>
				<!-- 終了時 -->
				<select name="endOclock">
                    <%for (int oclock = 0; oclock <= 23; oclock++) { %>
                        <option value="<%= oclock %>"><%= oclock %></option>
                    <% } %>
				</select>時
				<!-- 終了分 -->
				<select name="endMinute">
                    <%for (int minute = 0; minute <= 45; minute += 15) { %>
                        <option value="<%= minute %>"><%= minute %></option>
                    <% } %>
				</select>分  期間：一日間
				
			</tr>

			<tr>
				<th>タイトル</th>
				<td class="auto-style1">
			    
                    <asp:TextBox ID="Title" runat="server"></asp:TextBox>
			    
                </td>
			</tr>

			<tr>
				<th>タイトル色</th>
				<td class="auto-style1">
					
				    <span class="radio_01"> <input type="radio"
										name="titleColor" checked="checked" value="0">
							</span> <label for="titleColor_01" class="titleColor_text">訪問</label>
                    <span class="radio_02"> <input type="radio"
										name="titleColor" value="1">
							</span> <label for="titleColor_02" class="titleColor_text">勤怠</label>
                    <span class="radio_03"> <input type="radio"
										name="titleColor"  value="2">
							</span> <label for="titleColor_03" class="titleColor_text">来客</label>
                    <span class="radio_04"> <input type="radio"
										name="titleColor"  value="3">
							</span> <label for="titleColor_04" class="titleColor_text">面談・面接</label>
                    <span class="radio_05"> <input type="radio"
										name="titleColor"  value="4">
							</span> <label for="titleColor_05" class="titleColor_text">私用</label>
					
				</td>
			</tr>

			<tr>
				<th class="auto-style5">内容</th>
				<td class="auto-style6">
                    <asp:TextBox ID="Description" TextMode="MultiLine" runat="server" CssClass="auto-style7" Height="108px" Width="486px"></asp:TextBox>
                    <br>
					MAX1000文字</td>
			</tr>

			<tr>
				<th class="auto-style8">備考</th>
				<td class="auto-style9">
                    <asp:TextBox ID="Note" TextMode="MultiLine" runat="server" Height="101px" Width="493px"></asp:TextBox>
                    <br>
					MAX1000文字</td>
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