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

Public Class ObjectListViewProperty

    Private _header As String
    Public Property Header() As String
        Get
            Return _header
        End Get
        Set(ByVal value As String)
            _header = value
        End Set
    End Property

    Private _fieldName As String
    Public Property FieldName() As String
        Get
            Return _fieldName
        End Get
        Set(ByVal value As String)
            _fieldName = value
        End Set
    End Property

    Private _width As Integer
    Public Property Width() As Integer
        Get
            Return _width
        End Get
        Set(ByVal value As Integer)
            _width = value
        End Set
    End Property

    Private _isEditable As Boolean
    Public Property IsEditable() As Boolean
        Get
            Return _isEditable
        End Get
        Set(ByVal value As Boolean)
            _isEditable = value
        End Set
    End Property

    Private _isFillsFreeSpace As Boolean
    Public Property IsFillsFreeSpace() As Boolean
        Get
            Return _isFillsFreeSpace
        End Get
        Set(ByVal value As Boolean)
            _isFillsFreeSpace = value
        End Set
    End Property

    Private _isButton As Boolean
    Public Property IsButton() As Boolean
        Get
            Return _isButton
        End Get
        Set(ByVal value As Boolean)
            _isButton = value
        End Set
    End Property

    Private _textAlign As HorizontalAlignment
    Public Property TextAlign() As HorizontalAlignment
        Get
            Return _textAlign
        End Get
        Set(ByVal value As HorizontalAlignment)
            _textAlign = value
        End Set
    End Property

End Class
