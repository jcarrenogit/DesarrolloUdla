Imports wsPrueba.Clases

Partial Public Class frmRol
    Inherits System.Web.UI.Page

    Private _area As New areas
    Private _cargo As New cargos
    Private _roles As New roles
    Private _user As New usuario

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim dtRoles As New DataTable
            dtRoles = _roles.ListarRoles()

            dgvRol.DataSource = dtRoles
            dgvRol.DataBind()
        End If
    End Sub

    Protected Sub txtRol_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtRol.TextChanged
        Try
            Dim dtU As New DataTable
            dtU = _roles.consultar_Rol(txtRol.Text)

            notificacion.Visible = False

            If dtU.Rows.Count > 0 Then
                'Usuario Existe, despliego datos donde corresponde (controles ocultos)
                'username, email, nombre, cod_area, cod_cargo, estado, fecha_creacion, fecha_modificacion, cod_rol
                frmUser.Visible = True

                hCodigo.Value = dtU.Rows(0)(0).ToString

                Dim cEstado As Integer = IIf(dtU.Rows(0)(2).ToString = "", 0, CDbl(dtU.Rows(0)(2)))
                cmbEstado.SelectedValue = cEstado
                cmbEstado.Enabled = False

                txtRol.Enabled = False
                btnModificar.Visible = True
                btnGuardar.Visible = False
                hCrea.Value = True

            Else
                'Usuario Existe, despliego datos donde corresponde (controles ocultos)
                'username, email, nombre, cod_area, cod_cargo, estado, fecha_creacion, fecha_modificacion, cod_rol
                frmUser.Visible = True
                cmbEstado.Enabled = True
                txtRol.Enabled = True

                cmbEstado.SelectedValue = 1
                btnGuardar.Visible = True

            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnVolver_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnVolver.Click
        Try
            Response.Redirect("land.aspx")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Try
            If hCrea.Value = False Then
                If _roles.ActualizarRoles(hCodigo.Value, txtRol.Text, cmbEstado.SelectedValue) = True Then

                    notificacion.InnerHtml = "<br /><br />Registro Actualizado correctamente."
                    notificacion.Visible = True

                    hCrea.Value = True
                End If
            Else
                If _roles.AgregarRoles(txtRol.Text, cmbEstado.SelectedValue) = True Then

                    notificacion.InnerHtml = "<br /><br />Registro Ingresado correctamente."
                    notificacion.Visible = True

                End If
            End If

            dgvRol.DataSource = _roles.ListarRoles()
            dgvRol.DataBind()

            frmUser.Visible = False
        Catch ex As Exception
            notificacion.InnerText = "Error: " & ex.Message
        End Try
    End Sub

    Protected Sub btnModificar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnModificar.Click
        Try
            cmbEstado.Enabled = False
            txtRol.Enabled = True
            btnGuardar.Visible = True
            btnModificar.Visible = False
        Catch ex As Exception

        End Try
    End Sub
End Class