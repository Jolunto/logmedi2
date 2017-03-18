using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogic;
using Models;

namespace LogMedi.Controllers
{
    public class UsuarioController : Controller
    {
        usuarioRepository usuarios = new usuarioRepository();
        alertasListas alerta = new alertasListas();

        public ActionResult Index()
        {
            if (Session["Alerta"] == null)
            {
                alerta.Usuario = usuarios.Listar();
                return View(alerta);
            }
            else
            {
              alerta =  (alertasListas)Session["Alerta"];
                Session["Alerta"] = null;
                alerta.Usuario = usuarios.Listar();
                return View(alerta);
            }
        }

        
        public ActionResult Details(int id = 0)
        {
            if (id <= 0)
            {
                return RedirectToAction("Index");
            }
            var detalles = new usuario();
            detalles.id_usuario = id;           
            return View(usuarios.Detalles(detalles));

        }

        
      

       
        public ActionResult Edit(int id)
        {
            var editar = new usuario();
            editar.id_usuario = id;
            return View(usuarios.Editar(editar));
        }

        
        [HttpPost]
        public ActionResult Edit(usuario usuario, string ddlEmpleado, int ddlRol, int ddlEstado)
        {
            usuario.id_rol = ddlRol;
            usuario.estado = ddlEstado;
            usuario.id_empleado = ddlEmpleado;

            try
            {
                if (ModelState.IsValid)
                {
                    usuarios.Actualizar(usuario);
                    alerta.alerta = 2;
                    Session["Alerta"] = alerta;
                    return RedirectToAction("Index");
                }
                alerta.alerta = 4;
                Session["Alerta"] = alerta;
                return RedirectToAction("Index");
            }
            catch
            {
                alerta.alerta = 3;
                Session["Alerta"] = alerta;
                return RedirectToAction("Index");
            }
        }

        
      
    }
}
