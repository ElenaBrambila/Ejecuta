<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="MantenimientoBD.aspx.cs" Inherits="IntegramsaUltimate.MantenimientoBD" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Por favor ingresa el mes y el año</h2> <br />
    <p>Año:  </p> <asp:TextBox runat="server" ID="txtAno" ></asp:TextBox><br />
    <p>Mes: </p> <asp:TextBox runat="server" ID="txtMes"></asp:TextBox> <br />
    <asp:Button runat="server" ID="btnAceptar" Text="Aceptar" OnClick="btnAceptar_Click"/> <br />
    <asp:Label runat="server" ID="lblMensaje" ></asp:Label>

</asp:Content>
