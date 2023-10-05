using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebTienda.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Index()
        {
            return View();
        }
       
        public ActionResult ListaClientes()
        {
            return View();
        }

        public JsonResult ListaTablaClientes(string idNombre)
        {
            var a = Models.Clcliente.ListaClientes(idNombre);
            return Json(a, JsonRequestBehavior.AllowGet);
        }

        public JsonResult CargarCliente(int id)
        {
            var a = Models.Clcliente.Cargar(id);
            return Json(a, JsonRequestBehavior.AllowGet);
        }



        [HttpPost]
        public string GuardarCliente(Models.Clcliente c)
        {
            var a = c.Guardar();
            return a;
        }

        public string EditarCliente(Models.Clcliente c)
        {
            var a = c.Editar();
            return a;
        }

        public string BorrarCliente(Models.Clcliente c)
        {
            var a = c.Borrar();
            return a;
        }
    }
}