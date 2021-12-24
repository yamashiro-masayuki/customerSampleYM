Public Class errorMsgClass


    'メソッド呼び出し時に使用した番号を利用してエラーメッセージを返却するメソッド
    Function errorMsg(lbl As Label, msgNO As Integer) As String

        If msgNO = 1 Then
            errorMsg = "必須項目に記述がありません。"

        ElseIf msgNO = 2 Then
            errorMsg = "SQLエラーです。"

        ElseIf msgNO = 3 Then
            errorMsg = "データが存在しません。確認してください。"

        ElseIf msgNO = 4 Then
            errorMsg = "予期せぬエラーです、管理者に確認してください。"

        ElseIf msgNO = 5 Then
            errorMsg = "Passが一致しません。確認してください。"

        ElseIf msgNO = 6 Then
            errorMsg = "生年月日が現在よりも未来に設定されています。確認してください。"

        ElseIf msgNO = 7 Then
            errorMsg = "同一のIDが使用されています。変更してください。"

        ElseIf msgNO = 8 Then
            errorMsg = "別の人が更新作業を行いました。上記記述が最新のデータです。"

        ElseIf msgNO = 9 Then
            errorMsg = "複数選択しているか、選択できていません。確認してください。"

        Else
            errorMsg = ""

        End If

        lbl.Text = errorMsg
        lbl.Visible = True

    End Function

End Class
