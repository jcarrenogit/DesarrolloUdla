﻿<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ppal.Master" CodeBehind="frmCargo.aspx.vb" Inherits="wsPrueba.frmCargo" %>
<asp:Content ID="ctTitulo" ContentPlaceHolderID="cphTitulo" runat="server">
    <title>Mantenedor Cargos</title>
</asp:Content>
<asp:Content ID="ctContenido" ContentPlaceHolderID="cphContent" runat="server">
    <!-- BEGIN PAGE CONTAINER-->
  <div class="container-fluid">
    <!-- BEGIN PAGE HEADER-->
    <div class="row-fluid">
      <div class="span12">
        <h3 class="page-title">Mantenedor Cargos<small> <br /> creación y mantención</small></h3>
        <ul class="breadcrumb">
          <li>
            <i class="icon-home"></i>
            <a href="land.aspx">Inicio</a>
            <span class="icon-angle-right"></span>
          </li>
          <li>
            <a href="#">Mantenedor de Cargos</a>
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
              <span class="hidden-480">Información de Cargo</span>
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
                      <label class="control-label">Nombre Cargo</label>
                      <div class="controls"><asp:TextBox ID="txtCargo" CssClass="m-wrap small" runat="server" 
                              AutoPostBack="true"></asp:TextBox></div>
                      
                      <asp:UpdatePanel ID="updLogin" runat="server">
                        <Triggers>
                          <asp:AsyncPostBackTrigger ControlID="txtCargo" EventName="TextChanged" />
                        </Triggers>
                        <ContentTemplate>
                          <div style="color:Black;" id="notificacion" runat="server" visible="false"></div> 
                          <asp:HiddenField ID="hCrea" runat="server" Value="true" />
                          <asp:HiddenField ID="hCodigo" runat="server" Value="true" />
                          <br /><br />
                          <div id="frmUser" runat="server" visible ="false">                 
                            <div class="form-actions">
                              <asp:Button runat="server" ID="btnGuardar" text="Guardar" Visible="false" cssclass="btn blue"/>
                              <asp:Button runat="server" ID="btnModificar" Text="Modificar" visible = "false" cssclass="btn blue" />
                              <asp:Button runat="server" ID="btnVolver" Text="Volver" cssclass="btn blue" />
                            </div>           
                          </div>
                          </div>
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
