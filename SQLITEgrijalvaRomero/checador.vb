Public Class checador

    Dim showAnimation As Boolean = New Boolean()
    Dim animationTime As UShort = 0
    Dim Estado As Integer = 0

    Private Sub checador_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Start()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        Label1.Text = Format(TimeOfDay, "hh:mm:ss")
        Label2.Text = Format(TimeOfDay, "tt")
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        TextBox1.Text += "1"
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        TextBox1.Text += "2"
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        TextBox1.Text += "3"
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        TextBox1.Text += "4"

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        TextBox1.Text += "5"

    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        TextBox1.Text += "6"

    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        TextBox1.Text += "7"

    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        TextBox1.Text += "8"

    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        TextBox1.Text += "9"

    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        TextBox1.Text += "0"

    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        TextBox1.Text = ""

    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click

        If TextBox1.Text = "" Then
            TextBox1.BackColor = Color.White
        End If

        If IsNumeric(TextBox1.Text) Then
            Dim state As Integer = Plugin_asistencia.RegistrarAsistencia(Convert.ToInt64(TextBox1.Text))
            If state = 1 Then
                TextBox1.BackColor = Color.Green
                showAnimation = True
                Label3.Text = "Entrada registrada"
                Timer2.Start()
            Else
                If state = 2 Then
                    TextBox1.BackColor = Color.Green
                    showAnimation = True
                    Label3.Text = "Salida registrada"
                    Timer2.Start()
                Else
                    TextBox1.BackColor = Color.Red
                End If
            End If

        Else
            TextBox1.BackColor = Color.Red
        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

        If TextBox1.Text = "" Or IsNumeric(TextBox1.Text) Then
            TextBox1.BackColor = Color.White
            Return
        End If
        If Not IsNumeric(TextBox1.Text) Then TextBox1.BackColor = Color.Red
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        If showAnimation Then
            If animationTime < 45 Then
                animationTime += 1
                If animationTime > 5 Then
                    Panel2.BringToFront()
                End If
            Else
                showAnimation = False
                animationTime = 0
                Panel2.SendToBack()
                Timer2.Stop()
                TextBox1.Text = ""
            End If
        End If
    End Sub


End Class