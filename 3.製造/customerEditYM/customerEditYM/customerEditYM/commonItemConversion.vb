'取得データの数値・文字変換。
'記述データの数値・文字変換。
Public Class commonItemConversion

    '性別を数値に変換
    Function sexItemInConvert(ddl As DropDownList) As Integer

        '「1：男、2：女、3：その他」に一致した数値を返す。
        If ddl.Text = "0" Then
            sexItemInConvert = 1

        ElseIf ddl.Text = "1" Then
            sexItemInConvert = 2

        ElseIf ddl.Text = "2" Then
            sexItemInConvert = 3

        End If

    End Function

    '性別を文字に変換
    Function sexItemOutConvert(data As Integer) As String

        '「1：男、2：女、3：その他」に一致した数値を返す。
        If data = 1 Then
            sexItemOutConvert = "男"

        ElseIf data = 2 Then
            sexItemOutConvert = "女"

        ElseIf data = 3 Then
            sexItemOutConvert = "その他"

        End If

    End Function

    '都道府県を数値に変換
    Function prefectureItemInConvert(data As String, method As commonMethodClass) As Integer

        For i = 0 To method.getPrefectureData.Rows.Count

            If data = method.getPrefectureData.Rows(i)("PREFECTURE_CODE").ToString Then
                Return i

            End If

        Next


    End Function







End Class
