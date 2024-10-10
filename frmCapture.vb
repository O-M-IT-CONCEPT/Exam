Public Class frmCapture
    Dim myUtil As Util
    Dim I As Integer
    Dim id As Integer

    Private Sub frmCapture_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        
    End Sub
    ' Private Sub frmCapture_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
    '    If Label2.Text = "DONE" Then
    '       MsgBox("You are a new student, go ahead with your registration")
    '      Label2.Text = ""
    'Form5.Show()
    ' End If
    'End Sub


    Private Sub frmCapture_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles Me.FormClosing
        myUtil.FinalizeGrFinger()
    End Sub
    Private Sub frmCapture_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        Dim err As Integer

        ' alow util class to access controls in main form
        Control.CheckForIllegalCrossThreadCalls = False
        ' initialize util class
        myUtil = New Util(LogList, Pic)
        ' initialize GrFingerX Library
        err = myUtil.InitializeGrFinger()
        ' print result in log
        If err < 0 Then
            myUtil.WriteError(err)

            Exit Sub
        Else
            myUtil.WriteLog("**GrFinger Initialized Successfully**")
        End If
    End Sub
    Public Sub GrFinger_SensorPlugUnPlug(ByVal idSensor As String, ByVal evt As Integer)
        If evt = GrFinger.GR_PLUG Then
            myUtil.WriteLog("Sensor: " & idSensor & ". Event: Plugged.")
            GrFinger.CapStartCapture(idSensor, AddressOf GrFinger_FingerUpDown, AddressOf GrFinger_ImageAcquired)
        End If
        If evt = GrFinger.GR_UNPLUG Then
            myUtil.WriteLog("Sensor: " & idSensor & ". Event: Unplugged.")
            GrFinger.CapStopCapture(idSensor)
        End If
    End Sub

    ' A finger was placed on or removed from reader
    Public Sub GrFinger_FingerUpDown(ByVal idSensor As String, ByVal evt As Integer)
        If evt = GrFinger.GR_FINGER_DOWN Then
            myUtil.WriteLog("Sensor: " & idSensor & ". Event: Finger Placed.")
        End If
        If evt = GrFinger.GR_FINGER_UP Then
            myUtil.WriteLog("Sensor: " & idSensor & ". Event: Finger removed.")
        End If
    End Sub

    Public Sub GrFinger_ImageAcquired(ByVal idSensor As String, ByVal width As Integer, ByVal height As Integer, ByVal rawImage As Byte(), ByVal res As Integer)
        ' Copying aquired image
        myUtil.raw.height = height
        myUtil.raw.width = width
        myUtil.raw.res = res
        myUtil.raw.img = rawImage

        ' Signaling that an Image Event occurred.
        myUtil.WriteLog("Sensor: " & idSensor & ". Event: Image captured.")

        ' display fingerprint image
        myUtil.PrintBiometricDisplay(False, GrFinger.GR_DEFAULT_CONTEXT)

        extract()
        Identify()
        ' now we have a fingerprint, so we can extract template
        'ExtractButton.Enabled = True
        'EnrollButton.Enabled = False
        'IdentifyButton.Enabled = False
        'VerifyButton.Enabled = False

        ' extracting template from image
        'If ckAutoExtract.Checked Then ExtractButton.PerformClick()

        ' identify fingerprint
        ' If ckBoxAutoIdentify.Checked Then IdentifyButton().PerformClick()
    End Sub

    Public Sub extract()
        Dim ret As Integer

        ' extract template
        ret = myUtil.ExtractTemplate()
        ' write template quality to log
        If ret = GrFinger.GR_BAD_QUALITY Then
            myUtil.WriteLog("Template extracted successfully. Bad quality.")
        ElseIf ret = GrFinger.GR_MEDIUM_QUALITY Then
            myUtil.WriteLog("Template extracted successfully. Medium quality.")
        ElseIf ret = GrFinger.GR_HIGH_QUALITY Then
            myUtil.WriteLog("Template extracted successfully. High quality.")
        End If
        If ret >= 0 Then
            ' if no error, display minutiae/segments/directions into the image
            myUtil.PrintBiometricDisplay(True, GrFinger.GR_NO_CONTEXT)
            ' enable operations we can do over extracted template
            'ExtractButton.Enabled = False
            'EnrollButton.Enabled = True
            'IdentifyButton.Enabled = True
            'VerifyButton.Enabled = True
        Else
            ' write error to log
            myUtil.WriteError(ret)

        End If
    End Sub

    Public Sub EnrollPrint()


        ' add fingerprint
        id = myUtil.Enroll()
        ' write result to log
        If id >= 0 Then
            myUtil.WriteLog("Fingerprint enrolled with id = " & id)
        Else
            myUtil.WriteLog("Error: Fingerprint not enrolled")
        End If

    End Sub
    Public Sub Identify()
        Dim ret As Integer, score As Integer
        If lblId.Text = "Search" Then
            score = 0
            ' identify it
            ret = myUtil.Identify(score)
            ' write result to log
            If ret > 0 Then

                myUtil.WriteLog("Fingerprint identified. ID = " & ret & ". Score = " & score & ".")
                myUtil.PrintBiometricDisplay(True, GrFinger.GR_DEFAULT_CONTEXT)
                GlobalVar.GlobalID = ret
                Me.Hide()
                Dispose()
                Me.Close()
                Me.Dispose()

                Exit Sub
                myUtil.WriteLog("Fingerprint not Found.")
            Else
                myUtil.WriteError(ret)
                ' MsgBox("close and try again")
            End If

        End If
    End Sub
    Private Sub CmdCapture_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CmdCapture.Click

        If I = 0 Then
            Form10.Pic1.Image = Pic.Image
            EnrollPrint()
            Form10.lbl1.Text = id
            I = I + 1

        ElseIf I = 1 Then
            Form10.Pic2.Image = Pic.Image
            EnrollPrint()
            Form10.lbl2.Text = id
            I = I + 1

        ElseIf I = 2 Then
            Form10.Pic3.Image = Pic.Image
            EnrollPrint()
            Form10.lbl3.Text = id
            I = I + 1

        ElseIf I = 3 Then
            Form10.Pic4.Image = Pic.Image
            EnrollPrint()
            Form10.lbl4.Text = id
            I = 4
            CmdCapture.Text = "Finish"
            Dispose()
        End If
    End Sub
End Class