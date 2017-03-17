using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogic;
using Models;

namespace LogMedi.Controllers
{
    public class DirectorioMedicamentosController : Controller
    {
        medicamentoRepository medicamentos = new medicamentoRepository();
        alertasListas alerta = new alertasListas();

        public ActionResult Index()
        {
            if (Session["Alerta"] == null)
            {
                alerta.DirectorioMedicamento = medicamentos.ListarDirectorio();
                return View(alerta);
            }
            else
            {
                alerta = (alertasListas)Session["Alerta"];
                alerta.DirectorioMedicamento = medicamentos.ListarDirectorio();
                Session["Alerta"] = null;

                return View(alerta);
            }
            
        }

        
     

        // GET: DirectorioMedicamentos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DirectorioMedicamentos/Create
        [HttpPost]
        public ActionResult Create(medicamento medicamento)
        {

            medicamento.estado = 1;
            try
            {
                if (ModelState.IsValid)
                {
                    medicamentos.AgregarDirectorio(medicamento);
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

        // GET: DirectorioMedicamentos/Edit/5
        public ActionResult Edit(int id = 0)
        {
            if (id <= 0)
            {
                return RedirectToAction("Index");
            }
            var medicamento = new medicamento();
            medicamento.id_medicamento = id;
            return View(medicamentos.ObenerDirectorio(medicamento));
        }

        // POST: DirectorioMedicamentos/Edit/5
        [HttpPost]
        public ActionResult Edit(medicamento medicamento, int ddlEstado)
        {
            medicamento.estado = ddlEstado;
            try
            {
                if (ModelState.IsValid)
                {
                    medicamentos.ActualizarDirectorio(medicamento);
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
