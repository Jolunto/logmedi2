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
       
        public ActionResult Index()
        {
            return View(usuarios.Listar());
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

                    return RedirectToAction("Index");
                }
                return View(usuario);
            }
            catch
            {
                return View(usuario);
            }
        }

        
      
    }
}
