Imports System.Data.SqlClient

Public Class Form11

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Check if all required fields are filled
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox4.Text = "" Or ComboBox1.Text = "Select" Or ComboBox6.Text = "Select" Or ComboBox7.Text = "Select" Then
            MsgBox("All Fields are Required", MsgBoxStyle.Critical, "EXAM")
        Else
            ' Define the SQL query to check if the record already exists
            Dim checkSql As String = "SELECT COUNT(*) FROM course WHERE ctitle = @ctitle AND ccode = @ccode AND cunit = @cunit AND csemester = @csemester AND clevel = @clevel AND cdept = @cdept"
            Dim checkParameters As New List(Of SqlParameter) From {
            New SqlParameter("@ctitle", TextBox4.Text),
            New SqlParameter("@ccode", TextBox1.Text),
            New SqlParameter("@cunit", TextBox2.Text),
            New SqlParameter("@csemester", ComboBox1.Text),
            New SqlParameter("@clevel", ComboBox6.Text),
            New SqlParameter("@cdept", ComboBox7.Text)
        }

            ' Execute the check query using the Crud function and get the result in a DataTable
            Dim dt As DataTable = Crud(checkSql, checkParameters)

            ' Check if the record already exists
            If dt.Rows(0)(0) = 0 Then
                ' If not, insert the new record
                Dim insertSql As String = "INSERT INTO course (ctitle, ccode, cunit, csemester, clevel, cdept) VALUES (@ctitle, @ccode, @cunit, @csemester, @clevel, @cdept)"
                Dim insertParameters As New List(Of SqlParameter) From {
                New SqlParameter("@ctitle", TextBox4.Text),
                New SqlParameter("@ccode", TextBox1.Text),
                New SqlParameter("@cunit", TextBox2.Text),
                New SqlParameter("@csemester", ComboBox1.Text),
                New SqlParameter("@clevel", ComboBox6.Text),
                New SqlParameter("@cdept", ComboBox7.Text)
            }

                ' Execute the insert command using the Crud function
                Crud(insertSql, insertParameters)
                MsgBox("Success", MsgBoxStyle.Information, "EXAM")

                ' Clear the fields after successful insertion
                TextBox4.Clear()
                TextBox1.Clear()
                TextBox2.Clear()
                ComboBox1.Text = "Select"
                ComboBox6.Text = "Select"
                ComboBox7.Text = "Select"
            Else
                ' Record already exists
                MsgBox("Course Already Exists", MsgBoxStyle.Critical, "EXAM")
            End If
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Form9.Show()
        Me.Hide()
    End Sub


End Class