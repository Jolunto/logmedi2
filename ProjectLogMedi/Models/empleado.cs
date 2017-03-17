namespace Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("logmedi.empleado")]
    public partial class empleado
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public empleado()
        {
            usuario = new HashSet<usuario>();
            documentos = new List<tipo_documento>();
            generos = new List<genero>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string id_empleado { get; set; }

        [Required]
        [StringLength(20)]
        public string primer_nombre { get; set; }

        [StringLength(20)]
        public string segundo_nombre { get; set; }

        [Required]
        [StringLength(20)]
        public string primer_apellido { get; set; }

        [StringLength(20)]
        public string segundo_apellido { get; set; }

        [StringLength(20)]
        public string telefono { get; set; }

        [StringLength(20)]
        public string celular { get; set; }

        public int? estado { get; set; }

        public int id_tipodocumento { get; set; }

        public int id_genero { get; set; }        

        public List<tipo_documento> documentos { get; set; }

        public List<genero> generos { get; set; }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<usuario> usuario { get; set; }
    }
}
