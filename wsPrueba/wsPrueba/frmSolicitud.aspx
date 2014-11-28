<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ppal.Master" CodeBehind="frmSolicitud.aspx.vb" Inherits="wsPrueba.frmSolicitud" %>
<asp:Content ID="ctTitulo" ContentPlaceHolderID="cphTitulo" runat="server">
</asp:Content>
<asp:Content ID="ctContenido" ContentPlaceHolderID="cphContent" runat="server">
<!-- BEGIN PAGE CONTAINER-->
  <div class="container-fluid">
    <!-- BEGIN PAGE HEADER-->
    <div class="row-fluid">
      <div class="span12">
        <h3 class="page-title">Mantenedor Solicitudes<small> <br /> creación y mantención</small></h3>
        <ul class="breadcrumb">
          <li>
            <i class="icon-home"></i>
            <a href="land.aspx">Inicio</a>
            <span class="icon-angle-right"></span>
          </li>
          <li>
            <a href="#">Mantenedor de Solicitudes</a>
          </li>
        </ul>
      </div>
    </div>
    <!-- END PAGE HEADER-->
    
    <!-- BEGIN PAGE CONTENT-->
    <div class="row-fluid">
      <div class="span12">
        <!-- BEGIN SAMPLE FORM PORTLET-->
        <div class="portlet box blue tabbable">
          <div class="portlet-title">
            <div class="caption">
              <i class="icon-reorder"></i>
              <span class="hidden-480">Información de Solicitud</span>
            </div>
          </div>
          
          <div class="portlet-body form">
            <div class="tabbable portlet-tabs">
              <ul class="nav nav-tabs">
                <li><a href="#portlet_tab3" data-toggle="tab" style="visibility:hidden;">Inline</a></li>
              </ul>
              
              <div class="tab-content">
                <div class="tab-pane active" id="portlet_tab1">
                  <!-- BEGIN FORM-->
                  <form runat="server" id="frmAddUsuario" class="form-horizontal">
                    <asp:ScriptManager ID="scrServicio" runat="server"></asp:ScriptManager>
                    <div class="control-group">
                    <br /><br />
                    <div style="color:Black;" id="notificacion" runat="server" visible="false"></div>
                    <asp:HiddenField ID="hCrea" runat="server" Value="true" />
                    <asp:HiddenField ID="hCodigo" runat="server"  />
                    <asp:HiddenField ID="hUsuario" runat="server" />
                    <br />
                      <label class="control-label">Descripcion</label>
                      <div class="controls"><asp:TextBox ID="txtDescripcion" class="m-wrap span4" runat="server"></asp:TextBox></div>
                      <br />
                      <label class="control-label">Servicio</label>
                      <div class="controls"><asp:DropDownList runat="server" ID="cmbServicio"></asp:DropDownList></div>
                      <br />
                      <label class="control-label">Usuario</label>
                      <div class="controls"><asp:DropDownList runat="server" ID="cmbUsuario"></asp:DropDownList></div>
                      <br /><br />
                      <label class="control-label">Detalle</label>
                      <div class="controls"><asp:TextBox ID="txtDetalle" CssClass="span6" runat="server" MaxLength="500" TextMode="MultiLine" Columns="30" Rows="5"></asp:TextBox></div>
                      <br /><br />
                      <label class="control-label">Fecha Creación</label>
                      <div class="controls"><asp:Label ID="lblFechaCreacion" runat="server" Text=""></asp:Label></div>
                      <br /><br />
                      <label class="control-label">Fecha Modificación</label>
                      <div class="controls"><asp:Label ID="lblFechaModificacion" runat="server" Text=""></asp:Label></div>
                      <br /><br />
                      <label class="control-label">Estado</label>
                      <div class="controls">
                        <asp:DropDownList runat="server" ID="cmbEstado" AutoPostBack="true">
                          <asp:ListItem Value="1">Ingresada</asp:ListItem>
                          <asp:ListItem Value="2">Aprobada</asp:ListItem>
                          <asp:ListItem Value="3">Rechazada</asp:ListItem>
                          <asp:ListItem Value="4">Publicada</asp:ListItem>
                        </asp:DropDownList>
                      </div>
                      <br />
                      <asp:UpdatePanel ID="updMotivoRechazo" runat="server">
                        <Triggers>
                          <asp:AsyncPostBackTrigger ControlID="cmbEstado" EventName="SelectedIndexChanged" />
                        </Triggers>
                        <ContentTemplate>
                          <div id="rech" runat="server" visible="false">
                            <label class="control-label">Motivo Rechazo</label>
                            <div class="controls"><asp:TextBox ID="txtRechazo" runat="server" CssClass="span6" MaxLength="500" TextMode="MultiLine" Columns="30" Rows="5"></asp:TextBox></div>
                            <br /><br />
                          </div>  
                        </ContentTemplate>
                      </asp:UpdatePanel>
                      <br /><br />                                                        
                      <div class="form-actions">
                        <asp:Button runat="server" ID="btnGuardar" text="Guardar" cssclass="btn blue"/>
                        <asp:Button runat="server" ID="btnVolver" Text="Volver" cssclass="btn blue" />
                      </div>           
                      <br />
                      <br />
                      <asp:UpdatePanel UpdateMode="Always" ID="updSolicitud" runat="server">
                        <ContentTemplate>
                          <asp:GridView Width="100%" ID="dgvSolicitudes" runat="server" AutoGenerateColumns="False" 
                            CellPadding="4" ForeColor="#333333" GridLines="None">
                          <RowStyle BackColor="#EFF3FB" />
                          <Columns>
                              <asp:BoundField DataField="id_solicitud" HeaderText="ID" InsertVisible="False" 
                                  ReadOnly="True" SortExpression="id_solicitud" />
                              <asp:BoundField DataField="nServicio" HeaderText="Servicio" 
                                  SortExpression="nServicio" />
                              <asp:BoundField DataField="nUsuario" HeaderText="Usuario Solicitante" InsertVisible="False" 
                                  ReadOnly="True" SortExpression="nUsuario" />
                              <asp:BoundField DataField="Estado" HeaderText="Estado" 
                                  SortExpression="Estado" />
                              <asp:BoundField DataField="Detalle_Solicitud" HeaderText="Detalle" InsertVisible="False" 
                                  ReadOnly="True" SortExpression="detalle_solicitud" />
                              <asp:BoundField DataField="detalle_rechazo" HeaderText="Detalle Rechazo" 
                                  SortExpression="detalle_rechazo" />
                              <asp:BoundField DataField="Fecha_creacion" HeaderText="Fecha Creación" 
                                  SortExpression="Fecha_creacion" />
                              <asp:BoundField DataField="fecha_modificacion" HeaderText="Fecha Modificación" 
                                  SortExpression="fecha_modificacion" />
                          </Columns>
                          <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                          <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                          <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                          <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                          <EditRowStyle BackColor="#2461BF" />
                          <AlternatingRowStyle BackColor="White" />
                        </asp:GridView>
                        </ContentTemplate>
                      </asp:UpdatePanel>
                      <br />
                  </form>
                  <!-- END FORM-->
                </div>
              </div>
            </div>
          </div>
        </div>
        <!-- END SAMPLE FORM PORTLET-->
      </div>
    </div>
    <!-- END PAGE CONTENT-->
  </div>
  <!-- END PAGE CONTAINER-->
</asp:Content>
