Public Class Form9

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Form10.Dispose()
        Form10.Show()
        Me.Hide()
    End Sub

    Private Sub ToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem3.Click
        Form11.Dispose()
        Form11.Show()
        Me.Hide()
    End Sub

    Private Sub ToolStripMenuItem4_Click(sender As Object, e As EventArgs)
        Form12.Dispose()
        Form12.Show()
        Me.Hide()
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs)
        Form13.Dispose()
        Form13.Show()
        Me.Hide()
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs)
        Form14.Dispose()
        Form14.Show()
        Me.Hide()
    End Sub

    Private Sub ToolStripDropDownButton1_Click(sender As Object, e As EventArgs) Handles ToolStripDropDownButton1.Click
        Me.Hide()
        Form16.Show()
    End Sub

    Private Sub COURSEREGISTRATIONToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles COURSEREGISTRATIONToolStripMenuItem.Click
        Me.Hide()
        Form14.Show()
    End Sub

    Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs) Handles ToolStripButton5.Click
        Me.Hide()
        Form1.Show()
    End Sub

    Private Sub ToolStripDropDownButton4_Click(sender As Object, e As EventArgs) Handles ToolStripDropDownButton4.Click
        Me.Hide()
        Form20.Dispose()
        Form20.Show()
    End Sub
End Class