<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="WebApplication1.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>ログイン</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            ログインID : <asp:TextBox ID="LoginId" runat="server"></asp:TextBox>
            <br />
            <br />
            パスワード : <input type="password" name="password"/>
            <br />
                <asp:Button ID="Button1" runat="server" style="margin-bottom: 3px" Text="ログイン" Width="74px" OnClick="Button1_Click" />
            <br />
        </div>
    </form>
</body>
</html>
