Public Partial Class frRoles
    Inherits System.Web.UI.Page
    Private _roles As New roles

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Protected Sub btnGuardar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnGuardar.Click
        Try
            If txtCodigo.Text <> "" Then
                If _roles.ActualizarRoles(txtCodigo.Text, txtDescripcion.Text) = True Then
                    txtCodigo.Text = ""
                    txtDescripcion.Text = ""
                End If
            Else
                If _roles.AgregarRoles(txtCodigo.Text, txtDescripcion.Text) = True Then
                    txtCodigo.Text = ""
                    txtDescripcion.Text = ""
                End If
            End If
            
            SQRol.SelectCommand = "Select id_Roles, descripcion from roles"
            SQRol.DataBind()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgbRoles_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgbRoles.SelectedIndexChanged
        Try
            Dim idx = dgbRoles.SelectedIndex
            txtCodigo.Text = dgbRoles.Rows(idx).Cells(1).Text
            txtDescripcion.Text = dgbRoles.Rows(idx).Cells(2).Text

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Try
            Response.Redirect("land.aspx", False)
        Catch ex As Exception

        End Try
    End Sub
End Class