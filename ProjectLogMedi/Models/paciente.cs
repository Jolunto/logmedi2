namespace Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("logmedi.paciente")]
    public partial class paciente
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public paciente()
        {
            documentos = new List<tipo_documento>();
            generos = new List<genero>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string id_paciente { get; set; }

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

        public string telefono { get; set; }

        public string celular { get; set; }


        public string fecha_nacimiento { get; set; }

        [StringLength(45)]
        public string correo { get; set; }

        [StringLength(50)]
        public string direccion { get; set; }

        public int? estado { get; set; }

        public int idtipo_documento { get; set; }

        public int id_genero { get; set; }

       

        [StringLength(25)]
        public string tipo_sangre { get; set; }


        public List<tipo_documento> documentos { get; set; }

        public List<genero> generos { get; set; }
        public virtual ICollection<cita> cita { get; set; }

      

        public virtual ICollection<paciente_antecedente> paciente_antecedente { get; set; }

       

       public virtual ICollection<venta> venta { get; set; }
    }
}
