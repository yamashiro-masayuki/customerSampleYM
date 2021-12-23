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
    '値変換クラスの呼び出し
    Dim convert As New cusCommon.commonItemConversion

    '顧客情報登録メソッドクラスの呼び出し
    Dim addMethod As New addMethodClass
    '顧客情報登録変換データクラスの呼び出し
    Dim addCus As New addCusInfo

    'メソッドの戻り値代入変数
    Dim no As Integer
    '画面記述項目を入れるDataTable変数
    Dim screenData As New DataTable

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

    'DataTableに画面記述を保存する。
    Sub dataInsert(data As DataTable, addCus As addCusInfo)

        data.Rows.Add()
        data.Rows(0)("CUST_ID") = txt_ID.Text
        data.Rows(0)("CUST_PASS") = txt_Pass.Text
        data.Rows(0)("PERSON_LASTNAME") = txt_LastName.Text
        data.Rows(0)("PERSON_NAME") = txt_Name.Text
        data.Rows(0)("PERSON_KANA_LASTNAME") = txt_KanaLastName.Text
        data.Rows(0)("PERSON_KANA_NAME") = txt_KanaName.Text
        data.Rows(0)("SEX") = addCus.insereCusSex
        data.Rows(0)("BIRTH_YEAR") = txt_BirthYear.Text
        data.Rows(0)("BIRTH_MONTH") = txt_BirthMonth.Text
        data.Rows(0)("BIRTH_DAY") = txt_BirthDay.Text
        data.Rows(0)("POSTAL_CODE") = txt_PostalCode.Text
        data.Rows(0)("ADDRESS_PREFECTURES") = addCus.insereCusPrefecture
        data.Rows(0)("ADDRESS_CITY") = txt_AddressCity.Text
        data.Rows(0)("ADDRESS_STREET") = txt_AdressStreet.Text
        data.Rows(0)("ADDRESS_BUILDING") = txt_AdressBuilding.Text
        data.Rows(0)("UPDATE_PERSON") = txt_ID.Text
        data.Rows(0)("UPDATE_DAY") = $"{Date.Now.Year}{Date.Now.Month}{Date.Now.Day}"
        data.Rows(0)("CREATE_PERSON") = txt_ID.Text
        data.Rows(0)("CREATE_DAY") = $"{Date.Now.Year}{Date.Now.Month}{Date.Now.Day}"
        data.Rows(0)("IS_DLTFLG") = 0

    End Sub

    '画面表示時の処理
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'エラーメッセージを表示しない状態に変更。
        lbl_ErrorMsg.Visible = False
        '性別に値を代入。
        commonItem.sexItemInsert(ddl_Sex)
        '都道府県マスタのデータ代入
        Try
            no = commonItem.prefectureItemInsert(ddl_Prefecture, commonMethod)

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

        'Passの記述が一致しているかを確認する。
        If 0 < check.checkPassTextBox(txt_Pass, txt_PassCheck) Then
            'Pass不一致エラーのため、エラーメッセージを表示する。
            errorMsg.errorMsg(lbl_ErrorMsg, number.no5)
            Return
        End If

        '生年月日の日付が操作日よりも後の日付ではないことを確認する。
        If 0 < check.checkBirthDate($"{txt_BirthYear.Text}{txt_BirthMonth.Text}{txt_BirthDay.Text}") Then
            'Pass不一致エラーのため、エラーメッセージを表示する。
            errorMsg.errorMsg(lbl_ErrorMsg, number.no6)
            Return
        End If

        '性別の記述を数値に変換
        addCus.insereCusSex = convert.sexItemInConvert(ddl_Sex)

        '画面項目の住所の記述確認
        If 0 < ddl_Prefecture.SelectedValue Then
            addCus.insereCusPrefecture = convert.prefectureItemInConvert(ddl_Prefecture.Text, commonMethod)

        End If

        '顧客IDの存在確認
        Try
            no = addMethod.checkData(txt_ID.Text)

            If no = 2 Then
                'SQLエラーのため、SQLエラーメッセージを表示する。
                errorMsg.errorMsg(lbl_ErrorMsg, number.no2)
                Return
            ElseIf no = 1 Then
                '顧客IDが既に使用されているため、ID仕様エラーメッセージを表示する。
                errorMsg.errorMsg(lbl_ErrorMsg, number.no7)
                Return
            End If

            '画面記述を保持するDataTableの作成。
            screenData = commonMethod.customerOnlyDataAddColums(screenData)
            '画面記述をDataTableに代入。
            dataInsert(screenData, addCus)

            '会員情報のデータ登録
            no = addMethod.addData(screenData)

            If no = 2 Then
                'SQLエラーのため、SQLエラーメッセージを表示する。
                errorMsg.errorMsg(lbl_ErrorMsg, number.no2)
                Return
            End If

        Catch ex As Exception
            'その他エラーメッセージを表示する。
            errorMsg.errorMsg(lbl_ErrorMsg, number.no4)
            Return
        End Try



        '画面項目の記述初期化
        Clear()

    End Sub

End Class