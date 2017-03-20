namespace Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    public partial class seguimientos
    {
        public seguimientos()
        {

        }
        public int dias { get; set; }
        public string fecha { get; set; }
        public string empleado { get; set; }
        public string consulta { get; set; }
    }
}
