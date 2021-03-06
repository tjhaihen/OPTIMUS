﻿Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports Raven.Common

Namespace Raven.Common.BussinessRules
    Public Class UTSpotCheckHd
        Inherits BRInteractionBase

#Region " Class Member Declarations "
        Private _UTSpotCheckHdID, _projectID, _reportNo, _nominalWT, _minimalWT As String
        Private _UTSpotTypeSCode, _serialNo, _description, _material, _equipment, _couplant, _probeType, _impactDevice, _
                    _referenceLevel, _frequency, _calReference As String
        Private _isUTSpotArea, _isAreaSpotCylinder, _isAreaSpotSquare As Boolean
        Private _reportDate, _insertDate, _updateDate As DateTime
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
            cmdToExecute.CommandText = "INSERT INTO UTSpotCheckHd " + _
                                        "(UTSpotCheckHdID, projectID, reportNo, nominalWT, minimalWT, " + _
                                        "UTSpotTypeSCode, serialNo, description, material, equipment, couplant, probeType, impactDevice, " + _
                                        "referenceLevel, frequency, calReference, " + _
                                        "reportDate, insertDate, updateDate, " + _
                                        "userIDInsert, userIDUpdate, isUTSpotArea, isAreaSpotCylinder, isAreaSpotSquare) " + _
                                        "VALUES " + _
                                        "(@UTSpotCheckHdID, @projectID, @reportNo, @nominalWT, @minimalWT, " + _
                                        "@UTSpotTypeSCode, @serialNo, @description, @material, @equipment, @couplant, @probeType, @impactDevice, " + _
                                        "@referenceLevel, @frequency, @calReference, " + _
                                        "@reportDate, GETDATE(), GETDATE(), " + _
                                        "@userIDInsert, @userIDUpdate, @isUTSpotArea, @isAreaSpotCylinder, @isAreaSpotSquare)"
            cmdToExecute.CommandType = CommandType.Text
            cmdToExecute.Connection = _mainConnection

            Dim strID As String = ID.GenerateIDNumber("UTSpotCheckHd", "UTSpotCheckHdID")

            Try
                cmdToExecute.Parameters.AddWithValue("@UTSpotCheckHdID", strID)
                cmdToExecute.Parameters.AddWithValue("@projectID", _projectID)
                cmdToExecute.Parameters.AddWithValue("@reportNo", _reportNo)
                cmdToExecute.Parameters.AddWithValue("@nominalWT", _nominalWT)
                cmdToExecute.Parameters.AddWithValue("@minimalWT", _minimalWT)
                cmdToExecute.Parameters.AddWithValue("@UTSpotTypeSCode", _UTSpotTypeSCode)
                cmdToExecute.Parameters.AddWithValue("@serialNo", _serialNo)
                cmdToExecute.Parameters.AddWithValue("@description", _description)
                cmdToExecute.Parameters.AddWithValue("@material", _material)
                cmdToExecute.Parameters.AddWithValue("@equipment", _equipment)
                cmdToExecute.Parameters.AddWithValue("@couplant", _couplant)
                cmdToExecute.Parameters.AddWithValue("@probeType", _probeType)
                cmdToExecute.Parameters.AddWithValue("@impactDevice", _impactDevice)
                cmdToExecute.Parameters.AddWithValue("@referenceLevel", _referenceLevel)
                cmdToExecute.Parameters.AddWithValue("@frequency", _frequency)
                cmdToExecute.Parameters.AddWithValue("@calReference", _calReference)
                cmdToExecute.Parameters.AddWithValue("@reportDate", _reportDate)
                cmdToExecute.Parameters.AddWithValue("@userIDinsert", _userIDinsert)
                cmdToExecute.Parameters.AddWithValue("@userIDupdate", _userIDUpdate)
                cmdToExecute.Parameters.AddWithValue("@isUTSpotArea", _isUTSpotArea)
                cmdToExecute.Parameters.AddWithValue("@isAreaSpotCylinder", _isAreaSpotCylinder)
                cmdToExecute.Parameters.AddWithValue("@isAreaSpotSquare", _isAreaSpotSquare)

                ' // Open Connection
                _mainConnection.Open()

                ' // Execute Query
                cmdToExecute.ExecuteNonQuery()

                _UTSpotCheckHdID = strID
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
            cmdToExecute.CommandText = "UPDATE UTSpotCheckHd " + _
                                        "SET reportNo=@reportNo, reportDate=@reportDate, " + _
                                        "nominalWT=@nominalWT, minimalWT=@minimalWT, " + _
                                        "UTSpotTypeSCode=@UTSpotTypeSCode, serialNo=@serialNo, description=@description, " + _
                                        "material=@material, equipment=@equipment, couplant=@couplant, probeType=@probeType, " + _
                                        "impactDevice=@impactDevice, referenceLevel=@referenceLevel, frequency=@frequency, calReference=@calReference, " + _
                                        "isAreaSpotCylinder=@isAreaSpotCylinder, isAreaSpotSquare=@isAreaSpotSquare, " + _
                                        "userIDupdate=@userIDupdate, updateDate=GETDATE() " + _
                                        "WHERE UTSpotCheckHdID=@UTSpotCheckHdID"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@UTSpotCheckHdID", _UTSpotCheckHdID)
                cmdToExecute.Parameters.AddWithValue("@reportNo", _reportNo)
                cmdToExecute.Parameters.AddWithValue("@nominalWT", _nominalWT)
                cmdToExecute.Parameters.AddWithValue("@minimalWT", _minimalWT)
                cmdToExecute.Parameters.AddWithValue("@UTSpotTypeSCode", _UTSpotTypeSCode)
                cmdToExecute.Parameters.AddWithValue("@serialNo", _serialNo)
                cmdToExecute.Parameters.AddWithValue("@description", _description)
                cmdToExecute.Parameters.AddWithValue("@material", _material)
                cmdToExecute.Parameters.AddWithValue("@equipment", _equipment)
                cmdToExecute.Parameters.AddWithValue("@couplant", _couplant)
                cmdToExecute.Parameters.AddWithValue("@probeType", _probeType)
                cmdToExecute.Parameters.AddWithValue("@impactDevice", _impactDevice)
                cmdToExecute.Parameters.AddWithValue("@referenceLevel", _referenceLevel)
                cmdToExecute.Parameters.AddWithValue("@frequency", _frequency)
                cmdToExecute.Parameters.AddWithValue("@calReference", _calReference)
                cmdToExecute.Parameters.AddWithValue("@reportDate", _reportDate)
                cmdToExecute.Parameters.AddWithValue("@userIDupdate", _userIDUpdate)
                cmdToExecute.Parameters.AddWithValue("@isAreaSpotCylinder", _isAreaSpotCylinder)
                cmdToExecute.Parameters.AddWithValue("@isAreaSpotSquare", _isAreaSpotSquare)

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
            cmdToExecute.CommandText = "SELECT * FROM UTSpotCheckHd"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("UTSpotCheckHd")
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
            cmdToExecute.CommandText = "SELECT * FROM UTSpotCheckHd WHERE UTSpotCheckHdID=@UTSpotCheckHdID"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("UTSpotCheckHd")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@UTSpotCheckHdID", _UTSpotCheckHdID)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 Then
                    _UTSpotCheckHdID = CType(toReturn.Rows(0)("UTSpotCheckHdID"), String)
                    _projectID = CType(toReturn.Rows(0)("projectID"), String)
                    _reportNo = CType(toReturn.Rows(0)("reportNo"), String)
                    _nominalWT = CType(toReturn.Rows(0)("nominalWT"), String)
                    _minimalWT = CType(toReturn.Rows(0)("minimalWT"), String)
                    _UTSpotTypeSCode = CType(toReturn.Rows(0)("UTSpotTypeSCode"), String)
                    _serialNo = CType(toReturn.Rows(0)("serialNo"), String)
                    _description = CType(toReturn.Rows(0)("description"), String)
                    _material = CType(toReturn.Rows(0)("material"), String)
                    _equipment = CType(toReturn.Rows(0)("equipment"), String)
                    _couplant = CType(toReturn.Rows(0)("couplant"), String)
                    _probeType = CType(toReturn.Rows(0)("probeType"), String)
                    _impactDevice = CType(toReturn.Rows(0)("impactDevice"), String)
                    _referenceLevel = CType(toReturn.Rows(0)("referenceLevel"), String)
                    _frequency = CType(toReturn.Rows(0)("frequency"), String)
                    _calReference = CType(toReturn.Rows(0)("calReference"), String)
                    _reportDate = CType(toReturn.Rows(0)("reportDate"), DateTime)
                    _userIDInsert = CType(toReturn.Rows(0)("userIDinsert"), String)
                    _userIDUpdate = CType(toReturn.Rows(0)("userIDupdate"), String)
                    _insertDate = CType(toReturn.Rows(0)("insertDate"), DateTime)
                    _updateDate = CType(toReturn.Rows(0)("updateDate"), DateTime)
                    _isUTSpotArea = CType(toReturn.Rows(0)("isUTSpotArea"), Boolean)
                    _isAreaSpotCylinder = CType(toReturn.Rows(0)("isAreaSpotCylinder"), Boolean)
                    _isAreaSpotSquare = CType(toReturn.Rows(0)("isAreaSpotSquare"), Boolean)
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
            cmdToExecute.CommandText = "DELETE FROM UTSpotCheckHd " + _
                                        "WHERE UTSpotCheckHdID=@UTSpotCheckHdID"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@UTSpotCheckHdID", _UTSpotCheckHdID)

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
        Public Function SelectByProjectID() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "SELECT * " +
                                        "FROM UTSpotCheckHd WHERE projectID=@projectID"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("UTSpotCheckHd")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@projectID", _projectID)

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

        Public Property [projectID]() As String
            Get
                Return _projectID
            End Get
            Set(ByVal Value As String)
                _projectID = Value
            End Set
        End Property

        Public Property [reportNo]() As String
            Get
                Return _reportNo
            End Get
            Set(ByVal Value As String)
                _reportNo = Value
            End Set
        End Property

        Public Property [nominalWT]() As String
            Get
                Return _nominalWT
            End Get
            Set(ByVal Value As String)
                _nominalWT = Value
            End Set
        End Property

        Public Property [minimalWT]() As String
            Get
                Return _minimalWT
            End Get
            Set(ByVal Value As String)
                _minimalWT = Value
            End Set
        End Property

        Public Property [UTSpotTypeSCode]() As String
            Get
                Return _UTSpotTypeSCode
            End Get
            Set(ByVal Value As String)
                _UTSpotTypeSCode = Value
            End Set
        End Property

        Public Property [SerialNo]() As String
            Get
                Return _serialNo
            End Get
            Set(ByVal Value As String)
                _serialNo = Value
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

        Public Property [Material]() As String
            Get
                Return _material
            End Get
            Set(ByVal Value As String)
                _material = Value
            End Set
        End Property

        Public Property [Equipment]() As String
            Get
                Return _equipment
            End Get
            Set(ByVal Value As String)
                _equipment = Value
            End Set
        End Property

        Public Property [Couplant]() As String
            Get
                Return _couplant
            End Get
            Set(ByVal Value As String)
                _couplant = Value
            End Set
        End Property

        Public Property [ProbeType]() As String
            Get
                Return _probeType
            End Get
            Set(ByVal Value As String)
                _probeType = Value
            End Set
        End Property

        Public Property [ImpactDevice]() As String
            Get
                Return _impactDevice
            End Get
            Set(ByVal Value As String)
                _impactDevice = Value
            End Set
        End Property

        Public Property [ReferenceLevel]() As String
            Get
                Return _referenceLevel
            End Get
            Set(ByVal Value As String)
                _referenceLevel = Value
            End Set
        End Property

        Public Property [Frequency]() As String
            Get
                Return _frequency
            End Get
            Set(ByVal Value As String)
                _frequency = Value
            End Set
        End Property

        Public Property [CalReference]() As String
            Get
                Return _calReference
            End Get
            Set(ByVal Value As String)
                _calReference = Value
            End Set
        End Property

        Public Property [reportDate]() As DateTime
            Get
                Return _reportDate
            End Get
            Set(ByVal Value As DateTime)
                _reportDate = Value
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

        Public Property [isUTSpotArea]() As Boolean
            Get
                Return _isUTSpotArea
            End Get
            Set(ByVal Value As Boolean)
                _isUTSpotArea = Value
            End Set
        End Property

        Public Property [isAreaSpotCylinder]() As Boolean
            Get
                Return _isAreaSpotCylinder
            End Get
            Set(ByVal Value As Boolean)
                _isAreaSpotCylinder = Value
            End Set
        End Property

        Public Property [isAreaSpotSquare]() As Boolean
            Get
                Return _isAreaSpotSquare
            End Get
            Set(ByVal Value As Boolean)
                _isAreaSpotSquare = Value
            End Set
        End Property
#End Region

    End Class
End Namespace
