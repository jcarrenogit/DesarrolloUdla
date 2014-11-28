Public Partial Class ppal
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim url As String = Request.Url.Segments(Request.Url.Segments.Length - 1)

            Select Case url
                Case "frmUsuario.aspx"
                    slUsuario.Attributes("class") = slUsuario.Attributes("class").Trim.Replace("arrow", "selected")
                    slParametros.Attributes("class") = slParametros.Attributes("class").Trim.Replace("selected", "arrow")
                    slInformes.Attributes("class") = slInformes.Attributes("class").Trim.Replace("selected", "arrow")
                    slStats.Attributes("class") = slStats.Attributes("class").Trim.Replace("selected", "arrow")
                    slInicio.Attributes("class") = slInicio.Attributes("class").Trim.Replace("selected", "arrow")

                Case "land.aspx"
                    slUsuario.Attributes("class") = slUsuario.Attributes("class").Trim.Replace("selected", "arrow")
                    slParametros.Attributes("class") = slParametros.Attributes("class").Trim.Replace("selected", "arrow")
                    slInformes.Attributes("class") = slInformes.Attributes("class").Trim.Replace("selected", "arrow")
                    slStats.Attributes("class") = slStats.Attributes("class").Trim.Replace("selected", "arrow")
                    slInicio.Attributes("class") = slInicio.Attributes("class").Trim.Replace("arrow", "selected")

            End Select

            Dim _dtData As New DataTable
            _dtData = DirectCast(Session("uData"), DataTable)
            If _dtData.Rows.Count > 0 Then
                Dim rRol As Integer = CInt(_dtData.Rows(0)(9))

                Select Case rRol
                    Case 1
                        'Consultas
                        mnuUsuario.Visible = False
                        mnuEstadisticas.Visible = False
                        mnuParametro.Visible = False

                    Case Else
                        'Cualquier otro

                End Select

            End If


        Catch ex As Exception

        End Try
    End Sub

End Class