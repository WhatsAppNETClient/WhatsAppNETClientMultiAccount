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

Public Class Session

    Private _sessionId As String
    Public Property SessionId() As String
        Get
            Return _sessionId
        End Get
        Set(ByVal value As String)
            _sessionId = value
        End Set
    End Property

    Private _port As String
    Public Property Port() As String
        Get
            Return _port
        End Get
        Set(ByVal value As String)
            _port = value
        End Set
    End Property

    Private _btnAction As String
    Public Property BtnAction() As String
        Get
            Return _btnAction
        End Get
        Set(ByVal value As String)
            _btnAction = value
        End Set
    End Property

    Private _btnContact As String
    Public Property BtnContact() As String
        Get
            Return _btnContact
        End Get
        Set(ByVal value As String)
            _btnContact = value
        End Set
    End Property

    Private _btnSend As String
    Public Property BtnSend() As String
        Get
            Return _btnSend
        End Get
        Set(ByVal value As String)
            _btnSend = value
        End Set
    End Property
End Class
