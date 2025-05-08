Imports libDatos
Public Class clsUsuario
    Dim objMan As New clsMantenimiento
    Dim strSQL As String = ""
    Dim dtUsuario As New DataTable

    Public Function iniciarSesion(usu As String, con As String) As Boolean
        strSQL = "select * from usuario where nombre='" & usu & "' and contrasena='" & con & "'"
        Try
            dtUsuario = objMan.listarComando(strSQL)
            If dtUsuario.Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Throw New Exception("Error al ejecutar consulta!")
        End Try
    End Function

    Public Function obtenerPreguntaSec(usu As String) As String
        strSQL = "select preguntasecreta from usuario where nombre='" & usu & "'"
        Try
            dtUsuario = objMan.listarComando(strSQL)
            If dtUsuario.Rows.Count > 0 Then
                Return dtUsuario.Rows(0).Item(0)
            Else
                Return "USUARIO no existe!"
            End If
        Catch ex As Exception
            Throw New Exception("Error al ejecutar consulta!")
        End Try
    End Function

    Public Function validarRespuestaPregSec(usu As String, rpta As String) As Boolean
        strSQL = "select * from usuario where nombre='" & usu & "' and respuesta='" & rpta & "'"
        Try
            dtUsuario = objMan.listarComando(strSQL)
            If dtUsuario.Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Throw New Exception("Error al ejecutar consulta!")
        End Try
    End Function

    Public Function obtenerNombreUsuario(usu As String) As String
        strSQL = "select nombresCompletos from usuario where nombre='" & usu & "'"
        Try
            dtUsuario = objMan.listarComando(strSQL)
            If dtUsuario.Rows.Count > 0 Then
                Return dtUsuario.Rows(0).Item(0)
            Else
                Return "USUARIO no existe!"
            End If
        Catch ex As Exception
            Throw New Exception("Error al ejecutar consulta!")
        End Try
    End Function
End Class


