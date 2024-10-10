Imports System.Data.SqlClient

Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim sql As String
        Dim sqlParameters As New List(Of SqlParameter)

        ' Determine the SQL query based on the selected user type
        If ComboBox1.Text = "Admin" Then
            sql = "SELECT * FROM adminn WHERE mail=@mail AND pswd=@pswd"
        ElseIf ComboBox1.Text = "Staff" Then
            sql = "SELECT * FROM staff WHERE mail=@mail AND pswd=@pswd"
        Else
            MsgBox("Please Select UserType", vbCritical, "EXAMINATION MALPRACTICE")
            Exit Sub
        End If
        ' Add parameters to prevent SQL injection
        sqlParameters.Add(New SqlParameter("@mail", TextBox1.Text))
        sqlParameters.Add(New SqlParameter("@pswd", TextBox2.Text))

        ' Execute the query using the Crud function and get the result in a DataTable
        Dim dt As DataTable = Crud(sql, sqlParameters)

        ' Check if any rows were returned
        If dt.Rows.Count > 0 Then
            If ComboBox1.Text = "Admin" Then
                Form2.lblname.Text = dt.Rows(0)("fnam").ToString()
                Form2.PictureBox1.Image = Image.FromFile(Application.StartupPath & "\pic\" & dt.Rows(0)("pic").ToString())
                Me.Hide()
                Form2.Show()
            ElseIf ComboBox1.Text = "Staff" Then
                Form9.lblname.Text = dt.Rows(0)("Lect").ToString()
                Form9.PictureBox1.Image = Image.FromFile(Application.StartupPath & "\pic\" & dt.Rows(0)("pic").ToString())
                Me.Hide()
                Form9.Show()
            End If
        Else
            MsgBox("Invalid Details", vbCritical, "EXAMINATION MALPRACTICE")
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        End
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Hide()
        Form17.Show()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not System.IO.File.Exists(Application.StartupPath & "\SQLSettings.dat") Or Not CheckAndWriteHardwareID() Then
            frmSqlServerSetting.ShowDialog()
            Me.Dispose()
        End If
    End Sub
End Class
