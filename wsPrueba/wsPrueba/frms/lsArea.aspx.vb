Imports wsPrueba.Clases


Partial Public Class lsArea
    Inherits System.Web.UI.Page

    Dim _ar As New areas

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                dgvArea.DataSource = _ar.ListarAreas
                dgvArea.DataBind()

            End If
        Catch ex As Exception

        End Try
    End Sub

End Class