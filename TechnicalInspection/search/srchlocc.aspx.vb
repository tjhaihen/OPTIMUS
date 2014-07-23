Option Strict On
Option Explicit On 

Imports System
Imports System.Text
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports Microsoft.VisualBasic

Imports System.Data.SqlTypes

Imports Raven.Common


Namespace Raven.Web

    Public Class srchlocc
        Inherits PageBase

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
            Dim script As New System.Text.StringBuilder

            script.Append("function applicationUrl() ")
            script.Append("{")
            script.Append("return '" + PageBase.UrlBase + "/searchresults.aspx';")
            script.Append("}")
            script.Append("function Today() ")
            script.Append("{var retVal, tgl = new Date();")
            script.Append("retVal = tgl.getDay()+'-'+tgl.getMonth()+'-'+tgl.getFullYear();")
            script.Append("return retVal;")
            script.Append("}")

            Me.Controls.Add(New LiteralControl(script.ToString))
        End Sub

    End Class

End Namespace