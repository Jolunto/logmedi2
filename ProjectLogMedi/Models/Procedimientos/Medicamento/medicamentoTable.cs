namespace Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

   
    public partial class medicamentoTable
    {
        public medicamentoTable()
        {
            
        }

        [Key]
        public int id_medicamento_presentacion { get; set; }

        public string nombre { get; set; }

        public string presentacion { get; set; }

        public string contenido { get; set; }

        public int existencia { get; set; }

        public decimal? valor { get; set; }

        public int estado { get; set; }


    }
}
