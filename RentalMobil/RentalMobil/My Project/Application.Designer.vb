Imports MySql.Data.MySqlClient
Imports System.Data

Partial Public Class Form1
    ' Koneksi dan variabel global
    Dim strkon As String = "server=localhost;uid=root;password=;database=Rental_Mobil_2421006"
    Dim kon As MySqlConnection
    Dim perintah As MySqlCommand
    Dim mda As MySqlDataAdapter
    Dim ds As DataSet
    Dim cek As MySqlDataReader
    Dim sewa As Double = 0
    Dim total As Double = 0

    ' Konstruktor untuk inisialisasi
    Public Sub New()
        InitializeComponent()
        kon = New MySqlConnection(strkon)
        perintah = New MySqlCommand()
        mda = New MySqlDataAdapter()
        ds = New DataSet()
    End Sub

    ' Nonaktifkan kontrol
    Sub tidakaktif()
        txtnopin.Enabled = False
        dtppinjam.Enabled = False
        txtnapem.Enabled = False
        txtnomobil.Enabled = False
        cmbjenis.Enabled = False
        txtlama.Enabled = False
        CmdSimpan.Enabled = False
        CmdBatal.Enabled = False
        CmdUpdate.Enabled = False
        CmdHapus.Enabled = False
    End Sub

    ' Aktifkan kontrol
    Sub aktif()
        txtnopin.Enabled = True
        dtppinjam.Enabled = True
        txtnapem.Enabled = True
        txtnomobil.Enabled = True
        cmbjenis.Enabled = True
        txtlama.Enabled = True
        CmdSimpan.Enabled = True
        CmdBatal.Enabled = True
        CmdUpdate.Enabled = True
        CmdHapus.Enabled = True
    End Sub

    ' Bersihkan input
    Sub bersih()
        txtnopin.Clear()
        txtnapem.Clear()
        txtnomobil.Clear()
        cmbjenis.SelectedIndex = -1
        txtsewa.Clear()
        txtlama.Clear()
        txttotal.Clear()
        dtppinjam.Value = Now
        sewa = 0
        total = 0
    End Sub

    ' Tampilkan data ke DataGridView
    Sub tampil()
        Try
            If kon.State = ConnectionState.Open Then kon.Close()
            kon.Open()
            ds.Clear()
            perintah.Connection = kon
            perintah.CommandText = "SELECT Nopinjam, Tglpinjam, Namapeminjam, Nomobil, Jenismobil, Sewa, lama, Totalbayar FROM peminjaman ORDER BY Nopinjam"
            mda.SelectCommand = perintah
            mda.Fill(ds, "peminjaman")

            If ds.Tables("peminjaman").Rows.Count > 0 Then
                DgTampil.DataSource = ds.Tables("peminjaman")
                ' Format kolom header
                DgTampil.Columns(0).HeaderText = "No Pinjam"
                DgTampil.Columns(1).HeaderText = "Tanggal Pinjam"
                DgTampil.Columns(2).HeaderText = "Nama Peminjam"
                DgTampil.Columns(3).HeaderText = "No Mobil"
                DgTampil.Columns(4).HeaderText = "Jenis Mobil"
                DgTampil.Columns(5).HeaderText = "Sewa/Hari"
                DgTampil.Columns(6).HeaderText = "Lama (Hari)"
                DgTampil.Columns(7).HeaderText = "Total Bayar"

                ' Format tampilan untuk kolom currency
                DgTampil.Columns(5).DefaultCellStyle.Format = "N0"
                DgTampil.Columns(7).DefaultCellStyle.Format = "N0"

                ' Auto resize columns
                DgTampil.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            Else
                DgTampil.DataSource = Nothing
            End If
            kon.Close()
        Catch ex As Exception
            MsgBox("Gagal menampilkan data: " & ex.Message, MsgBoxStyle.Critical, "Error Database")
            If kon.State = ConnectionState.Open Then kon.Close()
        End Try
    End Sub

    ' Form Load
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            tidakaktif()
            bersih()
            tampil()
        Catch ex As Exception
            MsgBox("Error saat memuat form: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    ' Cek data saat input no pinjam
    Private Sub txtnopin_KeyDown(sender As Object, e As KeyEventArgs) Handles txtnopin.KeyDown
        If e.KeyCode = Keys.Enter And txtnopin.Text.Trim <> "" Then
            Try
                If kon.State = ConnectionState.Open Then kon.Close()
                kon.Open()
                perintah.Connection = kon
                perintah.CommandText = "SELECT * FROM peminjaman WHERE Nopinjam=@nopin"
                perintah.Parameters.Clear()
                perintah.Parameters.AddWithValue("@nopin", txtnopin.Text.Trim)
                cek = perintah.ExecuteReader()
                If cek.Read() Then
                    MsgBox("Data sudah ada!", MsgBoxStyle.Information, "Info")
                    dtppinjam.Value = Convert.ToDateTime(cek("Tglpinjam"))
                    txtnapem.Text = cek("Namapeminjam").ToString()
                    txtnomobil.Text = cek("Nomobil").ToString()
                    cmbjenis.Text = cek("Jenismobil").ToString()
                    sewa = Convert.ToDouble(cek("Sewa"))
                    txtsewa.Text = sewa.ToString("N0")
                    txtlama.Text = cek("lama").ToString()
                    total = Convert.ToDouble(cek("Totalbayar"))
                    txttotal.Text = total.ToString("N0")
                    CmdSimpan.Enabled = False
                    CmdUpdate.Enabled = True
                    CmdHapus.Enabled = True
                Else
                    ' Data tidak ditemukan, aktifkan input
                    CmdSimpan.Enabled = True
                    CmdUpdate.Enabled = False
                    CmdHapus.Enabled = False
                End If
                cek.Close()
                kon.Close()
            Catch ex As Exception
                MsgBox("Error saat mencari data: " & ex.Message, MsgBoxStyle.Critical, "Error Database")
                If cek IsNot Nothing AndAlso Not cek.IsClosed Then cek.Close()
                If kon.State = ConnectionState.Open Then kon.Close()
            End Try
        End If
    End Sub

    ' Harga sewa berdasarkan jenis
    Private Sub cmbjenis_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbjenis.SelectedIndexChanged
        If cmbjenis.SelectedIndex >= 0 Then
            Select Case cmbjenis.SelectedItem.ToString().ToUpper()
                Case "AVANZA", "XENIA"
                    sewa = 250000
                Case "INNOVA"
                    sewa = 300000
                Case "CRV"
                    sewa = 700000
                Case "FORTUNER"
                    sewa = 1000000
                Case Else
                    sewa = 0
            End Select
            txtsewa.Text = sewa.ToString("N0")

            ' Hitung ulang total jika lama sudah diisi
            If IsNumeric(txtlama.Text) And txtlama.Text.Trim <> "" Then
                total = sewa * Val(txtlama.Text)
                txttotal.Text = total.ToString("N0")
            End If
        End If
    End Sub

    ' Hitung total bayar
    Private Sub txtlama_TextChanged(sender As Object, e As EventArgs) Handles txtlama.TextChanged
        If IsNumeric(txtlama.Text) And txtlama.Text.Trim <> "" And sewa > 0 Then
            total = sewa * Val(txtlama.Text)
            txttotal.Text = total.ToString("N0")
        Else
            txttotal.Text = "0"
            total = 0
        End If
    End Sub

    ' Validasi input sebelum simpan
    Private Function ValidasiInput() As Boolean
        If txtnopin.Text.Trim = "" Then
            MsgBox("Nomor pinjam tidak boleh kosong!", MsgBoxStyle.Exclamation, "Validasi")
            txtnopin.Focus()
            Return False
        End If

        If txtnapem.Text.Trim = "" Then
            MsgBox("Nama peminjam tidak boleh kosong!", MsgBoxStyle.Exclamation, "Validasi")
            txtnapem.Focus()
            Return False
        End If

        If txtnomobil.Text.Trim = "" Then
            MsgBox("Nomor mobil tidak boleh kosong!", MsgBoxStyle.Exclamation, "Validasi")
            txtnomobil.Focus()
            Return False
        End If

        If cmbjenis.SelectedIndex = -1 Then
            MsgBox("Pilih jenis mobil!", MsgBoxStyle.Exclamation, "Validasi")
            cmbjenis.Focus()
            Return False
        End If

        If Not IsNumeric(txtlama.Text) Or Val(txtlama.Text) <= 0 Then
            MsgBox("Lama sewa harus berupa angka dan lebih dari 0!", MsgBoxStyle.Exclamation, "Validasi")
            txtlama.Focus()
            Return False
        End If

        ' Validasi tambahan untuk memastikan total > 0
        If total <= 0 Then
            MsgBox("Total bayar tidak valid!", MsgBoxStyle.Exclamation, "Validasi")
            Return False
        End If

        Return True
    End Function

    ' Tombol Tambah
    Private Sub CmdTambah_Click(sender As Object, e As EventArgs) Handles CmdTambah.Click
        aktif()
        bersih()
        CmdTambah.Enabled = False
        txtnopin.Focus()
    End Sub

    ' Tombol Simpan
    Private Sub CmdSimpan_Click(sender As Object, e As EventArgs) Handles CmdSimpan.Click
        If Not ValidasiInput() Then Exit Sub

        Try
            If kon.State = ConnectionState.Open Then kon.Close()
            kon.Open()

            ' Cek duplikasi nomor pinjam sebelum insert
            perintah.Connection = kon
            perintah.CommandText = "SELECT COUNT(*) FROM peminjaman WHERE Nopinjam=@nopin"
            perintah.Parameters.Clear()
            perintah.Parameters.AddWithValue("@nopin", txtnopin.Text.Trim)
            Dim count As Integer = Convert.ToInt32(perintah.ExecuteScalar())

            If count > 0 Then
                MsgBox("Nomor pinjam sudah ada! Gunakan nomor yang berbeda.", MsgBoxStyle.Exclamation, "Duplikasi Data")
                txtnopin.Focus()
                txtnopin.SelectAll()
                kon.Close()
                Exit Sub
            End If

            ' Insert data baru
            perintah.CommandText = "INSERT INTO peminjaman (Nopinjam, Tglpinjam, Namapeminjam, Nomobil, Jenismobil, Sewa, lama, Totalbayar) VALUES (@nopin, @tgl, @napem, @nomob, @jenis, @sewa, @lama, @total)"
            perintah.Parameters.Clear()
            perintah.Parameters.AddWithValue("@nopin", txtnopin.Text.Trim)
            perintah.Parameters.AddWithValue("@tgl", dtppinjam.Value.ToString("yyyy-MM-dd"))
            perintah.Parameters.AddWithValue("@napem", txtnapem.Text.Trim)
            perintah.Parameters.AddWithValue("@nomob", txtnomobil.Text.Trim)
            perintah.Parameters.AddWithValue("@jenis", cmbjenis.Text)
            perintah.Parameters.AddWithValue("@sewa", sewa)
            perintah.Parameters.AddWithValue("@lama", Val(txtlama.Text))
            perintah.Parameters.AddWithValue("@total", total)
            perintah.ExecuteNonQuery()
            kon.Close()

            MsgBox("Data berhasil disimpan!", MsgBoxStyle.Information, "Sukses")
            tampil()
            bersih()
            tidakaktif()
            CmdTambah.Enabled = True
        Catch ex As Exception
            MsgBox("Gagal simpan: " & ex.Message, MsgBoxStyle.Critical, "Error Database")
            If kon.State = ConnectionState.Open Then kon.Close()
        End Try
    End Sub

    ' Tombol Update
    Private Sub CmdUpdate_Click(sender As Object, e As EventArgs) Handles CmdUpdate.Click
        If Not ValidasiInput() Then Exit Sub

        If MsgBox("Yakin ingin mengupdate data ini?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Konfirmasi") = MsgBoxResult.Yes Then
            Try
                If kon.State = ConnectionState.Open Then kon.Close()
                kon.Open()
                perintah.Connection = kon
                perintah.CommandText = "UPDATE peminjaman SET Tglpinjam=@tgl, Namapeminjam=@napem, Nomobil=@nomob, Jenismobil=@jenis, Sewa=@sewa, lama=@lama, Totalbayar=@total WHERE Nopinjam=@nopin"
                perintah.Parameters.Clear()
                perintah.Parameters.AddWithValue("@tgl", dtppinjam.Value.ToString("yyyy-MM-dd"))
                perintah.Parameters.AddWithValue("@napem", txtnapem.Text.Trim)
                perintah.Parameters.AddWithValue("@nomob", txtnomobil.Text.Trim)
                perintah.Parameters.AddWithValue("@jenis", cmbjenis.Text)
                perintah.Parameters.AddWithValue("@sewa", sewa)
                perintah.Parameters.AddWithValue("@lama", Val(txtlama.Text))
                perintah.Parameters.AddWithValue("@total", total)
                perintah.Parameters.AddWithValue("@nopin", txtnopin.Text.Trim)

                Dim rowsAffected As Integer = perintah.ExecuteNonQuery()
                kon.Close()

                If rowsAffected > 0 Then
                    MsgBox("Data berhasil diupdate!", MsgBoxStyle.Information, "Sukses")
                    tampil()
                    bersih()
                    tidakaktif()
                    CmdTambah.Enabled = True
                Else
                    MsgBox("Data tidak ditemukan atau tidak ada perubahan!", MsgBoxStyle.Exclamation, "Peringatan")
                End If
            Catch ex As Exception
                MsgBox("Gagal update: " & ex.Message, MsgBoxStyle.Critical, "Error Database")
                If kon.State = ConnectionState.Open Then kon.Close()
            End Try
        End If
    End Sub

    ' Tombol Hapus
    Private Sub CmdHapus_Click(sender As Object, e As EventArgs) Handles CmdHapus.Click
        If txtnopin.Text.Trim = "" Then
            MsgBox("Pilih data yang akan dihapus terlebih dahulu!", MsgBoxStyle.Exclamation, "Peringatan")
            Exit Sub
        End If

        If MsgBox("Yakin ingin menghapus data dengan No Pinjam: " & txtnopin.Text & "?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Konfirmasi Hapus") = MsgBoxResult.Yes Then
            Try
                If kon.State = ConnectionState.Open Then kon.Close()
                kon.Open()
                perintah.Connection = kon
                perintah.CommandText = "DELETE FROM peminjaman WHERE Nopinjam=@nopin"
                perintah.Parameters.Clear()
                perintah.Parameters.AddWithValue("@nopin", txtnopin.Text.Trim)

                Dim rowsAffected As Integer = perintah.ExecuteNonQuery()
                kon.Close()

                If rowsAffected > 0 Then
                    MsgBox("Data berhasil dihapus!", MsgBoxStyle.Information, "Sukses")
                    tampil()
                    bersih()
                    tidakaktif()
                    CmdTambah.Enabled = True
                Else
                    MsgBox("Data tidak ditemukan!", MsgBoxStyle.Exclamation, "Peringatan")
                End If
            Catch ex As Exception
                MsgBox("Gagal hapus: " & ex.Message, MsgBoxStyle.Critical, "Error Database")
                If kon.State = ConnectionState.Open Then kon.Close()
            End Try
        End If
    End Sub

    ' Tombol Batal
    Private Sub CmdBatal_Click(sender As Object, e As EventArgs) Handles CmdBatal.Click
        tidakaktif()
        bersih()
        CmdTambah.Enabled = True
    End Sub

    ' Tombol Keluar
    Private Sub CmdKeluar_Click(sender As Object, e As EventArgs) Handles CmdKeluar.Click
        If MsgBox("Yakin ingin keluar dari aplikasi?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Konfirmasi") = MsgBoxResult.Yes Then
            Try
                If kon IsNot Nothing AndAlso kon.State = ConnectionState.Open Then
                    kon.Close()
                End If
            Catch ex As Exception
                ' Ignore error saat menutup koneksi
            End Try
            Me.Close()
        End If
    End Sub

    ' Event untuk klik pada DataGridView
    Private Sub DgTampil_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgTampil.CellClick
        If e.RowIndex >= 0 AndAlso DgTampil.Rows(e.RowIndex).Cells(0).Value IsNot Nothing Then
            Try
                aktif()
                txtnopin.Text = DgTampil.Rows(e.RowIndex).Cells(0).Value.ToString()
                dtppinjam.Value = Convert.ToDateTime(DgTampil.Rows(e.RowIndex).Cells(1).Value)
                txtnapem.Text = DgTampil.Rows(e.RowIndex).Cells(2).Value.ToString()
                txtnomobil.Text = DgTampil.Rows(e.RowIndex).Cells(3).Value.ToString()
                cmbjenis.Text = DgTampil.Rows(e.RowIndex).Cells(4).Value.ToString()
                sewa = Convert.ToDouble(DgTampil.Rows(e.RowIndex).Cells(5).Value)
                txtsewa.Text = sewa.ToString("N0")
                txtlama.Text = DgTampil.Rows(e.RowIndex).Cells(6).Value.ToString()
                total = Convert.ToDouble(DgTampil.Rows(e.RowIndex).Cells(7).Value)
                txttotal.Text = total.ToString("N0")

                CmdSimpan.Enabled = False
                CmdUpdate.Enabled = True
                CmdHapus.Enabled = True
                CmdTambah.Enabled = False
            Catch ex As Exception
                MsgBox("Error saat memuat data: " & ex.Message, MsgBoxStyle.Critical, "Error")
            End Try
        End If
    End Sub

    ' Override Form Closing untuk cleanup
    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Try
            If kon IsNot Nothing AndAlso kon.State = ConnectionState.Open Then
                kon.Close()
            End If
        Catch ex As Exception
            ' Ignore error saat cleanup
        End Try
    End Sub
End Class