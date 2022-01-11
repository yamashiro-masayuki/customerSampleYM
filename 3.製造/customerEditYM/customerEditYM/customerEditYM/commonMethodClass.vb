Imports System.Data.SqlClient
Imports System.Data
Public Class commonMethodClass

    '顧客情報マスタの取得データを入れるデータテーブル型変数
    Public Property getCusData As New DataTable

    '都道府県マスタの取得データを入れるデータテーブル型変数
    Public Property getPrefectureData As New DataTable

    Public Property dataSorce As String = "Data Source=DESKTOP-CF5KSJ9;Initial Catalog=customerSampleYM;Integrated Security=SSPI;"

#Region "共通SQLクライアント"

    '共通トランザクションを保管する変数
    Public Shared tra As SqlTransaction
    '共通コマンドを保管する変数
    Public Shared cmd As SqlCommand
    '共通コネクションを保管する変数
    Public Shared Conn As New SqlConnection



#End Region


#Region "取得データテーブルのカラム追加"

    '顧客情報マスタと都道府県マスタをカラムで入れる。
    Function customerDataAddColums(data As DataTable) As DataTable

        data.Columns.Add("CUST_ID")
        data.Columns.Add("CUST_PASS")
        data.Columns.Add("PERSON_LASTNAME")
        data.Columns.Add("PERSON_NAME")
        data.Columns.Add("PERSON_KANA_LASTNAME")
        data.Columns.Add("PERSON_KANA_NAME")
        data.Columns.Add("SEX")
        data.Columns.Add("BIRTH_YEAR")
        data.Columns.Add("BIRTH_MONTH")
        data.Columns.Add("BIRTH_DAY")
        data.Columns.Add("POSTAL_CODE")
        data.Columns.Add("ADDRESS_PREFECTURES")
        data.Columns.Add("ADDRESS_CITY")
        data.Columns.Add("ADDRESS_STREET")
        data.Columns.Add("ADDRESS_BUILDING")
        data.Columns.Add("UPDATE_PERSON")
        data.Columns.Add("UPDATE_DAY")
        data.Columns.Add("CREATE_PERSON")
        data.Columns.Add("CREATE_DAY")
        data.Columns.Add("IS_DLTFLG")
        data.Columns.Add("PREFECTURE_CODE")
        data.Columns.Add("PREFECTURE_REGION")
        data.Columns.Add("PREFECTURE_NAME")
        data.Columns.Add("PREFECTURE_KANA_NAME")

        customerDataAddColums = data

    End Function

    '都道府県マスタのみをカラムで入れる。
    Function prefectureDataAddColums(data As DataTable) As DataTable

        data.Columns.Add("PREFECTURE_CODE")
        data.Columns.Add("PREFECTURE_REGION")
        data.Columns.Add("PREFECTURE_NAME")
        data.Columns.Add("PREFECTURE_KANA_NAME")

        prefectureDataAddColums = data

    End Function

    '顧客情報マスタのみをカラムで入れる。
    Function customerOnlyDataAddColums(data As DataTable) As DataTable

        data.Columns.Add("CUST_ID")
        data.Columns.Add("CUST_PASS")
        data.Columns.Add("PERSON_LASTNAME")
        data.Columns.Add("PERSON_NAME")
        data.Columns.Add("PERSON_KANA_LASTNAME")
        data.Columns.Add("PERSON_KANA_NAME")
        data.Columns.Add("SEX")
        data.Columns.Add("BIRTH_YEAR")
        data.Columns.Add("BIRTH_MONTH")
        data.Columns.Add("BIRTH_DAY")
        data.Columns.Add("POSTAL_CODE")
        data.Columns.Add("ADDRESS_PREFECTURES")
        data.Columns.Add("ADDRESS_CITY")
        data.Columns.Add("ADDRESS_STREET")
        data.Columns.Add("ADDRESS_BUILDING")
        data.Columns.Add("UPDATE_PERSON")
        data.Columns.Add("UPDATE_DAY")
        data.Columns.Add("CREATE_PERSON")
        data.Columns.Add("CREATE_DAY")
        data.Columns.Add("IS_DLTFLG")

        customerOnlyDataAddColums = data

    End Function

#End Region

    'IDと一致したレコードを取得するメソッド
    Function GetData(data As DataTable, id As String) As Integer
        Dim con As String = dataSorce
        Dim Sql As String
        Sql = "SELECT * "
        Sql += "FROM m_customer "
        Sql += "Left Join m_prefecture On m_customer.ADDRESS_PREFECTURES = m_prefecture.PREFECTURE_CODE "
        Sql += $"where CUST_ID = '{id}' and "
        Sql += "IS_DLTFLG = 0 "

        Try
            Using Conn As New SqlConnection
                Conn.ConnectionString = (con)
                Conn.Open()
                Using cmd As New SqlCommand(Sql)
                    cmd.Connection = Conn
                    cmd.CommandType = CommandType.Text
                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        While (reader.Read())
                            data.Rows.Add()
                            data.Rows(0)("CUST_ID") = reader.GetString(0)
                            data.Rows(0)("CUST_PASS") = reader.GetString(1)
                            data.Rows(0)("PERSON_LASTNAME") = reader.GetString(2)
                            data.Rows(0)("PERSON_NAME") = reader.GetString(3)
                            data.Rows(0)("PERSON_KANA_LASTNAME") = reader.GetString(4)
                            data.Rows(0)("PERSON_KANA_NAME") = reader.GetString(5)
                            data.Rows(0)("SEX") = reader.GetInt32(6)
                            data.Rows(0)("BIRTH_YEAR") = reader.GetInt32(7)
                            data.Rows(0)("BIRTH_MONTH") = reader.GetInt32(8)
                            data.Rows(0)("BIRTH_DAY") = reader.GetInt32(9)
                            data.Rows(0)("POSTAL_CODE") = reader.GetString(10)
                            data.Rows(0)("ADDRESS_PREFECTURES") = reader.GetInt32(11)
                            data.Rows(0)("ADDRESS_CITY") = reader.GetString(12)
                            data.Rows(0)("ADDRESS_STREET") = reader.GetString(13)
                            data.Rows(0)("ADDRESS_BUILDING") = reader.GetString(14)
                            data.Rows(0)("UPDATE_PERSON") = reader.GetString(15)
                            data.Rows(0)("UPDATE_DAY") = reader.GetDateTime(16)
                            data.Rows(0)("CREATE_PERSON") = reader.GetString(17)
                            data.Rows(0)("CREATE_DAY") = reader.GetDateTime(18)
                            data.Rows(0)("IS_DLTFLG") = reader.GetByte(19)
                            data.Rows(0)("PREFECTURE_CODE") = reader.GetInt32(20)
                            data.Rows(0)("PREFECTURE_REGION") = reader.GetString(21)
                            data.Rows(0)("PREFECTURE_NAME") = reader.GetString(22)
                            data.Rows(0)("PREFECTURE_KANA_NAME") = reader.GetString(23)
                        End While
                    End Using
                    GetData = 1
                End Using
            End Using
        Catch ex As Exception
            Console.WriteLine(ex.Message)
            GetData = 2
        End Try
    End Function

    '都道府県名を取得するメソッド
    Function GetPrefecture(data As DataTable) As Integer
        Dim con As String = dataSorce
        Dim Sql As String
        Dim i = 0
        Sql = "SELECT * "
        Sql += "FROM m_prefecture "

        Try
            Using Conn As New SqlConnection
                Conn.ConnectionString = (con)
                Conn.Open()
                Using cmd As New SqlCommand(Sql)
                    cmd.Connection = Conn
                    cmd.CommandType = CommandType.Text
                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        While (reader.Read())
                            data.Rows.Add()
                            data.Rows(i)("PREFECTURE_CODE") = reader.GetInt32(0)
                            data.Rows(i)("PREFECTURE_REGION") = reader.GetString(1)
                            data.Rows(i)("PREFECTURE_NAME") = reader.GetString(2)
                            data.Rows(i)("PREFECTURE_KANA_NAME") = reader.GetString(3)
                            i += 1
                        End While
                    End Using
                    GetPrefecture = 1
                End Using
            End Using
        Catch ex As Exception
            Console.WriteLine(ex.Message)
            GetPrefecture = 2
        End Try
    End Function

    '取得性別を数値から文字に変換
    Function sexWordChange(data As Integer) As String

        If data = 1 Then
            sexWordChange = "男"

        ElseIf data = 2 Then
            sexWordChange = "女"

        ElseIf data = 3 Then
            sexWordChange = "その他"

        Else
            sexWordChange = ""
        End If

    End Function


    'IDと一致したレコードを悲観ロックし、取得するメソッド
    Function GetRockData(common As commonMethodClass, data As DataTable, id As String) As Integer
        Dim con As String = dataSorce
        Dim Sql As String
        Dim reader As SqlDataReader

        Sql += "	select * "
        Sql += "	from m_customer WITH(XLOCK,ROWLOCK,NOWAIT) "
        Sql += $"	where CUST_ID = '{id}' "

        Try
            cmd.CommandText = Sql
            reader = cmd.ExecuteReader()
            While (reader.Read())
                data.Rows.Add()
                data.Rows(0)("CUST_ID") = reader.GetString(0)
                data.Rows(0)("CUST_PASS") = reader.GetString(1)
                data.Rows(0)("PERSON_LASTNAME") = reader.GetString(2)
                data.Rows(0)("PERSON_NAME") = reader.GetString(3)
                data.Rows(0)("PERSON_KANA_LASTNAME") = reader.GetString(4)
                data.Rows(0)("PERSON_KANA_NAME") = reader.GetString(5)
                data.Rows(0)("SEX") = reader.GetInt32(6)
                data.Rows(0)("BIRTH_YEAR") = reader.GetInt32(7)
                data.Rows(0)("BIRTH_MONTH") = reader.GetInt32(8)
                data.Rows(0)("BIRTH_DAY") = reader.GetInt32(9)
                data.Rows(0)("POSTAL_CODE") = reader.GetString(10)
                data.Rows(0)("ADDRESS_PREFECTURES") = reader.GetInt32(11)
                data.Rows(0)("ADDRESS_CITY") = reader.GetString(12)
                data.Rows(0)("ADDRESS_STREET") = reader.GetString(13)
                data.Rows(0)("ADDRESS_BUILDING") = reader.GetString(14)
                data.Rows(0)("UPDATE_PERSON") = reader.GetString(15)
                data.Rows(0)("UPDATE_DAY") = reader.GetDateTime(16)
                data.Rows(0)("CREATE_PERSON") = reader.GetString(17)
                data.Rows(0)("CREATE_DAY") = reader.GetDateTime(18)
                data.Rows(0)("IS_DLTFLG") = reader.GetByte(19)
            End While
            reader.Close()
            GetRockData = 1
        Catch ex As Exception
            Console.WriteLine(ex.Message)
            GetRockData = 2
        End Try
    End Function








End Class
