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
    public class compraRepository
    {
        LogmediContext db = new LogmediContext();
        public List<movimiento> ConsultarCompra()
        {
            List<movimiento> Compra = new List<movimiento>();
            try
            {
                Compra = db.Database.SqlQuery<movimiento>("Call spConsultarMovimiento()").ToList();
            }


            catch (Exception)
            {

                Compra = null;
            }

            return Compra;
        }

        public detalleMovimiento detalle(int id)
        {
            detalleMovimiento detalle = new detalleMovimiento();
            try
            {
                detalle.movimiento = db.movimiento.Where(d => d.id_movimiento == id).Single();
                detalle.detalle = db.Database.SqlQuery<detalleMovimientolista>("Call spmovimientoDetalle(" + id + ")").ToList();
            }
            catch (Exception)
            {

                detalle = null;

            }

            return detalle;
        }

        public List<CompraMedicamento> BuscarProducto(string nombre)
        {
            List<CompraMedicamento> producto = new List<CompraMedicamento>();
            try
            {
                producto = db.Database.SqlQuery<CompraMedicamento>("Call spMedicamento('" + nombre + "')").ToList();
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


        public int Registrar(CompraMedicamento compra)
        {

            movimiento compraRegistrar = new movimiento();
            movimiento_medicamento medicamentoRegistrar = new movimiento_medicamento();
            compraRegistrar.fecha = DateTime.Now;
            compraRegistrar.observacion = compra.observacion;
            compraRegistrar.estado = 1;     
            try
            {
                db.Entry(compraRegistrar).State = EntityState.Added;
                db.SaveChanges();
                var ultima = db.Database.SqlQuery<movimiento>("Call spUltimoMovimiento()").Single();
                foreach (var p in compra.Productos)
                {
                    medicamentoRegistrar.cantidad = p.cantidad;
                    medicamentoRegistrar.id_medicamento_presentacion = p.id_medicamento;
                    medicamentoRegistrar.id_movimiento = ultima.id_movimiento;                    
                    db.movimiento_medicamento.Add(medicamentoRegistrar);
                    db.SaveChanges();
                    var existencia = db.medicamento_presentacion.Where(m => m.id_medicamento_presentacion == p.id_medicamento).Single();
                    existencia.existencia = existencia.existencia + p.cantidad;
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
        public void Actualizar(detalleMovimiento movimiento)
        {
            movimiento actualizar = new movimiento();
            actualizar = movimiento.movimiento;
            try
            {
                db.Database.ExecuteSqlCommand("Call spActualizarMovimiento('" + actualizar.observacion + "'," + actualizar.estado + ","+actualizar.id_movimiento+")");
                if (movimiento.movimiento.estado!=1)
                {
                    foreach (var p in movimiento.detalle)
                    {
                        var existencia = db.medicamento_presentacion.Where(m => m.id_medicamento_presentacion == p.id_medicamento).Single();
                        existencia.existencia = existencia.existencia - p.cantidad;
                        db.Entry(existencia).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                }
                
            }
            catch (Exception)
            {

                throw;
            }
        }
    }


}
