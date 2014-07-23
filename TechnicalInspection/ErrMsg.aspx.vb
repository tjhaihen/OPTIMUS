
Namespace Raven.Web

    Public Class ErrMsg
        Inherits PageBase
        Protected WithEvents lblErrorDesc As Label
        Protected WithEvents lblErrorDateTime As Label
        Protected WithEvents lblErrorPerformedBy As Label
        Protected WithEvents lblEmergencyEmail As Label
        Protected WithEvents lblEmergencyPhone As Label

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
            If Not Page.IsPostBack Then
                Dim ex As Exception
                ex = CType(Session("Cached:Error:"), Exception)

                If Not ex Is Nothing Then
                    Dim msg As String = ex.Message
                    lblErrorDesc.Text = msg
                    lblErrorDateTime.Text = DateTime.Now.ToString.Trim
                    lblErrorPerformedBy.Text = MyBase.LoggedOnUserID.Trim + " [" + MyBase.LoggedOnProfileID.Trim + "]"
                End If
                Session.Remove("Cached:Error:")
            End If
        End Sub

    End Class

End Namespace