<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SchedulingIsOk.aspx.cs" Inherits="WebApplication1.SchedulingIsOk" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>登録完了</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div>
				Imformation
			</div>
			<br>
			<div>
				[スケジュール]の登録が完了しました
			</div>
			<br>
			<div>
                <asp:Button ID="Button1" runat="server" Text="OK" OnClick="Button1_Click" />
			</div>
        </div>
    </form>
</body>
</html>
