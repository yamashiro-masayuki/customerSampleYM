Public Class webView
    Inherits System.Web.UI.Page

    'エラーメッセージクラスの呼び出し
    Dim errorMsg As New errorMsgClass
    '番号クラスの呼び出し
    Dim number As New numberClass
    '共通メソッドクラスの呼び出し
    Dim commonMethod As New commonMethodClass
    '値変換クラスの呼び出し
    Dim convert As New commonItemConversion
    'アイテム追加クラスの呼び出し
    Dim commonItem As New commonItemAssignment

    '一覧・表示メソッドクラス
    Dim viewClass As New webViewClass
    '一覧・表示顧客情報クラス
    Dim viewCus As New viewCusInfo
    '一覧選択選択メソッドクラスの呼び出し
    Dim selectView As New selectViewCusInfo

    'メソッドの戻り値代入変数
    Dim no As Integer
    '画面記述項目を入れるDataTable変数
    Dim screenData As New DataTable
    '取得データを入れるDataTable変数
    Dim getData As New DataTable
    'チェックボックスの記述確認
    Dim checkViewBox As New CheckBox
    '表示チェックの個数を調査
    Dim checkNum As Integer = 0


    '画面項目の初期化
    Sub Clear()

        txt_ID.Text = ""
        txt_LastName.Text = ""
        txt_Name.Text = ""
        txt_KanaLastName.Text = ""
        txt_KanaName.Text = ""
        txt_BirthYear.Text = ""
        txt_BirthMonth.Text = ""
        txt_BirthDay.Text = ""
        ddl_Sex.SelectedIndex = 0

    End Sub

    'GridViewの表示チェックの確認と、編集データの保管
    Function gv_DataGetInsert() As Integer

        '表示チェックの個数確認
        For i = 0 To gv_CusInfo.Rows.Count - 1

            checkViewBox = gv_CusInfo.Rows(i).FindControl("cb_viewCheck")

            If checkViewBox.Checked = True Then
                checkNum += 1
                selectView.viewCusID = gv_CusInfo.Rows(i).Cells(1).Text

            End If
        Next

        '表示チェックがない、もしくは２個以上ある場合エラーメッセージを表示する。
        If checkNum <> 1 Then

            '選択チェックエラーのため、選択チェックエラーメッセージを表示する。
            errorMsg.errorMsg(lbl_ErrorMsg, number.no9)
            Return number.no1

        End If

        Return number.no0

    End Function


    'DataTableに画面記述を保存する。
    Sub dataInsert(data As DataTable)

        data.Rows.Add()
        data.Rows(0)("CUST_ID") = txt_ID.Text
        data.Rows(0)("PERSON_LASTNAME") = txt_LastName.Text
        data.Rows(0)("PERSON_NAME") = txt_Name.Text
        data.Rows(0)("PERSON_KANA_LASTNAME") = txt_KanaLastName.Text
        data.Rows(0)("PERSON_KANA_NAME") = txt_KanaName.Text
        data.Rows(0)("SEX") = viewCus.viewCusSex
        data.Rows(0)("BIRTH_YEAR") = txt_BirthYear.Text
        data.Rows(0)("BIRTH_MONTH") = txt_BirthMonth.Text
        data.Rows(0)("BIRTH_DAY") = txt_BirthDay.Text

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        'エラーメッセージを表示しない状態に変更。
        lbl_ErrorMsg.Visible = False

        'ポストバックしてない場合初期化
        If Not Page.IsPostBack Then
            '性別に値を代入。
            commonItem.sexItemBrankInsert(ddl_Sex)
            Return
        End If




    End Sub

    'メインメニューボタンが押下された時の処理
    Protected Sub btn_MainMenu_Click(sender As Object, e As EventArgs) Handles btn_MainMenu.Click

        'メインメニューを表示する。
        Response.Redirect("webMainMenu.aspx", True)

    End Sub

    'クリアボタンが押下された時の処理
    Protected Sub btn_Clear_Click(sender As Object, e As EventArgs) Handles btn_Clear.Click

        Clear()

    End Sub

    '表示ボタンが押下された時の処理
    Protected Sub btn_View_Click(sender As Object, e As EventArgs) Handles btn_View.Click

        '性別の記述を数値に変換
        If 0 < ddl_Sex.SelectedIndex Then
            viewCus.viewCusSex = ddl_Sex.SelectedIndex
        End If

        '取得データを入れるデータテーブルの作成
        getData = viewClass.getDataAddColumns(getData)
        '画面記述を入れるデータテーブルの作成
        screenData = viewClass.viewDataTable(screenData)

        '画面記述をデータテーブルに代入する。
        dataInsert(screenData)

        'データの取得
        Try
            no = viewClass.viewGetData(getData, screenData)

            If no = 2 Then
                'SQLエラーのため、SQLエラーメッセージを表示する。
                errorMsg.errorMsg(lbl_ErrorMsg, Number.no2)
                Return
            End If

        Catch ex As Exception
            'その他エラーメッセージを表示する。
            errorMsg.errorMsg(lbl_ErrorMsg, Number.no4)
            Return
        End Try

        '性別の数値を文字に変換。
        getData = viewClass.sexWordChange(getData)


        'グリッドビューに表示
        gv_CusInfo.DataSource = getData
        gv_CusInfo.DataBind()


    End Sub

    '会員情報更新画面ボタンを押したときの
    Protected Sub btn_cusUP_Click(sender As Object, e As EventArgs) Handles btn_cusUP.Click

        '表示チェックと選択データの保管を行う。エラーの場合処理を終了する。
        If gv_DataGetInsert() = 1 Then
            Return
        End If

        '更新ページの表示
        Response.Redirect("~/webUp.aspx")

    End Sub

    '会員情報消去画面ボタンを押したときの
    Protected Sub btn_cusDelete_Click(sender As Object, e As EventArgs) Handles btn_cusDelete.Click

        '表示チェックと選択データの保管を行う。エラーの場合処理を終了する。
        If gv_DataGetInsert() = 1 Then
            Return
        End If

        '消去ページの表示
        Response.Redirect("~/webDelete.aspx")

    End Sub



End Class