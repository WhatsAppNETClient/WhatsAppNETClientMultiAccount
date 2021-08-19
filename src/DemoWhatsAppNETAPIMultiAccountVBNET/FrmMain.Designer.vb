<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.tableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.groupBox1 = New System.Windows.Forms.GroupBox()
        Me.tableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.lstLog = New System.Windows.Forms.ListBox()
        Me.chkAutoReply = New System.Windows.Forms.CheckBox()
        Me.flowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.label1 = New System.Windows.Forms.Label()
        Me.txtLokasiWhatsAppNETAPINodeJs = New System.Windows.Forms.TextBox()
        Me.btnLokasiWAAutomateNodejs = New System.Windows.Forms.Button()
        Me.groupBox2 = New System.Windows.Forms.GroupBox()
        Me.listView = New BrightIdeasSoftware.FastObjectListView()
        Me.tableLayoutPanel1.SuspendLayout()
        Me.groupBox1.SuspendLayout()
        Me.tableLayoutPanel2.SuspendLayout()
        Me.flowLayoutPanel1.SuspendLayout()
        Me.groupBox2.SuspendLayout()
        CType(Me.listView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tableLayoutPanel1
        '
        Me.tableLayoutPanel1.ColumnCount = 1
        Me.tableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tableLayoutPanel1.Controls.Add(Me.groupBox1, 0, 2)
        Me.tableLayoutPanel1.Controls.Add(Me.flowLayoutPanel1, 0, 0)
        Me.tableLayoutPanel1.Controls.Add(Me.groupBox2, 0, 1)
        Me.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.tableLayoutPanel1.Name = "tableLayoutPanel1"
        Me.tableLayoutPanel1.RowCount = 3
        Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34.0!))
        Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40.0!))
        Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60.0!))
        Me.tableLayoutPanel1.Size = New System.Drawing.Size(655, 484)
        Me.tableLayoutPanel1.TabIndex = 17
        '
        'groupBox1
        '
        Me.groupBox1.Controls.Add(Me.tableLayoutPanel2)
        Me.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.groupBox1.Location = New System.Drawing.Point(3, 217)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(649, 264)
        Me.groupBox1.TabIndex = 13
        Me.groupBox1.TabStop = False
        Me.groupBox1.Text = " [ Logs ] "
        '
        'tableLayoutPanel2
        '
        Me.tableLayoutPanel2.ColumnCount = 1
        Me.tableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tableLayoutPanel2.Controls.Add(Me.lstLog, 0, 1)
        Me.tableLayoutPanel2.Controls.Add(Me.chkAutoReply, 0, 0)
        Me.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tableLayoutPanel2.Location = New System.Drawing.Point(3, 16)
        Me.tableLayoutPanel2.Name = "tableLayoutPanel2"
        Me.tableLayoutPanel2.RowCount = 2
        Me.tableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.163346!))
        Me.tableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90.83665!))
        Me.tableLayoutPanel2.Size = New System.Drawing.Size(643, 245)
        Me.tableLayoutPanel2.TabIndex = 0
        '
        'lstLog
        '
        Me.lstLog.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lstLog.FormattingEnabled = True
        Me.lstLog.Location = New System.Drawing.Point(3, 25)
        Me.lstLog.Name = "lstLog"
        Me.lstLog.Size = New System.Drawing.Size(637, 217)
        Me.lstLog.TabIndex = 3
        '
        'chkAutoReply
        '
        Me.chkAutoReply.AutoSize = True
        Me.chkAutoReply.Location = New System.Drawing.Point(3, 3)
        Me.chkAutoReply.Name = "chkAutoReply"
        Me.chkAutoReply.Size = New System.Drawing.Size(73, 16)
        Me.chkAutoReply.TabIndex = 11
        Me.chkAutoReply.Text = "Auto reply"
        Me.chkAutoReply.UseVisualStyleBackColor = True
        '
        'flowLayoutPanel1
        '
        Me.flowLayoutPanel1.Controls.Add(Me.label1)
        Me.flowLayoutPanel1.Controls.Add(Me.txtLokasiWhatsAppNETAPINodeJs)
        Me.flowLayoutPanel1.Controls.Add(Me.btnLokasiWAAutomateNodejs)
        Me.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.flowLayoutPanel1.Location = New System.Drawing.Point(3, 3)
        Me.flowLayoutPanel1.Name = "flowLayoutPanel1"
        Me.flowLayoutPanel1.Size = New System.Drawing.Size(649, 28)
        Me.flowLayoutPanel1.TabIndex = 14
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(3, 0)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(175, 13)
        Me.label1.TabIndex = 12
        Me.label1.Text = "Lokasi WhatsApp NET API NodeJs"
        '
        'txtLokasiWhatsAppNETAPINodeJs
        '
        Me.txtLokasiWhatsAppNETAPINodeJs.Location = New System.Drawing.Point(184, 3)
        Me.txtLokasiWhatsAppNETAPINodeJs.Name = "txtLokasiWhatsAppNETAPINodeJs"
        Me.txtLokasiWhatsAppNETAPINodeJs.ReadOnly = True
        Me.txtLokasiWhatsAppNETAPINodeJs.Size = New System.Drawing.Size(421, 20)
        Me.txtLokasiWhatsAppNETAPINodeJs.TabIndex = 0
        '
        'btnLokasiWAAutomateNodejs
        '
        Me.btnLokasiWAAutomateNodejs.Location = New System.Drawing.Point(611, 3)
        Me.btnLokasiWAAutomateNodejs.Name = "btnLokasiWAAutomateNodejs"
        Me.btnLokasiWAAutomateNodejs.Size = New System.Drawing.Size(34, 23)
        Me.btnLokasiWAAutomateNodejs.TabIndex = 15
        Me.btnLokasiWAAutomateNodejs.Text = "..."
        Me.btnLokasiWAAutomateNodejs.UseVisualStyleBackColor = True
        '
        'groupBox2
        '
        Me.groupBox2.Controls.Add(Me.listView)
        Me.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.groupBox2.Location = New System.Drawing.Point(3, 37)
        Me.groupBox2.Name = "groupBox2"
        Me.groupBox2.Size = New System.Drawing.Size(649, 174)
        Me.groupBox2.TabIndex = 15
        Me.groupBox2.TabStop = False
        Me.groupBox2.Text = " [ Session ] "
        '
        'listView
        '
        Me.listView.CellEditUseWholeCell = False
        Me.listView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.listView.Location = New System.Drawing.Point(3, 16)
        Me.listView.Name = "listView"
        Me.listView.ShowGroups = False
        Me.listView.Size = New System.Drawing.Size(643, 155)
        Me.listView.TabIndex = 10
        Me.listView.UseCompatibleStateImageBehavior = False
        Me.listView.View = System.Windows.Forms.View.Details
        Me.listView.VirtualMode = True
        '
        'FrmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(655, 484)
        Me.Controls.Add(Me.tableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "FrmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Demo WhatsAppAPI untuk .NET Developer (VBNET) - Multi Account/WA Number/Session"
        Me.tableLayoutPanel1.ResumeLayout(False)
        Me.groupBox1.ResumeLayout(False)
        Me.tableLayoutPanel2.ResumeLayout(False)
        Me.tableLayoutPanel2.PerformLayout()
        Me.flowLayoutPanel1.ResumeLayout(False)
        Me.flowLayoutPanel1.PerformLayout()
        Me.groupBox2.ResumeLayout(False)
        CType(Me.listView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Private WithEvents tableLayoutPanel1 As TableLayoutPanel
    Private WithEvents groupBox1 As GroupBox
    Private WithEvents tableLayoutPanel2 As TableLayoutPanel
    Private WithEvents lstLog As ListBox
    Private WithEvents chkAutoReply As CheckBox
    Private WithEvents flowLayoutPanel1 As FlowLayoutPanel
    Private WithEvents label1 As Label
    Private WithEvents txtLokasiWhatsAppNETAPINodeJs As TextBox
    Private WithEvents btnLokasiWAAutomateNodejs As Button
    Private WithEvents groupBox2 As GroupBox
    Private WithEvents listView As BrightIdeasSoftware.FastObjectListView
End Class
