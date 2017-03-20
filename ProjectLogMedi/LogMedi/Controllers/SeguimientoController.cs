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
    public class SeguimientoController : Controller
    {
        seguimientoRepository seguimientos = new seguimientoRepository();
        LogmediContext db = new LogmediContext();
        // GET: Seguimiento
        public ActionResult Index()
        {
            return View(seguimientos.Index(17));
        }

        [HttpGet]
        public ActionResult Prioritaria()
        {
            return View(new cita());
        }

        [HttpPost]
        public ActionResult Prioritaria(cita cita)
        {
            try
            {
                seguimientos.Prioritaria(cita, 17);
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
               
            }
            return RedirectToAction("Index");
        }

        // GET: Seguimiento/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
                
        public ActionResult Create(int id)
        {
            Session["posologia"] = new List<Detalleformula>();
            Seguimiento seguimiento = new Seguimiento();
            Session["Paciente"]= seguimientos.General(id);
            seguimiento.paciente = (paciente)Session["Paciente"];
            seguimiento.pestaña = 0;
            seguimiento.id_cita = id;
            seguimiento.enfermedades = db.enfermedad.ToList();
            seguimiento.tratamientos = db.tratamiento.ToList();
            seguimiento.id_tratamiento = 0;
            seguimiento.id_enfermedad = 0;
            Session["Seguimientos"] = seguimientos.seguimientos(seguimiento.paciente.id_paciente);
            seguimiento.seguimientos = (List<seguimientos>)Session["Seguimientos"];
            return View(seguimiento);
        }

        // POST: Seguimiento/Create
        [HttpPost]
        public ActionResult Create(Seguimiento seguimiento, string action,int ddlEnfermedad,int ddlTratamiento)
        {

            seguimiento.posologia = (List<Detalleformula>)Session["posologia"];
            seguimiento.paciente = (paciente)Session["Paciente"];
            seguimiento.enfermedades = seguimientos.ObternerEnfermedad(ddlEnfermedad);
            seguimiento.tratamientos = seguimientos.ObternerTratamiento(ddlTratamiento);
            seguimiento.id_enfermedad = ddlEnfermedad;
            seguimiento.id_tratamiento = ddlTratamiento;
            

            if (action == "guardar")
            {
               
                try
                {
                    seguimientos.Registrar(seguimiento);
                    return RedirectToAction("Index");
                }
                catch (Exception )
                {

                    return View(seguimiento);
                }
                          
                
            }
            else if (action == "cerrar")
            {
                return RedirectToAction("Index");

            }
            else if (action == "agregar_formula")
            {
                // Si no ha pasado nuestra validación, mostramos el mensaje personalizado de error
                if (seguimiento.SeAgregoUnProductoValido() == 0)
                {
                    ModelState.AddModelError("producto_agregar", "Producto o cantidad invalidad");
                    seguimiento.pestaña = 3;
                }
                else if (seguimiento.ExisteEnDetalle(seguimiento.id_medicamento) == 0)
                {
                    ModelState.AddModelError("producto_agregar", "El producto elegido ya existe en el detalle");
                    seguimiento.pestaña = 3;
                }
                else
                {
                    seguimiento.AgregarPosologiaDetalle();
                    seguimiento.pestaña = 3;
                }
            }
            else
            {
                int id = Convert.ToInt32(action);
                seguimiento.RetirarProductoDetalle(id);
                seguimiento.pestaña = 3;
            }


            Session["posologia"] = seguimiento.posologia;
           

            return View(seguimiento);


        }

        // GET: Seguimiento/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Seguimiento/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Seguimiento/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Seguimiento/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        public JsonResult BuscarMedicamento(string nombre)
        {
            return Json(seguimientos.BuscarProducto(nombre));
        }
    }
}
