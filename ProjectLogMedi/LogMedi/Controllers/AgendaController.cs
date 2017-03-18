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
    public class AgendaController : Controller
    {
        agenda agenda = new agenda();
        agendaRepository agendaR = new agendaRepository();

        // GET: Agenda
        public ActionResult Index()
        {
           
            agenda = (agenda)Session["agenda"];
            if (Session["Alerta"] == null)
            {
                if (agenda == null) { return View(agendaR.index()); } else { agenda.ConsultaUsuario = agendaR.ConsultaUsuario(agenda); return View(agenda); }
            }
            else
            {
                agenda.alerta = int.Parse(Session["Alerta"].ToString());
                Session["Alerta"] = null;
                if (agenda == null) { return View(agendaR.index()); } else { agenda.ConsultaUsuario = agendaR.ConsultaUsuario(agenda); return View(agenda); }
            }
           
      
            
            
        }

        public ActionResult AgendaPaciente()
        {
            return View(new tablaAngendaPaciente());
        }

        [HttpPost]
        public ActionResult AgendaPaciente(tablaAngendaPaciente agenda)
        {
            agenda.lista = agendaR.ConsultaPaciente(agenda);
            return View(agenda);
        }

        [HttpPost]
        public ActionResult Index(agenda agenda, int ddlUsuario )
        {
            LogmediContext db = new LogmediContext();
            agenda.id_usuario = ddlUsuario;
            agenda.ConsultaUsuario = agendaR.ConsultaUsuario(agenda);
            agenda.fecha = Convert.ToDateTime(agenda.fechaConsulta);
            agenda.horario = db.horario.ToList();
            Session["idusuario"] = ddlUsuario;
            Session["fecha"] = agenda.fechaConsulta;
            agenda.ddlUsuario = agendaR.ddlUsuario(ddlUsuario);
            Session["agenda"] = agenda;
            return View(agenda);
        }

        
       

        // GET: Agenda/Details/5
        public ActionResult Details(int id=0)
        {
            if (id <= 0)
            {
                return RedirectToAction("Index");
            }
            return View(agendaR.Detalles(id));
        }

        [HttpGet]
        public ActionResult Create(int id)
        {
            
            var agenda = new agenda();
            agenda.fechaConsulta = Session["fecha"].ToString();
            agenda.id_horario = id;
            agenda.id_usuario =Convert.ToInt32( Session["idusuario"]);
            agenda.hora = agendaR.obtenerHora(agenda);
            agenda.Usuario = agendaR.obtenerUsuario(agenda);
            return View(agenda);
        }

      
        [HttpPost]
        public ActionResult Create(agenda agenda)
        {
            
            try
            {
                if (ModelState.IsValid)
                {
                    agendaR.Agregar(agenda);
                    agenda.alerta = 1;
                    Session["Alerta"] = agenda.alerta;
                    return RedirectToAction("Index");
                }
                agenda.alerta = 4;
                Session["Alerta"] = agenda.alerta;
                return RedirectToAction("Index");
            }
            catch
            {
                agenda.alerta = 3;
                Session["Alerta"] = agenda.alerta;
                return RedirectToAction("Index");
            }
        }

        // GET: Agenda/Edit/5
        public ActionResult Edit(int id=0)
        {
            if (id <= 0)
            {
                return RedirectToAction("Index");
            }
            return View(agendaR.Detalles(id));
        }

        // POST: Agenda/Edit/5
        [HttpPost]
        public ActionResult Edit(int ddlEstado, DetallesCita cita)
        {
            agenda agenda = new agenda();
            cita.id_estado_cita = ddlEstado;
            try
            {
                if (ModelState.IsValid)
                {
                    agendaR.Actualizar(cita);
                    agenda.alerta = 2;
                    Session["Alerta"] = agenda.alerta;

                    return RedirectToAction("Index");
                }
                agenda.alerta = 4;
                Session["Alerta"] = agenda.alerta;
                return RedirectToAction("Index");
            }
            catch
            {
                agenda.alerta = 3;
                Session["Alerta"] = agenda.alerta;
                return RedirectToAction("Index");
            }
        }

       
    }
}
