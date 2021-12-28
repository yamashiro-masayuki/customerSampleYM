'画面項目の値を代入する処理を行う
Public Class commonItemAssignment

    Dim commonMethod As New commonMethodClass
    Dim list As ListItem

    '性別の値を入れる作業
    Function sexItemInsert(ddl As DropDownList)

        list = New ListItem("男", "0")
        ddl.Items.Add(List)
        list = New ListItem("女", "1")
        ddl.Items.Add(List)
        list = New ListItem("その他", "2")
        ddl.Items.Add(List)

    End Function

    '性別(空白入り)の値を入れる作業
    Function sexItemBrankInsert(ddl As DropDownList)

        list = New ListItem("", "0")
        ddl.Items.Add(list)
        list = New ListItem("男", "1")
        ddl.Items.Add(list)
        list = New ListItem("女", "2")
        ddl.Items.Add(list)
        list = New ListItem("その他", "3")
        ddl.Items.Add(list)

    End Function


    '都道府県の値を入れる作業
    Function prefectureItemInsert(ddl As DropDownList, method As commonMethodClass) As Integer

        commonMethod = method
        '都道府県マスタの取得データを入れるDataTableの作成
        commonMethod.prefectureDataAddColums(commonMethod.getPrefectureData)
        '都道府県マスタのデータ取得
        prefectureItemInsert = commonMethod.GetPrefecture(commonMethod.getPrefectureData)
        If prefectureItemInsert = 2 Then
            Return prefectureItemInsert
        End If
        '都道府県マスタのデータ代入
        For i = 0 To commonMethod.getPrefectureData.Rows.Count - 1
            list = New ListItem($"{commonMethod.getPrefectureData.Rows(i)("PREFECTURE_NAME")}", $"{i}")
            ddl.Items.Add(list)
        Next



    End Function






End Class
