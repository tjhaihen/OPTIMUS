Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports Raven.Common

Namespace Raven.Common.BussinessRules
    Public Class ThoroughVisualReportDt
        Inherits BRInteractionBase

#Region " Class Member Declarations "
        Private _tviDtID, _tviHdID, _picDescription, _picType As String
        Private _picSize As Integer
        Private _pic As SqlBinary
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
            cmdToExecute.CommandText = "INSERT INTO ThoroughVisualReportDt " + _
                                        "(tviHdID, tviDtID, pic, " + _
                                        "picDescription, picSize, picType, " + _
                                        "userIDinsert, userIDupdate, insertDate, updateDate) " + _
                                        "VALUES " + _
                                        "(@tviHdID, @tviDtID, @pic, " + _
                                        "@picDescription, @picSize, @picType, " + _
                                        "@userIDinsert, @userIDupdate, GETDATE(), GETDATE())"
            cmdToExecute.CommandType = CommandType.Text
            cmdToExecute.Connection = _mainConnection

            Dim strID As String = ID.GenerateIDNumber("ThoroughVisualReportDt", "tviDtID")

            Try
                cmdToExecute.Parameters.AddWithValue("@tviHdID", _tviHdID)
                cmdToExecute.Parameters.AddWithValue("@tviDtID", strID)
                cmdToExecute.Parameters.AddWithValue("@pic", _pic)
                cmdToExecute.Parameters.AddWithValue("@picDescription", _picDescription)
                cmdToExecute.Parameters.AddWithValue("@picSize", _picSize)
                cmdToExecute.Parameters.AddWithValue("@picType", _picType)                
                cmdToExecute.Parameters.AddWithValue("@userIDinsert", _userIDInsert)
                cmdToExecute.Parameters.AddWithValue("@userIDupdate", _userIDUpdate)

                ' // Open Connection
                _mainConnection.Open()

                ' // Execute Query
                cmdToExecute.ExecuteNonQuery()

                _tviDtID = strID
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
            cmdToExecute.CommandText = "UPDATE ThoroughVisualReportDt " + _
                                        "SET picDescription=@picDescription, " + _
                                        "userIDupdate=@userIDupdate, updateDate=GETDATE() " + _
                                        "WHERE tviDtID=@tviDtID"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@tviDtID", _tviDtID)
                cmdToExecute.Parameters.AddWithValue("@picDescription", _picDescription)                
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
            cmdToExecute.CommandText = "SELECT * FROM ThoroughVisualReportDt"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("ThoroughVisualReportDt")
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
            cmdToExecute.CommandText = "SELECT * FROM ThoroughVisualReportDt WHERE tviDtID=@tviDtID"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("ThoroughVisualReportDt")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@tviDtID", _tviDtID)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 Then
                    _tviHdID = CType(toReturn.Rows(0)("tviHdID"), String)
                    _tviDtID = CType(toReturn.Rows(0)("tviDtID"), String)
                    _pic = CType(toReturn.Rows(0)("pic"), Byte())
                    _picDescription = CType(toReturn.Rows(0)("picDescription"), String)
                    _picSize = CType(toReturn.Rows(0)("picSize"), Integer)
                    _picType = CType(toReturn.Rows(0)("picType"), String)                    
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
            cmdToExecute.CommandText = "DELETE FROM ThoroughVisualReportDt " + _
                                        "WHERE tviDtID=@tviDtID"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@tviDtID", _tviDtID)

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
        Public Function SelectBytviHdID() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "SELECT * " +
                                        "FROM ThoroughVisualReportDt WHERE tviHdID=@tviHdID"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("ThoroughVisualReportDt")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@tviHdID", _tviHdID)

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
        Public Property [tviHdID]() As String
            Get
                Return _tviHdID
            End Get
            Set(ByVal Value As String)
                _tviHdID = Value
            End Set
        End Property

        Public Property [tviDtID]() As String
            Get
                Return _tviDtID
            End Get
            Set(ByVal Value As String)
                _tviDtID = Value
            End Set
        End Property

        Public Property [pic]() As SqlBinary
            Get
                Return _pic
            End Get
            Set(ByVal Value As SqlBinary)
                _pic = Value
            End Set
        End Property

        Public Property [picDescription]() As String
            Get
                Return _picDescription
            End Get
            Set(ByVal Value As String)
                _picDescription = Value
            End Set
        End Property

        Public Property [picSize]() As Integer
            Get
                Return _picSize
            End Get
            Set(ByVal Value As Integer)
                _picSize = Value
            End Set
        End Property

        Public Property [picType]() As String
            Get
                Return _picType
            End Get
            Set(ByVal Value As String)
                _picType = Value
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
