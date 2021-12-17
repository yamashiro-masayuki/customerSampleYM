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
    'チェッククラスの呼び出し
    Dim check As New cusCommon.checkClass

    'メソッドの戻り値代入変数
    Dim no As Integer

    '画面項目のクリア
    Sub Clear()

        txt_ID.Text = ""
        txt_Pass.Text = ""
        txt_PassCheck.Text = ""
        txt_LastName.Text = ""
        txt_Name.Text = ""
        txt_KanaLastName.Text = ""
        txt_KanaName.Text = ""
        txt_BirthYear.Text = ""
        txt_BirthMonth.Text = ""
        txt_BirthDay.Text = ""
        ddl_Sex.SelectedIndex = 0
        txt_PostalCode.Text = ""
        ddl_Prefecture.SelectedIndex = 0
        txt_AddressCity.Text = ""
        txt_AdressBuilding.Text = ""
        txt_AdressStreet.Text = ""

    End Sub

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

    'クリアボタンの押下処理
    Protected Sub btn_Clear_Click(sender As Object, e As EventArgs) Handles btn_Clear.Click

        'クリアメソッドを使用する。
        Clear()

    End Sub

    '登録ボタンの押下処理
    Protected Sub btn_Add_Click(sender As Object, e As EventArgs) Handles btn_Add.Click

#Region "必須項目の記述確認"
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
        '顧客Pass(確認)
        If check.checkTextBox(txt_PassCheck) = 0 Then
            errorMsg.errorMsg(lbl_ErrorMsg, number.no1)
            Return
        End If
        '氏名(苗字)
        If check.checkTextBox(txt_LastName) = 0 Then
            errorMsg.errorMsg(lbl_ErrorMsg, number.no1)
            Return
        End If
        '氏名(名前)
        If check.checkTextBox(txt_Name) = 0 Then
            errorMsg.errorMsg(lbl_ErrorMsg, number.no1)
            Return
        End If
        'カナ(苗字)
        If check.checkTextBox(txt_KanaLastName) = 0 Then
            errorMsg.errorMsg(lbl_ErrorMsg, number.no1)
            Return
        End If
        'カナ(名前)
        If check.checkTextBox(txt_KanaName) = 0 Then
            errorMsg.errorMsg(lbl_ErrorMsg, number.no1)
            Return
        End If
        '誕生年
        If check.checkTextBox(txt_BirthYear) = 0 Then
            errorMsg.errorMsg(lbl_ErrorMsg, number.no1)
            Return
        End If
        '誕生月
        If check.checkTextBox(txt_BirthMonth) = 0 Then
            errorMsg.errorMsg(lbl_ErrorMsg, number.no1)
            Return
        End If
        '誕生日
        If check.checkTextBox(txt_BirthDay) = 0 Then
            errorMsg.errorMsg(lbl_ErrorMsg, number.no1)
            Return
        End If
#End Region



    End Sub

End Class