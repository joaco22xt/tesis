using DoctaDelivery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoctaDelivery.Controllers
{
    public class EditarProductoController : Controller
    {
        //
        // GET: /EditarProducto/
        private DoctaDBDataContext db = new DoctaDBDataContext();

        public ActionResult Index(int idNegocio )
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

                var prod = from p in db.Productos
                           where p.id_negocio == idNegocio && p.borrado==0
                           orderby p.Tipo_producto.nombre, p.nombre
                           select p;

                var publicacion = from p in db.Publicacions
                                  where p.id_negocio==idNegocio
                                  select p;

                ViewBag.publicaciones = publicacion.ToArray();


                ViewBag.productos = prod.ToArray();
                return View();
 

        }

        public ActionResult Editar(int id_producto,int id_negocio,Producto p,int tipo)
        {
            var producto = from a in db.Productos
                           where a.id_producto == id_producto
                           select a;

            var b = producto.ToArray();
            b[0].nombre = p.nombre;
            b[0].descripcion = p.descripcion;
            b[0].id_tipo_producto = tipo;
            b[0].precio = p.precio;
            b[0].tiempo = p.tiempo;
            b[0].coins = p.coins;
            db.SubmitChanges();
            return RedirectToAction("Index", new {idNegocio=id_negocio});
        }

        public ActionResult Eliminar(int id_producto, int id_negocio)
        {
            var producto = from a in db.Productos
                           where a.id_producto == id_producto
                           select a;
            var b = producto.ToArray();
            b[0].borrado = 1;
            db.SubmitChanges();
            return RedirectToAction("Index", new { idNegocio = id_negocio });
        }


    }
}
