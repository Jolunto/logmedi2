namespace Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("logmedi.posologia")]
    public partial class posologia
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_posologia { get; set; }

        [Required]
        [StringLength(15)]
        public string dosis { get; set; }

        [StringLength(10)]
        public string frecuencia { get; set; }

        public int? cantidad { get; set; }

        public int id_medicamento_presentacion { get; set; }

        public int id_formula { get; set; }

        public virtual formula formula { get; set; }

        public virtual medicamento_presentacion medicamento_presentacion { get; set; }
    }
}
