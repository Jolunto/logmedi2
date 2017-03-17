using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using MySql.Data.MySqlClient;
using MySql.Data;
using System.Data.Entity;

namespace BusinessLogic
{
    public class ventaRepository
    {
        LogmediContext db = new LogmediContext();


        public List<ConsultarVentaTabla> ConsultarVenta()
        {
            List<ConsultarVentaTabla> venta = new List<ConsultarVentaTabla>();
            try
            {
                venta = db.Database.SqlQuery<ConsultarVentaTabla>("Call spConsultarVentas()").ToList();
            }


            catch (Exception)
            {

                venta = null;
            }

            return venta;
        }

        public ConsultarVentaTabla detalle(int id)
        {
            ConsultarVentaTabla venta = new ConsultarVentaTabla();

            try
            {
                venta =  db.Database.SqlQuery<ConsultarVentaTabla>("Call spConsultarVenta("+id+")").Single();
                venta.detalle = db.Database.SqlQuery<ConsultarVentaTablaDetalle>("Call spConsultarVentaDetalle(" + id+")").ToList();
            }
            catch (Exception)
            {

                venta = null;
            }

            return venta;

        }

        public List<vistaVenta> BuscarProducto(string nombre)
        {
            List<vistaVenta> producto = new List<vistaVenta>();
            try
            {
                producto = db.Database.SqlQuery<vistaVenta>("Call spMedicamento('" + nombre + "')").ToList();
                foreach (var item in producto)
                {
                    int algo = item.existencia;
                }
            }

           
            catch (Exception)
            {

                producto = null;
            }

            return producto;
        }

        public int Registrar(vistaVenta venta)
        {
            
            venta ventaregistrar = new venta();
            venta_medicamento medicamentoRegistrar = new venta_medicamento();
            ventaregistrar.estado = 1;
            ventaregistrar.fecha = DateTime.Now;
            ventaregistrar.id_paciente = venta.id_paciente;
            ventaregistrar.valor_total = venta.Total();

            try
            {
                db.Entry(ventaregistrar).State = EntityState.Added;
                db.SaveChanges();
                var ultima = db.Database.SqlQuery<venta>("Call spultimaVenta()").Single();
                foreach (var p in venta.Productos)
                {
                    medicamentoRegistrar.cantidad = p.cantidad;
                    medicamentoRegistrar.id_medicamento_presentacion = p.id_medicamento;
                    medicamentoRegistrar.id_venta = ultima.id_venta;
                    medicamentoRegistrar.subtotal = p.subtotal();
                    db.venta_medicamento.Add(medicamentoRegistrar);
                    db.SaveChanges();
                    var existencia = db.medicamento_presentacion.Where(m => m.id_medicamento_presentacion == p.id_medicamento).Single();
                    existencia.existencia = existencia.existencia - p.cantidad;
                    db.Entry(existencia).State = EntityState.Modified;
                    db.SaveChanges();

                }


                
            }
            catch (Exception)
            {
                return 0;
            }

            return 1;
        }

        public void Actualizar(ConsultarVentaTabla venta)
        {
           
            try
            {
                db.Database.ExecuteSqlCommand("Call spActualizarVenta(" + venta.estado + "," + venta.id_venta + ")");
                foreach (var p in venta.detalle)
                {
                    var existencia = db.medicamento_presentacion.Where(m => m.id_medicamento_presentacion == p.id_producto).Single();
                    existencia.existencia = existencia.existencia + p.cantidad;
                    db.Entry(existencia).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
