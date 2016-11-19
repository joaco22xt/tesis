using DoctaDelivery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;


namespace DoctaDelivery.Controllers
{
    public class IndexController : Controller
    {
        private DoctaDBDataContext db = new DoctaDBDataContext();

        //
        // GET: /Index/

        public ActionResult Index()
        {

          if (Request.IsAuthenticated) 
          { 
                String log = User.Identity.Name;
                var logeado = from l in db.Usuarios
                              where l.usuario1 == log
                              select l;

                var logeado2 = from l in db.Negocios
                               where l.usuario1 == log
                               select l;
                    ViewBag.logear = logeado.ToArray();
                    ViewBag.logear2 = logeado2.ToArray();

          }

          var barrio = from b in db.Barrios
                       select b;
          ViewBag.barrios = barrio.ToArray();

          var publicacion = from p in db.Publicacions
                            select p;

            ViewBag.publicaciones= publicacion.ToArray();

          var tipo = from t in db.Tipo_negocios
                     select t;
          ViewBag.Tipos = tipo.ToArray();

          var cantidad = from c in db.Negocios
                         select c;
          ViewBag.Cantidades = cantidad.ToArray().Length;

          var nego = from n in db.Negocios
                         select n;
          ViewBag.Negocios = nego.ToArray();
            return View();


        }


       
    }
}
