Imports BrightIdeasSoftware

Public Class ObjectListViewHelper

    Public Shared Sub InitializeObjectListView(ByVal olvFast As FastObjectListView,
                                               ByVal olvProperty As List(Of ObjectListViewProperty),
                                               Optional ByVal addRowNumber As Boolean = True)

        olvFast.HideSelection = False
        olvFast.FullRowSelect = True
        olvFast.UseAlternatingBackColors = True
        olvFast.AlternateRowBackColor = Color.FromArgb(239, 239, 239)

        For Each item As ObjectListViewProperty In olvProperty
            Dim olvColumn = New OLVColumn()

            olvColumn.CellPadding = Nothing
            olvColumn.Text = item.Header
            olvColumn.Width = item.Width
            olvColumn.IsEditable = item.IsEditable
            olvColumn.FillsFreeSpace = item.IsFillsFreeSpace
            olvColumn.TextAlign = item.TextAlign
            olvColumn.Sortable = False

            If item.IsButton Then
                olvColumn.IsButton = True
                olvColumn.ButtonSizing = OLVColumn.ButtonSizingMode.CellBounds
            End If

            If item.FieldName IsNot Nothing Then
                olvColumn.AspectName = item.FieldName
            End If

            olvFast.AllColumns.Add(olvColumn)
        Next

        olvFast.RebuildColumns()
        olvFast.RowHeight = 30

        If addRowNumber Then
            ' AddHandler wa.OnStartup, AddressOf OnStartupHandler

            AddHandler olvFast.FormatRow, AddressOf FormatRowHandler
        End If
    End Sub

    Private Shared Sub FormatRowHandler(ByVal sender As Object, ByVal e As FormatRowEventArgs)

        Dim noUrut = e.DisplayIndex + 1
        e.Item.SubItems(0).Text = noUrut.ToString()

    End Sub

    Public Shared Sub AddObjects(Of T)(ByVal olvFast As FastObjectListView, ByVal record As List(Of T))
        olvFast.ClearObjects()

        If record.Count > 0 Then

            Dim obj = record(0)

            If obj IsNot Nothing Then
                olvFast.SetObjects(record)
                SelectObject(olvFast, obj)
            End If
        End If
    End Sub

    Public Shared Sub SelectObject(ByVal olvFast As FastObjectListView, ByVal obj As Object)
        olvFast.EnsureModelVisible(obj)
        olvFast.SelectObject(obj)
        olvFast.Focus()
    End Sub

End Class
