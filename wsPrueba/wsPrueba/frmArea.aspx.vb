Imports wsPrueba.Clases


Partial Public Class frmArea
    Inherits System.Web.UI.Page

    Dim _user As New usuario
    Dim _area As New areas

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Try
                Dim dtUsers As New DataTable
                dtUsers = _user.listar_usuario_jefe
                If dtUsers.Rows.Count > 0 Then
                    cmbUsuario.DataSource = dtUsers
                    cmbUsuario.DataValueField = "usr_id"
                    cmbUsuario.DataTextField = "Nombre"
                    cmbUsuario.DataBind()

                Else
                    cmbUsuario.Items.Add("No existen usuarios")
                End If
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub txtArea_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtArea.TextChanged
        Try
            Dim dtU As New DataTable
            dtU = _area.consultar_area(txtArea.Text)

            notificacion.Visible = False

            If dtU.Rows.Count > 0 Then
                'Usuario Existe, despliego datos donde corresponde (controles ocultos)
                'username, email, nombre, cod_area, cod_cargo, estado, fecha_creacion, fecha_modificacion, cod_rol
                frmUser.Visible = True
                
                Dim cUJefe As String
                cUJefe = IIf(dtU.Rows(0)(2).ToString.Trim = "", "", dtU.Rows(0)(2).ToString.Trim)
                Try
                    cmbUsuario.Enabled = True
                    cmbUsuario.SelectedValue = cUJefe
                    cmbUsuario.Enabled = False
                Catch ex As Exception
                    cmbUsuario.SelectedIndex = -1
                End Try

                hCodigo.Value = dtU.Rows(0)(0)

                cmbUsuario.Enabled = False
                btnGuardar.Visible = False
                btnModificar.Visible = True
                hCrea.Value = False
            Else
                'Usuario Existe, despliego datos donde corresponde (controles ocultos)
                'username, email, nombre, cod_area, cod_cargo, estado, fecha_creacion, fecha_modificacion, cod_rol
                frmUser.Visible = True
                cmbUsuario.SelectedIndex = -1
                
                btnGuardar.Visible = True
                btnModificar.Visible = False
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Try
            If hCrea.Value = False Then
                If _area.ActualizarAreas(hCodigo.Value, txtArea.Text, cmbUsuario.SelectedValue) = True Then

                    notificacion.InnerHtml = "<br /><br />Registro Actualizado correctamente."
                    notificacion.Visible = True

                    hCrea.Value = True
                End If
            Else
                If _area.AgregarAreas(txtArea.Text, cmbUsuario.SelectedValue) = True Then

                    notificacion.InnerHtml = "<br /><br />Registro Ingresado correctamente."
                    notificacion.Visible = True

                End If
            End If
            frmUser.Visible = False
        Catch ex As Exception
            notificacion.InnerText = "Error: " & ex.Message
        End Try
    End Sub

    Private Sub btnModificar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnModificar.Click
        Try
            cmbUsuario.Enabled = True

            btnGuardar.Visible = True
            btnModificar.Visible = False
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnVolver_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnVolver.Click
        Try
            Response.Redirect("land.aspx")
        Catch ex As Exception

        End Try
    End Sub

    Public Sub cmbUsuario_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbUsuario.SelectedIndexChanged

    End Sub

End Class