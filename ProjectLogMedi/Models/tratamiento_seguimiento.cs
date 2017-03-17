namespace Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("logmedi.tratamiento_seguimiento")]
    public partial class tratamiento_seguimiento
    {
        [Key]
        public int id_tratamiento_seguimiento { get; set; }

        [StringLength(200)]
        public string observaciones { get; set; }

        public int id_seguimiento { get; set; }

        public int id_tratamiento { get; set; }

        public virtual seguimiento_clinico seguimiento_clinico { get; set; }

        public virtual tratamiento tratamiento { get; set; }
    }
}
