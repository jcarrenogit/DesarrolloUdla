
Imports wsPrueba
Imports System.Data
Imports System.Data.SqlClient

Partial Public Class uLogin
    Inherits System.Web.UI.Page

    Private _usr As New Clases.usuario
    Private _dt As New DataTable

    Protected Sub btnAcceder_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAcceder.Click
        Try
            _dt = _usr.uLogin(txtUserName.Text, txtPassword.Text)

            If _dt.Rows.Count > 0 Then

                Dim act As Integer = CInt(_dt.Rows(0)(4))
                If act = 0 Then
                    Session("uData") = _dt
                    Response.Redirect("land.aspx", True)
                Else
                    rspServer.InnerHtml = "<p color='white' style='font-size:14px;'>Usuario Inactivo</p>"
                End If
            Else
                rspServer.InnerHtml = "<p color='white' style='font-size:14px;'>Error en la autenticación del usuario</p>"
            End If
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
    End Sub

End Class