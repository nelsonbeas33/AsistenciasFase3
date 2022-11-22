Public Class GraficaPastelAsistenciasDiaria

    Public fecha As String

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        FolderBrowserDialog1.ShowDialog()
        Dim path As String = FolderBrowserDialog1.SelectedPath()
        FormToImg.Export(Me, path + "\AsistenciasDia.jpg")
    End Sub

    Private Sub GraficaPastelAsistenciasDiaria_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim NumeroAsistencias As Integer = Plugin_asistencia.ContarAsistenciasDia(fecha)
        Dim NumeroEmpleados As Integer = PlugIn_Empleados.NumeroEmpleados()

        Dim Faltas As Integer = NumeroEmpleados - NumeroAsistencias

        If NumeroAsistencias <> 0 Then
            Chart1.Series.ElementAt(0).Points.AddXY("Asistencias: " + NumeroAsistencias.ToString(), NumeroAsistencias)
        End If

        If Faltas <> 0 Then
            Chart1.Series.ElementAt(0).Points.AddXY("Faltas: " + Faltas.ToString(), Faltas)
        End If

        Dim Porcentaje As Decimal = (Convert.ToDecimal(NumeroAsistencias) * 100.0) / Convert.ToDecimal(NumeroEmpleados)
        Label1.Text = "Asistió un " + FormatNumber(Porcentaje, 2) + "% De los empleados registrados"
        Label2.Text += Format(DateTime.Now(), "MM/dd/yyyy")

    End Sub
End Class