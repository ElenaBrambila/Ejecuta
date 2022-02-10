﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="DescargarImagenes.aspx.cs" Inherits="IntegramsaUltimate.DescargarImagenes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="basic-form-area mg-tb-15">
        <div class="container-fluid">
            <div class="row">
                <div class="col-lg-7 col-md-7 col-sm-7 col-xs-12">
                    <div class="sparkline8-list mt-b-30">
                        <div class="sparkline8-hd">
                            <div class="main-sparkline8-hd">
                                <h1>Reporte fotográfico</h1>
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
            <asp:DropDownList runat="server" ID="cboClientes" DataSourceID="sqlCliente" DataTextField="razonSocial" DataValueField="id" AutoPostBack="True" OnSelectedIndexChanged="cboClientes_SelectedIndexChanged" />
                                            <asp:SqlDataSource runat="server" ID="sqlCliente" ConnectionString='<%$ ConnectionStrings:IntegramsaUltimateConnectionString %>' SelectCommand="SELECT [id], [razonSocial] FROM [cliente] order by razonSocial"></asp:SqlDataSource>
                                            <br />

                                            Ruta:
    <asp:DropDownList runat="server" ID="cboRutas" DataSourceID="sqlRutas" DataTextField="ruta" DataValueField="id" />
                                            <asp:SqlDataSource runat="server" ID="sqlRutas" ConnectionString='<%$ ConnectionStrings:IntegramsaUltimateConnectionString %>' SelectCommand="SELECT ruta.id, ruta.codigoRuta + '/' + usuario.nombre + ' ' + usuario.paterno AS ruta FROM ruta INNER JOIN usuario ON ruta.idPromotor = usuario.id WHERE ([idCliente] = @idCliente)">
                                                <SelectParameters>
                                                    <asp:ControlParameter ControlID="cboClientes" PropertyName="SelectedValue" Name="idCliente" Type="Int32"></asp:ControlParameter>
                                                </SelectParameters>
                                            </asp:SqlDataSource>
                                            <br />
                                            Promotor:
                                            <asp:Button runat="server" ID="btnSelectAll" OnClick="btnSelectAll_Click" Text="Seleccionar todos"/>

                                            <asp:UpdateProgress ID="UpdateProgress2" AssociatedUpdatePanelID="UpdatePanel3" runat="server">
                                                <ProgressTemplate>
                                                    Descargando...<br />
                                                    <img alt="progress" src="Images/descargando.gif" />
                                                </ProgressTemplate>
                                            </asp:UpdateProgress>
                                            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                <ContentTemplate>
                                                    <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
                                                    <br />
                                                    <br />
                                                    <asp:ImageButton ImageUrl="Images/btnDescargar.jpg" AlternateText="Generar" runat="server" OnClick="btnDescargar1_Click" ID="btnDescargar1" />
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                            <%--    <asp:DropDownList runat="server" ID="cboPromotor" />--%>
                                            
                                            <asp:CheckBoxList runat="server" ID="cboPromotor" Width="500px" />

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

                        <br />
                        <br />
                        Fecha inicio :
                        <asp:TextBox ID="dtInicio" runat="server" TextMode="Date"></asp:TextBox>
                        <br />
                        Fecha fin :
                        <asp:TextBox ID="dtFin" runat="server" TextMode="Date"></asp:TextBox>
                        <br />

                    </div>
                </div>
            </div>
        </div>
    </div>


    <br />
    <br />


    <asp:UpdateProgress ID="updProgress" AssociatedUpdatePanelID="UpdatePanel1" runat="server">
        <ProgressTemplate>
            Descargando...<br />
            <img alt="progress" src="Images/descargando.gif" />

        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Label ID="lblText" runat="server" Text=""></asp:Label>
            <br />
            <br />
            <asp:ImageButton ImageUrl="Images/btnDescargar.jpg" AlternateText="Generar" runat="server" OnClick="btnDescargar_Click" ID="btnDescargar" />
        </ContentTemplate>
    </asp:UpdatePanel>


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
            <asp:ImageButton ImageUrl="Images/btnGenerar.png" AlternateText="Generar" runat="server" OnClick="btnGenerar_Click" ID="ImageButton1" />
        </ContentTemplate>
    </asp:UpdatePanel>

    <asp:GridView ID="GridView1" runat="server">
    </asp:GridView>


</asp:Content>
