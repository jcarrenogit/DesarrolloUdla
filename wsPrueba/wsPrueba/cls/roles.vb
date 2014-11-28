Public Class roles
    Dim _cn As New conexion
    Dim _dtU As New DataTable

    Public Sub New()

    End Sub

    Public Function ListarRoles() As DataTable
        Try
            _cn.Conectar()

            _cn._strSQL = "SELECT id_rol, descripcion FROM rol ORDER BY id_rol ASC"

            _dtU = _cn.__select()
            If _dtU.Rows.Count() > 0 Then
                Return _dtU
            Else
                Return New DataTable
            End If

        Catch ex As Exception
            Return New DataTable
        Finally
            _cn.Desconectar()
            _cn = New conexion
        End Try
    End Function

    Public Function consultar_Rol(ByVal nombre As String) As DataTable
        Try
            _cn.Conectar()

            _cn._strSQL = "SELECT id_rol, descripcion, activo FROM rol WHERE LTRIM(RTRIM(UPPER(descripcion))) = '" & nombre.ToUpper.Trim & "' ORDER BY cod_rol ASC"

            _dtU = _cn.__select()
            If _dtU.Rows.Count() > 0 Then
                Return _dtU
            Else
                Return New DataTable
            End If

        Catch ex As Exception
            Return New DataTable
        Finally
            _cn.Desconectar()
            _cn = New conexion
        End Try
    End Function

    Public Function AgregarRoles(ByVal Descripcion As String, ByVal activo As Integer) As Boolean
        Try
            _cn.Conectar()

            _cn._strSQL = "INSERT INTO rol (Descripcion, activo) VALUES "
            _cn._strSQL &= "('" & Descripcion & "', '" & activo & "')"

            _cn.__insert()

            Return True

        Catch ex As Exception
            Return False
        Finally
            _cn.Desconectar()
            _cn = New conexion
        End Try
    End Function

    Public Function ActualizarRoles(ByVal codigo As String, ByVal Descripcion As String, ByVal activo As Integer) As Boolean
        Try
            _cn.Conectar()

            _cn._strSQL = "UPDATE rol SET  Descripcion='" & Descripcion & "', activo = '" & activo & "'"
            _cn._strSQL &= " WHERE id_rol = '" & codigo & "'"
            _cn.__insert()

            Return True

        Catch ex As Exception
            Return False
        Finally
            _cn.Desconectar()
            _cn = New conexion
        End Try
    End Function

End Class
