Public Class GraficaAsistenciaEmpleado

    Public ClvEmpleado As String

    Private Sub GraficaAsistenciaEmpleado_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Chart1.Series.Clear()
        Chart1.Series.Add("Horas trabajadas")
        Dim horas As Hashtable = Plugin_asistencia.GetHorasPorEmpleado(ClvEmpleado)

        For Each item As DictionaryEntry In horas
            Chart1.Series.ElementAt(0).Points.AddXY(item.Key, item.Value)
        Next

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        FolderBrowserDialog1.ShowDialog()
        Dim path As String = FolderBrowserDialog1.SelectedPath()
        FormToImg.Export(Me, path + "\AsistenciaEmpleado.jpg")
    End Sub
End Class