<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCapture
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lblId = New System.Windows.Forms.Label()
        Me.LogList = New System.Windows.Forms.ListBox()
        Me.CmdCapture = New System.Windows.Forms.Button()
        Me.lblPrintId = New System.Windows.Forms.Label()
        Me.Pic = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        CType(Me.Pic, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblId
        '
        Me.lblId.AutoSize = True
        Me.lblId.Location = New System.Drawing.Point(131, 12)
        Me.lblId.Name = "lblId"
        Me.lblId.Size = New System.Drawing.Size(0, 13)
        Me.lblId.TabIndex = 0
        Me.lblId.Visible = False
        '
        'LogList
        '
        Me.LogList.FormattingEnabled = True
        Me.LogList.Location = New System.Drawing.Point(3, 217)
        Me.LogList.Name = "LogList"
        Me.LogList.Size = New System.Drawing.Size(254, 95)
        Me.LogList.TabIndex = 2
        '
        'CmdCapture
        '
        Me.CmdCapture.Location = New System.Drawing.Point(68, 188)
        Me.CmdCapture.Name = "CmdCapture"
        Me.CmdCapture.Size = New System.Drawing.Size(103, 23)
        Me.CmdCapture.TabIndex = 3
        Me.CmdCapture.Text = "Capture"
        Me.CmdCapture.UseVisualStyleBackColor = True
        '
        'lblPrintId
        '
        Me.lblPrintId.AutoSize = True
        Me.lblPrintId.Location = New System.Drawing.Point(162, 12)
        Me.lblPrintId.Name = "lblPrintId"
        Me.lblPrintId.Size = New System.Drawing.Size(0, 13)
        Me.lblPrintId.TabIndex = 4
        '
        'Pic
        '
        Me.Pic.Location = New System.Drawing.Point(33, 12)
        Me.Pic.Name = "Pic"
        Me.Pic.Size = New System.Drawing.Size(175, 170)
        Me.Pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.Pic.TabIndex = 1
        Me.Pic.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(78, -23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Label1"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(-62, 89)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Label2"
        '
        'frmCapture
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(259, 313)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblPrintId)
        Me.Controls.Add(Me.CmdCapture)
        Me.Controls.Add(Me.LogList)
        Me.Controls.Add(Me.Pic)
        Me.Controls.Add(Me.lblId)
        Me.Name = "frmCapture"
        Me.Text = "frmCapture"
        CType(Me.Pic, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblId As System.Windows.Forms.Label
    Friend WithEvents Pic As System.Windows.Forms.PictureBox
    Friend WithEvents LogList As System.Windows.Forms.ListBox
    Friend WithEvents CmdCapture As System.Windows.Forms.Button
    Friend WithEvents lblPrintId As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
