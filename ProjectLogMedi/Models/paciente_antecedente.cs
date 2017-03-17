namespace Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("logmedi.paciente_antecedente")]
    public partial class paciente_antecedente
    {
        [Key]
        public int id_paciente_antecedente { get; set; }

        [StringLength(45)]
        public string descripcion { get; set; }

        public string id_paciente { get; set; }

        public int id_tipo_antecedente { get; set; }

        public virtual paciente paciente { get; set; }

        public virtual tipo_antecedente tipo_antecedente { get; set; }
    }
}
