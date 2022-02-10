<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="SegmentosAlta.aspx.cs" Inherits="IntegramsaUltimate.SegmentosAlta" %>

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
                                <h1>Registro/edición de segmentos</h1>
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
                                            <asp:SqlDataSource runat="server" ID="sqlCliente" ConnectionString='<%$ ConnectionStrings:IntegramsaUltimateConnectionString %>' SelectCommand="SELECT [id], [razonSocial] FROM [cliente] order by razonSocial"></asp:SqlDataSource>
                                            <br />
                                            Nombre del segmento: 

    <asp:TextBox runat="server" ID="txtSegmento" Width="350px" />
                                            <br />
                                            <br />

                                            <asp:ImageButton runat="server" ID="btnAgregar" ImageUrl="~/Images/btnGuardar-150x40.png" OnClick="btnAgregar_Click" />

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
                                <h1>Segmentos ya registrados</h1>
                            </div>
                        </div>

                        <asp:GridView  OnRowCommand="gdSegmentos_RowCommand" runat="server" ID="gdSegmentos" AutoGenerateColumns="False" DataKeyNames="idSegmento" DataSourceID="sqlSegmentos" Width="400px">
                            <Columns>
                                <asp:BoundField DataField="idSegmento" HeaderText="ID" ReadOnly="True" InsertVisible="False" SortExpression="idSegmento"></asp:BoundField>
                                <asp:BoundField DataField="segmento" HeaderText="segmento" SortExpression="segmento"></asp:BoundField>
                                <asp:ButtonField ButtonType="Image" ImageUrl="~/Images/icon_edit.png" CommandName="btnEditar" />
                                <asp:ButtonField ButtonType="Image" ImageUrl="~/Images/icon_delete.png" CommandName="btnEliminar" />
                            </Columns>
                        </asp:GridView>
                        <%--                        <asp:ListBox runat="server" ID="lstSegmentos" DataSourceID="sqlSegmentos" DataTextField="segmento" DataValueField="idSegmento" Width="400px"/>--%>

                        <asp:SqlDataSource runat="server" ID="sqlSegmentos" ConnectionString='<%$ ConnectionStrings:IntegramsaUltimateConnectionString %>' SelectCommand="SELECT [idSegmento], [segmento] FROM [segmentos] WHERE ([idCliente] = @idCliente)">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="cboClientes" PropertyName="SelectedValue" Name="idCliente" Type="Int32"></asp:ControlParameter>
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
