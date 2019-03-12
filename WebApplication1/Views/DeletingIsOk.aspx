<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DeletingIsOk.aspx.cs" Inherits="WebApplication1.Views.DeletingIsOk" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
	        Imformation
		</div>
		<br>
        <div>
			[スケジュール]の削除が完了しました
		</div>
		<br>
        <div>
            <asp:Button ID="Ok" runat="server" Text="OK" OnClick="Ok_Click" />
        </div>
    </form>
</body>
</html>
