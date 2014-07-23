Option Strict On
Option Explicit On

Imports System
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Collections
Imports System.ComponentModel
Imports System.Text
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient

Imports Telerik.Web.UI

Imports Raven.Web
Imports Raven.Common
Imports Raven.SystemFramework

Namespace Raven
    Public MustInherit Class ProjectBanner
        Inherits ModuleBase

        Private _ProjectID As String        

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        End Sub

        Public Sub GetProjectInformation()
            lblProjectID.Text = _ProjectID.Trim
            If Len(lblProjectID.Text) > 0 Then
                Dim oProject As New Common.BussinessRules.ProjectHd
                With oProject
                    .projectID = lblProjectID.Text.Trim
                    If .SelectOne.Rows.Count > 0 Then
                        lblCustomerID.Text = .customerID.Trim
                        lblCustomerName.Text = GetCustomerName(lblCustomerID.Text.Trim)
                        lblLocation.Text = .workLocation.Trim
                        lblWorkOrderNo.Text = .workOrderNo.Trim
                        lblWorkOrderDate.Text = Format(.workOrderDate, commonFunction.FORMAT_DATE)
                        lblProjectName.Text = .projectName.Trim
                        lblProjectCode.Text = .projectCode.Trim
                        lblJobDescription.Text = .jobDescription.Trim
                        lblPeriod.Text = Format(.startDate, commonFunction.FORMAT_DATE) + " to " + Format(.endDate, commonFunction.FORMAT_DATE)                        
                    Else
                        lblCustomerID.Text = String.Empty
                        lblCustomerName.Text = "[Customer Name]"
                        lblLocation.Text = "[Project Location]"
                        lblWorkOrderNo.Text = "[Work Order No.]"
                        lblWorkOrderDate.Text = "[dd-MMM-yyyy]"
                        lblProjectName.Text = "[Project Name]"
                        lblProjectCode.Text = "[Project Code]"
                        lblJobDescription.Text = "[Job Description]"
                        lblPeriod.Text = "[Period]"
                    End If
                End With
                oProject.Dispose()
                oProject = Nothing
            End If
        End Sub

        Private Function GetCustomerName(ByVal CustomerID As String) As String
            Dim strCustomerName As String = String.Empty
            Dim oCust As New Common.BussinessRules.Customer
            With oCust
                .CustomerID = CustomerID.Trim
                If .SelectOne.Rows.Count > 0 Then
                    strCustomerName = .CustomerName.Trim
                End If
            End With
            oCust.Dispose()
            oCust = Nothing
            Return strCustomerName.Trim
        End Function

        Public Property [ProjectID]() As String
            Get
                Return _ProjectID
            End Get
            Set(ByVal Value As String)
                _ProjectID = Value
            End Set
        End Property
    End Class
End Namespace


