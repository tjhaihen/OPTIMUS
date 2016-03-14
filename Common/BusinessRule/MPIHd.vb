Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports Raven.Common

Namespace Raven.Common.BussinessRules
    Public Class MPIHd
        Inherits BRInteractionBase

#Region " Class Member Declarations "        
        Private _MPIHdID, _projectID, _reportNo, _serialNo, _MPITypeSCode, _description, _qty, _dimension As String
        Private _areaInspection, _ACOtherDescription, _material, _surfaceCondition, _metalSurfaceTemp, _materialThickness As String
        Private _setCalibration, _poleSpacing, _application, _contrast, _magneticParticle, _cleaner, _penetrant As String
        Private _developer, _yokeSCode, _coilSCode, _fluorescentSCode, _contrastBWSCode, _inspectionResult, _notes As String
        Private _ACIsASME, _ACIsAPISpec, _ACIsDS1, _ACIsOther, _isBlacklight, _isRods, _isDyePenetrant, _isWireBrush As Boolean
        Private _isBlastCleaning, _isGrinding, _isMachining As Boolean
        Private _isEqpYoke, _isEqpCoil, _isEqpRods, _isEqpBlacklight, _isMagPermanent, _isMagActive As Boolean
        Private _isSysWet, _isSysDry, _isSysDye, _isSysFluorescent, _isSysContrastBW, _isSysDyePenetrant As Boolean
        Private _ACASMEDescription, _ACAPISpecDescription, _ACDS1Description As String
        Private _yokeSerialNo, _coilSerialNo, _rodsSerialNo, _blacklightSerialNo As String
        Private _MGWSWLWLLcaptionSCode, _MGWSWLWLLvalue As String
        Private _reportDate, _expiredDate As DateTime
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
            cmdToExecute.CommandText = "INSERT INTO MPIHd " + _
                                        "(MPIHdID, projectID, reportNo, serialNo, MPITypeSCode, description, qty, dimension, " + _
                                        "areaInspection, material, surfaceCondition, metalSurfaceTemp, materialThickness, " + _
                                        "setCalibration, poleSpacing, application, contrast, magneticParticle, cleaner, penetrant, " + _
                                        "developer, yokeSCode, coilSCode, fluorescentSCode, contrastBWSCode, inspectionResult, notes, " + _
                                        "yokeSerialNo, coilSerialNo, rodsSerialNo, blacklightSerialNo, " + _
                                        "ACASMEDescription, ACAPISpecDescription, ACDS1Description, ACOtherDescription, " + _
                                        "ACIsASME, ACIsAPISpec, ACIsDS1, ACIsOther, isBlacklight, isRods, isDyePenetrant, isWireBrush, " + _
                                        "isBlastCleaning, isGrinding, isMachining, " + _
                                        "isEqpYoke, isEqpCoil, isEqpRods, isEqpBlacklight, isMagPermanent, isMagActive, " + _
                                        "isSysWet, isSysDry, isSysDye, isSysFluorescent, isSysContrastBW, isSysDyePenetrant, " + _
                                        "MGWSWLWLLcaptionSCode, MGWSWLWLLvalue, " + _
                                        "reportDate, expiredDate, insertDate, updateDate, " + _
                                        "userIDInsert, userIDUpdate) " + _
                                        "VALUES " + _
                                        "(@MPIHdID, @projectID, @reportNo, @serialNo, @MPITypeSCode, @description, @qty, @dimension, " + _
                                        "@areaInspection, @material, @surfaceCondition, @metalSurfaceTemp, @materialThickness, " + _
                                        "@setCalibration, @poleSpacing, @application, @contrast, @magneticParticle, @cleaner, @penetrant, " + _
                                        "@developer, @yokeSCode, @coilSCode, @fluorescentSCode, @contrastBWSCode, @inspectionResult, @notes, " + _
                                        "@yokeSerialNo, @coilSerialNo, @rodsSerialNo, @blacklightSerialNo, " + _
                                        "@ACASMEDescription, @ACAPISpecDescription, @ACDS1Description, @ACOtherDescription, " + _
                                        "@ACIsASME, @ACIsAPISpec, @ACIsDS1, @ACIsOther, @isBlacklight, @isRods, @isDyePenetrant, @isWireBrush, " + _
                                        "@isBlastCleaning, @isGrinding, @isMachining, " + _
                                        "@isEqpYoke, @isEqpCoil, @isEqpRods, @isEqpBlacklight, @isMagPermanent, @isMagActive, " + _
                                        "@isSysWet, @isSysDry, @isSysDye, @isSysFluorescent, @isSysContrastBW, @isSysDyePenetrant, " + _
                                        "@MGWSWLWLLcaptionSCode, @MGWSWLWLLvalue, " + _
                                        "@reportDate, @expiredDate, GETDATE(), GETDATE(), " + _
                                        "@userIDInsert, @userIDUpdate) "
            cmdToExecute.CommandType = CommandType.Text
            cmdToExecute.Connection = _mainConnection

            Dim strID As String = ID.GenerateIDNumber("MPIHd", "MPIHdID")

            Try
                cmdToExecute.Parameters.AddWithValue("@MPIHdID", strID)
                cmdToExecute.Parameters.AddWithValue("@projectID", _projectID)
                cmdToExecute.Parameters.AddWithValue("@reportNo", _reportNo)
                cmdToExecute.Parameters.AddWithValue("@serialNo", _serialNo)
                cmdToExecute.Parameters.AddWithValue("@MPITypeSCode", _MPITypeSCode)
                cmdToExecute.Parameters.AddWithValue("@description", _description)
                cmdToExecute.Parameters.AddWithValue("@qty", _qty)
                cmdToExecute.Parameters.AddWithValue("@dimension", _dimension)
                cmdToExecute.Parameters.AddWithValue("@areaInspection", _areaInspection)                
                cmdToExecute.Parameters.AddWithValue("@material", _material)
                cmdToExecute.Parameters.AddWithValue("@surfaceCondition", _surfaceCondition)
                cmdToExecute.Parameters.AddWithValue("@metalSurfaceTemp", _metalSurfaceTemp)
                cmdToExecute.Parameters.AddWithValue("@materialThickness", _materialThickness)
                cmdToExecute.Parameters.AddWithValue("@setCalibration", _setCalibration)
                cmdToExecute.Parameters.AddWithValue("@poleSpacing", _poleSpacing)
                cmdToExecute.Parameters.AddWithValue("@application", _application)
                cmdToExecute.Parameters.AddWithValue("@contrast", _contrast)
                cmdToExecute.Parameters.AddWithValue("@magneticParticle", _magneticParticle)
                cmdToExecute.Parameters.AddWithValue("@cleaner", _cleaner)
                cmdToExecute.Parameters.AddWithValue("@penetrant", _penetrant)
                cmdToExecute.Parameters.AddWithValue("@developer", _developer)
                cmdToExecute.Parameters.AddWithValue("@yokeSCode", _yokeSCode)
                cmdToExecute.Parameters.AddWithValue("@coilSCode", _coilSCode)
                cmdToExecute.Parameters.AddWithValue("@fluorescentSCode", _fluorescentSCode)
                cmdToExecute.Parameters.AddWithValue("@contrastBWSCode", _contrastBWSCode)
                cmdToExecute.Parameters.AddWithValue("@inspectionResult", _inspectionResult)
                cmdToExecute.Parameters.AddWithValue("@notes", _notes)
                cmdToExecute.Parameters.AddWithValue("@yokeSerialNo", _yokeSerialNo)
                cmdToExecute.Parameters.AddWithValue("@coilSerialNo", _coilSerialNo)
                cmdToExecute.Parameters.AddWithValue("@rodsSerialNo", _rodsSerialNo)
                cmdToExecute.Parameters.AddWithValue("@blacklightSerialNo", _blacklightSerialNo)
                cmdToExecute.Parameters.AddWithValue("@ACASMEDescription", _ACASMEDescription)
                cmdToExecute.Parameters.AddWithValue("@ACAPISpecDescription", _ACAPISpecDescription)
                cmdToExecute.Parameters.AddWithValue("@ACDS1Description", _ACDS1Description)
                cmdToExecute.Parameters.AddWithValue("@ACOtherDescription", _ACOtherDescription)
                cmdToExecute.Parameters.AddWithValue("@ACIsASME", _ACIsASME)
                cmdToExecute.Parameters.AddWithValue("@ACIsAPISpec", _ACIsAPISpec)
                cmdToExecute.Parameters.AddWithValue("@ACIsDS1", _ACIsDS1)
                cmdToExecute.Parameters.AddWithValue("@ACIsOther", _ACIsOther)
                cmdToExecute.Parameters.AddWithValue("@isBlacklight", _isBlacklight)
                cmdToExecute.Parameters.AddWithValue("@isRods", _isRods)
                cmdToExecute.Parameters.AddWithValue("@isDyePenetrant", _isDyePenetrant)
                cmdToExecute.Parameters.AddWithValue("@isWireBrush", _isWireBrush)
                cmdToExecute.Parameters.AddWithValue("@isBlastCleaning", _isBlastCleaning)
                cmdToExecute.Parameters.AddWithValue("@isGrinding", _isGrinding)
                cmdToExecute.Parameters.AddWithValue("@isMachining", _isMachining)
                cmdToExecute.Parameters.AddWithValue("@isEqpYoke", _isEqpYoke)
                cmdToExecute.Parameters.AddWithValue("@isEqpCoil", _isEqpCoil)
                cmdToExecute.Parameters.AddWithValue("@isEqpRods", _isEqpRods)
                cmdToExecute.Parameters.AddWithValue("@isEqpBlacklight", _isEqpBlacklight)
                cmdToExecute.Parameters.AddWithValue("@isMagPermanent", _isMagPermanent)
                cmdToExecute.Parameters.AddWithValue("@isMagActive", _isMagActive)
                cmdToExecute.Parameters.AddWithValue("@isSysWet", _isSysWet)
                cmdToExecute.Parameters.AddWithValue("@isSysDry", _isSysDry)
                cmdToExecute.Parameters.AddWithValue("@isSysDye", _isSysDye)
                cmdToExecute.Parameters.AddWithValue("@isSysFluorescent", _isSysFluorescent)
                cmdToExecute.Parameters.AddWithValue("@isSysContrastBW", _isSysContrastBW)
                cmdToExecute.Parameters.AddWithValue("@isSysDyePenetrant", _isSysDyePenetrant)
                cmdToExecute.Parameters.AddWithValue("@MGWSWLWLLcaptionSCode", _MGWSWLWLLcaptionSCode)
                cmdToExecute.Parameters.AddWithValue("@MGWSWLWLLvalue", _MGWSWLWLLvalue)
                cmdToExecute.Parameters.AddWithValue("@reportDate", _reportDate)
                cmdToExecute.Parameters.AddWithValue("@expiredDate", _expiredDate)
                cmdToExecute.Parameters.AddWithValue("@userIDinsert", _userIDinsert)
                cmdToExecute.Parameters.AddWithValue("@userIDupdate", _userIDupdate)

                ' // Open Connection
                _mainConnection.Open()

                ' // Execute Query
                cmdToExecute.ExecuteNonQuery()

                _MPIHdID = strID
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
            cmdToExecute.CommandText = "UPDATE MPIHd " + _
                                        "SET reportNo=@reportNo, serialNo=@serialNo, MPITypeSCode=@MPITypeSCode, description=@description, qty=@qty, dimension=@dimension, " + _
                                        "areaInspection=@areaInspection, material=@material, surfaceCondition=@surfaceCondition, " + _
                                        "metalSurfaceTemp=@metalSurfaceTemp, materialThickness=@materialThickness, " + _
                                        "setCalibration=@setCalibration, poleSpacing=@poleSpacing, application=@application, contrast=@contrast, magneticParticle=@magneticParticle, cleaner=@cleaner, penetrant=@penetrant, " + _
                                        "developer=@developer, yokeSCode=@yokeSCode, coilSCode=@coilSCode, fluorescentSCode=@fluorescentSCode, contrastBWSCode=@contrastBWSCode, inspectionResult=@inspectionResult, notes=@notes, " + _
                                        "yokeSerialNo=@yokeSerialNo, coilSerialNo=@coilSerialNo, rodsSerialNo=@rodsSerialNo, blacklightSerialNo=@blacklightSerialNo, " + _
                                        "ACASMEDescription=@ACASMEDescription, ACAPISpecDescription=@ACAPISpecDescription, ACDS1Description=@ACDS1Description, ACOtherDescription=@ACOtherDescription, " + _
                                        "ACIsASME=@ACIsASME, ACIsAPISpec=@ACIsAPISpec, ACIsDS1=@ACIsDS1, ACIsOther=@ACIsOther, isBlacklight=@isBlacklight, isRods=@isRods, isDyePenetrant=@isDyePenetrant, isWireBrush=@isWireBrush, " + _
                                        "isBlastCleaning=@isBlastCleaning, isGrinding=@isGrinding, isMachining=@isMachining, " + _
                                        "isEqpYoke=@isEqpYoke, isEqpCoil=@isEqpCoil, isEqpRods=@isEqpRods, isEqpBlacklight=@isEqpBlacklight, isMagPermanent=@isMagPermanent, isMagActive=@isMagActive, " + _
                                        "isSysWet=@isSysWet, isSysDry=@isSysDry, isSysDye=@isSysDye, isSysFluorescent=@isSysFluorescent, isSysContrastBW=@isSysContrastBW, isSysDyePenetrant=@isSysDyePenetrant, " + _
                                        "MGWSWLWLLcaptionSCode=@MGWSWLWLLcaptionSCode, MGWSWLWLLvalue=@MGWSWLWLLvalue, " + _
                                        "reportDate=@reportDate, expiredDate=@expiredDate, updateDate=GETDATE(), userIDUpdate=@userIDUpdate " + _
                                        "WHERE MPIHdID=@MPIHdID"
            cmdToExecute.CommandType = CommandType.Text
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@MPIHdID", _MPIHdID)                
                cmdToExecute.Parameters.AddWithValue("@reportNo", _reportNo)
                cmdToExecute.Parameters.AddWithValue("@serialNo", _serialNo)
                cmdToExecute.Parameters.AddWithValue("@MPITypeSCode", _MPITypeSCode)
                cmdToExecute.Parameters.AddWithValue("@description", _description)
                cmdToExecute.Parameters.AddWithValue("@qty", _qty)
                cmdToExecute.Parameters.AddWithValue("@dimension", _dimension)
                cmdToExecute.Parameters.AddWithValue("@areaInspection", _areaInspection)
                cmdToExecute.Parameters.AddWithValue("@material", _material)
                cmdToExecute.Parameters.AddWithValue("@surfaceCondition", _surfaceCondition)
                cmdToExecute.Parameters.AddWithValue("@metalSurfaceTemp", _metalSurfaceTemp)
                cmdToExecute.Parameters.AddWithValue("@materialThickness", _materialThickness)
                cmdToExecute.Parameters.AddWithValue("@setCalibration", _setCalibration)
                cmdToExecute.Parameters.AddWithValue("@poleSpacing", _poleSpacing)
                cmdToExecute.Parameters.AddWithValue("@application", _application)
                cmdToExecute.Parameters.AddWithValue("@contrast", _contrast)
                cmdToExecute.Parameters.AddWithValue("@magneticParticle", _magneticParticle)
                cmdToExecute.Parameters.AddWithValue("@cleaner", _cleaner)
                cmdToExecute.Parameters.AddWithValue("@penetrant", _penetrant)
                cmdToExecute.Parameters.AddWithValue("@developer", _developer)
                cmdToExecute.Parameters.AddWithValue("@yokeSCode", _yokeSCode)
                cmdToExecute.Parameters.AddWithValue("@coilSCode", _coilSCode)
                cmdToExecute.Parameters.AddWithValue("@fluorescentSCode", _fluorescentSCode)
                cmdToExecute.Parameters.AddWithValue("@contrastBWSCode", _contrastBWSCode)
                cmdToExecute.Parameters.AddWithValue("@inspectionResult", _inspectionResult)
                cmdToExecute.Parameters.AddWithValue("@notes", _notes)
                cmdToExecute.Parameters.AddWithValue("@yokeSerialNo", _yokeSerialNo)
                cmdToExecute.Parameters.AddWithValue("@coilSerialNo", _coilSerialNo)
                cmdToExecute.Parameters.AddWithValue("@rodsSerialNo", _rodsSerialNo)
                cmdToExecute.Parameters.AddWithValue("@blacklightSerialNo", _blacklightSerialNo)
                cmdToExecute.Parameters.AddWithValue("@ACASMEDescription", _ACASMEDescription)
                cmdToExecute.Parameters.AddWithValue("@ACAPISpecDescription", _ACAPISpecDescription)
                cmdToExecute.Parameters.AddWithValue("@ACDS1Description", _ACDS1Description)
                cmdToExecute.Parameters.AddWithValue("@ACOtherDescription", _ACOtherDescription)
                cmdToExecute.Parameters.AddWithValue("@ACIsASME", _ACIsASME)
                cmdToExecute.Parameters.AddWithValue("@ACIsAPISpec", _ACIsAPISpec)
                cmdToExecute.Parameters.AddWithValue("@ACIsDS1", _ACIsDS1)
                cmdToExecute.Parameters.AddWithValue("@ACIsOther", _ACIsOther)
                cmdToExecute.Parameters.AddWithValue("@isBlacklight", _isBlacklight)
                cmdToExecute.Parameters.AddWithValue("@isRods", _isRods)
                cmdToExecute.Parameters.AddWithValue("@isDyePenetrant", _isDyePenetrant)
                cmdToExecute.Parameters.AddWithValue("@isWireBrush", _isWireBrush)
                cmdToExecute.Parameters.AddWithValue("@isBlastCleaning", _isBlastCleaning)
                cmdToExecute.Parameters.AddWithValue("@isGrinding", _isGrinding)
                cmdToExecute.Parameters.AddWithValue("@isMachining", _isMachining)
                cmdToExecute.Parameters.AddWithValue("@isEqpYoke", _isEqpYoke)
                cmdToExecute.Parameters.AddWithValue("@isEqpCoil", _isEqpCoil)
                cmdToExecute.Parameters.AddWithValue("@isEqpRods", _isEqpRods)
                cmdToExecute.Parameters.AddWithValue("@isEqpBlacklight", _isEqpBlacklight)
                cmdToExecute.Parameters.AddWithValue("@isMagPermanent", _isMagPermanent)
                cmdToExecute.Parameters.AddWithValue("@isMagActive", _isMagActive)
                cmdToExecute.Parameters.AddWithValue("@isSysWet", _isSysWet)
                cmdToExecute.Parameters.AddWithValue("@isSysDry", _isSysDry)
                cmdToExecute.Parameters.AddWithValue("@isSysDye", _isSysDye)
                cmdToExecute.Parameters.AddWithValue("@isSysFluorescent", _isSysFluorescent)
                cmdToExecute.Parameters.AddWithValue("@isSysContrastBW", _isSysContrastBW)
                cmdToExecute.Parameters.AddWithValue("@isSysDyePenetrant", _isSysDyePenetrant)
                cmdToExecute.Parameters.AddWithValue("@MGWSWLWLLcaptionSCode", _MGWSWLWLLcaptionSCode)
                cmdToExecute.Parameters.AddWithValue("@MGWSWLWLLvalue", _MGWSWLWLLvalue)
                cmdToExecute.Parameters.AddWithValue("@reportDate", _reportDate)
                cmdToExecute.Parameters.AddWithValue("@expiredDate", _expiredDate)                
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
            cmdToExecute.CommandText = "SELECT * FROM MPIHd"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("MPIHd")
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
            cmdToExecute.CommandText = "SELECT * FROM MPIHd WHERE MPIHdID=@MPIHdID"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("MPIHd")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@MPIHdID", _MPIHdID)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 Then
                    _MPIHdID = CType(toReturn.Rows(0)("MPIHdID"), String)
                    _projectID = CType(toReturn.Rows(0)("projectID"), String)
                    _reportNo = CType(toReturn.Rows(0)("reportNo"), String)
                    _serialNo = CType(toReturn.Rows(0)("serialNo"), String)
                    _reportDate = CType(toReturn.Rows(0)("reportDate"), DateTime)
                    _expiredDate = CType(toReturn.Rows(0)("expiredDate"), DateTime)
                    _MPITypeSCode = CType(toReturn.Rows(0)("MPITypeSCode"), String)
                    _description = CType(toReturn.Rows(0)("description"), String)
                    _qty = CType(toReturn.Rows(0)("qty"), String)
                    _dimension = CType(toReturn.Rows(0)("dimension"), String)
                    _areaInspection = CType(toReturn.Rows(0)("areaInspection"), String)
                    _material = CType(toReturn.Rows(0)("material"), String)
                    _surfaceCondition = CType(toReturn.Rows(0)("surfaceCondition"), String)
                    _metalSurfaceTemp = CType(toReturn.Rows(0)("metalSurfaceTemp"), String)
                    _materialThickness = CType(toReturn.Rows(0)("materialThickness"), String)
                    _setCalibration = CType(toReturn.Rows(0)("setCalibration"), String)
                    _poleSpacing = CType(toReturn.Rows(0)("poleSpacing"), String)
                    _application = CType(toReturn.Rows(0)("application"), String)
                    _contrast = CType(toReturn.Rows(0)("contrast"), String)
                    _magneticParticle = CType(toReturn.Rows(0)("magneticParticle"), String)
                    _cleaner = CType(toReturn.Rows(0)("cleaner"), String)
                    _penetrant = CType(toReturn.Rows(0)("penetrant"), String)
                    _developer = CType(toReturn.Rows(0)("developer"), String)
                    _yokeSCode = CType(toReturn.Rows(0)("yokeSCode"), String)
                    _coilSCode = CType(toReturn.Rows(0)("coilSCode"), String)
                    _fluorescentSCode = CType(toReturn.Rows(0)("fluorescentSCode"), String)
                    _contrastBWSCode = CType(toReturn.Rows(0)("contrastBWSCode"), String)
                    _inspectionResult = CType(toReturn.Rows(0)("inspectionResult"), String)
                    _notes = CType(toReturn.Rows(0)("notes"), String)
                    _yokeSerialNo = CType(toReturn.Rows(0)("yokeSerialNo"), String)
                    _coilSerialNo = CType(toReturn.Rows(0)("coilSerialNo"), String)
                    _rodsSerialNo = CType(toReturn.Rows(0)("rodsSerialNo"), String)
                    _blacklightSerialNo = CType(toReturn.Rows(0)("blacklightSerialNo"), String)
                    _ACASMEDescription = CType(toReturn.Rows(0)("ACASMEDescription"), String)
                    _ACAPISpecDescription = CType(toReturn.Rows(0)("ACAPISpecDescription"), String)
                    _ACDS1Description = CType(toReturn.Rows(0)("ACDS1Description"), String)
                    _ACOtherDescription = CType(toReturn.Rows(0)("ACOtherDescription"), String)
                    _ACIsASME = CType(toReturn.Rows(0)("ACIsASME"), Boolean)
                    _ACIsAPISpec = CType(toReturn.Rows(0)("ACIsAPISpec"), Boolean)
                    _ACIsDS1 = CType(toReturn.Rows(0)("ACIsDS1"), Boolean)
                    _ACIsOther = CType(toReturn.Rows(0)("ACIsOther"), Boolean)
                    _isBlacklight = CType(toReturn.Rows(0)("isBlacklight"), Boolean)
                    _isRods = CType(toReturn.Rows(0)("isRods"), Boolean)
                    _isDyePenetrant = CType(toReturn.Rows(0)("isDyePenetrant"), Boolean)
                    _isWireBrush = CType(toReturn.Rows(0)("isWireBrush"), Boolean)
                    _isBlastCleaning = CType(toReturn.Rows(0)("isBlastCleaning"), Boolean)
                    _isGrinding = CType(toReturn.Rows(0)("isGrinding"), Boolean)
                    _isMachining = CType(toReturn.Rows(0)("isMachining"), Boolean)
                    _isEqpYoke = CType(toReturn.Rows(0)("isEqpYoke"), Boolean)
                    _isEqpCoil = CType(toReturn.Rows(0)("isEqpCoil"), Boolean)
                    _isEqpRods = CType(toReturn.Rows(0)("isEqpRods"), Boolean)
                    _isEqpBlacklight = CType(toReturn.Rows(0)("isEqpBlacklight"), Boolean)
                    _isMagPermanent = CType(toReturn.Rows(0)("isMagPermanent"), Boolean)
                    _isMagActive = CType(toReturn.Rows(0)("isMagActive"), Boolean)
                    _isSysWet = CType(toReturn.Rows(0)("isSysWet"), Boolean)
                    _isSysDry = CType(toReturn.Rows(0)("isSysDry"), Boolean)
                    _isSysDye = CType(toReturn.Rows(0)("isSysDye"), Boolean)
                    _isSysFluorescent = CType(toReturn.Rows(0)("isSysFluorescent"), Boolean)
                    _isSysContrastBW = CType(toReturn.Rows(0)("isSysContrastBW"), Boolean)
                    _isSysDyePenetrant = CType(toReturn.Rows(0)("isSysDyePenetrant"), Boolean)
                    _MGWSWLWLLcaptionSCode = CType(toReturn.Rows(0)("MGWSWLWLLcaptionSCode"), String)
                    _MGWSWLWLLvalue = CType(toReturn.Rows(0)("MGWSWLWLLvalue"), String)
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
            cmdToExecute.CommandText = "DELETE FROM MPIHd " + _
                                        "WHERE MPIHdID=@MPIHdID"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@MPIHdID", _MPIHdID)

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
                                        "FROM MPIHd WHERE projectID=@projectID"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("MPIHd")
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
        Public Property [MPIHdID]() As String
            Get
                Return _MPIHdID
            End Get
            Set(ByVal Value As String)
                _MPIHdID = Value
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

        Public Property [reportNo]() As String
            Get
                Return _reportNo
            End Get
            Set(ByVal Value As String)
                _reportNo = Value
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

        Public Property [MPITypeSCode]() As String
            Get
                Return _MPITypeSCode
            End Get
            Set(ByVal Value As String)
                _MPITypeSCode = Value
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

        Public Property [qty]() As String
            Get
                Return _qty
            End Get
            Set(ByVal Value As String)
                _qty = Value
            End Set
        End Property

        Public Property [dimension]() As String
            Get
                Return _dimension
            End Get
            Set(ByVal Value As String)
                _dimension = Value
            End Set
        End Property

        Public Property [areaInspection]() As String
            Get
                Return _areaInspection
            End Get
            Set(ByVal Value As String)
                _areaInspection = Value
            End Set
        End Property

        Public Property [material]() As String
            Get
                Return _material
            End Get
            Set(ByVal Value As String)
                _material = Value
            End Set
        End Property

        Public Property [surfaceCondition]() As String
            Get
                Return _surfaceCondition
            End Get
            Set(ByVal Value As String)
                _surfaceCondition = Value
            End Set
        End Property

        Public Property [metalSurfaceTemp]() As String
            Get
                Return _metalSurfaceTemp
            End Get
            Set(ByVal Value As String)
                _metalSurfaceTemp = Value
            End Set
        End Property

        Public Property [materialThickness]() As String
            Get
                Return _materialThickness
            End Get
            Set(ByVal Value As String)
                _materialThickness = Value
            End Set
        End Property

        Public Property [setCalibration]() As String
            Get
                Return _setCalibration
            End Get
            Set(ByVal Value As String)
                _setCalibration = Value
            End Set
        End Property

        Public Property [poleSpacing]() As String
            Get
                Return _poleSpacing
            End Get
            Set(ByVal Value As String)
                _poleSpacing = Value
            End Set
        End Property

        Public Property [application]() As String
            Get
                Return _application
            End Get
            Set(ByVal Value As String)
                _application = Value
            End Set
        End Property

        Public Property [contrast]() As String
            Get
                Return _contrast
            End Get
            Set(ByVal Value As String)
                _contrast = Value
            End Set
        End Property

        Public Property [magneticParticle]() As String
            Get
                Return _magneticParticle
            End Get
            Set(ByVal Value As String)
                _magneticParticle = Value
            End Set
        End Property

        Public Property [cleaner]() As String
            Get
                Return _cleaner
            End Get
            Set(ByVal Value As String)
                _cleaner = Value
            End Set
        End Property

        Public Property [penetrant]() As String
            Get
                Return _penetrant
            End Get
            Set(ByVal Value As String)
                _penetrant = Value
            End Set
        End Property

        Public Property [developer]() As String
            Get
                Return _developer
            End Get
            Set(ByVal Value As String)
                _developer = Value
            End Set
        End Property

        Public Property [yokeSCode]() As String
            Get
                Return _yokeSCode
            End Get
            Set(ByVal Value As String)
                _yokeSCode = Value
            End Set
        End Property

        Public Property [coilSCode]() As String
            Get
                Return _coilSCode
            End Get
            Set(ByVal Value As String)
                _coilSCode = Value
            End Set
        End Property

        Public Property [fluorescentSCode]() As String
            Get
                Return _fluorescentSCode
            End Get
            Set(ByVal Value As String)
                _fluorescentSCode = Value
            End Set
        End Property

        Public Property [contrastBWSCode]() As String
            Get
                Return _contrastBWSCode
            End Get
            Set(ByVal Value As String)
                _contrastBWSCode = Value
            End Set
        End Property

        Public Property [inspectionResult]() As String
            Get
                Return _inspectionResult
            End Get
            Set(ByVal Value As String)
                _inspectionResult = Value
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

        Public Property [yokeSerialNo]() As String
            Get
                Return _yokeSerialNo
            End Get
            Set(ByVal Value As String)
                _yokeSerialNo = Value
            End Set
        End Property

        Public Property [coilSerialNo]() As String
            Get
                Return _coilSerialNo
            End Get
            Set(ByVal Value As String)
                _coilSerialNo = Value
            End Set
        End Property

        Public Property [rodsSerialNo]() As String
            Get
                Return _rodsSerialNo
            End Get
            Set(ByVal Value As String)
                _rodsSerialNo = Value
            End Set
        End Property

        Public Property [blacklightSerialNo]() As String
            Get
                Return _blacklightSerialNo
            End Get
            Set(ByVal Value As String)
                _blacklightSerialNo = Value
            End Set
        End Property

        Public Property [ACASMEDescription]() As String
            Get
                Return _ACASMEDescription
            End Get
            Set(ByVal Value As String)
                _ACASMEDescription = Value
            End Set
        End Property

        Public Property [ACAPISpecDescription]() As String
            Get
                Return _ACAPISpecDescription
            End Get
            Set(ByVal Value As String)
                _ACAPISpecDescription = Value
            End Set
        End Property

        Public Property [ACDS1Description]() As String
            Get
                Return _ACDS1Description
            End Get
            Set(ByVal Value As String)
                _ACDS1Description = Value
            End Set
        End Property

        Public Property [ACOtherDescription]() As String
            Get
                Return _ACOtherDescription
            End Get
            Set(ByVal Value As String)
                _ACOtherDescription = Value
            End Set
        End Property

        Public Property [ACIsASME]() As Boolean
            Get
                Return _ACIsASME
            End Get
            Set(ByVal Value As Boolean)
                _ACIsASME = Value
            End Set
        End Property

        Public Property [ACIsAPISpec]() As Boolean
            Get
                Return _ACIsAPISpec
            End Get
            Set(ByVal Value As Boolean)
                _ACIsAPISpec = Value
            End Set
        End Property

        Public Property [ACIsDS1]() As Boolean
            Get
                Return _ACIsDS1
            End Get
            Set(ByVal Value As Boolean)
                _ACIsDS1 = Value
            End Set
        End Property

        Public Property [ACIsOther]() As Boolean
            Get
                Return _ACIsOther
            End Get
            Set(ByVal Value As Boolean)
                _ACIsOther = Value
            End Set
        End Property

        Public Property [isBlacklight]() As Boolean
            Get
                Return _isBlacklight
            End Get
            Set(ByVal Value As Boolean)
                _isBlacklight = Value
            End Set
        End Property

        Public Property [isRods]() As Boolean
            Get
                Return _isRods
            End Get
            Set(ByVal Value As Boolean)
                _isRods = Value
            End Set
        End Property

        Public Property [isDyePenetrant]() As Boolean
            Get
                Return _isDyePenetrant
            End Get
            Set(ByVal Value As Boolean)
                _isDyePenetrant = Value
            End Set
        End Property

        Public Property [isWireBrush]() As Boolean
            Get
                Return _isWireBrush
            End Get
            Set(ByVal Value As Boolean)
                _isWireBrush = Value
            End Set
        End Property

        Public Property [isBlastCleaning]() As Boolean
            Get
                Return _isBlastCleaning
            End Get
            Set(ByVal Value As Boolean)
                _isBlastCleaning = Value
            End Set
        End Property

        Public Property [isGrinding]() As Boolean
            Get
                Return _isGrinding
            End Get
            Set(ByVal Value As Boolean)
                _isGrinding = Value
            End Set
        End Property

        Public Property [isMachining]() As Boolean
            Get
                Return _isMachining
            End Get
            Set(ByVal Value As Boolean)
                _isMachining = Value
            End Set
        End Property

        Public Property [isEqpYoke]() As Boolean
            Get
                Return _isEqpYoke
            End Get
            Set(ByVal Value As Boolean)
                _isEqpYoke = Value
            End Set
        End Property

        Public Property [isEqpCoil]() As Boolean
            Get
                Return _isEqpCoil
            End Get
            Set(ByVal Value As Boolean)
                _isEqpCoil = Value
            End Set
        End Property

        Public Property [isEqpRods]() As Boolean
            Get
                Return _isEqpRods
            End Get
            Set(ByVal Value As Boolean)
                _isEqpRods = Value
            End Set
        End Property

        Public Property [isEqpBlacklight]() As Boolean
            Get
                Return _isEqpBlacklight
            End Get
            Set(ByVal Value As Boolean)
                _isEqpBlacklight = Value
            End Set
        End Property

        Public Property [isMagPermanent]() As Boolean
            Get
                Return _isMagPermanent
            End Get
            Set(ByVal Value As Boolean)
                _isMagPermanent = Value
            End Set
        End Property

        Public Property [isMagActive]() As Boolean
            Get
                Return _isMagActive
            End Get
            Set(ByVal Value As Boolean)
                _isMagActive = Value
            End Set
        End Property

        Public Property [isSysWet]() As Boolean
            Get
                Return _isSysWet
            End Get
            Set(ByVal Value As Boolean)
                _isSysWet = Value
            End Set
        End Property

        Public Property [isSysDry]() As Boolean
            Get
                Return _isSysDry
            End Get
            Set(ByVal Value As Boolean)
                _isSysDry = Value
            End Set
        End Property

        Public Property [isSysDye]() As Boolean
            Get
                Return _isSysDye
            End Get
            Set(ByVal Value As Boolean)
                _isSysDye = Value
            End Set
        End Property

        Public Property [isSysFluorescent]() As Boolean
            Get
                Return _isSysFluorescent
            End Get
            Set(ByVal Value As Boolean)
                _isSysFluorescent = Value
            End Set
        End Property

        Public Property [isSysContrastBW]() As Boolean
            Get
                Return _isSysContrastBW
            End Get
            Set(ByVal Value As Boolean)
                _isSysContrastBW = Value
            End Set
        End Property

        Public Property [isSysDyePenetrant]() As Boolean
            Get
                Return _isSysDyePenetrant
            End Get
            Set(ByVal Value As Boolean)
                _isSysDyePenetrant = Value
            End Set
        End Property

        Public Property [MGWSWLWLLcaptionSCode]() As String
            Get
                Return _MGWSWLWLLcaptionSCode
            End Get
            Set(ByVal Value As String)
                _MGWSWLWLLcaptionSCode = Value
            End Set
        End Property

        Public Property [MGWSWLWLLvalue]() As String
            Get
                Return _MGWSWLWLLvalue
            End Get
            Set(ByVal Value As String)
                _MGWSWLWLLvalue = Value
            End Set
        End Property

        Public Property [reportDate]() As DateTime
            Get
                Return _reportDate
            End Get
            Set(ByVal Value As DateTime)
                _reportDate = Value
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
