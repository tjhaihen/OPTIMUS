Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports Raven.Common

Namespace Raven.Common.BussinessRules
    Public Class ServiceReportDt
        Inherits BRInteractionBase

#Region " Class Member Declarations "
        Private _serviceReportDtID, _serviceReportID, _ntName, _ntSerialNo, _ntUOM, _ntDimension, _ntResult As String
        Private _ntQty As Decimal
        Private _userIDinsert, _userIDupdate As String
        Private _insertDate, _updateDate As DateTime
#End Region

        Public Sub New()
            ' // Nothing for now.
        End Sub

        Public Sub New(ByVal strConnectionString As String)
            ConnectionString = strConnectionString
        End Sub

#Region " C,R,U,D "
        Public Overrides Function Insert() As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "INSERT INTO ServiceReportDt " + _
                                        "(serviceReportDtID, serviceReportID, ntName, ntSerialNo, ntQty, ntUOM, " + _
                                        "ntDimension, ntResult,  " + _
                                        "userIDinsert, userIDupdate, insertDate, updateDate) " + _
                                        "VALUES " + _
                                        "(@serviceReportDtID, @serviceReportID, @ntName, @ntSerialNo, @ntQty, @ntUOM, " + _
                                        "@ntDimension, @ntResult,  " + _
                                        "@userIDinsert, @userIDupdate, GETDATE(), GETDATE())"
            cmdToExecute.CommandType = CommandType.Text
            cmdToExecute.Connection = _mainConnection

            Dim strID As String = ID.GenerateIDNumber("ServiceReportDt", "serviceReportDtID")

            Try
                cmdToExecute.Parameters.AddWithValue("@serviceReportDtID", strID)
                cmdToExecute.Parameters.AddWithValue("@serviceReportID", _serviceReportID)
                cmdToExecute.Parameters.AddWithValue("@ntName", _ntName)
                cmdToExecute.Parameters.AddWithValue("@ntSerialNo", _ntSerialNo)
                cmdToExecute.Parameters.AddWithValue("@ntQty", _ntQty)
                cmdToExecute.Parameters.AddWithValue("@ntUOM", _ntUOM)
                cmdToExecute.Parameters.AddWithValue("@ntDimension", _ntDimension)
                cmdToExecute.Parameters.AddWithValue("@ntResult", _ntResult)
                cmdToExecute.Parameters.AddWithValue("@userIDinsert", _userIDinsert)
                cmdToExecute.Parameters.AddWithValue("@userIDupdate", _userIDupdate)

                ' // Open Connection
                _mainConnection.Open()

                ' // Execute Query
                cmdToExecute.ExecuteNonQuery()

                _serviceReportDtID = strID
                Return True
            Catch ex As Exception
                ExceptionManager.Publish(ex)
            Finally
                _mainConnection.Close()
                cmdToExecute.Dispose()
            End Try
        End Function

        Public Overrides Function Update() As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "UPDATE ServiceReportDt " + _
                                        "SET ntName=@ntName, ntSerialNo=@ntSerialNo, " + _
                                        "ntQty=@ntQty, ntUOM=@ntUOM, ntDimension=@ntDimension, " + _
                                        "ntResult=@ntResult, " + _
                                        "userIDupdate=@userIDupdate, updateDate=GETDATE() " + _
                                        "WHERE serviceReportDtID=@serviceReportDtID"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@serviceReportDtID", _serviceReportDtID)                
                cmdToExecute.Parameters.AddWithValue("@ntName", _ntName)
                cmdToExecute.Parameters.AddWithValue("@ntSerialNo", _ntSerialNo)
                cmdToExecute.Parameters.AddWithValue("@ntQty", _ntQty)
                cmdToExecute.Parameters.AddWithValue("@ntUOM", _ntUOM)
                cmdToExecute.Parameters.AddWithValue("@ntDimension", _ntDimension)
                cmdToExecute.Parameters.AddWithValue("@ntResult", _ntResult)                
                cmdToExecute.Parameters.AddWithValue("@userIDupdate", _userIDupdate)

                ' // Open Connection
                _mainConnection.Open()

                ' // Execute Query
                cmdToExecute.ExecuteNonQuery()

                Return True
            Catch ex As Exception
                ExceptionManager.Publish(ex)
            Finally
                _mainConnection.Close()
                cmdToExecute.Dispose()
            End Try
        End Function

        Public Overrides Function SelectAll() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "SELECT * FROM ServiceReportDt"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("ServiceReportDt")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)
            Catch ex As Exception
                ' // some error occured. Bubble it to caller and encapsulate Exception object
                ExceptionManager.Publish(ex)
            Finally
                ' // Close connection.
                _mainConnection.Close()
                cmdToExecute.Dispose()
                adapter.Dispose()
            End Try

            Return toReturn
        End Function

        Public Overrides Function SelectOne(Optional ByVal recStatus As RavenRecStatus = RavenRecStatus.CurrentRecord) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "SELECT * FROM ServiceReportDt WHERE serviceReportDtID=@serviceReportDtID"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("ServiceReportDt")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@serviceReportDtID", _serviceReportDtID)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 Then
                    _serviceReportDtID = CType(toReturn.Rows(0)("serviceReportDtID"), String)
                    _serviceReportID = CType(toReturn.Rows(0)("serviceReportID"), String)
                    _ntName = CType(toReturn.Rows(0)("ntName"), String)
                    _ntSerialNo = CType(toReturn.Rows(0)("ntSerialNo"), String)
                    _ntQty = CType(toReturn.Rows(0)("ntQty"), Decimal)
                    _ntUOM = CType(toReturn.Rows(0)("ntUOM"), String)
                    _ntDimension = CType(toReturn.Rows(0)("ntDimension"), String)
                    _ntResult = CType(toReturn.Rows(0)("ntResult"), String)
                    _userIDinsert = CType(toReturn.Rows(0)("userIDinsert"), String)
                    _userIDupdate = CType(toReturn.Rows(0)("userIDupdate"), String)
                    _insertDate = CType(toReturn.Rows(0)("insertDate"), DateTime)
                    _updateDate = CType(toReturn.Rows(0)("updateDate"), DateTime)
                End If
            Catch ex As Exception
                ' // some error occured. Bubble it to caller and encapsulate Exception object
                ExceptionManager.Publish(ex)
            Finally
                ' // Close connection.
                _mainConnection.Close()
                cmdToExecute.Dispose()
                adapter.Dispose()
            End Try

            Return toReturn
        End Function

        Public Overrides Function Delete() As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "DELETE FROM ServiceReportDt " + _
                                        "WHERE serviceReportDtID=@serviceReportDtID"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@serviceReportDtID", _serviceReportDtID)

                ' // Open Connection
                _mainConnection.Open()

                ' // Execute Query
                cmdToExecute.ExecuteNonQuery()

                Return True
            Catch ex As Exception
                ExceptionManager.Publish(ex)
            Finally
                _mainConnection.Close()
                cmdToExecute.Dispose()
            End Try
        End Function
#End Region

#Region " Custom Function "
        Public Function SelectByServiceReportID() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "SELECT sr.* " +
                                        "FROM ServiceReportDt sr WHERE sr.serviceReportID=@serviceReportID"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("ServiceReportDt")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@serviceReportID", _serviceReportID)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)
            Catch ex As Exception
                ' // some error occured. Bubble it to caller and encapsulate Exception object
                ExceptionManager.Publish(ex)
            Finally
                ' // Close connection.
                _mainConnection.Close()
                cmdToExecute.Dispose()
                adapter.Dispose()
            End Try

            Return toReturn
        End Function
#End Region

#Region " Class Property Declarations "
        Public Property [serviceReportDtID]() As String
            Get
                Return _serviceReportDtID
            End Get
            Set(ByVal Value As String)
                _serviceReportDtID = Value
            End Set
        End Property

        Public Property [serviceReportID]() As String
            Get
                Return _serviceReportID
            End Get
            Set(ByVal Value As String)
                _serviceReportID = Value
            End Set
        End Property

        Public Property [ntName]() As String
            Get
                Return _ntName
            End Get
            Set(ByVal Value As String)
                _ntName = Value
            End Set
        End Property

        Public Property [ntSerialNo]() As String
            Get
                Return _ntSerialNo
            End Get
            Set(ByVal Value As String)
                _ntSerialNo = Value
            End Set
        End Property

        Public Property [ntQty]() As Decimal
            Get
                Return _ntQty
            End Get
            Set(ByVal Value As Decimal)
                _ntQty = Value
            End Set
        End Property

        Public Property [ntUOM]() As String
            Get
                Return _ntUOM
            End Get
            Set(ByVal Value As String)
                _ntUOM = Value
            End Set
        End Property

        Public Property [ntDimension]() As String
            Get
                Return _ntDimension
            End Get
            Set(ByVal Value As String)
                _ntDimension = Value
            End Set
        End Property

        Public Property [ntResult]() As String
            Get
                Return _ntResult
            End Get
            Set(ByVal Value As String)
                _ntResult = Value
            End Set
        End Property

        Public Property [userIDinsert]() As String
            Get
                Return _userIDinsert
            End Get
            Set(ByVal Value As String)
                _userIDinsert = Value
            End Set
        End Property

        Public Property [userIDupdate]() As String
            Get
                Return _userIDupdate
            End Get
            Set(ByVal Value As String)
                _userIDupdate = Value
            End Set
        End Property

        Public Property [insertDate]() As DateTime
            Get
                Return _insertDate
            End Get
            Set(ByVal Value As DateTime)
                _insertDate = Value
            End Set
        End Property

        Public Property [updateDate]() As DateTime
            Get
                Return _updateDate
            End Get
            Set(ByVal Value As DateTime)
                _updateDate = Value
            End Set
        End Property
#End Region

    End Class
End Namespace
