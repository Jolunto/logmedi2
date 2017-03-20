namespace Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("logmedi.formula")]
    public partial class formula
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public formula()
        {
            posologia = new HashSet<posologia>();
            seguimiento_clinico = new HashSet<seguimiento_clinico>();
        }

        [Key]
        public int id_formula { get; set; }
                
        public String vigencia { get; set; }

        [StringLength(100)]
        public string observacion { get; set; }

        public int? estado { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<posologia> posologia { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<seguimiento_clinico> seguimiento_clinico { get; set; }
    }
}
