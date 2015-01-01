Option Explicit On
Option Strict On

Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Text
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Collections
Imports System.ComponentModel
Imports System.Math
Imports Microsoft.VisualBasic

Imports Raven.Common

Namespace Raven.Web
    Public NotInheritable Class App
        Public Const App_TechnicalInspection As String = "TIMS"
    End Class

    Public NotInheritable Class commonFunction
        Public Const Key_CacheLoggedOnUser As String = "CacheLoggedOnUser"
        Public Const Key_CacheLoggedOnProfileID As String = "CacheLoggedOnProfileID"
        Public Const Key_CacheLoggedOnProfileName As String = "CacheLoggedOnProfileName"
        Public Const Key_CacheLoggedOnSiteID As String = "CacheLoggedOnSiteID"
        Public Const Key_CacheLoggedOnSiteName As String = "CacheLoggedOnSiteName"
        Public Const Key_CacheErrorMessage As String = "ErrorMessage"
        Public Const Key_CacheUser As String = "CacheLoggedOnUser"

        Public Const rowPositionFirst As String = "First"
        Public Const rowPositionPrevious As String = "Previous"
        Public Const rowPositionNext As String = "Next"
        Public Const rowPositionLast As String = "Last"

        Public Const rowOpenCommand As String = "Open"
        Public Const rowSaveCommand As String = "Save"
        Public Const rowDeleteCommand As String = "Delete"
        Public Const rowVoidCommand As String = "Void"
        Public Const rowNewCommand As String = "New"
        Public Const rowRefreshCommand As String = "Refresh"
        Public Const rowPrintCommand As String = "Print"

        Public Const FORMAT_DATE As String = "dd-MMM-yyyy"
        Public Const FORMAT_DATE_CAL As String = "dd-MM-yyyy"
        Public Const FORMAT_CURRENCY As String = "#,##0.00"

        Public Const MSG_ACCESS_DENIED As String = "Access Denied<br/>You might not have permission to view this directory or page.<br/>If you believe you should be able to view this directory or page, please contact your System Administrator."
        Public Const MSG_CONFIRM_DELETE As String = "The record will be deleted. Are you sure?"
        Public Const MSG_CONFIRM_VOID As String = "The record will be void. Are you sure?"
        Public Const MSG_CONFIRM_SAVE As String = "The record will be saved. Are you sure?"
        Public Const MSG_CONFIRM_NEW As String = "The record have not been saved. Unsaved record will be lost. Continue?"
        Public Const MSG_CONFIRM_APPROVE As String = "The record will be approved. Are you sure?"

        Public Const EqualSL As String = "[equ]"
        Public Const QuoteSL As String = "[quo]"

        Public Shared Function CurrentRowPos(ByVal RowPosition As Integer, ByVal MaxRow As Integer, ByVal CommandName As String) As Integer
            Dim nRowPosition As Integer

            Select Case CommandName
                Case rowPositionFirst
                    If MaxRow > 0 Then
                        nRowPosition = 1
                    Else
                        nRowPosition = -1
                    End If
                Case rowPositionPrevious
                    If MaxRow > 0 Then
                        If RowPosition = 1 Then
                            ' move to the last row.
                            nRowPosition = MaxRow
                        Else
                            nRowPosition = RowPosition - 1
                        End If
                    Else
                        nRowPosition = -1
                    End If
                Case rowPositionNext
                    If MaxRow > 0 Then
                        If RowPosition = MaxRow Then
                            ' move to the first row.
                            nRowPosition = 1
                        Else
                            nRowPosition = RowPosition + 1
                        End If
                    Else
                        nRowPosition = -1
                    End If
                Case rowPositionLast
                    If MaxRow > 0 Then
                        nRowPosition = MaxRow
                    Else
                        nRowPosition = -1
                    End If
            End Select

            Return nRowPosition
        End Function 'Public Function CurrentRowPos

        Public Shared Sub SetUpdateCommandCausesValidation(ByVal grd As DataGrid, ByVal item As DataGridItem, ByVal fEnable As Boolean)
            Dim ctrl As Control
            Dim btn As Control
            If item.HasControls Then
                For Each ctrl In item.Controls
                    If ctrl.HasControls Then
                        For Each btn In ctrl.Controls
                            If btn.GetType.Name.Equals("DataGridLinkButton") Then
                                Dim lnkBtn As LinkButton = CType(btn, LinkButton)
                                If lnkBtn.Text.Equals(GetUpdateColumnText(grd)) Then
                                    lnkBtn.CausesValidation = fEnable
                                End If
                            End If
                        Next
                    End If
                Next
            End If
        End Sub

        Private Shared Function GetUpdateColumnText(ByVal grd As DataGrid) As String
            Dim col As DataGridColumn
            Dim colEdit As EditCommandColumn
            For Each col In grd.Columns
                If col.GetType.Name.Equals("EditCommandColumn") Then
                    colEdit = CType(col, EditCommandColumn)
                    Return colEdit.UpdateText
                End If
            Next
        End Function

#Region " Formating "
        Public Shared Sub TimeFormat(ByVal TextBox As eWorld.UI.MaskedTextBox)
            Dim formatJam As String
            formatJam = Common.Methods.GetSettingParameter("format_jam").Trim
            TextBox.Mask = formatJam
        End Sub

        Public Shared Function ConvertDate(ByVal [Date] As String, Optional ByVal [format] As String = "dd-MM-yyyy") As Date
            Try
                Select Case [format]
                    Case "dd-MM-yyyy"
                        Return DateSerial(Convert.ToInt32([Date].Substring(6, 4)), Convert.ToInt32([Date].Substring(3, 2)), Convert.ToInt32([Date].Substring(0, 2)))
                    Case "yyyyMMdd"
                        Return DateSerial(Convert.ToInt32([Date].Substring(0, 4)), Convert.ToInt32([Date].Substring(4, 2)), Convert.ToInt32([Date].Substring(6, 2)))
                End Select
            Catch
                Return DateTime.Now
            End Try
        End Function

        Public Shared Function DateToStringFormat(ByVal [date] As Date) As String
            Return Format([date], "yyyyMMdd")
        End Function

        Public Shared Function ValidateDateFormat(ByVal [Date] As String) As String
            Try
                Dim tanggal As Integer
                Dim bulan As Integer
                Dim tahun As Integer
                Dim Tgl As Date
                Dim err As String = "Maaf, Periksa kembali format tanggal anda (dd-MM-yyyy)"
                tanggal = Convert.ToInt32([Date].Substring(0, 2))
                bulan = Convert.ToInt32([Date].Substring(3, 2))
                tahun = Convert.ToInt32([Date].Substring(6, 4))
                If bulan > 12 Then
                    ExceptionManager.Publish(New Exception(err))
                End If

                Select Case bulan
                    Case 1, 3, 5, 7, 8, 10, 12
                        If tanggal > 31 Then
                            ExceptionManager.Publish(New Exception(err))
                        End If
                    Case 4, 6, 9, 11
                        If tanggal > 30 Then
                            ExceptionManager.Publish(New Exception(err))
                        End If
                    Case 2
                        If tahun Mod 4 = 0 Then
                            If tanggal > 29 Then
                                ExceptionManager.Publish(New Exception(err))
                            End If
                        Else
                            If tanggal > 28 Then
                                ExceptionManager.Publish(New Exception(err))
                            End If
                        End If
                End Select

                Tgl = DateSerial(Convert.ToInt32([Date].Substring(6, 4)), Convert.ToInt32([Date].Substring(3, 2)), Convert.ToInt32([Date].Substring(0, 2)))
                Return Format(Tgl, "dd-MM-yyyy")

            Catch e As Exception
                'Return DateTime.Now
                Throw New Exception("Maaf, Periksa kembali format tanggal anda (dd-MM-yyyy)")
            End Try
        End Function

        Public Shared Sub MRNFormat(ByVal TextBox As eWorld.UI.MaskedTextBox)
            Dim formatNoRM As String
            formatNoRM = Common.Methods.GetSettingParameter("format_norm").Trim

            TextBox.Mask = formatNoRM
        End Sub
#End Region

#Region " Set DropDownList "
        Public Shared Sub SetDDL_Table(ByVal ddl As DropDownList, ByVal ddlType As String, ByVal keyField As String, _
                Optional ByVal isIncludeBlank As Boolean = False, Optional ByVal strBlankText As String = "- Choose Record -", Optional ByVal strBlankValue As String = "")
            Dim tblToApply As DataTable

            Select Case ddlType
                Case "Site"
                    Dim oTbl As New Common.BussinessRules.Site
                    tblToApply = oTbl.SelectAllActive()
                Case "UserProfile"
                    Dim oTbl As New Common.BussinessRules.UserProfile
                    tblToApply = oTbl.SelectProfileByUserID(keyField.Trim)
                Case "UserSite"
                    Dim oTbl As New Common.BussinessRules.UserSite
                    tblToApply = oTbl.SelectSiteByUserID(keyField.Trim)
                Case "MonthInYear"
                    Dim tblMonth As New DataTable
                    With tblMonth
                        .Columns.Add("MonthCode", System.Type.GetType("System.String"))
                        .Columns.Add("MonthName", System.Type.GetType("System.String"))
                    End With
                    For i As Integer = 1 To 12
                        Dim newRow As DataRow = tblMonth.NewRow
                        newRow("MonthCode") = CStr(i)
                        newRow("MonthName") = MonthName(i)
                        tblMonth.Rows.Add(newRow)                        
                    Next
                    tblToApply = tblMonth
                Case "CaptionTemplate"
                    Dim oTbl As New Common.BussinessRules.CaptionTemplateHd
                    tblToApply = oTbl.SelectAll()
                Case Else
                    Dim oTbl As New Common.BussinessRules.CommonCode
                    oTbl.GroupCode = keyField.Trim
                    tblToApply = oTbl.SelectByGroupCode()
            End Select

            With ddl
                Dim rgRows As DataRow() = tblToApply.Select()

                If rgRows.Length > 0 Then
                    Dim i As Integer = 1
                    Dim _strBlankText As String = String.Empty
                    Dim _strBlankValue As String = String.Empty
                    Dim _strText As String = String.Empty
                    Dim _strValue As String = String.Empty

                    .Items.Clear()

                    If isIncludeBlank Then
                        If Len(strBlankText.Trim) > 0 Then
                            _strBlankText = strBlankText.Trim
                        End If

                        If Len(strBlankValue.Trim) > 0 Then
                            _strBlankValue = strBlankValue.Trim
                        End If

                        .Items.Add(New ListItem(_strBlankText.Trim, _strBlankValue.Trim))
                    End If

                    Do While i <= rgRows.Length
                        Select Case ddlType
                            Case "Site"
                                _strText = Common.ProcessNull.GetString(rgRows(i - 1)("SiteName"))
                                _strValue = Common.ProcessNull.GetString(rgRows(i - 1)("SiteID"))
                            Case "UserProfile"
                                _strText = Common.ProcessNull.GetString(rgRows(i - 1)("ProfileName"))
                                _strValue = Common.ProcessNull.GetString(rgRows(i - 1)("ProfileID"))
                            Case "UserSite"
                                _strText = Common.ProcessNull.GetString(rgRows(i - 1)("SiteName"))
                                _strValue = Common.ProcessNull.GetString(rgRows(i - 1)("SiteID"))
                            Case "MonthInYear"
                                _strText = Common.ProcessNull.GetString(rgRows(i - 1)("MonthName"))
                                _strValue = Common.ProcessNull.GetString(rgRows(i - 1)("MonthCode"))
                            Case "CaptionTemplate"
                                _strText = Common.ProcessNull.GetString(rgRows(i - 1)("CaptionTemplateName"))
                                _strValue = Common.ProcessNull.GetString(rgRows(i - 1)("CaptionTemplateHdID"))
                            Case Else
                                _strText = Common.ProcessNull.GetString(rgRows(i - 1)("Caption"))
                                _strValue = Common.ProcessNull.GetString(rgRows(i - 1)("Value"))
                        End Select
                        .Items.Add(New ListItem(_strText.Trim, _strValue.Trim))
                        i += 1
                    Loop
                Else
                    .Items.Add(New ListItem(strBlankText.Trim, strBlankValue.Trim))
                End If

            End With
        End Sub

        Public Shared Sub SetDDL_YearPeriod(ByVal ddl As DropDownList, ByVal startYear As Integer, ByVal endYear As Integer)
            Dim tblToApply As DataTable

            Dim tblYear As New DataTable
            With tblYear
                .Columns.Add("YearCode", System.Type.GetType("System.String"))
                .Columns.Add("YearName", System.Type.GetType("System.String"))
            End With
            For i As Integer = startYear To endYear
                Dim newRow As DataRow = tblYear.NewRow
                newRow("YearCode") = CStr(i)
                newRow("YearName") = CStr(i)
                tblYear.Rows.Add(newRow)                
            Next
            tblToApply = tblYear

            With ddl
                Dim rgRows As DataRow() = tblToApply.Select()

                If rgRows.Length > 0 Then
                    Dim i As Integer = 1
                    Dim _strText As String = String.Empty
                    Dim _strValue As String = String.Empty

                    .Items.Clear()

                    Do While i <= rgRows.Length
                        _strText = Common.ProcessNull.GetString(rgRows(i - 1)("YearName"))
                        _strValue = Common.ProcessNull.GetString(rgRows(i - 1)("YearCode"))
                        .Items.Add(New ListItem(_strText.Trim, _strValue.Trim))
                        i += 1
                    Loop
                Else
                    .Items.Add(New ListItem("", ""))
                End If

            End With
        End Sub
#End Region

#Region " Set RadioButtonList "
        Public Shared Sub SetRBTNL_Table(ByVal rbtnl As RadioButtonList, ByVal rbtnlType As String, ByVal keyField As String, _
                Optional ByVal isIncludeBlank As Boolean = False, Optional ByVal strBlankText As String = "- Choose Record -", Optional ByVal strBlankValue As String = "")
            Dim tblToApply As DataTable

            Select Case rbtnlType
                Case Else
                    Dim oTbl As New Common.BussinessRules.CommonCode
                    oTbl.GroupCode = keyField.Trim
                    tblToApply = oTbl.SelectByGroupCode()
            End Select

            With rbtnl
                Dim rgRows As DataRow() = tblToApply.Select()

                If rgRows.Length > 0 Then
                    Dim i As Integer = 1
                    Dim _strBlankText As String = String.Empty
                    Dim _strBlankValue As String = String.Empty
                    Dim _strText As String = String.Empty
                    Dim _strValue As String = String.Empty

                    .Items.Clear()

                    If isIncludeBlank Then
                        If Len(strBlankText.Trim) > 0 Then
                            _strBlankText = strBlankText.Trim
                        End If

                        If Len(strBlankValue.Trim) > 0 Then
                            _strBlankValue = strBlankValue.Trim
                        End If

                        .Items.Add(New ListItem(_strBlankText.Trim, _strBlankValue.Trim))
                    End If

                    Do While i <= rgRows.Length
                        Select Case rbtnlType
                            Case Else
                                _strText = Common.ProcessNull.GetString(rgRows(i - 1)("Caption"))
                                _strValue = Common.ProcessNull.GetString(rgRows(i - 1)("Value"))
                        End Select
                        .Items.Add(New ListItem(_strText.Trim, _strValue.Trim))
                        i += 1
                    Loop
                Else
                    .Items.Add(New ListItem(strBlankText.Trim, strBlankValue.Trim))
                End If

            End With
        End Sub
#End Region

        Public Shared Function InsertScriptHitungUmur(ByVal calTglLahir As Raven.Web.Calendar, ByVal txtUmurTahun As TextBox, ByVal txtUmurBulan As TextBox, ByVal txtUmurHari As TextBox) As Text.StringBuilder
            Dim scriptUpdateUmur As New Text.StringBuilder
            Dim scriptUpdateTgl As New Text.StringBuilder

            With scriptUpdateUmur
                .Append("<script type=""text/javascript"">" + Environment.NewLine)

                .Append("function calAge(cal) {" + Environment.NewLine)
                .Append("UpdateUmur(cal.date.getFullYear(),cal.date.getMonth()+1,cal.date.getDate());" + Environment.NewLine)
                .Append("}" + Environment.NewLine)

                .Append("</script>" + Environment.NewLine)

                .Append("<SCRIPT LANGUAGE=vbscript>" + Environment.NewLine)
                .Append("<!--" + Environment.NewLine)

                .Append("function UpdateUmur(y,m,d)" + Environment.NewLine)
                .Append("dim dtToday, dtBirthDay" + Environment.NewLine)
                .Append("dim intAgeInMonths, intAgeInYears, intAgeInDays" + Environment.NewLine)
                .Append("dtToday = Now" + Environment.NewLine)
                .Append("dtBirthDay = DateSerial(y,m,d)" + Environment.NewLine)
                .Append("intAgeInYears = Year(dtToday)-year(dtBirthDay)" + Environment.NewLine)
                .Append("intAgeInMonths = Month(dtToday)-month(dtBirthDay)" + Environment.NewLine)
                .Append("intAgeInDays = day(dtToday)-day(dtBirthDay)" + Environment.NewLine)

                .Append("if (intAgeInDays<0) then" + Environment.NewLine)
                .Append("intAgeInDays = intAgeInDays+day(dtToday-day(dtToday))" + Environment.NewLine)
                .Append("intAgeInMonths = intAgeInMonths-1" + Environment.NewLine)
                .Append("end if" + Environment.NewLine)

                .Append("if (intAgeInMonths<0) then" + Environment.NewLine)
                .Append("intAgeInMonths = intAgeInMonths+12" + Environment.NewLine)
                .Append("intAgeInYears = intAgeInYears-1" + Environment.NewLine)
                .Append("end if" + Environment.NewLine)

                .Append("document.getElementById(" + """" + txtUmurTahun.ClientID + """" + ").value=cstr(intAgeInYears)" + Environment.NewLine)
                .Append("document.getElementById(" + """" + txtUmurBulan.ClientID + """" + ").value=cstr(intAgeInMonths)" + Environment.NewLine)
                .Append("document.getElementById(" + """" + txtUmurHari.ClientID + """" + ").value=cstr(intAgeInDays)" + Environment.NewLine)

                .Append("end function" + Environment.NewLine)

                .Append("sub UpdateUmur2" + Environment.NewLine)
                .Append("On Error Resume Next" + Environment.NewLine)
                .Append("Dim intAgeInMonths, intAgeInYears, intAgeInDays" + Environment.NewLine)

                .Append("if IsNumeric(document.getElementById(" + """" + txtUmurTahun.ClientID + """" + ").value) then" + Environment.NewLine)
                .Append("intAgeInYears = cint(document.getElementById(" + """" + txtUmurTahun.ClientID + """" + ").value)" + Environment.NewLine)
                .Append("end if" + Environment.NewLine)

                .Append("if IsNumeric(document.getElementById(" + """" + txtUmurBulan.ClientID + """" + ").value) then" + Environment.NewLine)
                .Append("intAgeInMonths = CInt(document.getElementById(" + """" + txtUmurBulan.ClientID + """" + ").value)" + Environment.NewLine)
                .Append("end if" + Environment.NewLine)

                .Append("if IsNumeric(document.getElementById(" + """" + txtUmurHari.ClientID + """" + ").value) then" + Environment.NewLine)
                .Append("intAgeInDays = cint(document.getElementById(" + """" + txtUmurHari.ClientID + """" + ").value)" + Environment.NewLine)
                .Append("end if" + Environment.NewLine)

                .Append("if intAgeInDays>31 then " + Environment.NewLine)
                .Append("intAgeInDays=1" + Environment.NewLine)
                .Append("document.getElementById(" + """" + txtUmurHari.ClientID + """" + ").value=cstr(intAgeInDays)" + Environment.NewLine)
                .Append("End If " + Environment.NewLine)

                .Append("if intAgeInMonths>11 then " + Environment.NewLine)
                .Append("intAgeInMonths=1" + Environment.NewLine)
                .Append("document.getElementById(" + """" + txtUmurBulan.ClientID + """" + ").value=cstr(intAgeInMonths)" + Environment.NewLine)
                .Append("End If " + Environment.NewLine)

                .Append("if intAgeInYears>120 then " + Environment.NewLine)
                .Append("intAgeInYears=17" + Environment.NewLine)
                .Append("document.getElementById(" + """" + txtUmurTahun.ClientID + """" + ").value=cstr(intAgeInYears)" + Environment.NewLine)
                .Append("End If " + Environment.NewLine)

                .Append("If intAgeInYears >= 0 And intAgeInYears <= 120 Then" + Environment.NewLine)
                .Append("Dim dtTglLahir" + Environment.NewLine)
                .Append("Dim iYear, iMonth, iDay " + Environment.NewLine)
                .Append("dim selDay, selMonth, selYear" + Environment.NewLine)
                .Append("dim fDate" + Environment.NewLine)

                .Append("iYear = Year(Now) - intAgeInYears" + Environment.NewLine)
                .Append("iMonth = month(dateadd(" + """" + "m" + """" + ", -intAgeInMonths, now)) 'iMonth = Month(Month(Now)-intAgeInMonths)" + Environment.NewLine)
                .Append("iDay = Day(Now) - intAgeInDays" + Environment.NewLine)

                .Append("if len(iday)=1  then" + Environment.NewLine)
                .Append("fdate=" + """" + "0" + """" + "+cstr(iday)+" + """" + "-" + """" + Environment.NewLine)
                .Append("else" + Environment.NewLine)
                .Append("fdate=cstr(iday)+" + """" + "-" + """" + Environment.NewLine)
                .Append("end if" + Environment.NewLine)

                .Append("if len(iMonth)=1 then" + Environment.NewLine)
                .Append("fdate=fdate+" + """" + "0" + """" + "+cstr(iMonth)+" + """" + "-" + """" + Environment.NewLine)
                .Append("else " + Environment.NewLine)
                .Append("fdate=fdate+cstr(iMonth)+" + """" + "-" + """" + Environment.NewLine)
                .Append("end if" + Environment.NewLine)

                .Append("fdate=fdate+cstr(iYear)" + Environment.NewLine)

                .Append("document.getElementById(" + """" + calTglLahir.FindControl("txtPopUpCal").ClientID + """" + ").value=fdate" + Environment.NewLine)

                .Append("End If" + Environment.NewLine)
                .Append("end sub" + Environment.NewLine)


                .Append("function calChange()" + Environment.NewLine)
                .Append("dim dtToday, dtBirthDay, strDate" + Environment.NewLine)
                .Append("dim intAgeInMonths, intAgeInYears, intAgeInDays" + Environment.NewLine)
                .Append("strDate=document.getElementById(" + """" + calTglLahir.FindControl("txtPopUpCal").ClientID + """" + ").value" + Environment.NewLine)
                .Append("dtToday = Now" + Environment.NewLine)
                .Append("dtBirthDay = DateSerial(Right(strDate,4),right(left(strDate,5),2),Left(strDate,2))" + Environment.NewLine)
                .Append("intAgeInYears = Year(dtToday)-year(dtBirthDay)" + Environment.NewLine)
                .Append("intAgeInMonths = Month(dtToday)-month(dtBirthDay)" + Environment.NewLine)
                .Append("intAgeInDays = day(dtToday)-day(dtBirthDay)" + Environment.NewLine)

                .Append("if (intAgeInDays<0) then" + Environment.NewLine)
                .Append("intAgeInDays = intAgeInDays+day(dtToday-day(dtToday))" + Environment.NewLine)
                .Append("intAgeInMonths = intAgeInMonths-1" + Environment.NewLine)
                .Append("end if" + Environment.NewLine)

                .Append("if (intAgeInMonths<0) then" + Environment.NewLine)
                .Append("intAgeInMonths = intAgeInMonths+12" + Environment.NewLine)
                .Append("intAgeInYears = intAgeInYears-1" + Environment.NewLine)
                .Append("end if" + Environment.NewLine)

                .Append("document.getElementById(" + """" + txtUmurTahun.ClientID + """" + ").value=cstr(intAgeInYears)" + Environment.NewLine)
                .Append("document.getElementById(" + """" + txtUmurBulan.ClientID + """" + ").value=cstr(intAgeInMonths)" + Environment.NewLine)
                .Append("document.getElementById(" + """" + txtUmurHari.ClientID + """" + ").value=cstr(intAgeInDays)" + Environment.NewLine)

                .Append("end function" + Environment.NewLine)


                .Append("//-->" + Environment.NewLine)
                .Append("</SCRIPT>" + Environment.NewLine)
            End With

            Return scriptUpdateUmur
        End Function

        Public Shared Function SelectListItem(ByVal list As DropDownList, ByVal value As String) As Boolean
            Try
                list.SelectedItem.Selected = False
                list.Items.FindByValue(value).Selected = True
                Return True
            Catch
                Return False
            End Try
        End Function

        Public Shared Sub ShowPanel(ByRef panel As Panel, ByVal visible As Boolean)
            Dim validator As IValidator
            Dim ctrl As Control

            For Each ctrl In panel.Controls
                If TypeOf ctrl Is IValidator Then
                    validator = CType(ctrl, IValidator)
                    ctrl.Visible = visible
                    If Not visible Then
                        validator.Validate()
                    End If
                End If
            Next
            panel.Visible = visible
        End Sub

        Public Shared Sub Focus(ByVal Aspx As Page, ByVal ControlID As String)
            Aspx.RegisterStartupScript("__Focus", "<script language='javascript'>document.getElementById('" + ControlID + "').focus();document.getElementById('" + ControlID + "').select();</script>")
        End Sub

        Public Shared Sub MsgBox(ByVal AspxPage As Page, ByVal Msg As String)
            AspxPage.RegisterStartupScript("__MsgBox", "<script language='javascript'>alert('" + Msg.Replace("'", "").ToString + "');</script>")
        End Sub

#Region " Login "
        Public Shared Function tblUserLogin(ByVal UserName As String) As DataTable
            Dim oUser As New Common.BussinessRules.User
            Dim dt As New DataTable
            With oUser
                .UserName = UserName.Trim
                dt = .SelectByUserName()
                .Dispose()
            End With
            oUser = Nothing
            Return dt
        End Function

        Public Shared Function tblProfileMenu(ByVal ProfileID As String, ByVal AppID As String) As DataTable
            Dim oMenu As New Common.BussinessRules.Menu
            Dim dt As New DataTable
            dt = oMenu.SelectMenuAuthorizationByProfileID(ProfileID, AppID)
            oMenu.Dispose()
            oMenu = Nothing
            Return dt
        End Function

        Public Shared Function tblProfile(ByVal ProfileID As String) As DataTable
            Dim oProfile As New Common.BussinessRules.Profile
            Dim dt As New DataTable
            oProfile.ProfileID = ProfileID.Trim
            dt = oProfile.SelectOne
            oProfile.Dispose()
            oProfile = Nothing
            Return dt
        End Function

        Public Shared Function tblSite(ByVal SiteID As String) As DataTable
            Dim oSite As New Common.BussinessRules.Site
            Dim dt As New DataTable
            oSite.SiteID = SiteID.Trim
            dt = oSite.SelectOne
            oSite.Dispose()
            oSite = Nothing
            Return dt
        End Function
#End Region

#Region " Menu "
        Public Shared Function CreateMenu(ByVal MenuAuthorization As DataTable) As String
            CreateMenu = String.Empty

            Dim rows As DataRow() = MenuAuthorization.Select("ParentMenuID IS NOT Null AND HeaderDetail = 'H'", "counter")
            Dim row As DataRow
            Dim str_href As String
            Dim str_line As String
            Dim str_ImageUrl As String

            CreateMenu = CreateMenu + "<span class=""preload1""></span> <span class=""preload2""></span>"
            CreateMenu = CreateMenu + "<div style=""width:100%;border-bottom:#394376 solid 1px;"" > <ul id=""nav"">"
            For Each row In rows
                str_href = IIf((CType(row("Url"), String) = "#" Or CType(row("Url"), String) = ""), "", ("href=""" + PageBase.UrlBase + "/secure/" + CType(row("Url"), String) + """")).ToString.Trim
                str_line = IIf(CType(row("Line"), Boolean), "style=""border-bottom-style:dotted;border-bottom-color:White;border-bottom-width:1px""", "").ToString.Trim
                str_ImageUrl = IIf((CType(row("ImageUrl"), String) = "#" Or CType(row("ImageUrl"), String) = ""), "", ("<img src=""" + PageBase.UrlBase + "/" + CType(row("ImageUrl"), String) + """ alt="" border=""0"" align='absmiddle'/>&nbsp;")).ToString.Trim

                If CType(row("HeaderDetail"), String).Trim = "H" Then
                    CreateMenu = CreateMenu + "<li " + str_line + " class=""top""><a " + str_href + " class=""top_link"" ><span class=""down"">" + str_ImageUrl + CType(row("Caption"), String) + "</span></a>"
                    CreateMenu = CreateMenu + CreateSubMenu(True, MenuAuthorization, CType(row("MenuID"), String)) ', False
                    CreateMenu = CreateMenu + "</li>"
                Else
                    CreateMenu = CreateMenu + "<li " + str_line + " class=""top""><a " + str_href + " class=""top_link"" ><span>" + str_ImageUrl + CType(row("Caption"), String) + "</span></a></li>"
                End If

            Next row
            CreateMenu = CreateMenu + "</ul></div>"
        End Function

        Public Shared Function CreateSubMenu(ByVal isLevel1 As Boolean, ByVal MenuAuthorization As DataTable, ByVal MenuID As String) As String

            Dim rows As DataRow() = MenuAuthorization.Select("ParentMenuID = '" + MenuID + "'", "counter")

            Dim row As DataRow

            CreateSubMenu = ""

            If isLevel1 Then
                CreateSubMenu = CreateSubMenu + "<ul class=""sub"">"
            Else
                CreateSubMenu = CreateSubMenu + "<ul>"
            End If

            Dim str_href As String
            Dim str_line As String
            Dim str_ImageUrl As String

            For Each row In rows
                str_href = IIf((CType(row("Url"), String) = "#" Or CType(row("Url"), String) = ""), "", ("href=""" + PageBase.UrlBase + "/secure/" + CType(row("Url"), String) + """")).ToString.Trim
                str_line = IIf(CType(row("Line"), Boolean), "style=""border-bottom-style:dotted;border-bottom-color:White;border-bottom-width:1px""", "").ToString.Trim
                str_ImageUrl = IIf((CType(row("ImageUrl"), String) = "#" Or CType(row("ImageUrl"), String) = ""), "", ("<img src=""" + PageBase.UrlBase + "/" + CType(row("ImageUrl"), String) + """ alt="" border=""0"" align='absmiddle'/>&nbsp;")).ToString.Trim

                If CType(row("HeaderDetail"), String).Trim = "H" Then
                    CreateSubMenu = CreateSubMenu + "<li " + str_line + " > <a " + str_href + " class=""fly"" >" + str_ImageUrl + CType(row("Caption"), String) + "</a>"
                    CreateSubMenu = CreateSubMenu + CreateSubMenu(False, MenuAuthorization, CType(row("MenuID"), String).Trim) ', isReportMenu
                    CreateSubMenu = CreateSubMenu + "</li>"
                Else
                    CreateSubMenu = CreateSubMenu + "<li " + str_line + " > <a " + str_href + ">" + str_ImageUrl + CType(row("Caption"), String) + "</a></li>"
                End If

            Next row
            CreateSubMenu = CreateSubMenu + "</ul>"
        End Function
#End Region

        Public Shared Function JSOpenSearchListWind(ByVal SearchID As String, ByVal CtrlID As String, Optional ByVal FilterValue As String = "", Optional ByVal _width As String = "800", Optional ByVal _height As String = "500", Optional ByVal _resizeble As String = "1", Optional ByVal _scrollable As String = "1") As String
            Dim strJS As String = ""
            strJS = "javascript:openWindowForSL('" + PageBase.UrlBase + "/SearchList.aspx?sID=" + SearchID.Trim + "&ctrlID=" + CtrlID + "&filterValue=" + FilterValue.Trim + "','" + CtrlID + "','SL','" + _width + "','" + _height + "','" + _resizeble + "','" + _scrollable + "');"
            Return strJS
        End Function

    End Class

End Namespace