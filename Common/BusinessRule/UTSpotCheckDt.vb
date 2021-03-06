﻿Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports Raven.Common

Namespace Raven.Common.BussinessRules
    Public Class UTSpotCheckDt
        Inherits BRInteractionBase

#Region " Class Member Declarations "
        Private _UTSpotCheckDtID, _UTSpotCheckHdID, _structureTallyNo, _location, _size, _length, _remark As String
        Private _wallThickness1, _wallThickness2, _wallThickness3, _wallThickness4 As String
        Private _hardnessTest1, _hardnessTest2, _hardnessTest3, _hardnessTest4 As String
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
            cmdToExecute.CommandText = "INSERT INTO UTSpotCheckDt " + _
                                        "(UTSpotCheckHdID, UTSpotCheckDtID, structureTallyNo, location, size, length, remark, " + _
                                        "wallThickness1, wallThickness2, wallThickness3, wallThickness4, " + _
                                        "hardnessTest1, hardnessTest2, hardnessTest3, hardnessTest4, " + _
                                        "userIDinsert, userIDupdate, insertDate, updateDate) " + _
                                        "VALUES " + _
                                        "(@UTSpotCheckHdID, @UTSpotCheckDtID, @structureTallyNo, @location, @size, @length, @remark, " + _
                                        "@wallThickness1, @wallThickness2, @wallThickness3, @wallThickness4, " + _
                                        "@hardnessTest1, @hardnessTest2, @hardnessTest3, @hardnessTest4, " + _
                                        "@userIDinsert, @userIDupdate, GETDATE(), GETDATE())"
            cmdToExecute.CommandType = CommandType.Text
            cmdToExecute.Connection = _mainConnection

            Dim strID As String = ID.GenerateIDNumber("UTSpotCheckDt", "UTSpotCheckDtID")

            Try
                cmdToExecute.Parameters.AddWithValue("@UTSpotCheckHdID", _UTSpotCheckHdID)
                cmdToExecute.Parameters.AddWithValue("@UTSpotCheckDtID", strID)
                cmdToExecute.Parameters.AddWithValue("@structureTallyNo", _structureTallyNo)
                cmdToExecute.Parameters.AddWithValue("@location", _location)
                cmdToExecute.Parameters.AddWithValue("@size", _size)
                cmdToExecute.Parameters.AddWithValue("@length", _length)
                cmdToExecute.Parameters.AddWithValue("@remark", _remark)
                cmdToExecute.Parameters.AddWithValue("@wallThickness1", _wallThickness1)
                cmdToExecute.Parameters.AddWithValue("@wallThickness2", _wallThickness2)
                cmdToExecute.Parameters.AddWithValue("@wallThickness3", _wallThickness3)
                cmdToExecute.Parameters.AddWithValue("@wallThickness4", _wallThickness4)
                cmdToExecute.Parameters.AddWithValue("@hardnessTest1", _hardnessTest1)
                cmdToExecute.Parameters.AddWithValue("@hardnessTest2", _hardnessTest2)
                cmdToExecute.Parameters.AddWithValue("@hardnessTest3", _hardnessTest3)
                cmdToExecute.Parameters.AddWithValue("@hardnessTest4", _hardnessTest4)
                cmdToExecute.Parameters.AddWithValue("@userIDinsert", _userIDInsert)
                cmdToExecute.Parameters.AddWithValue("@userIDupdate", _userIDupdate)

                ' // Open Connection
                _mainConnection.Open()

                ' // Execute Query
                cmdToExecute.ExecuteNonQuery()

                _UTSpotCheckDtID = strID
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
                                        "SET structureTallyNo=@structureTallyNo, location=@location, size=@size, length=@length, remark=@remark, " + _
                                        "wallThickness1=@wallThickness1, wallThickness2=@wallThickness2, wallThickness3=@wallThickness3, wallThickness4=@wallThickness4, " + _
                                        "hardnessTest1=@hardnessTest1, hardnessTest2=@hardnessTest2, hardnessTest3=@hardnessTest3, hardnessTest4=@hardnessTest4, " + _
                                        "userIDupdate=@userIDupdate, updateDate=GETDATE() " + _
                                        "WHERE UTSpotCheckDtID=@UTSpotCheckDtID"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@UTSpotCheckDtID", _UTSpotCheckDtID)
                cmdToExecute.Parameters.AddWithValue("@structureTallyNo", _structureTallyNo)
                cmdToExecute.Parameters.AddWithValue("@location", _location)
                cmdToExecute.Parameters.AddWithValue("@size", _size)
                cmdToExecute.Parameters.AddWithValue("@length", _length)
                cmdToExecute.Parameters.AddWithValue("@remark", _remark)
                cmdToExecute.Parameters.AddWithValue("@wallThickness1", _wallThickness1)
                cmdToExecute.Parameters.AddWithValue("@wallThickness2", _wallThickness2)
                cmdToExecute.Parameters.AddWithValue("@wallThickness3", _wallThickness3)
                cmdToExecute.Parameters.AddWithValue("@wallThickness4", _wallThickness4)
                cmdToExecute.Parameters.AddWithValue("@hardnessTest1", _hardnessTest1)
                cmdToExecute.Parameters.AddWithValue("@hardnessTest2", _hardnessTest2)
                cmdToExecute.Parameters.AddWithValue("@hardnessTest3", _hardnessTest3)
                cmdToExecute.Parameters.AddWithValue("@hardnessTest4", _hardnessTest4)
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
            cmdToExecute.CommandText = "SELECT * FROM UTSpotCheckDt"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("UTSpotCheckDt")
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
            cmdToExecute.CommandText = "SELECT * FROM UTSpotCheckDt WHERE UTSpotCheckDtID=@UTSpotCheckDtID"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("UTSpotCheckDt")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@UTSpotCheckDtID", _UTSpotCheckDtID)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 Then
                    _UTSpotCheckHdID = CType(toReturn.Rows(0)("UTSpotCheckHdID"), String)
                    _UTSpotCheckDtID = CType(toReturn.Rows(0)("UTSpotCheckDtID"), String)
                    _structureTallyNo = CType(toReturn.Rows(0)("structureTallyNo"), String)
                    _location = CType(toReturn.Rows(0)("location"), String)
                    _size = CType(toReturn.Rows(0)("size"), String)
                    _length = CType(toReturn.Rows(0)("length"), String)
                    _remark = CType(toReturn.Rows(0)("remark"), String)
                    _wallThickness1 = CType(toReturn.Rows(0)("wallThickness1"), String)
                    _wallThickness2 = CType(toReturn.Rows(0)("wallThickness2"), String)
                    _wallThickness3 = CType(toReturn.Rows(0)("wallThickness3"), String)
                    _wallThickness4 = CType(toReturn.Rows(0)("wallThickness4"), String)
                    _hardnessTest1 = CType(toReturn.Rows(0)("hardnessTest1"), String)
                    _hardnessTest2 = CType(toReturn.Rows(0)("hardnessTest2"), String)
                    _hardnessTest3 = CType(toReturn.Rows(0)("hardnessTest3"), String)
                    _hardnessTest4 = CType(toReturn.Rows(0)("hardnessTest4"), String)
                    _userIDInsert = CType(toReturn.Rows(0)("userIDinsert"), String)
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
            cmdToExecute.CommandText = "DELETE FROM UTSpotCheckDt " + _
                                        "WHERE UTSpotCheckDtID=@UTSpotCheckDtID"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@UTSpotCheckDtID", _UTSpotCheckDtID)

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
        Public Function SelectByUTSpotCheckHdID() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "SELECT drd.* " +
                                        "FROM UTSpotCheckDt drd WHERE drd.UTSpotCheckHdID=@UTSpotCheckHdID"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("UTSpotCheckDt")
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

        Public Property [UTSpotCheckDtID]() As String
            Get
                Return _UTSpotCheckDtID
            End Get
            Set(ByVal Value As String)
                _UTSpotCheckDtID = Value
            End Set
        End Property

        Public Property [structureTallyNo]() As String
            Get
                Return _structureTallyNo
            End Get
            Set(ByVal Value As String)
                _structureTallyNo = Value
            End Set
        End Property

        Public Property [location]() As String
            Get
                Return _location
            End Get
            Set(ByVal Value As String)
                _location = Value
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

        Public Property [length]() As String
            Get
                Return _length
            End Get
            Set(ByVal Value As String)
                _length = Value
            End Set
        End Property

        Public Property [remark]() As String
            Get
                Return _remark
            End Get
            Set(ByVal Value As String)
                _remark = Value
            End Set
        End Property

        Public Property [wallThickness1]() As String
            Get
                Return _wallThickness1
            End Get
            Set(ByVal Value As String)
                _wallThickness1 = Value
            End Set
        End Property

        Public Property [wallThickness2]() As String
            Get
                Return _wallThickness2
            End Get
            Set(ByVal Value As String)
                _wallThickness2 = Value
            End Set
        End Property

        Public Property [wallThickness3]() As String
            Get
                Return _wallThickness3
            End Get
            Set(ByVal Value As String)
                _wallThickness3 = Value
            End Set
        End Property

        Public Property [wallThickness4]() As String
            Get
                Return _wallThickness4
            End Get
            Set(ByVal Value As String)
                _wallThickness4 = Value
            End Set
        End Property

        Public Property [hardnessTest1]() As String
            Get
                Return _hardnessTest1
            End Get
            Set(ByVal Value As String)
                _hardnessTest1 = Value
            End Set
        End Property

        Public Property [hardnessTest2]() As String
            Get
                Return _hardnessTest2
            End Get
            Set(ByVal Value As String)
                _hardnessTest2 = Value
            End Set
        End Property

        Public Property [hardnessTest3]() As String
            Get
                Return _hardnessTest3
            End Get
            Set(ByVal Value As String)
                _hardnessTest3 = Value
            End Set
        End Property

        Public Property [hardnessTest4]() As String
            Get
                Return _hardnessTest4
            End Get
            Set(ByVal Value As String)
                _hardnessTest4 = Value
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
