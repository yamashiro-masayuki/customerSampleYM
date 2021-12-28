Public Class loginCusInfo

    'ログイン時使用顧客ID
    Public Shared loginID As String = ""
    Public Property loginCusID() As String
        Get
            Return loginID
        End Get
        Set(ByVal value As String)
            loginID = value
        End Set
    End Property


    'ログイン者苗字
    Public Shared loginLastName As String = ""
    Public Property loginCusLastName() As String
        Get
            Return loginLastName
        End Get
        Set(ByVal value As String)
            loginLastName = value
        End Set
    End Property


    'ログイン者名前
    Public Shared loginName As String = ""
    Public Property loginCusName() As String
        Get
            Return loginName
        End Get
        Set(ByVal value As String)
            loginName = value
        End Set
    End Property


End Class
