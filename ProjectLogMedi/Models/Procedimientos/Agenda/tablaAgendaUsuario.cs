namespace Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;


    public partial class tablaAgendaUsuario
    {
        public tablaAgendaUsuario()
        {

        }

        public int id_cita { get; set; }
        public int id_horario { get; set; }
        public string id_paciente { get; set; }
        public string paciente { get; set; }
        public string contacto { get; set; }
        public int estado { get; set; }






    }
}
