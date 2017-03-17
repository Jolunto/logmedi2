using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogic;
using Models;
using System.Data.Entity;

namespace LogMedi.Controllers
{
    public class EmpleadoController : Controller
    {
        private empleadoRepository empleados = new empleadoRepository();
        private LogmediContext db = new LogmediContext();
        

        public ActionResult Index()
        {
            return View(empleados.Listar());
        }

       
        public ActionResult Details(string id = null)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            empleado detalle = new empleado();
            detalle.id_empleado = id;
            return View(empleados.Detalles(detalle));
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(empleados.loadRegistrar());
        }

        
        [HttpPost]
        public ActionResult Create(empleado empleado, int ddlGenero,int ddlDocumento)
        {
            empleado.id_genero = ddlGenero;
            empleado.id_tipodocumento = ddlDocumento;
            empleado.estado = 1;           
            try
            {
                if (ModelState.IsValid)
                {
                    empleados.Agregar(empleado);                   
                    return RedirectToAction("Index");
                }

                return View(empleado);
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Edit(string id = null)
        {

            if (id == null)
            {
                return RedirectToAction("Index");
            }
            var editar = new empleado();
            editar.id_empleado = id;
            return View(empleados.Editar(editar));
           

        }

        // POST: Empleado/Edit/5
        [HttpPost]
        public ActionResult Edit(empleado empleado, int ddlGenero, int ddlDocumento,int ddlEstado)
        {            
            empleado.id_genero = ddlGenero;
            empleado.id_tipodocumento = ddlDocumento;
            empleado.estado = ddlEstado;
            try
            {
                if (ModelState.IsValid)
                {
                    empleados.Actualizar(empleado);

                    return RedirectToAction("Index");
                }
                return View(empleado);
            }
            catch
            {
                return View(empleado);
            }
        }
    
    }
}
