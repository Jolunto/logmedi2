namespace Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("logmedi.movimiento")]
    public partial class movimiento
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public movimiento()
        {
            movimiento_medicamento = new HashSet<movimiento_medicamento>();
           
        }

        [Key]
        public int id_movimiento { get; set; }

        [Column(TypeName = "date")]
        public DateTime fecha { get; set; }

        [StringLength(200)]
        public string observacion { get; set; }

        public int estado { get; set; }

        

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<movimiento_medicamento> movimiento_medicamento { get; set; }
    }

    public partial class detalleMovimientolista
    {
        public int id_medicamento { get; set; }

        public string medicamento { get; set; }

        public string presentacion { get; set; }

        public string contenido { get; set; }

        public int cantidad { get; set; }
    }
}
