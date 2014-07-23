Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports Raven.Common

Namespace Raven.Common.BussinessRules
    Public Class DrillPipeReportDt
        Inherits BRInteractionBase

#Region " Class Member Declarations "
        Private _drillPipeReportHdID, _drillPipeReportDtID, _sequenceNo, _serialNo, _remarks As String
        Private _bdBodyWear, _bdBent, _bdBodyDamage, _bdEMI, _bdUTEndArea, _bdPlasticCoating, _bdWall, _bdWallRemanent, _bdTubeClass As String
        Private _pcToolJointYear, _pcOutsideDia, _pcInsideDia, _pcTongSpace, _pcThreadLength, _pcBevelDia, _pcLead, _pcShoulderWidth, _
                    _pcNeckLength, _pcReface, _pcFinalCondition As String
        Private _bcOutsideDia, _bcTongSpace, _bcQCDia, _bcQCDepth, _bcShoulderWidth, _bcBevelDia, _bcSealWidth, _bcReface, _bcFinalCondition As String
        Private _userIDinsert, _userIDupdate As String
        Private _insertDate, _updateDate As DateTime
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
            cmdToExecute.CommandText = "INSERT INTO DrillPipeReportDt " + _
                                        "(drillPipeReportHdID, drillPipeReportDtID, sequenceNo, serialNo, remarks, " + _
                                        "bdBodyWear, bdBent, bdBodyDamage, bdEMI, bdUTEndArea, bdPlasticCoating, bdWall, bdWallRemanent, bdTubeClass, " + _
                                        "pcToolJointYear, pcOutsideDia, pcInsideDia, pcTongSpace, pcThreadLength, pcBevelDia, pcLead, pcShoulderWidth, " + _
                                        "pcNeckLength, pcReface, pcFinalCondition, bcOutsideDia, bcTongSpace, bcQCDia, bcQCDepth, bcShoulderWidth, " + _
                                        "bcBevelDia, bcSealWidth, bcReface, bcFinalCondition, " + _
                                        "userIDinsert, userIDupdate, insertDate, updateDate) " + _
                                        "VALUES " + _
                                        "(@drillPipeReportHdID, @drillPipeReportDtID, @sequenceNo, @serialNo, @remarks, " + _
                                        "@bdBodyWear, @bdBent, @bdBodyDamage, @bdEMI, @bdUTEndArea, @bdPlasticCoating, @bdWall, @bdWallRemanent, @bdTubeClass, " + _
                                        "@pcToolJointYear, @pcOutsideDia, @pcInsideDia, @pcTongSpace, @pcThreadLength, @pcBevelDia, @pcLead, @pcShoulderWidth, " + _
                                        "@pcNeckLength, @pcReface, @pcFinalCondition, @bcOutsideDia, @bcTongSpace, @bcQCDia, @bcQCDepth, @bcShoulderWidth, " + _
                                        "@bcBevelDia, @bcSealWidth, @bcReface, @bcFinalCondition, " + _
                                        "@userIDinsert, @userIDupdate, GETDATE(), GETDATE())"
            cmdToExecute.CommandType = CommandType.Text
            cmdToExecute.Connection = _mainConnection

            Dim strDrillPipeReportDtID As String = ID.GenerateIDNumber("DrillPipeReportDt", "drillPipeReportDtID")

            Try
                cmdToExecute.Parameters.AddWithValue("@drillPipeReportHdID", _drillPipeReportHdID)
                cmdToExecute.Parameters.AddWithValue("@drillPipeReportDtID", strDrillPipeReportDtID)
                cmdToExecute.Parameters.AddWithValue("@sequenceNo", _sequenceNo)
                cmdToExecute.Parameters.AddWithValue("@serialNo", _serialNo)
                cmdToExecute.Parameters.AddWithValue("@remarks", _remarks)
                cmdToExecute.Parameters.AddWithValue("@bdBodyWear", _bdBodyWear)
                cmdToExecute.Parameters.AddWithValue("@bdBent", _bdBent)
                cmdToExecute.Parameters.AddWithValue("@bdBodyDamage", _bdBodyDamage)
                cmdToExecute.Parameters.AddWithValue("@bdEMI", _bdEMI)
                cmdToExecute.Parameters.AddWithValue("@bdUTEndArea", _bdUTEndArea)
                cmdToExecute.Parameters.AddWithValue("@bdPlasticCoating", _bdPlasticCoating)
                cmdToExecute.Parameters.AddWithValue("@bdWall", _bdWall)
                cmdToExecute.Parameters.AddWithValue("@bdWallRemanent", _bdWallRemanent)
                cmdToExecute.Parameters.AddWithValue("@bdTubeClass", _bdTubeClass)
                cmdToExecute.Parameters.AddWithValue("@pcToolJointYear", _pcToolJointYear)
                cmdToExecute.Parameters.AddWithValue("@pcOutsideDia", _pcOutsideDia)
                cmdToExecute.Parameters.AddWithValue("@pcInsideDia", _pcInsideDia)
                cmdToExecute.Parameters.AddWithValue("@pcTongSpace", _pcTongSpace)
                cmdToExecute.Parameters.AddWithValue("@pcThreadLength", _pcThreadLength)
                cmdToExecute.Parameters.AddWithValue("@pcBevelDia", _pcBevelDia)
                cmdToExecute.Parameters.AddWithValue("@pcLead", _pcLead)
                cmdToExecute.Parameters.AddWithValue("@pcShoulderWidth", _pcShoulderWidth)
                cmdToExecute.Parameters.AddWithValue("@pcNeckLength", _pcNeckLength)
                cmdToExecute.Parameters.AddWithValue("@pcReface", _pcReface)
                cmdToExecute.Parameters.AddWithValue("@pcFinalCondition", _pcFinalCondition)
                cmdToExecute.Parameters.AddWithValue("@bcOutsideDia", _bcOutsideDia)
                cmdToExecute.Parameters.AddWithValue("@bcTongSpace", _bcTongSpace)
                cmdToExecute.Parameters.AddWithValue("@bcQCDia", _bcQCDia)
                cmdToExecute.Parameters.AddWithValue("@bcQCDepth", _bcQCDepth)
                cmdToExecute.Parameters.AddWithValue("@bcShoulderWidth", _bcShoulderWidth)
                cmdToExecute.Parameters.AddWithValue("@bcBevelDia", _bcBevelDia)
                cmdToExecute.Parameters.AddWithValue("@bcSealWidth", _bcSealWidth)
                cmdToExecute.Parameters.AddWithValue("@bcReface", _bcReface)
                cmdToExecute.Parameters.AddWithValue("@bcFinalCondition", _bcFinalCondition)
                cmdToExecute.Parameters.AddWithValue("@userIDinsert", _userIDinsert)
                cmdToExecute.Parameters.AddWithValue("@userIDupdate", _userIDupdate)

                ' // Open Connection
                _mainConnection.Open()

                ' // Execute Query
                cmdToExecute.ExecuteNonQuery()

                _drillPipeReportDtID = strDrillPipeReportDtID
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
            cmdToExecute.CommandText = "UPDATE DrillPipeReportDt " + _
                                        "SET sequenceNo=@sequenceNo, serialNo=@serialNo, remarks=@remarks, " + _
                                        "bdBodyWear=@bdBodyWear, bdBent=@bdBent, bdBodyDamage=@bdBodyDamage, bdEMI=@bdEMI, " + _
                                        "bdUTEndArea=@bdUTEndArea, bdPlasticCoating=@bdPlasticCoating, bdWall=@bdWall, bdWallRemanent=@bdWallRemanent, " + _
                                        "bdTubeClass=@bdTubeClass, pcToolJointYear=@pcToolJointYear, pcOutsideDia=@pcOutsideDia, pcInsideDia=@pcInsideDia, " + _
                                        "pcTongSpace=@pcTongSpace, pcThreadLength=@pcThreadLength, pcBevelDia=@pcBevelDia, pcLead=@pcLead, " + _
                                        "pcShoulderWidth=@pcShoulderWidth, pcNeckLength=@pcNeckLength, pcReface=@pcReface, pcFinalCondition=@pcFinalCondition, " + _
                                        "bcOutsideDia=@bcOutsideDia, bcTongSpace=@bcTongSpace, bcQCDia=@bcQCDia, bcQCDepth=@bcQCDepth, bcShoulderWidth=@bcShoulderWidth, " + _
                                        "bcBevelDia=@bcBevelDia, bcSealWidth=@bcSealWidth, bcReface=@bcReface, bcFinalCondition=@bcFinalCondition, " + _
                                        "userIDupdate=@userIDupdate, updateDate=GETDATE() " + _
                                        "WHERE drillPipeReportDtID=@drillPipeReportDtID"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try                
                cmdToExecute.Parameters.AddWithValue("@drillPipeReportDtID", _drillPipeReportDtID)
                cmdToExecute.Parameters.AddWithValue("@sequenceNo", _sequenceNo)
                cmdToExecute.Parameters.AddWithValue("@serialNo", _serialNo)
                cmdToExecute.Parameters.AddWithValue("@remarks", _remarks)
                cmdToExecute.Parameters.AddWithValue("@bdBodyWear", _bdBodyWear)
                cmdToExecute.Parameters.AddWithValue("@bdBent", _bdBent)
                cmdToExecute.Parameters.AddWithValue("@bdBodyDamage", _bdBodyDamage)
                cmdToExecute.Parameters.AddWithValue("@bdEMI", _bdEMI)
                cmdToExecute.Parameters.AddWithValue("@bdUTEndArea", _bdUTEndArea)
                cmdToExecute.Parameters.AddWithValue("@bdPlasticCoating", _bdPlasticCoating)
                cmdToExecute.Parameters.AddWithValue("@bdWall", _bdWall)
                cmdToExecute.Parameters.AddWithValue("@bdWallRemanent", _bdWallRemanent)
                cmdToExecute.Parameters.AddWithValue("@bdTubeClass", _bdTubeClass)
                cmdToExecute.Parameters.AddWithValue("@pcToolJointYear", _pcToolJointYear)
                cmdToExecute.Parameters.AddWithValue("@pcOutsideDia", _pcOutsideDia)
                cmdToExecute.Parameters.AddWithValue("@pcInsideDia", _pcInsideDia)
                cmdToExecute.Parameters.AddWithValue("@pcTongSpace", _pcTongSpace)
                cmdToExecute.Parameters.AddWithValue("@pcThreadLength", _pcThreadLength)
                cmdToExecute.Parameters.AddWithValue("@pcBevelDia", _pcBevelDia)
                cmdToExecute.Parameters.AddWithValue("@pcLead", _pcLead)
                cmdToExecute.Parameters.AddWithValue("@pcShoulderWidth", _pcShoulderWidth)
                cmdToExecute.Parameters.AddWithValue("@pcNeckLength", _pcNeckLength)
                cmdToExecute.Parameters.AddWithValue("@pcReface", _pcReface)
                cmdToExecute.Parameters.AddWithValue("@pcFinalCondition", _pcFinalCondition)
                cmdToExecute.Parameters.AddWithValue("@bcOutsideDia", _bcOutsideDia)
                cmdToExecute.Parameters.AddWithValue("@bcTongSpace", _bcTongSpace)
                cmdToExecute.Parameters.AddWithValue("@bcQCDia", _bcQCDia)
                cmdToExecute.Parameters.AddWithValue("@bcQCDepth", _bcQCDepth)
                cmdToExecute.Parameters.AddWithValue("@bcShoulderWidth", _bcShoulderWidth)
                cmdToExecute.Parameters.AddWithValue("@bcBevelDia", _bcBevelDia)
                cmdToExecute.Parameters.AddWithValue("@bcSealWidth", _bcSealWidth)
                cmdToExecute.Parameters.AddWithValue("@bcReface", _bcReface)
                cmdToExecute.Parameters.AddWithValue("@bcFinalCondition", _bcFinalCondition)                
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
            cmdToExecute.CommandText = "SELECT * FROM DrillPipeReportDt"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("DrillPipeReportDt")
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
            cmdToExecute.CommandText = "SELECT * FROM DrillPipeReportDt WHERE drillPipeReportDtID=@drillPipeReportDtID"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("DrillPipeReportDt")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@drillPipeReportDtID", _drillPipeReportDtID)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 Then
                    _drillPipeReportHdID = CType(toReturn.Rows(0)("drillPipeReportHdID"), String)
                    _drillPipeReportDtID = CType(toReturn.Rows(0)("drillPipeReportDtID"), String)
                    _sequenceNo = CType(toReturn.Rows(0)("sequenceNo"), String)
                    _serialNo = CType(toReturn.Rows(0)("serialNo"), String)
                    _remarks = CType(toReturn.Rows(0)("remarks"), String)
                    _bdBodyWear = CType(toReturn.Rows(0)("bdBodyWear"), String)
                    _bdBent = CType(toReturn.Rows(0)("bdBent"), String)
                    _bdBodyDamage = CType(toReturn.Rows(0)("bdBodyDamage"), String)
                    _bdEMI = CType(toReturn.Rows(0)("bdEMI"), String)
                    _bdUTEndArea = CType(toReturn.Rows(0)("bdUTEndArea"), String)
                    _bdPlasticCoating = CType(toReturn.Rows(0)("bdPlasticCoating"), String)
                    _bdWall = CType(toReturn.Rows(0)("bdWall"), String)
                    _bdWallRemanent = CType(toReturn.Rows(0)("bdWallRemanent"), String)
                    _bdTubeClass = CType(toReturn.Rows(0)("bdTubeClass"), String)
                    _pcToolJointYear = CType(toReturn.Rows(0)("pcToolJointYear"), String)
                    _pcOutsideDia = CType(toReturn.Rows(0)("pcOutsideDia"), String)
                    _pcInsideDia = CType(toReturn.Rows(0)("pcInsideDia"), String)
                    _pcTongSpace = CType(toReturn.Rows(0)("pcTongSpace"), String)
                    _pcThreadLength = CType(toReturn.Rows(0)("pcThreadLength"), String)
                    _pcBevelDia = CType(toReturn.Rows(0)("pcBevelDia"), String)
                    _pcLead = CType(toReturn.Rows(0)("pcLead"), String)
                    _pcShoulderWidth = CType(toReturn.Rows(0)("pcShoulderWidth"), String)
                    _pcNeckLength = CType(toReturn.Rows(0)("pcNeckLength"), String)
                    _pcReface = CType(toReturn.Rows(0)("pcReface"), String)
                    _pcFinalCondition = CType(toReturn.Rows(0)("pcFinalCondition"), String)
                    _bcOutsideDia = CType(toReturn.Rows(0)("bcOutsideDia"), String)
                    _bcTongSpace = CType(toReturn.Rows(0)("bcTongSpace"), String)
                    _bcQCDia = CType(toReturn.Rows(0)("bcQCDia"), String)
                    _bcQCDepth = CType(toReturn.Rows(0)("bcQCDepth"), String)
                    _bcShoulderWidth = CType(toReturn.Rows(0)("bcShoulderWidth"), String)
                    _bcBevelDia = CType(toReturn.Rows(0)("bcBevelDia"), String)
                    _bcSealWidth = CType(toReturn.Rows(0)("bcSealWidth"), String)
                    _bcReface = CType(toReturn.Rows(0)("bcReface"), String)
                    _bcFinalCondition = CType(toReturn.Rows(0)("bcFinalCondition"), String)
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
            cmdToExecute.CommandText = "DELETE FROM DrillPipeReportDt " + _
                                        "WHERE drillPipeReportDtID=@drillPipeReportDtID"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@drillPipeReportDtID", _drillPipeReportDtID)

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
        Public Function SelectByDrillPipeReportHdID() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "SELECT drd.* " +
                                        "FROM DrillPipeReportDt drd WHERE drd.drillPipeReportHdID=@drillPipeReportHdID"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("DrillPipeReportDt")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@drillPipeReportHdID", _drillPipeReportHdID)

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
        Public Property [drillPipeReportHdID]() As String
            Get
                Return _drillPipeReportHdID
            End Get
            Set(ByVal Value As String)
                _drillPipeReportHdID = Value
            End Set
        End Property

        Public Property [drillPipeReportDtID]() As String
            Get
                Return _drillPipeReportDtID
            End Get
            Set(ByVal Value As String)
                _drillPipeReportDtID = Value
            End Set
        End Property

        Public Property [sequenceNo]() As String
            Get
                Return _sequenceNo
            End Get
            Set(ByVal Value As String)
                _sequenceNo = Value
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

        Public Property [remarks]() As String
            Get
                Return _remarks
            End Get
            Set(ByVal Value As String)
                _remarks = Value
            End Set
        End Property

        Public Property [bdBodyWear]() As String
            Get
                Return _bdBodyWear
            End Get
            Set(ByVal Value As String)
                _bdBodyWear = Value
            End Set
        End Property

        Public Property [bdBent]() As String
            Get
                Return _bdBent
            End Get
            Set(ByVal Value As String)
                _bdBent = Value
            End Set
        End Property

        Public Property [bdBodyDamage]() As String
            Get
                Return _bdBodyDamage
            End Get
            Set(ByVal Value As String)
                _bdBodyDamage = Value
            End Set
        End Property

        Public Property [bdEMI]() As String
            Get
                Return _bdEMI
            End Get
            Set(ByVal Value As String)
                _bdEMI = Value
            End Set
        End Property

        Public Property [bdUTEndArea]() As String
            Get
                Return _bdUTEndArea
            End Get
            Set(ByVal Value As String)
                _bdUTEndArea = Value
            End Set
        End Property

        Public Property [bdPlasticCoating]() As String
            Get
                Return _bdPlasticCoating
            End Get
            Set(ByVal Value As String)
                _bdPlasticCoating = Value
            End Set
        End Property

        Public Property [bdWall]() As String
            Get
                Return _bdWall
            End Get
            Set(ByVal Value As String)
                _bdWall = Value
            End Set
        End Property

        Public Property [bdWallRemanent]() As String
            Get
                Return _bdWallRemanent
            End Get
            Set(ByVal Value As String)
                _bdWallRemanent = Value
            End Set
        End Property

        Public Property [bdTubeClass]() As String
            Get
                Return _bdTubeClass
            End Get
            Set(ByVal Value As String)
                _bdTubeClass = Value
            End Set
        End Property

        Public Property [pcToolJointYear]() As String
            Get
                Return _pcToolJointYear
            End Get
            Set(ByVal Value As String)
                _pcToolJointYear = Value
            End Set
        End Property

        Public Property [pcOutsideDia]() As String
            Get
                Return _pcOutsideDia
            End Get
            Set(ByVal Value As String)
                _pcOutsideDia = Value
            End Set
        End Property

        Public Property [pcInsideDia]() As String
            Get
                Return _pcInsideDia
            End Get
            Set(ByVal Value As String)
                _pcInsideDia = Value
            End Set
        End Property

        Public Property [pcTongSpace]() As String
            Get
                Return _pcTongSpace
            End Get
            Set(ByVal Value As String)
                _pcTongSpace = Value
            End Set
        End Property

        Public Property [pcThreadLength]() As String
            Get
                Return _pcThreadLength
            End Get
            Set(ByVal Value As String)
                _pcThreadLength = Value
            End Set
        End Property

        Public Property [pcBevelDia]() As String
            Get
                Return _pcBevelDia
            End Get
            Set(ByVal Value As String)
                _pcBevelDia = Value
            End Set
        End Property

        Public Property [pcLead]() As String
            Get
                Return _pcLead
            End Get
            Set(ByVal Value As String)
                _pcLead = Value
            End Set
        End Property

        Public Property [pcShoulderWidth]() As String
            Get
                Return _pcShoulderWidth
            End Get
            Set(ByVal Value As String)
                _pcShoulderWidth = Value
            End Set
        End Property

        Public Property [pcNeckLength]() As String
            Get
                Return _pcNeckLength
            End Get
            Set(ByVal Value As String)
                _pcNeckLength = Value
            End Set
        End Property

        Public Property [pcReface]() As String
            Get
                Return _pcReface
            End Get
            Set(ByVal Value As String)
                _pcReface = Value
            End Set
        End Property

        Public Property [pcFinalCondition]() As String
            Get
                Return _pcFinalCondition
            End Get
            Set(ByVal Value As String)
                _pcFinalCondition = Value
            End Set
        End Property

        Public Property [bcOutsideDia]() As String
            Get
                Return _bcOutsideDia
            End Get
            Set(ByVal Value As String)
                _bcOutsideDia = Value
            End Set
        End Property

        Public Property [bcTongSpace]() As String
            Get
                Return _bcTongSpace
            End Get
            Set(ByVal Value As String)
                _bcTongSpace = Value
            End Set
        End Property

        Public Property [bcQCDia]() As String
            Get
                Return _bcQCDia
            End Get
            Set(ByVal Value As String)
                _bcQCDia = Value
            End Set
        End Property

        Public Property [bcQCDepth]() As String
            Get
                Return _bcQCDepth
            End Get
            Set(ByVal Value As String)
                _bcQCDepth = Value
            End Set
        End Property

        Public Property [bcShoulderWidth]() As String
            Get
                Return _bcShoulderWidth
            End Get
            Set(ByVal Value As String)
                _bcShoulderWidth = Value
            End Set
        End Property

        Public Property [bcBevelDia]() As String
            Get
                Return _bcBevelDia
            End Get
            Set(ByVal Value As String)
                _bcBevelDia = Value
            End Set
        End Property

        Public Property [bcSealWidth]() As String
            Get
                Return _bcSealWidth
            End Get
            Set(ByVal Value As String)
                _bcSealWidth = Value
            End Set
        End Property

        Public Property [bcReface]() As String
            Get
                Return _bcReface
            End Get
            Set(ByVal Value As String)
                _bcReface = Value
            End Set
        End Property

        Public Property [bcFinalCondition]() As String
            Get
                Return _bcFinalCondition
            End Get
            Set(ByVal Value As String)
                _bcFinalCondition = Value
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
