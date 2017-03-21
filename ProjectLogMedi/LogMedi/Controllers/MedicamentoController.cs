using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogic;
using Models;
using System.Diagnostics;

namespace LogMedi.Controllers
{
    public class MedicamentoController : Controller
    {
        medicamentoRepository medicamentos = new medicamentoRepository();
        alertasListas alerta = new alertasListas();
        compraRepository compras = new compraRepository();


        public ActionResult Index()
        {
            if (Session["Alerta"] == null)
            {
                alerta.medicamento = medicamentos.Listar();
                return View(alerta);
            }
            else
            {
                alerta.alerta = (int)Session["Alerta"];
                alerta.medicamento = medicamentos.Listar();
                Session["Alerta"] = null;
                return View(alerta);
            }
            
        }

        public ActionResult Movimiento()
        {
            List<movimiento> compra = new List<movimiento>();
            compra = compras.ConsultarCompra();
            alerta.Compra = compra;
            if (Session["Alerta"] == null)
            {

                return View(alerta);
            }
            else
            {
                alerta.alerta = (int)Session["Alerta"];
                Session["Alerta"] = null;
                return View(alerta);
            }
        }


        public ActionResult Ingreso()
        {
            Session["compras"] = new List<DetalleProducto>();
            return View(new CompraMedicamento());
        }

        [HttpPost]
        public ActionResult Ingreso(CompraMedicamento compra, string action)
        {
            compra.Productos = (List<DetalleProducto>)Session["compras"];

            if (action == "generar")
            {


                if (compras.Registrar(compra) == 1)
                {
                   
                    alerta.alerta = 1;
                    Session["Alerta"] = alerta.alerta;
                    return RedirectToAction("Movimiento");
                }
                else
                {
                    ModelState.AddModelError("cliente", "Error al registrar los productos");
                }



            }
            else if (action == "agregar_producto")
            {
                // Si no ha pasado nuestra validación, mostramos el mensaje personalizado de error
                if (compra.SeAgregoUnProductoValido() == 0)
                {
                    ModelState.AddModelError("producto_agregar", "Producto o cantidad invalidad");
                }
                else if (compra.ExisteEnDetalle(compra.id_medicamento) == 0)
                {
                    ModelState.AddModelError("producto_agregar", "El producto elegido ya existe en el detalle");
                }
                else
                {
                    compra.AgregarProductoDetalle();
                }
            }
            else
            {
                int id = Convert.ToInt32(action);
                compra.RetirarProductoDetalle(id);
            }


            Session["compras"] = compra.Productos;

            return View(compra);


        }

        public JsonResult BuscarMedicamento(string nombre)
        {
            return Json(compras.BuscarProducto(nombre));
        }

        public ActionResult DetailsMovimiento(int id = 0)
        {
            if (id <= 0)
            {
                return RedirectToAction("Movimiento");
            }
            return View(compras.detalle(id));
        }

        public ActionResult EditMovimiento(int id = 0)
        {
            if (id <= 0)
            {
                return RedirectToAction("Movimiento");
            }
            detalleMovimiento compra = new detalleMovimiento();
            compra = compras.detalle(id);
            Session["editarCompra"] = compra;

            return View(compra);
        }

        [HttpPost]
        public ActionResult EditMovimiento(detalleMovimiento movimiento, int Estado, string observacion)
        {
            movimiento = (detalleMovimiento)Session["editarCompra"];
            movimiento.movimiento.estado = Estado;
            movimiento.movimiento.observacion = observacion;
            try
            {
                if (ModelState.IsValid)
                {

                    compras.Actualizar(movimiento);
                    alerta.alerta = 2;
                    Session["Alerta"] = alerta.alerta;
                    return RedirectToAction("Movimiento");


                }
                alerta.alerta = 4;
                Session["Alerta"] = alerta.alerta;
                return RedirectToAction("Movimiento");
            }
            catch
            {
                alerta.alerta = 3;
                Session["Alerta"] = alerta.alerta;
                return RedirectToAction("Movimiento");
            }
        }








        // GET: Medicamento/Create
        public ActionResult Create()
        {
            return View(medicamentos.obtenerDdl());
        }

        // POST: Medicamento/Create
        [HttpPost]
        public ActionResult Create(medicamento_presentacion medicamento, int ddlMedicamento, int ddlPresentacion)
        {
            medicamento.estado = 1;
            medicamento.id_medicamento = ddlMedicamento;
            medicamento.id_presentacion = ddlPresentacion;
            try
            {
                if (ModelState.IsValid)
                {
                    medicamentos.Agregar(medicamento);
                    alerta.alerta = 1;
                    Session["Alerta"] = alerta.alerta;
                    return RedirectToAction("Index");
                }

                alerta.alerta = 4;
                Session["Alerta"] = alerta.alerta;
                return RedirectToAction("Index");

            }
            catch
            {
                alerta.alerta = 3;
                Session["Alerta"] = alerta.alerta;
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
            return View(medicamentos.ObenerMedicamento(id));
        }


        [HttpPost]
        public ActionResult Edit(int ddlEstado, medicamento_presentacion medicamento)
        {
            medicamento.estado = ddlEstado;
            try
            {
                if (ModelState.IsValid)
                {
                    medicamentos.ActualizarMedicamento(medicamento);
                    alerta.alerta = 2;
                    Session["Alerta"] = alerta.alerta;
                    return RedirectToAction("Index");
                }
                alerta.alerta = 4;
                Session["Alerta"] = alerta.alerta;
                return View(medicamento);
            }
            catch
            {
                alerta.alerta = 3;
                Session["Alerta"] = alerta.alerta;
                return View(medicamento);
            }
        }
        public ActionResult Generar(string Tabla)
        {
            Helper.HtmlToPdf Pdf = new Helper.HtmlToPdf();
            string ruta = (Pdf.ByteToPdf(Pdf.PdfSharpConvert("<html><body>" + Tabla + "</body><html>")));
            Process.Start(ruta);
            alerta.alerta = 1;
            Session["Alerta"] = alerta.alerta;
            return RedirectToAction("Index");
        }

    }

}
