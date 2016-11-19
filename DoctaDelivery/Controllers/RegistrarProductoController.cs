using DoctaDelivery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoctaDelivery.Controllers
{
    public class RegistrarProductoController : Controller
    {
        private DoctaDBDataContext db = new DoctaDBDataContext();

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



            var tipoProd = from t in db.Tipo_productos
                           select t;
            ViewBag.TiposProductos = tipoProd.ToArray();
            return View();
        }

        public ActionResult CargarProducto(Producto p,int id_negocio)
        {
            p.id_negocio = id_negocio;
            p.borrado = 0;
            db.Productos.InsertOnSubmit(p);
            db.SubmitChanges();
            TempData["Producto"] = "Producto registrado con Exito !";
            return RedirectToAction("Index");
        }

    }
}
