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
