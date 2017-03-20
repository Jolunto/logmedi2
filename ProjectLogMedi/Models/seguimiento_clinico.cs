namespace Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("logmedi.seguimiento_clinico")]
    public partial class seguimiento_clinico
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public seguimiento_clinico()
        {
            enfermedad_seguimiento = new HashSet<enfermedad_seguimiento>();
            tratamiento_seguimiento = new HashSet<tratamiento_seguimiento>();
        }

        [Key]
        public int id_seguimiento { get; set; }

        [Required]
        [StringLength(150)]
        public string motivo_consulta { get; set; }

        [StringLength(150)]
        public string sintomatologia { get; set; }

        public string peso { get; set; }

        public string presion { get; set; }

        public int id_cita { get; set; }

        public int id_formula { get; set; }

       
        public int estado_seguimiento { get; set; }

        public virtual cita cita { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<enfermedad_seguimiento> enfermedad_seguimiento { get; set; }

        public virtual formula formula { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tratamiento_seguimiento> tratamiento_seguimiento { get; set; }
    }
}
