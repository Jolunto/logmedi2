namespace Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("logmedi.tipo_antecedente")]
    public partial class tipo_antecedente
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tipo_antecedente()
        {
            paciente_antecedente = new HashSet<paciente_antecedente>();
        }

        [Key]
        public int id_antecedente { get; set; }

        [StringLength(45)]
        public string nombre { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<paciente_antecedente> paciente_antecedente { get; set; }
    }
}
