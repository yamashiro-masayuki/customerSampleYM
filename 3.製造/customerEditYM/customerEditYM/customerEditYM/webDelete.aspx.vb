Public Class webDelete
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
    '共通メソッドクラスの呼び出し
    Dim commonMethod As New commonMethodClass
    '一覧選択メソッドクラスの呼び出し
    Dim viewCus As New viewCusInfo

    '顧客情報消去メソッドクラスの呼び出し
    Dim deleteMethod As New deleteMethodClass

    'メソッドの戻り値代入変数
    Dim no As Integer = 0
    '出力データ一事保管代入変数
    Dim catchData As Integer = 0



    'ページを開いた時に行う処理
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
                errorMsg.errorMsg(lbl_ErrorMsg, Number.no2)
                Return
            End If


            '取得データを保持するDataTableの作成。
            commonMethod.getCusData = commonMethod.customerDataAddColums(commonMethod.getCusData)
            '会員情報のデータ取得
            no = commonMethod.GetData(commonMethod.getCusData, viewCus.viewCusID)

            If no = 2 Then
                'SQLエラーのため、SQLエラーメッセージを表示する。
                errorMsg.errorMsg(lbl_ErrorMsg, Number.no2)
                '顧客情報一覧・表示画面を表示する。
                Response.Redirect("webView.aspx", True)
                Return
            End If

        Catch ex As Exception
            'その他エラーメッセージを表示する。
            errorMsg.errorMsg(lbl_ErrorMsg, Number.no4)
            '顧客情報一覧・表示画面を表示する。
            Response.Redirect("webView.aspx", True)
            Return
        End Try

        '取得された性別のデータを文字にする。
        viewCus.sexWord = commonMethod.sexWordChange(commonMethod.getCusData.Rows(0)("SEX"))


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


        '画面項目の記述出来ない状態に変更
        txt_ID.Enabled = False
        txt_LastName.Enabled = False
        txt_Name.Enabled = False
        txt_KanaLastName.Enabled = False
        txt_KanaName.Enabled = False
        txt_BirthYear.Enabled = False
        txt_BirthMonth.Enabled = False
        txt_BirthDay.Enabled = False
        ddl_Sex.Enabled = False
        txt_PostalCode.Enabled = False
        ddl_Prefecture.Enabled = False
        txt_AddressCity.Enabled = False
        txt_AdressStreet.Enabled = False
        txt_AdressBuilding.Enabled = False



    End Sub

    '前の画面へボタンが押下された時に起こる処理
    Protected Sub btn_Before_Click(sender As Object, e As EventArgs) Handles btn_Before.Click

        Response.Redirect("webView.aspx", True)

    End Sub

    '消去ボタンを押下した時に起こる処理
    Protected Sub btn_Delete_Click(sender As Object, e As EventArgs) Handles btn_Delete.Click

        '会員情報のデータ消去
        Try
            no = deleteMethod.deleteData(txt_ID.Text)

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

        'データを消去したため、一覧・表示画面へ遷移する。
        Response.Redirect("webView.aspx", True)

    End Sub


End Class