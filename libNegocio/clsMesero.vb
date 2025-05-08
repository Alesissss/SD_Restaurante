Imports libDatos

Public Class clsMesero
    Dim objMan As New clsMantenimiento
    Dim strSQL = ""
    Dim dtMes As New DataTable

    Public Function generarIDMesero() As Integer
        strSQL = "select isnull(max(idMesero),0)+1 from mesero"
        Try
            dtMes = objMan.listarComando(strSQL)
            If dtMes.Rows.Count > 0 Then
                Return dtMes.Rows(0).Item(0)
            End If
        Catch ex As Exception
            Throw New Exception("Error al generar el ID de Mesero!")
        End Try
        Return 0
    End Function

    Public Sub guardarMesero(id As Integer, dni As String, nom As String, ape As String, sex As String, fec As Date, dir As String, tel As String, cor As String, est As Boolean)
        strSQL = "insert into mesero values(" & id & ",'" & dni & "','" & nom & "','" & ape & "'," & IIf(sex = "Masculino", 1, 0) & ",'" & fec & "','" & dir & "','" & tel & "','" & cor & "'," & IIf(est, 1, 0) & ")"
        Try
            objMan.ejecutarComando(strSQL)
        Catch ex As Exception
            Throw New Exception("Error al registrar Mesero!")
        End Try
    End Sub

    Public Sub modificarMesero(id As Integer, dni As String, nom As String, ape As String, sex As String, fec As Date, dir As String, tel As String, cor As String, est As Boolean)
        strSQL = "update mesero set dniMesero='" & dni & "',nombres='" & nom & "',apellidos='" & ape & "',sexo=" & IIf(sex = "Masculino", 1, 0) & ",fechaNac='" & fec & "',direccion='" & dir & "',telefono='" & tel & "',correo='" & cor & "',estado=" & IIf(est, 1, 0) & " where idMesero=" & id
        Try
            objMan.ejecutarComando(strSQL)
        Catch ex As Exception
            Throw New Exception("Error al modificar Mesero!")
        End Try
    End Sub

    Public Sub eliminarMesero(id As Integer)
        strSQL = "delete from mesero where idMesero=" & id
        Try
            objMan.ejecutarComando(strSQL)
        Catch ex As Exception
            Throw New Exception("Error al eliminar Mesero!")
        End Try
    End Sub

    Public Sub darBajaMesero(id As Integer)
        strSQL = "update mesero set estado=0 where idMesero=" & id
        Try
            objMan.ejecutarComando(strSQL)
        Catch ex As Exception
            Throw New Exception("Error al dar de baja a Mesero!")
        End Try
    End Sub

    Public Function buscarMesero(id As Integer) As DataTable
        strSQL = "select * from mesero where idMesero=" & id
        Try
            Return objMan.listarComando(strSQL)
        Catch ex As Exception
            Throw New Exception("Error al buscar Mesero!")
        End Try
    End Function

    Public Function listarMesero() As DataTable
        strSQL = "select * from mesero"
        Try
            Return objMan.listarComando(strSQL)
        Catch ex As Exception
            Throw New Exception("Error al listar Mesero!")
        End Try
    End Function

End Class
