<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ppal.Master" CodeBehind="frServicios.aspx.vb" Inherits="wsPrueba.frServicios" %>
<asp:Content ID="cthUsr" ContentPlaceHolderID="cphTitulo" runat="server">
<title>Mantenedor Servicios</title>
</asp:Content>

<asp:Content ID="cthUsuario" ContentPlaceHolderID="cphContent" runat="server">
<!-- BEGIN PAGE CONTAINER-->
			<div class="container-fluid">
				<!-- BEGIN PAGE HEADER-->   
				<div class="row-fluid">
					<div class="span12">
						<h3 class="page-title">
							Mantenedor Servicios
							<small>creación y mantención</small>
						</h3>
						<ul class="breadcrumb">
							<li>
								<i class="icon-home"></i>
								<a href="land.aspx">Inicio</a> 
								<span class="icon-angle-right"></span>
							</li>
							<li>
								<a href="#">Mantenedor de Servicios</a>
								<span class="icon-angle-right"></span>
							</li>
							<li>
								<a href="#">Agregar</a>
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
									<span class="hidden-480">Información de Servicios</span>
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
													<label class="control-label">Nombre</label>
													<div class="controls">
														<asp:TextBox ID="txtLogin" class="m-wrap small" runat="server"></asp:TextBox>
													</div>
													<br />
													<label class="control-label">Descripcion</label>
													<div class="controls">
														<asp:TextBox ID="txtNombre" class="m-wrap small" runat="server"></asp:TextBox>
													</div>
													<br />
													<label class="control-label">Funcionalidad</label>
													<div class="controls">
														<asp:DropDownList runat="server" ID="cmbFuncionalidad"></asp:DropDownList>
													</div>
													<br />
													<label class="control-label">Area</label>
													<div class="controls">
														<asp:DropDownList runat="server" ID="cmbArea" Height="30px" Width="220px"></asp:DropDownList>
													</div>
													<br />
												    <div class="control-group">
													<label class="control-label">Estado</label>
													<div class="controls">
													    <asp:DropDownList runat="server" ID="cmbEstado">
                                                            <asp:ListItem Value="0">Activo</asp:ListItem>
                                                            <asp:ListItem Value="1">Inactivo</asp:ListItem>
                                                            <asp:ListItem Value="3">Bloqueado</asp:ListItem>
                                                        </asp:DropDownList>
												    </div>
												</div>
												
												<div class="form-actions">
													<asp:Button runat="server" ID="btnGuardar" text="Guardar" cssclass="btn blue"/>
													<asp:Button runat="server" ID="btnCancelar" Text="Cancelar" cssclass="btn" />
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
