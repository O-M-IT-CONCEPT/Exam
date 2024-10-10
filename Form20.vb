Imports System.Data.SqlClient

Public Class Form20
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim sql As String
        Dim dt As DataTable
        Dim sqlParams As New List(Of SqlParameter)

        Try
            sql = "SELECT * FROM atten WHERE dep = @Dep AND lev = @Lev AND sem = @Sem AND ccod = @CCode"

            sqlParams.Add(New SqlParameter("@Dep", ComboBox3.Text))
            sqlParams.Add(New SqlParameter("@Lev", ComboBox2.Text))
            sqlParams.Add(New SqlParameter("@Sem", ComboBox4.Text))
            sqlParams.Add(New SqlParameter("@CCode", ComboBox1.Text))

            dt = Crud(sql, sqlParams)

            ListView1.Items.Clear() ' Clear existing items before adding new ones

            For Each row As DataRow In dt.Rows
                Dim str(6) As String
                str(0) = row("mat").ToString()
                str(1) = row("fullname").ToString()
                str(2) = row("dep").ToString()
                str(3) = row("ccod").ToString()
                str(4) = row("ctit").ToString()
                str(5) = row("bookid").ToString()
                str(6) = row("tim").ToString()

                Dim itm As New ListViewItem(str)
                ListView1.Items.Add(itm)
            Next
        Catch ex As Exception
            MessageBox.Show("An error occurred: " & ex.Message)
        End Try
    End Sub

    Private Sub ComboBox4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox4.SelectedIndexChanged
        ComboBox1.Items.Clear() ' Clear existing items in ComboBox1
        Dim sql As String
        Dim dt As DataTable
        Dim sqlParams As New List(Of SqlParameter)
        Try
            sql = "SELECT * FROM course WHERE cdept = @Dept AND clevel = @CLevel AND csemester = @CSemester"

            sqlParams.Add(New SqlParameter("@Dept", ComboBox3.Text))
            sqlParams.Add(New SqlParameter("@CLevel", ComboBox2.Text))
            sqlParams.Add(New SqlParameter("@CSemester", ComboBox4.Text))

            dt = Crud(sql, sqlParams)

            For Each row As DataRow In dt.Rows
                ComboBox1.Items.Add(row("ccode").ToString())
            Next
        Catch ex As Exception
            MessageBox.Show("An error occurred: " & ex.Message)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        Form9.Show()
    End Sub
End Class