namespace Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;


    public class CompraMedicamento
    {
        public CompraMedicamento()
        {
            Productos = new List<DetalleProducto>();
            Refrescar();
        }
        public int id_medicamento { get; set; }

        public decimal costo { get; set; }

        public string nombre { get; set; }

        public int existencia { get; set; }

        public int cantidad { get; set; }

        public DateTime fecha { get; set; }

        public string observacion { get; set; }

        public List<DetalleProducto> Productos { get; set; }



        public void AgregarProductoDetalle()
        {
            Productos.Add(new DetalleProducto
            {
                id_medicamento = id_medicamento,
                nombre = nombre,
                cantidad = cantidad,
            });

            Refrescar();
        }
        public void Refrescar()
        {
            id_medicamento = 0;
            nombre = null;
            costo = 0;
            existencia = 0;
            cantidad = 1;

        }

        public int SeAgregoUnProductoValido()
        {
            if (id_medicamento != 0 & nombre != null  & cantidad != 0 )
            {
                return 1;
            }
            return 0;
        }

        public int ExisteEnDetalle(int ProductoId)
        {
            if (Productos.FindAll(x => x.id_medicamento == ProductoId).Count > 0)
            {
                return 0;
            }
            return 1;
        }

        public void RetirarProductoDetalle(int id)
        {
            if (Productos.Count > 0)
            {
                var detalleARetirar = Productos.Where(x => x.id_medicamento == id)
                                                        .SingleOrDefault();

                Productos.Remove(detalleARetirar);
            }
        }

    }


    public partial class DetalleProducto
    {

        public int id_medicamento { get; set; }

        public string nombre { get; set; }

        public int cantidad { get; set; }       

        public bool Retirar { get; set; }        
    }

    public partial class detalleMovimiento
    {
        public detalleMovimiento()
        {
            movimiento = new movimiento();   
            detalle = new List<detalleMovimientolista>();
        }
        public List<detalleMovimientolista> detalle { get; set; }
        public movimiento movimiento { get; set; }
    }
}
