namespace Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("logmedi.venta_servicio")]
    public partial class venta_servicio
    {
        [Key]
        public int id_venta_servicio { get; set; }

        public int id_venta { get; set; }

        public int id_servicio { get; set; }

        public int cantidad { get; set; }

        public decimal subtotal { get; set; }

        public virtual servicio servicio { get; set; }

        public virtual venta venta { get; set; }
    }
}
