Namespace Clases

    Public Class Servicios

        Dim _cn As New conexion
        Dim _dtU As New DataTable

        Public Sub New()

        End Sub

        Public Function ListarServicios() As DataTable
            Try
                _cn.Conectar()

                _cn._strSQL = "SELECT  Nombre, Descripcion, Estado, id_area, id_usuario_ult_modif, fecha_creacion, fecha_modificacion, id_usr, id_servicio FROM Servicio ORDER BY [Nombre] ASC"

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

        Public Function ListarServiciosGrilla() As DataTable
            Try
                _cn.Conectar()

                _cn._strSQL = "SELECT  "
                _cn._strSQL &= " a.id_servicio, a.Nombre, a.Descripcion, (CASE a.Estado WHEN 1 THEN 'Activo' WHEN 2 THEN 'Inactivo' END) AS Estado, a.id_usr, a.id_area, "
                _cn._strSQL &= " a.id_usuario_ult_modif, a.fecha_creacion, a.fecha_modificacion, c.Nombre as usuario_modif, "
                _cn._strSQL &= " b.Descripcion as area, d.nombre as Responsable"
                _cn._strSQL &= " FROM Servicio a"
                _cn._strSQL &= " INNER JOIN Area b ON a.id_area = b.id_area"
                _cn._strSQL &= " INNER JOIN usuario c on a.id_usuario_ult_modif = c.usr_id"
                _cn._strSQL &= " INNER JOIN usuario d on a.id_usr = d.usr_id"
                _cn._strSQL &= " ORDER BY a.Nombre ASC"

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

        Public Function BuscarSolicitudes(ByVal idServicio As Integer) As ArrayList
            Try
                _cn.Conectar()

                _cn._strSQL = " SELECT * FROM solicitud WHERE id_servicio = " & idServicio

                _dtU = _cn.__select()
                If _dtU.Rows.Count() > 0 Then
                    Dim ing, apr, rech, publ As Integer
                    ing = 0
                    apr = 0
                    rech = 0
                    publ = 0
                    For Each dRow As DataRow In _dtU.Rows
                        'Solicitud Activa

                        Select Case dRow(3)
                            Case 1
                                ing = ing + 1
                            Case 2
                                apr = apr + 1
                            Case 3
                                rech = rech + 1
                            Case 4
                                publ = publ + 1
                        End Select
                    Next

                    Dim result As New ArrayList
                    result.Add(ing)
                    result.Add(apr)
                    result.Add(rech)
                    result.Add(publ)

                    Return result
                Else
                    Return New ArrayList
                End If

            Catch ex As Exception
                Return New ArrayList
            Finally
                _cn.Desconectar()
                _cn = New conexion
            End Try
        End Function

        Public Function consultar_servicio(ByVal servicio As String) As DataTable
            Try
                _cn.Conectar()

                '_cn._strSQL = "SELECT  Nombre, Descripcion, Funcionalidad, Cod_Area, Estado 
                'Nombre, Descripcion, Estado, id_area, id_usurio_ult_modif, 
                'fecha_creacion, fecha_modificacion
                _cn._strSQL = "SELECT [Nombre],[Descripcion],[id_area],[Estado],[id_servicio],[id_usuario_ult_modif],[fecha_creacion],[fecha_modificacion],id_usr "
                _cn._strSQL &= " FROM Servicio WHERE nombre = '" & servicio & "' ORDER BY [Nombre] ASC"

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

        Public Function AgregarServicio(ByVal Nombre As String, _
                                        ByVal Descripcion As String, ByVal Estado As Integer, _
                                        ByVal UsResp As Integer, ByVal Cod_Area As Integer, _
                                        ByVal usuario_mod As Integer) As Boolean
            Try
                _cn.Conectar()

                _cn._strSQL = "INSERT INTO Servicio ([Nombre], [Descripcion], [Estado], [id_usr], [id_area], [id_usuario_ult_modif], [fecha_creacion], [fecha_modificacion]) VALUES "
                _cn._strSQL &= "('" & Nombre & "', '" & Descripcion & "', '" & Estado & "', '" & UsResp & "', '" & Cod_Area & "', '" & usuario_mod & "', GETDATE(), GETDATE()) "

                _cn.__insert()

                Return True

            Catch ex As Exception
                Return False
            Finally
                _cn.Desconectar()
                _cn = New conexion
            End Try
        End Function

        Public Function ActualizarServicio(ByVal idServicio As Integer, ByVal Nombre As String, _
                                           ByVal Descripcion As String, ByVal Estado As Integer, _
                                           ByVal UsResp As Integer, ByVal Cod_Area As Integer, _
                                           ByVal usuario_mod As Integer, ByVal fecha_creacion As Date) As Boolean
            Try
                _cn.Conectar()

                _cn._strSQL = " UPDATE Servicio"
                _cn._strSQL &= " SET Nombre = '" & Nombre & "', "
                _cn._strSQL &= " [Descripcion] = '" & Descripcion & "', "
                _cn._strSQL &= " [Estado] = '" & Estado & "', "
                _cn._strSQL &= " [id_usr] = '" & UsResp & "', "
                _cn._strSQL &= " [id_area] = '" & Cod_Area & "', "
                _cn._strSQL &= " [id_usuario_ult_modif] = '" & usuario_mod & "', "
                _cn._strSQL &= " [fecha_creacion] = '" & fecha_creacion & "', "
                _cn._strSQL &= " [fecha_modificacion] = GETDATE() "
                _cn._strSQL &= " WHERE id_servicio = " & idServicio

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

End Namespace
