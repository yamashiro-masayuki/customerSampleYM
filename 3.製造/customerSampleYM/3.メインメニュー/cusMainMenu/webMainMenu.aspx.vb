Public Class webMainMenu
    Inherits System.Web.UI.Page

    Dim commonLoginCus As New cusCommon.loginCusInfo

    'メインメニューが表示された時に起こる処理
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        lbl_LoginName.Text = $"{commonLoginCus.loginLastName}{commonLoginCus.loginName} さん"

    End Sub

    'ログアウトボタンの押下処理
    Protected Sub btn_LogOut_Click(sender As Object, e As EventArgs) Handles btn_LogOut.Click




    End Sub

    '会員情報登録ボタンの押下処理
    Protected Sub btn_addCus_Click(sender As Object, e As EventArgs) Handles btn_addCus.Click

    End Sub

    '会員情報一覧表示ボタンの押下処理
    Protected Sub btn_viewCus_Click(sender As Object, e As EventArgs) Handles btn_viewCus.Click

    End Sub

End Class