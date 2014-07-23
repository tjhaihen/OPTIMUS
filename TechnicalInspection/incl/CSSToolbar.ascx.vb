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

Imports Raven.Web
Imports Raven.Common
Imports Raven.SystemFramework

Namespace Raven
    Public Enum CSSToolbarItem
        tidNew = 0
        tidSave = 1
        tidDelete = 2
        tidApprove = 3
        tidVoid = 4
        tidPrint = 5
        tidPrevious = 6
        tidNext = 7
        tidRefresh = 8
        tidPropose = 9
    End Enum

    Public MustInherit Class CSSToolbar
        Inherits ModuleBase

        Private _IsValid As Boolean = False
        Private _ProfileID As String = String.Empty
        Private _MenuID As String = String.Empty

        Public Event CSSToolbarItemClick(ByVal sender As Object, ByVal e As CSSToolbarItem)

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load            
        End Sub

        Public Sub setAuthorizationToolbar()
            If Not MyBase.MB_CacheLoggedOnUser Is Nothing Then
                Dim oUP As New Common.BussinessRules.ProfileMenu
                oUP.ProfileID = _ProfileID.Trim
                oUP.MenuID = _MenuID.Trim

                Dim dv As New DataView(oUP.SelectAuthorizeCRUDMenuByProfileIDMenuID)
                If dv.Count = 1 Then
                    If CType(dv(0)("IsAllowCreate"), Boolean) Then
                        chkIsAllowAdd.Checked = True
                        VisibleButton(CSSToolbarItem.tidNew) = True
                    Else
                        chkIsAllowAdd.Checked = False
                        VisibleButton(CSSToolbarItem.tidNew) = False
                    End If

                    If CType(dv(0)("IsAllowUpdate"), Boolean) Then
                        chkIsAllowEdit.Checked = True

                        chkIsAllowApprove.Checked = True
                        VisibleButton(CSSToolbarItem.tidApprove) = True

                        chkIsAllowVoid.Checked = True
                        VisibleButton(CSSToolbarItem.tidVoid) = True
                    Else
                        chkIsAllowEdit.Checked = False

                        chkIsAllowApprove.Checked = False
                        VisibleButton(CSSToolbarItem.tidApprove) = False

                        chkIsAllowVoid.Checked = False
                        VisibleButton(CSSToolbarItem.tidVoid) = False
                    End If

                    If chkIsAllowAdd.Checked Or chkIsAllowEdit.Checked Then
                        VisibleButton(CSSToolbarItem.tidSave) = True
                    Else
                        VisibleButton(CSSToolbarItem.tidSave) = False
                    End If

                    If CType(dv(0)("IsAllowDelete"), Boolean) Then
                        chkIsAllowDelete.Checked = True
                        VisibleButton(CSSToolbarItem.tidDelete) = True
                    Else
                        chkIsAllowDelete.Checked = False
                        VisibleButton(CSSToolbarItem.tidDelete) = False
                    End If

                    If CType(dv(0)("IsAllowRead"), Boolean) Then
                        chkIsAllowPrint.Checked = True
                        VisibleButton(CSSToolbarItem.tidPrint) = True
                    Else
                        chkIsAllowPrint.Checked = False
                        VisibleButton(CSSToolbarItem.tidPrint) = False
                    End If
                Else
                    Throw New Exception(commonFunction.MSG_ACCESS_DENIED)
                End If
                dv = Nothing
            End If
        End Sub

        Public Property VisibleButton(ByVal item As CSSToolbarItem) As Boolean
            Get
                Select Case item
                    Case CSSToolbarItem.tidNew
                        Return TMPnlNew.Visible
                    Case CSSToolbarItem.tidSave
                        Return TMPnlSave.Visible
                    Case CSSToolbarItem.tidDelete
                        Return TMPnlDelete.Visible
                    Case CSSToolbarItem.tidApprove
                        Return TMPnlApprove.Visible
                    Case CSSToolbarItem.tidVoid
                        Return TMPnlVoid.Visible
                    Case CSSToolbarItem.tidPrevious
                        Return TMPnlPrevious.Visible
                    Case CSSToolbarItem.tidNext
                        Return TMPnlNext.Visible
                    Case CSSToolbarItem.tidPrint
                        Return TMPnlPrint.Visible
                    Case CSSToolbarItem.tidRefresh
                        Return TMPnlRefresh.Visible
                    Case CSSToolbarItem.tidPropose
                        Return TMpnlPropose.Visible
                End Select
            End Get
            Set(ByVal Value As Boolean)
                Select Case item
                    Case CSSToolbarItem.tidNew
                        TMPnlNew.Visible = Value
                    Case CSSToolbarItem.tidSave
                        TMPnlSave.Visible = Value
                    Case CSSToolbarItem.tidDelete
                        TMPnlDelete.Visible = Value
                        If chkIsAllowDelete.Checked Then
                            If Value Then
                                lbtnDelete.Attributes.Add("OnClick", "javascript: if (!confirm('" + commonFunction.MSG_CONFIRM_DELETE + "')) return false; return true")
                            Else
                                lbtnDelete.Attributes.Remove("OnClick")
                            End If
                        End If
                    Case CSSToolbarItem.tidApprove
                        TMPnlApprove.Visible = Value
                    Case CSSToolbarItem.tidVoid
                        TMPnlVoid.Visible = Value
                    Case CSSToolbarItem.tidPrevious
                        TMPnlPrevious.Visible = Value
                    Case CSSToolbarItem.tidNext
                        TMPnlNext.Visible = Value
                    Case CSSToolbarItem.tidPrint
                        TMPnlPrint.Visible = Value
                    Case CSSToolbarItem.tidRefresh
                        TMPnlRefresh.Visible = Value
                    Case CSSToolbarItem.tidPropose
                        TMpnlPropose.Visible = Value
                End Select
            End Set
        End Property
        Private Sub lbtn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbtnNew.Click, lbtnSave.Click, lbtnDelete.Click, _
                lbtnApprove.Click, lbtnVoid.Click, lbtnPrint.Click, _
                    lbtnPrevious.Click, lbtnNext.Click, lbtnRefresh.Click, _
                        lbtnPropose.Click
            Select Case CType(sender, LinkButton).ClientID
                Case lbtnNew.ClientID
                    RaiseEvent CSSToolbarItemClick(sender, CSSToolbarItem.tidNew)
                Case lbtnSave.ClientID
                    RaiseEvent CSSToolbarItemClick(sender, CSSToolbarItem.tidSave)
                Case lbtnDelete.ClientID
                    RaiseEvent CSSToolbarItemClick(sender, CSSToolbarItem.tidDelete)
                Case lbtnApprove.ClientID
                    RaiseEvent CSSToolbarItemClick(sender, CSSToolbarItem.tidApprove)
                Case lbtnVoid.ClientID
                    RaiseEvent CSSToolbarItemClick(sender, CSSToolbarItem.tidVoid)
                Case lbtnPrint.ClientID
                    RaiseEvent CSSToolbarItemClick(sender, CSSToolbarItem.tidPrint)
                Case lbtnPrevious.ClientID
                    RaiseEvent CSSToolbarItemClick(sender, CSSToolbarItem.tidPrevious)
                Case lbtnNext.ClientID
                    RaiseEvent CSSToolbarItemClick(sender, CSSToolbarItem.tidNext)
                Case lbtnRefresh.ClientID
                    RaiseEvent CSSToolbarItemClick(sender, CSSToolbarItem.tidRefresh)
                Case lbtnPropose.ClientID
                    RaiseEvent CSSToolbarItemClick(sender, CSSToolbarItem.tidPropose)
            End Select
        End Sub

        Public ReadOnly Property TB_IsAllowAdd() As Boolean
            Get
                Return chkIsAllowAdd.Checked
            End Get
        End Property
        Public ReadOnly Property TB_IsAllowEdit() As Boolean
            Get
                Return chkIsAllowEdit.Checked
            End Get
        End Property
        Public ReadOnly Property TB_IsAllowDelete() As Boolean
            Get
                Return chkIsAllowDelete.Checked
            End Get
        End Property
        Public ReadOnly Property TB_IsAllowApprove() As Boolean
            Get
                Return chkIsAllowApprove.Checked
            End Get
        End Property
        Public ReadOnly Property TB_IsAllowVoid() As Boolean
            Get
                Return chkIsAllowVoid.Checked
            End Get
        End Property
        Public ReadOnly Property TB_IsAllowPrint() As Boolean
            Get
                Return chkIsAllowPrint.Checked
            End Get
        End Property
        Public ReadOnly Property IsValid() As Boolean
            Get
                Return _IsValid
            End Get
        End Property
        Public Property [ProfileID]() As String
            Get
                Return _ProfileID
            End Get
            Set(ByVal Value As String)
                _ProfileID = Value
            End Set
        End Property
        Public Property [MenuID]() As String
            Get
                Return _MenuID
            End Get
            Set(ByVal Value As String)
                _MenuID = Value
            End Set
        End Property
    End Class
End Namespace


