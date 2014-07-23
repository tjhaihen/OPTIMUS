Option Strict On
Option Explicit On 

Imports System
Imports System.Web
Imports System.Web.UI
Imports System.Web.Security
Imports System.Web.UI.WebControls
Imports System.Data
Imports System.Text
Imports System.Collections
Imports System.ComponentModel

Imports Microsoft.VisualBasic

Namespace Raven.Common

    Public NotInheritable Class ExceptionManager
        Private Sub New()
        End Sub

        Public Overloads Shared Sub Publish(ByVal e As Exception)
            SystemFramework.ApplicationLog.WriteError(e.Message.ToString)
            Throw New Exception(e.Message)
        End Sub
    End Class

End Namespace