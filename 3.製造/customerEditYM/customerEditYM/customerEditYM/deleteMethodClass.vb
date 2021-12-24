Imports System.Data.SqlClient
Imports System.Data
Public Class deleteMethodClass

	Dim commonMethod As New commonMethodClass

	'編集したデータを登録する。
	Function deleteData(id As String) As Integer
		Dim con As String = commonMethod.dataSorce
		Dim Sql As String
		Sql = "update m_customer set "
		Sql += $"IS_DLTFLG = 1  "
		Sql += $"WHERE CUST_ID = '{id}' "

		Try
			Using Conn As New SqlConnection
				Conn.ConnectionString = (con)
				Conn.Open()
				Using transaction As SqlTransaction = Conn.BeginTransaction()
					Try
						Using cmd As New SqlCommand(Sql, Conn, transaction)

							cmd.ExecuteNonQuery()
							deleteData = 1
							transaction.Commit()
						End Using
					Catch ex As Exception
						transaction.Rollback()
						deleteData = 2
						Console.WriteLine(ex.Message)
					End Try
				End Using
			End Using
		Catch ex As Exception
			Console.WriteLine(ex.Message)
			deleteData = 2
		End Try

	End Function


End Class
