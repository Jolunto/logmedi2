namespace Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("logmedi.tratamiento")]
    public partial class tratamiento
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tratamiento()
        {
            tratamiento_seguimiento = new HashSet<tratamiento_seguimiento>();
        }

        [Key]
        public int id_tratamiento { get; set; }

        [Required]
        [StringLength(25)]
        public string nombre { get; set; }

        [Required]
        [StringLength(200)]
        public string descripcion { get; set; }

        public int estado { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tratamiento_seguimiento> tratamiento_seguimiento { get; set; }
    }
}
