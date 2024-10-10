<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form15
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
        Me.components = New System.ComponentModel.Container()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ComboBox2 = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.ComboBox4 = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.ComboBox5 = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.CourseCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CourseTitle = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CourseUnit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.level = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Matfrom = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Matto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Venue = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.Time = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.ExamDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lbvenue = New System.Windows.Forms.ListBox()
        Me.lbcapacity = New System.Windows.Forms.ListBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.VenueBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.StaffBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Panel1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VenueBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StaffBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.ComboBox1)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.ComboBox2)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.ComboBox4)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.ComboBox5)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Location = New System.Drawing.Point(92, 128)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(827, 83)
        Me.Panel1.TabIndex = 45
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"2018/2019", "2019/2020", "2020/2021", "2021/2022", "2022/2023", "2023/2024", "2024/2025"})
        Me.ComboBox1.Location = New System.Drawing.Point(460, 50)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(210, 21)
        Me.ComboBox1.TabIndex = 34
        Me.ComboBox1.Text = "Select"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Modern No. 20", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(368, 54)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 17)
        Me.Label1.TabIndex = 33
        Me.Label1.Text = "Session"
        '
        'ComboBox2
        '
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Items.AddRange(New Object() {"ND1", "ND2", "HND1", "HND2"})
        Me.ComboBox2.Location = New System.Drawing.Point(460, 12)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(210, 21)
        Me.ComboBox2.TabIndex = 32
        Me.ComboBox2.Text = "Select"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Modern No. 20", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(368, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 17)
        Me.Label2.TabIndex = 31
        Me.Label2.Text = "Level"
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.SystemColors.Control
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Button1.Font = New System.Drawing.Font("Modern No. 20", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(711, 12)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(105, 51)
        Me.Button1.TabIndex = 30
        Me.Button1.Text = "SHOW REPORT"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'ComboBox4
        '
        Me.ComboBox4.FormattingEnabled = True
        Me.ComboBox4.Items.AddRange(New Object() {"First", "Second"})
        Me.ComboBox4.Location = New System.Drawing.Point(95, 53)
        Me.ComboBox4.Name = "ComboBox4"
        Me.ComboBox4.Size = New System.Drawing.Size(210, 21)
        Me.ComboBox4.TabIndex = 29
        Me.ComboBox4.Text = "Select"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Modern No. 20", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(3, 57)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(61, 17)
        Me.Label9.TabIndex = 28
        Me.Label9.Text = "Semester"
        '
        'ComboBox5
        '
        Me.ComboBox5.FormattingEnabled = True
        Me.ComboBox5.Items.AddRange(New Object() {"FT", "PT"})
        Me.ComboBox5.Location = New System.Drawing.Point(95, 15)
        Me.ComboBox5.Name = "ComboBox5"
        Me.ComboBox5.Size = New System.Drawing.Size(210, 21)
        Me.ComboBox5.TabIndex = 27
        Me.ComboBox5.Text = "Select"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Modern No. 20", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(3, 19)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(79, 17)
        Me.Label8.TabIndex = 26
        Me.Label8.Text = "Programme"
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToResizeColumns = False
        Me.DataGridView1.AllowUserToResizeRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CourseCode, Me.CourseTitle, Me.CourseUnit, Me.level, Me.Matfrom, Me.Matto, Me.Venue, Me.Time, Me.ExamDate})
        Me.DataGridView1.Location = New System.Drawing.Point(0, 217)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(1101, 458)
        Me.DataGridView1.TabIndex = 46
        '
        'CourseCode
        '
        Me.CourseCode.HeaderText = "Course Code"
        Me.CourseCode.Name = "CourseCode"
        '
        'CourseTitle
        '
        Me.CourseTitle.HeaderText = "Course Title"
        Me.CourseTitle.Name = "CourseTitle"
        Me.CourseTitle.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.CourseTitle.Width = 250
        '
        'CourseUnit
        '
        Me.CourseUnit.HeaderText = "Course Unit"
        Me.CourseUnit.Name = "CourseUnit"
        '
        'level
        '
        Me.level.HeaderText = "Level"
        Me.level.Name = "level"
        '
        'Matfrom
        '
        Me.Matfrom.HeaderText = "MatricNo.(From)"
        Me.Matfrom.Name = "Matfrom"
        '
        'Matto
        '
        Me.Matto.HeaderText = "MatricNo. (To)"
        Me.Matto.Name = "Matto"
        '
        'Venue
        '
        Me.Venue.DataSource = Me.VenueBindingSource
        Me.Venue.HeaderText = "Venue"
        Me.Venue.Name = "Venue"
        Me.Venue.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Venue.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'Time
        '
        Me.Time.HeaderText = "Time"
        Me.Time.Items.AddRange(New Object() {"08:30 - 11:30", "12:00 - 15:00", "15:30 - 18:30"})
        Me.Time.Name = "Time"
        '
        'ExamDate
        '
        Me.ExamDate.HeaderText = "ExamDate"
        Me.ExamDate.Name = "ExamDate"
        Me.ExamDate.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'lbvenue
        '
        Me.lbvenue.FormattingEnabled = True
        Me.lbvenue.Location = New System.Drawing.Point(937, 11)
        Me.lbvenue.Name = "lbvenue"
        Me.lbvenue.Size = New System.Drawing.Size(53, 82)
        Me.lbvenue.TabIndex = 47
        Me.lbvenue.Visible = False
        '
        'lbcapacity
        '
        Me.lbcapacity.FormattingEnabled = True
        Me.lbcapacity.Location = New System.Drawing.Point(996, 11)
        Me.lbcapacity.Name = "lbcapacity"
        Me.lbcapacity.Size = New System.Drawing.Size(52, 82)
        Me.lbcapacity.TabIndex = 49
        Me.lbcapacity.Visible = False
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(1068, 24)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(87, 20)
        Me.TextBox1.TabIndex = 50
        Me.TextBox1.Visible = False
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(1068, 55)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(87, 20)
        Me.TextBox2.TabIndex = 51
        Me.TextBox2.Visible = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.SystemColors.Control
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Button2.Font = New System.Drawing.Font("Modern No. 20", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(943, 588)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(138, 39)
        Me.Button2.TabIndex = 52
        Me.Button2.Text = "SUBMIT"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.SystemColors.Control
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Button3.Font = New System.Drawing.Font("Modern No. 20", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.Location = New System.Drawing.Point(747, 694)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(138, 39)
        Me.Button3.TabIndex = 53
        Me.Button3.Text = "EXIT"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'VenueBindingSource
        '
        Me.VenueBindingSource.DataMember = "venue"
        '
        'PictureBox3
        '
        Me.PictureBox3.BackgroundImage = Global.EXAM.My.Resources.Resources.offa_poly
        Me.PictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox3.Location = New System.Drawing.Point(943, 12)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(140, 104)
        Me.PictureBox3.TabIndex = 56
        Me.PictureBox3.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Modern No. 20", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(200, 42)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(653, 34)
        Me.Label4.TabIndex = 55
        Me.Label4.Text = "EXAMINATION TIMETABLE SCHEDULE"
        '
        'PictureBox2
        '
        Me.PictureBox2.BackgroundImage = Global.EXAM.My.Resources.Resources.offa_poly
        Me.PictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox2.Location = New System.Drawing.Point(3, 11)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(130, 104)
        Me.PictureBox2.TabIndex = 54
        Me.PictureBox2.TabStop = False
        '
        'Form15
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1110, 745)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.lbcapacity)
        Me.Controls.Add(Me.lbvenue)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Panel1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form15"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VenueBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.StaffBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Button1 As Button
    Friend WithEvents ComboBox4 As ComboBox
    Friend WithEvents Label9 As Label
    Friend WithEvents ComboBox5 As ComboBox
    Friend WithEvents Label8 As Label
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents ComboBox2 As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents lbvenue As ListBox
    Friend WithEvents lbcapacity As ListBox
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents VenueBindingSource As BindingSource
    Friend WithEvents StaffBindingSource As BindingSource
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents CourseCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CourseTitle As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CourseUnit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents level As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Matfrom As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Matto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Venue As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents Time As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents ExamDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents Label4 As Label
    Friend WithEvents PictureBox2 As PictureBox
End Class
