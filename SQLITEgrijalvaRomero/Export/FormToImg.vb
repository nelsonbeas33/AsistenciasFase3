Public Class FormToImg

    Public Shared Sub Export(_form As GraficaPastelAsistenciasDiaria, _path As String)

        _form.Button1.Hide()
        _form.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None

        Dim gfx As Graphics = _form.CreateGraphics()
        Dim bmp As Bitmap = New Bitmap(_form.Width, _form.Height, gfx)

        _form.DrawToBitmap(bmp, New Rectangle(0, 0, _form.Width, _form.Height))

        Try
            bmp.Save(_path)
        Catch ex As Exception

        End Try

        _form.Button1.Show()
        _form.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle

    End Sub

    Public Shared Sub Export(_form As GraficaAsistenciasRangoFechas, _path As String)

        _form.Button1.Hide()
        _form.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None

        Dim gfx As Graphics = _form.CreateGraphics()
        Dim bmp As Bitmap = New Bitmap(_form.Width, _form.Height, gfx)

        _form.DrawToBitmap(bmp, New Rectangle(0, 0, _form.Width, _form.Height))
        Try
            bmp.Save(_path)
        Catch ex As Exception

        End Try
        _form.Button1.Show()
        _form.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle

    End Sub

    Public Shared Sub Export(_form As GraficaAsistenciaEmpleado, _path As String)

        _form.Button1.Hide()
        _form.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None

        Dim gfx As Graphics = _form.CreateGraphics()
        Dim bmp As Bitmap = New Bitmap(_form.Width, _form.Height, gfx)

        _form.DrawToBitmap(bmp, New Rectangle(0, 0, _form.Width, _form.Height))
        Try
            bmp.Save(_path)
        Catch ex As Exception

        End Try
        _form.Button1.Show()
        _form.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle

    End Sub

    Public Shared Sub Export(_form As System.Windows.Forms.DataVisualization.Charting.Chart, _path As String)


        Dim gfx As Graphics = _form.CreateGraphics()
        Dim bmp As Bitmap = New Bitmap(_form.Width, _form.Height, gfx)

        _form.DrawToBitmap(bmp, New Rectangle(0, 0, _form.Width, _form.Height))
        Try
            bmp.Save(_path)
        Catch ex As Exception

        End Try
    End Sub

End Class
