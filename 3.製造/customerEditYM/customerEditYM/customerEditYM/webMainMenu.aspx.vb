Public Class webMainMenu
    Inherits System.Web.UI.Page

    Dim commonLoginCus As New loginCusInfo

    'メインメニューが表示された時に起こる処理
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        lbl_LoginName.Text = $"{commonLoginCus.loginCusLastName}{commonLoginCus.loginCusName} さん"

    End Sub

    'ログアウトボタンの押下処理
    Protected Sub btn_LogOut_Click(sender As Object, e As EventArgs) Handles btn_LogOut.Click

        commonLoginCus.loginCusID = ""
        commonLoginCus.loginCusLastName = ""
        commonLoginCus.loginCusName = ""

        'ログイン画面を表示する。
        Response.Redirect("webLogin.aspx", True)

    End Sub

    '顧客情報登録画面ボタンの押下処理
    Protected Sub btn_addCus_Click(sender As Object, e As EventArgs) Handles btn_addCus.Click

        '顧客情報登録画面を表示する。
        Response.Redirect("webAdd.aspx", True)

    End Sub

    '顧客情報一覧表示ボタンの押下処理
    Protected Sub btn_viewCus_Click(sender As Object, e As EventArgs) Handles btn_viewCus.Click

        '顧客情報一覧・表示画面を表示する。
        Response.Redirect("webView.aspx", True)

    End Sub

End Class