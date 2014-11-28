<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ppal.Master" CodeBehind="frmFuncionalidad.aspx.vb" Inherits="wsPrueba.frmFuncionalidad" %>
<asp:Content ID="ctTitulo" ContentPlaceHolderID="cphTitulo" runat="server">
    <title>Mantenedor Funcionalidad</title>
</asp:Content>
<asp:Content ID="ctContenido" ContentPlaceHolderID="cphContent" runat="server">
    <!-- BEGIN PAGE CONTAINER-->
  <div class="container-fluid">
    <!-- BEGIN PAGE HEADER-->
    <div class="row-fluid">
      <div class="span12">
        <h3 class="page-title">Mantenedor Funcionalidad<small> <br /> creación y mantención</small></h3>
        <ul class="breadcrumb">
          <li>
            <i class="icon-home"></i>
            <a href="land.aspx">Inicio</a>
            <span class="icon-angle-right"></span>
          </li>
          <li>
            <a href="#">Mantenedor de Funcionalidad</a>
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
              <span class="hidden-480">Información de Funcionalidad</span>
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
                      <label class="control-label">Funcionalidad</label>
                      <div class="controls"><asp:TextBox ID="txtFuncionalidad" class="m-wrap small" runat="server" AutoPostBack="true"></asp:TextBox></div>
                      
                      <asp:UpdatePanel ID="updLogin" runat="server">
                        <Triggers>
                          <asp:AsyncPostBackTrigger ControlID="txtFuncionalidad" EventName="TextChanged" />
                        </Triggers>
                        <ContentTemplate>
                          <div style="color:Black;" id="notificacion" runat="server" visible="false"></div> 
                          <asp:HiddenField ID="hCrea" runat="server" Value="true" />
                          <asp:HiddenField ID="hIdFunc" runat="server" Value="" />
                          <br />
                          <div id="frmUser" runat="server" visible ="false">                                                                                
                            <div class="form-actions">
                              <asp:Button runat="server" ID="btnGuardar" text="Guardar" Visible="false" cssclass="btn blue"/>
                              <asp:Button runat="server" ID="btnModificar" Text="Modificar" visible = "false" cssclass="btn blue" />
                              <asp:Button runat="server" ID="btnVolver" Text="Volver" cssclass="btn blue" />
                            </div>           
                          </div>
                        </ContentTemplate>
                      </asp:UpdatePanel>
                      <br />
                      <hr />
                      <br />
                      <asp:UpdatePanel UpdateMode="Always" ID="updFuncionalidad" runat="server">
                        <ContentTemplate>
                          <asp:GridView Width="50%" ID="dgvFuncionalidad" runat="server" AutoGenerateColumns="False" 
                            CellPadding="4" ForeColor="#333333" GridLines="None">
                          <RowStyle BackColor="#EFF3FB" />
                          <Columns>
                              <asp:BoundField DataField="id_funcionalidad" HeaderText="ID" InsertVisible="False" 
                                  ReadOnly="True" SortExpression="id_funcionalidad" />
                              <asp:BoundField DataField="Descripcion_funcionalidad" HeaderText="Descripción" 
                                  SortExpression="Descripcion_funcionalidad" />
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
