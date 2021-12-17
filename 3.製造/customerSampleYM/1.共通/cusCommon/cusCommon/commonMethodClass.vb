Imports System.Data.SqlClient
Imports System.Data
Public Class commonMethodClass

    '顧客情報マスタの取得データを入れるデータテーブル型変数
    Public Property getCusData As New DataTable
    '都道府県マスタの取得データを入れるデータテーブル型変数
    Public Property getPrefectureData As New DataTable

    Public Property dataSorce As String = "Data Source=DESKTOP-CF5KSJ9;Initial Catalog=customerSampleYM;Integrated Security=SSPI;"


#Region "取得データテーブルのカラム追加"

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

        customerDataAddColums = data

    End Function

    Function prefectureDataAddColums(data As DataTable) As DataTable

        data.Columns.Add("PREFECTURE_CODE")
        data.Columns.Add("PREFECTURE_REGION")
        data.Columns.Add("PREFECTURE_NAME")
        data.Columns.Add("PREFECTURE_KANA_NAME")

        prefectureDataAddColums = data

    End Function

#End Region

    'IDと一致したレコードを取得するメソッド
    Function GetData(id As String, pass As String) As Integer
        Dim con As String = dataSorce
        Dim Sql As String
        Sql = "SELECT * "
        Sql += "FROM m_customer "
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
                            'Common.cusID = reader.GetString(1)
                            'Common.cusPass = reader.GetString(2)
                            'Common.fullName = reader.GetString(3)
                            'Common.sex = reader.GetString(4)
                            'Common.BDYear = reader.GetInt32(5)
                            'Common.BDMonth = reader.GetInt32(6)
                            'Common.BDDay = reader.GetInt32(7)
                            'Common.posAdress = reader.GetString(8)
                            'Common.address1 = reader.GetString(9)
                            'Common.address2 = reader.GetString(10)
                            'Common.checkData = True
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

End Class
