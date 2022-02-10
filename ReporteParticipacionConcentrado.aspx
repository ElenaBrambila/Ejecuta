<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ReporteParticipacionConcentrado.aspx.cs" Inherits="IntegramsaUltimate.ReporteParticipacionConcentrado" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <!-- inicio de submenu de reporte -->
    <div class="section-admin container-fluid">
        <div class="row admin text-center">
            <div class="col-md-12">
                <div class="row">
                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
                        <div class="admin-content analysis-progrebar-ctn res-mg-t-15">
                            <br />
                            <br />
                            <a href="ReporteParticipacionCiudad.aspx">
                                <div class="row vertical-center-box vertical-center-box-tablet">
                                    <div class="col-xs-3 mar-bot-15 text-left">

                                        <label class="label bg-green">Reporte por <i class="fa fa-globe sub-icon-mg" aria-hidden="true"></i></label>

                                    </div>
                                    <div class="col-xs-9 cus-gh-hd-pro">
                                        <h2 class="text-right no-margin">ciudad</h2>
                                    </div>
                                </div>
                            </a>
                            <div class="progress progress-mini">
                                <div style="width: 78%;" class="progress-bar bg-green"></div>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12" style="margin-bottom: 1px;">
                        <div class="admin-content analysis-progrebar-ctn res-mg-t-30">
                            <br />
                            <br />
                            <a href="ReporteParticipacionCadena.aspx">
                                <div class="row vertical-center-box vertical-center-box-tablet">
                                    <div class="text-left col-xs-3 mar-bot-15">

                                        <label class="label bg-red">Reporte por <i class="fa fa-bookmark" aria-hidden="true"></i></label>

                                    </div>
                                    <div class="col-xs-9 cus-gh-hd-pro">
                                        <h2 class="text-right no-margin">cadena</h2>
                                    </div>
                                </div>
                            </a>
                            <div class="progress progress-mini">
                                <div style="width: 38%;" class="progress-bar progress-bar-danger bg-red"></div>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
                        <div class="admin-content analysis-progrebar-ctn res-mg-t-30">
                            <br />
                            <br />
                            <a href="ReporteParticipacionPromotor.aspx">
                                <div class="row vertical-center-box vertical-center-box-tablet">
                                    <div class="text-left col-xs-3 mar-bot-15">
                                        <label class="label bg-blue">Reporte por <i class="fa fa-female" aria-hidden="true"></i></label>
                                    </div>
                                    <div class="col-xs-9 cus-gh-hd-pro">
                                        <h2 class="text-right no-margin">promotor</h2>
                                    </div>
                                </div>
                            </a>
                            <div class="progress progress-mini">
                                <div style="width: 60%;" class="progress-bar bg-blue"></div>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
                        <div class="admin-content analysis-progrebar-ctn res-mg-t-30">
                            <br />
                            <br />
                            <a href="ReporteParticipacionProducto.aspx">
                                <div class="row vertical-center-box vertical-center-box-tablet">
                                    <div class="text-left col-xs-3 mar-bot-15">
                                        <label class="label bg-purple">Reporte por <i class="fa fa-heart-o" aria-hidden="true"></i></label>
                                    </div>
                                    <div class="col-xs-9 cus-gh-hd-pro">
                                        <h2 class="text-right no-margin">producto</h2>
                                    </div>
                                </div>
                            </a>
                            <div class="progress progress-mini">
                                <div style="width: 60%;" class="progress-bar bg-purple"></div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <!--fin de submenu de reporte -->

    <!--Comienza información del reporte -->
    <div class="basic-form-area mg-tb-15">
        <div class="container-fluid">
            <div class="row">
                <div class="col-lg-7 col-md-7 col-sm-7 col-xs-12">
                    <div class="sparkline8-list mt-b-30">
                        <div class="sparkline8-hd">
                            <div class="main-sparkline8-hd">
                                <h1>Concentrado de participación</h1>
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
                                            <%--    Clientes:
            <asp:DropDownList runat="server" ID="cboClientes" DataSourceID="sqlCliente" DataTextField="razonSocial" DataValueField="id" AutoPostBack="True" />
                                            <asp:SqlDataSource runat="server" ID="sqlCliente" ConnectionString='<%$ ConnectionStrings:IntegramsaUltimateConnectionString %>' SelectCommand="SELECT [id], [razonSocial] FROM [cliente]"></asp:SqlDataSource>
                                            <br />

                                            <asp:RadioButton runat="server" ID="rdoCadenas" Text="Cadenas" />
                                            <asp:DropDownList runat="server" ID="cboCadenas" DataSourceID="sqlCadenas" DataTextField="nombre" DataValueField="id" />--%>

                                            <br />


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

                        Fecha inicio :
    <asp:TextBox ID="dtInicio" runat="server" TextMode="Date"></asp:TextBox>
                        <br />
                        Fecha fin     :
    <asp:TextBox ID="dtFin" runat="server" TextMode="Date"></asp:TextBox>
                        <br />
                        <br />

                    </div>
                </div>
            </div>
        </div>


        <asp:GridView ID="gdDatos" runat="server" AutoGenerateColumns="False" DataSourceID="sqlConcentrado" Width="900px">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="id" SortExpression="ID"></asp:BoundField>
                <asp:BoundField DataField="CantidadProducto" HeaderText="cantidadProducto" SortExpression="cantidadProducto"></asp:BoundField>
                <asp:BoundField DataField="idProducto" HeaderText="idProducto" SortExpression="idProducto" Visible="false"></asp:BoundField>
                <asp:BoundField DataField="cantidadSegmentos" HeaderText="cantidadSegmentos" ReadOnly="True" SortExpression="cantidadSegmentos"></asp:BoundField>
                <asp:BoundField DataField="Participacion" HeaderText="Participación" ReadOnly="True" SortExpression="Participacion"></asp:BoundField>
                <asp:BoundField DataField="nombre" HeaderText="Producto" SortExpression="nombre" ></asp:BoundField>
                <asp:BoundField DataField="presentacion" HeaderText="Presentación" SortExpression="presentacion"></asp:BoundField>
                <asp:BoundField DataField="sku" HeaderText="SKU" SortExpression="sku"></asp:BoundField>
                <asp:BoundField DataField="idSegmento" HeaderText="idSegmento" SortExpression="idSegmento" Visible="false"></asp:BoundField>
                <asp:BoundField DataField="segmento" HeaderText="Segmento" SortExpression="segmento"></asp:BoundField>
                <asp:BoundField DataField="idCliente" HeaderText="idCliente" SortExpression="idCliente" Visible="false"></asp:BoundField>
                <asp:BoundField DataField="plaza" HeaderText="plaza" SortExpression="plaza"></asp:BoundField>
                <asp:BoundField DataField="municipio" HeaderText="municipio" SortExpression="municipio"></asp:BoundField>
                <asp:BoundField DataField="idPlaza" HeaderText="idPlaza" SortExpression="idPlaza" Visible="false"></asp:BoundField>
                <asp:BoundField DataField="idcMunicipio" HeaderText="idcMunicipio" SortExpression="idcMunicipio" Visible="false"></asp:BoundField>
                <asp:BoundField DataField="idCadena" HeaderText="idCadena" SortExpression="idCadena" Visible="false"></asp:BoundField>
                <asp:BoundField DataField="cadena" HeaderText="cadena" SortExpression="cadena"></asp:BoundField>
                <asp:BoundField DataField="idFormatoTienda" HeaderText="idFormatoTienda" SortExpression="idFormatoTienda"></asp:BoundField>
                <asp:BoundField DataField="formato" HeaderText="Formato" SortExpression="formato"></asp:BoundField>
                <asp:BoundField DataField="tienda" HeaderText="Tienda" SortExpression="tienda"></asp:BoundField>
                <asp:BoundField DataField="fecha" HeaderText="Fecha" ReadOnly="True" SortExpression="fecha"></asp:BoundField>
                <asp:BoundField DataField="idReporteTienda" HeaderText="idReporteTienda" SortExpression="idReporteTienda"></asp:BoundField>
            </Columns>
        </asp:GridView>

    </div>


    <br />
    <br />



    <asp:SqlDataSource runat="server" ID="sqlConcentrado" ConnectionString='<%$ ConnectionStrings:IntegramsaUltimateConnectionString %>' SelectCommand="SELECT * FROM [vwReporteParticipacionxFecha] WHERE (CAST(fecha AS DATE)  >=  CAST(@fecha1 AS DATE)) AND( CAST(fecha AS DATE) <= CAST(@fecha2 AS DATE))">
        <SelectParameters>
            <asp:ControlParameter ControlID="dtInicio" PropertyName="Text" Name="fecha" Type="String"></asp:ControlParameter>
            <asp:ControlParameter ControlID="dtFin" PropertyName="Text" Name="fecha2" Type="String"></asp:ControlParameter>
        </SelectParameters>
    </asp:SqlDataSource>

    <asp:SqlDataSource runat="server" ID="sqlConcentrado2" ConnectionString='<%$ ConnectionStrings:IntegramsaUltimateConnectionString %>' SelectCommand="SELECT * FROM [vwReporteParticipacionxFecha] where fecha between dtInicio and dtFin ORDER BY [Participacion] DESC"></asp:SqlDataSource>
</asp:Content>

