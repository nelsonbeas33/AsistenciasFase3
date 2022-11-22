Public Class MainMenu
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        PanelVacio.Show()
        PanelRegistrar.Hide()
        PanelEditar.Hide()
        PanelEliminar.Hide()
        PanelEmpleados.Hide()
        PanelAsistencias.Hide()
        PanelAsistenciasDia.Hide()
        PanelAsistenciasEmpleado.Hide()

    End Sub


    Private Sub BtnRegistrar_Click_1(sender As Object, e As EventArgs) Handles BtnRegistrar.Click
        PanelRegistrar.Show()
        PanelVacio.Hide()
        PanelEditar.Hide()
        PanelEliminar.Hide()
        PanelEmpleados.Hide()
        PanelAsistencias.Hide()
        PanelAsistenciasDia.Hide()
        PanelAsistenciasEmpleado.Hide()

    End Sub

    Private Sub BtnEditar_Click(sender As Object, e As EventArgs) Handles BtnEditar.Click
        PanelEditar.Show()
        PanelRegistrar.Hide()
        PanelVacio.Hide()
        PanelEliminar.Hide()
        PanelEmpleados.Hide()
        PanelAsistencias.Hide()
        PanelAsistenciasDia.Hide()
        PanelAsistenciasEmpleado.Hide()

    End Sub

    Private Sub BtnEliminar_Click(sender As Object, e As EventArgs) Handles BtnEliminar.Click
        PanelEliminar.Show()
        PanelEditar.Hide()
        PanelRegistrar.Hide()
        PanelVacio.Hide()
        PanelEmpleados.Hide()
        PanelAsistencias.Hide()
        PanelAsistenciasDia.Hide()
        PanelAsistenciasEmpleado.Hide()

    End Sub

    Private Sub BtnListAsis_Click(sender As Object, e As EventArgs) Handles BtnListAsis.Click
        PanelAsistencias.Show()
        PanelEliminar.Hide()
        PanelEditar.Hide()
        PanelRegistrar.Hide()
        PanelVacio.Hide()
        PanelEmpleados.Hide()
        PanelAsistenciasDia.Hide()
        PanelAsistenciasEmpleado.Hide()

        DataGridView1.Rows.Clear()

        Dim asistencias = Plugin_asistencia.GetAsistencias()

        For Each asistencia As List(Of String) In asistencias
            Try
                DataGridView1.Rows.Add(asistencia(0), asistencia(1), asistencia(2), asistencia(3))

            Catch ex As Exception
            End Try
        Next asistencia

    End Sub

    Private Sub BtnListEmp_Click(sender As Object, e As EventArgs) Handles BtnListEmp.Click
        PanelEmpleados.Show()
        PanelAsistencias.Hide()
        PanelEliminar.Hide()
        PanelEditar.Hide()
        PanelRegistrar.Hide()
        PanelVacio.Hide()
        PanelAsistenciasDia.Hide()
        PanelAsistenciasEmpleado.Hide()

        Dim Empleados = PlugIn_Empleados.GetEmpleados()

        DataGridView2.Rows.Clear()
        For Each empleado As List(Of String) In Empleados
            Try
                DataGridView2.Rows.Add(
                    empleado(0),
                    empleado(1),
                    empleado(2),
                    empleado(3),
                    empleado(4),
                    empleado(5),
                    empleado(6),
                    empleado(7),
                    empleado(8),
                    empleado(9))
            Catch ex As Exception

            End Try

        Next empleado

    End Sub


    Private Sub BtnAsisSem_Click(sender As Object, e As EventArgs) Handles BtnAsisDia.Click

        PanelAsistenciasDia.Show()
        PanelAsistencias.Hide()
        PanelEliminar.Hide()
        PanelEditar.Hide()
        PanelRegistrar.Hide()
        PanelVacio.Hide()
        PanelEmpleados.Hide()
        PanelAsistenciasEmpleado.Hide()



    End Sub


    Private Sub BtnAsisEmp_Click(sender As Object, e As EventArgs) Handles BtnAsisEmp.Click

        PanelAsistenciasEmpleado.Show()
        PanelAsistenciasDia.Hide()
        PanelAsistencias.Hide()
        PanelEliminar.Hide()
        PanelEditar.Hide()
        PanelRegistrar.Hide()
        PanelVacio.Hide()
        PanelEmpleados.Hide()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles EliminarButtonLimpiar.Click
        ElminarCleanTextboxs()
    End Sub

    Private Sub EliminarButtonBuscar_Click(sender As Object, e As EventArgs) Handles EliminarButtonBuscar.Click


        If EliminarTextboxClv.Text <> "" Then

            If IsNumeric(EliminarTextboxClv.Text) And PlugIn_Empleados.ExisteEmpleado(EliminarTextboxClv.Text) Then
                Dim data = PlugIn_Empleados.GetEmpleadoData(EliminarTextboxClv.Text)

                EliminarTextboxCargo.Text = data("Cargo").ToString()
                EliminarTextboxHoras.Text = data("HorasSemana").ToString()
                EliminarTextboxNombre.Text = data("Nombre").ToString()
                EliminarTextboxApellidoMaterno.Text = data("ApellidoMaterno").ToString()
                EliminarTextboxApellidoPaterno.Text = data("ApellidoPaterno").ToString()
                EliminarTextboxTelefono.Text = data("Telefono").ToString()
                EliminarTextboxCurp.Text = data("Curp").ToString()
                EliminarTextboxrfc.Text = data("Rfc").ToString()
                EliminarTextboxDireccion.Text = data("Direccion").ToString()
            End If
        Else
            ElminarCleanTextboxs()
        End If

    End Sub

    Private Sub EliminarButtonEliminar_Click(sender As Object, e As EventArgs) Handles EliminarButtonEliminar.Click
        PlugIn_Empleados.EliminarEmpleado(EliminarTextboxClv.Text)
        ElminarCleanTextboxs()
    End Sub

    Private Sub ElminarCleanTextboxs()

        EliminarTextboxClv.Clear()
        EliminarTextboxCargo.Clear()
        EliminarTextboxHoras.Clear()
        EliminarTextboxNombre.Clear()
        EliminarTextboxApellidoMaterno.Clear()
        EliminarTextboxApellidoPaterno.Clear()
        EliminarTextboxTelefono.Clear()
        EliminarTextboxCurp.Clear()
        EliminarTextboxrfc.Clear()
        EliminarTextboxDireccion.Clear()

    End Sub

    Private Sub EditarCleanTextboxs()

        EditarTextBoxClv.Clear()
        EditarTextBoxCargo.Clear()
        EditarTextBoxHoras.Clear()
        EditarTextBoxNombre.Clear()
        EditarTextBoxApellidoMaterno.Clear()
        EditarTextBoxApellidoPaterno.Clear()
        EditarTextBoxTelefono.Clear()
        EditarTextBoxCurp.Clear()
        EditarTextBoxrfc.Clear()
        EditarTextBoxDireccion.Clear()

    End Sub

    Private Sub AgregarCleanTextboxs()

        AgregarTextBoxClv.Clear()
        AgregarTextBoxCargo.Clear()
        AgregarTextBoxHoras.Clear()
        AgregarTextBoxNombre.Clear()
        AgregarTextBoxApellidoMaterno.Clear()
        AgregarTextBoxApellidoPaterno.Clear()
        AgregarTextBoxTelefono.Clear()
        AgregarTextBoxCurp.Clear()
        AgregarTextBoxrfc.Clear()
        AgregarTextBoxDireccion.Clear()

    End Sub

    Private Sub EditarButtonBuscar_Click(sender As Object, e As EventArgs) Handles EditarButtonBuscar.Click

        If EditarTextBoxClv.Text <> "" Then

            If IsNumeric(EditarTextBoxClv.Text) And PlugIn_Empleados.ExisteEmpleado(EditarTextBoxClv.Text) Then
                Dim data = PlugIn_Empleados.GetEmpleadoData(EditarTextBoxClv.Text)

                EditarTextBoxCargo.Text = data("Cargo").ToString()
                EditarTextBoxHoras.Text = data("HorasSemana").ToString()
                EditarTextBoxNombre.Text = data("Nombre").ToString()
                EditarTextBoxApellidoMaterno.Text = data("ApellidoMaterno").ToString()
                EditarTextBoxApellidoPaterno.Text = data("ApellidoPaterno").ToString()
                EditarTextBoxTelefono.Text = data("Telefono").ToString()
                EditarTextBoxCurp.Text = data("Curp").ToString()
                EditarTextBoxrfc.Text = data("Rfc").ToString()
                EditarTextBoxDireccion.Text = data("Direccion").ToString()

            End If
        Else
            EditarCleanTextboxs()
        End If

    End Sub

    Private Sub EditarButtonEditar_Click(sender As Object, e As EventArgs) Handles EditarButtonEditar.Click

        Dim data = New Hashtable()

        data.Add("ClvEmpleado", EditarTextBoxClv.Text)
        data.Add("Nombre", EditarTextBoxNombre.Text)
        data.Add("ApellidoPaterno", EditarTextBoxApellidoMaterno.Text)
        data.Add("ApellidoMaterno", EditarTextBoxApellidoPaterno.Text)
        data.Add("Direccion", EditarTextBoxDireccion.Text)
        data.Add("Cargo", EditarTextBoxCargo.Text)
        data.Add("Rfc", EditarTextBoxrfc.Text)
        data.Add("Curp", EditarTextBoxCurp.Text)
        data.Add("Telefono", EditarTextBoxTelefono.Text)
        data.Add("HorasSemana", EditarTextBoxHoras.Text)

        PlugIn_Empleados.EditarEmpleado(data)
        EditarCleanTextboxs()
    End Sub

    Private Sub EditarButtonLimpiar_Click(sender As Object, e As EventArgs) Handles EditarButtonLimpiar.Click
        EditarCleanTextboxs()
    End Sub

    Private Sub AgregarButtonBuscar_Click(sender As Object, e As EventArgs) Handles AgregarButtonBuscar.Click

        If AgregarTextBoxClv.Text <> "" Then

            If IsNumeric(AgregarTextBoxClv.Text) And PlugIn_Empleados.ExisteEmpleado(AgregarTextBoxClv.Text) Then
                Dim data = PlugIn_Empleados.GetEmpleadoData(AgregarTextBoxClv.Text)

                AgregarTextBoxCargo.Text = data("Cargo").ToString()
                AgregarTextBoxHoras.Text = data("HorasSemana").ToString()
                AgregarTextBoxNombre.Text = data("Nombre").ToString()
                AgregarTextBoxApellidoMaterno.Text = data("ApellidoMaterno").ToString()
                AgregarTextBoxApellidoPaterno.Text = data("ApellidoPaterno").ToString()
                AgregarTextBoxTelefono.Text = data("Telefono").ToString()
                AgregarTextBoxCurp.Text = data("Curp").ToString()
                AgregarTextBoxrfc.Text = data("Rfc").ToString()
                AgregarTextBoxDireccion.Text = data("Direccion").ToString()
            End If
        Else
            AgregarCleanTextboxs()
        End If
    End Sub

    Private Sub AgregarButtonLimpiar_Click(sender As Object, e As EventArgs) Handles AgregarButtonLimpiar.Click
        AgregarCleanTextboxs()
    End Sub

    Private Sub AgregarButtonAgregar_Click(sender As Object, e As EventArgs) Handles AgregarButtonAgregar.Click
        Dim data = New Hashtable()

        data.Add("ClvEmpleado", AgregarTextBoxClv.Text)
        data.Add("Nombre", AgregarTextBoxNombre.Text)
        data.Add("ApellidoPaterno", AgregarTextBoxApellidoMaterno.Text)
        data.Add("ApellidoMaterno", AgregarTextBoxApellidoPaterno.Text)
        data.Add("Direccion", AgregarTextBoxDireccion.Text)
        data.Add("Cargo", AgregarTextBoxCargo.Text)
        data.Add("Rfc", AgregarTextBoxrfc.Text)
        data.Add("Curp", AgregarTextBoxCurp.Text)
        data.Add("Telefono", AgregarTextBoxTelefono.Text)
        data.Add("HorasSemana", AgregarTextBoxHoras.Text)

        PlugIn_Empleados.AgregarEmpleado(data)
        AgregarCleanTextboxs()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim grafica = New GraficaPastelAsistenciasDiaria()
        grafica.fecha = Format(DateTimePicker1.Value, "MM/dd/yyyy")
        MsgBox(grafica.fecha)
        grafica.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Try
            FolderBrowserDialog1.ShowDialog()
            Dim path As String = FolderBrowserDialog1.SelectedPath()
            Plugin_Export.ExportEmpleados(path)
        Catch ex As Exception
        End Try

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            FolderBrowserDialog1.ShowDialog()
            Dim path As String = FolderBrowserDialog1.SelectedPath()
            Plugin_Export.ExportAsitencias(path)
        Catch ex As Exception
        End Try
    End Sub


    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        If PanelAsistenciasEmpleadoTextbox.Text <> "" And IsNumeric(PanelAsistenciasEmpleadoTextbox.Text) Then
            Dim grafica As GraficaAsistenciaEmpleado = New GraficaAsistenciaEmpleado()
            grafica.ClvEmpleado = PanelAsistenciasEmpleadoTextbox.Text
            grafica.Show()
        End If
    End Sub


    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim grafica As GraficaAsistenciasRangoFechas = New GraficaAsistenciasRangoFechas()

        If DateTime.Compare(DateTimePicker2.Value, DateTimePicker3.Value) <= 0 Then
            grafica.Fecha1 = Format(DateTimePicker2.Value, "MM/dd/yyyy")
            grafica.Fecha2 = Format(DateTimePicker3.Value, "MM/dd/yyyy")
            grafica.Show()
        End If
    End Sub

End Class
