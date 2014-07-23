Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports Raven.Common

Namespace Raven.Common.BussinessRules
    Public Class UTSpotCheckDt
        Inherits BRInteractionBase

#Region " Class Member Declarations "
        Private _UTSpotCheckDtID, _UTSpotCheckHdID, _tallyNo, _location, _remark As String
        Private _wallThicknessInch1, _wallThicknessInch2, _wallThicknessInch3 As Decimal        
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
                                        "(UTSpotCheckHdID, UTSpotCheckDtID, tallyNo, location, remark, " + _
                                        "wallThicknessInch1, wallThicknessInch2, wallThicknessInch3, " + _
                                        "userIDinsert, userIDupdate, insertDate, updateDate) " + _
                                        "VALUES " + _
                                        "(@UTSpotCheckHdID, @UTSpotCheckDtID, @tallyNo, @location, @remark, " + _
                                        "@wallThicknessInch1, @wallThicknessInch2, @wallThicknessInch3, " + _
                                        "@userIDinsert, @userIDupdate, GETDATE(), GETDATE())"
            cmdToExecute.CommandType = CommandType.Text
            cmdToExecute.Connection = _mainConnection

            Dim strID As String = ID.GenerateIDNumber("UTSpotCheckDt", "UTSpotCheckDtID")

            Try
                cmdToExecute.Parameters.AddWithValue("@UTSpotCheckHdID", _UTSpotCheckHdID)
                cmdToExecute.Parameters.AddWithValue("@UTSpotCheckDtID", strID)
                cmdToExecute.Parameters.AddWithValue("@tallyNo", _tallyNo)
                cmdToExecute.Parameters.AddWithValue("@location", _location)
                cmdToExecute.Parameters.AddWithValue("@remark", _remark)
                cmdToExecute.Parameters.AddWithValue("@wallThicknessInch1", _wallThicknessInch1)
                cmdToExecute.Parameters.AddWithValue("@wallThicknessInch2", _wallThicknessInch2)
                cmdToExecute.Parameters.AddWithValue("@wallThicknessInch3", _wallThicknessInch3)
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
                                        "SET tallyNo=@tallyNo, location=@location, remark=@remark, " + _
                                        "wallThicknessInch1=@wallThicknessInch1, wallThicknessInch2=@wallThicknessInch2, wallThicknessInch3=@wallThicknessInch3, " + _
                                        "userIDupdate=@userIDupdate, updateDate=GETDATE() " + _
                                        "WHERE UTSpotCheckDtID=@UTSpotCheckDtID"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@UTSpotCheckDtID", _UTSpotCheckDtID)
                cmdToExecute.Parameters.AddWithValue("@tallyNo", _tallyNo)
                cmdToExecute.Parameters.AddWithValue("@location", _location)
                cmdToExecute.Parameters.AddWithValue("@remark", _remark)
                cmdToExecute.Parameters.AddWithValue("@wallThicknessInch1", _wallThicknessInch1)
                cmdToExecute.Parameters.AddWithValue("@wallThicknessInch2", _wallThicknessInch2)
                cmdToExecute.Parameters.AddWithValue("@wallThicknessInch3", _wallThicknessInch3)
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
                    _tallyNo = CType(toReturn.Rows(0)("tallyNo"), String)
                    _location = CType(toReturn.Rows(0)("location"), String)
                    _remark = CType(toReturn.Rows(0)("remark"), String)
                    _wallThicknessInch1 = CType(toReturn.Rows(0)("wallThicknessInch1"), Decimal)
                    _wallThicknessInch2 = CType(toReturn.Rows(0)("wallThicknessInch2"), Decimal)
                    _wallThicknessInch3 = CType(toReturn.Rows(0)("wallThicknessInch3"), Decimal)
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

        Public Property [tallyNo]() As String
            Get
                Return _tallyNo
            End Get
            Set(ByVal Value As String)
                _tallyNo = Value
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

        Public Property [remark]() As String
            Get
                Return _remark
            End Get
            Set(ByVal Value As String)
                _remark = Value
            End Set
        End Property

        Public Property [wallThicknessInch1]() As Decimal
            Get
                Return _wallThicknessInch1
            End Get
            Set(ByVal Value As Decimal)
                _wallThicknessInch1 = Value
            End Set
        End Property

        Public Property [wallThicknessInch2]() As Decimal
            Get
                Return _wallThicknessInch2
            End Get
            Set(ByVal Value As Decimal)
                _wallThicknessInch2 = Value
            End Set
        End Property

        Public Property [wallThicknessInch3]() As Decimal
            Get
                Return _wallThicknessInch3
            End Get
            Set(ByVal Value As Decimal)
                _wallThicknessInch3 = Value
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
