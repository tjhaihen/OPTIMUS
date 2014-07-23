Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports Raven.Common

Namespace Raven.Common.BussinessRules
    Public Class InspectionReportHd
        Inherits BRInteractionBase

#Region " Class Member Declarations "
        Private _inspectionReportHdID, _projectID, _inspectionReportNo, _materialDescription, _typeOfInspection, _result As String
        Private _inspectionPic As Byte()
        Private _inspectionDate, _insertDate, _updateDate As DateTime
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
            cmdToExecute.CommandText = "INSERT INTO InspectionReportHd " + _
                                        "(inspectionReportHdID, projectID, inspectionReportNo, " + _
                                        "materialDescription, typeOfInspection, result, inspectionPic, " + _
                                        "inspectionDate, insertDate, updateDate, " + _
                                        "userIDInsert, userIDUpdate) " + _
                                        "VALUES " + _
                                        "(@inspectionReportHdID, @projectID, @inspectionReportNo, " + _
                                        "@materialDescription, @typeOfInspection, @result, @inspectionPic, " + _
                                        "@inspectionDate, GETDATE(), GETDATE(), " + _
                                        "@userIDInsert, @userIDUpdate)"
            cmdToExecute.CommandType = CommandType.Text
            cmdToExecute.Connection = _mainConnection

            Dim strID As String = ID.GenerateIDNumber("InspectionReportHd", "inspectionReportHdID")

            Try
                cmdToExecute.Parameters.AddWithValue("@inspectionReportHdID", strID)
                cmdToExecute.Parameters.AddWithValue("@projectID", _projectID)
                cmdToExecute.Parameters.AddWithValue("@inspectionReportNo", _inspectionReportNo)
                cmdToExecute.Parameters.AddWithValue("@inspectionDate", _inspectionDate)
                cmdToExecute.Parameters.AddWithValue("@materialDescription", _materialDescription)
                cmdToExecute.Parameters.AddWithValue("@typeOfInspection", _typeOfInspection)
                cmdToExecute.Parameters.AddWithValue("@materialDescription", _materialDescription)
                cmdToExecute.Parameters.AddWithValue("@result", _result)
                cmdToExecute.Parameters.AddWithValue("@inspectionPic", _inspectionPic)
                cmdToExecute.Parameters.AddWithValue("@userIDinsert", _userIDinsert)
                cmdToExecute.Parameters.AddWithValue("@userIDupdate", _userIDupdate)

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
            cmdToExecute.CommandText = "UPDATE InspectionReportHd " + _
                                        "SET inspectionReportNo=@inspectionReportNo, inspectionDate=@inspectionDate, " + _
                                        "materialDescription=@materialDescription, typeOfInspection=@typeOfInspection, result=@result, " + _
                                        "inspectionPic=@inpsectionPic, userIDupdate=@userIDupdate, updateDate=GETDATE() " + _
                                        "WHERE inspectionReportHdID=@inspectionReportHdID"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@inspectionReportHdID", _inspectionReportHdID)
                cmdToExecute.Parameters.AddWithValue("@inspectionReportNo", _inspectionReportNo)
                cmdToExecute.Parameters.AddWithValue("@inspectionDate", _inspectionDate)
                cmdToExecute.Parameters.AddWithValue("@materialDescription", _materialDescription)
                cmdToExecute.Parameters.AddWithValue("@typeOfInspection", _typeOfInspection)
                cmdToExecute.Parameters.AddWithValue("@materialDescription", _materialDescription)
                cmdToExecute.Parameters.AddWithValue("@result", _result)
                cmdToExecute.Parameters.AddWithValue("@inspectionPic", _inspectionPic)                
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
            cmdToExecute.CommandText = "SELECT * FROM InspectionReportHd"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("InspectionReportHd")
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
            cmdToExecute.CommandText = "SELECT * FROM InspectionReportHd WHERE inspectionReportHdID=@inspectionReportHdID"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("InspectionReportHd")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@inspectionReportHdID", _inspectionReportHdID)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 Then
                    _inspectionReportHdID = CType(toReturn.Rows(0)("inspectionReportHdID"), String)
                    _projectID = CType(toReturn.Rows(0)("projectID"), String)
                    _inspectionReportNo = CType(toReturn.Rows(0)("inspectionReportNo"), String)
                    _inspectionDate = CType(toReturn.Rows(0)("inspectionDate"), DateTime)
                    _materialDescription = CType(toReturn.Rows(0)("materialDescription"), String)
                    _typeOfInspection = CType(toReturn.Rows(0)("typeOfInspection"), String)
                    _result = CType(toReturn.Rows(0)("result"), String)
                    _inspectionPic = CType(toReturn.Rows(0)("inspectionPic"), Byte())
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
            cmdToExecute.CommandText = "DELETE FROM InspectionReportHd " + _
                                        "WHERE inspectionReportHdID=@inspectionReportHdID"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@inspectionReportHdID", _inspectionReportHdID)

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
                                        "FROM InspectionReportHd WHERE projectID=@projectID"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("InspectionReportHd")
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
        Public Property [inspectionReportHdID]() As String
            Get
                Return _inspectionReportHdID
            End Get
            Set(ByVal Value As String)
                _inspectionReportHdID = Value
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

        Public Property [inspectionReportNo]() As String
            Get
                Return _inspectionReportNo
            End Get
            Set(ByVal Value As String)
                _inspectionReportNo = Value
            End Set
        End Property

        Public Property [inspectionDate]() As DateTime
            Get
                Return _inspectionDate
            End Get
            Set(ByVal Value As DateTime)
                _inspectionDate = Value
            End Set
        End Property

        Public Property [materialDescription]() As String
            Get
                Return _materialDescription
            End Get
            Set(ByVal Value As String)
                _materialDescription = Value
            End Set
        End Property

        Public Property [typeOfInspection]() As String
            Get
                Return _typeOfInspection
            End Get
            Set(ByVal Value As String)
                _typeOfInspection = Value
            End Set
        End Property

        Public Property [result]() As String
            Get
                Return _result
            End Get
            Set(ByVal Value As String)
                _result = Value
            End Set
        End Property

        Public Property [inpsectionPic]() As Byte()
            Get
                Return _inspectionPic
            End Get
            Set(ByVal Value As Byte())
                _inspectionPic = Value
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
