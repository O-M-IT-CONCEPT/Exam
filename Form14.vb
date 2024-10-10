Imports System.ComponentModel
Imports System.Data.SqlClient

Public Class Form14
    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged
        Dim level As String = TextBox3.Text
        Dim semester As String = ComboBox1.Text
        Dim sql As String = ""

        ' Determine the SQL query based on the level
        If level = "HND1" OrElse level = "ND1" Then
            sql = "SELECT ccode, ctitle, cunit FROM course WHERE clevel=@clevel AND csemester=@csemester"
        ElseIf level = "HND2" Then
            sql = "SELECT ccode, ctitle, cunit FROM course WHERE (clevel='HND2' OR clevel='HND1') AND csemester=@csemester"
        ElseIf level = "ND2" Then
            sql = "SELECT ccode, ctitle, cunit FROM course WHERE (clevel='ND2' OR clevel='ND1') AND csemester=@csemester"
        End If

        ' If no valid level, exit the function
        If sql = "" Then
            Exit Sub
        End If

        ' Clear existing rows in DataGridView
        DataGridView1.Rows.Clear()

        ' Prepare parameters for SQL query
        Dim sqlParameters As New List(Of SqlParameter) From {
        New SqlParameter("@clevel", level),
        New SqlParameter("@csemester", semester)
    }

        ' Execute the query using the Crud function
        Dim dt As DataTable = Crud(sql, sqlParameters)

        ' Populate the DataGridView with results
        For Each row As DataRow In dt.Rows
            Dim rowNum As Integer = DataGridView1.Rows.Add()
            DataGridView1.Rows.Item(rowNum).Cells(0).Value = row("ccode").ToString()
            DataGridView1.Rows.Item(rowNum).Cells(1).Value = row("ctitle").ToString()
            DataGridView1.Rows.Item(rowNum).Cells(2).Value = row("cunit").ToString()
        Next
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        ' SQL query to fetch student information based on stid and session
        Dim sql As String = "SELECT fnam, dept, lev, pic FROM student WHERE stid = @stid AND sess = @sess"

        ' Prepare the parameters
        Dim sqlParameters As New List(Of SqlParameter) From {
        New SqlParameter("@stid", TextBox1.Text),
        New SqlParameter("@sess", ComboBox8.Text)
    }

        ' Execute the query using the Crud function
        Dim dt As DataTable = Crud(sql, sqlParameters)

        ' Check if any record was found
        If dt.Rows.Count > 0 Then
            ' Populate text boxes with student information
            TextBox2.Text = dt.Rows(0)("fnam").ToString()
            TextBox4.Text = dt.Rows(0)("dept").ToString()
            TextBox3.Text = dt.Rows(0)("lev").ToString()

            ' Load the student's picture from file
            Dim picPath As String = Application.StartupPath & "\pic\" & dt.Rows(0)("pic").ToString()
            If IO.File.Exists(picPath) Then
                PictureBox1.Image = Image.FromFile(picPath)
            Else
                PictureBox1.Image = Nothing
                MsgBox("Picture not found.", MsgBoxStyle.Information, "EXAM")
            End If
        Else
            ' Show message if no record was found
            MsgBox("NO RECORD FOUND", MsgBoxStyle.Critical, "EXAM")
        End If
    End Sub

    Private Sub registeredcourse()
        ' Define the SQL query to fetch registered courses for the student
        Dim sql As String = "SELECT ccode, ctitle, cunit FROM creg WHERE sid = @sid AND csemester = @csemester AND sess = @sess AND clevel = @clevel"

        ' Create parameters for the SQL query
        Dim sqlParameters As New List(Of SqlParameter) From {
        New SqlParameter("@sid", TextBox1.Text),
        New SqlParameter("@csemester", ComboBox1.Text),
        New SqlParameter("@sess", ComboBox8.Text),
        New SqlParameter("@clevel", TextBox3.Text)
    }

        ' Execute the query using the Crud function and get the result in a DataTable
        Dim dt As DataTable = Crud(sql, sqlParameters)

        ' Clear any previous rows in the DataGridView
        DataGridView2.Rows.Clear()

        ' Loop through the DataTable and add rows to the DataGridView
        For Each row As DataRow In dt.Rows
            Dim rowNum As Integer = DataGridView2.Rows.Add()
            DataGridView2.Rows.Item(rowNum).Cells(0).Value = row("ccode").ToString()
            DataGridView2.Rows.Item(rowNum).Cells(1).Value = row("ctitle").ToString()
            DataGridView2.Rows.Item(rowNum).Cells(2).Value = row("cunit").ToString()
        Next
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim sql As String = ""
        Dim sqlParams As New List(Of SqlParameter)

        If ComboBox1.Text = "Admin" Then
            sql = "SELECT * FROM adminn WHERE mail=@Mail AND pswd=@Pswd"
            sqlParams.Add(New SqlParameter("@Mail", TextBox1.Text))
            sqlParams.Add(New SqlParameter("@Pswd", TextBox2.Text))
        ElseIf ComboBox1.Text = "Staff" Then
            sql = "SELECT * FROM staff WHERE mail=@Mail AND pswd=@Pswd"
            sqlParams.Add(New SqlParameter("@Mail", TextBox1.Text))
            sqlParams.Add(New SqlParameter("@Pswd", TextBox2.Text))
        Else
            MsgBox("Please Select UserType", vbCritical, "EXAMINATION MALPRACTICE")
            Return
        End If
        Dim result As DataTable = Crud(sql, sqlParams)
        If result.Rows.Count > 0 Then
            Dim userRow As DataRow = result.Rows(0) ' Get the first row
            If ComboBox1.Text = "Admin" Then
                Form2.lblname.Text = userRow("fnam").ToString()
                Form2.PictureBox1.Image = Image.FromFile(Application.StartupPath & "\pic\" & userRow("pic").ToString())
                Me.Hide()
                Form2.Show()
            ElseIf ComboBox1.Text = "Staff" Then
                Form9.lblname.Text = userRow("Lect").ToString()
                Form9.PictureBox1.Image = Image.FromFile(Application.StartupPath & "\pic\" & userRow("pic").ToString())
                Me.Hide()
                Form9.Show()
            End If
        Else
            MsgBox("Invalid Details", vbCritical, "EXAMINATION MALPRACTICE")
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim sql As String
        Dim sqlParams As New List(Of SqlParameter)
        Dim rowNum As Integer = DataGridView2.Rows.Count - 1

        For a As Integer = 0 To rowNum
            Dim check As Boolean = Convert.ToBoolean(DataGridView2.Rows(a).Cells(3).Value)

            If check = True Then
                sql = "DELETE FROM creg WHERE sid=@Sid AND csemester=@Semester AND sess=@Sess AND clevel=@Level"
                sqlParams.Clear() ' Clear parameters for each row

                ' Add parameters for the current row
                sqlParams.Add(New SqlParameter("@Sid", TextBox1.Text))
                sqlParams.Add(New SqlParameter("@Semester", ComboBox1.Text))
                sqlParams.Add(New SqlParameter("@Sess", ComboBox8.Text))
                sqlParams.Add(New SqlParameter("@Level", TextBox3.Text))

                ' Execute the delete operation using the Crud function
                Crud(sql, sqlParams)
            End If
        Next a

        ' Clear DataGridView and refresh the registered courses
        DataGridView2.Rows.Clear()
        registeredcourse()

        MsgBox("COURSE SUCCESSFULLY REMOVED", MsgBoxStyle.Information, "EXAM")
    End Sub

    Private Sub Form14_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Form9.Show()
        Me.Hide()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Hide()
        Form9.Show()
    End Sub
End Class