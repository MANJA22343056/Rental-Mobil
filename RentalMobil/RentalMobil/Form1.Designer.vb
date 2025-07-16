<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtnopin = New System.Windows.Forms.TextBox()
        Me.dtppinjam = New System.Windows.Forms.DateTimePicker()
        Me.txtnapem = New System.Windows.Forms.TextBox()
        Me.txtnomobil = New System.Windows.Forms.TextBox()
        Me.cmbjenis = New System.Windows.Forms.ComboBox()
        Me.txtsewa = New System.Windows.Forms.TextBox()
        Me.txtlama = New System.Windows.Forms.TextBox()
        Me.txttotal = New System.Windows.Forms.TextBox()
        Me.CmdTambah = New System.Windows.Forms.Button()
        Me.CmdSimpan = New System.Windows.Forms.Button()
        Me.CmdBatal = New System.Windows.Forms.Button()
        Me.CmdUpdate = New System.Windows.Forms.Button()
        Me.CmdHapus = New System.Windows.Forms.Button()
        Me.CmdKeluar = New System.Windows.Forms.Button()
        Me.DgTampil = New System.Windows.Forms.DataGridView()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        CType(Me.DgTampil, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(223, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "RENTAL MOBIL CRYSTAL"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(20, 60)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Nomor Pinjam :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(20, 90)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(86, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Tanggal Pinjam :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(20, 120)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(98, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Nama Peminjam :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(20, 150)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(58, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "No Mobil :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(20, 180)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(67, 13)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Jenis Mobil :"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(20, 210)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(65, 13)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Sewa / Hari :"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(20, 240)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(39, 13)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "Lama :"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(6, 16)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(67, 13)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "Total Bayar :"
        '
        'txtnopin
        '
        Me.txtnopin.Location = New System.Drawing.Point(130, 57)
        Me.txtnopin.Name = "txtnopin"
        Me.txtnopin.Size = New System.Drawing.Size(200, 20)
        Me.txtnopin.TabIndex = 8
        '
        'dtppinjam
        '
        Me.dtppinjam.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtppinjam.Location = New System.Drawing.Point(130, 87)
        Me.dtppinjam.Name = "dtppinjam"
        Me.dtppinjam.Size = New System.Drawing.Size(200, 20)
        Me.dtppinjam.TabIndex = 9
        '
        'txtnapem
        '
        Me.txtnapem.Location = New System.Drawing.Point(130, 117)
        Me.txtnapem.Name = "txtnapem"
        Me.txtnapem.Size = New System.Drawing.Size(200, 20)
        Me.txtnapem.TabIndex = 10
        '
        'txtnomobil
        '
        Me.txtnomobil.Location = New System.Drawing.Point(130, 147)
        Me.txtnomobil.Name = "txtnomobil"
        Me.txtnomobil.Size = New System.Drawing.Size(200, 20)
        Me.txtnomobil.TabIndex = 11
        '
        'cmbjenis
        '
        Me.cmbjenis.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbjenis.FormattingEnabled = True
        Me.cmbjenis.Items.AddRange(New Object() {"Avanza", "Xenia", "Innova", "CRV", "Fortuner"})
        Me.cmbjenis.Location = New System.Drawing.Point(130, 177)
        Me.cmbjenis.Name = "cmbjenis"
        Me.cmbjenis.Size = New System.Drawing.Size(200, 21)
        Me.cmbjenis.TabIndex = 12
        '
        'txtsewa
        '
        Me.txtsewa.Location = New System.Drawing.Point(130, 207)
        Me.txtsewa.Name = "txtsewa"
        Me.txtsewa.ReadOnly = True
        Me.txtsewa.Size = New System.Drawing.Size(200, 20)
        Me.txtsewa.TabIndex = 13
        '
        'txtlama
        '
        Me.txtlama.Location = New System.Drawing.Point(130, 237)
        Me.txtlama.Name = "txtlama"
        Me.txtlama.Size = New System.Drawing.Size(100, 20)
        Me.txtlama.TabIndex = 14
        '
        'txttotal
        '
        Me.txttotal.Location = New System.Drawing.Point(130, 267)
        Me.txttotal.Name = "txttotal"
        Me.txttotal.ReadOnly = True
        Me.txttotal.Size = New System.Drawing.Size(200, 20)
        Me.txttotal.TabIndex = 15
        '
        'CmdTambah
        '
        Me.CmdTambah.Location = New System.Drawing.Point(23, 320)
        Me.CmdTambah.Name = "CmdTambah"
        Me.CmdTambah.Size = New System.Drawing.Size(75, 23)
        Me.CmdTambah.TabIndex = 16
        Me.CmdTambah.Text = "Tambah"
        Me.CmdTambah.UseVisualStyleBackColor = True
        '
        'CmdSimpan
        '
        Me.CmdSimpan.Location = New System.Drawing.Point(104, 320)
        Me.CmdSimpan.Name = "CmdSimpan"
        Me.CmdSimpan.Size = New System.Drawing.Size(75, 23)
        Me.CmdSimpan.TabIndex = 17
        Me.CmdSimpan.Text = "Simpan"
        Me.CmdSimpan.UseVisualStyleBackColor = True
        '
        'CmdBatal
        '
        Me.CmdBatal.Location = New System.Drawing.Point(185, 320)
        Me.CmdBatal.Name = "CmdBatal"
        Me.CmdBatal.Size = New System.Drawing.Size(75, 23)
        Me.CmdBatal.TabIndex = 18
        Me.CmdBatal.Text = "Batal"
        Me.CmdBatal.UseVisualStyleBackColor = True
        '
        'CmdUpdate
        '
        Me.CmdUpdate.Location = New System.Drawing.Point(266, 320)
        Me.CmdUpdate.Name = "CmdUpdate"
        Me.CmdUpdate.Size = New System.Drawing.Size(75, 23)
        Me.CmdUpdate.TabIndex = 19
        Me.CmdUpdate.Text = "Update"
        Me.CmdUpdate.UseVisualStyleBackColor = True
        '
        'CmdHapus
        '
        Me.CmdHapus.Location = New System.Drawing.Point(347, 320)
        Me.CmdHapus.Name = "CmdHapus"
        Me.CmdHapus.Size = New System.Drawing.Size(75, 23)
        Me.CmdHapus.TabIndex = 20
        Me.CmdHapus.Text = "Hapus"
        Me.CmdHapus.UseVisualStyleBackColor = True
        '
        'CmdKeluar
        '
        Me.CmdKeluar.Location = New System.Drawing.Point(428, 320)
        Me.CmdKeluar.Name = "CmdKeluar"
        Me.CmdKeluar.Size = New System.Drawing.Size(75, 23)
        Me.CmdKeluar.TabIndex = 21
        Me.CmdKeluar.Text = "Keluar"
        Me.CmdKeluar.UseVisualStyleBackColor = True
        '
        'DgTampil
        '
        Me.DgTampil.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgTampil.Location = New System.Drawing.Point(23, 360)
        Me.DgTampil.Name = "DgTampil"
        Me.DgTampil.Size = New System.Drawing.Size(520, 150)
        Me.DgTampil.TabIndex = 22
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.txttotal)
        Me.GroupBox1.Location = New System.Drawing.Point(20, 260)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(340, 50)
        Me.GroupBox1.TabIndex = 23
        Me.GroupBox1.TabStop = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(570, 530)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.DgTampil)
        Me.Controls.Add(Me.CmdKeluar)
        Me.Controls.Add(Me.CmdHapus)
        Me.Controls.Add(Me.CmdUpdate)
        Me.Controls.Add(Me.CmdBatal)
        Me.Controls.Add(Me.CmdSimpan)
        Me.Controls.Add(Me.CmdTambah)
        Me.Controls.Add(Me.txtlama)
        Me.Controls.Add(Me.txtsewa)
        Me.Controls.Add(Me.cmbjenis)
        Me.Controls.Add(Me.txtnomobil)
        Me.Controls.Add(Me.txtnapem)
        Me.Controls.Add(Me.dtppinjam)
        Me.Controls.Add(Me.txtnopin)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "DATA RENTAL MOBIL"
        CType(Me.DgTampil, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents txtnopin As TextBox
    Friend WithEvents dtppinjam As DateTimePicker
    Friend WithEvents txtnapem As TextBox
    Friend WithEvents txtnomobil As TextBox
    Friend WithEvents cmbjenis As ComboBox
    Friend WithEvents txtsewa As TextBox
    Friend WithEvents txtlama As TextBox
    Friend WithEvents txttotal As TextBox
    Friend WithEvents CmdTambah As Button
    Friend WithEvents CmdSimpan As Button
    Friend WithEvents CmdBatal As Button
    Friend WithEvents CmdUpdate As Button
    Friend WithEvents CmdHapus As Button
    Friend WithEvents CmdKeluar As Button
    Friend WithEvents DgTampil As DataGridView
    Friend WithEvents GroupBox1 As GroupBox

End Class