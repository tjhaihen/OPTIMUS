Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports Raven.Common

Namespace Raven.Common.BussinessRules
    Public Class InspectionTallyReportDt
        Inherits BRInteractionBase

#Region " Class Member Declarations "
        Private _inspectionTallyDtID, _inspectionTallyHdID, _pipeNo, _pipeLength As String
        Private _VBI, _RWT, _CCUYellow, _CCUBlue, _CCUGreen, _CCURed As String
        Private _VTIPin, _VTIBox, _FLD As String
        Private _CCNWhite, _CCNYellow, _CCNRed As String
        Private _finalClass, _intExtCleaning, _intExtCoating, _remarks As String
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
            cmdToExecute.CommandText = "INSERT INTO InspectionTallyReportDt " + _
                                        "(InspectionTallyDtID, InspectionTallyHdID, pipeNo, pipeLength, VBI, RWT, " + _
                                        "CCUYellow, CCUBlue, CCUGreen, CCURed, VTIPin, VTBox, FLD, " + _
                                        "CCNWhite, CCNYellow, CCNRed, finalClass, intExtCleaning, intExtCoating, remarks, " + _
                                        "insertDate, updateDate, " + _
                                        "userIDInsert, userIDUpdate) " + _
                                        "VALUES " + _
                                        "(@InspectionTallyDtID, @InspectionTallyHdID, @pipeNo, @pipeLength, @VBI, @RWT, " + _
                                        "@CCUYellow, @CCUBlue, @CCUGreen, @CCURed, @VTIPin, @VTBox, @FLD, " + _
                                        "@CCNWhite, @CCNYellow, @CCNRed, @finalClass, @intExtCleaning, @intExtCoating, @remarks, " + _
                                        "GETDATE(), GETDATE(), " + _
                                        "@userIDInsert, @userIDUpdate)"
            cmdToExecute.CommandType = CommandType.Text
            cmdToExecute.Connection = _mainConnection

            Dim strID As String = ID.GenerateIDNumber("InspectionTallyReportDt", "InspectionTallyDtID")

            Try
                cmdToExecute.Parameters.AddWithValue("@InspectionTallyDtID", strID)
                cmdToExecute.Parameters.AddWithValue("@inspectionTallyHdID", _inspectionTallyHdID)
                cmdToExecute.Parameters.AddWithValue("@pipeNo", _pipeNo)
                cmdToExecute.Parameters.AddWithValue("@pipeLength", _pipeLength)
                cmdToExecute.Parameters.AddWithValue("@VBI", _VBI)
                cmdToExecute.Parameters.AddWithValue("@RWT", _RWT)
                cmdToExecute.Parameters.AddWithValue("@CCUYellow", _CCUYellow)
                cmdToExecute.Parameters.AddWithValue("@CCUBlue", _CCUBlue)
                cmdToExecute.Parameters.AddWithValue("@CCUGreen", _CCUGreen)
                cmdToExecute.Parameters.AddWithValue("@CCURed", _CCURed)
                cmdToExecute.Parameters.AddWithValue("@VTIPin", _VTIPin)
                cmdToExecute.Parameters.AddWithValue("@VTIBox", _VTIBox)
                cmdToExecute.Parameters.AddWithValue("@FLD", _FLD)
                cmdToExecute.Parameters.AddWithValue("@CCNWhite", _CCNWhite)
                cmdToExecute.Parameters.AddWithValue("@CCNYellow", _CCNYellow)
                cmdToExecute.Parameters.AddWithValue("@CCNRed", _CCNRed)
                cmdToExecute.Parameters.AddWithValue("@finalClass", _finalClass)
                cmdToExecute.Parameters.AddWithValue("@intExtCleaning", _intExtCleaning)
                cmdToExecute.Parameters.AddWithValue("@intExtCoating", _intExtCoating)
                cmdToExecute.Parameters.AddWithValue("@remarks", _remarks)
                cmdToExecute.Parameters.AddWithValue("@userIDinsert", _userIDInsert)
                cmdToExecute.Parameters.AddWithValue("@userIDupdate", _userIDUpdate)

                ' // Open Connection
                _mainConnection.Open()

                ' // Execute Query
                cmdToExecute.ExecuteNonQuery()

                _inspectionTallyDtID = strID
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
            cmdToExecute.CommandText = "UPDATE InspectionTallyReportDt " + _
                                        "SET pipeNo=@pipeNo, pipeLength=@pipeLength, " + _
                                        "VBI=@VBI, RWT=@RWT, " + _
                                        "CCUYellow=@CCUYellow, CCUBlue=@CCUBlue, CCUGreen=@CCUGreen, CCURed=@CCURed, " + _
                                        "VTIPin=@VTIPin, VTIBox=@VTIBox, FLD=@FLD, " + _
                                        "CCNWhite=@CCNWhite, CCYellow=@CCYellow, CCNRed=@CCNRed, finalClass=@finalClass, " + _
                                        "intExtCleaning=@intExtCleaning, intExtCoating=@intExtCoating, remarks=@remarks, " + _
                                        "userIDupdate=@userIDupdate, updateDate=GETDATE() " + _
                                        "WHERE InspectionTallyDtID=@InspectionTallyDtID"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@InspectionTallyDtID", _inspectionTallyDtID)                
                cmdToExecute.Parameters.AddWithValue("@pipeNo", _pipeNo)
                cmdToExecute.Parameters.AddWithValue("@pipeLength", _pipeLength)
                cmdToExecute.Parameters.AddWithValue("@VBI", _VBI)
                cmdToExecute.Parameters.AddWithValue("@RWT", _RWT)
                cmdToExecute.Parameters.AddWithValue("@CCUYellow", _CCUYellow)
                cmdToExecute.Parameters.AddWithValue("@CCUBlue", _CCUBlue)
                cmdToExecute.Parameters.AddWithValue("@CCUGreen", _CCUGreen)
                cmdToExecute.Parameters.AddWithValue("@CCURed", _CCURed)
                cmdToExecute.Parameters.AddWithValue("@VTIPin", _VTIPin)
                cmdToExecute.Parameters.AddWithValue("@VTIBox", _VTIBox)
                cmdToExecute.Parameters.AddWithValue("@FLD", _FLD)
                cmdToExecute.Parameters.AddWithValue("@CCNWhite", _CCNWhite)
                cmdToExecute.Parameters.AddWithValue("@CCNYellow", _CCNYellow)
                cmdToExecute.Parameters.AddWithValue("@CCNRed", _CCNRed)
                cmdToExecute.Parameters.AddWithValue("@finalClass", _finalClass)
                cmdToExecute.Parameters.AddWithValue("@intExtCleaning", _intExtCleaning)
                cmdToExecute.Parameters.AddWithValue("@intExtCoating", _intExtCoating)
                cmdToExecute.Parameters.AddWithValue("@remarks", _remarks)                
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
            cmdToExecute.CommandText = "SELECT * FROM InspectionTallyReportDt"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("InspectionTallyReportDt")
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
            cmdToExecute.CommandText = "SELECT * FROM InspectionTallyReportDt WHERE InspectionTallyDtID=@InspectionTallyDtID"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("InspectionTallyReportDt")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@InspectionTallyDtID", _inspectionTallyDtID)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 Then
                    _inspectionTallyDtID = CType(toReturn.Rows(0)("inspectionTallyDtID"), String)
                    _inspectionTallyHdID = CType(toReturn.Rows(0)("InspectionTallyHdID"), String)
                    _pipeNo = CType(toReturn.Rows(0)("pipeNo"), String)
                    _pipeLength = CType(toReturn.Rows(0)("pipeLength"), String)
                    _VBI = CType(toReturn.Rows(0)("VBI"), String)
                    _RWT = CType(toReturn.Rows(0)("RWT"), String)
                    _CCUYellow = CType(toReturn.Rows(0)("CCUYellow"), String)
                    _CCUBlue = CType(toReturn.Rows(0)("CCUBlue"), String)
                    _CCUGreen = CType(toReturn.Rows(0)("CCUGreen"), String)
                    _CCURed = CType(toReturn.Rows(0)("CCURed"), String)
                    _VTIPin = CType(toReturn.Rows(0)("VTIPin"), String)
                    _VTIBox = CType(toReturn.Rows(0)("VTIBox"), String)
                    _FLD = CType(toReturn.Rows(0)("FLD"), String)
                    _CCNWhite = CType(toReturn.Rows(0)("CCNWhite"), String)
                    _CCNYellow = CType(toReturn.Rows(0)("CCNYellow"), String)
                    _CCNRed = CType(toReturn.Rows(0)("CCNRed"), String)
                    _finalClass = CType(toReturn.Rows(0)("finalClass"), String)
                    _intExtCleaning = CType(toReturn.Rows(0)("intExtCleaning"), String)
                    _intExtCoating = CType(toReturn.Rows(0)("intExtCoating"), String)
                    _remarks = CType(toReturn.Rows(0)("remarks"), String)
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
            cmdToExecute.CommandText = "DELETE FROM InspectionTallyReportDt " + _
                                        "WHERE InspectionTallyDtID=@InspectionTallyDtID"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@InspectionTallyDtID", _inspectionTallyDtID)

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
        Public Function SelectByHdID() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "SELECT * " +
                                        "FROM InspectionTallyReportDt WHERE inspectionTallyHdID=@inspectionTallyHdID"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("InspectionTallyReportDt")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@inspectionTallyHdID", _inspectionTallyHdID)

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
        Public Property [InspectionTallyHdID]() As String
            Get
                Return _InspectionTallyHdID
            End Get
            Set(ByVal Value As String)
                _InspectionTallyHdID = Value
            End Set
        End Property

        Public Property [inspectionTallyDtID]() As String
            Get
                Return _InspectionTallyDtID
            End Get
            Set(ByVal Value As String)
                _InspectionTallyDtID = Value
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

        Public Property [pipeLength]() As String
            Get
                Return _pipeLength
            End Get
            Set(ByVal Value As String)
                _pipeLength = Value
            End Set
        End Property

        Public Property [VBI]() As String
            Get
                Return _VBI
            End Get
            Set(ByVal Value As String)
                _VBI = Value
            End Set
        End Property

        Public Property [RWT]() As String
            Get
                Return _RWT
            End Get
            Set(ByVal Value As String)
                _RWT = Value
            End Set
        End Property

        Public Property [CCUYellow]() As String
            Get
                Return _CCUYellow
            End Get
            Set(ByVal Value As String)
                _CCUYellow = Value
            End Set
        End Property

        Public Property [CCUBlue]() As String
            Get
                Return _CCUBlue
            End Get
            Set(ByVal Value As String)
                _CCUBlue = Value
            End Set
        End Property

        Public Property [CCUGreen]() As String
            Get
                Return _CCUGreen
            End Get
            Set(ByVal Value As String)
                _CCUGreen = Value
            End Set
        End Property

        Public Property [CCURed]() As String
            Get
                Return _CCURed
            End Get
            Set(ByVal Value As String)
                _CCURed = Value
            End Set
        End Property

        Public Property [VTIPin]() As String
            Get
                Return _VTIPin
            End Get
            Set(ByVal Value As String)
                _VTIPin = Value
            End Set
        End Property

        Public Property [VTIBox]() As String
            Get
                Return _VTIBox
            End Get
            Set(ByVal Value As String)
                _VTIBox = Value
            End Set
        End Property

        Public Property [FLD]() As String
            Get
                Return _FLD
            End Get
            Set(ByVal Value As String)
                _FLD = Value
            End Set
        End Property

        Public Property [CCNWhite]() As String
            Get
                Return _CCNWhite
            End Get
            Set(ByVal Value As String)
                _CCNWhite = Value
            End Set
        End Property

        Public Property [CCNYellow]() As String
            Get
                Return _CCNYellow
            End Get
            Set(ByVal Value As String)
                _CCNYellow = Value
            End Set
        End Property

        Public Property [CCNRed]() As String
            Get
                Return _CCNRed
            End Get
            Set(ByVal Value As String)
                _CCNRed = Value
            End Set
        End Property

        Public Property [intExtCleaning]() As String
            Get
                Return _intExtCleaning
            End Get
            Set(ByVal Value As String)
                _intExtCleaning = Value
            End Set
        End Property

        Public Property [intExtCoating]() As String
            Get
                Return _intExtCoating
            End Get
            Set(ByVal Value As String)
                _intExtCoating = Value
            End Set
        End Property

        Public Property [remarks]() As String
            Get
                Return _remarks
            End Get
            Set(ByVal Value As String)
                _remarks = Value
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
