Imports System.Data.SqlClient
Imports System.Data
Public Class addMethodClass

	Dim commonMethod As New commonMethodClass

	'IDに当てはまるデータを取ってくるSQL
	Function checkData(id As String) As Integer
		Dim con As String = commonMethod.dataSorce
		Dim Sql As String
		Sql += "SELECT CUST_ID "
		Sql += "FROM m_customer "
		Sql += $"where CUST_ID = '{id}' and "
		Sql += "IS_DLTFLG = 0 "

		checkData = 0

		Try
			Using Conn As New SqlConnection
				Conn.ConnectionString = (con)
				Conn.Open()
				Using cmd As New SqlCommand(Sql)
					cmd.Connection = Conn
					cmd.CommandType = CommandType.Text
					Using reader As SqlDataReader = cmd.ExecuteReader()
						While (reader.Read())
							checkData = 1
						End While
					End Using
				End Using
			End Using
		Catch ex As Exception
			Console.WriteLine(ex.Message)
			checkData = 2
		End Try
	End Function

	'新しくデータを作成する
	Function addData(data As DataTable) As Integer
		Dim con As String = commonMethod.dataSorce
		Dim Sql As String
		Sql = "Insert into  m_customer ( "
		Sql += "CUST_ID, "
		Sql += "CUST_PASS, "
		Sql += "PERSON_LASTNAME, "
		Sql += "PERSON_NAME, "
		Sql += "PERSON_KANA_LASTNAME, "
		Sql += "PERSON_KANA_NAME, "
		Sql += "SEX, "
		Sql += "BIRTH_YEAR, "
		Sql += "BIRTH_MONTH, "
		Sql += "BIRTH_DAY, "
		Sql += "POSTAL_CODE, "
		Sql += "ADDRESS_PREFECTURES, "
		Sql += "ADDRESS_CITY, "
		Sql += "ADDRESS_STREET, "
		Sql += "ADDRESS_BUILDING, "
		Sql += "UPDATE_PERSON, "
		Sql += "UPDATE_DAY, "
		Sql += "CREATE_PERSON, "
		Sql += "CREATE_DAY, "
		Sql += "IS_DLTFLG ) "
		'実データの挿入
		Sql += "VALUES ( "
		Sql += $"'{data.Rows(0)("CUST_ID").ToString()}', "
		Sql += $"'{data.Rows(0)("CUST_PASS").ToString()}', "
		Sql += $"'{data.Rows(0)("PERSON_LASTNAME").ToString()}', "
		Sql += $"'{data.Rows(0)("PERSON_NAME").ToString()}', "
		Sql += $"'{data.Rows(0)("PERSON_KANA_LASTNAME").ToString()}', "
		Sql += $"'{data.Rows(0)("PERSON_KANA_NAME").ToString()}', "
		Sql += $"'{data.Rows(0)("SEX").ToString()}', "
		Sql += $"'{data.Rows(0)("BIRTH_YEAR").ToString()}', "
		Sql += $"'{data.Rows(0)("BIRTH_MONTH").ToString()}', "
		Sql += $"'{data.Rows(0)("BIRTH_DAY").ToString()}', "
		Sql += $"'{data.Rows(0)("POSTAL_CODE").ToString()}', "
		Sql += $"'{data.Rows(0)("ADDRESS_PREFECTURES").ToString()}', "
		Sql += $"'{data.Rows(0)("ADDRESS_CITY").ToString()}', "
		Sql += $"'{data.Rows(0)("ADDRESS_STREET").ToString()}', "
		Sql += $"'{data.Rows(0)("ADDRESS_BUILDING").ToString()}', "
		Sql += $"'{data.Rows(0)("UPDATE_PERSON").ToString()}', "
		Sql += $"'{data.Rows(0)("UPDATE_DAY").ToString()}', "
		Sql += $"'{data.Rows(0)("CREATE_PERSON").ToString()}', "
		Sql += $"'{data.Rows(0)("CREATE_DAY").ToString()}', "
		Sql += $"'{data.Rows(0)("IS_DLTFLG").ToString()}' "
		Sql += " ); "

		Try
			Using Conn As New SqlConnection
				Conn.ConnectionString = (con)
				Conn.Open()
				Using transaction As SqlTransaction = Conn.BeginTransaction()
					Try
						Using cmd As New SqlCommand(Sql, Conn, transaction)
							cmd.ExecuteNonQuery()
							addData = 0
							transaction.Commit()
						End Using
					Catch ex As Exception
						transaction.Rollback()
						addData = 2
						Console.WriteLine(ex.Message)
					End Try
				End Using
			End Using
		Catch ex As Exception
			Console.WriteLine(ex.Message)
			addData = 2
		End Try

	End Function











End Class
