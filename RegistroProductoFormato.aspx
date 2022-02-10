<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="RegistroProductoFormato.aspx.cs" Inherits="IntegramsaUltimate.RegistroProductoFormato" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="basic-form-area mg-tb-15">
        <div class="container-fluid">
            <div class="row">
                <div class="col-lg-7 col-md-7 col-sm-7 col-xs-12">
                    <div class="sparkline8-list mt-b-30">
                        <div class="sparkline8-hd">
                            <div class="main-sparkline8-hd">
                                <h1>Registro de productos por formato</h1>
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
                                            Cadenas:
            <asp:DropDownList runat="server" ID="cboCadenas" DataSourceID="sqlCadenas" DataTextField="nombre" DataValueField="id" AutoPostBack="True" />
                                            <asp:SqlDataSource runat="server" ID="sqlCadenas" ConnectionString='<%$ ConnectionStrings:IntegramsaUltimateConnectionString %>' SelectCommand="SELECT [id], [nombre] FROM [cadena] WHERE ([idEstado] = @idEstado) ORDER BY [nombre]">
                                                <SelectParameters>
                                                    <asp:Parameter DefaultValue="1" Name="idEstado" Type="Int32"></asp:Parameter>
                                                </SelectParameters>
                                            </asp:SqlDataSource>
                                            <br />
                                            <br />

                                            Formatos:<br />
                                            <asp:DropDownList runat="server" ID="cboFormatos" DataSourceID="sqlFormatos" DataTextField="nombre" DataValueField="id" />
                                            <asp:SqlDataSource runat="server" ID="sqlFormatos" ConnectionString='<%$ ConnectionStrings:IntegramsaUltimateConnectionString %>' SelectCommand="SELECT [id], [nombre] FROM [formatoTienda] WHERE (([idEstado] = @idEstado) AND ([idCadena] = @idCadena)) ORDER BY [nombre]">
                                                <SelectParameters>
                                                    <asp:Parameter DefaultValue="1" Name="idEstado" Type="Int32"></asp:Parameter>
                                                    <asp:ControlParameter ControlID="cboCadenas" PropertyName="SelectedValue" Name="idCadena" Type="Int32"></asp:ControlParameter>
                                                </SelectParameters>
                                            </asp:SqlDataSource>
                                            <br />
                                            <br />

                                            Clientes:<br />
                                            <asp:DropDownList runat="server" ID="cboClientes" DataSourceID="sqlCliente" DataTextField="razonSocial" DataValueField="id" AutoPostBack="True" OnSelectedIndexChanged="cboClientes_SelectedIndexChanged" />
                                            <asp:SqlDataSource runat="server" ID="sqlCliente" ConnectionString='<%$ ConnectionStrings:IntegramsaUltimateConnectionString %>' SelectCommand="SELECT [id], [razonSocial] FROM [cliente] order by razonSocial"></asp:SqlDataSource>
                                            <br />
                                            <br />
                                            Segmentos:
                                            <br />
                                            <asp:DropDownList runat="server" ID="cboSegmentos" DataSourceID="SqlDataSource1" DataTextField="segmento" DataValueField="idSegmento" AutoPostBack="true" />
                                            <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:IntegramsaUltimateConnectionString %>' SelectCommand="SELECT [segmento], [idSegmento] FROM [segmentos] WHERE ([idCliente] = @idCliente) order by segmento">
                                                <SelectParameters>
                                                    <asp:ControlParameter ControlID="cboClientes" PropertyName="SelectedValue" Name="idCliente" Type="Int32"></asp:ControlParameter>
                                                </SelectParameters>
                                            </asp:SqlDataSource>
                                            <br />
                                            <br />
                                            <asp:ImageButton runat="server" AlternateText="Guardar" OnClick="btnGuardar_Click" ID="ImageButton1" ImageUrl="Images/btnGuardar-105x48.png" />

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
                                <h1>Productos</h1>
                            </div>
                        </div>
                        Productos (<asp:Label runat="server" ID="lblProductos" />):                


                        <asp:CheckBoxList ID="chkProductos" runat="server" DataSourceID="sqlProductos" DataTextField="producto" DataValueField="id" OnDataBound="chkProductos_DataBound"></asp:CheckBoxList>

                        <asp:SqlDataSource runat="server" ID="sqlProductos" ConnectionString='<%$ ConnectionStrings:IntegramsaUltimateConnectionString %>' SelectCommand="SELECT producto.id, producto.nombre + '/' + producto.presentacion AS producto FROM producto INNER JOIN segmentoProductos ON producto.id = segmentoProductos.idProducto WHERE (producto.idCliente = @idCliente) AND (producto.idEstado = 1) AND (segmentoProductos.idSegmento = @idSegmento) ORDER BY producto">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="cboClientes" PropertyName="SelectedValue" Name="idCliente" Type="Int32"></asp:ControlParameter>
                                <asp:ControlParameter ControlID="cboSegmentos" PropertyName="SelectedValue" Name="idSegmento"></asp:ControlParameter>
                            </SelectParameters>
                        </asp:SqlDataSource>
                        <br />
                    </div>
                </div>
            </div>
        </div>
    </div>






    <div>

        <%--        <asp:ImageButton runat="server" AlternateText="Guardar" OnClick="btnGuardar_Click" ID="btnGuardar" ImageUrl="Images/btnGuardar-105x48.png" />--%>
    </div>

</asp:Content>
