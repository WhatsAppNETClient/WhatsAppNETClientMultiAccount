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

Imports BrightIdeasSoftware
Imports ConceptCave.WaitCursor

Imports WhatsAppNETAPI

Public Class FrmMain

    Dim _listOfSession As IList(Of Session) = New List(Of Session)
    Dim _listOfWAClient As Dictionary(Of String, IWhatsAppNETAPI) = New Dictionary(Of String, IWhatsAppNETAPI)

    Dim noUrut = 1

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        InitListView()
        LoadSession()

    End Sub

    Private Function GetWAInstance(ByVal sessionId As String) As IWhatsAppNETAPI

        Dim wa As IWhatsAppNETAPI = Nothing

        Dim isExist = _listOfWAClient.ContainsKey(sessionId)
        If isExist Then wa = _listOfWAClient(sessionId)

        Return wa
    End Function

    Private Sub InitListView()

        Dim listViewProperty = New List(Of ObjectListViewProperty)

        Dim width = 120

        Dim header1 = New ObjectListViewProperty With {.Header = "No", .Width = 40, .TextAlign = HorizontalAlignment.Center}
        Dim header2 = New ObjectListViewProperty With {.Header = "Session Id", .Width = width, .FieldName = "SessionId", .TextAlign = HorizontalAlignment.Center}
        Dim header3 = New ObjectListViewProperty With {.Header = "Port", .Width = width, .FieldName = "Port", .TextAlign = HorizontalAlignment.Center}
        Dim header4 = New ObjectListViewProperty With {.Header = "Action", .Width = width, .FieldName = "BtnAction", .IsButton = True, .TextAlign = HorizontalAlignment.Center}
        Dim header5 = New ObjectListViewProperty With {.Header = "Contact", .Width = width, .FieldName = "BtnContact", .IsButton = True, .TextAlign = HorizontalAlignment.Center}
        Dim header6 = New ObjectListViewProperty With {.Header = "Send", .Width = width, .FieldName = "BtnSend", .IsButton = True, .TextAlign = HorizontalAlignment.Center, .IsFillsFreeSpace = True}

        listViewProperty.Add(header1)
        listViewProperty.Add(header2)
        listViewProperty.Add(header3)
        listViewProperty.Add(header4)
        listViewProperty.Add(header5)
        listViewProperty.Add(header6)

        ObjectListViewHelper.InitializeObjectListView(listView, listViewProperty)

        AddHandler listView.ButtonClick, AddressOf ButtonClickHandler
    End Sub

    Private Sub LoadSession()
        ' sesi bisa di load dari database
        ' sesi id dan port harus unik
        Dim sesi1 = New Session With {.SessionId = "WA Center 1", .Port = "9091", .BtnAction = "Start", .BtnContact = "Contact", .BtnSend = "Send"}
        Dim sesi2 = New Session With {.SessionId = "WA Center 2", .Port = "9092", .BtnAction = "Start", .BtnContact = "Contact", .BtnSend = "Send"}
        Dim sesi3 = New Session With {.SessionId = "WA Center 3", .Port = "9093", .BtnAction = "Start", .BtnContact = "Contact", .BtnSend = "Send"}

        _listOfSession.Add(sesi1)
        _listOfSession.Add(sesi2)
        _listOfSession.Add(sesi3)

        ObjectListViewHelper.AddObjects(Of Session)(listView, _listOfSession)
    End Sub

    Private Sub ButtonClickHandler(ByVal sender As Object, ByVal e As CellClickEventArgs)

        Dim wa As IWhatsAppNETAPI = Nothing
        Dim session = DirectCast(e.Model, Session)

        If e.ColumnIndex = 3 Then ' button start

            If session.BtnAction = "Start" Then

                If (String.IsNullOrEmpty(txtLokasiWhatsAppNETAPINodeJs.Text)) Then
                    MessageBox.Show("Maaf, lokasi folder 'WhatsApp NET API NodeJs'  belum di set", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Information)

                    txtLokasiWhatsAppNETAPINodeJs.Focus()

                    Return
                End If

                wa = GetWAInstance(session.SessionId)
                If (wa Is Nothing) Then
                    wa = New WhatsAppNETAPI.WhatsAppNETAPI(session.Port, session.SessionId)
                    wa.WaNetApiNodeJsPath = txtLokasiWhatsAppNETAPINodeJs.Text

                    If (Not wa.IsWaNetApiNodeJsPathExists) Then

                        MessageBox.Show("Maaf, lokasi folder 'WhatsApp NET API NodeJs' tidak ditemukan !!!", "Peringatan",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)

                        txtLokasiWhatsAppNETAPINodeJs.Focus()

                        Return
                    End If

                    _listOfWAClient.Add(session.SessionId, wa)
                End If

                Connect(wa)

            Else ' stop
                wa = GetWAInstance(session.SessionId)
                Disconnect(wa)
            End If

            session.BtnAction = IIf(session.BtnAction = "Start", "Stop", "Start")
            listView.RefreshObject(e.Model)

        ElseIf e.ColumnIndex = 4 Then ' button contact

            If session.BtnAction = "Start" Then
                MessageBox.Show("Di start dulu om", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            wa = GetWAInstance(session.SessionId)
            wa.GetContacts()

        ElseIf e.ColumnIndex = 5 Then ' button send
            If session.BtnAction = "Start" Then
                MessageBox.Show("Di start dulu om", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            Dim frm = New FrmSendMessage(session.SessionId)
            If frm.ShowDialog() = DialogResult.OK Then
                Dim Contact = frm.Contact
                Dim Message = frm.Message

                If Not String.IsNullOrEmpty(Contact) Then
                    wa = GetWAInstance(session.SessionId)

                    Dim MsgArgs = New MsgArgs(Contact, Message, MsgArgsType.Text)
                    wa.SendMessage(MsgArgs)
                End If
            End If
        End If
    End Sub

    Private Sub Connect(ByVal wa As IWhatsAppNETAPI)

        ' subscribe event
        AddHandler wa.OnStartup, AddressOf OnStartupHandler
        AddHandler wa.OnReceiveMessage, AddressOf OnReceiveMessageHandler

        ' AddHandler wa.OnReceiveMessages, AddressOf OnReceiveMessagesHandler
        ' AddHandler wa.OnReceiveMessageStatus, AddressOf OnReceiveMessageStatusHandler
        ' AddHandler wa.OnChangeState, AddressOf OnChangeStateHandler

        AddHandler wa.OnReceiveContacts, AddressOf OnReceiveContactsHandler
        AddHandler wa.OnClientConnected, AddressOf OnClientConnectedHandler

        wa.Connect()

        Using New StCursor(Cursors.WaitCursor, New TimeSpan(0, 0, 0, 0))

            Using frm As New FrmStartUp

                ' subscribe event
                AddHandler wa.OnStartup, AddressOf frm.OnStartupHandler
                AddHandler wa.OnScanMe, AddressOf frm.OnScanMeHandler

                frm.UseWaitCursor = True
                frm.ShowDialog()

                ' unsubscribe event
                RemoveHandler wa.OnStartup, AddressOf frm.OnStartupHandler
                RemoveHandler wa.OnScanMe, AddressOf frm.OnScanMeHandler

            End Using

        End Using
    End Sub

    Private Sub Disconnect(ByVal wa As IWhatsAppNETAPI)
        Using New StCursor(Cursors.WaitCursor, New TimeSpan(0, 0, 0, 0))

            ' unsubscribe event
            RemoveHandler wa.OnStartup, AddressOf OnStartupHandler

            ' RemoveHandler wa.OnChangeState, AddressOf OnChangeStateHandler
            RemoveHandler wa.OnReceiveMessage, AddressOf OnReceiveMessageHandler
            RemoveHandler wa.OnReceiveContacts, AddressOf OnReceiveContactsHandler
            ' RemoveHandler wa.OnReceiveMessages, AddressOf OnReceiveMessagesHandler
            ' RemoveHandler wa.OnReceiveMessageStatus, AddressOf OnReceiveMessageStatusHandler
            RemoveHandler wa.OnClientConnected, AddressOf OnClientConnectedHandler

            If wa.IsConnected Then wa.Disconnect()

        End Using
    End Sub

    Private Sub Disconnect()
        Using New StCursor(Cursors.WaitCursor, New TimeSpan(0, 0, 0, 0))

            For Each item In _listOfWAClient

                Dim wa = item.Value

                ' unsubscribe event
                RemoveHandler wa.OnStartup, AddressOf OnStartupHandler

                ' RemoveHandler wa.OnChangeState, AddressOf OnChangeStateHandler
                RemoveHandler wa.OnReceiveMessage, AddressOf OnReceiveMessageHandler
                RemoveHandler wa.OnReceiveContacts, AddressOf OnReceiveContactsHandler
                ' RemoveHandler wa.OnReceiveMessages, AddressOf OnReceiveMessagesHandler
                ' RemoveHandler wa.OnReceiveMessageStatus, AddressOf OnReceiveMessageStatusHandler
                RemoveHandler wa.OnClientConnected, AddressOf OnClientConnectedHandler

                If wa.IsConnected Then wa.Disconnect()
            Next

        End Using
    End Sub

    Private Sub btnLokasiWAAutomateNodejs_Click(sender As Object, e As EventArgs) Handles btnLokasiWAAutomateNodejs.Click
        Dim folderName = ShowDialogOpenFolder()

        If (Not String.IsNullOrEmpty(folderName)) Then txtLokasiWhatsAppNETAPINodeJs.Text = folderName
    End Sub

    Private Function ShowDialogOpenFolder() As String

        Dim folderName As String = String.Empty

        Using dlgOpen As New FolderBrowserDialog

            Dim result = dlgOpen.ShowDialog()

            If result = DialogResult.OK AndAlso (Not String.IsNullOrWhiteSpace(dlgOpen.SelectedPath)) Then
                folderName = dlgOpen.SelectedPath
            End If
        End Using

        Return folderName

    End Function

#Region "Event handler"

    Private Sub OnStartupHandler(ByVal message As String, ByVal sessionId As String)

        ' koneksi ke WA berhasil
        If message.IndexOf("Ready") >= 0 Then
            Me.UseWaitCursor = False
        End If

        ' koneksi ke WA GAGAL, bisa dicoba lagi
        If message.IndexOf("Failure") >= 0 OrElse message.IndexOf("Timeout") >= 0 _
            OrElse message.IndexOf("ERR_NAME") >= 0 Then

            Dim wa = GetWAInstance(sessionId)
            If (wa IsNot Nothing) Then Disconnect(wa)

            Me.UseWaitCursor = False

            Dim msg = message + Environment.NewLine + Environment.NewLine +
                    "Koneksi ke WA gagal, silahkan cek koneksi internet Anda"

            MessageBox.Show(msg, "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub OnChangeStateHandler(ByVal state As WhatsAppNETAPI.WAState, ByVal sessionId As String)
        System.Diagnostics.Debug.Print("[Sesi: {0}]: {1}", sessionId, state.ToString())
    End Sub

    Private Sub OnReceiveMessageHandler(ByVal message As WhatsAppNETAPI.Message, ByVal sessionId As String)

        Dim msg = message.content

        Dim pengirim = String.Empty
        Dim group = String.Empty

        Dim isGroup = message.group IsNot Nothing

        If isGroup Then
            group = IIf(String.IsNullOrEmpty(message.group.name), message.from, message.group.name)

            Dim sender = message.group.sender
            pengirim = IIf(String.IsNullOrEmpty(sender.name), message.from, sender.name)
        Else
            pengirim = IIf(String.IsNullOrEmpty(message.sender.name), message.from, message.sender.name)
        End If

        Dim fileName = message.filename

        Dim data = String.Empty

        If isGroup Then ' pesan dari group
            If String.IsNullOrEmpty(fileName) Then
                data = String.Format("[Sesi: {0} - {1}] Group: {2}, Pesan teks: {3}, Pengirim: {4}",
                        sessionId, message.datetime.ToString("yyyy-MM-dd HH:mm:ss"), group, msg, pengirim)
            Else
                data = String.Format("[Sesi: {0} - {1}] Group: {2}, Pesan gambar/dokumen: {3}, Pengirim: {4}, nama file: {5}",
                        sessionId, message.datetime.ToString("yyyy-MM-dd HH:mm:ss"), group, msg, pengirim, fileName)
            End If
        Else

            If String.IsNullOrEmpty(fileName) Then
                data = String.Format("[Sesi: {0} - {1}] Pengirim: {2}, Pesan teks: {3}",
                        sessionId, message.datetime.ToString("yyyy-MM-dd HH:mm:ss"), pengirim, msg)
            Else
                data = String.Format("[Sesi: {0} - {1}] Pengirim: {2}, Pesan gambar/dokumen: {3}, nama file: {4}",
                        sessionId, message.datetime.ToString("yyyy-MM-dd HH:mm:ss"), pengirim, msg, fileName)
            End If

        End If

        ' update UI dari thread yang berbeda
        lstLog.Invoke(
            Sub()
                lstLog.Items.Add(data)

                If message.type = MessageType.Location Then

                    Dim location = message.location

                    Dim dataLocation = String.Format("--> latitude: {0}, longitude: {1}, description: {2}",
                        location.latitude, location.longitude, location.description)

                    lstLog.Items.Add(dataLocation)

                ElseIf message.type = MessageType.VCard OrElse message.type = MessageType.MultiVCard Then
                    Dim vcards = message.vcards
                    Dim vcardFilenames = message.vcardFilenames

                    Dim index = 0
                    For Each vcard As VCard In vcards

                        Dim dataVCard = String.Format("--> N: {0}, FN: {1}, WA Id: {2}, fileName: {3}",
                            vcard.n, vcard.fn, vcard.waId, vcardFilenames(index))

                        lstLog.Items.Add(dataVCard)

                        index = index + 1
                    Next
                End If

                lstLog.SelectedIndex = lstLog.Items.Count - 1
            End Sub
        )

        If chkAutoReply.Checked Then

            Dim wa = GetWAInstance(sessionId)

            Dim msgReplay = String.Format("Bpk/Ibu *{0}*, pesan *{1}* sudah kami terima. Silahkan ditunggu.",
                    pengirim, msg)

            wa.ReplyMessage(New ReplyMsgArgs(message.from, msgReplay, message.id))

        End If
    End Sub

    Private Sub OnReceiveContactsHandler(ByVal contacts As IList(Of Contact), ByVal sessionId As String)
        ' update UI dari thread yang berbeda
        lstLog.Invoke(
            Sub()
                For Each contact As Contact In contacts

                    If Not (contact.id = "status@broadcast") Then
                        lstLog.Items.Add(String.Format("[Sesi: {0}] {1}. {2} - {3}",
                            sessionId, noUrut, contact.id, contact.name))

                        noUrut = noUrut + 1

                    Else ' status@broadcast -> dummy contact, penanda load data contact selesai
                        If Me.IsHandleCreated Then Me.Invoke(Sub() Me.UseWaitCursor = False)
                    End If
                Next
            End Sub
        )
    End Sub

    Private Sub OnClientConnectedHandler(ByVal sessionId As String)
        System.Diagnostics.Debug.Print("ClientConnected on {0:yyyy-MM-dd HH:mm:ss}", DateTime.Now)
    End Sub

#End Region
End Class
