<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ppal.Master" CodeBehind="frmUsuario.aspx.vb" Inherits="wsPrueba.frmUsuario" %>
<asp:Content ID="ctHead" ContentPlaceHolderID="cphTitulo" runat="server">
  <title>Mantenedor Usuario</title>
</asp:Content>
<asp:Content ID="ctContenido" ContentPlaceHolderID="cphContent" runat="server">
  <!-- BEGIN PAGE CONTAINER-->
  <div class="container-fluid">
    <!-- BEGIN PAGE HEADER-->
    <div class="row-fluid">
      <div class="span12">
        <h3 class="page-title">Mantenedor Usuarios<small> <br />creación y mantención</small></h3>
        <ul class="breadcrumb">
          <li>
            <i class="icon-home"></i>
            <a href="land.aspx">Inicio</a>
            <span class="icon-angle-right"></span>
          </li>
          <li>
            <a href="#">Mantenedor de Usuarios</a>
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
              <span class="hidden-480">Información de Usuario</span>
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
                    <asp:ScriptManager ID="scrUsuario" runat="server"></asp:ScriptManager>
                    <div class="control-group">
                    <br /><br />
                      <asp:HiddenField ID="addupd" runat="server" />
                      <label class="control-label">Login / NickName</label>
                      <div class="controls"><asp:TextBox ID="txtLogin" class="m-wrap small" runat="server" AutoPostBack="true"></asp:TextBox></div>
                      
                      <asp:UpdatePanel ID="updLogin" runat="server" UpdateMode="Conditional">
                        <Triggers>
                          <asp:AsyncPostBackTrigger ControlID="txtlogin" EventName="TextChanged" />
                        </Triggers>
                        <ContentTemplate>
                          <div runat="server" id="notifExiste" visible="false"></div>
                          <div style="color:Black;" id="notificacion" runat="server" visible="false"></div> 
                          <asp:HiddenField ID="hCrea" runat="server" Value="true" />
                          <br />
                          <div id="frmUser" runat="server" visible ="false">                         
                            <label class="control-label">Nombre</label>
                            <div class="controls"><asp:TextBox ID="txtNombre" class="m-wrap small" runat="server"></asp:TextBox></div>
                            <br />
                            <label class="control-label">Email</label>
                            <div class="controls">
                              <asp:TextBox ID="txtEmail" class="m-wrap medium" runat="server"></asp:TextBox>
                              <asp:RegularExpressionValidator ID="regexEmailValid" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtEmail" ErrorMessage="Correo no válido"></asp:RegularExpressionValidator>
                            </div>
                            <br />
                            <label class="control-label">Contraseña</label>
                            <div class="controls">
                              <asp:TextBox ID="txtPass" TextMode="Password" class="m-wrap small" runat="server"></asp:TextBox>
                              <asp:regularexpressionvalidator id="revPassword" display="Dynamic" errormessage="La contraseña debe contener desde 6 caracteres de largo</br> y al menos 1 número." forecolor="Red" validationexpression="(?!^[0-9]*$)(?!^[a-zA-Z]*$)^([a-zA-Z0-9]{6,10})$" controltovalidate="txtPass" runat="server"></asp:regularexpressionvalidator>
                            </div>
                            <br />
                            <label class="control-label">Area</label>
                            <div class="controls"><asp:DropDownList runat="server" ID="cmbArea" EnableViewState="true" AutoPostBack="true" OnSelectedIndexChanged="cmbArea_SelectedIndexChanged"></asp:DropDownList></div>
                            <br />
                            <label class="control-label">Cargo</label>
                            <div class="controls"><asp:DropDownList runat="server" ID="cmbCargo" EnableViewState="true" AutoPostBack="true" OnSelectedIndexChanged="cmbCargo_SelectedIndexChanged"></asp:DropDownList></div>
                            <br />
                            <label class="control-label">Rol</label>
                            <div class="controls"><asp:DropDownList runat="server" ID="cmbRol" EnableViewState="true" AutoPostBack="true" OnSelectedIndexChanged="cmbRol_SelectedIndexChanged"></asp:DropDownList></div>
                            <br />
                            <label class="control-label">Fecha Creación</label>
                            <div class="controls"><asp:Label ID="lblFechaCreacion" runat="server" Text=""></asp:Label></div>
                            <br /><br />
                            <label class="control-label">Fecha Modificación</label>
                            <div class="controls"><asp:Label ID="lblFechaModificacion" runat="server" Text=""></asp:Label></div>
                            <br /><br />
                            <label class="control-label">Estado</label>
                            <div class="controls">
                              <asp:DropDownList runat="server" ID="cmbEstado">
                                <asp:ListItem Value="0">Activo</asp:ListItem>
                                <asp:ListItem Value="1">Inactivo</asp:ListItem>
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
