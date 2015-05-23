Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports Raven.Common

Namespace Raven.Common.BussinessRules
    Public Class CertificateInspection
        Inherits BRInteractionBase

#Region " Class Member Declarations "
        Private _certificateInspectionID, _projectID, _certificateNo, _owner, _userLabel, _location, _description, _notes As String
        Private _serialNo, _maxGrossWeightR, _loadTest, _duration, _specification, _examination, _result, _actualLoadTestUOM As String
        Private _Pic1, _Pic2, _Pic3 As SqlBinary
        Private _actualLoadTest As Decimal
        Private _certificateDate, _inspectionDate, _expiredDate, _insertDate, _updateDate As DateTime
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
            cmdToExecute.CommandText = "INSERT INTO CertificateInspection " + _
                                        "(certificateInspectionID, projectID, certificateNo, owner, userLabel, location, description, " + _
                                        "serialNo, maxGrossWeightR, loadTest, duration, specification, examination, result, notes, " + _
                                        "actualLoadTest, actualLoadTestUOM, " + _
                                        "certificateDate, inspectionDate, expiredDate, insertDate, updateDate, " + _
                                        "userIDInsert, userIDUpdate) " + _
                                        "VALUES " + _
                                        "(@certificateInspectionID, @projectID, @certificateNo, @owner, @userLabel, @location, @description, " + _
                                        "@serialNo, @maxGrossWeightR, @loadTest, @duration, @specification, @examination, @result, @notes, " + _
                                        "@actualLoadTest, @actualLoadTestUOM, " + _
                                        "@certificateDate, @inspectionDate, @expiredDate, GETDATE(), GETDATE(), " + _
                                        "@userIDInsert, @userIDUpdate)"
            cmdToExecute.CommandType = CommandType.Text
            cmdToExecute.Connection = _mainConnection

            Dim strCertificateInspectionID As String = ID.GenerateIDNumber("CertificateInspection", "certificateInspectionID")

            Try
                cmdToExecute.Parameters.AddWithValue("@certificateInspectionID", strCertificateInspectionID)
                cmdToExecute.Parameters.AddWithValue("@projectID", _projectID)
                cmdToExecute.Parameters.AddWithValue("@certificateNo", _certificateNo)
                cmdToExecute.Parameters.AddWithValue("@owner", _owner)
                cmdToExecute.Parameters.AddWithValue("@userLabel", _userLabel)
                cmdToExecute.Parameters.AddWithValue("@location", _location)
                cmdToExecute.Parameters.AddWithValue("@description", _description)
                cmdToExecute.Parameters.AddWithValue("@serialNo", _serialNo)
                cmdToExecute.Parameters.AddWithValue("@maxGrossWeightR", _maxGrossWeightR)
                cmdToExecute.Parameters.AddWithValue("@loadTest", _loadTest)
                cmdToExecute.Parameters.AddWithValue("@duration", _duration)
                cmdToExecute.Parameters.AddWithValue("@specification", _specification)
                cmdToExecute.Parameters.AddWithValue("@examination", _examination)
                cmdToExecute.Parameters.AddWithValue("@result", _result)
                cmdToExecute.Parameters.AddWithValue("@notes", _notes)
                cmdToExecute.Parameters.AddWithValue("@certificateDate", _certificateDate)
                cmdToExecute.Parameters.AddWithValue("@inspectionDate", _inspectionDate)
                cmdToExecute.Parameters.AddWithValue("@expiredDate", _expiredDate)
                cmdToExecute.Parameters.AddWithValue("@actualLoadTest", _actualLoadTest)
                cmdToExecute.Parameters.AddWithValue("@actualLoadTestUOM", _actualLoadTestUOM)
                cmdToExecute.Parameters.AddWithValue("@userIDinsert", _userIDinsert)
                cmdToExecute.Parameters.AddWithValue("@userIDupdate", _userIDupdate)

                ' // Open Connection
                _mainConnection.Open()

                ' // Execute Query
                cmdToExecute.ExecuteNonQuery()

                _certificateInspectionID = strCertificateInspectionID
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
            cmdToExecute.CommandText = "UPDATE CertificateInspection " + _
                                        "SET certificateNo=@certificateNo, owner=@owner, userLabel=@userLabel, " + _
                                        "location=@location, description=@description, " + _
                                        "serialNo=@serialNo, maxGrossWeightR=@maxGrossWeightR, " + _
                                        "loadTest=@loadTest, duration=@duration, " + _
                                        "specification=@specification, examination=@examination, " + _
                                        "actualLoadTest=@actualLoadTest, actualLoadTestUOM=@actualLoadTestUOM, " + _
                                        "result=@result, notes=@notes, certificateDate=@certificateDate, " + _
                                        "inspectionDate=@inspectionDate, expiredDate=@expiredDate, " + _
                                        "userIDupdate=@userIDupdate, updateDate=GETDATE() " + _
                                        "WHERE certificateInspectionID=@certificateInspectionID"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@certificateInspectionID", _certificateInspectionID)                
                cmdToExecute.Parameters.AddWithValue("@certificateNo", _certificateNo)
                cmdToExecute.Parameters.AddWithValue("@owner", _owner)
                cmdToExecute.Parameters.AddWithValue("@userLabel", _userLabel)
                cmdToExecute.Parameters.AddWithValue("@location", _location)
                cmdToExecute.Parameters.AddWithValue("@description", _description)
                cmdToExecute.Parameters.AddWithValue("@serialNo", _serialNo)
                cmdToExecute.Parameters.AddWithValue("@maxGrossWeightR", _maxGrossWeightR)
                cmdToExecute.Parameters.AddWithValue("@loadTest", _loadTest)
                cmdToExecute.Parameters.AddWithValue("@duration", _duration)
                cmdToExecute.Parameters.AddWithValue("@specification", _specification)
                cmdToExecute.Parameters.AddWithValue("@examination", _examination)
                cmdToExecute.Parameters.AddWithValue("@result", _result)
                cmdToExecute.Parameters.AddWithValue("@notes", _notes)
                cmdToExecute.Parameters.AddWithValue("@certificateDate", _certificateDate)
                cmdToExecute.Parameters.AddWithValue("@inspectionDate", _inspectionDate)
                cmdToExecute.Parameters.AddWithValue("@expiredDate", _expiredDate)
                cmdToExecute.Parameters.AddWithValue("@actualLoadTest", _actualLoadTest)
                cmdToExecute.Parameters.AddWithValue("@actualLoadTestUOM", _actualLoadTestUOM)
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
            cmdToExecute.CommandText = "SELECT * FROM CertificateInspection"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("CertificateInspection")
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
            cmdToExecute.CommandText = "SELECT * FROM CertificateInspection WHERE certificateInspectionID=@certificateInspectionID"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("CertificateInspection")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@certificateInspectionID", _certificateInspectionID)                

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 Then
                    _certificateInspectionID = CType(toReturn.Rows(0)("certificateInspectionID"), String)
                    _projectID = CType(toReturn.Rows(0)("projectID"), String)
                    _certificateNo = CType(toReturn.Rows(0)("certificateNo"), String)
                    _owner = CType(toReturn.Rows(0)("owner"), String)
                    _userLabel = CType(toReturn.Rows(0)("userLabel"), String)
                    _location = CType(toReturn.Rows(0)("location"), String)
                    _description = CType(toReturn.Rows(0)("description"), String)
                    _serialNo = CType(toReturn.Rows(0)("serialNo"), String)
                    _maxGrossWeightR = CType(toReturn.Rows(0)("maxGrossWeightR"), String)
                    _loadTest = CType(toReturn.Rows(0)("loadTest"), String)
                    _duration = CType(toReturn.Rows(0)("duration"), String)
                    _specification = CType(toReturn.Rows(0)("specification"), String)
                    _examination = CType(toReturn.Rows(0)("examination"), String)
                    _result = CType(toReturn.Rows(0)("result"), String)
                    _notes = CType(toReturn.Rows(0)("notes"), String)
                    _certificateDate = CType(toReturn.Rows(0)("certificateDate"), DateTime)
                    _inspectionDate = CType(toReturn.Rows(0)("inspectionDate"), DateTime)
                    _expiredDate = CType(toReturn.Rows(0)("expiredDate"), DateTime)
                    _Pic1 = CType(ProcessNull.GetBytes(toReturn.Rows(0)("Pic1")), Byte())
                    _Pic2 = CType(ProcessNull.GetBytes(toReturn.Rows(0)("Pic2")), Byte())
                    _Pic3 = CType(ProcessNull.GetBytes(toReturn.Rows(0)("Pic3")), Byte())
                    _actualLoadTest = CType(toReturn.Rows(0)("actualLoadTest"), Decimal)
                    _actualLoadTestUOM = CType(toReturn.Rows(0)("actualLoadTestUOM"), String)
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
            cmdToExecute.CommandText = "DELETE FROM CertificateInspection " + _
                                        "WHERE certificateInspectionID=@certificateInspectionID"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@certificateInspectionID", _certificateInspectionID)

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
            cmdToExecute.CommandText = "SELECT cis.* " +
                                        "FROM CertificateInspection cis WHERE cis.ProjectID=@ProjectID"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("CertificateInspection")
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

        Public Function UpdatePic(ByVal PicNo As Integer) As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand
            Select Case PicNo
                Case 1
                    cmdToExecute.CommandText = "UPDATE CertificateInspection " + _
                                        "SET Pic1=@Pic1, " + _
                                        "userIDupdate=@userIDupdate, updateDate=GETDATE() " + _
                                        "WHERE certificateInspectionID=@certificateInspectionID"
                Case 2
                    cmdToExecute.CommandText = "UPDATE CertificateInspection " + _
                                        "SET Pic2=@Pic2, " + _
                                        "userIDupdate=@userIDupdate, updateDate=GETDATE() " + _
                                        "WHERE certificateInspectionID=@certificateInspectionID"
                Case Else
                    cmdToExecute.CommandText = "UPDATE CertificateInspection " + _
                                        "SET Pic3=@Pic3, " + _
                                        "userIDupdate=@userIDupdate, updateDate=GETDATE() " + _
                                        "WHERE certificateInspectionID=@certificateInspectionID"
            End Select
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                Select Case PicNo
                    Case 1
                        cmdToExecute.Parameters.AddWithValue("@Pic1", _Pic1)
                    Case 2
                        cmdToExecute.Parameters.AddWithValue("@Pic2", _Pic2)
                    Case Else
                        cmdToExecute.Parameters.AddWithValue("@Pic3", _Pic3)
                End Select
                cmdToExecute.Parameters.AddWithValue("@certificateInspectionID", _certificateInspectionID)
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
#End Region

#Region " Class Property Declarations "
        Public Property [certificateInspectionID]() As String
            Get
                Return _certificateInspectionID
            End Get
            Set(ByVal Value As String)
                _certificateInspectionID = Value
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

        Public Property [certificateNo]() As String
            Get
                Return _certificateNo
            End Get
            Set(ByVal Value As String)
                _certificateNo = Value
            End Set
        End Property

        Public Property [owner]() As String
            Get
                Return _owner
            End Get
            Set(ByVal Value As String)
                _owner = Value
            End Set
        End Property

        Public Property [userLabel]() As String
            Get
                Return _userLabel
            End Get
            Set(ByVal Value As String)
                _userLabel = Value
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

        Public Property [description]() As String
            Get
                Return _description
            End Get
            Set(ByVal Value As String)
                _description = Value
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

        Public Property [maxGrossWeightR]() As String
            Get
                Return _maxGrossWeightR
            End Get
            Set(ByVal Value As String)
                _maxGrossWeightR = Value
            End Set
        End Property

        Public Property [loadTest]() As String
            Get
                Return _loadTest
            End Get
            Set(ByVal Value As String)
                _loadTest = Value
            End Set
        End Property

        Public Property [duration]() As String
            Get
                Return _duration
            End Get
            Set(ByVal Value As String)
                _duration = Value
            End Set
        End Property

        Public Property [specification]() As String
            Get
                Return _specification
            End Get
            Set(ByVal Value As String)
                _specification = Value
            End Set
        End Property

        Public Property [examination]() As String
            Get
                Return _examination
            End Get
            Set(ByVal Value As String)
                _examination = Value
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

        Public Property [notes]() As String
            Get
                Return _notes
            End Get
            Set(ByVal Value As String)
                _notes = Value
            End Set
        End Property

        Public Property [certificateDate]() As DateTime
            Get
                Return _certificateDate
            End Get
            Set(ByVal Value As DateTime)
                _certificateDate = Value
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

        Public Property [expiredDate]() As DateTime
            Get
                Return _expiredDate
            End Get
            Set(ByVal Value As DateTime)
                _expiredDate = Value
            End Set
        End Property

        Public Property [Pic1]() As SqlBinary
            Get
                Return _Pic1
            End Get
            Set(ByVal Value As SqlBinary)
                _Pic1 = Value
            End Set
        End Property

        Public Property [Pic2]() As SqlBinary
            Get
                Return _Pic2
            End Get
            Set(ByVal Value As SqlBinary)
                _Pic2 = Value
            End Set
        End Property

        Public Property [Pic3]() As SqlBinary
            Get
                Return _Pic3
            End Get
            Set(ByVal Value As SqlBinary)
                _Pic3 = Value
            End Set
        End Property

        Public Property [actualLoadTest]() As Decimal
            Get
                Return _actualLoadTest
            End Get
            Set(ByVal Value As Decimal)
                _actualLoadTest = Value
            End Set
        End Property

        Public Property [actualLoadTestUOM]() As String
            Get
                Return _actualLoadTestUOM
            End Get
            Set(ByVal Value As String)
                _actualLoadTestUOM = Value
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
