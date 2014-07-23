Option Strict On
Option Explicit On 

Imports System
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Collections
Imports System.ComponentModel
Imports System.Data

Namespace Raven.Web
    Public MustInherit Class Calendar
        Inherits ModuleBase

        Protected WithEvents txtPopUpCal As System.Web.UI.WebControls.TextBox
        Protected WithEvents calIcon As System.Web.UI.HtmlControls.HtmlImage
        Protected WithEvents pnlPopUpCal As System.Web.UI.WebControls.Panel

        Private _dontResetDate As Boolean = False
        Private _onUpdate As String = String.Empty

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub

        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Dim calText As New Text.StringBuilder

            With calText
                .Append("<script type=""text/javascript"">")
                .Append("Calendar.setup({")
                .Append("inputField     :    """ + txtPopUpCal.ClientID + """,")
                .Append("ifFormat       :    ""%d-%m-%Y"",")
                .Append("weekNumbers    :    false,")
                .Append("mondayFirst    :    false,")
                .Append("button         :    """ + calIcon.ClientID + """,")
                If (Len(_onUpdate) > 0) Then
                    .Append("onUpdate       :   " + _onUpdate + ",")
                End If
                .Append("singleClick    :    true")
                .Append("});")
                .Append("</script>")
            End With

            _registerCalClientScript()
            Me.Controls.Add(New System.Web.UI.LiteralControl(calText.ToString))

            If Not Page.IsPostBack Then
                If Not (DontResetDate) Then
                    resetDateValue()
                End If
            End If
        End Sub

        Private Sub _registerCalClientScript()
            Const scriptMain As String = "___calMain"
            Const scriptLang As String = "___calLang"
            Const scriptHelper As String = "___calHelper"
            Const styleCal As String = "___calStyle"

            Const scriptMainName As String = " <script type=""text/javascript"" src=""/PureravensLib/calendar/calendar.js""></script>"
            Const scriptLangName As String = "<script type=""text/javascript"" src=""/PureravensLib/calendar/lang/calendar-en.js""></script>"
            Const scriptHelperName As String = "<script type=""text/javascript"" src=""/PureravensLib/calendar/calendar-setup.js""></script>"
            Const styleCalName As String = "<link rel=""stylesheet"" type=""text/css"" media=""all"" href=""/PureravensLib/calendar/calendar-theme.css"" title=""theme"" >"

            If Not Page.ClientScript.IsClientScriptBlockRegistered(scriptMain) Then
                Page.RegisterClientScriptBlock(scriptMain, scriptMainName)
            End If
            If Not Page.ClientScript.IsClientScriptBlockRegistered(scriptLang) Then
                Page.RegisterClientScriptBlock(scriptLang, scriptLangName)
            End If
            If Not Page.ClientScript.IsClientScriptBlockRegistered(scriptHelper) Then
                Page.RegisterClientScriptBlock(scriptHelper, scriptHelperName)
            End If
            If Not Page.ClientScript.IsClientScriptBlockRegistered(styleCal) Then
                Page.RegisterClientScriptBlock(styleCal, styleCalName)
            End If

        End Sub

        Public Sub resetDateValue()
            Try
                txtPopUpCal.Text = Format(Date.Now, commonFunction.FORMAT_DATE_CAL)
            Catch ex As Exception
            End Try
        End Sub

        Public Property selectedDate() As Date
            Get
                If Len(txtPopUpCal.Text) = 0 Then
                    Return Nothing
                Else
                    Return commonFunction.ConvertDate(txtPopUpCal.Text.Trim)
                End If
            End Get
            Set(ByVal Value As Date)
                If (Value = Nothing Or IsDBNull(Value)) Then
                    txtPopUpCal.Text = String.Empty
                Else
                    txtPopUpCal.Text = Format(Value, commonFunction.FORMAT_DATE_CAL)
                End If
            End Set
        End Property

        Public Property DontResetDate() As Boolean
            Get
                Return _dontResetDate
            End Get
            Set(ByVal Value As Boolean)
                _dontResetDate = Value
            End Set
        End Property

        Public Property OnUpdate() As String
            Get
                Return _onUpdate
            End Get
            Set(ByVal Value As String)
                _onUpdate = Value
            End Set
        End Property

    End Class
End Namespace