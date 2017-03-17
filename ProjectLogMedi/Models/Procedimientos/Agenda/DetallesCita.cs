namespace Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;


    public partial class DetallesCita
    {
        public DetallesCita()
        {

        }
        public int id_cita { get; set; }

        public string fecha { get; set; }

       
        public string observaciones { get; set; }

        public string id_paciente { get; set; }

        public int id_estado_cita { get; set; }

        public int id_horario { get; set; }

        public int id_usuario { get; set; }

        public paciente paciente { get; set; }

        

        public horario horario { get; set; }

        public ddlUsuario usuario { get; set; }

        public List<estado_cita> estado_cita { get; set; }


    }
}
