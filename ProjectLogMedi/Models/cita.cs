namespace Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("logmedi.cita")]
    public partial class cita
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public cita()
        {
            seguimiento_clinico = new HashSet<seguimiento_clinico>();
        }

        [Key]
        public int id_cita { get; set; }

        public DateTime fecha { get; set; }

        [StringLength(16777215)]
        public string observaciones { get; set; }

        public string id_paciente { get; set; }

        public int id_estado_cita { get; set; }

        public int id_horario { get; set; }

        public int id_usuario { get; set; }

       
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<seguimiento_clinico> seguimiento_clinico { get; set; }
    }
}
