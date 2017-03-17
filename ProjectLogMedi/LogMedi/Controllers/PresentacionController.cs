using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogic;
using Models;

namespace LogMedi.Controllers
{
    public class PresentacionController : Controller
    {
        medicamentoRepository medicamentos = new medicamentoRepository();
        alertasListas alerta = new alertasListas();
        // GET: Presentacion
        public ActionResult Index()
        {

            if (Session["Alerta"] == null)
            {
                alerta.presentacion=medicamentos.ListarPresentacion();
                return View(alerta);
            }
            else
            {
                alerta =(alertasListas)Session["Alerta"];
                alerta.presentacion = medicamentos.ListarPresentacion();
                Session["Alerta"] = null;
               
                               
                return View(alerta);
            }
            

        }

               
        public ActionResult Create()
        {
            return View();
        }

        // POST: Presentacion/Create
        [HttpPost]
        public ActionResult Create(presentacion presentacion)
        {

      
            presentacion.estado = 1;
            
            try
            {
                if (ModelState.IsValid)
                {
                    medicamentos.Agregarpresentacion(presentacion);
                    alerta.alerta = 1;
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

        [HttpGet]
        public ActionResult Edit(int id = 0)
        {
            if (id <= 0)
            {
                return RedirectToAction("Index");
            }
            var presentacion = new presentacion();
            presentacion.id_presentacion = id;
            return View(medicamentos.ObenerPresentacion(presentacion));
        }

        // POST: Presentacion/Edit/5
        [HttpPost]
        public ActionResult Edit(presentacion presentacion, int ddlEstado)
        {
            presentacion.estado = ddlEstado;
            try
            {
                if (ModelState.IsValid)
                {
                    medicamentos.ActualizarPresentacion(presentacion);
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
