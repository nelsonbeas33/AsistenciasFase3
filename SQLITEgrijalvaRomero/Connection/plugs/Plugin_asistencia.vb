Public Class Plugin_asistencia

    Public Shared Function RegistrarAsistencia(_ClvEmpleado As Integer) As Integer

        Dim AsistenciaEmpleado = New Asistencia With {
            .ClvEmpleado = _ClvEmpleado,
            .Fecha = DateAndTime.Now()
        }

        If AsistenciaEmpleado.InsertarAsitencia() Then
            Return 1
        Else
            If AsistenciaEmpleado.InsertarSalida() Then
                Return 2
            Else
                Return 0
            End If
        End If

        Return 0
    End Function

    Public Shared Function ContarAsistenciasDia(_fechas As String) As Integer

        Dim AsistenciasDia As List(Of Asistencia) = Asistencia.BuscarPorFecha(_fechas)
        Return AsistenciasDia.Count
    End Function

    Public Shared Function GetHorasPorEmpleado(_clvEmpleado As String) As Hashtable

        Dim Horas As Hashtable = New Hashtable()
        Dim asistencias = Asistencia.BuscarPorClv(_clvEmpleado)

        For Each asistencia As Asistencia In asistencias
            If Not Horas.ContainsKey(Format(asistencia.Fecha, "MM/dd/yyyy")) Then

                If Format(asistencia.Salida, "hh:mm:ss") <> "12:00:00" Then
                    Dim ts As TimeSpan = asistencia.Llegada - asistencia.Salida
                    Horas.Add(Format(asistencia.Fecha, "MM/dd/yyyy"), Math.Abs(ts.TotalHours).ToString())
                Else
                    Horas.Add(Format(asistencia.Fecha, "MM/dd/yyyy"), 0)
                End If

            End If
        Next asistencia

        Return Horas
    End Function

    Public Shared Function GetAsistencias() As List(Of List(Of String))

        Dim Listasistencias = New List(Of List(Of String))
        Dim asistenciaStrings = New List(Of String)
        Dim asistencias = Asistencia.GetAsistencias()

        For Each asistencia As Asistencia In asistencias
            asistenciaStrings = New List(Of String)
            asistenciaStrings.Add(asistencia.ClvEmpleado.ToString())
            asistenciaStrings.Add(asistencia.Fecha.ToShortDateString())
            asistenciaStrings.Add(Format(asistencia.Llegada, "hh:mm:ss"))
            asistenciaStrings.Add(Format(asistencia.Salida, "hh:mm:ss"))
            Listasistencias.Add(asistenciaStrings)
        Next asistencia

        Return Listasistencias
    End Function

End Class
