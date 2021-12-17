Public Class webAdd
    Inherits System.Web.UI.Page

    'エラーメッセージクラスの呼び出し
    Dim errorMsg As New cusCommon.errorMsgClass
    '共通メソッドクラスの呼び出し
    Dim commonMethod As New cusCommon.commonMethodClass
    'アイテム追加クラスの呼び出し
    Dim commonItem As New cusCommon.commonItemAssignment
    '番号クラスの呼び出し
    Dim number As New cusCommon.numberClass
    'ログイン者情報クラスの呼び出し
    Dim loginCus As New cusCommon.loginCusInfo

    'メソッドの戻り値代入変数
    Dim no As Integer


    '画面表示時の処理
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'エラーメッセージを表示しない状態に変更。
        lbl_ErrorMsg.Visible = False
        '性別に値を代入。
        commonItem.sexItemInsert(ddl_Sex)
        '都道府県マスタのデータ代入
        Try
            no = commonItem.prefectureItemInsert(ddl_Prefecture)

            If no = 2 Then
                'SQLエラーのため、SQLエラーメッセージを表示する。
                errorMsg.errorMsg(lbl_ErrorMsg, number.no2)
                Return
            End If

        Catch ex As Exception
            'その他エラーメッセージを表示する。
            errorMsg.errorMsg(lbl_ErrorMsg, Number.no4)
            Return
        End Try

    End Sub

    '前の画面へボタンの押下処理
    Protected Sub btn_Before_Click(sender As Object, e As EventArgs) Handles btn_Before.Click

        If 0 < loginCus.loginCusID.Length Then

            'メインメニューを表示する。
            Response.Redirect("webMainMenu.aspx", True)
        Else

            'ログイン画面を表示する。
            Response.Redirect("webLogin.aspx", True)
        End If

    End Sub



End Class