namespace Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("logmedi.permiso")]
    public partial class permiso
    {
        [Key]
        public int id_permiso { get; set; }

        public int id_rol { get; set; }

        public int id_modulo { get; set; }

        public virtual modulos modulos { get; set; }

        public virtual rol rol { get; set; }
    }
}
