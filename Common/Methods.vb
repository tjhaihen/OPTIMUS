Imports System.Web.UI.WebControls
Imports System.Web.UI

Namespace Raven.Common
    Public NotInheritable Class Methods
#Region "Methods and Function"
        Public Shared Function GetSettingParameter(ByVal code As String) As String
            Dim result As String
            Dim oSysPar As New Common.SystemParameter
            result = oSysPar.GetValue(code).Trim
            Return result
        End Function

        Public Shared Function GetCommonCode(ByVal code As String, ByVal groupCode As String) As String
            Dim result As String = String.Empty
            Dim oCommon As New Common.BussinessRules.CommonCode
            oCommon.GroupCode = groupCode.Trim
            oCommon.Code = code.Trim
            If oCommon.SelectOne.Rows.Count > 0 Then
                result = oCommon.Value.Trim
            End If
            oCommon.Dispose()
            oCommon = Nothing
            Return result
        End Function

        Public Shared Function GetUserFullName(ByVal UserID As String) As String
            Dim result As String = String.Empty
            Dim oUser As New Common.BussinessRules.User
            oUser.UserID = UserID.Trim
            If oUser.SelectOne.Rows.Count > 0 Then
                Dim oPerson As New Common.BussinessRules.Person
                oPerson.PersonID = oUser.PersonID.Trim
                If oPerson.SelectOne.Rows.Count > 0 Then
                    result = Replace((Trim((oPerson.FirstName.Trim + " " + oPerson.MiddleName.Trim + " " + oPerson.LastName.Trim))), "  ", " ")
                Else
                    result = String.Empty
                End If
            Else
                result = String.Empty
            End If
            oUser.Dispose()
            oUser = Nothing
            Return result
        End Function

        Public Shared Function SelectListItem(ByRef list As DropDownList, ByVal value As String) As Boolean
            Try
                list.SelectedItem.Selected = False
            Catch e As Exception
            End Try

            Try
                list.Items.FindByValue(ProcessNull.GetString(value)).Selected = True
                Return True
            Catch e As Exception
                System.Diagnostics.Debug.WriteLine(e.Message)
                Return False
            End Try
        End Function

        Public Shared Function FormatCurrency(ByVal value As Decimal) As String
            Return Format(value, "Standard")            
        End Function

        Public Shared Function FormatMRN() As String
            Return GetSettingParameter(Constants.Parameter.PARAM_FORMAT_MRN)
        End Function
#End Region

#Region "Common Page Function"
        Public Shared Sub MessageBox(ByVal AspxPage As Page, ByVal Msg As String)
            AspxPage.RegisterStartupScript("__MsgBox", "<script language='javascript'>alert('" + Msg.Replace("'", "").ToString + "');</script>")
        End Sub

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

#End Region
    End Class
End Namespace

