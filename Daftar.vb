Imports MySql.Data.MySqlClient
Imports System.Data.SqlClient
Imports System.Data

Public Class Daftar
    Dim mySqlConn As New MySqlConnection
    Dim mySqlCommand, mySqlCommandskor As New MySqlCommand
    Dim myadapter As New MySqlDataAdapter
    Dim mydata As New DataTable
    Dim reader As MySqlDataReader

    Sub koneksi()
        mySqlConn = New MySqlConnection("server='localhost';user id='root';password='';database='ternak'")
        mySqlConn.Open()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Call koneksi()
        mySqlCommand = New MySqlCommand("insert into tbl_pemain (nama) values('" & TextBox1.Text & "') ", mySqlConn)
        mySqlCommand.ExecuteNonQuery()

        Me.Hide()
        Main.Show()
    End Sub

    Private Sub Daftar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        koneksi()
    End Sub
End Class