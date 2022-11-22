Imports Finisar.SQLite

Public Class Admin

    Public Id As Integer
    Public Password As String
    Public ClvEmpleado As Integer

    Public Shared Function getAdmin(_ClvEmpleado As String, _Psw As String) As Admin

        Dim objcommand As SQLiteCommand
        Dim objReader As SQLiteDataReader
        Dim admin As Admin

        Try
            DB.objConn.Open()

            objcommand = DB.objConn.CreateCommand()
            objcommand.CommandText = "SELECT * FROM Admin 
            WHERE ClvEmpleado = " + _ClvEmpleado.ToString() + " AND Password = '" + _Psw + "'"
            objReader = objcommand.ExecuteReader()
            admin = New Admin()
            If (Not objReader.Read()) Then
                Return admin
            End If

            admin.Id = objReader("Id")
            admin.ClvEmpleado = objReader("ClvEmpleado")
            admin.Password = objReader("Password")
        Finally
            DB.objConn.Close()
        End Try

        Return admin
    End Function

End Class
