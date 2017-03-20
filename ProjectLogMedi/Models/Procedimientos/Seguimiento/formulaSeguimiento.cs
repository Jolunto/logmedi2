namespace Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;


    public partial class formulaSeguimiento
    {
        public formulaSeguimiento()
        {
            posologia = new List<Detalleformula>();
            Refrescar();
        }

        public int id_medicamento { get; set; }        

        public string nombre { get; set; }

        public int existencia { get; set; }

        public int cantidad { get; set; }

        public string dosis { get; set; }

        public string frecuencia { get; set; }

        public string observacion { get; set; }

        public string vigencia { get; set; }

        public List<Detalleformula> posologia { get; set; }

        public void AgregarPosologiaDetalle()
        {
            posologia.Add(new Detalleformula
            {
                id_medicamento = id_medicamento,
                nombre = nombre,                
                frecuencia = frecuencia,
                
            });

            Refrescar();
        }
        public void Refrescar()
        {
            id_medicamento = 0;
            nombre = null;
            cantidad = 0;
            existencia = 0;
            dosis = null;
            frecuencia = null;

        }

        public int SeAgregoUnProductoValido()
        {
            if (id_medicamento != 0 & nombre != null & cantidad != 0)
            {
                return 1;
            }
            return 0;
        }

        public int ExisteEnDetalle(int ProductoId)
        {
            if (posologia.FindAll(x => x.id_medicamento == ProductoId).Count > 0)
            {
                return 0;
            }
            return 1;
        }

        public void RetirarProductoDetalle(int id)
        {
            if (posologia.Count > 0)
            {
                var detalleARetirar = posologia.Where(x => x.id_medicamento == id)
                                                        .SingleOrDefault();

                posologia.Remove(detalleARetirar);
            }
        }




    }

    
}
