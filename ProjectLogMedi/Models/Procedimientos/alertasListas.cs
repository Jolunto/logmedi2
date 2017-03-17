namespace Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;


    public partial class alertasListas
    {
        public int alerta { get; set; }

        public List<presentacion> presentacion { get; set; }
        public List<medicamento> DirectorioMedicamento { get; set; }
        public List<medicamentoTable> medicamento { get; set; }
        public List<ConsultarVentaTabla> venta { get; set; }
        public List<agenda> agenda { get; set; }

        public alertasListas()
        {
            presentacion = new List<presentacion>();
            DirectorioMedicamento = new List<medicamento>();
            medicamento = new List<medicamentoTable>();
            venta = new List<ConsultarVentaTabla>();
            agenda = new List<Models.agenda>();
        }

        


    }
}
