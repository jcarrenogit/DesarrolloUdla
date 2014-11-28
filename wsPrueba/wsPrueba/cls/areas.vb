
Public Class areas
    Dim _cn As New conexion
    Dim _dtU As New DataTable

    Public Sub New()

    End Sub

    Public Function ListarAreas() As DataTable
        Try
            _cn.Conectar()


            _cn._strSQL = "SELECT id_area, descripcion FROM area ORDER BY id_area ASC"
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

    Public Function consultar_area(ByVal area As String) As DataTable
        Try
            _cn.Conectar()

            _cn._strSQL = "SELECT id_area, descripcion, id_usuario_jefe FROM area WHERE descripcion = '" & area & "' ORDER BY id_area ASC"
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

    Public Function AgregarAreas(ByVal Descripcion As String, _
                                 ByVal usuario_jefe As Integer) As Boolean
        Try
            _cn.Conectar()

            _cn._strSQL = "INSERT INTO area (Descripcion, id_usuario_jefe) VALUES "
            _cn._strSQL &= "('" & Descripcion & "', '" & usuario_jefe & "')"

            _cn.__insert()

            Return True

        Catch ex As Exception
            Return False
        Finally
            _cn.Desconectar()
            _cn = New conexion
        End Try
    End Function

    Public Function ActualizarAreas(ByVal codigo As String, ByVal Descripcion As String, _
                                 ByVal usuario_jefe As String) As Boolean
        Try
            _cn.Conectar()

            _cn._strSQL = "UPDATE area SET Descripcion = '" & Descripcion & "', id_usuario_jefe = '" & usuario_jefe & "' "
            _cn._strSQL &= " WHERE id_area = '" & codigo & "'"

            _cn.__update()

            Return True

        Catch ex As Exception
            Return False
        Finally
            _cn.Desconectar()
            _cn = New conexion
        End Try
    End Function

End Class
