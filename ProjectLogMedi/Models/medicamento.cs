namespace Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("logmedi.medicamento")]
    public partial class medicamento
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public medicamento()
        {
            medicamento_presentacion = new HashSet<medicamento_presentacion>();
        }

        [Key]
        public int id_medicamento { get; set; }

        [Required]
        [StringLength(25)]
        public string nombre { get; set; }

        public int estado { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<medicamento_presentacion> medicamento_presentacion { get; set; }
    }
}
