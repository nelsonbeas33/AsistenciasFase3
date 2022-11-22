Public Class Plugin_Admin

    Public Shared Function AdminLogin(_Clv As String, _Psw As String) As Boolean

        Dim admin As Admin = Admin.getAdmin(_Clv, _Psw)

        If admin.ClvEmpleado <> 0 Then
            Return True
        Else
            Return False
        End If

    End Function

End Class
