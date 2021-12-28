Imports System.Data.SqlClient
Imports System.Data
Public Class webViewClass

	Dim commonMethod As New commonMethodClass


	'dataColumの挿入
	Function viewDataTable(data As DataTable) As DataTable

		data.Columns.Add("CUST_ID")
		data.Columns.Add("PERSON_LASTNAME")
		data.Columns.Add("PERSON_NAME")
		data.Columns.Add("PERSON_KANA_LASTNAME")
		data.Columns.Add("PERSON_KANA_NAME")
		data.Columns.Add("SEX")
		data.Columns.Add("BIRTH_YEAR")
		data.Columns.Add("BIRTH_MONTH")
		data.Columns.Add("BIRTH_DAY")
		data.Columns.Add("CREATE_PERSON")

		viewDataTable = data

	End Function

	'dataColumの挿入
	Function getDataAddColumns(data As DataTable) As DataTable

		data.Columns.Add("ID")
		data.Columns.Add("氏名")
		data.Columns.Add("性別")
		data.Columns.Add("生年月日")
		data.Columns.Add("登録者")

		getDataAddColumns = data

	End Function

	'項目ごとのデータを取ってくる。
	Function viewGetData(ByRef data As DataTable, screenData As DataTable) As Integer
		Dim i As Integer = 0

		Dim con As String = commonMethod.dataSorce
		Dim Sql As String = $"SELECT  "
		Sql += $"* , "
		Sql += $"(select PERSON_LASTNAME from m_customer as m_c2 where CUST_ID = m_c1.CREATE_PERSON ) as CREATE_LASTNAME ,"
		Sql += $"(select PERSON_NAME from m_customer as m_c2 where CUST_ID = m_c1.CREATE_PERSON ) as CREATE_NAME "
		Sql += $"FROM m_customer as m_c1 "
		Sql += $"where 1 = 1 "
		If Not screenData.Rows(0)("CUST_ID").ToString = "" Then
			Sql += $"And CUST_ID like '%{screenData.Rows(0)("CUST_ID").ToString}%' "
		End If
		If Not screenData.Rows(0)("PERSON_LASTNAME").ToString = "" Then
			Sql += $"And PERSON_LASTNAME = '{screenData.Rows(0)("PERSON_LASTNAME").ToString}' "
		End If
		If Not screenData.Rows(0)("PERSON_NAME").ToString = "" Then
			Sql += $"And PERSON_NAME = '{screenData.Rows(0)("PERSON_NAME").ToString}' "
		End If
		If Not screenData.Rows(0)("PERSON_KANA_LASTNAME").ToString = "" Then
			Sql += $"And PERSON_KANA_LASTNAME = '{screenData.Rows(0)("PERSON_KANA_LASTNAME").ToString}' "
		End If
		If Not screenData.Rows(0)("PERSON_KANA_NAME").ToString = "" Then
			Sql += $"And PERSON_KANA_NAME = '{screenData.Rows(0)("PERSON_KANA_NAME").ToString}' "
		End If
		If Not screenData.Rows(0)("SEX").ToString = "" Then
			Sql += $"And SEX = '{screenData.Rows(0)("SEX").ToString}' "
		End If
		If Not screenData.Rows(0)("BIRTH_YEAR").ToString = "" Then
			Sql += $"And BIRTH_YEAR = '{screenData.Rows(0)("BIRTH_YEAR").ToString}' "
		End If
		If Not screenData.Rows(0)("BIRTH_MONTH").ToString = "" Then
			Sql += $"And BIRTH_MONTH = '{screenData.Rows(0)("BIRTH_MONTH").ToString}' "
		End If
		If Not screenData.Rows(0)("BIRTH_DAY").ToString = "" Then
			Sql += $"And BIRTH_DAY = '{screenData.Rows(0)("BIRTH_DAY").ToString}' "
		End If
		Sql += "And IS_DLTFLG = 0 "

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
							data.Rows(i)("ID") = reader.GetString(0)
							data.Rows(i)("氏名") = $"{reader.GetString(2)} {reader.GetString(3)}"
							data.Rows(i)("性別") = reader.GetInt32(6)
							data.Rows(i)("生年月日") = $"{reader.GetInt32(7)}/{reader.GetInt32(8)}/{reader.GetInt32(9)}"
							data.Rows(i)("登録者") = $"{reader.GetString(20)} {reader.GetString(21)}"
							i += 1
						End While
					End Using
					viewGetData = 1
				End Using
			End Using
		Catch ex As Exception
			Console.WriteLine(ex.Message)
			viewGetData = 2
		End Try
	End Function

	'性別の数値を文字に変換する。
	Function sexWordChange(data As DataTable)

		For i = 0 To data.Rows.Count - 1

			If data.Rows(i)("性別") = 1 Then
				data.Rows(i)("性別") = "男"

			ElseIf data.Rows(i)("性別") = 2 Then
				data.Rows(i)("性別") = "女"

			ElseIf data.Rows(i)("性別") = 3 Then
				data.Rows(i)("性別") = "その他"

			Else
				data.Rows(i)("性別") = "ｴﾗｰ"

			End If
		Next

		sexWordChange = data

	End Function






End Class
