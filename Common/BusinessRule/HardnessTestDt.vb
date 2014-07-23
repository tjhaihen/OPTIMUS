Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports Raven.Common

Namespace Raven.Common.BussinessRules
    Public Class HardnessTestDt
        Inherits BRInteractionBase

#Region " Class Member Declarations "
        Private _hardnessTestDtID, _hardnessTestHdID, _pipeNo, _locationSCode As String
        Private _HRB1, _HRB2, _HRB3, _HRB4, _HRBAvg As Decimal
        Private _HB1, _HB2, _HB3, _HB4, _HBAvg As Decimal
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
            cmdToExecute.CommandText = "INSERT INTO HardnessTestDt " + _
                                        "(hardnessTestHdID, hardnessTestDtID, pipeNo, locationSCode, " + _
                                        "HRB1, HRB2, HRB3, HRB4, HRBAvg, " + _
                                        "HB1, HB2, HB3, HB4, HBAvg, " + _
                                        "userIDinsert, userIDupdate, insertDate, updateDate) " + _
                                        "VALUES " + _
                                        "(@hardnessTestHdID, @hardnessTestDtID, @pipeNo, @locationSCode, " + _
                                        "@HRB1, @HRB2, @HRB3, @HRB4, @HRBAvg, " + _
                                        "@HB1, @HB2, @HB3, @HB4, @HBAvg, " + _
                                        "@userIDinsert, @userIDupdate, GETDATE(), GETDATE())"
            cmdToExecute.CommandType = CommandType.Text
            cmdToExecute.Connection = _mainConnection

            Dim strID As String = ID.GenerateIDNumber("HardnessTestDt", "hardnessTestDtID")

            Try
                cmdToExecute.Parameters.AddWithValue("@hardnessTestHdID", _hardnessTestHdID)
                cmdToExecute.Parameters.AddWithValue("@hardnessTestDtID", strID)
                cmdToExecute.Parameters.AddWithValue("@pipeNo", _pipeNo)
                cmdToExecute.Parameters.AddWithValue("@locationSCode", _locationSCode)
                cmdToExecute.Parameters.AddWithValue("@HRB1", _HRB1)
                cmdToExecute.Parameters.AddWithValue("@HRB2", _HRB2)
                cmdToExecute.Parameters.AddWithValue("@HRB3", _HRB3)
                cmdToExecute.Parameters.AddWithValue("@HRB4", _HRB4)
                cmdToExecute.Parameters.AddWithValue("@HRBAvg", _HRBAvg)
                cmdToExecute.Parameters.AddWithValue("@HB1", _HB1)
                cmdToExecute.Parameters.AddWithValue("@HB2", _HB2)
                cmdToExecute.Parameters.AddWithValue("@HB3", _HB3)
                cmdToExecute.Parameters.AddWithValue("@HB4", _HB4)
                cmdToExecute.Parameters.AddWithValue("@HBAvg", _HBAvg)
                cmdToExecute.Parameters.AddWithValue("@userIDinsert", _userIDInsert)
                cmdToExecute.Parameters.AddWithValue("@userIDupdate", _userIDupdate)

                ' // Open Connection
                _mainConnection.Open()

                ' // Execute Query
                cmdToExecute.ExecuteNonQuery()

                _hardnessTestDtID = strID
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
            cmdToExecute.CommandText = "UPDATE HardnessTestDt " + _
                                        "SET pipeNo=@pipeNo, locationSCode=@locationSCode, " + _
                                        "HRB1=@HRB1, HRB2=@HRB2, HRB3=@HRB3, HRB4=@HRB4, HRBAvg=@HRBAvg, " + _
                                        "HB1=@HB1, HB2=@HB2, HB3=@HB3, HB4=@HB4, HBAvg=@HBAvg, " + _
                                        "userIDupdate=@userIDupdate, updateDate=GETDATE() " + _
                                        "WHERE hardnessTestDtID=@hardnessTestDtID"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try                
                cmdToExecute.Parameters.AddWithValue("@hardnessTestDtID", _hardnessTestDtID)
                cmdToExecute.Parameters.AddWithValue("@pipeNo", _pipeNo)
                cmdToExecute.Parameters.AddWithValue("@locationSCode", _locationSCode)
                cmdToExecute.Parameters.AddWithValue("@HRB1", _HRB1)
                cmdToExecute.Parameters.AddWithValue("@HRB2", _HRB2)
                cmdToExecute.Parameters.AddWithValue("@HRB3", _HRB3)
                cmdToExecute.Parameters.AddWithValue("@HRB4", _HRB4)
                cmdToExecute.Parameters.AddWithValue("@HRBAvg", _HRBAvg)
                cmdToExecute.Parameters.AddWithValue("@HB1", _HB1)
                cmdToExecute.Parameters.AddWithValue("@HB2", _HB2)
                cmdToExecute.Parameters.AddWithValue("@HB3", _HB3)
                cmdToExecute.Parameters.AddWithValue("@HB4", _HB4)
                cmdToExecute.Parameters.AddWithValue("@HBAvg", _HBAvg)                
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
            cmdToExecute.CommandText = "SELECT * FROM HardnessTestDt"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("HardnessTestDt")
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
            cmdToExecute.CommandText = "SELECT * FROM HardnessTestDt WHERE hardnessTestDtID=@hardnessTestDtID"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("HardnessTestDt")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@hardnessTestDtID", _hardnessTestDtID)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 Then
                    _hardnessTestHdID = CType(toReturn.Rows(0)("hardnessTestHdID"), String)
                    _hardnessTestDtID = CType(toReturn.Rows(0)("hardnessTestDtID"), String)
                    _pipeNo = CType(toReturn.Rows(0)("pipeNo"), String)
                    _locationSCode = CType(toReturn.Rows(0)("locationSCode"), String)
                    _HRB1 = CType(toReturn.Rows(0)("HRB1"), Decimal)
                    _HRB2 = CType(toReturn.Rows(0)("HRB2"), Decimal)
                    _HRB3 = CType(toReturn.Rows(0)("HRB3"), Decimal)
                    _HRB4 = CType(toReturn.Rows(0)("HRB4"), Decimal)
                    _HRBAvg = CType(toReturn.Rows(0)("HRBAvg"), Decimal)
                    _HB1 = CType(toReturn.Rows(0)("HB1"), Decimal)
                    _HB2 = CType(toReturn.Rows(0)("HB2"), Decimal)
                    _HB3 = CType(toReturn.Rows(0)("HB3"), Decimal)
                    _HB4 = CType(toReturn.Rows(0)("HB4"), Decimal)
                    _HBAvg = CType(toReturn.Rows(0)("HBAvg"), Decimal)
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
            cmdToExecute.CommandText = "DELETE FROM HardnessTestDt " + _
                                        "WHERE hardnessTestDtID=@hardnessTestDtID"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@hardnessTestDtID", _hardnessTestDtID)

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
        Public Function SelectByHardnessTestHdID() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "SELECT drd.*, (SELECT caption FROM CommonCode WHERE groupCode='HTLOCATION' " +
                                        "AND value=drd.locationSCode) AS locationName " +
                                        "FROM HardnessTestDt drd WHERE drd.hardnessTestHdID=@hardnessTestHdID"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("HardnessTestDt")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@hardnessTestHdID", _hardnessTestHdID)

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
        Public Property [hardnessTestHdID]() As String
            Get
                Return _hardnessTestHdID
            End Get
            Set(ByVal Value As String)
                _hardnessTestHdID = Value
            End Set
        End Property

        Public Property [hardnessTestDtID]() As String
            Get
                Return _hardnessTestDtID
            End Get
            Set(ByVal Value As String)
                _hardnessTestDtID = Value
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

        Public Property [locationSCode]() As String
            Get
                Return _locationSCode
            End Get
            Set(ByVal Value As String)
                _locationSCode = Value
            End Set
        End Property

        Public Property [HRB1]() As Decimal
            Get
                Return _HRB1
            End Get
            Set(ByVal Value As Decimal)
                _HRB1 = Value
            End Set
        End Property

        Public Property [HRB2]() As Decimal
            Get
                Return _HRB2
            End Get
            Set(ByVal Value As Decimal)
                _HRB2 = Value
            End Set
        End Property

        Public Property [HRB3]() As Decimal
            Get
                Return _HRB3
            End Get
            Set(ByVal Value As Decimal)
                _HRB3 = Value
            End Set
        End Property

        Public Property [HRB4]() As Decimal
            Get
                Return _HRB4
            End Get
            Set(ByVal Value As Decimal)
                _HRB4 = Value
            End Set
        End Property

        Public Property [HRBAvg]() As Decimal
            Get
                Return _HRBAvg
            End Get
            Set(ByVal Value As Decimal)
                _HRBAvg = Value
            End Set
        End Property

        Public Property [HB1]() As Decimal
            Get
                Return _HB1
            End Get
            Set(ByVal Value As Decimal)
                _HB1 = Value
            End Set
        End Property

        Public Property [HB2]() As Decimal
            Get
                Return _HB2
            End Get
            Set(ByVal Value As Decimal)
                _HB2 = Value
            End Set
        End Property

        Public Property [HB3]() As Decimal
            Get
                Return _HB3
            End Get
            Set(ByVal Value As Decimal)
                _HB3 = Value
            End Set
        End Property

        Public Property [HB4]() As Decimal
            Get
                Return _HB4
            End Get
            Set(ByVal Value As Decimal)
                _HB4 = Value
            End Set
        End Property

        Public Property [HBAvg]() As Decimal
            Get
                Return _HBAvg
            End Get
            Set(ByVal Value As Decimal)
                _HBAvg = Value
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
