<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ppal.Master" CodeBehind="frmRol.aspx.vb" Inherits="wsPrueba.frmRol" %>
<asp:Content ID="ctTitulo" ContentPlaceHolderID="cphTitulo" runat="server">
  <title>Mantenedor Roles</title>
</asp:Content>
<asp:Content ID="ctContenido" ContentPlaceHolderID="cphContent" runat="server">
  <!-- BEGIN PAGE CONTAINER-->
  <div class="container-fluid">
    <!-- BEGIN PAGE HEADER-->
    <div class="row-fluid">
      <div class="span12">
        <h3 class="page-title">Mantenedor Roles<small> <br />creación y mantención</small></h3>
        <ul class="breadcrumb">
          <li>
            <i class="icon-home"></i>
            <a href="land.aspx">Inicio</a>
            <span class="icon-angle-right"></span>
          </li>
          <li>
            <a href="#">Mantenedor de Rol</a>
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
              <span class="hidden-480">Información de Rol</span>
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
                  <form runat="server" id="frmAddRol" class="form-horizontal">
                    <asp:ScriptManager ID="scrRol" runat="server"></asp:ScriptManager>
                    <div class="control-group">
                    <br /><br />
                      <asp:HiddenField ID="addupd" runat="server" />
                      
                      
                      <label class="control-label">Nombre Rol</label>
                      <div class="controls"><asp:TextBox ID="txtRol" class="m-wrap small" runat="server" AutoPostBack="true"></asp:TextBox></div>
                      
                      <asp:UpdatePanel ID="updLogin" runat="server">
                        <Triggers>
                          <asp:AsyncPostBackTrigger ControlID="txtRol" EventName="TextChanged" />
                        </Triggers>
                        <ContentTemplate>
                          <div style="color:Black;" id="notificacion" runat="server" visible="false"></div> 
                          <asp:HiddenField ID="hCrea" runat="server" Value="true" />
                          <asp:HiddenField ID="hCodigo" runat="server" />
                          <br />
                          <div id="frmUser" runat="server" visible ="false">                         
                            <label class="control-label">Estado</label>
                            <div class="controls">
                              <asp:DropDownList runat="server" ID="cmbEstado">
                                <asp:ListItem Value="0">Activo</asp:ListItem>
                                <asp:ListItem Value="1">Inactivo</asp:ListItem>
                                <asp:ListItem Value="2">Bloqueado</asp:ListItem>
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
                      
                      <hr />
                      <br />
                      <asp:UpdatePanel UpdateMode="Always" ID="updRoles" runat="server">
                        <ContentTemplate>
                          <asp:GridView Width="50%" ID="dgvRol" runat="server" AutoGenerateColumns="False" 
                            CellPadding="4" ForeColor="#333333" GridLines="None">
                          <RowStyle BackColor="#EFF3FB" />
                          <Columns>
                              <asp:BoundField DataField="id_rol" HeaderText="ID" InsertVisible="False" 
                                  ReadOnly="True" SortExpression="id_rol" />
                              <asp:BoundField DataField="Descripcion" HeaderText="Descripción" 
                                  SortExpression="Descripcion" />
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
                    </div>
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
