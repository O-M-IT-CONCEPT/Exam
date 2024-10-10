Imports System.Data.SqlClient
Module ModClasses
    Public con As SqlConnection = Nothing
    Public cmd0, cmd, cmd1, cmd2, cmd3, cmd4 As SqlCommand
    Public rdr As SqlDataReader = Nothing
    Public rdr2 As SqlDataReader = Nothing
    Public ds, ds2, ds3 As DataSet
    Public adp, adp1, adp2, adp3, adp4 As SqlDataAdapter
    Public dtable, dtable1, dtable2, dtable3, dtable4, dtable5, dtable6, dtable7, dtable8 As DataTable
    Public TempFileNames2, TempFileNames3 As String
    Public rdr1 As SqlDataReader = Nothing
End Module

Public Class Receipt
    Public receiptType As String
    Public receiptCurrency As String
    Public receiptCounter As Integer?
    Public receiptGlobalNo As Integer?
    Public invoiceNo As String
    Public buyerData As Object
    Public receiptNotes As Object
    Public receiptDate As DateTime?
    Public creditDebitNote As Object
    Public receiptLinesTaxInclusive As Boolean?
    Public receiptLines As List(Of ReceiptLine)
    Public receiptTaxes As List(Of ReceiptTaxis)
    Public receiptPayments As List(Of ReceiptPayment)
    Public receiptTotal As Double?
    Public receiptPrintForm As String
    Public receiptDeviceSignature As ReceiptDeviceSignature
End Class

Public Class ReceiptDeviceSignature
    Public hash As String
    Public signature As String
End Class

Public Class ReceiptLine
    Public receiptLineName As String
    Public receiptLineNo As Integer?
    Public receiptLineQuantity As Decimal?
    Public receiptLineType As String
    Public receiptLineTotal As Double?
    Public taxID As Integer?
    Public receiptLineHSCode As String
    Public receiptLinePrice As Double?
    Public taxCode As String
    Public taxPercent As Double?
End Class

Public Class ReceiptPayment
    Public moneyTypeCode As String
    Public paymentAmount As Double?
End Class

Public Class ReceiptTaxis
    Public salesAmountWithTax As Double?
    Public taxAmount As Double?
    Public taxID As Integer?
    Public taxCode As String
    Public taxPercent As Double?
End Class