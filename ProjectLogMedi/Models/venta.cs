namespace Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("logmedi.venta")]
    public partial class venta
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public venta()
        {
            venta_medicamento = new HashSet<venta_medicamento>();
            venta_servicio = new HashSet<venta_servicio>();
        }

        [Key]
        public int id_venta { get; set; }

        public decimal? valor_total { get; set; }

        [Column(TypeName = "date")]
        public DateTime? fecha { get; set; }

        public string id_paciente { get; set; }

        public int estado { get; set; }

        public virtual paciente paciente { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<venta_medicamento> venta_medicamento { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<venta_servicio> venta_servicio { get; set; }
    }
}
