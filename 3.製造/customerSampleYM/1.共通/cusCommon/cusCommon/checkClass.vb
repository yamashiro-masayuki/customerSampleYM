Public Class checkClass


    'TextBoxに記述があるかを確認するメソッド
    '返却値「0:記述なし、1:記述あり」
    Function checkTextBox(txtData As TextBox) As Integer

        If txtData.Text.Length = 0 Then
            checkTextBox = 0
        Else
            checkTextBox = 1
        End If

    End Function






End Class
