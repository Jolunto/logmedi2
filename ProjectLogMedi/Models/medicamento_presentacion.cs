namespace Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("logmedi.medicamento_presentacion")]
    public partial class medicamento_presentacion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public medicamento_presentacion()
        {
            movimiento_medicamento = new HashSet<movimiento_medicamento>();
            posologia = new HashSet<posologia>();
            venta_medicamento = new HashSet<venta_medicamento>();
        }

        [Key]
        public int id_medicamento_presentacion { get; set; }

        public decimal? valor { get; set; }

        public int? existencia { get; set; }

        [StringLength(20)]
        public string contenido { get; set; }

        public int id_medicamento { get; set; }

        public int id_presentacion { get; set; }
        
        public int estado { get; set; }

        public List< medicamento> medicamento { get; set; }

        public List<presentacion> presentacion { get; set; }

         public virtual ICollection<movimiento_medicamento> movimiento_medicamento { get; set; }

        public virtual ICollection<posologia> posologia { get; set; }

       public virtual ICollection<venta_medicamento> venta_medicamento { get; set; }
    }
}
