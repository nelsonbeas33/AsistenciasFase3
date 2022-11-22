Imports System.Runtime.InteropServices

Public Class Login
#Region "Form Behaviors"
    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Application.Exit()
    End Sub

    Private Sub btnMinimize_Click(sender As Object, e As EventArgs) Handles btnMinimize.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub
#End Region
#Region "Drag Form"
    <DllImport("user32.DLL", EntryPoint:="ReleaseCapture")>
    Private Shared Sub ReleaseCapture()
    End Sub
    <DllImport("user32.DLL", EntryPoint:="SendMessage")>
    Private Shared Sub SendMessage(hWnd As IntPtr, wMsg As Integer, wParam As Integer, lParam As Integer)
    End Sub

    Private Sub titleBar_MouseMove(sender As Object, e As MouseEventArgs) Handles titleBar.MouseMove
        ReleaseCapture()
        SendMessage(Me.Handle, &H112&, &HF012&, 0)
    End Sub

#End Region
#Region "Customize Controls"
    Private Sub CustomizeComponents()
        'txtUsuario
        txtUsuario.AutoSize = False
        txtUsuario.Size = New Size(350, 25)
        'txtContraseña
        txtPassword.AutoSize = False
        txtPassword.Size = New Size(350, 25)
        txtPassword.UseSystemPasswordChar = True
    End Sub
    Private Sub btnLogin_Paint(sender As Object, e As PaintEventArgs) Handles btnLogin.Paint
        Dim buttonPath As Drawing2D.GraphicsPath = New Drawing2D.GraphicsPath()
        Dim myRectangle As Rectangle = btnLogin.ClientRectangle
        myRectangle.Inflate(0, 30)
        buttonPath.AddEllipse(myRectangle)
        btnLogin.Region = New Region(buttonPath)
    End Sub

#End Region
    Public Sub New()
        InitializeComponent()
        CustomizeComponents()
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click

        If Plugin_Admin.AdminLogin(txtUsuario.Text, txtPassword.Text) Then
            Dim mainMenu As MainMenu = New MainMenu()
            mainMenu.Show()
            Me.Visible = False
        Else
            txtUsuario.BackColor = Color.LightYellow
            txtPassword.BackColor = Color.LightYellow
        End If

    End Sub

    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtUsuario.Width = 290
        txtUsuario.Height = 19

        txtPassword.Width = 290
        txtPassword.Height = 19
    End Sub
End Class
