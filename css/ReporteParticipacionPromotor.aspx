<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ReporteParticipacionPromotor.aspx.cs" Inherits="IntegramsaUltimate.ReporteParticipacionPromotor" %>

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
            <asp:DropDownList runat="server" ID="cboClientes" DataSourceID="sqlCliente" DataTextField="razonSocial" DataValueField="id" AutoPostBack="True" OnSelectedIndexChanged="cboClientes_SelectedIndexChanged" />
                                            <asp:SqlDataSource runat="server" ID="sqlCliente" ConnectionString='<%$ ConnectionStrings:IntegramsaUltimateConnectionString %>' SelectCommand="SELECT [id], [razonSocial] FROM [cliente] order by razonSocial"></asp:SqlDataSource>
                                            <br />


                                            <br />
                                            Promotor:<asp:ImageButton runat="server" ID="btnTodosPromotores" ImageUrl="~/Images/sort-icon.png" OnClick="btnTodosPromotores_Click" />
                                            <%--    <asp:DropDownList runat="server" ID="cboPromotor" />--%>
                                            <asp:DropDownList runat="server" ID="cboPromotor" /><br />
                                            <asp:CheckBoxList runat="server" ID="chkPromotor" Visible="false" />


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
                                                    <asp:ImageButton ImageUrl="Images/btnGenerar.png" AlternateText="Generar" runat="server" OnClick="ImageButton1_Click" ID="ImageButton1" />

                                                    <asp:GridView ID="gdDatos" runat="server" Width="800px" AutoGenerateColumns="false">
                                                        <Columns>
                                                            <asp:BoundField DataField="Promotor" HeaderText="Promotor" HeaderStyle-ForeColor="White" HeaderStyle-BackColor="Red"></asp:BoundField>
                                                            <asp:BoundField DataField="fechaEntrada" HeaderText="Fecha" HeaderStyle-ForeColor="White" HeaderStyle-BackColor="Red"></asp:BoundField>
                                                            <asp:BoundField DataField="Cadena" HeaderText="Cadena" HeaderStyle-ForeColor="White" HeaderStyle-BackColor="Red"></asp:BoundField>
                                                            <asp:BoundField DataField="Tienda" HeaderText="Tienda" HeaderStyle-ForeColor="White" HeaderStyle-BackColor="Red"></asp:BoundField>
                                                        </Columns>
                                                    </asp:GridView>
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


</asp:Content>
