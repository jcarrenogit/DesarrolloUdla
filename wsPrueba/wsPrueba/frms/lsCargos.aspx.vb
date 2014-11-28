Imports wsPrueba.Clases

Partial Public Class lsCargos
    Inherits System.Web.UI.Page
    Dim _ar As New cargos

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                dgvCargo.DataSource = _ar.ListarCargos
                dgvCargo.DataBind()

            End If
        Catch ex As Exception

        End Try
    End Sub

End Class