<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctrlMenu.ascx.cs" Inherits="IntegramsaUltimate.v2.ctrlMenu" %>
<nav id="sidebar" class="">
    <div class="sidebar-header">
        <a href="http://portalsistema.com">
            <img class="main-logo" src="v2/img/logo/logo.png" alt="" /></a>
        <strong>
            <img src="v2/img/logo/logosn.png" alt="" /></strong>
    </div>
    <div class="left-custom-menu-adp-wrap comment-scrollbar">
        <nav class="sidebar-nav left-sidebar-menu-pro">
            <ul class="metismenu" id="menu1">
                <li class="active">
                    <a class="has-arrow" href="http://portalsistema.com">
                        <i class="fa big-icon fa-home icon-wrap"></i>
                        <a href="Default.aspx"><span class="mini-click-non">Inicio</span></a>

                        <ul class="submenu-angle" aria-expanded="true">
                        </ul></li>

                <!-- Personas -->
                <li>
                    <a class="has-arrow" href="mailbox.html" aria-expanded="false"><i class="fa big-icon fa-user icon-wrap"></i><span class="mini-click-non">Personas</span></a>
                    <ul class="submenu-angle" aria-expanded="false">
                        <li><a title="Usuarios " href="http://portalsistema.com/Usuario"><i class="fa fa-user-circle sub-icon-mg" aria-hidden="true"></i><span class="mini-sub-pro">Usuarios </span></a></li>
                        <li><a title="Clientes " href="http://portalsistema.com/Cliente"><i class="fa fa-user-circle-o sub-icon-mg" aria-hidden="true"></i><span class="mini-sub-pro">Clientes </span></a></li>
                    </ul>
                </li>

                <!--Productos -->

                <li>
                    <a class="has-arrow" href="mailbox.html" aria-expanded="false"><i class="fa big-icon fa-cube icon-wrap"></i><span class="mini-click-non">Productos</span></a>
                    <ul class="submenu-angle" aria-expanded="false">

                        <li><a title="Dashboard v.1" href="SegmentosAlta.aspx"><i class="fa fa-bullseye sub-icon-mg" aria-hidden="true"></i><span class="mini-sub-pro">Segmentos</span></a></li>
                        <li><a title="Dashboard v.2" href="SegmentosProductos.aspx"><i class="fa fa-circle-o sub-icon-mg" aria-hidden="true"></i><span class="mini-sub-pro">Segmentos Productos</span></a></li>
                        <li><a title="Dashboard v.3" href="RegistroProductoFormato.aspx"><i class="fa fa-cube sub-icon-mg" aria-hidden="true"></i><span class="mini-sub-pro">Productos Formato</span></a></li>


                        <li><a title="Basic Form Elements" href="basic-form-element.html"><i class="fa fa-pencil sub-icon-mg" aria-hidden="true"></i><span class="mini-sub-pro">Bc Form Elements</span></a></li>
                        <li><a title="Advance Form Elements" href="advance-form-element.html"><i class="fa fa-lightbulb-o sub-icon-mg" aria-hidden="true"></i><span class="mini-sub-pro">Ad Form Elements</span></a></li>
                        <li><a title="Password Meter" href="password-meter.html"><i class="fa fa-hourglass sub-icon-mg" aria-hidden="true"></i><span class="mini-sub-pro">Password Meter</span></a></li>
                        <li><a title="Multi Upload" href="multi-upload.html"><i class="fa fa-hdd-o sub-icon-mg" aria-hidden="true"></i><span class="mini-sub-pro">Multi Upload</span></a></li>
                        <li><a title="Text Editor" href="tinymc.html"><i class="fa fa-globe sub-icon-mg" aria-hidden="true"></i><span class="mini-sub-pro">Text Editor</span></a></li>
                        <li><a title="Dual List Box" href="dual-list-box.html"><i class="fa fa-hand-paper-o sub-icon-mg" aria-hidden="true"></i><span class="mini-sub-pro">Dual List Box</span></a></li>
                    </ul>
                </li>

                <!--Rutas -->
                <li>
                    <a class="has-arrow" href="mailbox.html" aria-expanded="false"><i class="fa big-icon fa-paper-plane icon-wrap"></i><span class="mini-click-non">Rutas</span></a>
                    <ul class="submenu-angle" aria-expanded="false">
<%--                        <li><a title="Inbox" href="mailbox.html"><i class="fa fa-inbox sub-icon-mg" aria-hidden="true"></i><span class="mini-sub-pro">Inbox</span></a></li>
                        <li><a title="View Mail" href="mailbox-view.html"><i class="fa fa-television sub-icon-mg" aria-hidden="true"></i><span class="mini-sub-pro">View Mail</span></a></li>
                        <li><a title="Compose Mail" href="mailbox-compose.html"><i class="fa fa-paper-plane sub-icon-mg" aria-hidden="true"></i><span class="mini-sub-pro">Compose Mail</span></a></li>--%>
                    </ul>
                </li>

                <!-- Sistema -->
                <li>
                    <a class="has-arrow" href="mailbox.html" aria-expanded="false"><i class="fa big-icon fa-table icon-wrap"></i><span class="mini-click-non">Sistema</span></a>
                    <ul class="submenu-angle" aria-expanded="false">
                        <li><a title="Cadenas" href="http://portalsistema.com/Cadena"><i class="fa fa-square sub-icon-mg" aria-hidden="true"></i><span class="mini-sub-pro">Cadenas</span></a></li>
<%--                        <li><a title="Peity Charts" href="static-table.html"><i class="fa fa-table sub-icon-mg" aria-hidden="true"></i><span class="mini-sub-pro">Static Table</span></a></li>
                        <li><a title="Data Table" href="data-table.html"><i class="fa fa-th sub-icon-mg" aria-hidden="true"></i><span class="mini-sub-pro">Data Table</span></a></li>--%>
                    </ul>
                </li>


                <li>
                    <a class="has-arrow" href="mailbox.html" aria-expanded="false"><i class="fa big-icon fa-file-image-o icon-wrap"></i><span class="mini-click-non">Reporte fotos</span></a>
                    <ul class="submenu-angle" aria-expanded="false">
                        <li><a title="Product List" href="ReporteFotoSimple.aspx"><i class="fa fa-female sub-icon-mg" aria-hidden="true"></i><span class="mini-sub-pro">Promotor</span></a></li>
                        <%--                        <li><a title="Product Detail" href="ReporteFotosProductos.aspx"><i class="fa fa-heart-o sub-icon-mg" aria-hidden="true"></i><span class="mini-sub-pro">Producto</span></a></li>--%>
                        <li><a title="Images Cropper" href="ReporteFotosCiudad.aspx"><i class="fa fa-file-image-o sub-icon-mg" aria-hidden="true"></i><span class="mini-sub-pro">Ciudad</span></a></li>
                        <li><a title="Google Map" href="ReporteFotoCadena.aspx"><i class="fa fa-map-marker sub-icon-mg" aria-hidden="true"></i><span class="mini-sub-pro">Cadena</span></a></li>
                        <%--                        <li><a title="Data Maps" href="ReporteFotoSimple.aspx"><i class="fa fa-map-o sub-icon-mg" aria-hidden="true"></i><span class="mini-sub-pro">Simple</span></a></li>--%>
                        <!-- <li><a title="Pdf Viewer" href="pdf-viewer.html"><i class="fa fa-file-pdf-o sub-icon-mg" aria-hidden="true"></i><span class="mini-sub-pro">Sección</span></a></li>-->
                        <li><a title="X-Editable" href="DescargarImagenes.aspx"><i class="fa fa-fighter-jet sub-icon-mg" aria-hidden="true"></i><span class="mini-sub-pro">Descargar imagenes</span></a></li>

                    </ul>
                </li>
                <li>
                    <a class="has-arrow" href="mailbox.html" aria-expanded="false"><i class="fa big-icon fa-line-chart icon-wrap"></i><span class="mini-click-non">R. participación</span></a>
                    <ul class="submenu-angle" aria-expanded="false">
                        <li><a title="Code Editor" href="ReporteParticipacionCadena.aspx"><i class="fa fa-code sub-icon-mg" aria-hidden="true"></i><span class="mini-sub-pro">Master</span></a></li>
                        <li><a title="Code Editor" href="ReporteParticipacionPromotor.aspx"><i class="fa fa-code sub-icon-mg" aria-hidden="true"></i><span class="mini-sub-pro">Promotes captura</span></a></li>

                        <!--    <li><a title="Tree View" href="tree-view.html"><i class="fa fa-frown-o sub-icon-mg" aria-hidden="true"></i><span class="mini-sub-pro">Sección</span></a></li>
                        <li><a title="Preloader" href="preloader.html"><i class="fa fa-circle sub-icon-mg" aria-hidden="true"></i><span class="mini-sub-pro">Sección</span></a></li>
                        <li><a title="Product Edit" href="product-edit.html"><i class="fa fa-bolt sub-icon-mg" aria-hidden="true"></i><span class="mini-sub-pro">Sección</span></a></li>
                        <li><a title="Product Cart" href="product-cart.html"><i class="fa fa-level-down sub-icon-mg" aria-hidden="true"></i><span class="mini-sub-pro">Sección</span></a></li>
                        <li><a title="Product Payment" href="product-payment.html"><i class="fa fa-location-arrow sub-icon-mg" aria-hidden="true"></i><span class="mini-sub-pro">Sección</span></a></li>
                        <li><a title="Analytics" href="analytics.html"><i class="fa fa-line-chart sub-icon-mg" aria-hidden="true"></i><span class="mini-sub-pro">Sección</span></a></li>
                        <li><a title="Widgets" href="widgets.html"><i class="fa fa-magnet sub-icon-mg" aria-hidden="true"></i><span class="mini-sub-pro">Sección</span></a></li> -->

                    </ul>
                </li>



                <li>
                    <a class="has-arrow" href="mailbox.html" aria-expanded="false"><i class="fa big-icon fa-pie-chart icon-wrap"></i><span class="mini-click-non">Reportes</span></a>
                    <ul class="submenu-angle" aria-expanded="false">
                       <%-- <li><a title="File Manager" href="file-manager.html"><i class="fa fa-folder sub-icon-mg" aria-hidden="true"></i><span class="mini-sub-pro">File Manager</span></a></li>
                        <li><a title="Blog" href="blog.html"><i class="fa fa-square sub-icon-mg" aria-hidden="true"></i><span class="mini-sub-pro">Blog</span></a></li>
                        <li><a title="Blog Details" href="blog-details.html"><i class="fa fa-tags sub-icon-mg" aria-hidden="true"></i><span class="mini-sub-pro">Blog Details</span></a></li>
                        <li><a title="404 Page" href="404.html"><i class="fa fa-tint sub-icon-mg" aria-hidden="true"></i><span class="mini-sub-pro">404 Page</span></a></li>
                        <li><a title="500 Page" href="500.html"><i class="fa fa-tree sub-icon-mg" aria-hidden="true"></i><span class="mini-sub-pro">500 Page</span></a></li>--%>
                    </ul>
                </li>



             <%--   <li>
                    <a class="has-arrow" href="mailbox.html" aria-expanded="false"><i class="fa big-icon fa-desktop icon-wrap"></i><span class="mini-click-non">Salir</span></a>
                    <ul class="submenu-angle" aria-expanded="false">
                        <li><a title="Notifications" href="notifications.html"><i class="fa fa-external-link-square sub-icon-mg" aria-hidden="true"></i><span class="mini-sub-pro">Notifications</span></a></li>
                        <li><a title="Alerts" href="alerts.html"><i class="fa fa-crop sub-icon-mg" aria-hidden="true"></i><span class="mini-sub-pro">Alerts</span></a></li>
                        <li><a title="Modals" href="modals.html"><i class="fa fa-building sub-icon-mg" aria-hidden="true"></i><span class="mini-sub-pro">Modals</span></a></li>
                        <li><a title="Buttons" href="buttons.html"><i class="fa fa-adjust sub-icon-mg" aria-hidden="true"></i><span class="mini-sub-pro">Buttons</span></a></li>
                        <li><a title="Tabs" href="tabs.html"><i class="fa fa-eye sub-icon-mg" aria-hidden="true"></i><span class="mini-sub-pro">Tabs</span></a></li>
                        <li><a title="Accordion" href="accordion.html"><i class="fa fa-life-ring sub-icon-mg" aria-hidden="true"></i><span class="mini-sub-pro">Accordion</span></a></li>
                    </ul>
                </li>--%>
               <%--   <li id="removable">
                    <a class="has-arrow" href="#" aria-expanded="false"><i class="fa big-icon fa-files-o icon-wrap"></i><span class="mini-click-non">Pages</span></a>
                  <ul class="submenu-angle" aria-expanded="false">
                        <li><a title="Login" href="login.html"><i class="fa fa-hand-rock-o sub-icon-mg" aria-hidden="true"></i><span class="mini-sub-pro">Login</span></a></li>
                        <li><a title="Register" href="register.html"><i class="fa fa-plane sub-icon-mg" aria-hidden="true"></i><span class="mini-sub-pro">Register</span></a></li>
                        <li><a title="Lock" href="lock.html"><i class="fa fa-file sub-icon-mg" aria-hidden="true"></i><span class="mini-sub-pro">Lock</span></a></li>
                        <li><a title="Password Recovery" href="password-recovery.html"><i class="fa fa-wheelchair sub-icon-mg" aria-hidden="true"></i><span class="mini-sub-pro">Password Recovery</span></a></li>
                    </ul>
                </li>
                <li><a title="Landing Page" href="#" aria-expanded="false"><i class="fa fa-bookmark icon-wrap sub-icon-mg" aria-hidden="true"></i><span class="mini-click-non">Landing Page</span></a></li>--%>
            </ul>
        </nav>
    </div>
</nav>
