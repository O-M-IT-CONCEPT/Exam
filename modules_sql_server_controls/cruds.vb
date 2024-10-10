Imports System.Data.SqlClient
Imports System.IO
Imports System.Management
Imports System.Text
Imports System.Threading.Tasks


Module cruds

    Public Function Crud(sql As String, sqlParameters As List(Of SqlParameter)) As DataTable
        Dim dt As New DataTable()
        Using conn As New SqlConnection(cs)
            Try
                conn.Open()
                Using cmd As New SqlCommand(sql, conn)
                    If sqlParameters IsNot Nothing Then
                        cmd.Parameters.AddRange(sqlParameters.ToArray())
                    End If
                    If sql.Trim().ToUpper().StartsWith("SELECT") Then
                        Using da As New SqlDataAdapter(cmd)
                            da.Fill(dt)
                        End Using
                    Else
                        cmd.ExecuteNonQuery()
                    End If
                End Using
            Catch ex As Exception
                MsgBox("An error occurred: " & ex.Message)
            Finally
                conn.Close()
            End Try
        End Using

        Return dt
    End Function
    Public Function ExecuteScalar(query As String, params As List(Of SqlParameter)) As Object
        Dim con As New SqlConnection(cs)
        con.Open()
        Dim cmd As New SqlCommand(query, con)
        For Each param In params
            cmd.Parameters.Add(param)
        Next
        Return cmd.ExecuteScalar()
    End Function
    Public Async Function UpdateDecimalFieldsAsyncold(connectionString As String) As Task
        Try
            Using con As New SqlConnection(connectionString)
                Await con.OpenAsync()
                Dim cmd As SqlCommand = con.CreateCommand()
                cmd.CommandTimeout = 0 ' Set the command timeout to infinite

                ' Get all tables in the database
                cmd.CommandText = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE'"
                Dim tables As New List(Of String)
                Using reader As SqlDataReader = Await cmd.ExecuteReaderAsync()
                    While Await reader.ReadAsync()
                        tables.Add(reader("TABLE_NAME").ToString())
                    End While
                End Using

                ' Loop through each table
                For Each table As String In tables
                    ' Get all decimal fields in the table
                    cmd.CommandText = $"SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{table}' AND DATA_TYPE = 'decimal'"
                    Dim decimalFields As New List(Of String)
                    Using reader As SqlDataReader = Await cmd.ExecuteReaderAsync()
                        While Await reader.ReadAsync()
                            decimalFields.Add(reader("COLUMN_NAME").ToString())
                        End While
                    End Using

                    ' Alter each decimal field to have 2 decimal places
                    For Each field As String In decimalFields
                        cmd.CommandText = $"ALTER TABLE {table} ALTER COLUMN {field} DECIMAL(18, 3)"
                        Await cmd.ExecuteNonQueryAsync()
                    Next
                Next

                MsgBox("Decimal fields updated successfully.")
            End Using
        Catch ex As Exception
            MsgBox($"An error occurred: {ex.Message}")
        End Try
    End Function

    Public Async Function UpdateDecimalFieldsAsync(connectionString As String) As Task
        Try
            Using con As New SqlConnection(connectionString)
                Await con.OpenAsync()
                Dim cmd As SqlCommand = con.CreateCommand()
                cmd.CommandTimeout = 0 ' Set the command timeout to infinite

                ' Get all tables in the database
                cmd.CommandText = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE'"
                Dim tables As New List(Of String)
                Using reader As SqlDataReader = Await cmd.ExecuteReaderAsync()
                    While Await reader.ReadAsync()
                        tables.Add(reader("TABLE_NAME").ToString())
                    End While
                End Using

                ' Loop through each table
                For Each table As String In tables
                    ' Get all decimal fields in the table
                    cmd.CommandText = $"SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{table}' AND DATA_TYPE = 'decimal'"
                    Dim decimalFields As New List(Of String)
                    Using reader As SqlDataReader = Await cmd.ExecuteReaderAsync()
                        While Await reader.ReadAsync()
                            decimalFields.Add(reader("COLUMN_NAME").ToString())
                        End While
                    End Using

                    ' Loop through each decimal field in the table
                    For Each field As String In decimalFields
                        ' If the field is named "Amount", allow maximum precision (38 total digits, 38 decimal places)
                        If field.Equals("Amount", StringComparison.OrdinalIgnoreCase) Or field.Equals("Change", StringComparison.OrdinalIgnoreCase) Then
                            cmd.CommandText = $"ALTER TABLE {table} ALTER COLUMN {field} DECIMAL(38, 18)"
                        Else
                            ' For other fields, use DECIMAL(18, 3)
                            cmd.CommandText = $"ALTER TABLE {table} ALTER COLUMN {field} DECIMAL(18, 3)"
                        End If
                        Await cmd.ExecuteNonQueryAsync()
                    Next
                Next

                MsgBox("Decimal fields updated successfully.")
            End Using
        Catch ex As Exception
            MsgBox($"An error occurred: {ex.Message}")
        End Try
    End Function


    Public Function ExecuteReader(query As String, params As List(Of SqlParameter)) As SqlDataReader
        Dim con As New SqlConnection(cs)
        con.Open()
        Dim cmd As New SqlCommand(query, con)
        For Each param In params
            cmd.Parameters.Add(param)
        Next
        Return cmd.ExecuteReader(CommandBehavior.CloseConnection)
    End Function


    Dim st As String
    Public Function ReadCS() As String
        Using sr As StreamReader = New StreamReader(Application.StartupPath & "\SQLSettings.dat")
            st = sr.ReadLine()
        End Using
        Return st
    End Function
    Public Function ReadServer() As String
        Using sr As StreamReader = New StreamReader(Application.StartupPath & "\SQLSettings.dat")
            st = sr.ReadLine()
        End Using
        Dim serverstr As String = st.Split(";")(0)
        Return serverstr
    End Function
    Public ReadOnly cs As String = ReadCS()
    Public ReadOnly serverstr As String = ReadServer()

End Module
