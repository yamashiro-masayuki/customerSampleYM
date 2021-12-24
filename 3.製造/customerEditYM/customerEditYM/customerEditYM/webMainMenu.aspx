<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="webMainMenu.aspx.vb" Inherits="customerEditYM.webMainMenu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Panel ID="pnl_MainMenu" runat="server" Height="390px" style="margin-left: 92px; margin-top: 15px">
                <asp:Label ID="lbl_LoginName" runat="server" Text="デバックモード さん"></asp:Label>
                　　　　　　　　　　　　　　　<br /> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btn_LogOut" runat="server" Text="ログアウト" Width="84px" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <br />
                <asp:Label ID="lbl_Title" runat="server" Font-Size="XX-Large" Text="会員情報編集画面へようこそ"></asp:Label>
                <br />
                <br />
                　　　　<asp:Button ID="btn_addCus" runat="server" Height="45px" Text="会員情報登録" Width="134px" />
                　　<asp:Button ID="btn_viewCus" runat="server" Height="45px" Text="会員情報一覧表示" Width="134px" />
                <br />
                <br />
            </asp:Panel>
        </div>
    </form>
</body>
</html>
