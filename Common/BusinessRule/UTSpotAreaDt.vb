Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports Raven.Common

Namespace Raven.Common.BussinessRules
    Public Class UTSpotAreaDt
        Inherits BRInteractionBase

#Region " Class Member Declarations "
        Private _UTSpotAreaDtID, _UTSpotCheckHdID, _pipeNo As String
        Private _conditionResultPin, _conditionResultBox, _remarkPin, _remarkBox As String
        Private _insertDate, _updateDate As DateTime
        Private _userIDInsert, _userIDUpdate As String
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
            cmdToExecute.CommandText = "INSERT INTO UTSpotAreaDt " + _
                                        "(UTSpotCheckHdID, UTSpotAreaDtID, pipeNo, " + _
                                        "conditionResultPin, conditionResultBox, remarkPin, remarkBox, " + _
                                        "userIDinsert, userIDupdate, insertDate, updateDate) " + _
                                        "VALUES " + _
                                        "(@UTSpotCheckHdID, @UTSpotAreaDtID, @pipeNo, " + _
                                        "@conditionResultPin, @conditionResultBox, @remarkPin, @remarkBox, " + _
                                        "@userIDinsert, @userIDupdate, GETDATE(), GETDATE())"
            cmdToExecute.CommandType = CommandType.Text
            cmdToExecute.Connection = _mainConnection

            Dim strID As String = ID.GenerateIDNumber("UTSpotAreaDt", "UTSpotAreaDtID")

            Try
                cmdToExecute.Parameters.AddWithValue("@UTSpotCheckHdID", _UTSpotCheckHdID)
                cmdToExecute.Parameters.AddWithValue("@UTSpotAreaDtID", strID)
                cmdToExecute.Parameters.AddWithValue("@pipeNo", _pipeNo)
                cmdToExecute.Parameters.AddWithValue("@conditionResultPin", _conditionResultPin)
                cmdToExecute.Parameters.AddWithValue("@conditionResultBox", _conditionResultBox)
                cmdToExecute.Parameters.AddWithValue("@remarkPin", _remarkPin)
                cmdToExecute.Parameters.AddWithValue("@remarkBox", _remarkBox)
                cmdToExecute.Parameters.AddWithValue("@userIDinsert", _userIDInsert)
                cmdToExecute.Parameters.AddWithValue("@userIDupdate", _userIDUpdate)

                ' // Open Connection
                _mainConnection.Open()

                ' // Execute Query
                cmdToExecute.ExecuteNonQuery()

                _UTSpotAreaDtID = strID
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
            cmdToExecute.CommandText = "UPDATE UTSpotCheckDt " + _
                                        "SET pipeNo=@pipeNo, conditionResultPin=@conditionResultPin, conditionResultBox=@conditionResultBox, " + _
                                        "remarkPin=@remarkPin, remarkBox=@remarkBox, " + _
                                        "userIDupdate=@userIDupdate, updateDate=GETDATE() " + _
                                        "WHERE UTSpotAreaDtID=@UTSpotAreaDtID"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try                
                cmdToExecute.Parameters.AddWithValue("@UTSpotAreaDtID", _UTSpotAreaDtID)
                cmdToExecute.Parameters.AddWithValue("@pipeNo", _pipeNo)
                cmdToExecute.Parameters.AddWithValue("@conditionResultPin", _conditionResultPin)
                cmdToExecute.Parameters.AddWithValue("@conditionResultBox", _conditionResultBox)
                cmdToExecute.Parameters.AddWithValue("@remarkPin", _remarkPin)
                cmdToExecute.Parameters.AddWithValue("@remarkBox", _remarkBox)                
                cmdToExecute.Parameters.AddWithValue("@userIDupdate", _userIDUpdate)

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
            cmdToExecute.CommandText = "SELECT * FROM UTSpotAreaDt"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("UTSpotAreaDt")
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
            cmdToExecute.CommandText = "SELECT * FROM UTSpotAreaDt WHERE UTSpotAreaDtID=@UTSpotAreaDtID"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("UTSpotAreaDt")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@UTSpotAreaDtID", _UTSpotAreaDtID)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 Then
                    _UTSpotCheckHdID = CType(toReturn.Rows(0)("UTSpotCheckHdID"), String)
                    _UTSpotAreaDtID = CType(toReturn.Rows(0)("UTSpotAreaDtID"), String)
                    _pipeNo = CType(toReturn.Rows(0)("pipeNo"), String)
                    _conditionResultPin = CType(toReturn.Rows(0)("conditionResultPin"), String)
                    _conditionResultBox = CType(toReturn.Rows(0)("conditionResultBox"), String)
                    _remarkPin = CType(toReturn.Rows(0)("remarkPin"), String)
                    _remarkBox = CType(toReturn.Rows(0)("remarkBox"), String)
                    _userIDInsert = CType(toReturn.Rows(0)("userIDinsert"), String)
                    _userIDUpdate = CType(toReturn.Rows(0)("userIDupdate"), String)
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
            cmdToExecute.CommandText = "DELETE FROM UTSpotAreaDt " + _
                                        "WHERE UTSpotAreaDtID=@UTSpotAreaDtID"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@UTSpotAreaDtID", _UTSpotAreaDtID)

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
        Public Function SelectByHdID() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "SELECT drd.* " +
                                        "FROM UTSpotAreaDt drd WHERE drd.UTSpotCheckHdID=@UTSpotCheckHdID"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("UTSpotAreaDt")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@UTSpotCheckHdID", _UTSpotCheckHdID)

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
        Public Property [UTSpotCheckHdID]() As String
            Get
                Return _UTSpotCheckHdID
            End Get
            Set(ByVal Value As String)
                _UTSpotCheckHdID = Value
            End Set
        End Property

        Public Property [UTSpotAreaDtID]() As String
            Get
                Return _UTSpotAreaDtID
            End Get
            Set(ByVal Value As String)
                _UTSpotAreaDtID = Value
            End Set
        End Property

        Public Property [pipeNo]() As String
            Get
                Return _pipeNo
            End Get
            Set(ByVal Value As String)
                _pipeNo = Value
            End Set
        End Property

        Public Property [conditionResultPin]() As String
            Get
                Return _conditionResultPin
            End Get
            Set(ByVal Value As String)
                _conditionResultPin = Value
            End Set
        End Property

        Public Property [conditionResultBox]() As String
            Get
                Return _conditionResultBox
            End Get
            Set(ByVal Value As String)
                _conditionResultBox = Value
            End Set
        End Property

        Public Property [remarkPin]() As String
            Get
                Return _remarkPin
            End Get
            Set(ByVal Value As String)
                _remarkPin = Value
            End Set
        End Property

        Public Property [remarkBox]() As String
            Get
                Return _remarkBox
            End Get
            Set(ByVal Value As String)
                _remarkBox = Value
            End Set
        End Property

        Public Property [userIDinsert]() As String
            Get
                Return _userIDInsert
            End Get
            Set(ByVal Value As String)
                _userIDInsert = Value
            End Set
        End Property

        Public Property [userIDupdate]() As String
            Get
                Return _userIDUpdate
            End Get
            Set(ByVal Value As String)
                _userIDUpdate = Value
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
