namespace Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("logmedi.usuario")]
    public partial class usuario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public usuario()
        {
            cita = new HashSet<cita>();
           
        }

        [Key]
        public int id_usuario { get; set; }

        [StringLength(50)]
        public string nombre_usuario { get; set; }

        [StringLength(15)]
        public string contraseña { get; set; }

        [StringLength(45)]
        public string correo { get; set; }

        public string id_empleado { get; set; }

        public int id_rol { get; set; }
        
        public int estado { get; set; }

         public virtual ICollection<cita> cita { get; set; }

        public List<empleado> empleado { get; set; }

        public List<rol> rol { get; set; }

        public List<modulos> permisos { get; set; }

    }
}
