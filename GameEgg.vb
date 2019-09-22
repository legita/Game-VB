Imports MySql.Data.MySqlClient
Imports System.Data.SqlClient
Imports System.Data

Public Class Main
    Dim mySqlConn As New MySqlConnection
    Dim mySqlCommand As New MySqlCommand
    Dim myadapter As New MySqlDataAdapter
    Dim mydata As New DataTable
    Dim reader As MySqlDataReader
    Dim s As Integer
    Dim start As Integer = 5
    Dim pindah As Boolean = False
    Dim nyawa As Integer
    Dim hewan(5) As PictureBox
    Dim h(2) As PictureBox
    Dim score As Integer

    Sub koneksi()
        mySqlConn = New MySqlConnection("server='localhost';user id='root';password='';database='ternak'")
        mySqlConn.Open()
    End Sub

    Sub hewan4()
        nyawa += 1
        hewan(4).Location = New Point(200, 350)
        h(nyawa - 1).Hide()
        Return
    End Sub

    Sub hewan5()
        nyawa += 1
        hewan(5).Location = New Point(450, 400)
        h(nyawa - 1).Hide()
        Return
    End Sub

    Private Sub TimerRight_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerRight.Tick
        If Not PictureBox1.Bounds.IntersectsWith(PictureBox2.Bounds) Then
            PictureBox1.Left += 5
        End If
    End Sub

    Private Sub TimerLeft_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerLeft.Tick
        If PictureBox1.Left > 0 Then
            PictureBox1.Left -= 5
        End If
    End Sub

    Private Sub Main_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Right And pindah = True Then
            TimerRight.Start()
        End If

        If e.KeyCode = Keys.Left And pindah = True Then
            TimerLeft.Start()
        End If
    End Sub

    Private Sub Main_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        TimerRight.Stop()
        TimerLeft.Stop()
    End Sub

    Private Sub Timer_Time_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer_Time.Tick
        s += 1
        Label1.Text = s

    End Sub

    Private Sub TimerStart_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerStart.Tick
        If start > 0 Then
            start -= 1
        End If

        Label2.Text = start
        If start = 0 Then
            Timer_Time.Start()
            Timer_Hewan.Start()
            Label2.Visible = False
            pindah = True
            TimerStart.Stop()
        End If
    End Sub

    Private Sub Main_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        hewan(0) = PictureBox6
        hewan(1) = PictureBox7
        hewan(2) = PictureBox8
        hewan(3) = PictureBox9
        hewan(4) = PictureBox12
        hewan(5) = PictureBox13

        h(0) = PictureBox3
        h(1) = PictureBox4
        h(2) = PictureBox5

        For y = 0 To 5
            hewan(y).Top = -Int(Rnd() * 500)
        Next
    End Sub

    Private Sub Timer_Hewan_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer_Hewan.Tick
        Call koneksi()
        For y = 0 To 5
            hewan(y).Top += 5

            If hewan(y).Top > Me.Height Then
                hewan(y).Top = -Int(Rnd() * 500)
            ElseIf PictureBox1.Bounds.IntersectsWith(hewan(5).Bounds) Then
                hewan5()
            ElseIf PictureBox1.Bounds.IntersectsWith(hewan(4).Bounds) Then
                hewan4()
            End If
            If PictureBox1.Bounds.IntersectsWith(hewan(y).Bounds) Then
                hewan(y).Top = -Int(Rnd() * 500)
                score += 1
                Label4.Text = score
                If nyawa = 3 Then
                    Timer_Hewan.Stop()
                    Timer_Time.Stop()
                    TimerLeft.Stop()
                    TimerRight.Stop()
                    pindah = False
                    MsgBox("Game Over")
                    MsgBox("Score Anda = " & score)
                    s = 0
                    nyawa = 0

                    Dim Sqltambah As String = "INSERT INTO tbl_score(id_pemain,score)values('', '" & score & "')"
                    mySqlCommand = New MySqlCommand(Sqltambah, mySqlConn)
                    mySqlCommand.ExecuteNonQuery()
                    Peringkat.Show()
                    Me.Hide()
                End If
            End If

        Next

    End Sub

End Class
