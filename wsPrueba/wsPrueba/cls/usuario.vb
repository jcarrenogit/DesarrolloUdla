
Namespace Clases

    Public Class usuario

        Dim _cn As New conexion
        Dim _dtU As New DataTable

        Public Sub New()

        End Sub

        Public Function uLogin(ByVal usr As String, ByVal pwd As String) As DataTable
            Try
                _cn.Conectar()

                'Limpiar Injection
                usr = UCase(usr).Replace("SELECT", "").Replace("DROP", "").Replace("--", "").Replace("EXEC", "").Replace("1=1", "")
                pwd = UCase(pwd).Replace("SELECT", "").Replace("DROP", "").Replace("--", "").Replace("EXEC", "").Replace("1=1", "")

                _cn._strSQL = "SELECT * FROM usuario WHERE UPPER([Username]) = '" & usr & "' AND UPPER([Password]) = '" & pwd & "'"
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

        Public Function ListarUsuario() As DataTable
            Try
                _cn.Conectar()

                _cn._strSQL = "SELECT * FROM usuario ORDER BY [UserName] ASC"

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

        Public Function ListarUsuario(ByVal IdU As Integer) As String
            Try
                _cn.Conectar()

                _cn._strSQL = "SELECT nombre FROM usuario WHERE usr_id = " & IdU

                _dtU = _cn.__select()
                If _dtU.Rows.Count() > 0 Then
                    Return _dtU.Rows(0)(0)
                Else
                    Return ""
                End If

            Catch ex As Exception
                Return ""
            Finally
                _cn.Desconectar()
                _cn = New conexion
            End Try
        End Function

        Public Function listar_usuario_jefe() As DataTable
            Try
                _cn.Conectar()

                _cn._strSQL = "SELECT usr_id, nombre FROM usuario WHERE username <> 'groot' ORDER BY [Nombre] ASC"

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

        Public Function UsuarioDisponible(ByVal usr As String) As Boolean
            Try
                _cn.Conectar()

                _cn._strSQL = "SELECT * FROM usuario WHERE UPPER([UserName]) = '" & usr.ToUpper & "'"

                _dtU = _cn.__select()
                If _dtU.Rows.Count() > 0 Then
                    Return False
                Else
                    Return True
                End If

            Catch ex As Exception
                Return False
            Finally
                _cn.Desconectar()
                _cn = New conexion
            End Try
        End Function

        Public Function consulta_usuario(ByVal usr As String) As DataTable
            Try
                _cn.Conectar()

                _cn._strSQL = "SELECT username, email, nombre, cod_area, cod_cargo, estado, fecha_creacion, fecha_modificacion, cod_rol "
                _cn._strSQL &= " FROM usuario WHERE UPPER([UserName]) = '" & usr.ToUpper & "'"

                _dtU = _cn.__select()
                If _dtU.Rows.Count() > 0 Then
                    Return _dtU
                Else
                    Return New DataTable
                End If

            Catch ex As Exception
                Return Nothing
            Finally
                _cn.Desconectar()
                _cn = New conexion
            End Try
        End Function

        Public Function AgregarUsuario(ByVal login As String, ByVal email As String, ByVal pass As String, _
                                      ByVal nombre As String, ByVal cod_area As String, ByVal cod_cargo As String, _
                                      ByVal estado As String, ByVal cod_rol As String) As Boolean
            Try
                _cn.Conectar()

                _cn._strSQL = "INSERT INTO usuario (Username, Email, Password, Nombre, Cod_area, Cod_cargo, Estado, Cod_rol) VALUES "
                _cn._strSQL &= "('" & Login & "', '" & email & "', '" & pass & "', '" & nombre & "', '" & cod_area & "', '" & cod_cargo & "', '" & estado & "', '" & cod_rol & "') "

                _cn.__insert()

                Return True

            Catch ex As Exception
                Return False
            Finally
                _cn.Desconectar()
                _cn = New conexion
            End Try
        End Function

        Public Function ActualizarUsuario(ByVal login As String, ByVal email As String, ByVal pass As String, _
                                      ByVal nombre As String, ByVal cod_area As String, ByVal cod_cargo As String, _
                                      ByVal estado As String, ByVal cod_rol As String) As Boolean
            Try
                _cn.Conectar()

                _cn._strSQL = "UPDATE usuario SET Email='" & email & "', Nombre= '" & nombre & "', "
                If pass <> "" Then
                    _cn._strSQL &= " Password = '" & pass & "', "
                End If
                _cn._strSQL &= " Cod_area = '" & cod_area & "', Cod_cargo='" & cod_cargo & "', Estado='" & estado & "', Cod_rol='" & cod_rol & "', fecha_modificacion = GETDATE() "
                _cn._strSQL &= " WHERE username = '" & login & "'"

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
