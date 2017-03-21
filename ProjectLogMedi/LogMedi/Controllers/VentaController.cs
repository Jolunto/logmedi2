using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogic;
using Models;
using System.Data.Entity;
using System.Diagnostics;

namespace LogMedi.Controllers
{
    public class VentaController : Controller
    {
       ventaRepository ventas = new ventaRepository();
        alertasListas venta = new alertasListas();
        
        public ActionResult Consultar()
        {
            if (Session["Alerta"] == null)
            {
                venta.venta = ventas.ConsultarVenta();
                return View(venta);
            }
            else
            {
                int alertaa = int.Parse(Session["Alerta"].ToString());
                venta.alerta = alertaa;
                Session["Alerta"] = null;

                venta.venta = ventas.ConsultarVenta();
                return View(venta);
            }
        }

        // GET: Venta/Details/5
        public ActionResult Details(int id = 0)
        {
            if (id == 0)
            {
                return RedirectToAction("Consultar");
            }
            return View(ventas.detalle(id));
        }

        // GET: Venta/Create
        public ActionResult Create()
        {
            Session["productos"] = new List<vistasDetalleProducto>();
            
            return View(new vistaVenta());
        }

        // POST: Venta/Create
        [HttpPost]
        public ActionResult Create(vistaVenta venta1, string action)
        {
            venta1.Productos = (List<vistasDetalleProducto>)Session["productos"];

            if (action == "generar")
            {

                if (!string.IsNullOrEmpty(venta1.id_paciente))
                {
                    if (ventas.Registrar(venta1) == 1)
                    {
                        venta.alerta = 1;
                        Session["Alerta"] = venta.alerta;
                        return RedirectToAction("Consultar");
                    }
                    else
                    {
                        ModelState.AddModelError("cliente", "El paciente no se encuentra registrado");
                    }

                }
                else
                {
                    ModelState.AddModelError("cliente", "Debe agregar un paciente para el comprobante");
                }
            }
            else if (action == "agregar_producto")
            {
                // Si no ha pasado nuestra validación, mostramos el mensaje personalizado de error
                if (venta1.SeAgregoUnProductoValido() == 0)
                {
                    ModelState.AddModelError("producto_agregar", "Producto o cantidad invalidad");
                }
                else if (venta1.ExisteEnDetalle(venta1.id_medicamento) == 0)
                {
                    ModelState.AddModelError("producto_agregar", "El producto elegido ya existe en el detalle");
                }
                else
                {
                    venta1.AgregarProductoDetalle();
                }
            }
            else 
            {
                int id = Convert.ToInt32(action);
                venta1.RetirarProductoDetalle(id);
            }


            Session["productos"] = venta1.Productos;

            return View(venta1);

           
        }

        // GET: Venta/Edit/5
        public ActionResult Edit(int id = 0)
        {
            if (id == 0)
            {
                return RedirectToAction("Consultar");
            }
            ConsultarVentaTabla venta = new ConsultarVentaTabla();
            venta = ventas.detalle(id);
            Session["Ventas"] = venta;
            return View(venta);
        }

        // POST: Venta/Edit/5
        [HttpPost]
        public ActionResult Edit(int Estado, ConsultarVentaTabla venta1)
        {
            venta1 = (ConsultarVentaTabla)Session["Ventas"];
            venta1.estado = Estado;
            try
            {
                if (ModelState.IsValid)
                {
                    if (venta1.estado != 1)
                    {
                        ventas.Actualizar(venta1);
                        venta.alerta = 2;
                        Session["Alerta"] = venta.alerta;
                        return RedirectToAction("Consultar");
                    }
                   
                }

                venta.alerta = 2;
                Session["Alerta"] = venta.alerta;
                return RedirectToAction("Consultar");
            }
            catch
            {

                venta.alerta = 3;
                Session["Alerta"] = venta.alerta;
                return RedirectToAction("Consultar");
            }
        }

        public JsonResult BuscarMedicamento(string nombre)
        {
            return Json(ventas.BuscarProducto(nombre));
        }

        public ActionResult Generar(string Tabla,string Total,string id_paciente)
        {
            Helper.HtmlToPdf Pdf = new Helper.HtmlToPdf();
            string ruta = (Pdf.ByteToPdf(Pdf.PdfSharpConvert("<html><body>"+Tabla+"</br>"+Total+"</body><html>")));
            Process.Start(ruta);
            venta.alerta = 1;
            Session["Alerta"] = venta.alerta;
            return RedirectToAction("Consultar");
        }
    }
}
