Imports System.Data.SqlClient
Imports System.IO
Imports System.Text
Imports Microsoft.SqlServer.Management.Smo
Imports Microsoft.SqlServer.Management.Common
Imports MetroFramework
Imports MetroFramework.Forms
Imports System.Data.Sql

Public Class frmSqlServerSetting
    Dim st As String
    Dim SqlConnStr As String

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnDemoDB.Click
        If cmbInstallationType.SelectedIndex = 0 Then
            ValidateServerDetails()
            ConfigureSqlConnection()
            If ConfirmDatabaseCreation() Then
                SaveSqlSettings()
                If Not CheckBox1.Checked Then
                    CreateDB()
                Else
                    CreateDBnew()
                End If
                ShowSuccessMessage("DB has been created and SQL Server setting has been saved successfully. Application will be closed. Please start it again.")
                End
            End If
        ElseIf cmbInstallationType.SelectedIndex = 1 Then
            ValidateServerDetails()
            ConfigureSqlConnection()
            If ConfirmSqlServerConfiguration() Then
                SaveSqlSettings()
                ShowSuccessMessage("SQL Server setting has been saved successfully. Application will be closed. Please start it again.")
                End
            End If
        End If
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        If lblSet.Text = "Main Form" Then
            Me.Close()
        Else
            If ConfirmCloseApplication() Then
                End
            End If
        End If
    End Sub

    Private Sub CreateDB()
        Try
            Using con As New SqlConnection("Data Source=" & cmbServerName.Text & ";Initial Catalog=master;Integrated Security=True;MultipleActiveResultSets=True")
                con.Open()
                DropExistingDatabase(con, "STUDENT_DATA_DB")
                CreateNewDatabase(con, "STUDENT_DATA_DB")
                ExecuteDatabaseScript(con, Application.StartupPath & "\BlankDBscript.sql")
            End Using
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try
    End Sub

    Sub CreateDBnew()
        'Try


        Dim backupFolderPath As String = "C:\db_backup"
        Dim queryCheckDb As String = "If exists (select name from master.dbo.sysdatabases where name = @dbName) select 1 else select 0"
        Try
            Dim dbname As String = "STUDENT_DATA_DB"
            Using cmdCheck As New SqlCommand(queryCheckDb, con)
                cmdCheck.Parameters.AddWithValue("@dbName", dbname)
                If Convert.ToInt32(cmdCheck.ExecuteScalar()) = 1 Then
                    If Not Directory.Exists(backupFolderPath) Then
                        Directory.CreateDirectory(backupFolderPath)
                    End If
                    Dim backupFilePath As String = Path.Combine(backupFolderPath, dbname & "_backup_" & DateTime.Now.ToString("yyyyMMddHHmmss") & ".bak")
                    Dim queryBackup As String = "BACKUP DATABASE [" & dbname & "] TO DISK = @backupFilePath"
                    Using cmdBackup As New SqlCommand(queryBackup, con)
                        cmdBackup.Parameters.AddWithValue("@backupFilePath", backupFilePath)
                        cmdBackup.ExecuteNonQuery()
                    End Using
                End If
            End Using
        Catch EX As Exception
        End Try





        Dim conString As String = "Data Source=" & cmbServerName.Text & ";Initial Catalog=master;Integrated Security=True;MultipleActiveResultSets=True"
        Using con As New SqlConnection(conString)
            con.Open()
            Dim cb2 As String = "SELECT * FROM sys.databases WHERE name='STUDENT_DATA_DB'"
            Using cmd As New SqlCommand(cb2, con)
                Using rdr As SqlDataReader = cmd.ExecuteReader()
                    If rdr.Read() Then
                        Dim cb1 As String = "USE Master ALTER DATABASE STUDENT_DATA_DB SET Single_User WITH Rollback Immediate"
                        Using cmdDrop As New SqlCommand(cb1, con)
                            cmdDrop.ExecuteNonQuery()
                        End Using

                        Dim cbDrop As String = "DROP DATABASE STUDENT_DATA_DB"
                        Using cmdDropDB As New SqlCommand(cbDrop, con)
                            cmdDropDB.ExecuteNonQuery()
                        End Using
                    End If
                End Using
            End Using
            Dim cb3 As String = "CREATE DATABASE STUDENT_DATA_DB"
            Using cmdCreateDB As New SqlCommand(cb3, con)
                cmdCreateDB.ExecuteNonQuery()
            End Using

            Using sr As New StreamReader(Application.StartupPath & "\BlankDBscript.sql")
                Dim script As String = sr.ReadToEnd()
                Dim commands As String() = script.Split({"GO"}, StringSplitOptions.RemoveEmptyEntries)
                Using con1 As New SqlConnection(conString)
                    con1.Open()
                    For Each cmdText As String In commands
                        Using cmdExecuteScript As New SqlCommand(cmdText, con1)
                            cmdExecuteScript.ExecuteNonQuery()
                        End Using
                    Next
                End Using
            End Using
        End Using

        'Catch ex As Exception
        'MetroMessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End Try
    End Sub
    Private Sub cmbAuthentication_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbAuthentication.SelectedIndexChanged
        If cmbAuthentication.SelectedIndex = 0 Then
            txtUserName.ReadOnly = True
            txtPassword.ReadOnly = True
            txtUserName.Text = ""
            txtPassword.Text = ""
        ElseIf cmbAuthentication.SelectedIndex = 1 Then
            txtUserName.ReadOnly = False
            txtPassword.ReadOnly = False
        End If
    End Sub

    Private Sub cmbServerName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbServerName.SelectedIndexChanged
        cmbAuthentication.Enabled = True
    End Sub

    Public Sub Reset()
        txtPassword.Text = ""
        txtUserName.Text = ""
        cmbServerName.Text = ""
        cmbAuthentication.SelectedIndex = 0
        cmbInstallationType.SelectedIndex = 0
    End Sub

    Private Sub btnTestConnection_Click(sender As Object, e As EventArgs) Handles btnTestConnection.Click
        ValidateServerDetails()

        Dim SqlConn As New SqlConnection
        ConfigureSqlConnection()

        If SqlConn.State = ConnectionState.Closed Then
            SqlConn.ConnectionString = SqlConnStr
            Try
                SqlConn.Open()
                ShowSuccessMessage("Successful DB Connection")
            Catch ex As Exception
                ShowErrorMessage("Invalid DB Connection: " & ex.Message)
            End Try
        End If
    End Sub

    Private Sub btnBlankDB_Click(sender As Object, e As EventArgs) Handles btnBlankDB.Click

        If cmbInstallationType.SelectedIndex = 0 Then
            ValidateServerDetails()
            ConfigureSqlConnection()
            If ConfirmDatabaseCreation() Then
                SaveSqlSettings()
                CreateBlankDB()
                ShowSuccessMessage("DB has been created and SQL Server setting has been saved successfully. Application will be closed. Please start it again.")
                End
            End If
        ElseIf cmbInstallationType.SelectedIndex = 1 Then
            ValidateServerDetails()
            ConfigureSqlConnection()
            If ConfirmSqlServerConfiguration() Then
                SaveSqlSettings()
                ShowSuccessMessage("SQL Server setting has been saved successfully. Application will be closed. Please start it again.")
                End
            End If
        End If
    End Sub

    Private Sub CreateBlankDB()
        Try
            Using con As New SqlConnection("Data Source=" & cmbServerName.Text & ";Initial Catalog=master;Integrated Security=True;MultipleActiveResultSets=True")
                con.Open()
                DropExistingDatabase(con, "STUDENT_DATA_DB")
                CreateNewDatabase(con, "STUDENT_DATA_DB")
                ExecuteDatabaseScript(con, Application.StartupPath & "\BlankDBscript.sql")
            End Using
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try
    End Sub

    Private Sub frmSqlServerSetting_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Reset()
    End Sub

    Private Sub cmbInstallationType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbInstallationType.SelectedIndexChanged
        If cmbInstallationType.SelectedIndex = 1 Then
            cmbAuthentication.SelectedIndex = 1
            cmbAuthentication.Enabled = False
            btnTestConnection.Visible = True
            btnSearchServers.Visible = False
            btnBlankDB.Visible = False
            btnDemoDB.Text = "Save Setting"
        ElseIf cmbInstallationType.SelectedIndex = 0 Then
            cmbAuthentication.SelectedIndex = 0
            cmbAuthentication.Enabled = True
            btnTestConnection.Visible = True
            btnSearchServers.Visible = True
            btnBlankDB.Visible = True
            btnDemoDB.Text = "Create DB and Proceed"
        End If
    End Sub

    Private Sub Timer5_Tick(sender As Object, e As EventArgs) Handles Timer5.Tick
        Cursor = Cursors.Default
        Timer5.Enabled = False
    End Sub

    Private Sub Button1_Click_1(sender As System.Object, e As System.EventArgs) Handles btnSearchServers.Click
        If CheckBox1.Checked = False Then
            Try
                Cursor = Cursors.WaitCursor
                Timer5.Enabled = True
                Dim dataTable As DataTable = SmoApplication.EnumAvailableSqlServers(True)
                cmbServerName.ValueMember = "Name"
                cmbServerName.DataSource = dataTable
                Dim serverName As String = cmbServerName.SelectedValue.ToString()
                Dim server As New Server(serverName)
            Catch ex As Exception
                MetroMessageBox.Show(Me, "Sorry unable to find SQL Server instance" & vbCrLf & "If you have installed SQL Server then enter name of SQL Server instance manually", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Try
        Else
            Try
                ' Use SqlDataSourceEnumerator to enumerate available SQL Servers
                Dim serverList As DataTable = SqlDataSourceEnumerator.Instance.GetDataSources()
                Dim servers As New List(Of String)()
                For Each row As DataRow In serverList.Rows
                    Dim serverName As String = row("ServerName").ToString()
                    Dim instanceName As String = row("InstanceName").ToString()
                    If String.IsNullOrEmpty(instanceName) Then
                        servers.Add(serverName)
                    Else
                        servers.Add(serverName & "\" & instanceName)
                    End If
                Next
                cmbServerName.DataSource = servers
            Catch ex1 As Exception
                ' Handle any exceptions here
                MetroMessageBox.Show(Me, "Sorry unable to find SQL Server instance" & vbCrLf & $"If you have installed SQL Server then enter name of SQL Server instance manually{vbCrLf}{ex1.ToString()}", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Try
        End If
    End Sub

    ' Helper Methods
    Private Sub ValidateServerDetails()
        If String.IsNullOrEmpty(cmbServerName.Text) Then
            MsgBox("Please select/enter Server Name", MsgBoxStyle.Information)
            cmbServerName.Focus()
            Exit Sub
        End If
        If cmbAuthentication.SelectedIndex = 1 Then
            If String.IsNullOrEmpty(txtUserName.Text) Then
                MsgBox("Please enter user name", MsgBoxStyle.Information)
                txtUserName.Focus()
                Exit Sub
            End If
            If String.IsNullOrEmpty(txtPassword.Text) Then
                MsgBox("Please enter password", MsgBoxStyle.Information)
                txtPassword.Focus()
                Exit Sub
            End If
        End If
    End Sub

    Private Sub ConfigureSqlConnection()
        If cmbAuthentication.SelectedIndex = 0 Then
            SqlConnStr = "Data Source=" & cmbServerName.Text.Trim & ";Initial Catalog=master;Integrated Security=True;MultipleActiveResultSets=True"
        ElseIf cmbAuthentication.SelectedIndex = 1 Then
            SqlConnStr = "Data Source=" & cmbServerName.Text.Trim & ";Initial Catalog=master;User ID=" & txtUserName.Text.Trim & ";Password=" & txtPassword.Text & ";MultipleActiveResultSets=True"
        End If
    End Sub

    Private Function ConfirmDatabaseCreation() As Boolean
        Return MsgBox("It will create the DB and configure the SQL Server. Do you want to proceed?", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes
    End Function

    Private Function ConfirmSqlServerConfiguration() As Boolean
        Return MsgBox("It will configure the SQL Server. Do you want to proceed?", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes
    End Function

    Private Function ConfirmCloseApplication() As Boolean
        Return MsgBox("Do you want to close the application?", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes
    End Function

    Private Sub SaveSqlSettings()
        Dim destpath As String = Application.StartupPath & "\SQLSettings.dat"
        Using sw As New StreamWriter(destpath)
            If cmbAuthentication.SelectedIndex = 0 Then
                sw.WriteLine("Data Source=" & cmbServerName.Text.Trim & ";Initial Catalog=STUDENT_DATA_DB;Integrated Security=True;MultipleActiveResultSets=True")
            ElseIf cmbAuthentication.SelectedIndex = 1 Then
                sw.WriteLine("Data Source=" & cmbServerName.Text.Trim & ";Initial Catalog=STUDENT_DATA_DB;User ID=" & txtUserName.Text.Trim & ";Password=" & txtPassword.Text & ";MultipleActiveResultSets=True")
            End If
        End Using
    End Sub
    Private Sub DropExistingDatabase(con As SqlConnection, dbName As String)
        Dim backupFolderPath As String = "C:\db_backup"
        Dim queryCheckDb As String = "If exists (select name from master.dbo.sysdatabases where name = @dbName) select 1 else select 0"

        Try
            Using cmdCheck As New SqlCommand(queryCheckDb, con)
                cmdCheck.Parameters.AddWithValue("@dbName", dbName)
                If Convert.ToInt32(cmdCheck.ExecuteScalar()) = 1 Then
                    If Not Directory.Exists(backupFolderPath) Then
                        Directory.CreateDirectory(backupFolderPath)
                    End If
                    Dim backupFilePath As String = Path.Combine(backupFolderPath, dbName & "_backup_" & DateTime.Now.ToString("yyyyMMddHHmmss") & ".bak")
                    Dim queryBackup As String = "BACKUP DATABASE [" & dbName & "] TO DISK = @backupFilePath"
                    Using cmdBackup As New SqlCommand(queryBackup, con)
                        cmdBackup.Parameters.AddWithValue("@backupFilePath", backupFilePath)
                        cmdBackup.ExecuteNonQuery()
                    End Using

                    ' Set the database to single-user mode to disconnect users
                    Dim querySingleUser As String = "ALTER DATABASE [" & dbName & "] SET SINGLE_USER WITH ROLLBACK IMMEDIATE"
                    Using cmdSingleUser As New SqlCommand(querySingleUser, con)
                        cmdSingleUser.ExecuteNonQuery()
                    End Using

                    ' Drop the database
                    Dim queryDrop As String = "DROP DATABASE [" & dbName & "]"
                    Using cmdDrop As New SqlCommand(queryDrop, con)
                        cmdDrop.ExecuteNonQuery()
                    End Using
                End If
            End Using
        Catch ex As Exception
            ShowErrorMessage("Error in dropping existing database: " & ex.Message)
        End Try
    End Sub

    Private Sub CreateNewDatabase(con As SqlConnection, dbName As String)
        Dim query As String = "CREATE DATABASE [" & dbName & "]"
        Using cmd As New SqlCommand(query, con)
            cmd.ExecuteNonQuery()
        End Using
    End Sub

    Private Sub ExecuteDatabaseScript(con As SqlConnection, scriptPath As String)
        Dim script As String = File.ReadAllText(scriptPath)
        Try
            Dim conString As String = "Data Source=" & cmbServerName.Text & ";Initial Catalog=master;Integrated Security=True;MultipleActiveResultSets=True"
            Using con1 As New SqlConnection(conString)
                con1.Open()
                Dim cb2 As String = "SELECT * FROM sys.databases WHERE name='STUDENT_DATA_DB'"
                Using cmd As New SqlCommand(cb2, con1)
                    Using rdr As SqlDataReader = cmd.ExecuteReader()
                        If rdr.Read() Then
                            Dim cb1 As String = "USE Master ALTER DATABASE STUDENT_DATA_DB SET Single_User WITH Rollback Immediate DROP DATABASE STUDENT_DATA_DB"
                            Using cmdDrop As New SqlCommand(cb1, con)
                                cmdDrop.ExecuteNonQuery()
                            End Using
                        End If
                    End Using
                End Using
                Dim cb3 As String = "CREATE DATABASE STUDENT_DATA_DB"
                Using cmdCreateDB As New SqlCommand(cb3, con)
                    cmdCreateDB.ExecuteNonQuery()
                End Using
                Using sr As New StreamReader(Application.StartupPath & "\BlankDBscript.sql")
                    Dim st As String = sr.ReadToEnd()
                    Dim server As New Microsoft.SqlServer.Management.Smo.Server(New Microsoft.SqlServer.Management.Common.ServerConnection(con))
                    server.ConnectionContext.ExecuteNonQuery(st)
                End Using
            End Using
        Catch ex As Exception
            MetroMessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ExecuteDatabaseScriptWithGO(con As SqlConnection, scriptPath As String)
        Dim script As String = File.ReadAllText(scriptPath)
        Dim server As New Server(New ServerConnection(con))
        server.ConnectionContext.ExecuteNonQuery(script)
    End Sub

    Private Sub ShowSuccessMessage(message As String)
        MessageBox.Show(message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub ShowErrorMessage(message As String)
        MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    Private Sub btnConnect_Click(sender As Object, e As EventArgs) Handles btnConnect.Click
        Using sw As StreamWriter = New StreamWriter(Application.StartupPath & "\SQLSettings.dat")
            If cmbAuthentication.SelectedIndex = 0 Then
                sw.WriteLine("Data Source=" & cmbServerName.Text.Trim & ";Initial Catalog=STUDENT_DATA_DB;Integrated Security=True;MultipleActiveResultSets=True")
                sw.Close()
            End If
            If cmbAuthentication.SelectedIndex = 1 Then
                sw.WriteLine("Data Source=" & cmbServerName.Text.Trim & ";Initial Catalog=STUDENT_DATA_DB;User ID=" & txtUserName.Text.Trim & ";Password=" & txtPassword.Text & ";MultipleActiveResultSets=True")
                sw.Close()
            End If

            MetroMessageBox.Show(Me, "SQL Server setting has been connected" & vbCrLf & "Application will be closed,Please start it again", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End
        End Using
        Application.Exit()
    End Sub

End Class
