<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="WebApplication1.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="../Contents/css/index_style.css"
	type="text/css" rel="stylesheet" />
    <title>ログイン</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="" CssClass="errorMessage"></asp:Label><br/>
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
