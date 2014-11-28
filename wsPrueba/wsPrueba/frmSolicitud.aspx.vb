Imports wsPrueba.Clases

Partial Public Class frmSolicitud
    Inherits System.Web.UI.Page

    Private _area As New areas
    Private _cargo As New cargos
    Private _roles As New roles
    Private _user As New usuario
    Private _srv As New Servicios
    Private _sol As New solicitud

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then

                lblFechaCreacion.Text = Now.ToString
                lblFechaModificacion.Text = Now.ToString

                Dim dtServicio As New DataTable
                dtServicio = _srv.ListarServicios
                cmbServicio.DataSource = dtServicio
                cmbServicio.DataTextField = "Nombre"
                cmbServicio.DataValueField = "id_servicio"
                cmbServicio.DataBind()

                Dim dtUsuarioResp As New DataTable
                dtUsuarioResp = _user.listar_usuario_jefe()
                cmbUsuario.DataSource = dtUsuarioResp
                cmbUsuario.DataTextField = "nombre"
                cmbUsuario.DataValueField = "usr_id"
                cmbUsuario.DataBind()

                dgvSolicitudes.DataSource = _sol.ListarSolicitudGrilla
                dgvSolicitudes.DataBind()
            End If

        Catch ex As Exception

        End Try
    End Sub

    Public Sub cmbEstado_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbEstado.SelectedIndexChanged
        Try
            If cmbEstado.SelectedValue = "3" Then
                rech.Visible = True
            Else
                rech.Visible = False
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Try
            _sol.AgregarSolicitud(cmbServicio.SelectedValue, cmbUsuario.SelectedValue, cmbEstado.SelectedValue, txtDetalle.Text, txtRechazo.Text)

            notificacion.Visible = True
            notificacion.InnerHtml = "<br /><br />Solicitud agregada correctmente<br /> "

            txtDescripcion.Text = ""
            txtDetalle.Text = ""
            txtRechazo.Text = ""

            cmbEstado.SelectedIndex = -1
            cmbServicio.SelectedIndex = -1
            cmbUsuario.SelectedIndex = -1

            lblFechaCreacion.Text = ""
            lblFechaModificacion.Text = ""

            txtDescripcion.Visible = False
            txtDetalle.Visible = False
            txtRechazo.Visible = False

            cmbEstado.Visible = False
            cmbServicio.Visible = False
            cmbUsuario.Visible = False

            lblFechaCreacion.Visible = False
            lblFechaModificacion.Visible = False

            btnGuardar.Visible = False


        Catch ex As Exception

        End Try
    End Sub

End Class