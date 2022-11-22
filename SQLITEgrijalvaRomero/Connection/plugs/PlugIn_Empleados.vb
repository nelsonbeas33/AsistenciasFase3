Public Class PlugIn_Empleados

    Public Shared Function NumeroEmpleados() As Integer
        Return Empleado.NumeroDeEmpleados()
    End Function

    Public Shared Function GetEmpleadoData(_clv As String) As Hashtable

        Dim empleadoHash = New Hashtable()
        Dim empleado As Empleado = Empleado.BuscarEmpleadoClv(_clv)

        empleadoHash.Add("ClvEmpleado", empleado.ClvEmpleado)
        empleadoHash.Add("Nombre", empleado.Nombre)
        empleadoHash.Add("ApellidoPaterno", empleado.ApellidoPaterno)
        empleadoHash.Add("ApellidoMaterno", empleado.ApellidoMaterno)
        empleadoHash.Add("Direccion", empleado.Direccion)
        empleadoHash.Add("Cargo", empleado.Cargo)
        empleadoHash.Add("Rfc", empleado.Rfc)
        empleadoHash.Add("Curp", empleado.Curp)
        empleadoHash.Add("Telefono", empleado.Telefono)
        empleadoHash.Add("HorasSemana", empleado.HorasSemana)

        Return empleadoHash
    End Function

    Public Shared Function ExisteEmpleado(_clv As String) As Boolean
        Return Not Empleado.BuscarEmpleadoClv(_clv).ClvEmpleado = 0
    End Function

    Public Shared Function EliminarEmpleado(_clv As String) As Boolean
        Return Empleado.BorrarEmpleado(_clv)
    End Function

    Public Shared Function EditarEmpleado(EmpledoData As Hashtable) As Boolean

        Dim EmpleadoEditado As Empleado = New Empleado()

        EmpleadoEditado.Cargo = EmpledoData("Cargo").ToString()
        EmpleadoEditado.Nombre = EmpledoData("Nombre").ToString()
        EmpleadoEditado.ApellidoMaterno = EmpledoData("ApellidoMaterno").ToString()
        EmpleadoEditado.ApellidoPaterno = EmpledoData("ApellidoPaterno").ToString()
        EmpleadoEditado.Telefono = EmpledoData("Telefono").ToString()
        EmpleadoEditado.Curp = EmpledoData("Curp").ToString()
        EmpleadoEditado.Rfc = EmpledoData("Rfc").ToString()
        EmpleadoEditado.Direccion = EmpledoData("Direccion").ToString()

        Try
            EmpleadoEditado.HorasSemana = Convert.ToInt64(EmpledoData("HorasSemana"))
            EmpleadoEditado.ClvEmpleado = Convert.ToInt64(EmpledoData("ClvEmpleado"))
        Catch ex As Exception
            Return False
        End Try

        Return EmpleadoEditado.EditarEmpleado()
    End Function

    Public Shared Function AgregarEmpleado(EmpledoData As Hashtable) As Boolean

        Dim EmpleadoNuevo As Empleado = New Empleado()

        EmpleadoNuevo.Cargo = EmpledoData("Cargo").ToString()
        EmpleadoNuevo.Nombre = EmpledoData("Nombre").ToString()
        EmpleadoNuevo.ApellidoMaterno = EmpledoData("ApellidoMaterno").ToString()
        EmpleadoNuevo.ApellidoPaterno = EmpledoData("ApellidoPaterno").ToString()
        EmpleadoNuevo.Telefono = EmpledoData("Telefono").ToString()
        EmpleadoNuevo.Curp = EmpledoData("Curp").ToString()
        EmpleadoNuevo.Rfc = EmpledoData("Rfc").ToString()
        EmpleadoNuevo.Direccion = EmpledoData("Direccion").ToString()

        Try
            EmpleadoNuevo.HorasSemana = Convert.ToInt64(EmpledoData("HorasSemana"))
            EmpleadoNuevo.ClvEmpleado = Convert.ToInt64(EmpledoData("ClvEmpleado"))
        Catch ex As Exception
            Return False
        End Try

        Return EmpleadoNuevo.InsertarEmpleado()
    End Function

    Public Shared Function GetEmpleados() As List(Of List(Of String))

        Dim Listasempleados = New List(Of List(Of String))
        Dim empleadosStrings = New List(Of String)
        Dim empleados = Empleado.GetEmpleados()

        For Each empleado As Empleado In empleados
            empleadosStrings = New List(Of String)
            empleadosStrings.Add(empleado.ClvEmpleado.ToString())
            empleadosStrings.Add(empleado.Nombre)
            empleadosStrings.Add(empleado.ApellidoPaterno)
            empleadosStrings.Add(empleado.ApellidoMaterno)
            empleadosStrings.Add(empleado.Direccion)
            empleadosStrings.Add(empleado.Cargo)
            empleadosStrings.Add(empleado.Rfc)
            empleadosStrings.Add(empleado.Curp)
            empleadosStrings.Add(empleado.Telefono)
            empleadosStrings.Add(empleado.HorasSemana.ToString())

            Listasempleados.Add(empleadosStrings)
        Next empleado

        Return Listasempleados
    End Function
End Class
