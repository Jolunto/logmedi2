namespace Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;
      
    
    public partial class vistaVenta
    {


        public int id_medicamento { get; set; }

        public decimal costo { get; set; }

        public string nombre { get; set; }

        public int existencia { get; set; }                    

        public int cantidad { get; set; }

        public string id_paciente { get; set; }

        public DateTime fecha { get; set; }

        public List<vistasDetalleProducto> Productos { get; set; }

        public decimal Total()
        {
            return Productos.Sum(x => x.subtotal());
        }

        public vistaVenta()
        {
            Productos = new List<vistasDetalleProducto>();
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
            if (id_medicamento != 0 & nombre != null & costo != 0 & cantidad != 0 & cantidad < existencia)
            {
                return 1;
            }
            return 0;
        }

        public int ExisteEnDetalle(int ProductoId)
        {
            if (Productos.FindAll(x => x.id_medicamento == ProductoId).Count>0)
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

        public void AgregarProductoDetalle()
        {
            Productos.Add(new vistasDetalleProducto
            {
                id_medicamento = id_medicamento,
                nombre = nombre,
                costo = costo,
                cantidad = cantidad,
            });

            Refrescar();
        }

    }

    public partial class vistasDetalleProducto
    {
      
        public int id_medicamento { get; set; }

        public string nombre { get; set; }

        public int cantidad { get; set; }

        public decimal costo { get; set; }

        public bool Retirar { get; set; }

        public decimal subtotal()
        {
            return cantidad * costo;

        }
    }


   

    public partial class ConsultarVentaTabla
    {
        public ConsultarVentaTabla()
        {
            detalle = new List<ConsultarVentaTablaDetalle>();
        }
        public int id_venta { get; set; }

        public string fecha { get; set; }

        public int estado { get; set; }

        public string id_paciente { get; set; }
       
        public decimal valor { get; set; }

        public string paciente { get; set; }

        public string contacto { get; set; }

        public List<ConsultarVentaTablaDetalle> detalle { get; set; }

    }

    public partial class ConsultarVentaTablaDetalle
    {
        public int id_producto { get; set; }

        public string producto { get; set; }

        public string  presentacion { get; set; }

        public string contenido { get; set; }

        public int cantidad { get; set; }

        public decimal subtotal { get; set; }
       


    }



}