Option Explicit On

Imports System
Imports System.Web
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports System.Data.OleDb


Imports Raven.Common

Namespace Raven.BussinessRules

    Public Class MyReport
        Inherits BRInteractionBase

#Region " Class Member Declarations "
        Private _reportID, _parentReportID, _reportCaption, _url, _reportParameter, _appID, _reportFileName, _description, _reportAsp, _reportSPName As String
        Private _isHeader, _isActive As Boolean
        Private _publishDate As DateTime
        Private _reportFormat As String
        Private _Parameters As String = String.Empty
#End Region

#Region "Public Functions"
        Public Function GetReportDataByReportCode() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = String.Format("SELECT * FROM Report WHERE ReportID = '{0}'", _reportID)
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("rpt_data")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 Then
                    _reportID = toReturn.Rows(0)("ReportID").ToString()
                    _parentReportID = ProcessNull.GetString(toReturn.Rows(0)("ParentReportID").ToString)
                    _reportCaption = toReturn.Rows(0)("ReportCaption").ToString()
                    _url = toReturn.Rows(0)("Url").ToString()
                    _reportParameter = toReturn.Rows(0)("ReportParameter").ToString()
                    _appID = toReturn.Rows(0)("AppID").ToString()
                    _reportFileName = toReturn.Rows(0)("ReportFIleName").ToString()
                    _reportSPName = toReturn.Rows(0)("ReportSPName").ToString()
                    _reportAsp = toReturn.Rows(0)("ReportAsp").ToString()
                    _reportFormat = toReturn.Rows(0)("ReportFormat").ToString()
                    _isHeader = Convert.ToBoolean(toReturn.Rows(0)("isHeader"))
                    _isActive = Convert.ToBoolean(toReturn.Rows(0)("isActive"))
                    _description = toReturn.Rows(0)("Description").ToString()
                    _publishDate = Convert.ToDateTime(toReturn.Rows(0)("PublishDate"))
                End If
                Return toReturn
            Catch ex As Exception
                ' // some error occured. Bubble it to caller and encapsulate Exception object
                ExceptionManager.Publish(ex)
            Finally
                ' // Close connection.
                _mainConnection.Close()
                cmdToExecute.Dispose()
                adapter.Dispose()
            End Try
        End Function

        Public Sub AddParameters(ByVal Parameter As String, Optional ByVal IsClear As Boolean = False)
            If Not IsClear Then
                If _Parameters = "" Or _Parameters = Nothing Then
                    _Parameters = Parameter
                Else
                    _Parameters = _Parameters + "|" + Parameter
                End If
            Else
                _Parameters = String.Empty
            End If
        End Sub

        Public Function UrlPrint(ByVal ContextRequestUrlHost As String) As String
            Return "<script language=javascript>window.open('http://" + ContextRequestUrlHost + Common.SysConfig.ModuleAppl + "ReportViewer.aspx?rpt=" + _reportID.Trim + "&par=" + _Parameters.Trim + "','','status=no,resizable=yes,toolbar=no,menubar=no,location=no,scrollbars=1')</script>"
        End Function

        Public Function UrlPrintPreview(ByVal ContextRequestUrlHost As String, Optional ByVal ModuleName As String = "systemsetup") As String
            If Not GetReportDataByReportCode.Rows.Count > 0 Then
                Throw New Exception("Report ID not found")
                Exit Function
            End If
            'If _Parameters = "" OrElse _Parameters = Nothing Then
            '    Throw New Exception("Parameter Print form cannot empty")
            '    Exit Function
            'End If
            Return "<script language=javascript>window.open('http://" + ContextRequestUrlHost + SysConfig.ReportsFolder.Trim + _reportAsp.Trim + ".asp?RptName=" + _reportFileName.Trim + "&SP=" + _reportSPName.Trim + "&parm=" + _Parameters.Trim + "&moduleName=" + ModuleName.Trim + "','','status=no,resizable=yes,toolbar=no,menubar=no,location=no;')</script>"
        End Function

#End Region

#Region " Class Property Declaration"
        Public Property [ReportCode]() As String
            Get
                Return _reportID
            End Get
            Set(ByVal Value As String)
                _reportID = Value
            End Set
        End Property

        Public Property [ParentReportCode]() As String
            Get
                Return _parentReportID
            End Get
            Set(ByVal Value As String)
                _parentReportID = Value
            End Set
        End Property

        Public Property [ReportCaption]() As String
            Get
                Return _reportCaption
            End Get
            Set(ByVal Value As String)
                _reportCaption = Value
            End Set
        End Property

        Public Property [Url]() As String
            Get
                Return _url
            End Get
            Set(ByVal Value As String)
                _url = Value
            End Set
        End Property

        Public Property [ReportParameter]() As String
            Get
                Return _reportParameter
            End Get
            Set(ByVal Value As String)
                _reportParameter = Value
            End Set
        End Property

        Public Property [AppID]() As String
            Get
                Return _appID
            End Get
            Set(ByVal Value As String)
                _appID = Value
            End Set
        End Property

        Public Property [ReportFileName]() As String
            Get
                Return _reportFileName
            End Get
            Set(ByVal Value As String)
                _reportFileName = Value
            End Set
        End Property

        Public Property [ReportFormat]() As String
            Get
                Return _reportFormat
            End Get
            Set(ByVal Value As String)
                _reportFormat = Value
            End Set
        End Property

        Public Property [IsHeader]() As Boolean
            Get
                Return _isHeader
            End Get
            Set(ByVal Value As Boolean)
                _isHeader = Value
            End Set
        End Property

        Public Property [IsActive]() As Boolean
            Get
                Return _isActive
            End Get
            Set(ByVal Value As Boolean)
                _isActive = Value
            End Set
        End Property

        Public Property [Description]() As String
            Get
                Return _description
            End Get
            Set(ByVal Value As String)
                _description = Value
            End Set
        End Property

        Public Property [PublishDate]() As DateTime
            Get
                Return _publishDate
            End Get
            Set(ByVal Value As DateTime)
                _publishDate = Value
            End Set
        End Property
#End Region
    End Class

End Namespace
