Imports System.Data.SqlClient

Public Class Form19
    Private Sub Form19_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim sql As String
        Dim dt As DataTable

        Try
            sql = "SELECT * FROM student WHERE stid = @StId AND sess = @Session"

            Dim sqlParams As New List(Of SqlParameter) From {
            New SqlParameter("@StId", Form16.TextBox1.Text),
            New SqlParameter("@Session", Form16.ComboBox1.Text)
        }

            dt = Crud(sql, sqlParams)

            If dt.Rows.Count > 0 Then
                Dim row As DataRow = dt.Rows(0)
                lblfname.Text = row("fnam").ToString()
                lblmatric.Text = row("stid").ToString()
                lbldept.Text = row("dept").ToString()
                lblprog.Text = row("prog").ToString()
                lblsess.Text = row("sess").ToString()
                lbllevel.Text = row("lev").ToString()
                PictureBox1.Image = Image.FromFile(Application.StartupPath & "\pic\" & row("pic").ToString())
            End If
        Catch ex As Exception
            MessageBox.Show("An error occurred: " & ex.Message)
        End Try

        course()
    End Sub
    Private Sub course()
        Dim matval As String = Form16.TextBox1.Text
        Dim mat As Integer = 0

        ' Get the numerical part of the matriculation number
        If matval.Length = 15 Then
            mat = Val(Mid(matval, 12, 4))
        ElseIf matval.Length = 14 Then
            mat = Val(Mid(matval, 11, 4))
        End If

        Dim sql As String
        Dim dt As DataTable
        Dim sn As Integer = 1

        Try
            sql = "SELECT * FROM ttable WHERE sess = @Session AND clevel = @CLevel AND csemester = @CSemester AND mstart <= @Mat AND mstop >= @Mat"

            Dim sqlParams As New List(Of SqlParameter) From {
            New SqlParameter("@Session", Form16.ComboBox1.Text),
            New SqlParameter("@CLevel", lbllevel.Text & lblprog.Text),
            New SqlParameter("@CSemester", Form16.ComboBox4.Text),
            New SqlParameter("@Mat", mat)
        }

            dt = Crud(sql, sqlParams)

            For Each row As DataRow In dt.Rows
                Dim str(5) As String
                str(0) = sn.ToString()
                str(1) = row("ccode").ToString()
                str(2) = row("ctitle").ToString()
                str(3) = row("venue").ToString()
                str(4) = row("datee").ToString()
                str(5) = row("timee").ToString()

                Dim itm As New ListViewItem(str)
                ListView1.Items.Add(itm)
                sn += 1
            Next
        Catch ex As Exception
            MessageBox.Show("An error occurred: " & ex.Message)
        End Try
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Me.Hide()
        Form9.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        PrintDocument1.Print()
    End Sub


End Class