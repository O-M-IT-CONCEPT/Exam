Imports System.Data.SqlClient

Public Class Form17
    Private Sub MENUToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MENUToolStripMenuItem.Click
        Me.Dispose()
        Form2.Show()
    End Sub
    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        ComboBox2.Items.Clear()
        ComboBox2.Text = "Select"
        With ComboBox2.Items
            If ComboBox1.Text = "Applied Science and Tech." Then
                .Add("Computer Science")
                .Add("Food Technology")
                .Add("Maths & Statistic")
                .Add("Science Lab. Tech.")
            ElseIf ComboBox1.Text = "Comm. & Info. Tech." Then
                .Add("Library & Info Science")
                .Add("Mass Communication")
                .Add("Office Tech. & Mgt.")
            ElseIf ComboBox1.Text = "Bus. & Management Studies" Then
                .Add("Accountancy")
                .Add("Banking & Finance")
                .Add("Bus. Admin")
                .Add("Insurance")
                .Add("Marketing")
            ElseIf ComboBox1.Text = "Engineering & Technology" Then
                .Add("Civil Engineering")
                .Add("Computer Technology")
                .Add("Elect/Elect Engineering")
                .Add("Mechanical Engineering")
            ElseIf ComboBox1.Text = "Environmental Studies" Then
                .Add("Architecture/Tech")
                .Add("Building Tech")
                .Add("Estate Mgt")
                .Add("Quantity Surveying")
                .Add("Urban & Reg Planning")
            End If
        End With
    End Sub

    Dim mat, sur, fir, las, sex, fac, dep, lev, pas As String

    Private Sub ComboBox5_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox5.SelectedIndexChanged
        Dim con As String
        Dim sql As String
        Dim dt As DataTable

        Try
            sql = "SELECT * FROM ttable WHERE clevel = @CLevel AND csemester = @CSemester AND ccode = @CCode"

            ' Create SQL parameters
            Dim sqlParams As New List(Of SqlParameter) From {
            New SqlParameter("@CLevel", ComboBox3.Text & ComboBox7.Text),
            New SqlParameter("@CSemester", ComboBox4.Text),
            New SqlParameter("@CCode", ComboBox5.Text)
        }

            ' Execute the query using the Crud function
            dt = Crud(sql, sqlParams)

            ' Check if there are any results
            If dt.Rows.Count > 0 Then
                Dim row As DataRow = dt.Rows(0) ' Get the first row

                ' Populate text boxes and labels
                TextBox3.Text = row("ctitle").ToString()
                TextBox1.Text = row("cunit").ToString()
                lblday.Text = row("datee").ToString()
                Dim timee As String = row("timee").ToString()
                Lstart.Text = Mid(timee, 1, 5)
                lblstop.Text = Mid(timee, 9, 5)
            Else
                ' Clear fields if no data is found (optional)
                TextBox3.Clear()
                TextBox1.Clear()
                lblday.Text = ""
                Lstart.Text = ""
                lblstop.Text = ""
            End If
        Catch ex As Exception
            MessageBox.Show("An error occurred: " & ex.Message)
        End Try
    End Sub
    Public Sub CheckByPrint()
        Dim sql As String
        Dim dt As DataTable

        Try
            ' SQL query with parameterization
            sql = "SELECT * FROM student WHERE PrintID1 = @PrintID OR PrintID2 = @PrintID OR PrintID3 = @PrintID OR PrintID4 = @PrintID"

            ' Create SQL parameters
            Dim sqlParams As New List(Of SqlParameter) From {
            New SqlParameter("@PrintID", GlobalVar.GlobalID)
        }

            ' Execute the query using the Crud function
            dt = Crud(sql, sqlParams)

            If dt.Rows.Count = 0 Then
                Exit Sub ' Exit if no records found
            End If

            ' Populate Form18 with data from the first row
            Dim row As DataRow = dt.Rows(0)
            mat = row("stid").ToString()
            las = row("fnam").ToString()
            sex = row("mstatus").ToString()
            fac = row("lev").ToString()
            dep = row("dept").ToString()

            ' Load the picture from file
            Form18.PictureBox1.Image = Image.FromFile("pic/" & row("pic").ToString())

            ' Populate text fields
            Form18.TextBox1.Text = mat
            Form18.txtfullname.Text = las
            Form18.txtdept.Text = dep

            Form18.Show()

            ' Clear the GlobalID variable
            GlobalVar.GlobalID = ""
        Catch ex As Exception
            MessageBox.Show("An error occurred: " & ex.Message)
        End Try
    End Sub

    Private Sub ComboBox4_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox4.SelectedIndexChanged
        Dim sql As String
        Dim dt As DataTable

        Try
            ' SQL query with parameterization
            sql = "SELECT * FROM course WHERE clevel = @CLevel AND csemester = @CSemester"

            ' Create SQL parameters
            Dim sqlParams As New List(Of SqlParameter) From {
            New SqlParameter("@CLevel", ComboBox3.Text),
            New SqlParameter("@CSemester", ComboBox4.Text)
        }

            ' Execute the query using the Crud function
            dt = Crud(sql, sqlParams)

            ' Clear previous items
            ComboBox5.Items.Clear()

            ' Populate ComboBox5 with course codes
            For Each row As DataRow In dt.Rows
                ComboBox5.Items.Add(row("ccode").ToString())
            Next
        Catch ex As Exception
            MessageBox.Show("An error occurred: " & ex.Message)
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        ComboBox1.Text = "Select"
        ComboBox2.Text = "Select"
        ComboBox3.Text = "Select"
        ComboBox4.Text = "Select"
        ComboBox5.Text = "Select"
        TextBox1.Clear()
        TextBox3.Clear()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If ComboBox6.Text = "Biometric" Then
            frmCapture.lblId.Text = "Search"
            frmCapture.Show()
            Form18.Label1.Visible = False
            Form18.TextBox1.Visible = False
            Form18.Button2.Visible = False
        ElseIf ComboBox6.Text = "Matric No." Then
            Form18.Show()
            Form18.Label1.Visible = True
            Form18.TextBox1.Visible = True
            Form18.Button2.Visible = True
        End If
    End Sub
    Private Sub Form17_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        CheckByPrint()
    End Sub
End Class