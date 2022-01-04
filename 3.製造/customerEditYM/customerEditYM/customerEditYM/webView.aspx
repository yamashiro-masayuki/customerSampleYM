<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="webView.aspx.vb" Inherits="customerEditYM.webView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .Freezing {
            margin-left: 49px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lbl_Title" runat="server" Font-Size="XX-Large" Text="会員情報の検索・一覧表示できます。"></asp:Label>
                <br />
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lbl_SubTitleFirst" runat="server" ForeColor="Black" Text="検索情報の記述"></asp:Label>
                　　　　　　　　　　　　　　　　　　<asp:Button ID="btn_MainMenu" runat="server" Height="45px" Text="メインメニュー" Width="106px" />
                <asp:Panel ID="serchPanel" runat="server" BorderStyle="Solid" Height="207px" style="margin-left: 63px" Width="516px">
                    <br />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lbl_ID" runat="server" ForeColor="Black" Text="ID : "></asp:Label>
                    <asp:TextBox ID="txt_ID" runat="server" MaxLength="6" Width="62px"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lbl_DateBirth" runat="server" ForeColor="Black" Text="生年月日 : "></asp:Label>
                    <asp:TextBox ID="txt_BirthYear" runat="server" MaxLength="4" Width="32px"></asp:TextBox>
                    <asp:Label ID="lbl_BirthYear" runat="server" Text="年"></asp:Label>
                    <br />
                    &nbsp;&nbsp;<asp:Label ID="lbl_LastName" runat="server" ForeColor="Black" Text="氏名(苗字) : "></asp:Label>
                    <asp:TextBox ID="txt_LastName" runat="server" MaxLength="5" Width="140px"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="txt_BirthMonth" runat="server" MaxLength="2" Width="20px"></asp:TextBox>
                    <asp:Label ID="lbl_BirthMonth" runat="server" Text="月"></asp:Label>
                    <br />
                    &nbsp;&nbsp;<asp:Label ID="lbl_Name" runat="server" ForeColor="Black" Text="氏名(名前) : "></asp:Label>
                    <asp:TextBox ID="txt_Name" runat="server" MaxLength="9" Width="140px"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="txt_BirthDay" runat="server" MaxLength="2" Width="20px"></asp:TextBox>
                    <asp:Label ID="lbl_BirthDay" runat="server" Text="日"></asp:Label>
                    <br />
                    &nbsp;&nbsp;
                    <asp:Label ID="lbl_KanaLastName" runat="server" ForeColor="Black" Text="カナ(苗字) : "></asp:Label>
                    <asp:TextBox ID="txt_KanaLastName" runat="server" MaxLength="9" Width="140px"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lbl_Sex" runat="server" ForeColor="Black" Text="性別 : "></asp:Label>
                    <asp:DropDownList ID="ddl_Sex" runat="server" Height="22px" Width="70px">
                    </asp:DropDownList>
                    <br />
                    &nbsp;&nbsp;
                    <asp:Label ID="lbl_KanaName" runat="server" ForeColor="Black" Text="カナ(名前) : "></asp:Label>
                    <asp:TextBox ID="txt_KanaName" runat="server" MaxLength="9" Width="140px"></asp:TextBox>
                    <br />
                    <br />
                    &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;　<asp:Label ID="lbl_caution" runat="server" ForeColor="Black" Text="※何も書かれていない項目は検索条件には含まれません。"></asp:Label>
                    <br />
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <br />
                    &nbsp;&nbsp;<br />
                    <br />
                </asp:Panel>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lbl_ErrorMsg" runat="server" ForeColor="Red" Text="エラーメッセージを表示"></asp:Label>
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 　　　　　　　　　　　　　　　　　　&nbsp;
                <asp:Button ID="btn_Clear" runat="server" Height="45px" Text="項目クリア" Width="110px" />
                <asp:Button ID="btn_View" runat="server" Height="45px" Text="表示" Width="106px" />
                <br />
                <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lbl_SubTitleSecond" runat="server" ForeColor="Black" Text="編集画面ボタン" Font-Size="X-Large"></asp:Label>
                <br />
            　　　　<asp:Button ID="btn_cusUP" runat="server" Height="45px" Text="会員情報更新画面" Width="130px" />
                <asp:Button ID="btn_cusDelete" runat="server" Height="45px" Text="会員情報消去画面" Width="130px" />
                <br />
            　　　　<asp:Label ID="lbl_cautionSeccond" runat="server" ForeColor="Black" Text="※一覧表示の選択に一つだけチェックした後、表示画面ボタンを押してください。"></asp:Label>
                <br />
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lbl_SubTitleThird" runat="server" ForeColor="Black" Text="会員情報一覧表示" Font-Size="X-Large"></asp:Label>
                &nbsp;&nbsp;
            <asp:GridView ID="gv_CusInfo" runat="server" CssClass="Freezing" Width="486px">
                <Columns>
                    <asp:TemplateField HeaderText="表示">
                        <ItemTemplate>
                            <asp:CheckBox ID="cb_viewCheck" runat="server" />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
        </div>
    </form>
</body>
</html>
