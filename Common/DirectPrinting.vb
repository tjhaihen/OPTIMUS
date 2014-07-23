Imports System
Imports System.Data
Imports System.Drawing.Printing
Imports System.Runtime.InteropServices

Namespace Raven.Common
    Public Class DirectPrinting
        Private printerName As String
        Private thisDocInfo As DOCINFOW
        Private thisPrinterHandler As IntPtr

#Region "Interop UnManage"

        <DllImport("winspool.drv", CallingConvention:=CallingConvention.StdCall, CharSet:=CharSet.Unicode)> _
        Public Shared Function OpenPrinter(ByVal pPrinterName As String, ByRef phPrinter As IntPtr, ByVal pDefault As Integer) As Long
        End Function

        <DllImport("winspool.drv", CallingConvention:=CallingConvention.StdCall, CharSet:=CharSet.Unicode)> _
        Public Shared Function StartDocPrinter(ByVal hPrinter As IntPtr, ByVal Level As Integer, ByRef pDocInfo As DOCINFOW) As IntPtr
        End Function

        <DllImport("winspool.drv", CallingConvention:=CallingConvention.StdCall, CharSet:=CharSet.Unicode, ExactSpelling:=True)> _
        Public Shared Function StartPagePrinter(ByVal hPrinter As IntPtr) As Long
        End Function

        <DllImport("winspool.drv", CallingConvention:=CallingConvention.StdCall, CharSet:=CharSet.Ansi, ExactSpelling:=True)> _
        Public Shared Function WritePrinter(ByVal hPrinter As IntPtr, ByVal data As String, ByVal buf As Integer, ByRef pcWritten As Integer) As Long
        End Function

        <DllImport("winspool.drv", CallingConvention:=CallingConvention.StdCall, CharSet:=CharSet.Unicode, ExactSpelling:=True)> _
        Public Shared Function EndPagePrinter(ByVal hPrinter As IntPtr) As Long
        End Function

        <DllImport("winspool.drv", CallingConvention:=CallingConvention.StdCall, CharSet:=CharSet.Unicode, ExactSpelling:=True)> _
        Public Shared Function EndDocPrinter(ByVal hPrinter As IntPtr) As Long
        End Function

        <DllImport("winspool.drv", CallingConvention:=CallingConvention.StdCall, CharSet:=CharSet.Unicode, ExactSpelling:=True)> _
        Public Shared Function ClosePrinter(ByVal hPrinter As IntPtr) As Long
        End Function
#End Region

#Region "Public Properties"

        Public ReadOnly Property DocumentDatatype() As String
            Get
                Return thisDocInfo.pDataType
            End Get
        End Property



        Public ReadOnly Property DocumentName() As String
            Get
                Return thisDocInfo.pDocName
            End Get
        End Property


        Public ReadOnly Property DocumentOutputFile() As String
            Get
                Return thisDocInfo.pOutputFile
            End Get
        End Property


        Public ReadOnly Property PrinterHandler() As IntPtr
            Get
                Return thisPrinterHandler
            End Get

        End Property


#End Region

#Region "Raw Printer"

        Public Sub OpenPrinter(ByVal printer As String)
            OpenPrinter(printer, False)
        End Sub


        Public Sub OpenPrinter(ByVal printer As String, ByVal isStartDocPrinter As Boolean)

            printerName = printer
            OpenPrinter(printerName, thisPrinterHandler, 0)
            If isStartDocPrinter Then
                StartDocPrinter()
            End If

        End Sub

        Public Sub StartDocPrinter()
            thisDocInfo.pDataType = "RAW"
            StartDocPrinter(thisPrinterHandler, 1, thisDocInfo)
        End Sub

        Public Sub StartPagePrinter()
            StartPagePrinter(thisPrinterHandler)
        End Sub


        Public Sub EndPagePrinter()
            EndPagePrinter(thisPrinterHandler)
        End Sub


        Public Sub EndDocPrinter()
            EndDocPrinter(thisPrinterHandler)
        End Sub


        Public Sub ClosePrinter()
            ClosePrinter(thisPrinterHandler)

            Dim doc As New PrintDocument()
            Dim setting As New PrinterSettings()
            setting.PrinterName = printerName
            doc.PrinterSettings = setting
            doc.Print()
        End Sub


#End Region

#Region "Send Information"

        Public Sub Send(ByVal sData As String)
            Dim lpcWritten As Integer = 0
            WritePrinter(thisPrinterHandler, sData, sData.Length, lpcWritten)
        End Sub


        Public Sub SendLine(ByVal sData As String)
            Send(sData + "\f\r\n")
        End Sub


        Public Sub SendNewPage()
            Send("\f")
        End Sub

#End Region

        <StructLayout(LayoutKind.Sequential)> _
        Public Structure DOCINFOW
            <MarshalAs(UnmanagedType.LPWStr)> Public pDocName As String
            <MarshalAs(UnmanagedType.LPWStr)> Public pOutputFile As String
            <MarshalAs(UnmanagedType.LPWStr)> Public pDataType As String
        End Structure


    End Class
End Namespace

