
Public Class funcionalidad
    Dim _cn As New conexion
    Dim _dtU As New DataTable

    Public Sub New()

    End Sub

    Public Function ListarFuncionalidad() As DataTable
        Try
            _cn.Conectar()


            _cn._strSQL = "SELECT id_funcionalidad, descripcion_funcionalidad FROM funcionalidad ORDER BY cod_funcionalidad ASC"
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

    Public Function consultar_funcionlidad(ByVal funcionalidad As String) As DataTable
        Try
            _cn.Conectar()


            _cn._strSQL = "SELECT id_funcionalidad, descripcion_funcionalidad FROM funcionalidad WHERE descripcion_funcionalidad = '" & funcionalidad & "' ORDER BY cod_funcionalidad ASC"
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

    Public Function AgregarFuncionalidad(ByVal Descripcion As String) As Boolean
        Try
            _cn.Conectar()

            _cn._strSQL = "INSERT INTO funcionalidad (Descripcion_Funcionalidad) VALUES "
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

    Public Function ActualizarFuncionalidad(ByVal codigo As String, ByVal Descripcion As String) As Boolean
        Try
            _cn.Conectar()

            _cn._strSQL = "UPDATE funcionalidad SET Descripcion = '" & Descripcion & "' "
            _cn._strSQL &= " WHERE id_funcionalidad = '" & codigo & "'"

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
