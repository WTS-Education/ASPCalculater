<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DeleteCheck.aspx.cs" Inherits="WebApplication1.Views.DeleteCheck" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>削除確認</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>Imformation</div>
		<br>
		<div>スケジュールを削除しますか？</div>
        <br>
        <asp:Label ID="DeleteError" runat="server" Text=""></asp:Label>
        <asp:Button ID="Yes" runat="server" Text="はい" OnClick="Yes_Click" />
        <asp:Button ID="No" runat="server" Text="いいえ" OnClick="No_Click" />
		<br>
    </form>
</body>
</html>
