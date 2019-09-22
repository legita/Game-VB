Imports MySql.Data.MySqlClient
Imports System.Data.SqlClient
Imports System.Data

Public Class Telor
    Dim kanan, atas As Boolean
    Dim skor As Integer = 0
    Dim nyawa As Integer = 3
    Dim start As Integer = 5

    Private Sub Timer_Start_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer_Start.Tick
        If start > 0 Then
            start -= 1
        End If

        Label5.Text = start
        If start = 0 Then
            Timer1.Start()
            TimerMuncul.Start()
            Label5.Visible = False
            Timer_Start.Stop()
        End If
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Label2.Text = skor
        Label4.Text = nyawa

        If kanan = True Then
            PictureBox8.Left += 20 'kekanan
        Else
            PictureBox8.Left -= 20 'kekiri
        End If

        If atas = True Then
            PictureBox8.Top += 20 'kebawah
        Else
            PictureBox8.Top -= 20 'keatas
        End If

        'kekanan
        If PictureBox8.Left <= Me.ClientRectangle.Left Then
            kanan = True
        End If

        'kekiri
        If PictureBox8.Left + PictureBox8.Width >= Me.ClientRectangle.Right Then
            kanan = False
        End If

        'kebawah
        If PictureBox8.Top <= Me.ClientRectangle.Top Then
            atas = True
        End If

        'keatas
        If PictureBox8.Top + PictureBox8.Height >= Me.ClientRectangle.Bottom Then
            atas = False
            nyawa = nyawa - 1
            Label4.Text = nyawa
            PictureBox8.Left = RectangleShape1.Left + 8
            PictureBox8.Top = RectangleShape1.Top - PictureBox8.Height
            Timer1.Enabled = False
            If nyawa = 0 Then
                MsgBox("Game Over.!")
                nyawa = 3
                skor = 0
            End If
        End If

        'kebalok
        If PictureBox8.Left >= (RectangleShape1.Left - PictureBox8.Width) And
        PictureBox8.Left <= (RectangleShape1.Left + RectangleShape1.Width) And
        PictureBox8.Top = RectangleShape1.Top - PictureBox8.Height Then
            If Timer1.Enabled = True Then
                atas = False
                skor = skor + 1
                Label2.Text = skor
                Timer1.Enabled = False
            End If
            PictureBox9.Visible = True
        End If

    End Sub

    Private Sub Form1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Z Then
            Timer1.Enabled = True
            If RectangleShape1.Left <= Me.ClientRectangle.Left Then
                RectangleShape1.Left = 0
            Else
                RectangleShape1.Left -= 10
            End If
        End If

        If e.KeyCode = Keys.X Then
            Timer1.Enabled = True

            If RectangleShape1.Left + RectangleShape1.Width >= Me.ClientRectangle.Right Then
                RectangleShape1.Left = (Me.ClientRectangle.Right - RectangleShape1.Width)
            Else
                RectangleShape1.Left += 10
            End If
        End If
    End Sub

    Private Sub TimerMuncul_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerMuncul.Tick
        Label2.Text = skor
        Label4.Text = nyawa

        If kanan = True Then
            PictureBox9.Left += 18 'kekanan
        Else
            PictureBox9.Left -= 18 'kekiri
        End If

        If atas = True Then
            PictureBox9.Top += 26 'kebawah
        Else
            PictureBox9.Top -= 26 'keatas
        End If

        'kekanan
        If PictureBox9.Left <= Me.ClientRectangle.Left Then
            kanan = True
        End If

        'kekiri
        If PictureBox9.Left + PictureBox9.Width >= Me.ClientRectangle.Right Then
            kanan = False
        End If

        'kebawah
        If PictureBox9.Top <= Me.ClientRectangle.Top Then
            atas = True
        End If

        'keatas
        If PictureBox9.Top + PictureBox9.Height >= Me.ClientRectangle.Bottom Then
            atas = False
            nyawa = nyawa - 1
            Label4.Text = nyawa
            PictureBox9.Left = RectangleShape1.Left + 8
            PictureBox9.Top = RectangleShape1.Top - PictureBox8.Height
            Timer1.Enabled = False
            If nyawa = 0 Then
                MsgBox("Game Over.!")
                nyawa = 3
                skor = 0
            End If
        End If

        'kebalok
        If PictureBox9.Left >= (RectangleShape1.Left - PictureBox9.Width) And
        PictureBox9.Left <= (RectangleShape1.Left + RectangleShape1.Width) And
        PictureBox9.Top = RectangleShape1.Top - PictureBox9.Height Then
            If Timer1.Enabled = True Then
                atas = False
                skor = skor + 1
                Label2.Text = skor
                PictureBox1.Visible = True
                Timer1.Enabled = False
            End If
        End If
    End Sub

    Private Sub PictureBox9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox9.Click

    End Sub
End Class

