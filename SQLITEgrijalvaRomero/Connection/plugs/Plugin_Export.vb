Public Class Plugin_Export

    Public Shared Sub ExportEmpleados(path As String)
        excel.WriteEmpleadosCSV(path + "\empleados.csv", Empleado.GetEmpleados(), ",")
    End Sub

    Public Shared Sub ExportAsitencias(path As String)
        excel.WriteAsistenciasCSV(path + "\asistencias.csv", Asistencia.GetAsistencias(), ",")
    End Sub
End Class
