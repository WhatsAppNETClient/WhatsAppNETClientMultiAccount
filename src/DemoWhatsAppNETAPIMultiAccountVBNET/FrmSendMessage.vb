'*******************************************************************************************************************
' Copyright (C) 2021 Kamarudin (http://wa-net.coding4ever.net/)
'
' Licensed under the Apache License, Version 2.0 (the "License"); you may not
' use this file except in compliance with the License. You may obtain a copy of
' the License at
'
' http://www.apache.org/licenses/LICENSE-2.0
'
' Unless required by applicable law or agreed to in writing, software
' distributed under the License is distributed on an "AS IS" BASIS, WITHOUT
' WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the
' License for the specific language governing permissions and limitations under
' the License.
'
' The latest version of this file can be found at https://github.com/WhatsAppNETClient/WhatsAppNETClientMultiAccount
'*******************************************************************************************************************

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