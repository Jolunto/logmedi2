namespace Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("logmedi.presentacion")]
    public partial class presentacion
    {

        public presentacion()
        {
            medicamento_presentacion = new HashSet<medicamento_presentacion>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_presentacion { get; set; }

        [StringLength(45)]
        public string nombre { get; set; }

        public int estado { get; set; }

        [NotMapped]
        public int alerta { get; set; }


        public virtual ICollection<medicamento_presentacion> medicamento_presentacion { get; set; }
    }
}
