﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogic;
using Models;
using System.Data.Entity;


namespace LogMedi.Controllers
{
    public class RolController : Controller
    {
        private rolRepository roles = new rolRepository();
        private LogmediContext db = new LogmediContext();
        
       
        public ActionResult Index()
        {
            return View(roles.Listar());
        }

        

        public ActionResult Details(int id = 0)
        {
            if (id <= 0)
            {
                return RedirectToAction("Index");
            } 
               
            var detalle = new rol();
            detalle.id_rol = id;
            return View(roles.Detalles(detalle));
        }

        [HttpGet]
        public ActionResult Create()
        {

            return View(roles.modulos());
        }

       
        [HttpPost]
        public ActionResult Create(rol rol,int[] Permisos = null)
        {
            int[] permiso = Permisos;        
            var addrol = new rol();
            var addper = new rol();
            addrol.estado = 1;
            addrol.nombre = rol.nombre;

            try
            {
                if (ModelState.IsValid)
                {
                    roles.Agregar(addrol);
                    if (Permisos != null)                    {
                        addper= roles.getIdrol(addrol);
                        roles.EstablecerPermisos(addper,permiso);
                    }
                    return RedirectToAction("Index");
                }

                return View(rol);
            }
            catch
            {
                return View(rol);
            }
        }

        [HttpGet]
        public ActionResult Edit(int id = 0)
        {
            if (id <= 0)
            {
                return RedirectToAction("Index");
            }
            var editar = new rol();
            editar.id_rol = id;           
            return View(roles.Editar(editar));
        }

       
        [HttpPost]
        public ActionResult Edit(rol rol, int[] Permisos = null, int Estado = 0)
        {
            rol editar = new rol();
            editar.estado = Estado;
            editar.nombre = rol.nombre;
            editar.id_rol = rol.id_rol;
            try
            {
                if (ModelState.IsValid)
                {
                    roles.eliminarPermisos(editar);
                    if (Permisos != null)
                    {                        
                        roles.EstablecerPermisos(editar, Permisos);
                    }
                    
                   
                    roles.Actualizar(editar);
                    return RedirectToAction("Index");
                }
                return View(editar);
            }

            catch
            {
                return View(editar);
            }
        }
       
    }
}
