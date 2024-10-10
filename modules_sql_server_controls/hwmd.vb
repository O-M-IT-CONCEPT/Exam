Imports System.IO
Imports System.Management
Imports System.Text
Module hwmd
    Public filePathfirst_time As String = Path.Combine("first_time_execution.dll")
    Function GetHardwareID() As String
        Dim hardwareID As String = String.Empty
        Try
            Dim searcher As New ManagementObjectSearcher("SELECT ProcessorId FROM Win32_Processor")
            For Each obj As ManagementObject In searcher.Get()
                hardwareID = obj("ProcessorId").ToString()
                Exit For
            Next
        Catch ex As Exception
            MsgBox($"Unable to retrieve hardware ID:{vbCrLf} Program will stop immediately, {vbCrLf} Please Contact the Dev. {vbCrLf} {ex.Message}")
            End
        End Try
        Return hardwareID
    End Function

    Public Function CheckAndWriteHardwareID() As Boolean
        Dim appPath As String = AppDomain.CurrentDomain.BaseDirectory
        Dim filePath As String = filePathfirst_time
        Dim currentHardwareID As String = GetHardwareID()
        If File.Exists(filePath) Then
            Dim fileHardwareID As String = File.ReadAllText(filePath, Encoding.UTF8)
            If fileHardwareID = currentHardwareID Then
                Return True
            Else
                File.WriteAllText(filePath, currentHardwareID, Encoding.UTF8)
                Return False
            End If
        Else
            File.WriteAllText(filePath, currentHardwareID, Encoding.UTF8)
            Return False
        End If
    End Function

End Module
