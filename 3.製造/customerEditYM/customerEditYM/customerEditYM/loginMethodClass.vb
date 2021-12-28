Imports System.Data.SqlClient
Imports System.Data
Public Class loginMethodClass

    Dim commonMethod As New commonMethodClass

    'IDとPassに当てはまるデータを取ってくるSQL
    Function GetData(loginCus As loginCusInfo, id As String, pass As String) As Integer
        Dim con As String = commonMethod.dataSorce
        Dim Sql As String
        Sql += "SELECT PERSON_LASTNAME, "
        Sql += "PERSON_NAME "
        Sql += "FROM m_customer "
        Sql += $"where CUST_ID = '{id}' and "
        Sql += $"CUST_PASS = '{pass}' and "
        Sql += "IS_DLTFLG = 0 "

        GetData = 0

        Try
            Using Conn As New SqlConnection
                Conn.ConnectionString = (con)
                Conn.Open()
                Using cmd As New SqlCommand(Sql)
                    cmd.Connection = Conn
                    cmd.CommandType = CommandType.Text
                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        While (reader.Read())
                            loginCus.loginCusLastName = reader.GetString(0)
                            loginCus.loginCusName = reader.GetString(1)
                            GetData = 1
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            Console.WriteLine(ex.Message)
            GetData = 2
        End Try
    End Function






End Class
