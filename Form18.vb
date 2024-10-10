Imports System.Data.SqlClient

Public Class Form18
    Dim mat, sur, fir, las, sex, fac, dep As String

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim stim, etim As Integer
        Dim sdat, edat As String
        Dim dayy, dayy1 As String

        sdat = (Form17.Lstart.Text)
        edat = (Form17.lblstop.Text)
        dayy = Form17.lblday.Text
        stim = DateDiff(DateInterval.Minute, TimeOfDay, CDate(sdat))
        etim = DateDiff(DateInterval.Minute, TimeOfDay, CDate(edat))
        dayy1 = Today.ToString("d") ' Format today to match the date format

        If (stim <= 0) And (etim >= 0) And dayy = dayy1 Then
            Dim sql As String
            Dim dt As DataTable

            Try
                ' Check if attendance already exists
                sql = "SELECT * FROM atten WHERE mat = @Mat AND dat = @Today AND ccod = @CCode"

                Dim sqlParams As New List(Of SqlParameter) From {
                New SqlParameter("@Mat", TextBox1.Text),
                New SqlParameter("@Today", Today.ToString("d")),
                New SqlParameter("@CCode", Form17.ComboBox5.Text)
            }

                dt = Crud(sql, sqlParams)

                If dt.Rows.Count = 0 Then
                    ' Insert new attendance record
                    sql = "INSERT INTO atten (mat, fullname, dep, lev, sem, ccod, ctit, dat, tim, bookid) VALUES (@Mat, @FullName, @Dep, @Lev, @Sem, @CCode, @CTitle, @Date, @Time, @BookID)"

                    Dim insertParams As New List(Of SqlParameter) From {
                    New SqlParameter("@Mat", TextBox1.Text),
                    New SqlParameter("@FullName", txtfullname.Text),
                    New SqlParameter("@Dep", txtdept.Text),
                    New SqlParameter("@Lev", Form17.ComboBox3.Text),
                    New SqlParameter("@Sem", Form17.ComboBox4.Text),
                    New SqlParameter("@CCode", Form17.ComboBox5.Text),
                    New SqlParameter("@CTitle", Form17.TextBox3.Text),
                    New SqlParameter("@Date", Today.ToString("d")),
                    New SqlParameter("@Time", DateTime.Now),
                    New SqlParameter("@BookID", TextBox2.Text)
                }

                    Crud(sql, insertParams) ' Call Crud to execute the insert
                    MsgBox("Information saved successfully", vbInformation, "ONLINE ATTENDANCE")
                    Me.Hide()
                    TextBox1.Clear()
                    PictureBox1.Image = Nothing
                Else
                    MsgBox("ATTENDANCE ALREADY EXISTS", vbCritical, "ONLINE ATTENDANCE")
                End If
            Catch ex As Exception
                MessageBox.Show("An error occurred: " & ex.Message)
            End Try
        Else
            MsgBox("NO COURSE FOUND FOR THIS PERIOD", vbCritical, "ONLINE ATTENDANCE")
        End If
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim sql As String
        Dim dt As DataTable

        Try
            ' SQL query to select student information
            sql = "SELECT * FROM student WHERE mat = @Mat"

            Dim sqlParams As New List(Of SqlParameter) From {
            New SqlParameter("@Mat", TextBox1.Text)
        }

            ' Execute the query using the Crud function
            dt = Crud(sql, sqlParams)

            If dt.Rows.Count = 0 Then
                MsgBox("Student Expel/Withdrawal Information not Found", vbCritical, "Record Not Found")
                Exit Sub
            End If

            ' Populate fields with data from the first row
            Dim row As DataRow = dt.Rows(0)
            mat = row("stid").ToString()
            las = row("fnam").ToString()
            sex = row("mstatus").ToString()
            fac = row("lev").ToString()
            dep = row("dept").ToString()

            ' Load the picture from file
            PictureBox1.Image = Image.FromFile("pic/" & row("pic").ToString())
            txtfullname.Text = las
            txtdept.Text = dep
        Catch ex As Exception
            MessageBox.Show("An error occurred: " & ex.Message)
        End Try
    End Sub

End Class