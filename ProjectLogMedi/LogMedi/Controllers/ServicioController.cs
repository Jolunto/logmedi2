using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogic;
using Models;

namespace LogMedi.Controllers
{
    public class ServicioController : Controller
    {
        servicioRepository servicios = new servicioRepository();

        public ActionResult Index()
        {
            return View(servicios.Listar());
        }

        // GET: Servicio/Details/5
        public ActionResult Details(int id = 0)
        {
            if (id <= 0)
            {
                return RedirectToAction("Index");
            }
            var servicio = new servicio();
            servicio.id_servicio = id;
            return View(servicios.Detalles(servicio));
        }

       [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        public ActionResult Create(servicio servicio)
        {
            servicio.estado = 1;
            try
            {
                if (ModelState.IsValid)
                {
                    servicios.Agregar(servicio);
                    return RedirectToAction("Index");
                }

                return View(servicio);
            }
            catch
            {
                return View();
            }
        }

        // GET: Servicio/Edit/5
        public ActionResult Edit(int id = 0)
        {
            if (id <= 0)
            {
                return RedirectToAction("Index");
            }
            var servicio = new servicio();
            servicio.id_servicio = id;
            return View(servicios.Detalles(servicio));
        }

        // POST: Servicio/Edit/5
        [HttpPost]
        public ActionResult Edit(servicio servicio, int ddlEstado)
        {
            servicio.estado = ddlEstado;
            try
            {
                if (ModelState.IsValid)
                {
                    servicios.Actualizar(servicio);

                    return RedirectToAction("Index");
                }
                return View(servicio);
            }
            catch
            {
                return View(servicio);
            }
        }

       
    }
}
