namespace Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("logmedi.enfermedad_seguimiento")]
    public partial class enfermedad_seguimiento
    {
        [Key]
        public int id_enfermedad_seguimiento { get; set; }

        [StringLength(200)]
        public string observaciones { get; set; }

        public int id_seguimiento { get; set; }

        public int id_nfermedad { get; set; }

        public virtual enfermedad enfermedad { get; set; }

        public virtual seguimiento_clinico seguimiento_clinico { get; set; }
    }
}
