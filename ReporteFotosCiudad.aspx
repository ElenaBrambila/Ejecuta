<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ReporteFotosCiudad.aspx.cs" Inherits="IntegramsaUltimate.ReporteFotosCiudad" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="section-admin container-fluid">
        <div class="row admin text-center">
            <div class="col-md-12">
                <div class="row">
                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
                        <div class="admin-content analysis-progrebar-ctn res-mg-t-15">
                            <br />
                            <br />
                            <div class="row vertical-center-box vertical-center-box-tablet">
                               <a href="ReporteFotosCiudad.aspx">   <div class="col-xs-3 mar-bot-15 text-left">
                                 <label class="label bg-green">Reporte por <i class="fa fa-globe sub-icon-mg" aria-hidden="true"></i></label>
                                </div>
                                <div class="col-xs-9 cus-gh-hd-pro">
                                    <h2 class="text-right no-margin">ciudad</h2>
                                </div></a>
                            </div>
                            <div class="progress progress-mini">
                                <div style="width: 78%;" class="progress-bar bg-green"></div>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12" style="margin-bottom: 1px;">
                        <div class="admin-content analysis-progrebar-ctn res-mg-t-30">
                            <br />
                            <br />
                            <div class="row vertical-center-box vertical-center-box-tablet">
                                <div class="text-left col-xs-3 mar-bot-15">
                                    <label class="label bg-red">Reporte por <i class="fa fa-bookmark" aria-hidden="true"></i></label>
                                </div>
                                <div class="col-xs-9 cus-gh-hd-pro">
                                    <h2 class="text-right no-margin">cadena</h2>
                                </div>
                            </div>
                            <div class="progress progress-mini">
                                <div style="width: 38%;" class="progress-bar progress-bar-danger bg-red"></div>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
                        <div class="admin-content analysis-progrebar-ctn res-mg-t-30">
                            <br />
                            <br />
                            <div class="row vertical-center-box vertical-center-box-tablet">
                                <div class="text-left col-xs-3 mar-bot-15">
                                    <label class="label bg-blue">Reporte por <i class="fa fa-female" aria-hidden="true"></i></label>
                                </div>
                                <div class="col-xs-9 cus-gh-hd-pro">
                                    <h2 class="text-right no-margin">promotor</h2>
                                </div>
                            </div>
                            <div class="progress progress-mini">
                                <div style="width: 60%;" class="progress-bar bg-blue"></div>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
                        <div class="admin-content analysis-progrebar-ctn res-mg-t-30">
                            <br />
                            <br />
                            <div class="row vertical-center-box vertical-center-box-tablet">
                                <div class="text-left col-xs-3 mar-bot-15">
                                    <label class="label bg-purple">Reporte por <i class="fa fa-heart-o" aria-hidden="true"></i></label>
                                </div>
                                <div class="col-xs-9 cus-gh-hd-pro">
                                    <h2 class="text-right no-margin">producto</h2>
                                </div>
                            </div>
                            <div class="progress progress-mini">
                                <div style="width: 60%;" class="progress-bar bg-purple"></div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
         <asp:ScriptManager ID="ScriptManager1" runat="server">
                                            </asp:ScriptManager>
    <!--Comienza contenido del reporte -->
    <div class="basic-form-area mg-tb-15">
        <div class="container-fluid">
            <div class="row">
                <div class="col-lg-7 col-md-7 col-sm-7 col-xs-12">
                    <div class="sparkline8-list mt-b-30">
                        <div class="sparkline8-hd">
                            <div class="main-sparkline8-hd">
                                <h1>Reporte fotográfico por ciudad</h1>
                            </div>
                        </div>
                        <div class="sparkline8-graph">
                            <div class="basic-login-form-ad">
                                <div class="row">
                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                                        <div class="basic-login-inner">
                                            Clientes:
            <asp:DropDownList runat="server" ID="cboClientes" DataSourceID="sqlCliente" DataTextField="razonSocial" DataValueField="id" AutoPostBack="True"  />
                                            <asp:SqlDataSource runat="server" ID="sqlCliente" ConnectionString='<%$ ConnectionStrings:IntegramsaUltimateConnectionString %>' SelectCommand="SELECT [id], [razonSocial] FROM [cliente] order by razonSocial"></asp:SqlDataSource>
                                            <br />

                                            Plaza:   
                                             
                                            
                                            <br />
                                            <asp:DropDownList runat="server" ID="cboPlaza" DataSourceID="sqlPlazas" DataTextField="nombre" DataValueField="id" AutoPostBack="true" />
                                             <asp:UpdateProgress ID="UpdateProgress2" AssociatedUpdatePanelID="UpdatePanel2" runat="server">
                                                <ProgressTemplate>
                                                    Generando...<br />
                                                    <img alt="progress" src="Images/descargando.gif" />

                                                </ProgressTemplate>
                                            </asp:UpdateProgress>
                                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                <ContentTemplate>
                                                    <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
                                                    <br />
                                                    <br />
                                                    <!-- ImageUrl="Images/icon_filter.png" -->
                                                    <asp:ImageButton ImageUrl="Images/btnGenerarXPlaza.jpg"  AlternateText="Generar reporte por plaza" runat="server" OnClick="btnGenerarPlaza_Click1" ID="btnGenerarPlaza2" Text="Reporte por plaza" />
                                                    <asp:Label ID="lblMensajePlaza" runat="server"/>
                                                
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                            <asp:SqlDataSource runat="server" ID="sqlPlazas" ConnectionString='<%$ ConnectionStrings:IntegramsaUltimateConnectionString %>' SelectCommand="SELECT * FROM [cPlaza] ORDER BY [nombre]"></asp:SqlDataSource>
                                            <br />
                                            Ciudad:<br /><asp:ImageButton runat="server" ID="btnTodasCiudades" ImageUrl="~/Images/sort-icon.png" OnClick="btnTodasCiudades_Click"/>
                                            <asp:DropDownList runat="server" ID="cboCiudad" DataSourceID="sqlCiudadesPlazas" DataTextField="Nombre" DataValueField="idcMunicipio" />
                                            <%--    <asp:DropDownList runat="server" ID="cboPromotor" />--%>
                                            <asp:CheckBoxList runat="server" ID="chkCiudad" DataSourceID="sqlCiudadesPlazas" DataTextField="Nombre" DataValueField="idcMunicipio" Visible="false" />

                                            <asp:SqlDataSource runat="server" ID="sqlCiudadesPlazas" ConnectionString='<%$ ConnectionStrings:IntegramsaUltimateConnectionString %>' SelectCommand="SELECT cmunicipio.Nombre, cmunicipio.idcMunicipio FROM cmunicipio INNER JOIN PlazaMunicipio ON cmunicipio.idcMunicipio = PlazaMunicipio.idMunicipio WHERE ([idPlaza] = @idPlaza) order by cmunicipio.Nombre">
                                            <SelectParameters>
                                                    <asp:ControlParameter ControlID="cboPlaza" PropertyName="SelectedValue" Name="idPlaza" Type="Int32"></asp:ControlParameter>
                                                </SelectParameters>
                                            </asp:SqlDataSource>
                                            <asp:SqlDataSource runat="server" ID="sqlCiudades" ConnectionString='<%$ ConnectionStrings:IntegramsaUltimateConnectionString %>' SelectCommand="SELECT [id], [idMunicipio] FROM [PlazaMunicipio] WHERE ([idPlaza] = @idPlaza) order by PlazaMunicipio">
                                              
                                            </asp:SqlDataSource>
                                            <br />
                                       
                                                <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel2" runat="server">
                                                <ProgressTemplate>
                                                    Generando...<br />
                                                    <img alt="progress" src="Images/descargando.gif" />

                                                </ProgressTemplate>
                                            </asp:UpdateProgress>
                                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                <ContentTemplate>
                                                    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                                                    <br />
                                                    <br />
                                                    <asp:ImageButton ImageUrl="Images/btnGenerarXCiudad.jpg" AlternateText="Generar" runat="server" OnClick="btnGenerar_Click" ID="ImageButton1" />
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>
                                    <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-lg-5 col-md-5 col-sm-5 col-xs-12">
                    <div class="sparkline9-list responsive-mg-b-30">
                        <div class="sparkline9-hd">
                            <div class="main-sparkline9-hd">
                                <h1>Rango de fechas</h1>
                            </div>
                        </div>
                        <br />
                        <br />
                        Fecha inicio :
    <asp:TextBox ID="dtInicio" runat="server" TextMode="Date"></asp:TextBox>
                        <br />
                        Fecha fin :
    <asp:TextBox ID="dtFin" runat="server" TextMode="Date"></asp:TextBox>
                        <br />
                        <br />
                                                <asp:Button Text="Actualizar" runat="server" ID="btnActualizar" OnClick="btnActualizar_Click" />

                      
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!--Fin del contenido de filtros del reporte -->


    <rsweb:reportviewer id="ReportViewer1" runat="server" font-names="Verdana" font-size="8pt" waitmessagefont-names="Verdana" waitmessagefont-size="14pt" width="800px" height="800px" BackColor="" ClientIDMode="AutoID" HighlightBackgroundColor="" InternalBorderColor="204, 204, 204" InternalBorderStyle="Solid" InternalBorderWidth="1px" LinkActiveColor="" LinkActiveHoverColor="" LinkDisabledColor="" PrimaryButtonBackgroundColor="" PrimaryButtonForegroundColor="" PrimaryButtonHoverBackgroundColor="" PrimaryButtonHoverForegroundColor="" SecondaryButtonBackgroundColor="" SecondaryButtonForegroundColor="" SecondaryButtonHoverBackgroundColor="" SecondaryButtonHoverForegroundColor="" SplitterBackColor="" ToolbarDividerColor="" ToolbarForegroundColor="" ToolbarForegroundDisabledColor="" ToolbarHoverBackgroundColor="" ToolbarHoverForegroundColor="" ToolBarItemBorderColor="" ToolBarItemBorderStyle="Solid" ToolBarItemBorderWidth="1px" ToolBarItemHoverBackColor="" ToolBarItemPressedBorderColor="51, 102, 153" ToolBarItemPressedBorderStyle="Solid" ToolBarItemPressedBorderWidth="1px" ToolBarItemPressedHoverBackColor="153, 187, 226">
        <LocalReport ReportPath="rptRepFotosSimple.rdlc" EnableExternalImages="True">
           
        </LocalReport>
    </rsweb:reportviewer>


    <asp:SqlDataSource ID="sqlGeneral" runat="server" ConnectionString="<%$ ConnectionStrings:IntegramsaUltimateConnectionString %>" SelectCommand="SELECT * FROM [vwReporteFotos]"></asp:SqlDataSource>


    <asp:ObjectDataSource runat="server" SelectMethod="GetData" TypeName="IntegramsaUltimate.IntegramsaUltimateDataSetTableAdapters.vwReporteFotosTableAdapter" ID="ObjectDataSource1"></asp:ObjectDataSource>
</asp:Content>
