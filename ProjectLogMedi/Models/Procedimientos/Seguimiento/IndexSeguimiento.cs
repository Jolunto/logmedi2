namespace Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;


    public partial class IndexSeguimiento
    {
        public IndexSeguimiento()
        {
           
        }

        public int id_cita { get; set; }
        public string horario { get; set; }
        public string id_paciente { get; set; }
        public string paciente { get; set; }       
        public int estado { get; set; }



    }
}
