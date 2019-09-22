Imports MySql.Data.MySqlClient
Imports System.Data.SqlClient
Imports System.Data

Public Class Peringkat
    Dim mySqlConn As New MySqlConnection
    Dim mySqlCommand, mySqlCommandskor As New MySqlCommand
    Dim myadapter As New MySqlDataAdapter
    Dim mydata As New DataTable
    Dim reader As MySqlDataReader

    Sub koneksi()
        mySqlConn = New MySqlConnection("server='localhost';user id='root';password='';database='ternak'")
        mySqlConn.Open()
    End Sub

    Sub opentable()
        Dim myadapter As New MySqlDataAdapter("SELECT p.nama, s.score FROM tbl_pemain p JOIN tbl_score s USING(id_pemain) ORDER BY score DESC", mySqlConn)
        Dim mydata As New DataTable
        myadapter.Fill(mydata)
        DataGridView1.DataSource = mydata
    End Sub

    Private Sub Score_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        koneksi()
        opentable()
    End Sub


    Private Sub PictureBox4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox4.Click
        Me.Hide()
        Home.Show()
    End Sub
End Class