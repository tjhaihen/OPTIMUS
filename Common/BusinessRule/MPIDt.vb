Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports Raven.Common

Namespace Raven.Common.BussinessRules
    Public Class MPIDt
        Inherits BRInteractionBase

#Region " Class Member Declarations "
        Private _MPIDtID, _MPIHdID, _MPIpicDescription, _MPIpicType, _MPIpicGroupSCode As String
        Private _MPIpicSize As Integer
        Private _MPIpic As Byte()
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
            cmdToExecute.CommandText = "INSERT INTO MPIDt " + _
                                        "(MPIHdID, MPIDtID, MPIpic, " + _
                                        "MPIpicDescription, MPIpicSize, MPIpicType, MPIpicGroupSCode, " + _
                                        "userIDinsert, userIDupdate, insertDate, updateDate) " + _
                                        "VALUES " + _
                                        "(@MPIHdID, @MPIDtID, @MPIpic, " + _
                                        "@MPIpicDescription, @MPIpicSize, @MPIpicType, @MPIpicGroupSCode, " + _
                                        "@userIDinsert, @userIDupdate, GETDATE(), GETDATE())"
            cmdToExecute.CommandType = CommandType.Text
            cmdToExecute.Connection = _mainConnection

            Dim strID As String = ID.GenerateIDNumber("MPIDt", "MPIDtID")

            Try
                cmdToExecute.Parameters.AddWithValue("@MPIHdID", _MPIHdID)
                cmdToExecute.Parameters.AddWithValue("@MPIDtID", strID)
                cmdToExecute.Parameters.AddWithValue("@MPIpic", _MPIpic)
                cmdToExecute.Parameters.AddWithValue("@MPIpicDescription", _MPIpicDescription)
                cmdToExecute.Parameters.AddWithValue("@MPIpicSize", _MPIpicSize)
                cmdToExecute.Parameters.AddWithValue("@MPIpicType", _MPIpicType)
                cmdToExecute.Parameters.AddWithValue("@MPIpicGroupSCode", _MPIpicGroupSCode)
                cmdToExecute.Parameters.AddWithValue("@userIDinsert", _userIDInsert)
                cmdToExecute.Parameters.AddWithValue("@userIDupdate", _userIDupdate)

                ' // Open Connection
                _mainConnection.Open()

                ' // Execute Query
                cmdToExecute.ExecuteNonQuery()

                _MPIDtID = strID
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
            cmdToExecute.CommandText = "UPDATE MPIDt " + _
                                        "SET MPIpic=@MPIpic, MPIpicDescription=@MPIpicDescription, " + _
                                        "MPIpicSize=@MPIpicSize, MPIpicType=@MPIpicType, MPIpicGroupSCode=@MPIpicGroupSCode, " + _
                                        "userIDupdate=@userIDupdate, updateDate=GETDATE() " + _
                                        "WHERE MPIDtID=@MPIDtID"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try                
                cmdToExecute.Parameters.AddWithValue("@MPIDtID", _MPIDtID)
                cmdToExecute.Parameters.AddWithValue("@MPIpic", _MPIpic)
                cmdToExecute.Parameters.AddWithValue("@MPIpicDescription", _MPIpicDescription)
                cmdToExecute.Parameters.AddWithValue("@MPIpicSize", _MPIpicSize)
                cmdToExecute.Parameters.AddWithValue("@MPIpicType", _MPIpicType)
                cmdToExecute.Parameters.AddWithValue("@MPIpicGroupSCode", _MPIpicGroupSCode)
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
            cmdToExecute.CommandText = "SELECT * FROM MPIDt"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("MPIDt")
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
            cmdToExecute.CommandText = "SELECT * FROM MPIDt WHERE MPIDtID=@MPIDtID"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("MPIDt")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@MPIDtID", _MPIDtID)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 Then
                    _MPIHdID = CType(toReturn.Rows(0)("MPIHdID"), String)
                    _MPIDtID = CType(toReturn.Rows(0)("MPIDtID"), String)
                    _MPIpic = CType(toReturn.Rows(0)("MPIpic"), Byte())
                    _MPIpicDescription = CType(toReturn.Rows(0)("MPIpicDescription"), String)
                    _MPIpicSize = CType(toReturn.Rows(0)("MPIpicSize"), Integer)
                    _MPIpicType = CType(toReturn.Rows(0)("MPIpicType"), String)
                    _MPIpicGroupSCode = CType(toReturn.Rows(0)("MPIpicGroupSCode"), String)
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
            cmdToExecute.CommandText = "DELETE FROM MPIDt " + _
                                        "WHERE MPIDtID=@MPIDtID"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@MPIDtID", _MPIDtID)

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
        Public Function SelectByMPIHdID() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "SELECT * " +
                                        "FROM MPIDt WHERE MPIHdID=@MPIHdID"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("MPIDt")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@MPIHdID", _MPIHdID)

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
        Public Property [MPIHdID]() As String
            Get
                Return _MPIHdID
            End Get
            Set(ByVal Value As String)
                _MPIHdID = Value
            End Set
        End Property

        Public Property [MPIDtID]() As String
            Get
                Return _MPIDtID
            End Get
            Set(ByVal Value As String)
                _MPIDtID = Value
            End Set
        End Property

        Public Property [MPIpic]() As Byte()
            Get
                Return _MPIpic
            End Get
            Set(ByVal Value As Byte())
                _MPIpic = Value
            End Set
        End Property

        Public Property [MPIpicDescription]() As String
            Get
                Return _MPIpicDescription
            End Get
            Set(ByVal Value As String)
                _MPIpicDescription = Value
            End Set
        End Property

        Public Property [MPIpicSize]() As Integer
            Get
                Return _MPIpicSize
            End Get
            Set(ByVal Value As Integer)
                _MPIpicSize = Value
            End Set
        End Property

        Public Property [MPIpicType]() As String
            Get
                Return _MPIpicType
            End Get
            Set(ByVal Value As String)
                _MPIpicType = Value
            End Set
        End Property

        Public Property [MPIpicGroupSCode]() As String
            Get
                Return _MPIpicGroupSCode
            End Get
            Set(ByVal Value As String)
                _MPIpicGroupSCode = Value
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
