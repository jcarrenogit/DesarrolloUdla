<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ppal.Master" CodeBehind="lsCargos.aspx.vb" Inherits="wsPrueba.lsCargos" %>
<asp:Content ID="ctHeader" ContentPlaceHolderID="cphTitulo" runat="server">
    Listado Cargos
</asp:Content>
<asp:Content ID="ctContenido" ContentPlaceHolderID="cphContent" runat="server">
    <!-- BEGIN PAGE CONTAINER-->
  <div class="container-fluid">
    <!-- BEGIN PAGE HEADER-->
    <div class="row-fluid">
      <div class="span12">
        <h3 class="page-title">Listado Cargos<small> Consultas</small></h3>
        <ul class="breadcrumb">
          <li><i class="icon-home"></i><a href="land.aspx">Inicio</a><span class="icon-angle-right"></span></li>
          <li>&nbsp;<a href="#">Consulta Cargos</a><span class="icon-angle-right"></span></li>
          <li><a href="#">Listado</a></li>
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
              <i class="icon-reorder"></i><span class="hidden-480">Listado Cargos</span>
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
                    <asp:GridView ID="dgvCargo" runat="server" CellPadding="4" ForeColor="#333333" 
                        GridLines="None">
                        <RowStyle BackColor="#EFF3FB" />
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <EditRowStyle BackColor="#2461BF" />
                        <AlternatingRowStyle BackColor="White" />
                    </asp:GridView>  
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