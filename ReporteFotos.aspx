<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ReporteFotos.aspx.cs" Inherits="IntegramsaUltimate.ReporteFotos" EnableEventValidation="false" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!--Comienza tab-->
    <!-- Single pro tab start-->
<%--    <div class="single-product-tab-area mg-tb-15">
        <!-- Single pro tab review Start-->
        <div class="single-pro-review-area">
            <div class="container-fluid">
                <div class="row">
                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                        <div class="review-tab-pro-inner">
                            <ul id="myTab3" class="tab-review-design">
                                <li class="active"><a href="#description"><i class="fa fa-pencil" aria-hidden="true"></i>Filtros</a></li>
                                <li><a href="#reviews"><i class="fa fa-file-image-o" aria-hidden="true"></i>Imagenes</a></li>
                                <li><a href="#INFORMATION"><i class="fa fa-commenting" aria-hidden="true"></i>Reporte</a></li>
                            </ul>
                            <div id="myTabContent" class="tab-content custom-product-edit">
                                <div class="product-tab-list tab-pane fade active in" id="description">
                                    <div class="row">
                                        <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">

                                            <div class="chosen-select-single">
                                                <label>Promotores</label>
                                                <select data-placeholder="Selecciona los promotores..." class="chosen-select" multiple="" tabindex="-1" id="cboPromotor2" runat="server">
                                                </select>
                                            </div>




                                            <div class="review-content-section">

                                                <div class="input-group mg-b-pro-edt">
                                                    <span class="input-group-addon"><i class="fa fa-user" aria-hidden="true"></i></span>
                                                    <input type="text" class="form-control" placeholder="First Name">
                                                </div>
                                                <div class="input-group mg-b-pro-edt">
                                                    <span class="input-group-addon"><i class="fa fa-pencil" aria-hidden="true"></i></span>
                                                    <input type="text" class="form-control" placeholder="Product Title">
                                                </div>
                                                <div class="input-group mg-b-pro-edt">
                                                    <span class="input-group-addon"><i class="fa fa-usd" aria-hidden="true"></i></span>
                                                    <input type="text" class="form-control" placeholder="Regular Price">
                                                </div>
                                                <div class="input-group mg-b-pro-edt">
                                                    <span class="input-group-addon"><i class="fa fa-sticky-note-o" aria-hidden="true"></i></span>
                                                    <input type="text" class="form-control" placeholder="Tax">
                                                </div>
                                                <div class="input-group mg-b-pro-edt">
                                                    <span class="input-group-addon"><i class="fa fa-qrcode" aria-hidden="true"></i></span>
                                                    <input type="text" class="form-control" placeholder="Quantity">
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                                            <div class="review-content-section">
                                                <div class="input-group mg-b-pro-edt">
                                                    <span class="input-group-addon"><i class="fa fa-user" aria-hidden="true"></i></span>
                                                    <input type="text" class="form-control" placeholder="Last Name">
                                                </div>
                                                <div class="input-group mg-b-pro-edt">
                                                    <span class="input-group-addon"><i class="fa fa-ticket" aria-hidden="true"></i></span>
                                                    <input type="text" class="form-control" placeholder="Product Description">
                                                </div>
                                                <div class="input-group mg-b-pro-edt">
                                                    <span class="input-group-addon"><i class="fa fa-usd" aria-hidden="true"></i></span>
                                                    <input type="text" class="form-control" placeholder="Sale Price">
                                                </div>
                                                <div class="input-group mg-b-pro-edt">
                                                    <span class="input-group-addon"><i class="fa fa-tag" aria-hidden="true"></i></span>
                                                    <input type="text" class="form-control" placeholder="Category">
                                                </div>
                                                <select name="select" class="form-control pro-edt-select form-control-primary">
                                                    <option value="opt1">Select One Value Only</option>
                                                    <option value="opt2">2</option>
                                                    <option value="opt3">3</option>
                                                    <option value="opt4">4</option>
                                                    <option value="opt5">5</option>
                                                    <option value="opt6">6</option>
                                                </select>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                            <div class="text-center mg-b-pro-edt custom-pro-edt-ds">
                                                <button type="button" class="btn btn-primary waves-effect waves-light m-r-10">
                                                    Save
                                                </button>
                                                <button type="button" class="btn btn-warning waves-effect waves-light">
                                                    Discard
                                                </button>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="product-tab-list tab-pane fade" id="reviews">
                                    <div class="row">
                                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                            <div class="review-content-section">
                                                <div class="row">
                                                    <div class="col-lg-4">
                                                        <div class="pro-edt-img">
                                                            <img src="img/new-product/5-small.jpg" alt="" />
                                                        </div>
                                                    </div>
                                                    <div class="col-lg-8">
                                                        <div class="row">
                                                            <div class="col-lg-12">
                                                                <div class="product-edt-pix-wrap">
                                                                    <div class="input-group">
                                                                        <span class="input-group-addon">TT</span>
                                                                        <input type="text" class="form-control" placeholder="Label Name">
                                                                    </div>
                                                                    <div class="row">
                                                                        <div class="form-group data-custon-pick data-custom-mg" id="data_5">
                                                                            <label>Range select</label>
                                                                            <div class="input-daterange input-group" id="datepicker">
                                                                                <input type="text" class="form-control" name="start" value="05/14/2014" />
                                                                                <span class="input-group-addon">to</span>
                                                                                <input type="text" class="form-control" name="end" value="05/22/2014" />
                                                                            </div>
                                                                        </div>
                                                                        <div class="col-lg-6">
                                                                            <div class="form-radio">
                                                                                <form>
                                                                                    <div class="radio radiofill">
                                                                                        <label>
                                                                                            <input type="radio" name="radio"><i class="helper"></i>Largest Image
                                                                                        </label>
                                                                                    </div>
                                                                                    <div class="radio radiofill">
                                                                                        <label>
                                                                                            <input type="radio" name="radio"><i class="helper"></i>Medium Image
                                                                                        </label>
                                                                                    </div>
                                                                                    <div class="radio radiofill">
                                                                                        <label>
                                                                                            <input type="radio" name="radio"><i class="helper"></i>Small Image
                                                                                        </label>
                                                                                    </div>
                                                                                </form>
                                                                            </div>
                                                                        </div>
                                                                        <div class="col-lg-6">
                                                                            <div class="product-edt-remove">
                                                                                <button type="button" class="btn btn-danger waves-effect waves-light">
                                                                                    Remove
																							<i class="fa fa-times" aria-hidden="true"></i>
                                                                                </button>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-lg-4">
                                                        <div class="pro-edt-img">
                                                            <img src="img/new-product/6-small.jpg" alt="" />
                                                        </div>
                                                    </div>
                                                    <div class="col-lg-8">
                                                        <div class="row">
                                                            <div class="col-lg-12">
                                                                <div class="product-edt-pix-wrap">
                                                                    <div class="input-group">
                                                                        <span class="input-group-addon">TT</span>
                                                                        <input type="text" class="form-control" placeholder="Label Name">
                                                                    </div>
                                                                    <div class="row">
                                                                        <div class="col-lg-6">
                                                                            <div class="form-radio">
                                                                                <form>
                                                                                    <div class="radio radiofill">
                                                                                        <label>
                                                                                            <input type="radio" name="radio"><i class="helper"></i>Largest Image
                                                                                        </label>
                                                                                    </div>
                                                                                    <div class="radio radiofill">
                                                                                        <label>
                                                                                            <input type="radio" name="radio"><i class="helper"></i>Medium Image
                                                                                        </label>
                                                                                    </div>
                                                                                    <div class="radio radiofill">
                                                                                        <label>
                                                                                            <input type="radio" name="radio"><i class="helper"></i>Small Image
                                                                                        </label>
                                                                                    </div>
                                                                                </form>
                                                                            </div>
                                                                        </div>
                                                                        <div class="col-lg-6">
                                                                            <div class="product-edt-remove">
                                                                                <button type="button" class="btn btn-danger waves-effect waves-light">
                                                                                    Remove
																							<i class="fa fa-times" aria-hidden="true"></i>
                                                                                </button>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-lg-4">
                                                        <div class="pro-edt-img">
                                                            <img src="img/new-product/7-small.jpg" alt="" />
                                                        </div>
                                                    </div>
                                                    <div class="col-lg-8">
                                                        <div class="row">
                                                            <div class="col-lg-12">
                                                                <div class="product-edt-pix-wrap">
                                                                    <div class="input-group">
                                                                        <span class="input-group-addon">TT</span>
                                                                        <input type="text" class="form-control" placeholder="Label Name">
                                                                    </div>
                                                                    <div class="row">
                                                                        <div class="col-lg-6">
                                                                            <div class="form-radio">
                                                                                <form>
                                                                                    <div class="radio radiofill">
                                                                                        <label>
                                                                                            <input type="radio" name="radio"><i class="helper"></i>Largest Image
                                                                                        </label>
                                                                                    </div>
                                                                                    <div class="radio radiofill">
                                                                                        <label>
                                                                                            <input type="radio" name="radio"><i class="helper"></i>Medium Image
                                                                                        </label>
                                                                                    </div>
                                                                                    <div class="radio radiofill">
                                                                                        <label>
                                                                                            <input type="radio" name="radio"><i class="helper"></i>Small Image
                                                                                        </label>
                                                                                    </div>
                                                                                </form>
                                                                            </div>
                                                                        </div>
                                                                        <div class="col-lg-6">
                                                                            <div class="product-edt-remove">
                                                                                <button type="button" class="btn btn-danger waves-effect waves-light">
                                                                                    Remove
																							<i class="fa fa-times" aria-hidden="true"></i>
                                                                                </button>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="product-tab-list tab-pane fade" id="INFORMATION">
                                    <div class="row">
                                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                            <div class="review-content-section">
                                                <div class="card-block">
                                                    <div class="text-muted f-w-400">
                                                        <p>No reviews yet.</p>
                                                    </div>
                                                    <div class="m-t-10">
                                                        <div class="txt-primary f-18 f-w-600">
                                                            <p>Your Rating</p>
                                                        </div>
                                                        <div class="stars stars-example-css detail-stars">
                                                            <div class="review-rating">
                                                                <fieldset class="rating">
                                                                    <input type="radio" id="star5" name="rating" value="5">
                                                                    <label class="full" for="star5"></label>
                                                                    <input type="radio" id="star4half" name="rating" value="4 and a half">
                                                                    <label class="half" for="star4half"></label>
                                                                    <input type="radio" id="star4" name="rating" value="4">
                                                                    <label class="full" for="star4"></label>
                                                                    <input type="radio" id="star3half" name="rating" value="3 and a half">
                                                                    <label class="half" for="star3half"></label>
                                                                    <input type="radio" id="star3" name="rating" value="3">
                                                                    <label class="full" for="star3"></label>
                                                                    <input type="radio" id="star2half" name="rating" value="2 and a half">
                                                                    <label class="half" for="star2half"></label>
                                                                    <input type="radio" id="star2" name="rating" value="2">
                                                                    <label class="full" for="star2"></label>
                                                                    <input type="radio" id="star1half" name="rating" value="1 and a half">
                                                                    <label class="half" for="star1half"></label>
                                                                    <input type="radio" id="star1" name="rating" value="1">
                                                                    <label class="full" for="star1"></label>
                                                                    <input type="radio" id="starhalf" name="rating" value="half">
                                                                    <label class="half" for="starhalf"></label>
                                                                </fieldset>
                                                            </div>
                                                            <div class="clear"></div>
                                                        </div>
                                                    </div>
                                                    <div class="input-group mg-b-15 mg-t-15">
                                                        <span class="input-group-addon"><i class="fa fa-user" aria-hidden="true"></i></span>
                                                        <input type="text" class="form-control" placeholder="User Name">
                                                    </div>
                                                    <div class="input-group mg-b-15">
                                                        <span class="input-group-addon"><i class="fa fa-user" aria-hidden="true"></i></span>
                                                        <input type="text" class="form-control" placeholder="Last Name">
                                                    </div>
                                                    <div class="input-group mg-b-15">
                                                        <span class="input-group-addon"><i class="fa fa-envelope-o" aria-hidden="true"></i></span>
                                                        <input type="text" class="form-control" placeholder="Email">
                                                    </div>
                                                    <div class="form-group review-pro-edt">
                                                        <button type="submit" class="btn btn-primary waves-effect waves-light">
                                                            Submit
                                                        </button>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>--%>

    <!--Fin de tab -->
    <!--Comienza contenido del reporte -->
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

                                            <br />
                                            Filtros:
                                            <asp:Label runat="server" ID="lblCantidad" />
                                            <div class="chosen-select-single">
                                                <label>Promotores</label>
                                                <select data-placeholder="Selecciona los promotores..." class="chosen-select" multiple="" tabindex="-1" id="cboPromotor1" runat="server">
                                                </select>

                                            </div>

                                            <div class="chosen-select-single">
                                                <label>Plazas</label>
                                                <select data-placeholder="Selecciona las plazas..." class="chosen-select" multiple="" tabindex="-1" id="cboPlazas" runat="server">
                                                </select>
                                            </div>

                                           <%-- <div class="chosen-select-single">
                                                <label>Ciudades</label>
                                                <select data-placeholder="Selecciona las ciudades..." class="chosen-select" multiple="" tabindex="-1" id="cboCiudades" runat="server">
                                                </select>
                                            </div>--%>

                                             <div class="chosen-select-single">
                                                <label>Cadenas</label>
                                                <select data-placeholder="Selecciona las cadenas..." class="chosen-select" multiple="" tabindex="-1" id="cboCadena" runat="server">
                                                </select>
                                            </div>


                                            <asp:SqlDataSource runat="server" ID="sqlCadenas" ConnectionString='<%$ ConnectionStrings:IntegramsaUltimateConnectionString %>' SelectCommand="SELECT [id], [nombre] FROM [cadena] ORDER BY [nombre]"></asp:SqlDataSource>
                                           <%-- <asp:SqlDataSource runat="server" ID="sqlFormatos" ConnectionString='<%$ ConnectionStrings:IntegramsaUltimateConnectionString %>' SelectCommand="SELECT [id], [nombre] FROM [formatoTienda] WHERE ([idCadena] = @idCadena)">
                                                <SelectParameters>
                                                    <asp:ControlParameter ControlID="cboCadena" PropertyName="SelectedValue" Name="idCadena" Type="Int32"></asp:ControlParameter>
                                                </SelectParameters>
                                            </asp:SqlDataSource>--%>

                                            <asp:SqlDataSource runat="server" ID="sqlPlazas" ConnectionString='<%$ ConnectionStrings:IntegramsaUltimateConnectionString %>' SelectCommand="SELECT * FROM [cPlaza] ORDER BY [nombre]"></asp:SqlDataSource>

                                          <%--  <asp:SqlDataSource runat="server" ID="sqlCiudadesPlazas" ConnectionString='<%$ ConnectionStrings:IntegramsaUltimateConnectionString %>' SelectCommand="SELECT cmunicipio.Nombre, cmunicipio.idcMunicipio FROM cmunicipio INNER JOIN PlazaMunicipio ON cmunicipio.idcMunicipio = PlazaMunicipio.idMunicipio WHERE ([idPlaza] = @idPlaza) order by cmunicipio.Nombre">
                                                <SelectParameters>
                                                    <asp:ControlParameter ControlID="cboPlaza" PropertyName="SelectedValue" Name="idPlaza" Type="Int32"></asp:ControlParameter>
                                                </SelectParameters>
                                            </asp:SqlDataSource>--%>
                                            <asp:SqlDataSource runat="server" ID="sqlCiudades" ConnectionString='<%$ ConnectionStrings:IntegramsaUltimateConnectionString %>' SelectCommand="SELECT [id], [idMunicipio] FROM [PlazaMunicipio] WHERE ([idPlaza] = @idPlaza) order by PlazaMunicipio"></asp:SqlDataSource>

                                            <div class="chosen-select-single">
                                                <label>Tipo de exhibición</label>
                                                <select data-placeholder="Selecciona por tipo de exhbición..." class="chosen-select" multiple="" tabindex="-1" id="cboTipoExhibicion" runat="server">
                                                </select>
                                            </div>

                                            <asp:CheckBox runat="server" ID="chkDescargarFotos" Text="Descargar fotos no existentes" Checked="true" />
                                            <asp:CheckBoxList runat="server" ID="cboPromotor" />

                                            <br />
                                            <asp:ScriptManager ID="ScriptManager1" runat="server">
                                            </asp:ScriptManager>

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
                                                     <asp:Label runat="server" ID="lblCantidadFotos" />
<%--                                                    <button type="button" class="btn btn-custon-rounded-four btn-warning" runat="server" visible="false" id="btnFotosPendientes" onserverclick="btnFotosPendientes_ServerClick">Generar fotos pendientes</button>--%>
                                                    <button type="button" class="btn btn-custon-rounded-four btn-primary" runat="server" visible="false" id="btnSelectAllPics1" onserverclick="btnSelectAllPics_Click">Seleccionar todos</button>
                                                    <button type="button" class="btn btn-custon-four btn-default" id="btnDeseleccionar" visible="false" runat="server" onserverclick="btnDeseleccionar_ServerClick">Quitar selección</button>
                                                    <asp:Button runat="server" ID="btnPreliminar" Text="Generar preliminar" OnClick="btnPreliminar_Click" />
                                                     <br />
                                                      <br />
                                                    <asp:Button runat="server" ID="btnPreliminar2" Text="Generar preliminar Test" OnClick="btnPreliminar_ClickR" />
                                                    <%--                                                    <asp:ImageButton ImageUrl="Images/btnGenerar.png" AlternateText="Generar" runat="server"  ID="ImageButton1" />--%>
                                                    <br />
                                                    <asp:GridView ID="datosGrid" runat="server" AutoGenerateColumns="false">

                                                        <Columns>
                                                            <asp:TemplateField>
                                                                <ItemTemplate>
                                                                    <asp:CheckBox runat="server" ID="chkAgregar" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="id" HeaderText="ID" ItemStyle-Width="30" />
                                                            <asp:BoundField DataField="Fecha" HeaderText="Fecha" ItemStyle-Width="30" />
                                                            <asp:BoundField DataField="plaza" HeaderText="Plaza" ItemStyle-Width="30" />
                                                            <asp:BoundField DataField="municipio" HeaderText="Municipio" ItemStyle-Width="30" />
                                                            <asp:BoundField DataField="cadena" HeaderText=" Cadena" ItemStyle-Width="30" />
                                                            <asp:BoundField DataField="tienda" HeaderText=" Tienda" ItemStyle-Width="30" />
                                                            <asp:BoundField DataField="formatoTienda" HeaderText=" Formato" ItemStyle-Width="30" />
                                                            <asp:BoundField DataField="Promotor" HeaderText=" Promotor" ItemStyle-Width="30" />
                                                            <asp:BoundField DataField="proposito" HeaderText=" Propósito" ItemStyle-Width="30" />
                                                            <asp:BoundField DataField="comentario" HeaderText=" Comentario" ItemStyle-Width="30" />
                                                            <asp:BoundField DataField="idDUsuario" HeaderText=" Tienda" ItemStyle-Width="30" Visible="false" />
                                                            <asp:BoundField DataField="idDTienda" HeaderText=" Formato" ItemStyle-Width="30" Visible="false" />
                                                            <asp:BoundField DataField="idFormato" HeaderText=" Promotor" ItemStyle-Width="30" Visible="false" />
                                                            <asp:BoundField DataField="idCliente" HeaderText=" Propósito" ItemStyle-Width="30" Visible="false" />
                                                            <asp:BoundField DataField="idcMunicipio" HeaderText=" Comentario" ItemStyle-Width="30" Visible="false" />
                                                            <asp:BoundField DataField="idCadena" HeaderText="Comentario" ItemStyle-Width="30" Visible="false" />
                                                            <asp:BoundField DataField="idPlaza" HeaderText="Comentario" ItemStyle-Width="30" Visible="false" />


                                                            <asp:TemplateField>
                                                                <ItemTemplate>
                                                                    <asp:HyperLink ID="lnkImage" runat="server" Width="100px"
                                                                        ImageUrl='<%# String.Format("~/fotosReportes/{0}.jpg",Eval("id"))%>'
                                                                        Target="_blank"
                                                                        NavigateUrl='<%# String.Format("~/fotosReportes/{0}.jpg",Eval("id")) %>'></asp:HyperLink>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <ItemTemplate>
                                                                    <asp:HyperLink ID="lnkEditar" runat="server" Width="100px"
                                                                        Text="Editar"
                                                                        Target="_blank"
                                                                        NavigateUrl='<%# String.Format("~/Fotos.aspx?id={0}",Eval("id")) %>'></asp:HyperLink>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>

                                                    <br />

                                                    <asp:Button runat="server" ID="btnGenerarReporte" OnClick="btnGenerarReporte_Click" Text="Generar reporte" Visible="false" /> <br />
                                                    <asp:Button runat="server" ID="btnGenerarReporteHorizontal" Visible="false" Text="Generar datos" OnClick="btnGenerarReporteHorizontal_Click"/>
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
                        <br />
                        <br />
                        Fecha inicio :
    <asp:TextBox ID="dtInicio" runat="server" TextMode="Date"></asp:TextBox>
                        <br />
                        Fecha fin :
    <asp:TextBox ID="dtFin" runat="server" TextMode="Date"></asp:TextBox>
                        <br />
                        <br />
                    </div>
                </div>
            </div>
        </div>

    </div>
    <!--Fin del contenido de filtros del reporte -->



   
    <rsweb:ReportViewer  ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="800px" Height="800px">
        <LocalReport ReportPath="rptRepFotosSimple.rdlc" EnableExternalImages="true">
        </LocalReport>
    </rsweb:ReportViewer>


    <asp:ObjectDataSource runat="server" SelectMethod="GetData" TypeName="IntegramsaUltimate.IntegramsaUltimateDataSetTableAdapters.vwReporteFotosTableAdapter" ID="ObjectDataSource1"></asp:ObjectDataSource>
</asp:Content>
