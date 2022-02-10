<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ReporteParticipacionSegmento.aspx.cs" Inherits="IntegramsaUltimate.ReporteParticipacionSegmento" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
                                <h1>Reporte de participación</h1>
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
            <asp:DropDownList runat="server" ID="cboClientes" DataSourceID="sqlCliente" DataTextField="razonSocial" DataValueField="id" AutoPostBack="True" />
                                            <asp:SqlDataSource runat="server" ID="sqlCliente" ConnectionString='<%$ ConnectionStrings:IntegramsaUltimateConnectionString %>' SelectCommand="SELECT [id], [razonSocial] FROM [cliente]"></asp:SqlDataSource>
                                            <br />

                                            <asp:RadioButton runat="server" ID="rdoCadenas" Text="Cadenas" />
                                            <asp:DropDownList runat="server" ID="cboCadenas" DataSourceID="sqlCadenas" DataTextField="nombre" DataValueField="id" />
                                                <asp:SqlDataSource runat="server" ID="sqlCadenas" ConnectionString='<%$ ConnectionStrings:IntegramsaUltimateConnectionString %>' SelectCommand="SELECT [id], [nombre] FROM [cadena] ORDER BY [nombre]"></asp:SqlDataSource>

                                            <br />
                                            <br />
                                            Segmentos:
                                               <asp:DropDownList runat="server" ID="cboSegmentos" DataSourceID="sqlSegmentos" DataTextField="segmento" DataValueField="idSegmento" />
                                            <asp:SqlDataSource runat="server" ID="sqlSegmentos" ConnectionString='<%$ ConnectionStrings:IntegramsaUltimateConnectionString %>' SelectCommand="SELECT [segmento], [idSegmento] FROM [segmentos] WHERE ([idCliente] = @idCliente) ORDER BY [segmento]">
                                                <SelectParameters>
                                                    <asp:ControlParameter ControlID="cboClientes" PropertyName="SelectedValue" Name="idCliente" Type="Int32"></asp:ControlParameter>
                                                </SelectParameters>
                                            </asp:SqlDataSource>
                                            <asp:CheckBoxList runat="server" ID="chkSegmentos" DataSourceID="sqlSegmentos" DataTextField="segmento" DataValueField="idSegmento" />
                                            <asp:Label runat="server" ID="lblMensaje" />
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
                        <asp:ImageButton ImageUrl="Images/btnGenerar.png" AlternateText="Generar" runat="server" OnClick="btnDescargar_Click" ID="btnDescargar" />

                    </div>
                </div>
            </div>
        </div>
    </div>


    <br />
    <br />

    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="1000px">
        <LocalReport ReportPath="rptRepParticipacionCadena.rdlc">
            <DataSources>
                <rsweb:ReportDataSource Name="DataSet1" DataSourceId="ObjectDataSource1"></rsweb:ReportDataSource>
            </DataSources>
        </LocalReport>
    </rsweb:ReportViewer>

    <asp:ObjectDataSource runat="server" SelectMethod="GetData" TypeName="IntegramsaUltimate.IntegramsaUltimateDataSetTableAdapters.vwReporteParticipacionTableAdapter" ID="ObjectDataSource1"></asp:ObjectDataSource>
</asp:Content>