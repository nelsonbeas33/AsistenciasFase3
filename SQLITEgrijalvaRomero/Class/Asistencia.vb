Imports Finisar.SQLite

Public Class Asistencia

    Dim Id As Integer
    Public Fecha As DateTime
    Public Llegada As DateTime
    Public Salida As DateTime
    Public ClvEmpleado As Integer

    Public Sub Inicializar(
        _Fecha As DateTime,
        _Llegada As DateTime,
        _Salida As DateTime,
        _ClvEmpleado As Integer)

        Fecha = _Fecha
        Llegada = _Llegada
        Salida = _Salida
        ClvEmpleado = _ClvEmpleado
    End Sub

    Public Function InsertarAsitencia() As Boolean

        Try
            Dim AsistenciaBuscada = BuscarAsistencia(ClvEmpleado, Format(Fecha, "MM/dd/yyyy"))
            Dim EmpleadoBuscado = Empleado.BuscarEmpleadoClv(ClvEmpleado)
            Dim ComandText As String
            DB.objConn.Open()

            If AsistenciaBuscada.ClvEmpleado = 0 And EmpleadoBuscado.ClvEmpleado <> 0 Then
                ComandText = "INSERT INTO Asistencia (Fecha, Llegada, ClvEmpleado) VALUES ("
                ComandText += "'" + Format(Date.Today(), "MM/dd/yyyy") + "',"
                ComandText += "'" + Format(DateTime.Now(), "hh:mm:ss") + "',"
                ComandText += ClvEmpleado.ToString()
                ComandText += ");"
                DB.WriteTextFile(ComandText)
                Dim Query As New SQLiteCommand(ComandText, DB.objConn)
                Query.ExecuteNonQuery()

                Return True
                DB.objConn.Close()
            End If
        Finally
            DB.objConn.Close()
        End Try


        Return False
    End Function

    Public Shared Function BorrarAsistencia(_ClvEmpleado As Integer, _Fecha As String) As Boolean

        Try
            DB.objConn.Open()

            Dim ComandText As String

            ComandText = "DELETE FROM Asistencia WHERE ClvEmpleado = " + _ClvEmpleado.ToString + " AND Fecha = '" + _Fecha + "'"
            Dim Query As New SQLiteCommand(ComandText, DB.objConn)
            MsgBox(ComandText)
            Query.ExecuteNonQuery()

        Finally
            DB.objConn.Close()
        End Try

        Return True
    End Function

    Public Function InsertarSalida() As Boolean

        Try

            Dim ComandText As String
            Dim AsistenciaBuscada As Asistencia = BuscarAsistencia(ClvEmpleado, Format(Fecha, "MM/dd/yyyy"))
            DB.objConn.Open()

            If AsistenciaBuscada.ClvEmpleado <> 0 And Format(AsistenciaBuscada.Salida, "MM/dd/yyyy") = "01/01/0001" Then
                ComandText = "update Asistencia set Salida = '" + Format(DateTime.Now(), "hh:mm:ss") + "' WHERE ClvEmpleado = " + ClvEmpleado.ToString() + " AND Fecha = '" + Format(Fecha, "MM/dd/yyyy") + "'"
                DB.WriteTextFile(ComandText)
                Dim Query As New SQLiteCommand(ComandText, DB.objConn)
                Query.ExecuteNonQuery()
                Return True
            End If
        Finally
            DB.objConn.Close()
        End Try



        Return False
    End Function

    Public Shared Function BuscarAsistencia(_ClvEmpleado As String, _Fecha As String) As Asistencia
        Dim objcommand As SQLiteCommand
        Dim objReader As SQLiteDataReader
        Dim AsistenciaTMp As Asistencia


        Try
            DB.objConn.Open()

            objcommand = DB.objConn.CreateCommand()
            objcommand.CommandText = "SELECT * FROM Asistencia 
            WHERE ClvEmpleado = " + _ClvEmpleado.ToString() + " AND Fecha = '" + _Fecha + "'"
            objReader = objcommand.ExecuteReader()
            AsistenciaTMp = New Asistencia()
            If (Not objReader.Read()) Then
                Return AsistenciaTMp
            End If

            AsistenciaTMp.Id = objReader("Id")
            AsistenciaTMp.ClvEmpleado = objReader("ClvEmpleado")

            AsistenciaTMp.Fecha = transform.ToDate(objReader("Fecha"))
            AsistenciaTMp.Llegada = DateTime.Parse(objReader("Llegada"))

            If (objReader("Salida") <> "") Then
                AsistenciaTMp.Salida = DateTime.Parse(objReader("Salida"))
            End If
        Finally
            DB.objConn.Close()
        End Try

        Return AsistenciaTMp

    End Function

    Public Shared Function BuscarPorClv(_ClvEmpleado As String) As List(Of Asistencia)

        Dim Asistencias As List(Of Asistencia) = New List(Of Asistencia)()

        Try
            DB.objConn.Open()

            Dim objcommand As SQLiteCommand
            Dim objReader As SQLiteDataReader

            Dim AsistenciaTmp As Asistencia = New Asistencia()

            objcommand = DB.objConn.CreateCommand()
            objcommand.CommandText = "SELECT * FROM Asistencia WHERE ClvEmpleado = " + _ClvEmpleado
            objReader = objcommand.ExecuteReader()

            While (objReader.Read())

                AsistenciaTmp = New Asistencia()

                AsistenciaTmp.Id = objReader("Id")
                AsistenciaTmp.ClvEmpleado = objReader("ClvEmpleado")
                AsistenciaTmp.Fecha = transform.ToDate(objReader("Fecha"))
                AsistenciaTmp.Llegada = Convert.ToDateTime(objReader("Llegada"))

                If (objReader("Salida") <> "") Then
                    AsistenciaTmp.Salida = Convert.ToDateTime(objReader("Salida"))
                Else
                    AsistenciaTmp.Salida = New DateTime()
                End If

                Asistencias.Add(AsistenciaTmp)
            End While

        Finally
            DB.objConn.Close()
        End Try

        Return Asistencias

    End Function

    Public Shared Function BuscarPorFecha(_fecha As String) As List(Of Asistencia)

        Dim Asistencias As List(Of Asistencia) = New List(Of Asistencia)()

        Try
            DB.objConn.Open()

            Dim objcommand As SQLiteCommand
            Dim objReader As SQLiteDataReader

            Dim AsistenciaTmp As Asistencia = New Asistencia()

            objcommand = DB.objConn.CreateCommand()
            objcommand.CommandText = "SELECT * FROM Asistencia WHERE Fecha = '" + _fecha + "'"
            DB.WriteTextFile(objcommand.CommandText)
            objReader = objcommand.ExecuteReader()

            While (objReader.Read())

                AsistenciaTmp = New Asistencia()

                AsistenciaTmp.Id = objReader("Id")
                AsistenciaTmp.ClvEmpleado = objReader("ClvEmpleado")
                AsistenciaTmp.Fecha = transform.ToDate(objReader("Fecha"))
                AsistenciaTmp.Llegada = Convert.ToDateTime(objReader("Llegada"))

                If (objReader("Salida") <> "") Then
                    AsistenciaTmp.Salida = Convert.ToDateTime(objReader("Salida"))
                Else
                    AsistenciaTmp.Salida = New DateTime()
                End If

                Asistencias.Add(AsistenciaTmp)
            End While
        Finally
            DB.objConn.Close()
        End Try

        Return Asistencias

    End Function

    Public Shared Function BuscarPorRangoFecha(_fecha1 As String, _fecha2 As String) As List(Of Asistencia)

        Dim AsistenciasFiltradas As List(Of Asistencia) = New List(Of Asistencia)()

        Try
            DB.objConn.Open()

            Dim objcommand As SQLiteCommand
            Dim objReader As SQLiteDataReader

            Dim AsistenciaTmp As Asistencia = New Asistencia()
            Dim Asistencias As List(Of Asistencia) = New List(Of Asistencia)()

            objcommand = DB.objConn.CreateCommand()
            objcommand.CommandText = "SELECT * FROM Asistencia"
            DB.WriteTextFile(objcommand.CommandText)
            objReader = objcommand.ExecuteReader()

            While (objReader.Read())

                AsistenciaTmp = New Asistencia()

                AsistenciaTmp.Id = objReader("Id")
                AsistenciaTmp.ClvEmpleado = objReader("ClvEmpleado")
                AsistenciaTmp.Fecha = transform.ToDate(objReader("Fecha"))
                AsistenciaTmp.Llegada = Convert.ToDateTime(objReader("Llegada"))

                If (objReader("Salida") <> "") Then
                    AsistenciaTmp.Salida = Convert.ToDateTime(objReader("Salida"))
                Else
                    AsistenciaTmp.Salida = New DateTime()
                End If

                Asistencias.Add(AsistenciaTmp)
            End While


            Dim Fechatmp1 As DateTime = transform.ToDate(_fecha1)
            Dim Fechatmp2 As DateTime = transform.ToDate(_fecha2)
            Dim CorrectFormat As Int16 = DateTime.Compare(Fechatmp1, Fechatmp2)

            If CorrectFormat <= 0 Then
                For Each temporal As Asistencia In Asistencias
                    Dim daysEarly As Int16 = DateTime.Compare(temporal.Fecha, Fechatmp1)
                    Dim daysLate As Int16 = DateTime.Compare(temporal.Fecha, Fechatmp2)

                    If daysEarly >= 0 And daysLate <= 0 Then
                        AsistenciasFiltradas.Add(temporal)
                    End If

                Next temporal
            End If

        Finally
            DB.objConn.Close()
        End Try

        Return AsistenciasFiltradas

    End Function

    Public Shared Function GetAsistencias() As List(Of Asistencia)

        Dim Asistencias As List(Of Asistencia) = New List(Of Asistencia)()

        Try
            DB.objConn.Open()

            Dim objcommand As SQLiteCommand
            Dim objReader As SQLiteDataReader

            Dim AsistenciaTmp As Asistencia = New Asistencia()

            objcommand = DB.objConn.CreateCommand()
            objcommand.CommandText = "SELECT * FROM Asistencia"
            DB.WriteTextFile(objcommand.CommandText)
            objReader = objcommand.ExecuteReader()

            While (objReader.Read())

                AsistenciaTmp = New Asistencia()

                AsistenciaTmp.Id = objReader("Id")
                AsistenciaTmp.ClvEmpleado = objReader("ClvEmpleado")
                AsistenciaTmp.Fecha = transform.ToDate(objReader("Fecha"))
                AsistenciaTmp.Llegada = Convert.ToDateTime(objReader("Llegada"))

                If (objReader("Salida") <> "") Then
                    AsistenciaTmp.Salida = Convert.ToDateTime(objReader("Salida"))
                Else
                    AsistenciaTmp.Salida = New DateTime()
                End If

                Asistencias.Add(AsistenciaTmp)
            End While
        Finally
            DB.objConn.Close()
        End Try

        Return Asistencias
    End Function

End Class
