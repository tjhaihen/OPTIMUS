Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports Raven.Common

Namespace Raven.Common.BussinessRules
    Public Class Temp_InspectionReportDt
        Inherits BRInteractionBase

#Region " Class Member Declarations "
        Private _inspectionReportDtID, _inspectionReportHdID, _serialNo, _length, _remark As String
        Private _Adesc, _Bdesc, _Cdesc, _Ddesc As String
        Private _Edesc, _Fdesc, _Gdesc, _Hdesc, _Idesc As String
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
                                        "(inspectionReportHdID, inspectionReportDtID, serialNo, length, " + _
                                        "remark, Adesc, Bdesc, Cdesc, Ddesc, " + _
                                        "Edesc, Fdesc, Gdesc, Hdesc, Idesc, " + _
                                        "userIDinsert, userIDupdate, insertDate, updateDate) " + _
                                        "VALUES " + _
                                        "(@inspectionReportHdID, @inspectionReportDtID, @serialNo, @length, " + _
                                        "@remark, @Adesc, @Bdesc, @Cdesc, @Ddesc, " + _
                                        "@Edesc, @Fdesc, @Gdesc, @Hdesc, @Idesc, " + _
                                        "@userIDinsert, @userIDupdate, GETDATE(), GETDATE())"
            cmdToExecute.CommandType = CommandType.Text
            cmdToExecute.Connection = _mainConnection

            Dim strID As String = ID.GenerateIDNumber("InspectionReportDt", "inspectionReportDtID")

            Try
                cmdToExecute.Parameters.AddWithValue("@inspectionReportHdID", _inspectionReportHdID)
                cmdToExecute.Parameters.AddWithValue("@inspectionReportDtID", strID)
                cmdToExecute.Parameters.AddWithValue("@serialNo", _serialNo)
                cmdToExecute.Parameters.AddWithValue("@length", _length)
                cmdToExecute.Parameters.AddWithValue("@remark", _remark)
                cmdToExecute.Parameters.AddWithValue("@Adesc", _Adesc)
                cmdToExecute.Parameters.AddWithValue("@Bdesc", _Bdesc)
                cmdToExecute.Parameters.AddWithValue("@Cdesc", _Cdesc)
                cmdToExecute.Parameters.AddWithValue("@Ddesc", _Ddesc)
                cmdToExecute.Parameters.AddWithValue("@Edesc", _Edesc)
                cmdToExecute.Parameters.AddWithValue("@Fdesc", _Fdesc)
                cmdToExecute.Parameters.AddWithValue("@Gdesc", _Gdesc)
                cmdToExecute.Parameters.AddWithValue("@Hdesc", _Hdesc)
                cmdToExecute.Parameters.AddWithValue("@Idesc", _Idesc)
                cmdToExecute.Parameters.AddWithValue("@userIDinsert", _userIDInsert)
                cmdToExecute.Parameters.AddWithValue("@userIDupdate", _userIDUpdate)

                ' // Open Connection
                _mainConnection.Open()

                ' // Execute Query
                cmdToExecute.ExecuteNonQuery()

                _inspectionReportDtID = strID
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
                                        "SET serialNo=@serialNo, length=@length, " + _
                                        "remark=@remark, Adesc=@Adesc, Bdesc=@Bdesc, Cdesc=@Cdesc, Ddesc=@Ddesc, " + _
                                        "Edesc=@Edesc, Fdesc=@Fdesc, Gdesc=@Gdesc, Hdesc=@Hdesc, Idesc=@Idesc, " + _
                                        "userIDupdate=@userIDupdate, updateDate=GETDATE() " + _
                                        "WHERE inspectionReportDtID=@inspectionReportDtID"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@inspectionReportDtID", _inspectionReportDtID)
                cmdToExecute.Parameters.AddWithValue("@serialNo", _serialNo)
                cmdToExecute.Parameters.AddWithValue("@length", _length)
                cmdToExecute.Parameters.AddWithValue("@remark", _remark)
                cmdToExecute.Parameters.AddWithValue("@Adesc", _Adesc)
                cmdToExecute.Parameters.AddWithValue("@Bdesc", _Bdesc)
                cmdToExecute.Parameters.AddWithValue("@Cdesc", _Cdesc)
                cmdToExecute.Parameters.AddWithValue("@Ddesc", _Ddesc)
                cmdToExecute.Parameters.AddWithValue("@Edesc", _Edesc)
                cmdToExecute.Parameters.AddWithValue("@Fdesc", _Fdesc)
                cmdToExecute.Parameters.AddWithValue("@Gdesc", _Gdesc)
                cmdToExecute.Parameters.AddWithValue("@Hdesc", _Hdesc)
                cmdToExecute.Parameters.AddWithValue("@Idesc", _Idesc)
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
                    _inspectionReportHdID = CType(toReturn.Rows(0)("inspectionReportHdID"), String)
                    _inspectionReportDtID = CType(toReturn.Rows(0)("inspectionReportDtID"), String)
                    _serialNo = CType(toReturn.Rows(0)("serialNo"), String)
                    _length = CType(toReturn.Rows(0)("length"), String)
                    _remark = CType(toReturn.Rows(0)("remark"), String)
                    _Adesc = CType(toReturn.Rows(0)("Adesc"), String)
                    _Bdesc = CType(toReturn.Rows(0)("Bdesc"), String)
                    _Cdesc = CType(toReturn.Rows(0)("Cdesc"), String)
                    _Ddesc = CType(toReturn.Rows(0)("Ddesc"), String)
                    _Edesc = CType(toReturn.Rows(0)("Edesc"), String)
                    _Fdesc = CType(toReturn.Rows(0)("Fdesc"), String)
                    _Gdesc = CType(toReturn.Rows(0)("Gdesc"), String)
                    _Hdesc = CType(toReturn.Rows(0)("Hdesc"), String)
                    _Idesc = CType(toReturn.Rows(0)("Idesc"), String)
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
        Public Function SelectByInspectionReportHdID() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "SELECT drd.* " +
                                        "FROM InspectionReportDt drd WHERE drd.inspectionReportHdID=@inspectionReportHdID"
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
        Public Property [inspectionReportHdID]() As String
            Get
                Return _inspectionReportHdID
            End Get
            Set(ByVal Value As String)
                _inspectionReportHdID = Value
            End Set
        End Property

        Public Property [inspectionReportDtID]() As String
            Get
                Return _inspectionReportDtID
            End Get
            Set(ByVal Value As String)
                _inspectionReportDtID = Value
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

        Public Property [Adesc]() As String
            Get
                Return _Adesc
            End Get
            Set(ByVal Value As String)
                _Adesc = Value
            End Set
        End Property

        Public Property [Bdesc]() As String
            Get
                Return _Bdesc
            End Get
            Set(ByVal Value As String)
                _Bdesc = Value
            End Set
        End Property

        Public Property [Cdesc]() As String
            Get
                Return _Cdesc
            End Get
            Set(ByVal Value As String)
                _Cdesc = Value
            End Set
        End Property

        Public Property [Ddesc]() As String
            Get
                Return _Ddesc
            End Get
            Set(ByVal Value As String)
                _Ddesc = Value
            End Set
        End Property

        Public Property [Edesc]() As String
            Get
                Return _Edesc
            End Get
            Set(ByVal Value As String)
                _Edesc = Value
            End Set
        End Property

        Public Property [Fdesc]() As String
            Get
                Return _Fdesc
            End Get
            Set(ByVal Value As String)
                _Fdesc = Value
            End Set
        End Property

        Public Property [Gdesc]() As String
            Get
                Return _Gdesc
            End Get
            Set(ByVal Value As String)
                _Gdesc = Value
            End Set
        End Property

        Public Property [Hdesc]() As String
            Get
                Return _Hdesc
            End Get
            Set(ByVal Value As String)
                _Hdesc = Value
            End Set
        End Property

        Public Property [Idesc]() As String
            Get
                Return _Idesc
            End Get
            Set(ByVal Value As String)
                _Idesc = Value
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
