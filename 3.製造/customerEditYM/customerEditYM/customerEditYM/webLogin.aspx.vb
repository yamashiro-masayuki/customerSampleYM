Public Class webLogin
    Inherits System.Web.UI.Page

#Region "クラス宣言"

    'エラーメッセージクラスの呼び出し
    Dim errorMsg As New errorMsgClass
    'チェッククラスの呼び出し
    Dim check As New checkClass
    '番号クラスの呼び出し
    Dim number As New numberClass
    'ログインメソッドクラスの呼び出し
    Dim login As New loginMethodClass
    'ログイン者情報クラスの呼び出し
    Dim loginCus As New loginCusInfo

#End Region


    'ページが表示された時に動く処理
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load, pnl_Login.Load

        'エラーメッセージを表示しない状態に変更。
        lbl_ErrorMsg.Visible = False

    End Sub

    '会員情報登録画面表示するボタン押下処理
    Protected Sub btn_AddCus_Click(sender As Object, e As EventArgs) Handles btn_AddCus.Click

        Response.Redirect("webAdd.aspx", True)

    End Sub

    'ログインボタンの押下処理
    Protected Sub btn_Login_Click(sender As Object, e As EventArgs) Handles btn_Login.Click

        '画面必須項目の記述確認
        '顧客ID
        If check.checkTextBox(txt_ID) = 0 Then
            errorMsg.errorMsg(lbl_ErrorMsg, number.no1)
            Return
        End If
        '顧客Pass
        If check.checkTextBox(txt_Pass) = 0 Then
            errorMsg.errorMsg(lbl_ErrorMsg, number.no1)
            Return
        End If

        Try
            '顧客データの取得
            Dim no As Integer
            no = login.GetData(loginCus, txt_ID.Text, txt_Pass.Text)

            If no = 0 Then
                '取得データが0件のため、データが取得できないエラーメッセージを表示する。
                errorMsg.errorMsg(lbl_ErrorMsg, number.no3)
                Return
            ElseIf no = 2 Then
                'SQLエラーのため、SQLエラーメッセージを表示する。
                errorMsg.errorMsg(lbl_ErrorMsg, number.no2)
                Return
            End If

            'データが取得できた時共通変数に顧客IDを保持する。
            loginCus.loginCusID = txt_ID.Text

        Catch ex As Exception
            'その他エラーメッセージを表示する。
            errorMsg.errorMsg(lbl_ErrorMsg, number.no4)
            Return
        End Try

        'メインメニューを表示する。
        Response.Redirect("webMainMenu.aspx", True)

    End Sub


End Class