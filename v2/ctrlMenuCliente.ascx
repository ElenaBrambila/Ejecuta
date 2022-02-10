<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctrlMenuCliente.ascx.cs" Inherits="IntegramsaUltimate.v2.ctrlMenuCliente" %>
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

             <%--   <li>
                    <a class="has-arrow" href="mailbox.html" aria-expanded="false"><i class="fa big-icon fa-file-image-o icon-wrap"></i><span class="mini-click-non">Reporte fotos</span></a>
                    <ul class="submenu-angle" aria-expanded="false">
                        <li><a title="X-Editable" href="DescargarImagenes.aspx"><i class="fa fa-fighter-jet sub-icon-mg" aria-hidden="true"></i><span class="mini-sub-pro">Descargar imagenes</span></a></li>
                        <li><a title="Product List" href="ReporteFotoSimple.aspx"><i class="fa fa-female sub-icon-mg" aria-hidden="true"></i><span class="mini-sub-pro">Promotor</span></a></li>
                 --%>       <%--                        <li><a title="Product Detail" href="ReporteFotosProductos.aspx"><i class="fa fa-heart-o sub-icon-mg" aria-hidden="true"></i><span class="mini-sub-pro">Producto</span></a></li>--%>
                 <%--       <li><a title="Images Cropper" href="ReporteFotosCiudad.aspx"><i class="fa fa-file-image-o sub-icon-mg" aria-hidden="true"></i><span class="mini-sub-pro">Ciudad</span></a></li>
                        <li><a title="Google Map" href="ReporteFotoCadena.aspx"><i class="fa fa-map-marker sub-icon-mg" aria-hidden="true"></i><span class="mini-sub-pro">Cadena</span></a></li>
                  --%>      <%--                        <li><a title="Data Maps" href="ReporteFotoSimple.aspx"><i class="fa fa-map-o sub-icon-mg" aria-hidden="true"></i><span class="mini-sub-pro">Simple</span></a></li>--%>
                        <!-- <li><a title="Pdf Viewer" href="pdf-viewer.html"><i class="fa fa-file-pdf-o sub-icon-mg" aria-hidden="true"></i><span class="mini-sub-pro">Sección</span></a></li>-->

<%--                    </ul>
                </li>--%>
          <%-- COMENTADO PROVISIONALMENTE      <li>
                    <a class="has-arrow" href="mailbox.html" aria-expanded="false"><i class="fa big-icon fa-pie-chart icon-wrap"></i><span class="mini-click-non">R. participación</span></a>
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
                    <a class="has-arrow" href="mailbox.html" aria-expanded="false"><i class="fa big-icon fa-line-chart icon-wrap"></i><span class="mini-click-non">Reportes</span></a>
                    <ul class="submenu-angle" aria-expanded="false">
                        <li><a title="File Manager" href="http://portalsistema.com/ReporteAsistenciaCobertura"><i class="fa fa-folder sub-icon-mg" aria-hidden="true"></i><span class="mini-sub-pro">Reporte Asistencia Cobertura</span></a></li>
                        <li><a title="Blog" href="http://portalsistema.com/ReporteTiempoEfectivo"><i class="fa fa-square sub-icon-mg" aria-hidden="true"></i><span class="mini-sub-pro">Reporte Tiempo Efectivo</span></a></li>
                        <li><a title="Blog Details" href="http://portalsistema.com/ReporteTiempoEfectivoMuerto"><i class="fa fa-tags sub-icon-mg" aria-hidden="true"></i><span class="mini-sub-pro">Reporte Tiempo Efectivo Muerto</span></a></li>
                        <li><a title="404 Page" href="http://portalsistema.com/ReporteAsistenciaNew"><i class="fa fa-tint sub-icon-mg" aria-hidden="true"></i><span class="mini-sub-pro">Reporte Asistencia</span></a></li>
                        <li><a title="500 Page" href="http://portalsistema.com/ReporteAsistenciaFechaEnEspecifico"><i class="fa fa-tree sub-icon-mg" aria-hidden="true"></i><span class="mini-sub-pro">Resumen ejecutivo</span></a></li>
                        <li><a title="500 Page" href="http://portalsistema.com/ReporteAsistenciaFechaEnEspecificoPromedio"><i class="fa fa-tree sub-icon-mg" aria-hidden="true"></i><span class="mini-sub-pro">Resumen ejecutivo promedio</span></a></li>

                    </ul>
                </li>--%>

            </ul>
        </nav>
    </div>
</nav>
