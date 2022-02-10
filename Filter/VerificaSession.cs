using IntegramsaUltimate.Controllers;
using IntegramsaUltimate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IntegramsaUltimate.Filter
{
    public class VerificaSession : ActionFilterAttribute
    {
        private usuario usuario;

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            try
            {
                base.OnActionExecuting(filterContext);

                usuario = (usuario)HttpContext.Current.Session["Usuario"];
                if (usuario == null)
                {
                    if (filterContext.RequestContext.HttpContext.Request.IsAjaxRequest())
                    {
                        if (filterContext.Controller is AccesoController == false)
                        {
                            filterContext.HttpContext.Response.Redirect("/Acceso/Login");
                        }
                    }
                    else
                    {
                        if (filterContext.Controller is AccesoController == false)
                        {
                            filterContext.Result = new RedirectResult("~/Acceso/Login");
                        }
                    }

                }

            }
            catch (Exception)
            {
                filterContext.Result = new RedirectResult("~/Acceso/Login");
            }

        }

    }
}