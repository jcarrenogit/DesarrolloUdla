<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ppal.Master" CodeBehind="frmServicio.aspx.vb" Inherits="wsPrueba.frmServicio" %>
<asp:Content ID="ctTitulo" ContentPlaceHolderID="cphTitulo" runat="server">
  <title>Mantenedor Servicio</title>
</asp:Content>
<asp:Content ID="ctContenido" ContentPlaceHolderID="cphContent" runat="server">
  <!-- BEGIN PAGE CONTAINER-->
  <div class="container-fluid">
    <!-- BEGIN PAGE HEADER-->
    <div class="row-fluid">
      <div class="span12">
        <h3 class="page-title">Mantenedor Servicios<small> <br />creación y mantención</small></h3>
        <ul class="breadcrumb">
          <li>
            <i class="icon-home"></i>
            <a href="land.aspx">Inicio</a>
            <span class="icon-angle-right"></span>
          </li>
          <li>
            <a href="#">Mantenedor de Servicios</a>
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
              <span class="hidden-480">Información de Servicio</span>
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
                      <asp:HiddenField ID="addupd" runat="server" />
                      <label class="control-label">Nombre Servicio</label>
                      <div class="controls"><asp:TextBox ID="txtServicio" class="m-wrap small" runat="server" AutoPostBack="true"></asp:TextBox></div>
                      
                      <asp:UpdatePanel ID="updLogin" runat="server" UpdateMode="Conditional">
                        <Triggers>
                          <asp:AsyncPostBackTrigger ControlID="txtServicio" EventName="TextChanged" />
                        </Triggers>
                        <ContentTemplate>
                          <div style="color:Black;" id="notificacion" runat="server" visible="false"></div> 
                          <asp:HiddenField ID="hCrea" runat="server" Value="true" />
                          <asp:HiddenField ID="hCodigo" runat="server"  />
                          <asp:HiddenField ID="hUsuario" runat="server" />
                          <br />
                          <div id="frmUser" runat="server" visible ="false">                         
                            <label class="control-label">Descripcion</label>
                            <div class="controls"><asp:TextBox ID="txtDescripcion" class="m-wrap span4" runat="server"></asp:TextBox></div>
                            <br />
                            <label class="control-label">Usuario Responsable</label>
                            <div class="controls"><asp:DropDownList runat="server" ID="cmbUResp" EnableViewState="true" AutoPostBack="true" OnSelectedIndexChanged="cmbUResp_SelectedIndexChanged"></asp:DropDownList></div>
                            <br />
                            <label class="control-label">Area</label>
                            <div class="controls"><asp:DropDownList runat="server" ID="cmbArea" EnableViewState="true" AutoPostBack="true" OnSelectedIndexChanged="cmbArea_SelectedIndexChanged"></asp:DropDownList></div>
                            <br /><br />
                            <label class="control-label">Ult. Usuario que modificó</label>
                            <div class="controls"><asp:label ID="lblUsuario" runat="server"></asp:label></div>
                            <br /><br />
                            <label class="control-label">Fecha Creación</label>
                            <div class="controls"><asp:Label ID="lblFechaCreacion" runat="server" Text=""></asp:Label></div>
                            <br /><br />
                            <label class="control-label">Fecha Modificación</label>
                            <div class="controls"><asp:Label ID="lblFechaModificacion" runat="server" Text=""></asp:Label></div>
                            <br /><br />
                            <label class="control-label">Estado</label>
                            <div class="controls">
                              <asp:DropDownList runat="server" ID="cmbEstado">
                                <asp:ListItem Value="1">Activo</asp:ListItem>
                                <asp:ListItem Value="2">Inactivo</asp:ListItem>
                              </asp:DropDownList>
                            </div>
                                <br /><br />                                                        
                            <div class="form-actions">
                              <asp:Button runat="server" ID="btnGuardar" text="Guardar" Visible="false" cssclass="btn blue"/>
                              <asp:Button runat="server" ID="btnModificar" Text="Modificar" visible = "false" cssclass="btn blue" />
                              <asp:Button runat="server" ID="btnActivar" Text="Activar" visible = "false" cssclass="btn blue" />
                              <asp:Button runat="server" ID="btnVolver" Text="Volver" cssclass="btn blue" />
                            </div>           
                          </div>
                        </ContentTemplate>
                      </asp:UpdatePanel>
                      <br />
                      <br />
                      <asp:UpdatePanel UpdateMode="Always" ID="updFuncionalidad" runat="server">
                        <ContentTemplate>
                          <asp:GridView Width="100%" ID="dgvServicios" runat="server" AutoGenerateColumns="False" 
                            CellPadding="4" ForeColor="#333333" GridLines="None">
                          <RowStyle BackColor="#EFF3FB" />
                          <Columns>
                              <asp:BoundField DataField="id_servicio" HeaderText="ID" InsertVisible="False" 
                                  ReadOnly="True" SortExpression="id_servicio" />
                              <asp:BoundField DataField="Nombre" HeaderText="Nombre" 
                                  SortExpression="nombre" />
                              <asp:BoundField DataField="descripcion" HeaderText="descripcion" InsertVisible="False" 
                                  ReadOnly="True" SortExpression="descripcion" />
                              <asp:BoundField DataField="Estado" HeaderText="Estado" 
                                  SortExpression="Estado" />
                              <asp:BoundField DataField="area" HeaderText="Area" InsertVisible="False" 
                                  ReadOnly="True" SortExpression="area" />
                              <asp:BoundField DataField="responsable" HeaderText="Usuario Responsable" 
                                  SortExpression="responsable" />
                              <asp:BoundField DataField="usuario_modif" HeaderText="Modificado Por..." 
                                  SortExpression="usuario_modif" />
                              <asp:BoundField DataField="fecha_creacion" HeaderText="Fecha Creación" InsertVisible="False" 
                                  ReadOnly="True" SortExpression="fecha_creacion" />
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
