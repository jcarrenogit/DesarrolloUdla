
Public Class solicitud

    Dim _cn As New conexion
    Dim _dtU As New DataTable

    Public Sub New()

    End Sub

    Public Function ListarSolicitudGrilla() As DataTable
        Try
            _cn.Conectar()

            _cn._strSQL = " SELECT a.id_solicitud, a.id_servicio, a.id_usuario, a.Estado, a.Detalle_Solicitud, "
            _cn._strSQL &= " a.Detalle_Rechazo, a.Fecha_creacion, a.Fecha_modificacion, "
            _cn._strSQL &= " c.Nombre as nUsuario, b.Nombre as nServicio"
            _cn._strSQL &= " FROM Solicitud a"
            _cn._strSQL &= "    INNER JOIN Servicio b ON a.id_servicio = b.id_servicio"
            _cn._strSQL &= "    INNER JOIN usuario c on a.id_usuario = c.usr_id"

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

    Public Function consultar_solicitud(ByVal Solicitud As Integer) As DataTable
        Try
            _cn.Conectar()

            '_cn._strSQL = "SELECT  Nombre, Descripcion, Funcionalidad, Cod_Area, Estado 
            'Nombre, Descripcion, Estado, id_area, id_usurio_ult_modif, 
            'fecha_creacion, fecha_modificacion
            _cn._strSQL = " SELECT [id_solicitud], [id_servicio], [id_usuario], [Estado], "
            _cn._strSQL &= " [Detalle_Solicitud], [Detalle_Rechazo], [Fecha_creacion], [Fecha_modificacion] "
            _cn._strSQL = " FROM [cat_servicios].[dbo].[Solicitud]"
            _cn._strSQL = " WHERE id_solicitud = " & solicitud

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

    Public Function AgregarSolicitud(ByVal idservicio As Integer, ByVal idusuariosol As Integer, ByVal estado As Integer, _
                                    ByVal detallesol As String, Optional ByVal detallerech As String = "") As Boolean
        Try
            _cn.Conectar()

            _cn._strSQL = " INSERT INTO Solicitud ([id_servicio], [id_usuario], [Estado], [Detalle_Solicitud], "
            _cn._strSQL &= " [Detalle_Rechazo], [Fecha_creacion], [Fecha_modificacion]) VALUES "
            _cn._strSQL &= " ('" & idservicio & "', '" & idusuariosol & "', '" & estado & "', "
            _cn._strSQL &= " '" & detallesol & "', '" & detallerech & "', "
            _cn._strSQL &= " GETDATE(), GETDATE()) "

            _cn.__insert()

            Return True

        Catch ex As Exception
            Return False
        Finally
            _cn.Desconectar()
            _cn = New conexion
        End Try
    End Function

    Public Function ActualizarSolicitud(ByVal idsolicitud As Integer, ByVal idservicio As Integer, ByVal idusuariosol As Integer, ByVal estado As Integer, _
                                    ByVal detallesol As String, ByVal detallerech As String) As Boolean
        Try
            _cn.Conectar()

            _cn._strSQL = " UPDATE Solicitud SET id_servicio = " & idservicio & ", "
            _cn._strSQL &= " [id_usuario] = " & idusuariosol & ","
            _cn._strSQL &= " [Estado] = " & estado & ", "
            _cn._strSQL &= " [Detalle_Solicitud] = '" & detallesol & "', "
            _cn._strSQL &= " [Detalle_Rechazo] = '" & detallerech & "', "
            _cn._strSQL &= " [Fecha_modificacion] = GETDATE(), "
            _cn._strSQL &= " WHERE id_servicio = " & idsolicitud

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
