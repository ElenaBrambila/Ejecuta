<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="TipoFotosNueva.aspx.cs" Inherits="IntegramsaUltimate.TipoFotosNueva" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Nuevo tipo de foto</h2>
    <asp:TextBox runat="server" ID="txtNuevo" Width="400px"/>
    <br /><br />
     <h4>Cliente:</h4>
    <asp:DropDownList runat="server" ID="cboClientes" Width="400px" DataSourceID="sqlClientes" DataTextField="razonSocial" DataValueField="id" />
    <asp:SqlDataSource runat="server" ID="sqlClientes" ConnectionString='<%$ ConnectionStrings:IntegramsaUltimateConnectionString1 %>' SelectCommand="SELECT * FROM [cliente] WHERE ([idEstado] = @idEstado)">
        <SelectParameters>
            <asp:Parameter DefaultValue="1" Name="idEstado" Type="Int32"></asp:Parameter>
        </SelectParameters>
    </asp:SqlDataSource>

    <br /><br />
    <h4>Estatus:</h4>
    <asp:DropDownList runat="server" ID="cboEstatus" DataSourceID="sqlEstatus" DataTextField="nombre" DataValueField="id" Width="400px" />
    <asp:SqlDataSource runat="server" ID="sqlEstatus" ConnectionString='<%$ ConnectionStrings:IntegramsaUltimateConnectionString %>' SelectCommand="SELECT [id], [nombre] FROM [cEstado]"></asp:SqlDataSource>
    <br /><br />
    <asp:Button runat="server" ID="btnGuardar" Text="Guardar"  OnClick="btnGuardar_Click"/><asp:Button runat="server" ID="btnCancelar" OnClick="btnCancelar_Click" Text="Cancelar" />
</asp:Content>
