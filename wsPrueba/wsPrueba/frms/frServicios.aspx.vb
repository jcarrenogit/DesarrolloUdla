Public Partial Class frServicios
    Inherits System.Web.UI.Page

    Private _area As New areas
    Private _func As New funcionalidad
   
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim dtAreas As New DataTable
        dtAreas = _area.ListarAreas
        cmbArea.DataSource = dtAreas
        cmbArea.DataTextField = "descripcion"
        cmbArea.DataValueField = "id_area"
        cmbArea.DataBind()

        Dim dtFuncionalidad As New DataTable
        dtFuncionalidad = _func.ListarFuncionalidad
        cmbFuncionalidad.DataSource = dtFuncionalidad
        cmbFuncionalidad.DataTextField = "Descripcion_funcionalidad"
        cmbFuncionalidad.DataValueField = "id_funcionalidad"
        cmbFuncionalidad.DataBind()

    End Sub

End Class