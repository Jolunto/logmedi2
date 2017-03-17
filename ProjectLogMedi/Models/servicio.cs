namespace Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("logmedi.servicio")]
    public partial class servicio
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public servicio()
        {
            venta_servicio = new HashSet<venta_servicio>();
        }

        [Key]
        public int id_servicio { get; set; }

        [Required]
        [StringLength(25)]
        public string nombre { get; set; }

        [StringLength(50)]
        public string descripcion { get; set; }

        public decimal valor { get; set; }

        public int estado { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<venta_servicio> venta_servicio { get; set; }
    }
}
