<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Fotos.aspx.cs" Inherits="IntegramsaUltimate.Fotos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Información de la fotografía</h2> <br />

    <asp:Label runat="server" ID="lblInfo" /><br />
    <h5>Comentario de la fotografía</h5><br />
    <asp:TextBox runat="server" ID="txtComentario" TextMode="MultiLine" Width="400" /> <br /><br />
    <asp:Button runat="server" ID="btnGuardar" Text="Guardar cambios" OnClick="btnGuardar_Click"/> <br /><br />

    <asp:Label runat="server" ID="lblNoImagen" Text="No se encuentra la imagen en el servidor. Presiona el boton para descargar la fotografía" />
    <asp:Button runat="server" ID="btnGenerar" OnClick="btnGenerar_Click" Text="Generar imagen"/>
    <asp:Image ID="img" runat="server"  />

</asp:Content>
