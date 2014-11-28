Imports wsPrueba.Clases
Partial Public Class frArea
    Inherits System.Web.UI.Page

    Private _area As New areas


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnGuardar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnGuardar.Click
        Try
            If txtCodigo.Text <> "" Then
                If _area.ActualizarAreas(txtCodigo.Text, txtDescripcion.Text) = True Then
                    txtCodigo.Text = ""
                    txtDescripcion.Text = ""

                    divNotificacion.InnerText = "Registro Actualizado correctamente."
                End If
            Else
                If _area.AgregarAreas(txtCodigo.Text, txtDescripcion.Text) = True Then
                    txtCodigo.Text = ""
                    txtDescripcion.Text = ""

                    divNotificacion.InnerText = "Registro Ingresado correctamente."

                End If
            End If
            SQAreas.SelectCommand = "SELECT * FROM areas"
            SQAreas.DataBind()

        Catch ex As Exception
            divNotificacion.InnerText = "Error: " & ex.Message
        End Try

    End Sub
    
    Private Sub dgvAreas_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvAreas.SelectedIndexChanged
        Try
            Dim idx = dgvAreas.SelectedIndex
            txtCodigo.Text = dgvAreas.Rows(idx).Cells(1).Text
            txtDescripcion.Text = dgvAreas.Rows(idx).Cells(2).Text

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