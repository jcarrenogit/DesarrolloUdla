Public Class cargos
    Dim _cn As New conexion
    Dim _dtU As New DataTable

    Public Sub New()

    End Sub

    Public Function ListarCargos() As DataTable
        Try
            _cn.Conectar()

            _cn._strSQL = "SELECT id_cargo, descripcion FROM cargo ORDER BY id_cargo ASC"

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

    Public Function consultar_cargo(ByVal cargo As String) As DataTable
        Try
            _cn.Conectar()

            _cn._strSQL = "SELECT id_cargo, descripcion FROM cargo WHERE descripcion = '" & cargo & "' ORDER BY id_cargo ASC"

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

    Public Function AgregarCargos(ByVal Descripcion As String) As Boolean
        Try
            _cn.Conectar()

            _cn._strSQL = "INSERT INTO cargo (Descripcion) VALUES "
            _cn._strSQL &= "('" & Descripcion & "')"

            _cn.__insert()

            Return True

        Catch ex As Exception
            Return False
        Finally
            _cn.Desconectar()
            _cn = New conexion
        End Try
    End Function

    Public Function ActualizarCargo(ByVal codigo As String, ByVal Descripcion As String) As Boolean
        Try
            _cn.Conectar()

            _cn._strSQL = "UPDATE cargo SET Descripcion = '" & Descripcion & "' "
            _cn._strSQL &= " WHERE id_cargo = '" & codigo & "'"

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
