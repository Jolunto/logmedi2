namespace Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("logmedi.venta_medicamento")]
    public partial class venta_medicamento
    {
        [Key]      
        public int id_venta_medicamento { get; set; }

        public int? cantidad { get; set; }

        public decimal? subtotal { get; set; }

        public int id_medicamento_presentacion { get; set; }

        public int id_venta { get; set; }

        public virtual medicamento_presentacion medicamento_presentacion { get; set; }

        public virtual venta venta { get; set; }
    }
}
