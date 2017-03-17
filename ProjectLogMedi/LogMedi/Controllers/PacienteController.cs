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
    public class PacienteController : Controller
    {
        pacienteRepository pacientes = new pacienteRepository();

        public ActionResult Index()
        {
            pacienteTable buscar = new pacienteTable();
            if (Session["Alerta"]==null)
            {
                
                return View(buscar);
            }
            else
            {
                buscar = (pacienteTable)Session["Alerta"];
                Session["Alerta"] = null;
                return View(buscar);
            }
          
           
          
          
        }

        [HttpPost]
        public ActionResult BuscarPaciente( string busqueda)
        {

            pacienteTable buscar = new pacienteTable();
            buscar.busqueda = busqueda;
            try
            {
                if (ModelState.IsValid)
                { pacienteTable listar = new pacienteTable();
                    listar.paciente = pacientes.Listar(buscar);
                    return View("Consultar", listar.paciente);
                }                              
                return View("Index",buscar);
            }
            catch
            {
                return View(buscar);
            }
        }


        public ActionResult Details(string id = null)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            paciente detalle = new paciente();
            detalle.id_paciente = id;
            return View(pacientes.Detalles(detalle));
        }

        // GET: Paciente/Create
        public ActionResult Create()
        {
            return View(pacientes.loadRegistrar());
        }

        // POST: Paciente/Create
        [HttpPost]
        public ActionResult Create(paciente paciente, int ddlGenero, int ddlDocumento)
        {
            pacienteTable alerta = new pacienteTable();
            paciente.id_genero = ddlGenero;
            paciente.idtipo_documento = ddlDocumento;
            
            paciente.estado = 1;

            
            try
            {
                if (ModelState.IsValid)
                {                  
                    pacientes.Agregar(paciente);
                    alerta.alerta=1;
                    Session["Alerta"] = alerta;
                    return RedirectToAction("Index");
                }
                alerta.alerta = 4;
                Session["Alerta"] =alerta;
                return RedirectToAction("Index");
            }
            catch
            {
                alerta.alerta = 3;
                Session["Alerta"] = alerta;
                return RedirectToAction("Index");
            }
        }

        // GET: Paciente/Edit/5
        public ActionResult Edit(string id = null)
        {

            if (id == null)
            {
                return RedirectToAction("Index");
            }
            var editar = new paciente();
            editar.id_paciente = id;
            return View(pacientes.Editar(editar));


        }

        // POST: Paciente/Edit/5
        [HttpPost]
        public ActionResult Edit(paciente paciente, int ddlGenero, int ddlDocumento, int ddlEstado)
        {
            pacienteTable alerta = new pacienteTable();
            paciente.id_genero = ddlGenero;
            paciente.idtipo_documento = ddlDocumento;
            paciente.estado = ddlEstado;
            try
            {
                if (ModelState.IsValid)
                {
                    pacientes.Actualizar(paciente);
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
