<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="webDelete.aspx.vb" Inherits="customerEditYM.webDelete" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Panel ID="pnl_Delete" runat="server" Height="561px" style="margin-left: 0px" Width="674px">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lbl_Title" runat="server" Font-Size="XX-Large" Text="会員情報を"></asp:Label>
                <asp:Label ID="lbl_Title0" runat="server" Font-Size="XX-Large" ForeColor="#0066FF" Text="消去"></asp:Label>
                <br />
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lbl_cautionTitle" runat="server" ForeColor="#0066FF" Text="注意事項"></asp:Label>
                &nbsp;<asp:Panel ID="pnl_cautionPanel" runat="server" BorderStyle="Solid" Height="73px" style="margin-left: 63px" Width="490px">
&nbsp;<asp:Label ID="lbl_cautionFirst" runat="server" Text="・他者のデータを消去する場合、よく確認してください。"></asp:Label>
                    <br />
&nbsp;<asp:Label ID="lbl_cautionSecond" runat="server" Text="・自分のデータを消去する場合ログイン画面に戻されます。"></asp:Label>
                    &nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
                    <br />
                    &nbsp;<asp:Label ID="lbl_cautionThird" runat="server" Text="　再ログインの際には新規でデータを作成してください。"></asp:Label>
                    <br />
                    <br />
                </asp:Panel>
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lbl_ID" runat="server" ForeColor="Black" Text="ID : "></asp:Label>
                <asp:TextBox ID="txt_ID" runat="server" MaxLength="6" Width="62px"></asp:TextBox>
                <asp:Panel ID="pnl_editPanel" runat="server" BorderStyle="Solid" Height="285px" style="margin-left: 63px" Width="591px">
                    <br />
                    &nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lbl_LastName" runat="server" ForeColor="#0066FF" Text="氏名(苗字) : "></asp:Label>
                    <asp:TextBox ID="txt_LastName" runat="server" MaxLength="5" Width="140px"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lbl_Name" runat="server" ForeColor="#0066FF" Text="氏名(名前) : "></asp:Label>
                    <asp:TextBox ID="txt_Name" runat="server" MaxLength="9" Width="140px"></asp:TextBox>
                    <br />
                    &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
                    <asp:Label ID="lbl_KanaLastName" runat="server" ForeColor="#0066FF" Text="カナ(苗字) : "></asp:Label>
                    <asp:TextBox ID="txt_KanaLastName" runat="server" MaxLength="9" Width="140px"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lbl_KanaName" runat="server" ForeColor="#0066FF" Text="カナ(名前) : "></asp:Label>
                    <asp:TextBox ID="txt_KanaName" runat="server" MaxLength="9" Width="140px"></asp:TextBox>
                    <br />
                    <br />
                    &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lbl_DateBirth" runat="server" ForeColor="#0066FF" Text="生年月日 : "></asp:Label>
                    <asp:TextBox ID="txt_BirthYear" runat="server" MaxLength="4" Width="32px"></asp:TextBox>
                    <asp:Label ID="lbl_BirthYear" runat="server" Text="年"></asp:Label>
                    <asp:TextBox ID="txt_BirthMonth" runat="server" MaxLength="2" Width="20px"></asp:TextBox>
                    <asp:Label ID="lbl_BirthMonth" runat="server" Text="月"></asp:Label>
                    <asp:TextBox ID="txt_BirthDay" runat="server" MaxLength="2" Width="20px"></asp:TextBox>
                    <asp:Label ID="lbl_BirthDay" runat="server" Text="日"></asp:Label>
                    　<asp:Label ID="lbl_Sex" runat="server" ForeColor="#0066FF" Text="性別 : "></asp:Label>
                    <asp:DropDownList ID="ddl_Sex" runat="server" Height="22px" Width="70px">
                    </asp:DropDownList>
                    <br />
                    <br />
                    &nbsp;&nbsp;&nbsp;&nbsp; 　&nbsp;
                    <asp:Label ID="lbl_PostalCode" runat="server" Text="郵便番号 : "></asp:Label>
                    <asp:TextBox ID="txt_PostalCode" runat="server" MaxLength="8" Width="63px"></asp:TextBox>
                    <br />
                    &nbsp;<asp:Label ID="lbl_Prefecture" runat="server" Text="住所(都道府県) : "></asp:Label>
                    <asp:DropDownList ID="ddl_Prefecture" runat="server" Height="22px" Width="70px">
                    </asp:DropDownList>
                    <br />
                    &nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lbl_AddressCity" runat="server" Text="住所(市区郡) : "></asp:Label>
                    <asp:TextBox ID="txt_AddressCity" runat="server" MaxLength="8" Width="134px"></asp:TextBox>
                    <br />
                    &nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lbl_AdressStreet" runat="server" Text="住所(町大字) : "></asp:Label>
                    <asp:TextBox ID="txt_AdressStreet" runat="server" MaxLength="14" Width="217px"></asp:TextBox>
                    <br />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lbl_AdressBuilding" runat="server" Text="住所(建物) : "></asp:Label>
                    <asp:TextBox ID="txt_AdressBuilding" runat="server" MaxLength="30" Width="435px"></asp:TextBox>
                    <br />
                    &nbsp;&nbsp;&nbsp;
                    <br />
                </asp:Panel>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lbl_ErrorMsg" runat="server" ForeColor="Red" Text="エラーメッセージを表示"></asp:Label>
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
                <asp:Button ID="btn_Before" runat="server" Height="45px" Text="画面を戻る" Width="110px" />
                　　　　　　　　　　　　　　　　　　　　　　　<asp:Button ID="btn_Delete" runat="server" Height="45px" Text="消去" Width="106px" />
                <br />
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 　　&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
                <br />
                <br />
                <br />
            </asp:Panel>
        </div>
    </form>
</body>
</html>
