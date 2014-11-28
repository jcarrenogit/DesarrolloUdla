Imports wsPrueba.Clases

Partial Public Class frmFuncionalidad
    Inherits System.Web.UI.Page

    Private _area As New areas
    Private _cargo As New cargos
    Private _roles As New roles
    Private _user As New usuario
    Private _func As New funcionalidad

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Try
                Dim dtFunc As New DataTable
                dtFunc = _func.ListarFuncionalidad()
                dgvFuncionalidad.DataSource = dtFunc
                dgvFuncionalidad.DataBind()

            Catch ex As Exception

            End Try
        End If

    End Sub

    Private Sub txtFuncionalidad_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFuncionalidad.TextChanged
        Try
            Dim dtU As New DataTable
            dtU = _func.consultar_funcionlidad(txtFuncionalidad.Text)

            notificacion.Visible = False

            If dtU.Rows.Count > 0 Then
                'Usuario Existe, despliego datos donde corresponde (controles ocultos)
                'username, email, nombre, cod_area, cod_cargo, estado, fecha_creacion, fecha_modificacion, cod_rol
                frmUser.Visible = True

                txtFuncionalidad.Enabled = False
                btnModificar.Visible = True
                hIdFunc.Value = dtU.Rows(0)(0).ToString
                hCrea.Value = True
            Else
                'Usuario Existe, despliego datos donde corresponde (controles ocultos)
                'username, email, nombre, cod_area, cod_cargo, estado, fecha_creacion, fecha_modificacion, cod_rol
                frmUser.Visible = True
                txtFuncionalidad.Enabled = True
                btnModificar.Visible = False
                btnGuardar.Visible = True

            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Try
            If hCrea.Value = False Then
                'Agregar Nuevo Usuario
                If _func.AgregarFuncionalidad(txtFuncionalidad.Text) = True Then

                    notificacion.Visible = True
                    notificacion.InnerText = "<br /><br />Funcionalidad creada correctmente, " & txtFuncionalidad.Text

                    frmUser.Visible = False

                End If
            Else
                'Modificar Usuario
                If _func.ActualizarFuncionalidad(hIdFunc.Value, txtFuncionalidad.Text) = True Then

                    notificacion.Visible = True
                    notificacion.InnerHtml = "<br /><br />Funcionalidad Actualizada Correctamente, " & txtFuncionalidad.Text

                    frmUser.Visible = False

                End If
            End If

            dgvFuncionalidad.DataSource = _func.ListarFuncionalidad()
            dgvFuncionalidad.DataBind()
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnModificar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnModificar.Click
        Try
            'Usuario Existe, despliego datos donde corresponde (controles ocultos)
            'username, email, nombre, cod_area, cod_cargo, estado, fecha_creacion, fecha_modificacion, cod_rol
            frmUser.Visible = True
            txtFuncionalidad.Enabled = True
            
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
End Class