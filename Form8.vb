Imports System.Data.SqlClient

Public Class Form8

    Private Sub Form8_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim sql As String = "SELECT * FROM venue"
        Dim dt As DataTable = Crud(sql, Nothing) ' No parameters for this query

        For Each row As DataRow In dt.Rows
            ComboBox1.Items.Add(row("vnam").ToString())
        Next
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Dim sql As String = "SELECT * FROM venue WHERE vnam = @vnam"
        Dim sqlParameters As New List(Of SqlParameter) From {
        New SqlParameter("@vnam", ComboBox1.Text)
    }

        Dim dt As DataTable = Crud(sql, sqlParameters)

        If dt.Rows.Count > 0 Then
            TextBox2.Text = dt.Rows(0)("capa").ToString()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim sql As String = "SELECT * FROM venue WHERE vnam = @vnam"
        Dim sqlParameters As New List(Of SqlParameter) From {
        New SqlParameter("@vnam", ComboBox1.Text)
    }

        Dim dt As DataTable = Crud(sql, sqlParameters)

        If dt.Rows.Count > 0 Then
            Dim updateSql As String = "UPDATE venue SET capa = @capa WHERE vnam = @vnam"
            Dim updateParameters As New List(Of SqlParameter) From {
            New SqlParameter("@capa", TextBox2.Text),
            New SqlParameter("@vnam", ComboBox1.Text)
        }

            Crud(updateSql, updateParameters) ' Update the record
            MsgBox("Success", MsgBoxStyle.Information, "EXAM")
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        Form2.Show()
    End Sub
End Class