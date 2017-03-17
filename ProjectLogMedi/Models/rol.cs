namespace Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    
   

    [Table("logmedi.rol")]
    public partial class rol
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public rol()
        {
            permiso = new HashSet<permiso>();
            usuario = new HashSet<usuario>();
            modulos = new List<Models.modulos>();
        }

        [Key]
        public int id_rol { get; set; }

        [StringLength(20)]
        public string nombre { get; set; }

        public int estado { get; set; }

        public List<modulos> modulos { get; set; }

        public List<modulos> Allmodulos { get; set; }








        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<permiso> permiso { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<usuario> usuario { get; set; }
    }
}
