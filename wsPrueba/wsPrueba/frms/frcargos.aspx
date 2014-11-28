<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ppal.Master" CodeBehind="frcargos.aspx.vb" Inherits="wsPrueba.frcargos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphTitulo" runat="server">
<title>Mantenedor Cargos</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="server">
<!-- BEGIN PAGE CONTAINER-->
  <div class="container-fluid">
    <!-- BEGIN PAGE HEADER-->
    <div class="row-fluid">
      <div class="span12">
        <h3 class="page-title">Mantenedor Cargos <small>creación y mantención</small></h3>
        <ul class="breadcrumb">c
          <li><i class="icon-home"></i><a href="land.aspx">Inicio</a><span class="icon-angle-right"></span></li>
          <li><a href="#">Mantenedor de Cargos</a><span class="icon-angle-right"></span></li>
          <li><a href="#">Agregar</a></li>
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
              <i class="icon-reorder"></i><span class="hidden-480">Información del Cargo</span>
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
                    <div class="control-group">
                      
                      <label class="control-label" style="visibility:hidden;">Código</label>
                      <div class="controls">
                        <asp:TextBox  runat="server" ID="txtCodigo" class="m-wrap small" style="visibility:hidden;"></asp:TextBox>
                      </div>
                      
                      <br />
                      <label class="control-label">Descripción</label>
                      <div class="controls">
                        <asp:TextBox ID="txtDescripcion" class="m-wrap small" runat="server"></asp:TextBox>
                      </div>
                                            
                      <div class="form-actions">
                        <asp:Button runat="server" ID="btnGuardar" text="Guardar" cssclass="btn blue"/>
                        <asp:Button runat="server" ID="btnCancelar" Text="Cancelar" cssclass="btn" />
                      </div>
                      <br /><br />
                      <div runat="server" id="divNotificacion"></div>
                      <br /><br />
                      <asp:GridView runat="server" ID="dgvCargos" AutoGenerateColumns="False" 
                            CellPadding="4" DataSourceID="SQCargos" ForeColor="#333333" GridLines="None">
                          <RowStyle BackColor="#EFF3FB" />
                          <Columns>
                              <asp:CommandField ShowSelectButton="True" />
                              <asp:BoundField DataField="id_cargo" HeaderText="ID" InsertVisible="False" 
                                  ReadOnly="True" SortExpression="id_cargo" />
                              <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" 
                                  SortExpression="Descripcion" />
                          </Columns>
                          <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                          <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                          <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                          <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                          <EditRowStyle BackColor="#2461BF" />
                          <AlternatingRowStyle BackColor="White" />
                      </asp:GridView>
                      
                        <asp:SqlDataSource ID="SQCargos" runat="server" 
                            ConnectionString="<%$ ConnectionStrings:cnServicios %>" 
                            SelectCommand="SELECT [id_cargo], [Descripcion] FROM [Cargo]">
                        </asp:SqlDataSource>
                      
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
