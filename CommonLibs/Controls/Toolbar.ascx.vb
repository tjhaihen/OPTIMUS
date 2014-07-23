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

Imports Raven.Common

Namespace Raven
    Public Enum ToolbarItem
        tidNew = 0
        tidSave = 1
        tidDelete = 2
        tidApprove = 3
        tidVoid = 4
        tidPrint = 5
        tidPrevious = 6
        tidNext = 7
    End Enum

    Public MustInherit Class Toolbar
        Inherits System.Web.UI.UserControl

        Private _IsValid As Boolean = False
        Private _UserGroupID As String = String.Empty
        Private _MenuID As String = String.Empty

        Public Event ToolbarItemClick(ByVal sender As Object, ByVal e As ToolbarItem)

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            If Me.IsPostBack Then
            Else
                'setAuthorizationToolbar()
                _registerPopUpToolbarClientScript()
            End If
        End Sub
        Private Sub lbtn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbtnNew.Click, lbtnSave.Click, lbtnDelete.Click, _
                                                                                            lbtnApprove.Click, lbtnVoid.Click, lbtnPrint.Click, _
                                                                                             lbtnPrevious.Click, lbtnNext.Click
            Select Case CType(sender, LinkButton).ClientID
                Case lbtnNew.ClientID
                    RaiseEvent ToolbarItemClick(sender, ToolbarItem.tidNew)
                Case lbtnSave.ClientID
                    RaiseEvent ToolbarItemClick(sender, ToolbarItem.tidSave)
                Case lbtnDelete.ClientID
                    RaiseEvent ToolbarItemClick(sender, ToolbarItem.tidDelete)
                Case lbtnApprove.ClientID
                    RaiseEvent ToolbarItemClick(sender, ToolbarItem.tidApprove)
                Case lbtnVoid.ClientID
                    RaiseEvent ToolbarItemClick(sender, ToolbarItem.tidVoid)
                Case lbtnPrint.ClientID
                    RaiseEvent ToolbarItemClick(sender, ToolbarItem.tidPrint)
                Case lbtnPrevious.ClientID
                    RaiseEvent ToolbarItemClick(sender, ToolbarItem.tidPrevious)
                Case lbtnNext.ClientID
                    RaiseEvent ToolbarItemClick(sender, ToolbarItem.tidNext)
            End Select
        End Sub

        Public Sub setAuthorizationToolbar()
            'Dim oUGM As New BussinessRules.UserGroupMenu
            'oUGM.UserGroupID = _UserGroupID.Trim
            'oUGM.MenuID = _MenuID.Trim

            'Dim dv As New DataView(oUGM.SelectOtorisasiMenuByUserGroupIDMenuID)
            'If dv.Count = 1 Then
            '    If CType(dv(0)("IsAllowAdd"), Boolean) Then
            '        chkIsAllowAdd.Checked = True
            '        lbtnNew.Enabled = True
            '    Else
            '        chkIsAllowAdd.Checked = False
            '        lbtnNew.Enabled = False
            '    End If
            '    If CType(dv(0)("IsAllowEdit"), Boolean) Then
            '        chkIsAllowEdit.Checked = True
            '    Else
            '        chkIsAllowEdit.Checked = False
            '    End If
            '    If chkIsAllowAdd.Checked Or chkIsAllowEdit.Checked Then
            '        lbtnSave.Enabled = True
            '    Else
            '        lbtnSave.Enabled = False
            '    End If

            '    If CType(dv(0)("IsAllowDelete"), Boolean) Then
            '        chkIsAllowDelete.Checked = True
            '        lbtnDelete.Enabled = True
            '    Else
            '        chkIsAllowDelete.Checked = False
            '        lbtnDelete.Enabled = False
            '    End If

            '    If CType(dv(0)("IsAllowApprove"), Boolean) Then
            '        chkIsAllowApprove.Checked = True
            '        lbtnApprove.Enabled = True
            '    Else
            '        chkIsAllowApprove.Checked = False
            '        lbtnApprove.Enabled = False
            '    End If

            '    If CType(dv(0)("IsAllowVoid"), Boolean) Then
            '        chkIsAllowVoid.Checked = True
            '        lbtnVoid.Enabled = True
            '    Else
            '        chkIsAllowVoid.Checked = False
            '        lbtnVoid.Enabled = False
            '    End If

            '    If CType(dv(0)("IsAllowPrint"), Boolean) Then
            '        chkIsAllowPrint.Checked = True
            '        lbtnPrint.Enabled = True
            '    Else
            '        chkIsAllowPrint.Checked = False
            '        lbtnPrint.Enabled = False
            '    End If
            'End If
        End Sub
        Private Sub _registerPopUpToolbarClientScript()
            EnableButton(ToolbarItem.tidSave) = True
            EnableButton(ToolbarItem.tidDelete) = True
            EnableButton(ToolbarItem.tidApprove) = True
            EnableButton(ToolbarItem.tidVoid) = True
            EnableButton(ToolbarItem.tidPrint) = True
        End Sub

        Public Property EnableButton(ByVal item As ToolbarItem) As Boolean
            Get
                Select Case item
                    Case ToolbarItem.tidNew
                        Return lbtnNew.Enabled
                    Case ToolbarItem.tidSave
                        Return lbtnSave.Enabled
                    Case ToolbarItem.tidDelete
                        Return lbtnDelete.Enabled
                    Case ToolbarItem.tidApprove
                        Return lbtnApprove.Enabled
                    Case ToolbarItem.tidVoid
                        Return lbtnVoid.Enabled
                    Case ToolbarItem.tidPrevious
                        Return lbtnPrevious.Enabled
                    Case ToolbarItem.tidNext
                        Return lbtnNext.Enabled
                    Case ToolbarItem.tidPrint
                        Return lbtnPrint.Enabled
                End Select
            End Get
            Set(ByVal Value As Boolean)
                Select Case item
                    Case ToolbarItem.tidNew
                        lbtnNew.Enabled = Value
                    Case ToolbarItem.tidSave
                        If chkIsAllowAdd.Checked Or chkIsAllowEdit.Checked Then
                            If Value Then
                                lbtnSave.Attributes.Add("OnClick", "javascript: if (!confirm('" + "Data akan disimpan. Apakah Anda yakin?" + "')) return false; return true;")
                            Else
                                lbtnSave.Attributes.Remove("OnClick")
                            End If
                            lbtnSave.Enabled = Value
                        End If
                    Case ToolbarItem.tidDelete
                        If chkIsAllowDelete.Checked Then
                            If Value Then
                                lbtnDelete.Attributes.Add("OnClick", "javascript: if (!confirm('" + "Data akan dihapus. Apakah Anda yakin?" + "')) return false; return true")
                            Else
                                lbtnDelete.Attributes.Remove("OnClick")
                            End If
                            lbtnDelete.Enabled = Value
                        End If
                    Case ToolbarItem.tidApprove
                        If chkIsAllowApprove.Checked Then
                            If Value Then
                                lbtnApprove.Attributes.Add("OnClick", "javascript: if (!confirm('" + "Data akan di-Approval. Apakah Anda yakin?" + "')) return false; return true")
                            Else
                                lbtnApprove.Attributes.Remove("OnClick")
                            End If
                            lbtnApprove.Enabled = Value
                        End If
                    Case ToolbarItem.tidVoid
                        If chkIsAllowVoid.Checked Then
                            If Value Then
                                lbtnVoid.Attributes.Add("OnClick", "javascript: if (!confirm('" + "Data akan dibatalkan. Apakah Anda yakin?" + "')) return false; return true")
                            Else
                                lbtnVoid.Attributes.Remove("OnClick")
                            End If
                            lbtnVoid.Enabled = Value
                        End If
                    Case ToolbarItem.tidPrevious
                        lbtnPrevious.Enabled = Value
                    Case ToolbarItem.tidNext
                        lbtnNext.Enabled = Value
                    Case ToolbarItem.tidPrint
                        If chkIsAllowPrint.Checked Then
                            If Value Then
                                lbtnPrint.Attributes.Add("OnClick", "javascript: if (!confirm('" + "Data akan dicetak. Apakah Anda yakin?" + "')) return false; return true")
                            Else
                                lbtnPrint.Attributes.Remove("OnClick")
                            End If
                            lbtnPrint.Enabled = Value
                        End If
                End Select
            End Set
        End Property
        Public Property VisibleButton(ByVal item As ToolbarItem) As Boolean
            Get
                Select Case item
                    Case ToolbarItem.tidNew
                        Return TMPnlNew.Visible
                    Case ToolbarItem.tidSave
                        Return TMPnlSave.Visible
                    Case ToolbarItem.tidDelete
                        Return TMPnlDelete.Visible
                    Case ToolbarItem.tidApprove
                        Return TMPnlApprove.Visible
                    Case ToolbarItem.tidVoid
                        Return TMPnlVoid.Visible
                    Case ToolbarItem.tidPrevious
                        Return TMPnlPrevious.Visible
                    Case ToolbarItem.tidNext
                        Return TMPnlNext.Visible
                    Case ToolbarItem.tidPrint
                        Return TMPnlPrint.Visible
                End Select
            End Get
            Set(ByVal Value As Boolean)
                Select Case item
                    Case ToolbarItem.tidNew
                        TMPnlNew.Visible = Value
                    Case ToolbarItem.tidSave
                        TMPnlSave.Visible = Value
                    Case ToolbarItem.tidDelete
                        TMPnlDelete.Visible = Value
                    Case ToolbarItem.tidApprove
                        TMPnlApprove.Visible = Value
                    Case ToolbarItem.tidVoid
                        TMPnlVoid.Visible = Value
                    Case ToolbarItem.tidPrevious
                        TMPnlPrevious.Visible = Value
                    Case ToolbarItem.tidNext
                        TMPnlNext.Visible = Value
                    Case ToolbarItem.tidPrint
                        TMPnlPrint.Visible = Value
                End Select
            End Set
        End Property

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

        Public Property [UserGroupID]() As String
            Get
                Return _UserGroupID
            End Get
            Set(ByVal Value As String)
                _UserGroupID = Value
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


