using DoctaDelivery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoctaDelivery.Controllers;

namespace DoctaDelivery.Controllers
{
    public class NegocioController : Controller
    {
        private DoctaDBDataContext db = new DoctaDBDataContext();
        private RegistrarController r = new RegistrarController();
        //
        // GET: /Negocio/

        public ActionResult Index()
        {
            var zona = from z in db.Zonas
                       select z;
            ViewBag.zonas = zona;

            var barrio = from b in db.Barrios
                         orderby b.nombre
                         select b;
            ViewBag.barrios = barrio;

            var tipo = from t in db.Tipo_negocios
                       select t;
            ViewBag.tipos = tipo;

            if (Request.IsAuthenticated)
            {
                String log = User.Identity.Name;
                var logeo = from l in db.Negocios
                            where l.nombre == log
                            select l;
                if (logeo.Count()==0)
                { return RedirectToAction("index", "Index"); }
                else
                {
                    return View();
                }
            }
            return View();
        }


        public ActionResult Registrar(Negocio n) 
        {
            var validu = from c in db.Negocios
                         select c;
            var i = validu.ToArray();
            int j = 0;
            for (int e = 0; e < i.Length; e++)
            {
                if (i[e].usuario1 == n.usuario1)
                {
                    j++;
                }
            }

            if (j == 0)
            {
                n.contrasenia = r.encriptar(n.contrasenia);
                n.avatar = "no_foto_empresa-123.png";
                db.Negocios.InsertOnSubmit(n);
                db.SubmitChanges();
                TempData["LogeadoNeg"] = "Negocio Registrado con Exito , Por favor Ingrese a su Cuenta";
                return RedirectToAction("index", "Index");
            }
            else
            {
                TempData["ErrorNeg"] = "Nombre del Usuario ya registrado";
                return RedirectToAction("index", "Negocio");
            }
        }

    }
}
