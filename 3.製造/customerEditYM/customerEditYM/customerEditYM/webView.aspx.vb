Public Class webView
    Inherits System.Web.UI.Page

    'エラーメッセージクラスの呼び出し
    Dim errorMsg As New cusCommon.errorMsgClass
    '番号クラスの呼び出し
    Dim number As New cusCommon.numberClass
    '共通メソッドクラスの呼び出し
    Dim commonMethod As New cusCommon.commonMethodClass
    '値変換クラスの呼び出し
    Dim convert As New cusCommon.commonItemConversion

    '一覧・表示メソッドクラス
    Dim viewClass As New webViewClass
    '一覧・表示メソッドクラス
    Dim viewCus As New viewCusInfo

    'メソッドの戻り値代入変数
    Dim no As Integer
    '画面記述項目を入れるDataTable変数
    Dim screenData As New DataTable
    '取得データを入れるDataTable変数
    Dim getData As New DataTable


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

        'ポストバックしてない場合初期化
        If Not Page.IsPostBack Then
            'Clear()
        End If

        'エラーメッセージを非表示にする。
        lbl_ErrorMsg.Visible = False




        ''GridViewを表示する。
        'Me.gv_CusInfo.ShowHeaderWhenEmpty = True
        ''登録のためのテーブル作り
        'Data = serchViewClass.viewDataTable(Data)
        'gv_CusInfo.DataSource = Data
        'gv_CusInfo.DataBind()

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

        'グリッドビューに表示
        gv_CusInfo.DataSource = getData
        gv_CusInfo.DataBind()




    End Sub

    '会員情報更新画面ボタンを押したときの
    Protected Sub btn_cusUP_Click(sender As Object, e As EventArgs) Handles btn_cusUP.Click

        '選択されたデータを保管する。

        '更新ページの表示
        Response.Redirect("~/webUp.aspx")

    End Sub

    '会員情報消去画面ボタンを押したときの
    Protected Sub btn_cusDelete_Click(sender As Object, e As EventArgs) Handles btn_cusDelete.Click

        '消去ページの表示
        Response.Redirect("~/webDelete.aspx")

    End Sub


    Protected Sub gv_CusInfo_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles gv_CusInfo.RowDataBound
        ''ヘッダ行の場合は処理しない
        'If e.Row.RowIndex < 0 Then Return

        ''チェックボックスコントロールを取得して有効化する
        'Dim check As CheckBox = CType(e.Row.Cells(0).Controls(0), CheckBox)
        'check.Enabled = True


    End Sub

End Class