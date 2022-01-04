Public Class webUP
    Inherits System.Web.UI.Page

    'チェッククラスの呼び出し
    Dim check As New checkClass
    'エラーメッセージクラスの呼び出し
    Dim errorMsg As New errorMsgClass
    '番号クラスの呼び出し
    Dim number As New numberClass
    '値変換クラスの呼び出し
    Dim convert As New commonItemConversion
    'アイテム追加クラスの呼び出し
    Dim commonItem As New commonItemAssignment
    '変換値代入クラスの呼び出し
    Dim up As New upCusInfo
    '共通メソッドクラスの呼び出し
    Dim commonMethod As New commonMethodClass
    '一覧選択メソッドクラスの呼び出し
    Dim viewCus As New viewCusInfo
    '一覧選択選択メソッドクラスの呼び出し
    Dim selectView As New selectViewCusInfo


    '顧客情報更新メソッドクラスの呼び出し
    Dim upMethod As New upMethodClass
    '顧客情報更新変換データクラスの呼び出し
    Dim upCus As New upCusInfo

    'メソッドの戻り値代入変数
    Dim no As Integer = 0
    'エラー値代入変数
    Dim errorNO As Integer = 0
    '出力データ一事保管代入変数
    Dim catchData As Integer = 0
    '画面記述項目を入れるDataTable変数
    Dim screenData As New DataTable

    'ページが表示された時に起こる処理
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'エラーメッセージを表示しない状態に変更。
        lbl_ErrorMsg.Visible = False
        '性別に値を代入。
        commonItem.sexItemInsert(ddl_Sex)

        Try
            '都道府県のDropDownListへの代入
            no = commonItem.prefectureItemInsert(ddl_Prefecture, commonMethod)

            If no = 2 Then
                'SQLエラーのため、SQLエラーメッセージを表示する。
                errorMsg.errorMsg(lbl_ErrorMsg, number.no2)
                Return
            End If


            '取得データを保持するDataTableの作成。
            commonMethod.getCusData = commonMethod.customerDataAddColums(commonMethod.getCusData)
            '会員情報のデータ取得
            no = commonMethod.GetData(commonMethod.getCusData, selectView.viewCusID)

            If no = 2 Then
                'SQLエラーのため、SQLエラーメッセージを表示する。
                errorMsg.errorMsg(lbl_ErrorMsg, number.no2)
                '顧客情報一覧・表示画面を表示する。
                Response.Redirect("webView.aspx", True)
                Return
            End If

        Catch ex As Exception
            'その他エラーメッセージを表示する。
            errorMsg.errorMsg(lbl_ErrorMsg, number.no4)
            '顧客情報一覧・表示画面を表示する。
            Response.Redirect("webView.aspx", True)
            Return
        End Try

        '取得された性別のデータを文字にする。
        viewCus.viewCusSex = commonMethod.sexWordChange(commonMethod.getCusData.Rows(0)("SEX"))


        '取得された項目のデータ表示
        txt_ID.Text = commonMethod.getCusData.Rows(0)("CUST_ID").ToString
        txt_LastName.Text = commonMethod.getCusData.Rows(0)("PERSON_LASTNAME").ToString
        txt_Name.Text = commonMethod.getCusData.Rows(0)("PERSON_NAME").ToString
        txt_KanaLastName.Text = commonMethod.getCusData.Rows(0)("PERSON_KANA_LASTNAME").ToString
        txt_KanaName.Text = commonMethod.getCusData.Rows(0)("PERSON_KANA_NAME").ToString
        txt_BirthYear.Text = commonMethod.getCusData.Rows(0)("BIRTH_YEAR").ToString
        txt_BirthMonth.Text = commonMethod.getCusData.Rows(0)("BIRTH_MONTH").ToString
        txt_BirthDay.Text = commonMethod.getCusData.Rows(0)("BIRTH_DAY").ToString
        txt_PostalCode.Text = commonMethod.getCusData.Rows(0)("POSTAL_CODE").ToString
        txt_AddressCity.Text = commonMethod.getCusData.Rows(0)("ADDRESS_CITY").ToString
        txt_AdressStreet.Text = commonMethod.getCusData.Rows(0)("ADDRESS_STREET").ToString
        txt_AdressBuilding.Text = commonMethod.getCusData.Rows(0)("ADDRESS_BUILDING").ToString

        catchData = commonMethod.getCusData.Rows(0)("SEX")
        ddl_Sex.SelectedValue = catchData - 1
        catchData = commonMethod.getCusData.Rows(0)("ADDRESS_PREFECTURES")
        ddl_Prefecture.SelectedValue = catchData

        'パスワード変更チェックボックスのチェックを外す。
        chkBox_Pass.Checked = False

        'IDを使用不可にする。
        txt_ID.Enabled = False


    End Sub

    '前の画面へボタンが押下された時に起こる処理
    Protected Sub btn_Before_Click(sender As Object, e As EventArgs) Handles btn_Before.Click

        Response.Redirect("webView.aspx", True)

    End Sub

    '画面の項目を初期化する。
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
        chkBox_Pass.Checked = False

    End Sub

    'DataTableに画面記述を保存する。
    Sub dataInsert(data As DataTable, upCus As upCusInfo)

        data.Rows.Add()
        data.Rows(0)("CUST_ID") = txt_ID.Text
        data.Rows(0)("CUST_PASS") = txt_Pass.Text
        data.Rows(0)("PERSON_LASTNAME") = txt_LastName.Text
        data.Rows(0)("PERSON_NAME") = txt_Name.Text
        data.Rows(0)("PERSON_KANA_LASTNAME") = txt_KanaLastName.Text
        data.Rows(0)("PERSON_KANA_NAME") = txt_KanaName.Text
        data.Rows(0)("SEX") = upCus.viewCusSex
        data.Rows(0)("BIRTH_YEAR") = txt_BirthYear.Text
        data.Rows(0)("BIRTH_MONTH") = txt_BirthMonth.Text
        data.Rows(0)("BIRTH_DAY") = txt_BirthDay.Text
        data.Rows(0)("POSTAL_CODE") = txt_PostalCode.Text
        data.Rows(0)("ADDRESS_PREFECTURES") = upCus.updateCusPrefecture
        data.Rows(0)("ADDRESS_CITY") = txt_AddressCity.Text
        data.Rows(0)("ADDRESS_STREET") = txt_AdressStreet.Text
        data.Rows(0)("ADDRESS_BUILDING") = txt_AdressBuilding.Text
        data.Rows(0)("UPDATE_PERSON") = txt_ID.Text
        data.Rows(0)("UPDATE_DAY") = $"{Date.Now.Year}{Date.Now.Month}{Date.Now.Day}"
        data.Rows(0)("IS_DLTFLG") = 0

    End Sub

    Protected Sub btn_Add_Click(sender As Object, e As EventArgs) Handles btn_Add.Click

        Try

            '悲観ロックの実行
            commonMethod.GetRockData(commonMethod.getCusData, txt_ID.Text)




#Region "必須項目の記述確認"
            '顧客ID
            If check.checkTextBox(txt_ID) = 0 Then
                errorMsg.errorMsg(lbl_ErrorMsg, Number.no1)
                Return
            End If
            '氏名(苗字)
            If check.checkTextBox(txt_LastName) = 0 Then
                errorMsg.errorMsg(lbl_ErrorMsg, Number.no1)
                Return
            End If
            '氏名(名前)
            If check.checkTextBox(txt_Name) = 0 Then
                errorMsg.errorMsg(lbl_ErrorMsg, Number.no1)
                Return
            End If
            'カナ(苗字)
            If check.checkTextBox(txt_KanaLastName) = 0 Then
                errorMsg.errorMsg(lbl_ErrorMsg, Number.no1)
                Return
            End If
            'カナ(名前)
            If check.checkTextBox(txt_KanaName) = 0 Then
                errorMsg.errorMsg(lbl_ErrorMsg, Number.no1)
                Return
            End If
            '誕生年
            If check.checkTextBox(txt_BirthYear) = 0 Then
                errorMsg.errorMsg(lbl_ErrorMsg, Number.no1)
                Return
            End If
            '誕生月
            If check.checkTextBox(txt_BirthMonth) = 0 Then
                errorMsg.errorMsg(lbl_ErrorMsg, Number.no1)
                Return
            End If
            '誕生日
            If check.checkTextBox(txt_BirthDay) = 0 Then
                errorMsg.errorMsg(lbl_ErrorMsg, Number.no1)
                Return
            End If

            'パスワード変更にチェックがついている場合
            If chkBox_Pass.Checked = True Then
                '新規顧客Pass
                If check.checkTextBox(txt_Pass) = 0 Then
                    errorMsg.errorMsg(lbl_ErrorMsg, number.no1)
                    Return
                End If
                '新規顧客Pass(確認)
                If check.checkTextBox(txt_PassCheck) = 0 Then
                    errorMsg.errorMsg(lbl_ErrorMsg, number.no1)
                    Return
                End If
            End If


#End Region


            '生年月日の日付が操作日よりも後の日付ではないことを確認する。
            If 0 < check.checkBirthDate($"{txt_BirthYear.Text}{txt_BirthMonth.Text}{txt_BirthDay.Text}") Then
                'Pass不一致エラーのため、エラーメッセージを表示する。
                errorNO = number.no6
                Throw New Exception
            End If

            'chkBoxにチェックがある場合、新規Passの記述が一致しているかを確認する。
            If chkBox_Pass.Checked = True Then
                If 0 < check.checkPassTextBox(txt_Pass, txt_PassCheck) Then
                    'Pass不一致エラーのため、エラーメッセージを表示する。
                    errorNO = number.no5
                    Throw New Exception
                    Return
                End If
            End If

            '性別の記述を数値に変換
            up.viewCusSex = convert.sexItemInConvert(ddl_Sex)

            '画面項目の住所の記述確認
            If 0 < ddl_Prefecture.SelectedValue Then
                '都道府県のコード変換
                up.updateCusPrefecture = convert.prefectureItemInConvert(ddl_Prefecture.Text, commonMethod)

            End If


            '画面記述を保持するDataTableの作成。
            screenData = commonMethod.customerOnlyDataAddColums(screenData)
            '画面記述をDataTableに代入。
            dataInsert(screenData, upCus)

            '会員情報のデータ登録
            no = upMethod.upData(screenData)

            If no = 2 Then
                'SQLエラーのため、SQLエラーメッセージを表示する。
                errorMsg.errorMsg(lbl_ErrorMsg, number.no2)
                Return
            End If


        Catch ex As Exception

            'その他エラーでない場合各エラー内容を表示する。
            If 0 < errorNO Then
                errorMsg.errorMsg(lbl_ErrorMsg, errorNO)
                Return
            Else
                errorMsg.errorMsg(lbl_ErrorMsg, number.no4)
                Return
            End If

        End Try

        '画面項目を初期化する。
        Clear()


    End Sub

    'パスワード変更チェックボックスのチェック値が変化した時に必要
    Protected Sub chkBox_Pass_CheckedChanged(sender As Object, e As EventArgs) Handles chkBox_Pass.CheckedChanged, chkBox_Pass.Load

        'チェック時テキストボックスを使用可能にする。
        If chkBox_Pass.Checked = True Then
            txt_Pass.Enabled = True
            txt_PassCheck.Enabled = True
        Else
            txt_Pass.Enabled = False
            txt_PassCheck.Enabled = False
            txt_Pass.Text = ""
            txt_PassCheck.Text = ""
        End If

    End Sub



End Class