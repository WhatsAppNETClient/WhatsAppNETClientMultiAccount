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
