Imports MySql.Data.MySqlClient
Imports System.Data.SqlClient
Imports System.Data

Public Class Score
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
        Dim myadapter As New MySqlDataAdapter("SELECT p.nama, s.point FROM tbl_pemain p JOIN tbl_point s USING(id_pemain) ORDER BY point DESC", mySqlConn)
        Dim mydata As New DataTable
        myadapter.Fill(mydata)
        DataGridView1.DataSource = mydata
    End Sub

    Private Sub Score_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        koneksi()
        opentable()
    End Sub

End Class