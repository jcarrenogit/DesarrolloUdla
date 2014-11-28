Imports wsPrueba.Clases

Partial Public Class frmServicio
    Inherits System.Web.UI.Page

    Private _area As New areas
    Private _cargo As New cargos
    Private _roles As New roles
    Private _user As New usuario
    Private _srv As New Servicios

    '[Nombre],[Descripcion],[id_area],[Estado],
    '[id_servicio],[id_usuario_ult_modif],[fecha_creacion],[fecha_modificacion]

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then

                Dim dtAreas As New DataTable
                dtAreas = _area.ListarAreas
                cmbArea.DataSource = dtAreas
                cmbArea.DataTextField = "descripcion"
                cmbArea.DataValueField = "id_area"
                cmbArea.DataBind()

                Dim dtUsuarioResp As New DataTable
                dtUsuarioResp = _user.listar_usuario_jefe()
                cmbUResp.DataSource = dtUsuarioResp
                cmbUResp.DataTextField = "nombre"
                cmbUResp.DataValueField = "usr_id"
                cmbUResp.DataBind()

                Dim dtUData As New DataTable
                dtUData = DirectCast(Session("uData"), DataTable)

                If dtUData.Rows.Count > 0 Then
                    hUsuario.Value = dtUData.Rows(0)(0)
                    lblUsuario.Text = _user.ListarUsuario(dtUData.Rows(0)(0))
                End If


                dgvServicios.DataSource = _srv.ListarServiciosGrilla()
                dgvServicios.DataBind()
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtServicio_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtServicio.TextChanged
        Try
            Dim dtU As New DataTable
            dtU = _srv.consultar_servicio(txtServicio.Text)
            notificacion.InnerHtml = ""
            notificacion.Visible = False

            If dtU.Rows.Count > 0 Then
                '[Nombre],[Descripcion],[id_area],[Estado],[id_servicio],[id_usuario_ult_modif],
                '[fecha_creacion],[fecha_modificacion],id_usr
                frmUser.Visible = True

                txtDescripcion.Text = dtU.Rows(0)(1).ToString

                Dim cArea, cEstado, cUsuarioResp As Integer

                cArea = CInt(IIf(dtU.Rows(0)(2).ToString.Trim = "", 0, dtU.Rows(0)(2).ToString.Trim))
                cmbArea.SelectedValue = cArea

                cEstado = CInt(IIf(dtU.Rows(0)(3).ToString.Trim = "", 0, dtU.Rows(0)(3).ToString.Trim))
                cmbEstado.SelectedValue = cEstado
                Select Case cEstado
                    Case 1
                        notificacion.Visible = True
                        notificacion.InnerHtml = "<br /><br /> Servicio ya existe, presione el botón modificar ubicado más abajo."
                    Case 2
                        notificacion.Visible = True
                        notificacion.InnerHtml = "<br /><br /> Servicio ya existe en estado inactivo, presione el botón modificar ubicado más abajo."

                End Select

                Dim RegSol As New ArrayList
                RegSol = _srv.BuscarSolicitudes(dtU.Rows(0)(4))
                If RegSol.Count > 0 Then
                    If notificacion.InnerHtml <> "" Then
                        notificacion.InnerHtml &= "además, posee algunas solicitudes incompletas:"
                    Else
                        notificacion.InnerHtml = " Se han encontrado solicitudes asociadas a este servicio:"
                    End If
                    notificacion.InnerHtml &= "<br>"
                    notificacion.InnerHtml &= "Ingresadas : " & RegSol.Item(0) & "<br />"
                    notificacion.InnerHtml &= "Aprobada : " & RegSol.Item(1) & "<br />"
                    notificacion.InnerHtml &= "Rechazada : " & RegSol.Item(2) & "<br />"
                    notificacion.InnerHtml &= "Publicada : " & RegSol.Item(3) & "<br />"
                End If

                cUsuarioResp = CInt(IIf(dtU.Rows(0)(8).ToString.Trim = "", 0, dtU.Rows(0)(8).ToString.Trim))
                cmbUResp.SelectedValue = cUsuarioResp

                txtDescripcion.Enabled = False

                cmbArea.Enabled = False
                cmbEstado.Enabled = False
                cmbUResp.Enabled = False

                If Not IsDBNull(dtU.Rows(0)(5)) Then
                    If dtU.Rows(0)(5) <> 0 Then
                        hUsuario.Value = dtU.Rows(0)(5)
                        lblUsuario.Text = _user.ListarUsuario(dtU.Rows(0)(5))
                    End If
                End If

                lblFechaCreacion.Text = dtU.Rows(0)(6).ToString
                lblFechaModificacion.Text = dtU.Rows(0)(7).ToString

                btnModificar.Visible = True
                btnGuardar.Visible = False

                hCodigo.Value = dtU.Rows(0)(4)
                hCrea.Value = False
            Else
                '[Nombre],[Descripcion],[id_area],[Estado],
                '[id_servicio],[id_usuario_ult_modif],[fecha_creacion],[fecha_modificacion]
                frmUser.Visible = True

                txtDescripcion.Text = ""

                cmbUResp.SelectedIndex = -1
                cmbArea.SelectedIndex = -1
                cmbEstado.SelectedIndex = -1

                Dim dtUData As New DataTable
                dtUData = DirectCast(Session("uData"), DataTable)

                If dtUData.Rows.Count > 0 Then
                    hUsuario.Value = dtUData.Rows(0)(0)
                    lblUsuario.Text = _user.ListarUsuario(dtUData.Rows(0)(0))
                End If

                lblFechaCreacion.Text = Now.ToShortDateString
                lblFechaModificacion.Text = Now.ToShortDateString

                btnGuardar.Visible = True

            End If

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnModificar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnModificar.Click
        Try
            txtDescripcion.Enabled = True

            cmbArea.Enabled = True
            cmbEstado.Enabled = True
            cmbUResp.Enabled = True

            Dim dtUData As New DataTable
            dtUData = DirectCast(Session("uData"), DataTable)

            If dtUData.Rows.Count > 0 Then
                hUsuario.Value = dtUData.Rows(0)(0)
                lblUsuario.Text = _user.ListarUsuario(dtUData.Rows(0)(0))
            End If

            lblFechaModificacion.Text = Now

            btnGuardar.Visible = True
            btnModificar.Visible = False

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnGuardar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnGuardar.Click
        Try
            If hCrea.Value = False Then
                'Agregar Nuevo Usuario
                If _srv.ActualizarServicio(hCodigo.Value, txtServicio.Text, txtDescripcion.Text, cmbEstado.SelectedValue, _
                                           cmbUResp.SelectedValue, cmbArea.SelectedValue, hUsuario.Value, lblFechaCreacion.Text) = True Then

                    notificacion.Visible = True
                    notificacion.InnerHtml = "<br /><br />Servicio Actualizado Correctamente, " & txtServicio.Text
                    hCodigo.Value = ""
                    txtServicio.Text = ""
                    frmUser.Visible = False

                End If
            Else
                'Modificar Usuario

                If _srv.AgregarServicio(txtServicio.Text, txtDescripcion.Text, cmbEstado.SelectedValue, cmbUResp.SelectedValue, cmbArea.SelectedValue, hUsuario.Value) = True Then

                    notificacion.Visible = True
                    notificacion.InnerHtml = "<br /><br />Servicio Agregado Correctamente, " & txtServicio.Text
                    txtServicio.Text = ""
                    hCodigo.Value = ""
                    frmUser.Visible = False

                End If
            End If

            dgvServicios.DataSource = _srv.ListarServiciosGrilla()
            dgvServicios.DataBind()

        Catch ex As Exception

        End Try
        
    End Sub

    Private Sub btnVolver_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnVolver.Click
        Try
            Response.Redirect("land.aspx")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvServicios_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles dgvServicios.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Cells(7).Text = CDate(e.Row.Cells(7).Text).ToShortDateString
            e.Row.Cells(8).Text = CDate(e.Row.Cells(8).Text).ToShortDateString
        End If
    End Sub

    Public Sub cmbArea_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbArea.SelectedIndexChanged

    End Sub

    Public Sub cmbUResp_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbUResp.SelectedIndexChanged

    End Sub
End Class