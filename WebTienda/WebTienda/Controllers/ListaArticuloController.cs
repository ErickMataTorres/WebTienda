using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebTienda.Controllers
{
    public class ListaArticuloController : Controller
    {
        // GET: ListaArticulo
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ListaArticulo()
        {
            return View();
        }

        //llenar tabla
        public JsonResult ListaTablaArticulo(string idNombre)
        {
            var a = Models.Clarticulo.ListaArticulo(idNombre);
            return Json(a, JsonRequestBehavior.AllowGet);
        }

        //cargar cliente
        public JsonResult CargarArticulo(int id)
        {
            var a = Models.Clarticulo.Cargar(id);
            return Json(a, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        //guardar articulo
        public string GuardarArticulo(Models.Clarticulo c)
        {
            var a = c.Guardar();
            return a;
        }
        //editar articulo
        public string EditarArticulo(Models.Clarticulo c)
        {
            var a = c.Editar();
            return a;
        }
        //borrar articulo
        public string BorrarArticulo(Models.Clarticulo c)
        {
            var a = c.Borrar();
            return a;
        }
    }
}