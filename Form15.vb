Imports System.Data.SqlClient

Public Class Form15
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        loadmatric()
        displaycourse()
        loadvenue()
        '   additems()
    End Sub
    Dim lp, lr As Integer
    Dim lev, stat As String
    Private Sub course()
        Try
            Dim sql As String = "SELECT * FROM Venue"
            Dim sqlParams As New List(Of SqlParameter)

            ' Use the Crud function to get venue data
            Dim result As DataTable = Crud(sql, sqlParams)

            ' Clear ListBox before adding items
            lbvenue.Items.Clear()
            lbcapacity.Items.Clear()

            ' Loop through the DataTable and populate the ListBox
            For Each row As DataRow In result.Rows
                lbvenue.Items.Add(row("vnam").ToString())
                lbcapacity.Items.Add(row("capa").ToString())
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub displaycourse()
        Try
            DataGridView1.Rows.Clear()
            Dim sql As String
            Dim sqlParams As New List(Of SqlParameter)

            sql = "SELECT * FROM course WHERE clevel=@Clevel AND csemester=@CSemester"
            sqlParams.Add(New SqlParameter("@Clevel", ComboBox2.Text))
            sqlParams.Add(New SqlParameter("@CSemester", ComboBox4.Text))

            ' Use the Crud function to get course data
            Dim result As DataTable = Crud(sql, sqlParams)

            ' Loop through the DataTable and populate the DataGridView
            For Each row As DataRow In result.Rows
                Dim ccode As String = row("ccode").ToString()
                Dim ctitle As String = row("ctitle").ToString()
                Dim cunit As String = row("cunit").ToString()
                Dim clevel As String = row("clevel").ToString()
                griddisplay(ccode, ctitle, cunit, clevel)
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Function griddisplay(ccode As String, ctitle As String, cunit As String, clevel As String)

        Dim a As Integer
        For a = Val(TextBox1.Text) - 1 To Val(TextBox2.Text) Step 30
            Dim rowNum As Integer = DataGridView1.Rows.Add()
            DataGridView1.Rows.Item(rowNum).Cells(0).Value = ccode
            DataGridView1.Rows.Item(rowNum).Cells(1).Value = ctitle
            DataGridView1.Rows.Item(rowNum).Cells(2).Value = cunit
            DataGridView1.Rows.Item(rowNum).Cells(3).Value = clevel
            DataGridView1.Rows.Item(rowNum).Cells(4).Value = a + 1
            DataGridView1.Rows.Item(rowNum).Cells(5).Value = a + 30
            '  DataGridView1.Rows.Item(rowNum).Cells(6).Value = ''
            ' DataGridView1.Rows.Item(rowNum).Cells(7).Value = 'Select'
        Next
        If a > Val(TextBox2.Text) Then
            Dim rowNum As Integer = DataGridView1.Rows.Add()
            DataGridView1.Rows.Item(rowNum).Cells(0).Value = ccode
            DataGridView1.Rows.Item(rowNum).Cells(1).Value = ctitle
            DataGridView1.Rows.Item(rowNum).Cells(2).Value = cunit
            DataGridView1.Rows.Item(rowNum).Cells(3).Value = clevel
            DataGridView1.Rows.Item(rowNum).Cells(4).Value = DataGridView1.Rows.Item(rowNum - 1).Cells(5).Value + 1
            DataGridView1.Rows.Item(rowNum).Cells(5).Value = "Others"
            ' DataGridView1.Rows.Item(rowNum).Cells(6).ReadOnly = False
            ' DataGridView1.Rows.Item(rowNum).Cells(7).ReadOnly = False
        End If
    End Function

    Private Sub loadvenue()
        Try
            lbvenue.Items.Clear()
            lbcapacity.Items.Clear()

            Dim sql As String = "SELECT * FROM Venue"
            Dim sqlParams As New List(Of SqlParameter)

            ' Use the Crud function to get venue data
            Dim result As DataTable = Crud(sql, sqlParams)

            ' Populate ListBoxes with venue data
            For Each row As DataRow In result.Rows
                lbvenue.Items.Add(row("vnam").ToString())
                lbcapacity.Items.Add(row("capa").ToString())
            Next

            ' Populate DataGridView ComboBox cells with venue data
            For i As Integer = 0 To DataGridView1.RowCount - 1
                Dim comboBoxCell As New DataGridViewComboBoxCell
                For j As Integer = 0 To lbvenue.Items.Count - 1
                    comboBoxCell.Items.Add(lbvenue.Items(j))
                Next
                DataGridView1.Item(6, i) = comboBoxCell
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public minmat, maxmat, studentno As Integer
    Private Sub loadmatric()
        Try
            minmat = 9999
            maxmat = 0
            Dim sql As String
            Dim sqlParams As New List(Of SqlParameter)

            sql = "SELECT * FROM student WHERE sess=@Sess AND prog=@Prog AND lev=@Lev"
            sqlParams.Add(New SqlParameter("@Sess", ComboBox1.Text))
            sqlParams.Add(New SqlParameter("@Prog", ComboBox5.Text))
            sqlParams.Add(New SqlParameter("@Lev", ComboBox2.Text))

            ' Use the Crud function to get student data
            Dim result As DataTable = Crud(sql, sqlParams)

            ' Process each student record
            For Each row As DataRow In result.Rows
                Dim matval As String = row("stid").ToString()
                Dim matlen As Integer = matval.Length
                Dim mat As Integer

                If matlen = 15 Then
                    mat = Val(matval.Substring(11, 4)) ' Get the numeric part from the correct position
                ElseIf matlen = 14 Then
                    mat = Val(matval.Substring(10, 4)) ' Adjust position for 14-character matric number
                End If

                If mat < minmat Then
                    minmat = mat
                End If
                If mat > maxmat Then
                    maxmat = mat
                End If
            Next

            TextBox1.Text = minmat.ToString()
            TextBox2.Text = maxmat.ToString()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub loadmatric1()
        Try
            minmat = 9999
            maxmat = 0

            Dim sql As String = "SELECT * FROM student WHERE sess=@Sess AND prog=@Prog AND lev=@Lev"
            Dim sqlParams As New List(Of SqlParameter) From {
            New SqlParameter("@Sess", ComboBox1.Text),
            New SqlParameter("@Prog", ComboBox5.Text),
            New SqlParameter("@Lev", ComboBox2.Text)
        }

            ' Use the Crud function to get student data
            Dim result As DataTable = Crud(sql, sqlParams)

            ' Process each student record
            For Each row As DataRow In result.Rows
                Dim matval As String = row("stid").ToString()
                Dim getmatnum As String

                If matval.Length >= 12 Then
                    getmatnum = matval.Substring(11, 4) ' Extracts the number from the 12th character
                    Dim mat As Integer = Val(getmatnum)

                    If mat < minmat Then
                        minmat = mat
                    End If
                    If mat > maxmat Then
                        maxmat = mat
                    End If
                End If
            Next

            ' Uncomment these lines if you want to display min and max in TextBoxes
            ' TextBox1.Text = minmat.ToString()
            ' TextBox2.Text = maxmat.ToString()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Dim vnam As String

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        savetable()
    End Sub
    Private Sub updatedata()
        Try
            Dim sql As String = "INSERT INTO tablesta (semester, level, sess, prog, datee) VALUES (@Semester, @Level, @Sess, @Prog, @Datee)"
            Dim sqlParams As New List(Of SqlParameter) From {
            New SqlParameter("@Semester", ComboBox4.Text),
            New SqlParameter("@Level", ComboBox2.Text),
            New SqlParameter("@Sess", ComboBox1.Text),
            New SqlParameter("@Prog", ComboBox5.Text),
            New SqlParameter("@Datee", DateTime.Now) ' Use DateTime.Now for the current date
        }

            ' Use the Crud function to execute the INSERT command
            Crud(sql, sqlParams)

            ' Optionally, you can display a message or perform additional actions
            MessageBox.Show("Data updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Hide()
        '  Me.Dispose()
        Form2.Show()
    End Sub
    Private Sub savetable()
        Try
            Dim sql As String = "INSERT INTO ttable (ccode, ctitle, cunit, csemester, clevel, sess, venue, mstart, mstop, timee, datee) VALUES (@Ccode, @Ctitle, @Cunit, @CSemester, @CLevel, @Sess, @Venue, @MStart, @MStop, @Timee, @Datee)"

            Dim rowNum As Integer = DataGridView1.Rows.Count() - 1

            For a As Integer = 0 To rowNum
                If Not DataGridView1.Rows(a).IsNewRow Then ' Check if the row is not a new row
                    Dim sqlParams As New List(Of SqlParameter) From {
                    New SqlParameter("@Ccode", DataGridView1.Rows.Item(a).Cells(0).Value),
                    New SqlParameter("@Ctitle", DataGridView1.Rows.Item(a).Cells(1).Value),
                    New SqlParameter("@Cunit", DataGridView1.Rows.Item(a).Cells(2).Value),
                    New SqlParameter("@CSemester", ComboBox4.Text),
                    New SqlParameter("@CLevel", ComboBox2.Text & ComboBox5.Text),
                    New SqlParameter("@Sess", ComboBox1.Text),
                    New SqlParameter("@Venue", DataGridView1.Rows.Item(a).Cells(6).Value),
                    New SqlParameter("@MStart", DataGridView1.Rows.Item(a).Cells(4).Value),
                    New SqlParameter("@MStop", DataGridView1.Rows.Item(a).Cells(5).Value),
                    New SqlParameter("@Timee", DataGridView1.Rows.Item(a).Cells(7).Value),
                    New SqlParameter("@Datee", DataGridView1.Rows.Item(a).Cells(8).Value)
                }

                    ' Use the Crud function to execute the INSERT command
                    Crud(sql, sqlParams)
                End If
            Next a

            ' Call the updatedata method after all rows are saved
            updatedata()

            MsgBox("SUCCESS", MsgBoxStyle.Information, "EXAM")
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public sta As String
    Public Function readvenue(vnam As String, session As String, lev As String) As String
        Dim sta As String = "True" ' Default status is "True"
        Try
            Dim sql As String = "SELECT * FROM ttable WHERE sess = @Session AND venue = @Vnam AND clevel = @Level AND csemester = @CSemester"

            ' Create SQL parameters
            Dim sqlParams As New List(Of SqlParameter) From {
            New SqlParameter("@Session", session),
            New SqlParameter("@Vnam", vnam),
            New SqlParameter("@Level", lev),
            New SqlParameter("@CSemester", ComboBox4.Text)
        }

            ' Execute the query using the Crud function
            Dim dt As DataTable = Crud(sql, sqlParams)

            ' Check if the DataTable has any rows
            If dt.Rows.Count > 0 Then
                sta = "False" ' Venue exists
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Return sta
    End Function


    Private Sub Form15_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Form2.Show()
    End Sub
End Class