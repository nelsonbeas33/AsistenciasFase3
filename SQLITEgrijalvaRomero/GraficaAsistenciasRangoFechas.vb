Public Class GraficaAsistenciasRangoFechas

    Public Fecha1 As String
    Public Fecha2 As String

    Private Sub GraficaAsistenciasRangoFechas_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim asistencias As List(Of Asistencia) = Asistencia.BuscarPorRangoFecha(Fecha1, Fecha2)
        Dim FechasOrdenadas As List(Of Fecha_Valor) = New List(Of Fecha_Valor)()

        For Each asistencia As Asistencia In asistencias

            Dim founded = False
            For Each fechaordenada As Fecha_Valor In FechasOrdenadas
                If fechaordenada.Fecha = asistencia.Fecha Then
                    fechaordenada.Valor += 1
                    founded = True
                End If
            Next fechaordenada

            If Not founded Then
                Dim nuevaFecha = New Fecha_Valor With {.Fecha = asistencia.Fecha, .Valor = 1}
                FechasOrdenadas.Add(nuevaFecha)
            End If
        Next asistencia

        FechasOrdenadas.Sort(Function(x, y) (DateTime.Compare(x.Fecha, y.Fecha) < 0))


        For Each item As Fecha_Valor In FechasOrdenadas
            Chart1.Series.ElementAt(0).Points.AddXY(item.Fecha, item.Valor)
        Next item

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        FolderBrowserDialog1.ShowDialog()
        Dim path As String = FolderBrowserDialog1.SelectedPath()
        FormToImg.Export(Me, path + "\AsistenciaSemana.jpg")
    End Sub
End Class

Public Class Fecha_Valor
    Public Fecha As DateTime
    Public Valor As Integer = 0
End Class