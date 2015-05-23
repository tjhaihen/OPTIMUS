Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports Raven.Common

Namespace Raven.Common.BussinessRules
    Public Class ServiceReport
        Inherits BRInteractionBase

#Region " Class Member Declarations "
        Private _serviceReportID, _projectID, _serviceReportForSCode, _typeOfInspection, _typeOfInspectionCol2, _result, _mdManufacturer As String
        Private _mdTypeOfPipe, _mdPipeOD, _mdPipeGrade, _mdPipeWeight, _mdThreadConnection, _mdRange, _mdTotalInspected, _mdTotalAccepted As String
        Private _mdNotes, _userIDinsert, _userIDupdate As String
        Private _serviceReportDate, _insertDate, _updateDate As DateTime
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
            cmdToExecute.CommandText = "INSERT INTO ServiceReport " + _
                                        "(serviceReportID, projectID, serviceReportForSCode, serviceReportDate, typeOfInspection, typeOfInspectionCol2, " + _
                                        "mdManufacturer, mdTypeOfPipe, mdPipeOD, mdPipeGrade, mdPipeWeight, mdThreadConnection,  " + _
                                        "mdRange, mdTotalInspected, mdTotalAccepted, mdNotes, result,  " + _
                                        "userIDinsert, userIDupdate, insertDate, updateDate) " + _
                                        "VALUES " + _
                                        "(@serviceReportID, @projectID, @serviceReportForSCode, @serviceReportDate, @typeOfInspection, @typeOfInspectionCol2, " + _
                                        "@mdManufacturer, @mdTypeOfPipe, @mdPipeOD, @mdPipeGrade, @mdPipeWeight, @mdThreadConnection,  " + _
                                        "@mdRange, @mdTotalInspected, @mdTotalAccepted, @mdNotes, @result,  " + _
                                        "@userIDinsert, @userIDupdate, GETDATE(), GETDATE())"
            cmdToExecute.CommandType = CommandType.Text
            cmdToExecute.Connection = _mainConnection

            Dim strServiceReportID As String = ID.GenerateIDNumber("ServiceReport", "serviceReportID")

            Try
                cmdToExecute.Parameters.AddWithValue("@serviceReportID", strServiceReportID)
                cmdToExecute.Parameters.AddWithValue("@projectID", _projectID)
                cmdToExecute.Parameters.AddWithValue("@serviceReportForSCode", _serviceReportForSCode)
                cmdToExecute.Parameters.AddWithValue("@serviceReportDate", _serviceReportDate)
                cmdToExecute.Parameters.AddWithValue("@typeOfInspection", _typeOfInspection)
                cmdToExecute.Parameters.AddWithValue("@typeOfInspectionCol2", _typeOfInspectionCol2)
                cmdToExecute.Parameters.AddWithValue("@mdManufacturer", _mdManufacturer)
                cmdToExecute.Parameters.AddWithValue("@mdTypeOfPipe", _mdTypeOfPipe)
                cmdToExecute.Parameters.AddWithValue("@mdPipeOD", _mdPipeOD)
                cmdToExecute.Parameters.AddWithValue("@mdPipeGrade", _mdPipeGrade)
                cmdToExecute.Parameters.AddWithValue("@mdPipeWeight", _mdPipeWeight)
                cmdToExecute.Parameters.AddWithValue("@mdThreadConnection", _mdThreadConnection)
                cmdToExecute.Parameters.AddWithValue("@mdRange", _mdRange)
                cmdToExecute.Parameters.AddWithValue("@mdTotalInspected", _mdTotalInspected)
                cmdToExecute.Parameters.AddWithValue("@mdTotalAccepted", _mdTotalAccepted)
                cmdToExecute.Parameters.AddWithValue("@mdNotes", _mdNotes)
                cmdToExecute.Parameters.AddWithValue("@result", _result)
                cmdToExecute.Parameters.AddWithValue("@userIDinsert", _userIDinsert)
                cmdToExecute.Parameters.AddWithValue("@userIDupdate", _userIDupdate)

                ' // Open Connection
                _mainConnection.Open()

                ' // Execute Query
                cmdToExecute.ExecuteNonQuery()

                _serviceReportID = strServiceReportID
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
            cmdToExecute.CommandText = "UPDATE ServiceReport " + _
                                        "SET serviceReportForSCode=@serviceReportForSCode, serviceReportDate=@serviceReportDate, " + _
                                        "typeOfInspection=@typeOfInspection, typeOfInspectionCol2=@typeOfInspectionCol2, mdManufacturer=@mdManufacturer, mdTypeOfPipe=@mdTypeOfPipe, " + _
                                        "mdPipeOD=@mdPipeOD, mdPipeGrade=@mdPipeGrade, mdPipeWeight=@mdPipeWeight, mdThreadConnection=@mdThreadConnection, " + _
                                        "mdRange=@mdRange, mdTotalInspected=@mdTotalInspected, mdTotalAccepted=@mdTotalAccepted, mdNotes=@mdNotes, result=@result, " + _
                                        "userIDupdate=@userIDupdate, updateDate=GETDATE() " + _
                                        "WHERE serviceReportID=@serviceReportID"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@serviceReportID", _serviceReportID)
                cmdToExecute.Parameters.AddWithValue("@projectID", _projectID)
                cmdToExecute.Parameters.AddWithValue("@serviceReportForSCode", _serviceReportForSCode)
                cmdToExecute.Parameters.AddWithValue("@serviceReportDate", _serviceReportDate)
                cmdToExecute.Parameters.AddWithValue("@typeOfInspection", _typeOfInspection)
                cmdToExecute.Parameters.AddWithValue("@typeOfInspectionCol2", _typeOfInspectionCol2)
                cmdToExecute.Parameters.AddWithValue("@mdManufacturer", _mdManufacturer)
                cmdToExecute.Parameters.AddWithValue("@mdTypeOfPipe", _mdTypeOfPipe)
                cmdToExecute.Parameters.AddWithValue("@mdPipeOD", _mdPipeOD)
                cmdToExecute.Parameters.AddWithValue("@mdPipeGrade", _mdPipeGrade)
                cmdToExecute.Parameters.AddWithValue("@mdPipeWeight", _mdPipeWeight)
                cmdToExecute.Parameters.AddWithValue("@mdThreadConnection", _mdThreadConnection)
                cmdToExecute.Parameters.AddWithValue("@mdRange", _mdRange)
                cmdToExecute.Parameters.AddWithValue("@mdTotalInspected", _mdTotalInspected)
                cmdToExecute.Parameters.AddWithValue("@mdTotalAccepted", _mdTotalAccepted)
                cmdToExecute.Parameters.AddWithValue("@mdNotes", _mdNotes)
                cmdToExecute.Parameters.AddWithValue("@result", _result)                
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
            cmdToExecute.CommandText = "SELECT * FROM ServiceReport"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("ServiceReport")
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
            cmdToExecute.CommandText = "SELECT * FROM ServiceReport WHERE serviceReportID=@serviceReportID"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("ServiceReport")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@serviceReportID", _serviceReportID)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 Then
                    _serviceReportID = CType(toReturn.Rows(0)("serviceReportID"), String)
                    _projectID = CType(toReturn.Rows(0)("projectID"), String)
                    _serviceReportForSCode = CType(toReturn.Rows(0)("serviceReportForSCode"), String)
                    _serviceReportDate = CType(toReturn.Rows(0)("serviceReportDate"), DateTime)
                    _typeOfInspection = CType(toReturn.Rows(0)("typeOfInspection"), String)
                    _typeOfInspectionCol2 = CType(toReturn.Rows(0)("typeOfInspectionCol2"), String)
                    _mdManufacturer = CType(toReturn.Rows(0)("mdManufacturer"), String)
                    _mdTypeOfPipe = CType(toReturn.Rows(0)("mdTypeOfPipe"), String)
                    _mdPipeOD = CType(toReturn.Rows(0)("mdPipeOD"), String)
                    _mdPipeGrade = CType(toReturn.Rows(0)("mdPipeGrade"), String)
                    _mdPipeWeight = CType(toReturn.Rows(0)("mdPipeWeight"), String)
                    _mdThreadConnection = CType(toReturn.Rows(0)("mdThreadConnection"), String)
                    _mdRange = CType(toReturn.Rows(0)("mdRange"), String)
                    _mdTotalInspected = CType(toReturn.Rows(0)("mdTotalInspected"), String)
                    _mdTotalAccepted = CType(toReturn.Rows(0)("mdTotalAccepted"), String)
                    _mdNotes = CType(toReturn.Rows(0)("mdNotes"), String)
                    _result = CType(toReturn.Rows(0)("result"), String)
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
            cmdToExecute.CommandText = "DELETE FROM ServiceReport " + _
                                        "WHERE serviceReportID=@serviceReportID"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@serviceReportID", _serviceReportID)

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
            cmdToExecute.CommandText = "SELECT sr.*, " +
                                        "(SELECT caption FROM CommonCode WHERE groupCode='SVCRPTFOR' AND value=sr.serviceReportForSCode) AS ServiceReportFor " +
                                        "FROM ServiceReport sr WHERE sr.projectID=@projectID"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("ServiceReport")
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

        Public Function SelectByProjectIDForSCode() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "SELECT sr.*, " +
                                        "(SELECT caption FROM CommonCode WHERE groupCode='SVCRPTFOR' AND value=sr.serviceReportForSCode) AS ServiceReportFor " +
                                        "FROM ServiceReport sr WHERE sr.projectID=@projectID AND " +
                                        "sr.serviceReportForSCode = @serviceReportForSCode ORDER BY sr.serviceReportDate"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("ServiceReport")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@projectID", _projectID)
                cmdToExecute.Parameters.AddWithValue("@serviceReportForSCode", _serviceReportForSCode)

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
        Public Property [serviceReportID]() As String
            Get
                Return _serviceReportID
            End Get
            Set(ByVal Value As String)
                _serviceReportID = Value
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

        Public Property [serviceReportForSCode]() As String
            Get
                Return _serviceReportForSCode
            End Get
            Set(ByVal Value As String)
                _serviceReportForSCode = Value
            End Set
        End Property

        Public Property [serviceReportDate]() As DateTime
            Get
                Return _serviceReportDate
            End Get
            Set(ByVal Value As DateTime)
                _serviceReportDate = Value
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

        Public Property [typeOfInspectionCol2]() As String
            Get
                Return _typeOfInspectionCol2
            End Get
            Set(ByVal Value As String)
                _typeOfInspectionCol2 = Value
            End Set
        End Property

        Public Property [mdManufacturer]() As String
            Get
                Return _mdManufacturer
            End Get
            Set(ByVal Value As String)
                _mdManufacturer = Value
            End Set
        End Property

        Public Property [mdTypeOfPipe]() As String
            Get
                Return _mdTypeOfPipe
            End Get
            Set(ByVal Value As String)
                _mdTypeOfPipe = Value
            End Set
        End Property

        Public Property [mdPipeOD]() As String
            Get
                Return _mdPipeOD
            End Get
            Set(ByVal Value As String)
                _mdPipeOD = Value
            End Set
        End Property

        Public Property [mdPipeGrade]() As String
            Get
                Return _mdPipeGrade
            End Get
            Set(ByVal Value As String)
                _mdPipeGrade = Value
            End Set
        End Property

        Public Property [mdPipeWeight]() As String
            Get
                Return _mdPipeWeight
            End Get
            Set(ByVal Value As String)
                _mdPipeWeight = Value
            End Set
        End Property

        Public Property [mdThreadConnection]() As String
            Get
                Return _mdThreadConnection
            End Get
            Set(ByVal Value As String)
                _mdThreadConnection = Value
            End Set
        End Property

        Public Property [mdRange]() As String
            Get
                Return _mdRange
            End Get
            Set(ByVal Value As String)
                _mdRange = Value
            End Set
        End Property

        Public Property [mdTotalInspected]() As String
            Get
                Return _mdTotalInspected
            End Get
            Set(ByVal Value As String)
                _mdTotalInspected = Value
            End Set
        End Property

        Public Property [mdTotalAccepted]() As String
            Get
                Return _mdTotalAccepted
            End Get
            Set(ByVal Value As String)
                _mdTotalAccepted = Value
            End Set
        End Property

        Public Property [mdNotes]() As String
            Get
                Return _mdNotes
            End Get
            Set(ByVal Value As String)
                _mdNotes = Value
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
