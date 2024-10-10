Imports System.Data.SqlClient

Public Class Form7

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim sql As String = "SELECT * FROM venue WHERE vnam = @vnam AND capa = @capa"
        Dim sqlParameters As New List(Of SqlParameter) From {
        New SqlParameter("@vnam", TextBox4.Text),
        New SqlParameter("@capa", TextBox2.Text)
    }

        ' Check if the venue already exists
        Dim dt As DataTable = Crud(sql, sqlParameters)

        If dt.Rows.Count = 0 Then
            Dim capacity As Integer = Val(TextBox1.Text)

            For a As Integer = 1 To capacity
                Dim insertSql As String = "INSERT INTO venue (vnam, capa) VALUES (@vnam, @capa)"
                Dim insertParameters As New List(Of SqlParameter) From {
                New SqlParameter("@vnam", TextBox4.Text & a),
                New SqlParameter("@capa", TextBox2.Text)
            }

                ' Execute the insert command
                Crud(insertSql, insertParameters)
            Next

            MsgBox("Success", MsgBoxStyle.Information, "EXAM")
        Else
            MsgBox("Venue Already Exists", MsgBoxStyle.Critical, "EXAM")
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        Form2.Show()
    End Sub
End Class