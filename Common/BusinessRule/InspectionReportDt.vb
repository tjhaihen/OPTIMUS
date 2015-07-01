Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports Raven.Common

Namespace Raven.Common.BussinessRules
    Public Class InspectionReportDt
        Inherits BRInteractionBase

#Region " Class Member Declarations "
        Private _inspectionReportDtID, _inspectionReportHdID As String
        Private _description, _serialNo, _totalLength, _connectionSizePin, _connectionSizeBox, _connectionODPin, _connectionODBox As String
        Private _elevatorGrooveDiaPin, _elevatorGrooveDiaBox, _elevatorGrooveDepthPin, _elevatorGrooveDepthBox, _IDdescription As String
        Private _BBackRGrooveDiaPin, _BBackRGrooveDiaBox, _BBackRGrooveLengthPin, _BBackRGrooveLengthBox, _bevelDiaPin, _bevelDiaBox As String
        Private _threadLengthPin, _threadLengthBox, _counterBoreDiaPin, _counterBoreDiaBox, _counterBoreDepthPin, _counterBoreDepthBox As String
        Private _centerPadDiaPin, _centerPadDiaBox, _centerPadDepthPin, _centerPadDepthBox As String
        Private _tongSpacePin, _tongSpaceBox, _conditionPin, _conditionBox, _BSR, _remarksPin, _remarksBox As String
        Private _HBPin, _HBBox, _HBCenterPad As String
        Private _connectionPinSCode, _connectionBoxSCode, _threadLengthPinSCode, _threadLengthBoxSCode As String
        Private _conditionPinSCode, _conditionBoxSCode As String
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
            cmdToExecute.CommandText = "INSERT INTO InspectionReportDt " + _
                                        "(inspectionReportDtID, inspectionReportHdID, " + _
                                        "description, serialNo, totalLength, connectionSizePin, connectionSizeBox, connectionODPin, connectionODBox, " + _
                                        "elevatorGrooveDiaPin, elevatorGrooveDiaBox, elevatorGrooveDepthPin, elevatorGrooveDepthBox, IDdescription, " + _
                                        "BBackRGrooveDiaPin, BBackRGrooveDiaBox, BBackRGrooveLengthPin, BBackRGrooveLengthBox, bevelDiaPin, bevelDiaBox, " + _
                                        "threadLengthPin, threadLengthBox, counterBoreDiaPin, counterBoreDiaBox, counterBoreDepthPin, counterBoreDepthBox, " + _
                                        "centerPadDiaPin, centerPadDiaBox, centerPadDepthPin, centerPadDepthBox, " + _
                                        "tongSpacePin, tongSpaceBox, conditionPin, conditionBox, BSR, remarksPin, remarksBox, " + _
                                        "connectionPinSCode, connectionBoxSCode, threadLengthPinSCode, threadLengthBoxSCode, " + _
                                        "conditionPinSCode, conditionBoxSCode, " + _
                                        "HBPin, HBBox, HBCenterPad, " + _
                                        "insertDate, updateDate, " + _
                                        "userIDInsert, userIDUpdate) " + _
                                        "VALUES " + _
                                        "(@inspectionReportDtID, @inspectionReportHdID, " + _
                                        "@description, @serialNo, @totalLength, @connectionSizePin, @connectionSizeBox, @connectionODPin, @connectionODBox, " + _
                                        "@elevatorGrooveDiaPin, @elevatorGrooveDiaBox, @elevatorGrooveDepthPin, @elevatorGrooveDepthBox, @IDdescription, " + _
                                        "@BBackRGrooveDiaPin, @BBackRGrooveDiaBox, @BBackRGrooveLengthPin, @BBackRGrooveLengthBox, @bevelDiaPin, @bevelDiaBox, " + _
                                        "@threadLengthPin, @threadLengthBox, @counterBoreDiaPin, @counterBoreDiaBox, @counterBoreDepthPin, @counterBoreDepthBox, " + _
                                        "@centerPadDiaPin, @centerPadDiaBox, @centerPadDepthPin, @centerPadDepthBox, " + _
                                        "@tongSpacePin, @tongSpaceBox, @conditionPin, @conditionBox, @BSR, @remarksPin, @remarksBox, " + _
                                        "@connectionPinSCode, @connectionBoxSCode, @threadLengthPinSCode, @threadLengthBoxSCode, " + _
                                        "@conditionPinSCode, @conditionBoxSCode, " + _
                                        "@HBPin, @HBBox, @HBCenterPad, " + _
                                        "GETDATE(), GETDATE(), " + _
                                        "@userIDInsert, @userIDUpdate)"
            cmdToExecute.CommandType = CommandType.Text
            cmdToExecute.Connection = _mainConnection

            Dim strID As String = ID.GenerateIDNumber("InspectionReportDt", "inspectionReportDtID")

            Try
                cmdToExecute.Parameters.AddWithValue("@inspectionReportDtID", strID)
                cmdToExecute.Parameters.AddWithValue("@inspectionReportHdID", _inspectionReportHdID)
                cmdToExecute.Parameters.AddWithValue("@description", _description)
                cmdToExecute.Parameters.AddWithValue("@serialNo", _serialNo)
                cmdToExecute.Parameters.AddWithValue("@totalLength", _totalLength)
                cmdToExecute.Parameters.AddWithValue("@connectionSizePin", _connectionSizePin)
                cmdToExecute.Parameters.AddWithValue("@connectionSizeBox", _connectionSizeBox)
                cmdToExecute.Parameters.AddWithValue("@connectionODPin", _connectionODPin)
                cmdToExecute.Parameters.AddWithValue("@connectionODBox", _connectionODBox)
                cmdToExecute.Parameters.AddWithValue("@elevatorGrooveDiaPin", _elevatorGrooveDiaPin)
                cmdToExecute.Parameters.AddWithValue("@elevatorGrooveDiaBox", _elevatorGrooveDiaBox)
                cmdToExecute.Parameters.AddWithValue("@elevatorGrooveDepthPin", _elevatorGrooveDepthPin)
                cmdToExecute.Parameters.AddWithValue("@elevatorGrooveDepthBox", _elevatorGrooveDepthBox)
                cmdToExecute.Parameters.AddWithValue("@IDdescription", _IDdescription)
                cmdToExecute.Parameters.AddWithValue("@BBackRGrooveDiaPin", _BBackRGrooveDiaPin)
                cmdToExecute.Parameters.AddWithValue("@BBackRGrooveDiaBox", _BBackRGrooveDiaBox)
                cmdToExecute.Parameters.AddWithValue("@BBackRGrooveLengthPin", _BBackRGrooveLengthPin)
                cmdToExecute.Parameters.AddWithValue("@BBackRGrooveLengthBox", _BBackRGrooveLengthBox)
                cmdToExecute.Parameters.AddWithValue("@bevelDiaPin", _bevelDiaPin)
                cmdToExecute.Parameters.AddWithValue("@bevelDiaBox", _bevelDiaBox)
                cmdToExecute.Parameters.AddWithValue("@threadLengthPin", _threadLengthPin)
                cmdToExecute.Parameters.AddWithValue("@threadLengthBox", _threadLengthBox)
                cmdToExecute.Parameters.AddWithValue("@counterBoreDiaPin", _counterBoreDiaPin)
                cmdToExecute.Parameters.AddWithValue("@counterBoreDiaBox", _counterBoreDiaBox)
                cmdToExecute.Parameters.AddWithValue("@counterBoreDepthPin", _counterBoreDepthPin)
                cmdToExecute.Parameters.AddWithValue("@counterBoreDepthBox", _counterBoreDepthBox)
                cmdToExecute.Parameters.AddWithValue("@centerPadDiaPin", _centerPadDiaPin)
                cmdToExecute.Parameters.AddWithValue("@centerPadDiaBox", _centerPadDiaBox)
                cmdToExecute.Parameters.AddWithValue("@centerPadDepthPin", _centerPadDepthPin)
                cmdToExecute.Parameters.AddWithValue("@centerPadDepthBox", _centerPadDepthBox)
                cmdToExecute.Parameters.AddWithValue("@tongSpacePin", _tongSpacePin)
                cmdToExecute.Parameters.AddWithValue("@tongSpaceBox", _tongSpaceBox)
                cmdToExecute.Parameters.AddWithValue("@conditionPin", _conditionPin)
                cmdToExecute.Parameters.AddWithValue("@conditionBox", _conditionBox)
                cmdToExecute.Parameters.AddWithValue("@BSR", _BSR)
                cmdToExecute.Parameters.AddWithValue("@remarksPin", _remarksPin)
                cmdToExecute.Parameters.AddWithValue("@remarksBox", _remarksBox)
                cmdToExecute.Parameters.AddWithValue("@HBPin", _HBPin)
                cmdToExecute.Parameters.AddWithValue("@HBBox", _HBBox)
                cmdToExecute.Parameters.AddWithValue("@HBCenterPad", _HBCenterPad)
                cmdToExecute.Parameters.AddWithValue("@connectionPinSCode", _connectionPinSCode)
                cmdToExecute.Parameters.AddWithValue("@connectionBoxSCode", _connectionBoxSCode)
                cmdToExecute.Parameters.AddWithValue("@threadLengthPinSCode", _threadLengthPinSCode)
                cmdToExecute.Parameters.AddWithValue("@threadLengthBoxSCode", _threadLengthBoxSCode)
                cmdToExecute.Parameters.AddWithValue("@conditionPinSCode", _conditionPinSCode)
                cmdToExecute.Parameters.AddWithValue("@conditionBoxSCode", _conditionBoxSCode)
                cmdToExecute.Parameters.AddWithValue("@userIDinsert", _userIDInsert)
                cmdToExecute.Parameters.AddWithValue("@userIDupdate", _userIDUpdate)

                ' // Open Connection
                _mainConnection.Open()

                ' // Execute Query
                cmdToExecute.ExecuteNonQuery()

                _inspectionReportHdID = strID
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
            cmdToExecute.CommandText = "UPDATE InspectionReportDt " + _
                                        "SET description=@description, serialNo=@serialNo, totalLength=@totalLength, connectionSizePin=@connectionSizePin, " + _
                                        "connectionSizeBox=@connectionSizeBox, connectionODPin=@connectionODPin, connectionODBox=@connectionODBox, " + _
                                        "elevatorGrooveDiaPin=@elevatorGrooveDiaPin, elevatorGrooveDiaBox=@elevatorGrooveDiaBox, " + _
                                        "elevatorGrooveDepthPin=@elevatorGrooveDepthPin, elevatorGrooveDepthBox=@elevatorGrooveDepthBox, IDdescription=@IDdescription, " + _
                                        "BBackRGrooveDiaPin=@BBackRGrooveDiaPin, BBackRGrooveDiaBox=@BBackRGrooveDiaBox, BBackRGrooveLengthPin=@BBackRGrooveLengthPin, " + _
                                        "BBackRGrooveLengthBox=@BBackRGrooveLengthBox, bevelDiaPin=@bevelDiaPin, bevelDiaBox=@bevelDiaBox, " + _
                                        "threadLengthPin=@threadLengthPin, threadLengthBox=@threadLengthBox, counterBoreDiaPin=@counterBoreDiaPin, " + _
                                        "counterBoreDiaBox=@counterBoreDiaBox, counterBoreDepthPin=@counterBoreDepthPin, counterBoreDepthBox=@counterBoreDepthBox, " + _
                                        "centerPadDiaPin=@centerPadDiaPin, centerPadDiaBox=@centerPadDiaBox, centerPadDepthPin=@centerPadDepthPin, centerPadDepthBox=@centerPadDepthBox, " + _
                                        "tongSpacePin=@tongSpacePin, tongSpaceBox=@tongSpaceBox, conditionPin=@conditionPin, " + _
                                        "conditionBox=@conditionBox, BSR=@BSR, remarksPin=@remarksPin, remarksBox=@remarksBox, " + _
                                        "HBPin=@HBPin, HBBox=@HBBox, HBCenterPad=@HBCenterPad, " + _
                                        "connectionPinSCode=@connectionPinSCode, connectionBoxSCode=@connectionBoxSCode, " + _
                                        "threadLengthPinSCode=@threadLengthPinSCode, threadLengthBoxSCode=@threadLengthBoxSCode, " + _
                                        "conditionPinSCode=@conditionPinSCode, conditionBoxSCode=@conditionBoxSCode, " + _
                                        "userIDupdate=@userIDupdate, updateDate=GETDATE() " + _
                                        "WHERE inspectionReportDtID=@inspectionReportDtID"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@inspectionReportDtID", _inspectionReportDtID)                
                cmdToExecute.Parameters.AddWithValue("@description", _description)
                cmdToExecute.Parameters.AddWithValue("@serialNo", _serialNo)
                cmdToExecute.Parameters.AddWithValue("@totalLength", _totalLength)
                cmdToExecute.Parameters.AddWithValue("@connectionSizePin", _connectionSizePin)
                cmdToExecute.Parameters.AddWithValue("@connectionSizeBox", _connectionSizeBox)
                cmdToExecute.Parameters.AddWithValue("@connectionODPin", _connectionODPin)
                cmdToExecute.Parameters.AddWithValue("@connectionODBox", _connectionODBox)
                cmdToExecute.Parameters.AddWithValue("@elevatorGrooveDiaPin", _elevatorGrooveDiaPin)
                cmdToExecute.Parameters.AddWithValue("@elevatorGrooveDiaBox", _elevatorGrooveDiaBox)
                cmdToExecute.Parameters.AddWithValue("@elevatorGrooveDepthPin", _elevatorGrooveDepthPin)
                cmdToExecute.Parameters.AddWithValue("@elevatorGrooveDepthBox", _elevatorGrooveDepthBox)
                cmdToExecute.Parameters.AddWithValue("@IDdescription", _IDdescription)
                cmdToExecute.Parameters.AddWithValue("@BBackRGrooveDiaPin", _BBackRGrooveDiaPin)
                cmdToExecute.Parameters.AddWithValue("@BBackRGrooveDiaBox", _BBackRGrooveDiaBox)
                cmdToExecute.Parameters.AddWithValue("@BBackRGrooveLengthPin", _BBackRGrooveLengthPin)
                cmdToExecute.Parameters.AddWithValue("@BBackRGrooveLengthBox", _BBackRGrooveLengthBox)
                cmdToExecute.Parameters.AddWithValue("@bevelDiaPin", _bevelDiaPin)
                cmdToExecute.Parameters.AddWithValue("@bevelDiaBox", _bevelDiaBox)
                cmdToExecute.Parameters.AddWithValue("@threadLengthPin", _threadLengthPin)
                cmdToExecute.Parameters.AddWithValue("@threadLengthBox", _threadLengthBox)
                cmdToExecute.Parameters.AddWithValue("@counterBoreDiaPin", _counterBoreDiaPin)
                cmdToExecute.Parameters.AddWithValue("@counterBoreDiaBox", _counterBoreDiaBox)
                cmdToExecute.Parameters.AddWithValue("@counterBoreDepthPin", _counterBoreDepthPin)
                cmdToExecute.Parameters.AddWithValue("@counterBoreDepthBox", _counterBoreDepthBox)
                cmdToExecute.Parameters.AddWithValue("@centerPadDiaPin", _centerPadDiaPin)
                cmdToExecute.Parameters.AddWithValue("@centerPadDiaBox", _centerPadDiaBox)
                cmdToExecute.Parameters.AddWithValue("@centerPadDepthPin", _centerPadDepthPin)
                cmdToExecute.Parameters.AddWithValue("@centerPadDepthBox", _centerPadDepthBox)
                cmdToExecute.Parameters.AddWithValue("@tongSpacePin", _tongSpacePin)
                cmdToExecute.Parameters.AddWithValue("@tongSpaceBox", _tongSpaceBox)
                cmdToExecute.Parameters.AddWithValue("@conditionPin", _conditionPin)
                cmdToExecute.Parameters.AddWithValue("@conditionBox", _conditionBox)
                cmdToExecute.Parameters.AddWithValue("@BSR", _BSR)
                cmdToExecute.Parameters.AddWithValue("@remarksPin", _remarksPin)
                cmdToExecute.Parameters.AddWithValue("@remarksBox", _remarksBox)
                cmdToExecute.Parameters.AddWithValue("@HBPin", _HBPin)
                cmdToExecute.Parameters.AddWithValue("@HBBox", _HBBox)
                cmdToExecute.Parameters.AddWithValue("@HBCenterPad", _HBCenterPad)
                cmdToExecute.Parameters.AddWithValue("@connectionPinSCode", _connectionPinSCode)
                cmdToExecute.Parameters.AddWithValue("@connectionBoxSCode", _connectionBoxSCode)
                cmdToExecute.Parameters.AddWithValue("@threadLengthPinSCode", _threadLengthPinSCode)
                cmdToExecute.Parameters.AddWithValue("@threadLengthBoxSCode", _threadLengthBoxSCode)
                cmdToExecute.Parameters.AddWithValue("@conditionPinSCode", _conditionPinSCode)
                cmdToExecute.Parameters.AddWithValue("@conditionBoxSCode", _conditionBoxSCode)
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
            cmdToExecute.CommandText = "SELECT * FROM InspectionReportDt"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("InspectionReportDt")
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
            cmdToExecute.CommandText = "SELECT * FROM InspectionReportDt WHERE inspectionReportDtID=@inspectionReportDtID"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("InspectionReportDt")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@inspectionReportDtID", _inspectionReportDtID)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 Then
                    _inspectionReportHdID = CType(toReturn.Rows(0)("inspectionReportDtID"), String)
                    _inspectionReportHdID = CType(toReturn.Rows(0)("inspectionReportHdID"), String)
                    _description = CType(toReturn.Rows(0)("description"), String)
                    _serialNo = CType(toReturn.Rows(0)("serialNo"), String)
                    _totalLength = CType(toReturn.Rows(0)("totalLength"), String)
                    _connectionSizePin = CType(toReturn.Rows(0)("connectionSizePin"), String)
                    _connectionSizeBox = CType(toReturn.Rows(0)("connectionSizeBox"), String)
                    _connectionODPin = CType(toReturn.Rows(0)("connectionODPin"), String)
                    _connectionODBox = CType(toReturn.Rows(0)("connectionODBox"), String)
                    _elevatorGrooveDiaPin = CType(toReturn.Rows(0)("elevatorGrooveDiaPin"), String)
                    _elevatorGrooveDiaBox = CType(toReturn.Rows(0)("elevatorGrooveDiaBox"), String)
                    _elevatorGrooveDepthPin = CType(toReturn.Rows(0)("elevatorGrooveDepthPin"), String)
                    _elevatorGrooveDepthBox = CType(toReturn.Rows(0)("elevatorGrooveDepthBox"), String)
                    _IDdescription = CType(toReturn.Rows(0)("IDdescription"), String)
                    _BBackRGrooveDiaPin = CType(toReturn.Rows(0)("BBackRGrooveDiaPin"), String)
                    _BBackRGrooveDiaBox = CType(toReturn.Rows(0)("BBackRGrooveDiaBox"), String)
                    _BBackRGrooveLengthPin = CType(toReturn.Rows(0)("BBackRGrooveLengthPin"), String)
                    _BBackRGrooveLengthBox = CType(toReturn.Rows(0)("BBackRGrooveLengthBox"), String)
                    _bevelDiaPin = CType(toReturn.Rows(0)("bevelDiaPin"), String)
                    _bevelDiaBox = CType(toReturn.Rows(0)("bevelDiaBox"), String)
                    _threadLengthPin = CType(toReturn.Rows(0)("threadLengthPin"), String)
                    _threadLengthBox = CType(toReturn.Rows(0)("threadLengthBox"), String)
                    _counterBoreDiaPin = CType(toReturn.Rows(0)("counterBoreDiaPin"), String)
                    _counterBoreDiaBox = CType(toReturn.Rows(0)("counterBoreDiaBox"), String)
                    _counterBoreDepthPin = CType(toReturn.Rows(0)("counterBoreDepthPin"), String)
                    _counterBoreDepthBox = CType(toReturn.Rows(0)("counterBoreDepthBox"), String)
                    _centerPadDiaPin = CType(toReturn.Rows(0)("centerPadDiaPin"), String)
                    _centerPadDiaBox = CType(toReturn.Rows(0)("centerPadDiaBox"), String)
                    _centerPadDepthPin = CType(toReturn.Rows(0)("centerPadDepthPin"), String)
                    _centerPadDepthBox = CType(toReturn.Rows(0)("centerPadDepthBox"), String)
                    _tongSpacePin = CType(toReturn.Rows(0)("tongSpacePin"), String)
                    _tongSpaceBox = CType(toReturn.Rows(0)("tongSpaceBox"), String)
                    _conditionPin = CType(toReturn.Rows(0)("conditionPin"), String)
                    _conditionBox = CType(toReturn.Rows(0)("conditionBox"), String)
                    _BSR = CType(toReturn.Rows(0)("BSR"), String)
                    _remarksPin = CType(toReturn.Rows(0)("remarksPin"), String)
                    _remarksBox = CType(toReturn.Rows(0)("remarksBox"), String)
                    _HBPin = CType(toReturn.Rows(0)("HBPin"), String)
                    _HBBox = CType(toReturn.Rows(0)("HBBox"), String)
                    _HBCenterPad = CType(toReturn.Rows(0)("HBCenterPad"), String)
                    _connectionPinSCode = CType(toReturn.Rows(0)("connectionPinSCode"), String)
                    _connectionBoxSCode = CType(toReturn.Rows(0)("connectionBoxSCode"), String)
                    _threadLengthPinSCode = CType(toReturn.Rows(0)("threadLengthPinSCode"), String)
                    _threadLengthBoxSCode = CType(toReturn.Rows(0)("threadLengthBoxSCode"), String)
                    _conditionPinSCode = CType(toReturn.Rows(0)("conditionPinSCode"), String)
                    _conditionBoxSCode = CType(toReturn.Rows(0)("conditionBoxSCode"), String)
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
            cmdToExecute.CommandText = "DELETE FROM InspectionReportDt " + _
                                        "WHERE inspectionReportDtID=@inspectionReportDtID"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@inspectionReportDtID", _inspectionReportDtID)

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
            cmdToExecute.CommandText = "SELECT * " +
                                        "FROM InspectionReportDt WHERE inspectionReportHdID=@inspectionReportHdID"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("InspectionReportDt")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@inspectionReportHdID", _inspectionReportHdID)

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
        Public Property [inspectionReportDtID]() As String
            Get
                Return _inspectionReportDtID
            End Get
            Set(ByVal Value As String)
                _inspectionReportDtID = Value
            End Set
        End Property

        Public Property [inspectionReportHdID]() As String
            Get
                Return _inspectionReportHdID
            End Get
            Set(ByVal Value As String)
                _inspectionReportHdID = Value
            End Set
        End Property

        Public Property [description]() As String
            Get
                Return _description
            End Get
            Set(ByVal Value As String)
                _description = Value
            End Set
        End Property

        Public Property [serialNo]() As String
            Get
                Return _serialNo
            End Get
            Set(ByVal Value As String)
                _serialNo = Value
            End Set
        End Property

        Public Property [totalLength]() As String
            Get
                Return _totalLength
            End Get
            Set(ByVal Value As String)
                _totalLength = Value
            End Set
        End Property

        Public Property [connectionSizePin]() As String
            Get
                Return _connectionSizePin
            End Get
            Set(ByVal Value As String)
                _connectionSizePin = Value
            End Set
        End Property

        Public Property [connectionSizeBox]() As String
            Get
                Return _connectionSizeBox
            End Get
            Set(ByVal Value As String)
                _connectionSizeBox = Value
            End Set
        End Property

        Public Property [connectionODPin]() As String
            Get
                Return _connectionODPin
            End Get
            Set(ByVal Value As String)
                _connectionODPin = Value
            End Set
        End Property

        Public Property [connectionODBox]() As String
            Get
                Return _connectionODBox
            End Get
            Set(ByVal Value As String)
                _connectionODBox = Value
            End Set
        End Property

        Public Property [elevatorGrooveDiaPin]() As String
            Get
                Return _elevatorGrooveDiaPin
            End Get
            Set(ByVal Value As String)
                _elevatorGrooveDiaPin = Value
            End Set
        End Property

        Public Property [elevatorGrooveDiaBox]() As String
            Get
                Return _elevatorGrooveDiaBox
            End Get
            Set(ByVal Value As String)
                _elevatorGrooveDiaBox = Value
            End Set
        End Property

        Public Property [elevatorGrooveDepthPin]() As String
            Get
                Return _elevatorGrooveDepthPin
            End Get
            Set(ByVal Value As String)
                _elevatorGrooveDepthPin = Value
            End Set
        End Property

        Public Property [elevatorGrooveDepthBox]() As String
            Get
                Return _elevatorGrooveDepthBox
            End Get
            Set(ByVal Value As String)
                _elevatorGrooveDepthBox = Value
            End Set
        End Property

        Public Property [IDdescription]() As String
            Get
                Return _IDdescription
            End Get
            Set(ByVal Value As String)
                _IDdescription = Value
            End Set
        End Property

        Public Property [BBackRGrooveDiaPin]() As String
            Get
                Return _BBackRGrooveDiaPin
            End Get
            Set(ByVal Value As String)
                _BBackRGrooveDiaPin = Value
            End Set
        End Property

        Public Property [BBackRGrooveDiaBox]() As String
            Get
                Return _BBackRGrooveDiaBox
            End Get
            Set(ByVal Value As String)
                _BBackRGrooveDiaBox = Value
            End Set
        End Property

        Public Property [BBackRGrooveLengthPin]() As String
            Get
                Return _BBackRGrooveLengthPin
            End Get
            Set(ByVal Value As String)
                _BBackRGrooveLengthPin = Value
            End Set
        End Property

        Public Property [BBackRGrooveLengthBox]() As String
            Get
                Return _BBackRGrooveLengthBox
            End Get
            Set(ByVal Value As String)
                _BBackRGrooveLengthBox = Value
            End Set
        End Property

        Public Property [bevelDiaPin]() As String
            Get
                Return _bevelDiaPin
            End Get
            Set(ByVal Value As String)
                _bevelDiaPin = Value
            End Set
        End Property

        Public Property [bevelDiaBox]() As String
            Get
                Return _bevelDiaBox
            End Get
            Set(ByVal Value As String)
                _bevelDiaBox = Value
            End Set
        End Property

        Public Property [threadLengthPin]() As String
            Get
                Return _threadLengthPin
            End Get
            Set(ByVal Value As String)
                _threadLengthPin = Value
            End Set
        End Property

        Public Property [threadLengthBox]() As String
            Get
                Return _threadLengthBox
            End Get
            Set(ByVal Value As String)
                _threadLengthBox = Value
            End Set
        End Property

        Public Property [counterBoreDiaPin]() As String
            Get
                Return _counterBoreDiaPin
            End Get
            Set(ByVal Value As String)
                _counterBoreDiaPin = Value
            End Set
        End Property

        Public Property [counterBoreDiaBox]() As String
            Get
                Return _counterBoreDiaBox
            End Get
            Set(ByVal Value As String)
                _counterBoreDiaBox = Value
            End Set
        End Property

        Public Property [counterBoreDepthPin]() As String
            Get
                Return _counterBoreDepthPin
            End Get
            Set(ByVal Value As String)
                _counterBoreDepthPin = Value
            End Set
        End Property

        Public Property [counterBoreDepthBox]() As String
            Get
                Return _counterBoreDepthBox
            End Get
            Set(ByVal Value As String)
                _counterBoreDepthBox = Value
            End Set
        End Property

        Public Property [centerPadDiaPin]() As String
            Get
                Return _centerPadDiaPin
            End Get
            Set(ByVal Value As String)
                _centerPadDiaPin = Value
            End Set
        End Property

        Public Property [centerPadDiaBox]() As String
            Get
                Return _centerPadDiaBox
            End Get
            Set(ByVal Value As String)
                _centerPadDiaBox = Value
            End Set
        End Property

        Public Property [centerPadDepthPin]() As String
            Get
                Return _centerPadDepthPin
            End Get
            Set(ByVal Value As String)
                _centerPadDepthPin = Value
            End Set
        End Property

        Public Property [centerPadDepthBox]() As String
            Get
                Return _centerPadDepthBox
            End Get
            Set(ByVal Value As String)
                _centerPadDepthBox = Value
            End Set
        End Property

        Public Property [tongSpacePin]() As String
            Get
                Return _tongSpacePin
            End Get
            Set(ByVal Value As String)
                _tongSpacePin = Value
            End Set
        End Property

        Public Property [tongSpaceBox]() As String
            Get
                Return _tongSpaceBox
            End Get
            Set(ByVal Value As String)
                _tongSpaceBox = Value
            End Set
        End Property

        Public Property [conditionPin]() As String
            Get
                Return _conditionPin
            End Get
            Set(ByVal Value As String)
                _conditionPin = Value
            End Set
        End Property

        Public Property [conditionBox]() As String
            Get
                Return _conditionBox
            End Get
            Set(ByVal Value As String)
                _conditionBox = Value
            End Set
        End Property

        Public Property [BSR]() As String
            Get
                Return _BSR
            End Get
            Set(ByVal Value As String)
                _BSR = Value
            End Set
        End Property

        Public Property [remarksPin]() As String
            Get
                Return _remarksPin
            End Get
            Set(ByVal Value As String)
                _remarksPin = Value
            End Set
        End Property

        Public Property [remarksBox]() As String
            Get
                Return _remarksBox
            End Get
            Set(ByVal Value As String)
                _remarksBox = Value
            End Set
        End Property

        Public Property [HBPin]() As String
            Get
                Return _HBPin
            End Get
            Set(ByVal Value As String)
                _HBPin = Value
            End Set
        End Property

        Public Property [HBBox]() As String
            Get
                Return _HBBox
            End Get
            Set(ByVal Value As String)
                _HBBox = Value
            End Set
        End Property

        Public Property [HBCenterPad]() As String
            Get
                Return _HBCenterPad
            End Get
            Set(ByVal Value As String)
                _HBCenterPad = Value
            End Set
        End Property

        Public Property [ConnectionPinSCode]() As String
            Get
                Return _connectionPinSCode
            End Get
            Set(ByVal Value As String)
                _connectionPinSCode = Value
            End Set
        End Property

        Public Property [ConnectionBoxSCode]() As String
            Get
                Return _connectionBoxSCode
            End Get
            Set(ByVal Value As String)
                _connectionBoxSCode = Value
            End Set
        End Property

        Public Property [ThreadLengthPinSCode]() As String
            Get
                Return _threadLengthPinSCode
            End Get
            Set(ByVal Value As String)
                _threadLengthPinSCode = Value
            End Set
        End Property

        Public Property [ThreadLengthBoxSCode]() As String
            Get
                Return _threadLengthBoxSCode
            End Get
            Set(ByVal Value As String)
                _threadLengthBoxSCode = Value
            End Set
        End Property

        Public Property [ConditionPinSCode]() As String
            Get
                Return _conditionPinSCode
            End Get
            Set(ByVal Value As String)
                _conditionPinSCode = Value
            End Set
        End Property

        Public Property [ConditionBoxSCode]() As String
            Get
                Return _conditionBoxSCode
            End Get
            Set(ByVal Value As String)
                _conditionBoxSCode = Value
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
