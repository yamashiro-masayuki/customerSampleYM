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

    'Passの記述一致確認
    Function checkPassTextBox(txtPass As TextBox, txtCheckPass As TextBox) As Integer

        If txtPass.Text = txtCheckPass.Text Then
            checkPassTextBox = 0
        Else
            checkPassTextBox = 1
        End If

    End Function

    '生年月日の日付矛盾チェック
    Function checkBirthDate(day As String) As Integer

        If day <= $"{Date.Now.Year}{Date.Now.Month}{Date.Now.Day}" Then
            checkBirthDate = 0
        Else
            checkBirthDate = 1
        End If

    End Function




End Class
