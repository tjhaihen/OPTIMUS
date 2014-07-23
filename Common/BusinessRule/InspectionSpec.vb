Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports Raven.Common

Namespace Raven.Common.BussinessRules
    Public Class InspectionSpec
        Inherits BRInteractionBase

#Region " Class Member Declarations "
        Private _inspectionSpecID, _inspectionSpecCode, _inspectionSpecName As String
        Private _size, _weight, _connection, _grade, _range, _nominalWT As String
        Private _minODpremium, _maxIDpremium, _minWallpremium, _minShldrpremium, _minSealpremium, _minBevelDiapremium As String
        Private _minODclass2, _maxIDclass2, _minWallclass2, _minShldrclass2, _minSealclass2, _minTongSpacePinclass2, _minTongSpaceBoxclass2, _
                    _minQCDepthclass2, _maxQCclass2, _minBevelDiaclass2, _maxBevelDiaclass2, _maxLengthPinclass2, _
                    _maxPinNeckclass2, _maxCBoreclass2 As String
        Private _userIDinsert, _userIDupdate As String
        Private _insertDate, _updateDate As DateTime
        Private _isActive As Boolean
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
            cmdToExecute.CommandText = "INSERT INTO InspectionSpec " + _
                                        "(inspectionSpecID, inspectionSpecCode, inspectionSpecName, minODpremium, maxIDpremium, " + _
                                        "minWallpremium, minShldrpremium, minSealpremium, minBevelDiapremium, " + _
                                        "size, weight, connection, grade, range, nominalWT, " + _
                                        "minODclass2, maxIDclass2, minWallclass2, minShldrclass2, minSealclass2, " + _
                                        "minTongSpacePinclass2, minTongSpaceBoxclass2, minQCDepthclass2, maxQCclass2, " + _
                                        "minbevelDiaclass2, maxbevelDiaclass2, maxLengthPinclass2, maxPinNeckclass2, " + _
                                        "maxCBoreclass2, isActive, userIDinsert, userIDupdate, insertDate, updateDate) " + _
                                        "VALUES " + _
                                        "(@inspectionSpecID, @inspectionSpecCode, @inspectionSpecName, @minODpremium, @maxIDpremium, " + _
                                        "@minWallpremium, @minShldrpremium, @minSealpremium, @minBevelDiapremium, " + _
                                        "@size, @weight, @connection, @grade, @range, @nominalWT, " + _
                                        "@minODclass2, @maxIDclass2, @minWallclass2, @minShldrclass2, @minSealclass2, " + _
                                        "@minTongSpacePinclass2, @minTongSpaceBoxclass2, @minQCDepthclass2, @maxQCclass2, " + _
                                        "@minbevelDiaclass2, @maxbevelDiaclass2, @maxLengthPinclass2, @maxPinNeckclass2, " + _
                                        "@maxCBoreclass2, @isActive, @userIDinsert, @userIDupdate, GETDATE(), GETDATE())"
            cmdToExecute.CommandType = CommandType.Text
            cmdToExecute.Connection = _mainConnection

            Dim strInspectionSpecID As String = ID.GenerateIDNumber("InspectionSpec", "inspectionSpecID")

            Try
                cmdToExecute.Parameters.AddWithValue("@inspectionSpecID", strInspectionSpecID)
                cmdToExecute.Parameters.AddWithValue("@inspectionSpecCode", _inspectionSpecCode)
                cmdToExecute.Parameters.AddWithValue("@inspectionSpecName", _inspectionSpecName)
                cmdToExecute.Parameters.AddWithValue("@size", _size)
                cmdToExecute.Parameters.AddWithValue("@weight", _weight)
                cmdToExecute.Parameters.AddWithValue("@connection", _connection)
                cmdToExecute.Parameters.AddWithValue("@grade", _grade)
                cmdToExecute.Parameters.AddWithValue("@range", _range)
                cmdToExecute.Parameters.AddWithValue("@nominalWT", _nominalWT)
                cmdToExecute.Parameters.AddWithValue("@minODpremium", _minODpremium)
                cmdToExecute.Parameters.AddWithValue("@maxIDpremium", _maxIDpremium)
                cmdToExecute.Parameters.AddWithValue("@minWallpremium", _minWallpremium)
                cmdToExecute.Parameters.AddWithValue("@minShldrpremium", _minShldrpremium)
                cmdToExecute.Parameters.AddWithValue("@minSealpremium", _minSealpremium)
                cmdToExecute.Parameters.AddWithValue("@minBevelDiapremium", _minBevelDiapremium)
                cmdToExecute.Parameters.AddWithValue("@minODclass2", _minODclass2)
                cmdToExecute.Parameters.AddWithValue("@maxIDclass2", _maxIDclass2)
                cmdToExecute.Parameters.AddWithValue("@minWallclass2", _minWallclass2)
                cmdToExecute.Parameters.AddWithValue("@minShldrclass2", _minShldrclass2)
                cmdToExecute.Parameters.AddWithValue("@minSealclass2", _minSealclass2)
                cmdToExecute.Parameters.AddWithValue("@minTongSpacePinclass2", _minTongSpacePinclass2)
                cmdToExecute.Parameters.AddWithValue("@minTongSpaceBoxclass2", _minTongSpaceBoxclass2)
                cmdToExecute.Parameters.AddWithValue("@minQCDepthclass2", _minQCDepthclass2)
                cmdToExecute.Parameters.AddWithValue("@maxQCclass2", _maxQCclass2)
                cmdToExecute.Parameters.AddWithValue("@minBevelDiaclass2", _minBevelDiaclass2)
                cmdToExecute.Parameters.AddWithValue("@maxBevelDiaclass2", _maxBevelDiaclass2)
                cmdToExecute.Parameters.AddWithValue("@maxLengthPinclass2", _maxLengthPinclass2)
                cmdToExecute.Parameters.AddWithValue("@maxPinNeckclass2", _maxPinNeckclass2)
                cmdToExecute.Parameters.AddWithValue("@maxCBoreclass2", _maxCBoreclass2)
                cmdToExecute.Parameters.AddWithValue("@isActive", _isActive)
                cmdToExecute.Parameters.AddWithValue("@userIDinsert", _userIDinsert)
                cmdToExecute.Parameters.AddWithValue("@userIDupdate", _userIDupdate)

                ' // Open Connection
                _mainConnection.Open()

                ' // Execute Query
                cmdToExecute.ExecuteNonQuery()

                _inspectionSpecID = strInspectionSpecID
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
            cmdToExecute.CommandText = "UPDATE InspectionSpec " + _
                                        "SET inspectionSpecName=@inspectionSpecName, minODpremium=@minODpremium, maxIDpremium=@maxIDpremium, minWallpremium=@minWallpremium, " + _
                                        "size=@size, weight=@weight, connection=@connection, grade=@grade, range=@range, nominalWT=@nominalWT, " + _
                                        "minShldrpremium=@minShldrpremium, minSealpremium=@minSealpremium, minBevelDiapremium=@minBevelDiapremium, minODclass2=@minODclass2, " +
                                        "maxIDclass2=@maxIDclass2, minWallclass2=@minWallclass2, minShldrclass2=@minShldrclass2, minSealclass2=@minSealclass2, " + _
                                        "minTongSpacePinclass2=@minTongSpacePinclass2, minTongSpaceBoxclass2=@minTongSpaceBoxclass2, minQCDepthclass2=@minQCDepthclass2, " + _
                                        "maxQCclass2=@maxQCclass2, minBevelDiaclass2=@minBevelDiaclass2, maxBevelDiaclass2=@maxBevelDiaclass2, " + _
                                        "maxLengthPinclass2=@maxLengthPinclass2, maxPinNeckclass2=@maxPinNeckclass2, maxCBoreclass2=@maxCBoreclass2, " + _
                                        "isActive=@isActive, userIDupdate=@userIDupdate, updateDate=GETDATE() " + _
                                        "WHERE inspectionSpecID=@inspectionSpecID"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@inspectionSpecID", _inspectionSpecID)
                cmdToExecute.Parameters.AddWithValue("@inspectionSpecCode", _inspectionSpecCode)
                cmdToExecute.Parameters.AddWithValue("@inspectionSpecName", _inspectionSpecName)
                cmdToExecute.Parameters.AddWithValue("@size", _size)
                cmdToExecute.Parameters.AddWithValue("@weight", _weight)
                cmdToExecute.Parameters.AddWithValue("@connection", _connection)
                cmdToExecute.Parameters.AddWithValue("@grade", _grade)
                cmdToExecute.Parameters.AddWithValue("@range", _range)
                cmdToExecute.Parameters.AddWithValue("@nominalWT", _nominalWT)
                cmdToExecute.Parameters.AddWithValue("@minODpremium", _minODpremium)
                cmdToExecute.Parameters.AddWithValue("@maxIDpremium", _maxIDpremium)
                cmdToExecute.Parameters.AddWithValue("@minWallpremium", _minWallpremium)
                cmdToExecute.Parameters.AddWithValue("@minShldrpremium", _minShldrpremium)
                cmdToExecute.Parameters.AddWithValue("@minSealpremium", _minSealpremium)
                cmdToExecute.Parameters.AddWithValue("@minBevelDiapremium", _minBevelDiapremium)
                cmdToExecute.Parameters.AddWithValue("@minODclass2", _minODclass2)
                cmdToExecute.Parameters.AddWithValue("@maxIDclass2", _maxIDclass2)
                cmdToExecute.Parameters.AddWithValue("@minWallclass2", _minWallclass2)
                cmdToExecute.Parameters.AddWithValue("@minShldrclass2", _minShldrclass2)
                cmdToExecute.Parameters.AddWithValue("@minSealclass2", _minSealclass2)
                cmdToExecute.Parameters.AddWithValue("@minTongSpacePinclass2", _minTongSpacePinclass2)
                cmdToExecute.Parameters.AddWithValue("@minTongSpaceBoxclass2", _minTongSpaceBoxclass2)
                cmdToExecute.Parameters.AddWithValue("@minQCDepthclass2", _minQCDepthclass2)
                cmdToExecute.Parameters.AddWithValue("@maxQCclass2", _maxQCclass2)
                cmdToExecute.Parameters.AddWithValue("@minBevelDiaclass2", _minBevelDiaclass2)
                cmdToExecute.Parameters.AddWithValue("@maxBevelDiaclass2", _maxBevelDiaclass2)
                cmdToExecute.Parameters.AddWithValue("@maxLengthPinclass2", _maxLengthPinclass2)
                cmdToExecute.Parameters.AddWithValue("@maxPinNeckclass2", _maxPinNeckclass2)
                cmdToExecute.Parameters.AddWithValue("@maxCBoreclass2", _maxCBoreclass2)
                cmdToExecute.Parameters.AddWithValue("@isActive", _isActive)                
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
            cmdToExecute.CommandText = "SELECT * FROM InspectionSpec"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("InspectionSpec")
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
            cmdToExecute.CommandText = "SELECT * FROM InspectionSpec WHERE inspectionSpecID=@inspectionSpecID"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("InspectionSpec")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@inspectionSpecID", _inspectionSpecID)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 Then
                    _inspectionSpecID = CType(toReturn.Rows(0)("inspectionSpecID"), String)
                    _inspectionSpecCode = CType(toReturn.Rows(0)("inspectionSpecCode"), String)
                    _inspectionSpecName = CType(toReturn.Rows(0)("inspectionSpecName"), String)
                    _size = CType(toReturn.Rows(0)("size"), String)
                    _weight = CType(toReturn.Rows(0)("weight"), String)
                    _connection = CType(toReturn.Rows(0)("connection"), String)
                    _grade = CType(toReturn.Rows(0)("grade"), String)
                    _range = CType(toReturn.Rows(0)("range"), String)
                    _nominalWT = CType(toReturn.Rows(0)("nominalWT"), String)
                    _minODpremium = CType(toReturn.Rows(0)("minODpremium"), String)
                    _maxIDpremium = CType(toReturn.Rows(0)("maxIDpremium"), String)
                    _minWallpremium = CType(toReturn.Rows(0)("minWallpremium"), String)
                    _minShldrpremium = CType(toReturn.Rows(0)("minShldrpremium"), String)
                    _minSealpremium = CType(toReturn.Rows(0)("minSealpremium"), String)
                    _minBevelDiapremium = CType(toReturn.Rows(0)("minBevelDiapremium"), String)
                    _minODclass2 = CType(toReturn.Rows(0)("minODclass2"), String)
                    _maxIDclass2 = CType(toReturn.Rows(0)("maxIDclass2"), String)
                    _minWallclass2 = CType(toReturn.Rows(0)("minWallclass2"), String)
                    _minShldrclass2 = CType(toReturn.Rows(0)("minShldrclass2"), String)
                    _minSealclass2 = CType(toReturn.Rows(0)("minSealclass2"), String)
                    _minTongSpacePinclass2 = CType(toReturn.Rows(0)("minTongSpacePinclass2"), String)
                    _minTongSpaceBoxclass2 = CType(toReturn.Rows(0)("minTongSpaceBoxclass2"), String)
                    _minQCDepthclass2 = CType(toReturn.Rows(0)("minQCDepthclass2"), String)
                    _maxQCclass2 = CType(toReturn.Rows(0)("maxQCclass2"), String)
                    _minBevelDiaclass2 = CType(toReturn.Rows(0)("minBevelDiaclass2"), String)
                    _maxBevelDiaclass2 = CType(toReturn.Rows(0)("maxBevelDiaclass2"), String)
                    _maxLengthPinclass2 = CType(toReturn.Rows(0)("maxLengthPinclass2"), String)
                    _maxPinNeckclass2 = CType(toReturn.Rows(0)("maxPinNeckclass2"), String)
                    _maxCBoreclass2 = CType(toReturn.Rows(0)("maxCBoreclass2"), String)
                    _isActive = CType(toReturn.Rows(0)("isActive"), Boolean)
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
            cmdToExecute.CommandText = "DELETE FROM InspectionSpec " + _
                                        "WHERE inspectionSpecID=@inspectionSpecID"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@inspectionSpecID", _inspectionSpecID)

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

#Region " Custom "
        Public Function SelectForInspectionReport() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "SELECT * FROM InspectionSpec WHERE inspectionSpecID=@inspectionSpecID AND " + _
                                        "size=@size AND weight=@weight AND connection=@connection AND range=@range " + _
                                        "AND grade=@grade AND nominalWT=@nominalWT "
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("InspectionSpec")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@inspectionSpecID", _inspectionSpecID)
                cmdToExecute.Parameters.AddWithValue("@size", _size)
                cmdToExecute.Parameters.AddWithValue("@weight", _weight)
                cmdToExecute.Parameters.AddWithValue("@connection", _connection)
                cmdToExecute.Parameters.AddWithValue("@grade", _grade)
                cmdToExecute.Parameters.AddWithValue("@range", _range)
                cmdToExecute.Parameters.AddWithValue("@nominalWT", _nominalWT)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 Then
                    _inspectionSpecID = CType(toReturn.Rows(0)("inspectionSpecID"), String)
                    _inspectionSpecCode = CType(toReturn.Rows(0)("inspectionSpecCode"), String)
                    _inspectionSpecName = CType(toReturn.Rows(0)("inspectionSpecName"), String)
                    _minODpremium = CType(toReturn.Rows(0)("minODpremium"), String)
                    _maxIDpremium = CType(toReturn.Rows(0)("maxIDpremium"), String)
                    _minWallpremium = CType(toReturn.Rows(0)("minWallpremium"), String)
                    _minShldrpremium = CType(toReturn.Rows(0)("minShldrpremium"), String)
                    _minSealpremium = CType(toReturn.Rows(0)("minSealpremium"), String)
                    _minBevelDiapremium = CType(toReturn.Rows(0)("minBevelDiapremium"), String)
                    _minODclass2 = CType(toReturn.Rows(0)("minODclass2"), String)
                    _maxIDclass2 = CType(toReturn.Rows(0)("maxIDclass2"), String)
                    _minWallclass2 = CType(toReturn.Rows(0)("minWallclass2"), String)
                    _minShldrclass2 = CType(toReturn.Rows(0)("minShldrclass2"), String)
                    _minSealclass2 = CType(toReturn.Rows(0)("minSealclass2"), String)
                    _minTongSpacePinclass2 = CType(toReturn.Rows(0)("minTongSpacePinclass2"), String)
                    _minTongSpaceBoxclass2 = CType(toReturn.Rows(0)("minTongSpaceBoxclass2"), String)
                    _minQCDepthclass2 = CType(toReturn.Rows(0)("minQCDepthclass2"), String)
                    _maxQCclass2 = CType(toReturn.Rows(0)("maxQCclass2"), String)
                    _minBevelDiaclass2 = CType(toReturn.Rows(0)("minBevelDiaclass2"), String)
                    _maxBevelDiaclass2 = CType(toReturn.Rows(0)("maxBevelDiaclass2"), String)
                    _maxLengthPinclass2 = CType(toReturn.Rows(0)("maxLengthPinclass2"), String)
                    _maxPinNeckclass2 = CType(toReturn.Rows(0)("maxPinNeckclass2"), String)
                    _maxCBoreclass2 = CType(toReturn.Rows(0)("maxCBoreclass2"), String)
                    _isActive = CType(toReturn.Rows(0)("isActive"), Boolean)
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
#End Region

#Region " Class Property Declarations "
        Public Property [inspectionSpecID]() As String
            Get
                Return _inspectionSpecID
            End Get
            Set(ByVal Value As String)
                _inspectionSpecID = Value
            End Set
        End Property

        Public Property [inspectionSpecCode]() As String
            Get
                Return _inspectionSpecCode
            End Get
            Set(ByVal Value As String)
                _inspectionSpecCode = Value
            End Set
        End Property

        Public Property [inspectionSpecName]() As String
            Get
                Return _inspectionSpecName
            End Get
            Set(ByVal Value As String)
                _inspectionSpecName = Value
            End Set
        End Property

        Public Property [size]() As String
            Get
                Return _size
            End Get
            Set(ByVal Value As String)
                _size = Value
            End Set
        End Property

        Public Property [weight]() As String
            Get
                Return _weight
            End Get
            Set(ByVal Value As String)
                _weight = Value
            End Set
        End Property

        Public Property [connection]() As String
            Get
                Return _connection
            End Get
            Set(ByVal Value As String)
                _connection = Value
            End Set
        End Property

        Public Property [grade]() As String
            Get
                Return _grade
            End Get
            Set(ByVal Value As String)
                _grade = Value
            End Set
        End Property

        Public Property [range]() As String
            Get
                Return _range
            End Get
            Set(ByVal Value As String)
                _range = Value
            End Set
        End Property

        Public Property [nominalWT] As String
            Get
                Return _nominalWT
            End Get
            Set(ByVal Value As String)
                _nominalWT = Value
            End Set
        End Property

        Public Property [minODpremium]() As String
            Get
                Return _minODpremium
            End Get
            Set(ByVal Value As String)
                _minODpremium = Value
            End Set
        End Property

        Public Property [maxIDpremium]() As String
            Get
                Return _maxIDpremium
            End Get
            Set(ByVal Value As String)
                _maxIDpremium = Value
            End Set
        End Property

        Public Property [minWallpremium]() As String
            Get
                Return _minWallpremium
            End Get
            Set(ByVal Value As String)
                _minWallpremium = Value
            End Set
        End Property

        Public Property [minShldrpremium]() As String
            Get
                Return _minShldrpremium
            End Get
            Set(ByVal Value As String)
                _minShldrpremium = Value
            End Set
        End Property

        Public Property [minSealpremium]() As String
            Get
                Return _minSealpremium
            End Get
            Set(ByVal Value As String)
                _minSealpremium = Value
            End Set
        End Property

        Public Property [minBevelDiapremium]() As String
            Get
                Return _minBevelDiapremium
            End Get
            Set(ByVal Value As String)
                _minBevelDiapremium = Value
            End Set
        End Property

        Public Property [minODclass2]() As String
            Get
                Return _minODclass2
            End Get
            Set(ByVal Value As String)
                _minODclass2 = Value
            End Set
        End Property

        Public Property [maxIDclass2]() As String
            Get
                Return _maxIDclass2
            End Get
            Set(ByVal Value As String)
                _maxIDclass2 = Value
            End Set
        End Property

        Public Property [minWallclass2]() As String
            Get
                Return _minWallclass2
            End Get
            Set(ByVal Value As String)
                _minWallclass2 = Value
            End Set
        End Property

        Public Property [minShldrclass2]() As String
            Get
                Return _minShldrclass2
            End Get
            Set(ByVal Value As String)
                _minShldrclass2 = Value
            End Set
        End Property

        Public Property [minSealclass2]() As String
            Get
                Return _minSealclass2
            End Get
            Set(ByVal Value As String)
                _minSealclass2 = Value
            End Set
        End Property

        Public Property [minTongSpacePinclass2]() As String
            Get
                Return _minTongSpacePinclass2
            End Get
            Set(ByVal Value As String)
                _minTongSpacePinclass2 = Value
            End Set
        End Property

        Public Property [minTongSpaceBoxclass2]() As String
            Get
                Return _minTongSpaceBoxclass2
            End Get
            Set(ByVal Value As String)
                _minTongSpaceBoxclass2 = Value
            End Set
        End Property

        Public Property [minQCDepthclass2]() As String
            Get
                Return _minQCDepthclass2
            End Get
            Set(ByVal Value As String)
                _minQCDepthclass2 = Value
            End Set
        End Property

        Public Property [maxQCclass2]() As String
            Get
                Return _maxQCclass2
            End Get
            Set(ByVal Value As String)
                _maxQCclass2 = Value
            End Set
        End Property

        Public Property [minBevelDiaclass2]() As String
            Get
                Return _minBevelDiaclass2
            End Get
            Set(ByVal Value As String)
                _minBevelDiaclass2 = Value
            End Set
        End Property

        Public Property [maxBevelDiaclass2]() As String
            Get
                Return _maxBevelDiaclass2
            End Get
            Set(ByVal Value As String)
                _maxBevelDiaclass2 = Value
            End Set
        End Property

        Public Property [maxLengthPinclass2]() As String
            Get
                Return _maxLengthPinclass2
            End Get
            Set(ByVal Value As String)
                _maxLengthPinclass2 = Value
            End Set
        End Property

        Public Property [maxPinNeckclass2]() As String
            Get
                Return _maxPinNeckclass2
            End Get
            Set(ByVal Value As String)
                _maxPinNeckclass2 = Value
            End Set
        End Property

        Public Property [maxCBoreclass2]() As String
            Get
                Return _maxCBoreclass2
            End Get
            Set(ByVal Value As String)
                _maxCBoreclass2 = Value
            End Set
        End Property

        Public Property [isActive]() As Boolean
            Get
                Return _isActive
            End Get
            Set(ByVal Value As Boolean)
                _isActive = Value
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
