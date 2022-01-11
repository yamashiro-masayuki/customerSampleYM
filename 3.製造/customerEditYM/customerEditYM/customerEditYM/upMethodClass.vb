Imports System.Data.SqlClient
Imports System.Data
Public Class upMethodClass

	Dim commonMethod As New commonMethodClass


	'データ更新時データに変更があるか確認するTable。
	Public Property getCusAfterData As New DataTable


	'編集したデータを登録する。
	Function upData(common As commonMethodClass, data As DataTable) As Boolean
		Dim con As String = commonMethod.dataSorce
		Dim Sql As String
		Sql = "update m_customer set "
		'パスワードを変更していない場合更新をしない。
		If Not data.Rows(0)("CUST_PASS").ToString() = "" Then
			Sql += $"CUST_PASS = '{data.Rows(0)("CUST_PASS").ToString()}', "
		End If
		Sql += $"CUST_ID = '{data.Rows(0)("CUST_ID").ToString()}', "
		Sql += $"PERSON_LASTNAME = '{data.Rows(0)("PERSON_LASTNAME").ToString()}', "
		Sql += $"PERSON_NAME = '{data.Rows(0)("PERSON_NAME").ToString()}', "
		Sql += $"PERSON_KANA_LASTNAME = '{data.Rows(0)("PERSON_KANA_LASTNAME").ToString()}', "
		Sql += $"PERSON_KANA_NAME = '{data.Rows(0)("PERSON_KANA_NAME").ToString()}', "
		Sql += $"SEX = '{data.Rows(0)("SEX").ToString()}', "
		Sql += $"BIRTH_YEAR = '{data.Rows(0)("BIRTH_YEAR").ToString()}', "
		Sql += $"BIRTH_MONTH = '{data.Rows(0)("BIRTH_MONTH").ToString()}', "
		Sql += $"BIRTH_DAY = '{data.Rows(0)("BIRTH_DAY").ToString()}', "
		Sql += $"POSTAL_CODE = '{data.Rows(0)("POSTAL_CODE").ToString()}', "
		Sql += $"ADDRESS_PREFECTURES = '{data.Rows(0)("ADDRESS_PREFECTURES").ToString()}', "
		Sql += $"ADDRESS_CITY = '{data.Rows(0)("ADDRESS_CITY").ToString()}', "
		Sql += $"ADDRESS_STREET = '{data.Rows(0)("ADDRESS_STREET").ToString()}', "
		Sql += $"ADDRESS_BUILDING = '{data.Rows(0)("ADDRESS_BUILDING").ToString()}', "
		Sql += $"UPDATE_PERSON = '{data.Rows(0)("UPDATE_PERSON").ToString()}', "
		Sql += $"UPDATE_DAY = '{data.Rows(0)("UPDATE_DAY").ToString()}' "
		Sql += $"WHERE CUST_ID = '{data.Rows(0)("CUST_ID")}' and "
		Sql += "IS_DLTFLG = 0 "

		Try
			Try
				Using cmd As New SqlCommand(Sql, common.Conn, common.tra)

					cmd.ExecuteNonQuery()
					upData = True
					common.tra.Commit()
				End Using
			Catch ex As Exception
				common.tra.Rollback()
				Console.WriteLine(ex.Message)
			End Try
		Catch ex As Exception
			common.tra.Rollback()
			Console.WriteLine(ex.Message)
			upData = False
		End Try


	End Function


	'画面の記述データを入れるDataTableを作成する。
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



	'取得データが画面表示データと一致するか確認する。
	Function checkCusData(beforeData As DataTable, afterData As DataTable) As Integer

		For i = 0 To afterData.Columns.Count - 1

			If beforeData.Rows(0)(i).ToString <> afterData.Rows(0)(i).ToString Then

				checkCusData = 1
				Return checkCusData

			End If
		Next

		checkCusData = 0

	End Function





End Class
