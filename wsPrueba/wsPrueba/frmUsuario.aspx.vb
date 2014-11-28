Imports wsPrueba.Clases

Partial Public Class frmUsuario
    Inherits System.Web.UI.Page

    Private _area As New areas
    Private _cargo As New cargos
    Private _roles As New roles
    Private _user As New usuario

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Try
                Dim dtAreas As New DataTable
                dtAreas = _area.ListarAreas
                cmbArea.DataSource = dtAreas
                cmbArea.DataTextField = "descripcion"
                cmbArea.DataValueField = "id_area"
                cmbArea.DataBind()

                Dim dtCargos As New DataTable
                dtCargos = _cargo.ListarCargos
                cmbCargo.DataSource = dtCargos
                cmbCargo.DataTextField = "descripcion"
                cmbCargo.DataValueField = "id_cargo"
                cmbCargo.DataBind()

                Dim dtRoles As New DataTable
                dtRoles = _roles.ListarRoles
                cmbRol.DataSource = dtRoles
                cmbRol.DataTextField = "descripcion"
                cmbRol.DataValueField = "id_rol"
                cmbRol.DataBind()

            Catch ex As Exception

            End Try
        End If
    End Sub

    Public Sub txtLogin_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtLogin.TextChanged
        Try
            If txtLogin.Text.ToUpper = UCase("groot") Then
                txtLogin.Text = ""
                notificacion.InnerHtml = "* usuario reservado para el sistema"
                notificacion.Visible = False
                Exit Sub
            End If

            Dim dtU As New DataTable
            dtU = _user.consulta_usuario(txtLogin.Text)

            notificacion.Visible = False
            notifExiste.Visible = False
            notifExiste.InnerText = ""

            If dtU.Rows.Count > 0 Then
                'Usuario Existe, despliego datos donde corresponde (controles ocultos)
                'username, email, nombre, cod_area, cod_cargo, estado, fecha_creacion, fecha_modificacion, cod_rol
                frmUser.Visible = True
                txtNombre.Text = dtU.Rows(0)(2).ToString
                txtEmail.Text = dtU.Rows(0)(1).ToString

                Dim cArea, cCargo, cRol, cEstado As Integer

                cArea = CInt(IIf(dtU.Rows(0)(3).ToString.Trim = "", 0, dtU.Rows(0)(3).ToString.Trim))
                cmbArea.SelectedValue = cArea

                cCargo = CInt(IIf(dtU.Rows(0)(4).ToString.Trim = "", 0, dtU.Rows(0)(4).ToString.Trim))
                cmbCargo.SelectedValue = cCargo

                cRol = CInt(IIf(dtU.Rows(0)(8).ToString.Trim = "", 0, dtU.Rows(0)(8).ToString.Trim))
                Try
                    cmbRol.SelectedValue = cRol
                Catch ex As Exception
                    cmbRol.SelectedIndex = -1
                End Try


                cEstado = CInt(IIf(dtU.Rows(0)(5).ToString.Trim = "", 0, dtU.Rows(0)(5).ToString.Trim))
                Try
                    cmbEstado.SelectedValue = cEstado
                Catch ex As Exception
                    cmbEstado.SelectedIndex = -1
                End Try


                txtNombre.Enabled = False
                txtEmail.Enabled = False

                cmbArea.Enabled = False
                cmbCargo.Enabled = False
                cmbRol.Enabled = False
                cmbEstado.Enabled = False

                notifExiste.InnerHtml = "* usuario existe, presione el botón modificar."

                Select Case cmbEstado.SelectedValue
                    Case 1
                        notifExiste.InnerHtml &= "<br />* usuario inactivo, presione el botón modificar."
                    Case 3
                        notifExiste.InnerHtml &= "<br />* usuario bloqueado, presione el botón modificar."
                    Case Else

                End Select


                notifExiste.Style.Add("color", "red")
                notifExiste.Visible = True

                lblFechaCreacion.Text = dtU.Rows(0)(6).ToString
                lblFechaModificacion.Text = dtU.Rows(0)(7).ToString

                btnModificar.Visible = True
                btnGuardar.Visible = False
                hCrea.Value = True
            Else
                'Usuario Existe, despliego datos donde corresponde (controles ocultos)
                'username, email, nombre, cod_area, cod_cargo, estado, fecha_creacion, fecha_modificacion, cod_rol
                frmUser.Visible = True

                txtNombre.Enabled = True
                txtEmail.Enabled = True

                cmbArea.Enabled = True
                cmbCargo.Enabled = True
                cmbRol.Enabled = True
                cmbEstado.Enabled = True

                txtNombre.Text = ""
                txtEmail.Text = ""

                cmbArea.SelectedIndex = -1
                cmbCargo.SelectedIndex = -1
                cmbRol.SelectedIndex = -1
                cmbEstado.SelectedIndex = -1

                notifExiste.InnerText = "* usuario no existe, edite los campos y presione guardar."
                notifExiste.Style.Add("color", "green")
                notifExiste.Visible = True

                lblFechaCreacion.Text = ""
                lblFechaModificacion.Text = ""

                btnGuardar.Visible = True
                btnModificar.Visible = False
            End If

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnGuardar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnGuardar.Click
        Try
            Dim cRol As String = cmbRol.Items(cmbRol.SelectedIndex).Value
            Dim cCargo As String = cmbCargo.Items(cmbCargo.SelectedIndex).Value
            Dim cEstado As String = cmbEstado.Items(cmbEstado.SelectedIndex).Value
            Dim cArea As String = cmbArea.Items(cmbArea.SelectedIndex).Value

            If hCrea.Value = False Then
                'Agregar Nuevo Usuario


                If _user.AgregarUsuario(txtLogin.Text, txtEmail.Text, txtPass.Text, txtNombre.Text, _
                                        cArea, cCargo, cEstado, _
                                        cRol) = True Then

                    notificacion.Visible = True
                    notificacion.InnerText = "<br /><br />Usuario creado Correctmente, " & txtLogin.Text

                    frmUser.Visible = False

                End If
            Else
                'Modificar Usuario
                If _user.ActualizarUsuario(txtLogin.Text, txtEmail.Text, txtPass.Text, txtNombre.Text, _
                                        cArea, cCargo, cEstado, _
                                        cRol) = True Then

                    notificacion.Visible = True
                    notificacion.InnerHtml = "<br /><br />Usuario Actualizado Correctamente, " & txtLogin.Text

                    frmUser.Visible = False

                End If
            End If
            notifExiste.Visible = False
            notifExiste.InnerHtml = ""

            txtLogin.Text = ""

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnModificar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnModificar.Click
        Try
            'Usuario Existe, despliego datos donde corresponde (controles ocultos)
            'username, email, nombre, cod_area, cod_cargo, estado, fecha_creacion, fecha_modificacion, cod_rol
            frmUser.Visible = True
            txtNombre.Enabled = True
            txtEmail.Enabled = True

            cmbArea.Enabled = True
            cmbCargo.Enabled = True
            cmbRol.Enabled = True
            cmbEstado.Enabled = True

            lblFechaModificacion.Text = Now

            btnGuardar.Enabled = True
            btnGuardar.Visible = True

            btnModificar.Visible = False
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnVolver_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnVolver.Click
        Try
            Response.Redirect("land.aspx")
        Catch ex As Exception

        End Try
    End Sub

    Public Sub cmbArea_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbArea.SelectedIndexChanged

    End Sub


    Public Sub cmbCargo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbCargo.SelectedIndexChanged

    End Sub

    Public Sub cmbEstado_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbEstado.SelectedIndexChanged

    End Sub

    Public Sub cmbRol_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbRol.SelectedIndexChanged

    End Sub
End Class