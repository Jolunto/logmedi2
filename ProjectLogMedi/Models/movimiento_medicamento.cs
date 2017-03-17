namespace Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("logmedi.movimiento_medicamento")]
    public partial class movimiento_medicamento
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_movimiento_medicamento { get; set; }

        public int? cantidad { get; set; }

        public int id_movimiento { get; set; }

        public int id_medicamento_presentacion { get; set; }

        public virtual medicamento_presentacion medicamento_presentacion { get; set; }

        public virtual movimiento movimiento { get; set; }
    }
}
