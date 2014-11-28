Imports wsPrueba.Clases

Partial Public Class frmCargo
    Inherits System.Web.UI.Page

    Private _area As New areas
    Private _cargo As New cargos
    Private _roles As New roles
    Private _user As New usuario
    Private _func As New funcionalidad


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub txtCargo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCargo.TextChanged
        Try
            Dim dtU As New DataTable
            dtU = _cargo.consultar_cargo(txtCargo.Text)

            notificacion.Visible = False

            If dtU.Rows.Count > 0 Then
                'Usuario Existe, despliego datos donde corresponde (controles ocultos)
                'username, email, nombre, cod_area, cod_cargo, estado, fecha_creacion, fecha_modificacion, cod_rol
                frmUser.Visible = True

                hCodigo.Value = dtU.Rows(0)(0)

                btnModificar.Visible = True
                btnGuardar.Visible = False
                txtCargo.Enabled = False
                hCrea.Value = False
            Else
                'No Existe, despliego datos donde corresponde (controles ocultos)
                'username, email, nombre, cod_area, cod_cargo, estado, fecha_creacion, fecha_modificacion, cod_rol
                frmUser.Visible = True

                btnGuardar.Visible = True

            End If

        Catch ex As Exception

        End Try
    End Sub


    Private Sub btnGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Try
            If hCrea.Value = False Then
                If _cargo.ActualizarCargo(hCodigo.Value, txtCargo.Text) = True Then

                    notificacion.InnerHtml = "<br /><br />Cargo Actualizado correctamente."
                    notificacion.Visible = True

                    hCrea.Value = True
                End If
            Else
                If _cargo.AgregarCargos(txtCargo.Text) = True Then

                    notificacion.InnerHtml = "<br /><br />CargoIngresado correctamente."
                    notificacion.Visible = True

                End If
            End If
            frmUser.Visible = False
        Catch ex As Exception
            notificacion.InnerText = "Error: " & ex.Message
        End Try
    End Sub

    Protected Sub btnModificar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnModificar.Click
        Try
            hCrea.Value = False
            btnModificar.Visible = False

            btnGuardar.Visible = True

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnVolver_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnVolver.Click
        Try
            Response.Redirect("land.aspx")
        Catch ex As Exception

        End Try
    End Sub
End Class