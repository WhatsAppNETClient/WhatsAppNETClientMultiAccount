/**
 * Copyright (C) 2021 Kamarudin (http://wa-net.coding4ever.net/)
 *
 * Licensed under the Apache License, Version 2.0 (the "License"); you may not
 * use this file except in compliance with the License. You may obtain a copy of
 * the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS, WITHOUT
 * WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the
 * License for the specific language governing permissions and limitations under
 * the License.
 *
 * The latest version of this file can be found at https://github.com/WhatsAppNETClient/WhatsAppNETClientMultiSession
 */

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WhatsAppNETAPI;

using BrightIdeasSoftware;
using ConceptCave.WaitCursor;

namespace DemoWhatsAppNETAPIMultiAccountCSharp
{
    public partial class FrmMain : Form
    {
        private IList<Session> _listOfSession = new List<Session>();
        private Dictionary<string, IWhatsAppNETAPI> _listOfWAClient = new Dictionary<string, IWhatsAppNETAPI>();        

        private int noUrut = 1;

        public FrmMain()
        {
            InitializeComponent();

            InitListView();
            LoadSession();
        }

        private IWhatsAppNETAPI GetWAInstance(string sessionId)
        {
            IWhatsAppNETAPI wa = null;

            var isExist = _listOfWAClient.ContainsKey(sessionId);
            if (isExist) wa = _listOfWAClient[sessionId];

            return wa;
        }

        private void InitListView()
        {
            var listViewProperty = new List<ObjectListViewProperty>();

            var width = 120;

            listViewProperty.Add(new ObjectListViewProperty { Header = "No", Width = 40, TextAlign = HorizontalAlignment.Center });
            listViewProperty.Add(new ObjectListViewProperty { Header = "Session Id", Width = width, FieldName = "SessionId", TextAlign = HorizontalAlignment.Center });
            listViewProperty.Add(new ObjectListViewProperty { Header = "Port", Width = width, FieldName = "Port",  TextAlign = HorizontalAlignment.Center });
            listViewProperty.Add(new ObjectListViewProperty { Header = "Action", Width = width, FieldName = "BtnAction", IsButton = true, TextAlign = HorizontalAlignment.Center });
            listViewProperty.Add(new ObjectListViewProperty { Header = "Contact", Width = width, FieldName = "BtnContact", IsButton = true, TextAlign = HorizontalAlignment.Center });
            listViewProperty.Add(new ObjectListViewProperty { Header = "Send", Width = width, FieldName = "BtnSend", IsButton = true, TextAlign = HorizontalAlignment.Center, IsFillsFreeSpace = true });

            ObjectListViewHelper.InitializeObjectListView(this.listView, listViewProperty);

            this.listView.ButtonClick += delegate (object sender, CellClickEventArgs e)
            {
                IWhatsAppNETAPI wa = null;
                var session = (Session)e.Model;

                if (e.ColumnIndex == 3) // button start
                {                                        
                    if (session.BtnAction == "Start")
                    {
                        if (string.IsNullOrEmpty(txtLokasiWhatsAppNETAPINodeJs.Text))
                        {
                            MessageBox.Show("Maaf, lokasi folder 'WhatsApp NET API NodeJs'  belum di set", "Peringatan",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                            txtLokasiWhatsAppNETAPINodeJs.Focus();
                            return;
                        }

                        wa = GetWAInstance(session.SessionId);
                        if (wa == null)
                        {
                            wa = new WhatsAppNETAPI.WhatsAppNETAPI(session.Port, session.SessionId);
                            wa.WaNetApiNodeJsPath = txtLokasiWhatsAppNETAPINodeJs.Text;

                            if (!wa.IsWaNetApiNodeJsPathExists)
                            {
                                MessageBox.Show("Maaf, lokasi folder 'WhatsApp NET API NodeJs' tidak ditemukan !!!", "Peringatan",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                                txtLokasiWhatsAppNETAPINodeJs.Focus();
                                return;
                            }

                            _listOfWAClient.Add(session.SessionId, wa);
                        }

                        Connect(wa);
                    }
                    else // stop
                    {
                        wa = GetWAInstance(session.SessionId);
                        Disconnect(wa);
                    }

                    session.BtnAction = session.BtnAction == "Start" ? "Stop" : "Start";
                    this.listView.RefreshObject(e.Model);
                }
                else if (e.ColumnIndex == 4) // button load contact
                {
                    if (session.BtnAction == "Start")
                    {
                        MessageBox.Show("Di start dulu om", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    lstLog.Items.Clear();
                    wa = GetWAInstance(session.SessionId);
                    wa.GetContacts();
                }
                else if (e.ColumnIndex == 5) // button send
                {
                    if (session.BtnAction == "Start")
                    {
                        MessageBox.Show("Di start dulu om", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    var frm = new FrmSendMessage(session.SessionId);
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        var contact = frm.Contact;
                        var message = frm.Message;

                        if (!string.IsNullOrEmpty(contact))
                        {
                            wa = GetWAInstance(session.SessionId);

                            var msgArgs = new MsgArgs(contact, message, MsgArgsType.Text);
                            wa.SendMessage(msgArgs);
                        }
                    }
                }
            };
        }

        private void LoadSession()
        {
            // sesi bisa di load dari database
            // sesi id dan port harus unik
            _listOfSession.Add(new Session { SessionId = "WA Center 1", Port = "9091", BtnAction = "Start", BtnContact = "Contact", BtnSend = "Send" });
            _listOfSession.Add(new Session { SessionId = "WA Center 2", Port = "9192", BtnAction = "Start", BtnContact = "Contact", BtnSend = "Send" });
            _listOfSession.Add(new Session { SessionId = "WA Center 3", Port = "9193", BtnAction = "Start", BtnContact = "Contact", BtnSend = "Send" });

            ObjectListViewHelper.AddObjects<Session>(this.listView, _listOfSession);
        }

        private void Connect(IWhatsAppNETAPI wa)
        {
            // subscribe event
            wa.OnStartup += OnStartupHandler;
            wa.OnReceiveMessage += OnReceiveMessageHandler;
            // wa.OnReceiveMessages += OnReceiveMessagesHandler;
            // wa.OnReceiveMessageStatus += OnReceiveMessageStatusHandler;
            // wa.OnChangeState += OnChangeStateHandler;
            wa.OnReceiveContacts += OnReceiveContactsHandler;
            // wa.OnReceiveGroups += OnReceiveGroupsHandler;
            wa.OnClientConnected += OnClientConnectedHandler;
            wa.Connect();

            using (var frm = new FrmStartUp())
            {
                // subscribe event
                wa.OnStartup += frm.OnStartupHandler;
                wa.OnScanMe += frm.OnScanMeHandler;

                frm.UseWaitCursor = true;
                frm.ShowDialog();

                // unsubscribe event
                wa.OnStartup -= frm.OnStartupHandler;
                wa.OnScanMe -= frm.OnScanMeHandler;
            }
        }

        private void Disconnect(IWhatsAppNETAPI wa)
        {
            using (new StCursor(Cursors.WaitCursor, new TimeSpan(0, 0, 0, 0)))
            {
                // unsubscribe event
                wa.OnStartup -= OnStartupHandler;
                // wa.OnChangeState -= OnChangeStateHandler;
                wa.OnReceiveMessage -= OnReceiveMessageHandler;
                wa.OnReceiveContacts -= OnReceiveContactsHandler;
                // wa.OnReceiveMessages -= OnReceiveMessagesHandler;
                // wa.OnReceiveMessageStatus -= OnReceiveMessageStatusHandler;
                wa.OnClientConnected -= OnClientConnectedHandler;

                if (wa.IsConnected) wa.Disconnect();
            }
        }

        private void Disconnect()
        {
            if (!(_listOfWAClient.Count > 0)) return;

            using (new StCursor(Cursors.WaitCursor, new TimeSpan(0, 0, 0, 0)))
            {
                foreach (var item in _listOfWAClient)
                {
                    var wa = item.Value;

                    // unsubscribe event
                    wa.OnStartup -= OnStartupHandler;
                    wa.OnChangeState -= OnChangeStateHandler;
                    wa.OnReceiveMessage -= OnReceiveMessageHandler;
                    // wa.OnReceiveMessages -= OnReceiveMessagesHandler;
                    // wa.OnReceiveMessageStatus -= OnReceiveMessageStatusHandler;
                    wa.OnClientConnected -= OnClientConnectedHandler;

                    if (wa.IsConnected) wa.Disconnect();
                }
            }
        }

        private void btnLokasiWAAutomateNodejs_Click(object sender, EventArgs e)
        {
            var folderName = ShowDialogOpenFolder();

            if (!string.IsNullOrEmpty(folderName)) txtLokasiWhatsAppNETAPINodeJs.Text = folderName;
        }

        private string ShowDialogOpenFolder()
        {
            var folderName = string.Empty;

            using (var dlgOpen = new FolderBrowserDialog())
            {
                var result = dlgOpen.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(dlgOpen.SelectedPath))
                {
                    folderName = dlgOpen.SelectedPath;
                }
            }

            return folderName;
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Disconnect();
        }

        #region event handler

        private void OnClientConnectedHandler(string sessionId)
        {
            System.Diagnostics.Debug.Print("ClientConnected on {0:yyyy-MM-dd HH:mm:ss} -> [{1}]", DateTime.Now, sessionId);
        }

        private void OnReceiveContactsHandler(IList<Contact> contacts, string sessionId)
        {
            // update UI dari thread yang berbeda
            lstLog.Invoke(() =>
            {
                foreach (var contact in contacts)
                {
                    if (!(contact.id == "status@broadcast"))
                    {
                        lstLog.Items.Add(string.Format("[Sesi: {0}] {1}. {2} - {3}",
                        sessionId, noUrut, contact.id, contact.name));

                        noUrut++;
                    }
                    else // status@broadcast -> dummy contact, penanda load data contact selesai
                    {
                        if (this.IsHandleCreated)
                            this.Invoke(new MethodInvoker(() => this.UseWaitCursor = false));
                    }

                }
            });
        }

        private void OnChangeStateHandler(WAState state, string sessionId)
        {
            System.Diagnostics.Debug.Print("[Sesi: {0}]: {1}", sessionId, state.ToString());
        }

        private void OnStartupHandler(string message, string sessionId)
        {
            // koneksi ke WA berhasil
            if (message.IndexOf("Ready") >= 0)
            {
                this.UseWaitCursor = false;
            }

            // koneksi ke WA GAGAL, bisa dicoba lagi
            if (message.IndexOf("Failure") >= 0 || message.IndexOf("Timeout") >= 0
                || message.IndexOf("ERR_NAME") >= 0)
            {
                var wa = GetWAInstance(sessionId);
                if (wa != null) Disconnect(wa);

                this.UseWaitCursor = false;

                var msg = string.Format("{0}\n\nKoneksi ke WA gagal, silahkan cek koneksi internet Anda", message);
                MessageBox.Show(msg, "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void OnReceiveMessageHandler(WhatsAppNETAPI.Message message, string sessionId)
        {
            var msg = message.content;

            var pengirim = string.Empty;
            var group = string.Empty;

            var isGroup = message.group != null;

            if (isGroup) // pesan dari group
            {
                group = string.IsNullOrEmpty(message.group.name) ? message.from : message.group.name;

                var sender = message.group.sender;
                pengirim = string.IsNullOrEmpty(sender.name) ? message.from : sender.name;
            }
            else
                pengirim = string.IsNullOrEmpty(message.sender.name) ? message.from : message.sender.name;

            var fileName = message.filename;

            var data = string.Empty;

            if (isGroup)
            {
                if (string.IsNullOrEmpty(fileName))
                {
                    data = string.Format("[Sesi: {0} - {1}] Group: {2}, Pesan teks: {3}, Pengirim: {4}",
                        sessionId, message.datetime.ToString("yyyy-MM-dd HH:mm:ss"), group, msg, pengirim);
                }
                else
                    data = string.Format("[Sesi: {0} - {1}] Group: {2}, Pesan gambar/dokumen: {3}, Pengirim: {4}, nama file: {5}",
                        sessionId, message.datetime.ToString("yyyy-MM-dd HH:mm:ss"), group, msg, pengirim, fileName);
            }
            else
            {
                if (string.IsNullOrEmpty(fileName))
                {
                    data = string.Format("[Sesi: {0} - {1}] Pengirim: {2}, Pesan teks: {3}",
                        sessionId, message.datetime.ToString("yyyy-MM-dd HH:mm:ss"), pengirim, msg);
                }
                else
                    data = string.Format("[Sesi: {0} - {1}] Pengirim: {2}, Pesan gambar/dokumen: {3}, nama file: {4}",
                        sessionId, message.datetime.ToString("yyyy-MM-dd HH:mm:ss"), pengirim, msg, fileName);
            }

            // update UI dari thread yang berbeda
            lstLog.Invoke(() =>
            {
                lstLog.Items.Add(data);

                if (message.type == MessageType.Location)
                {
                    var location = message.location;
                    var dataLocation = string.Format("--> latitude: {0}, longitude: {1}, description: {2}",
                        location.latitude, location.longitude, location.description);

                    lstLog.Items.Add(dataLocation);
                }
                else if (message.type == MessageType.VCard || message.type == MessageType.MultiVCard)
                {
                    var vcards = message.vcards;
                    var vcardFilenames = message.vcardFilenames;

                    var index = 0;
                    foreach (var vcard in vcards)
                    {
                        var dataVCard = string.Format("--> N: {0}, FN: {1}, WA Id: {2}, fileName: {3}",
                            vcard.n, vcard.fn, vcard.waId, vcardFilenames[index]);

                        lstLog.Items.Add(dataVCard);
                        index++;
                    }
                }

                lstLog.SelectedIndex = lstLog.Items.Count - 1;
            });

            if (chkAutoReply.Checked)
            {
                var wa = GetWAInstance(sessionId);

                var senderName = string.IsNullOrEmpty(message.sender.name) ? message.from : message.sender.name;

                var msgReplay = string.Format("Bpk/Ibu *{0}*, pesan *{1}* sudah kami terima. Silahkan ditunggu.",
                        senderName, msg);

                wa.ReplyMessage(new ReplyMsgArgs(message.from, msgReplay, message.id));
            }
        }

        # endregion                      
                
    }
}
