Public Partial Class frcargos
    Inherits System.Web.UI.Page

    Private _cargo As New cargos

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnGuardar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnGuardar.Click
        Try
            If txtCodigo.Text <> "" Then
                'aCTUALIZACION
                If _cargo.ActualizarCargo(txtCodigo.Text, txtDescripcion.Text) = True Then
                    txtCodigo.Text = ""
                    txtDescripcion.Text = ""
                    divNotificacion.InnerText = "Registro Actualizado correctamente."
                End If
            Else
                'iNSERCION
                If _cargo.AgregarCargos(txtCodigo.Text, txtDescripcion.Text) = True Then
                    txtCodigo.Text = ""
                    txtDescripcion.Text = ""
                    divNotificacion.InnerText = "Registro Ingresado correctamente."
                End If
            End If
            SQCargos.SelectCommand = "SELECT id_cargo, descripcion FROM cargos"
            SQCargos.DataBind()
        Catch ex As Exception
            divNotificacion.InnerText = "Error al actualizar/ingresar." & ex.Message
        End Try
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Try
            Response.Redirect("land.aspx", False)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgCargos_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvCargos.SelectedIndexChanged
        Try

            Dim idx = dgvCargos.SelectedIndex
            txtCodigo.Text = dgvCargos.Rows(idx).Cells(1).Text
            txtDescripcion.Text = dgvCargos.Rows(idx).Cells(2).Text

        Catch ex As Exception

        End Try
    End Sub
End Class