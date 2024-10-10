Imports System.Data.SqlClient

Public Class Form12

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        Form9.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' SQL Update query
        Dim sql As String = "UPDATE course SET ccode=@ccode, cunit=@cunit, csemester=@csemester, clevel=@clevel, cdept=@cdept WHERE ctitle=@ctitle"

        ' Parameters for the SQL query
        Dim sqlParameters As New List(Of SqlParameter) From {
            New SqlParameter("@ccode", TextBox1.Text),
            New SqlParameter("@cunit", TextBox2.Text),
            New SqlParameter("@csemester", ComboBox1.Text),
            New SqlParameter("@clevel", ComboBox6.Text),
            New SqlParameter("@cdept", ComboBox7.Text),
            New SqlParameter("@ctitle", ComboBox2.Text)
        }

        ' Execute the update using the Crud function
        Crud(sql, sqlParameters)

        MsgBox("Success", MsgBoxStyle.Information, "EXAM")

        ' Clear fields after successful update
        TextBox1.Clear()
        TextBox2.Clear()
        ComboBox1.Text = "Select"
        ComboBox6.Text = "Select"
        ComboBox7.Text = "Select"
    End Sub
    Private Sub Form12_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim sql As String = "SELECT ctitle FROM course"

        Dim dt As DataTable = Crud(sql, Nothing)
        For Each row As DataRow In dt.Rows
            ComboBox2.Items.Add(row("ctitle").ToString())
        Next
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        ' SQL Select query to get course details based on selected course title
        Dim sql As String = "SELECT ccode, cunit, csemester, clevel, cdept FROM course WHERE ctitle=@ctitle"

        ' Parameter for the SQL query
        Dim sqlParameters As New List(Of SqlParameter) From {
        New SqlParameter("@ctitle", ComboBox2.Text)
    }

        ' Execute the select query using the Crud function
        Dim dt As DataTable = Crud(sql, sqlParameters)

        ' Populate fields with the selected course details
        If dt.Rows.Count > 0 Then
            Dim row As DataRow = dt.Rows(0)
            TextBox1.Text = row("ccode").ToString()
            TextBox2.Text = row("cunit").ToString()
            ComboBox1.Text = row("csemester").ToString()
            ComboBox6.Text = row("clevel").ToString()
            ComboBox7.Text = row("cdept").ToString()
        End If
    End Sub

End Class