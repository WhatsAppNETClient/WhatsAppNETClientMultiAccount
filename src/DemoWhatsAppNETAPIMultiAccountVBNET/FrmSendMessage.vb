Public Class FrmSendMessage
    Public ReadOnly Property Contact() As String
        Get
            Return txtContact.Text
        End Get
    End Property

    Public ReadOnly Property Message() As String
        Get
            Return txtMessage.Text
        End Get
    End Property

    Public Sub New(ByVal sessionId As String)

        ' This call is required by the designer.
        InitializeComponent()

        Me.Text = String.Format("Session Id: {0}", sessionId)
    End Sub

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        Me.DialogResult = DialogResult.OK
    End Sub
End Class