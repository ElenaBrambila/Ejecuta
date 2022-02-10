<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="TipoFotos.aspx.cs" Inherits="IntegramsaUltimate.TipoFotos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>Propósito de fotografía</h3>
    <br />
    <h4>Nombre del propósito</h4>
    <asp:DropDownList runat="server" ID="cboProposito" DataSourceID="sqlTipoProposito" DataTextField="tipoProposito" DataValueField="id" Width="400px" OnSelectedIndexChanged="cboProposito_SelectedIndexChanged" AutoPostBack="true"/>
    <asp:SqlDataSource runat="server" ID="sqlTipoProposito" ConnectionString='<%$ ConnectionStrings:IntegramsaUltimateConnectionString1 %>' SelectCommand="SELECT cFotoProposito.id, cFotoProposito.nombre + ' /  ' + cliente.razonSocial AS tipoProposito FROM cFotoProposito LEFT OUTER JOIN cliente ON cFotoProposito.idCliente = cliente.id ORDER BY cFotoProposito.nombre"></asp:SqlDataSource>
    <br /><br />
   
    <h4>Estatus:</h4>
    <asp:DropDownList runat="server" ID="cboEstatus" DataSourceID="sqlEstatus" DataTextField="nombre" DataValueField="id" Width="400px" />
    <asp:SqlDataSource runat="server" ID="sqlEstatus" ConnectionString='<%$ ConnectionStrings:IntegramsaUltimateConnectionString %>' SelectCommand="SELECT [id], [nombre] FROM [cEstado]"></asp:SqlDataSource>
    <br /><br />
    <asp:Button runat="server" ID="btnNuevo" Text="Nuevo" OnClick="btnNuevo_Click" /><asp:Button runat="server" id="btnEditar" Text="Editar" OnClick="btnEditar_Click"/>
        <asp:Button runat="server" ID="btnEliminar" Text="Eliminar" OnClick="btnEliminar_Click"/><br />
    <asp:Label runat="server" ID="lblMensaje" />

</asp:Content>
