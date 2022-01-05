Public Class selectViewCusInfo


    '一覧・表示画面で選択された顧客ID
    Public Shared selectViewCusID As String = "admin"
    Public Property viewCusID() As String
        Get
            Return selectViewCusID
        End Get
        Set(ByVal value As String)
            selectViewCusID = value
        End Set
    End Property

    'ロックエラーフラグ
    Public Property rockErrorFlg As Boolean
    Public Property rockError() As Boolean
        Get
            Return rockErrorFlg
        End Get
        Set(ByVal value As Boolean)
            rockErrorFlg = value
        End Set
    End Property













End Class
