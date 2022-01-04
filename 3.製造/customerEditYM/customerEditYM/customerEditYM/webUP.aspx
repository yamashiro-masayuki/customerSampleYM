<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="webUP.aspx.vb" Inherits="customerEditYM.webUP" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form2" runat="server">
        <div>
            <asp:Panel ID="pnl_UP" runat="server" Height="561px" style="margin-left: 0px" Width="674px">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lbl_Title" runat="server" Font-Size="XX-Large" Text="会員情報を更新できます。"></asp:Label>
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lbl_ID" runat="server" ForeColor="Black" Text="ID : "></asp:Label>
                <asp:TextBox ID="txt_ID" runat="server" MaxLength="6" Width="62px"></asp:TextBox>
                <asp:Panel ID="editPanel" runat="server" BorderStyle="Solid" Height="381px" style="margin-left: 63px" Width="591px">
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
                    <asp:Panel ID="passPanel" runat="server" BorderStyle="Solid" Height="80px" style="margin-left: 33px" Width="267px">
                        &nbsp;
                        <asp:CheckBox ID="chkBox_Pass" runat="server" Text="パスワード変更" />
                        <br />
                        &nbsp;&nbsp; 　&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="lbl_Pass" runat="server" ForeColor="#0066FF" Text="新規Pass : "></asp:Label>
                        <asp:TextBox ID="txt_Pass" runat="server" MaxLength="10" Width="99px"></asp:TextBox>
                        <br />
                        &nbsp;<asp:Label ID="lbl_PassCheck" runat="server" ForeColor="#0066FF" Text="新規Pass(確認) : "></asp:Label>
                        <asp:TextBox ID="txt_PassCheck" runat="server" MaxLength="10" Width="99px"></asp:TextBox>
                    </asp:Panel>
                    <br />
                    <br />
                    <br />
                </asp:Panel>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lbl_ErrorMsg" runat="server" ForeColor="Red" Text="エラーメッセージを表示"></asp:Label>
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
                <asp:Button ID="btn_Before" runat="server" Height="45px" Text="画面を戻る" Width="110px" />
                　　　　　　　　　　　　　　　　　　　　　　　<asp:Button ID="btn_Add" runat="server" Height="45px" Text="登録" Width="106px" />
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
