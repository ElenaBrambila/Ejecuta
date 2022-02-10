<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmSegmentos.aspx.cs" Inherits="IntegramsaUltimate.frmSegmentos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Cadenas:
            <asp:DropDownList runat="server" ID="cboCadenas" DataSourceID="sqlCadenas" DataTextField="nombre" DataValueField="id" AutoPostBack="True" />
            <asp:SqlDataSource runat="server" ID="sqlCadenas" ConnectionString='<%$ ConnectionStrings:IntegramsaUltimateConnectionString %>' SelectCommand="SELECT [id], [nombre] FROM [cadena] WHERE ([idEstado] = @idEstado) ORDER BY [nombre]">
                <SelectParameters>
                    <asp:Parameter DefaultValue="1" Name="idEstado" Type="Int32"></asp:Parameter>
                </SelectParameters>
            </asp:SqlDataSource>
            <br />

            Formatos:
            <asp:DropDownList runat="server" ID="cboFormatos" DataSourceID="sqlFormatos" DataTextField="nombre" DataValueField="id" />
            <asp:SqlDataSource runat="server" ID="sqlFormatos" ConnectionString='<%$ ConnectionStrings:IntegramsaUltimateConnectionString %>' SelectCommand="SELECT [id], [nombre] FROM [formatoTienda] WHERE (([idEstado] = @idEstado) AND ([idCadena] = @idCadena)) ORDER BY [nombre]">
                <SelectParameters>
                    <asp:Parameter DefaultValue="1" Name="idEstado" Type="Int32"></asp:Parameter>
                    <asp:ControlParameter ControlID="cboCadenas" PropertyName="SelectedValue" Name="idCadena" Type="Int32"></asp:ControlParameter>
                </SelectParameters>
            </asp:SqlDataSource>
            <br />

            Clientes:
            <asp:DropDownList runat="server" ID="cboClientes" DataSourceID="sqlCliente" DataTextField="razonSocial" DataValueField="id" AutoPostBack="True" />
            <asp:SqlDataSource runat="server" ID="sqlCliente" ConnectionString='<%$ ConnectionStrings:IntegramsaUltimateConnectionString %>' SelectCommand="SELECT [id], [razonSocial] FROM [cliente]"></asp:SqlDataSource>
            <br />
            Segmentos:
            <asp:DropDownList runat="server" ID="cboSegmentos" DataSourceID="SqlDataSource1" DataTextField="segmento" DataValueField="idSegmento" />
            <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:IntegramsaUltimateConnectionString %>' SelectCommand="SELECT [segmento], [idSegmento] FROM [segmentos] WHERE ([idCliente] = @idCliente)">
                <SelectParameters>
                    <asp:ControlParameter ControlID="cboClientes" PropertyName="SelectedValue" Name="idCliente" Type="Int32"></asp:ControlParameter>
                </SelectParameters>
            </asp:SqlDataSource><br />
            Productos:
            <asp:CheckBoxList ID="chkProductos" runat="server" DataSourceID="sqlProductos" DataTextField="producto" DataValueField="id"></asp:CheckBoxList>

            <asp:SqlDataSource runat="server" ID="sqlProductos" ConnectionString='<%$ ConnectionStrings:IntegramsaUltimateConnectionString %>' SelectCommand="SELECT id, nombre + '/' + presentacion AS producto FROM producto WHERE (idCliente = @idCliente) AND (idEstado = 1) ORDER BY producto">
                <SelectParameters>
                    <asp:ControlParameter ControlID="cboClientes" PropertyName="SelectedValue" Name="idCliente" Type="Int32"></asp:ControlParameter>
                </SelectParameters>
            </asp:SqlDataSource>
            <br />

        </div>
    </form>
</body>
</html>
