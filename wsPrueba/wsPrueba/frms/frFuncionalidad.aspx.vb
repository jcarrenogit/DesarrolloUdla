Public Partial Class frFuncionalidad
    Inherits System.Web.UI.Page

    Private _funcionalidad As New wsPrueba.funcionalidad

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub dgvdgvFuncionalidad_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvFuncionalidad.SelectedIndexChanged
        Try
            Dim idx = dgvFuncionalidad.SelectedIndex
            txtCodigo.Text = dgvFuncionalidad.Rows(idx).Cells(1).Text
            txtDescripcion.Text = dgvFuncionalidad.Rows(idx).Cells(2).Text

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnGuardar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnGuardar.Click
        Try
            If txtCodigo.Text <> "" Then
                If _funcionalidad.ActualizarFuncionalidad(txtCodigo.Text, txtDescripcion.Text, ) = True Then
                    txtCodigo.Text = ""
                    txtDescripcion.Text = ""

                    divNotificacion.InnerText = "Registro Actualizado correctamente."
                End If
            Else
                If _funcionalidad.AgregarFuncionalidad(txtCodigo.Text, txtDescripcion.Text) = True Then
                    txtCodigo.Text = ""
                    txtDescripcion.Text = ""

                    divNotificacion.InnerText = "Registro Ingresado correctamente."

                End If
            End If
            SQFuncionalidad.SelectCommand = "SELECT * FROM  Funcionalidades"
            SQFuncionalidad.DataBind()

        Catch ex As Exception
            divNotificacion.InnerText = "Error: " & ex.Message
        End Try

    End Sub

    Private Sub btnCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Try
            Response.Redirect("land.aspx", False)
        Catch ex As Exception

        End Try
    End Sub
End Class