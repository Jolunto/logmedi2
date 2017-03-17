namespace Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;


    public partial class agenda
    {
        public agenda()
        {
            ConsultaUsuario = new List<tablaAgendaUsuario>();
            horario = new List<Models.horario>();
            ddlUsuario = new List<ddlUsuario>();
        }


        public string fechaConsulta { get; set; }

        public DateTime fecha { get; set; }

        public int id_usuario { get; set; }

        public string id_paciente { get; set; }

        public int id_horario { get; set; }

        public int alerta { get; set;}

        public List<ddlUsuario> ddlUsuario { get; set; }

        public List<tablaAgendaUsuario> ConsultaUsuario { get; set; }

        public List<tablaAgendaUsuario> ConsultaPaciente { get; set; }

        public List<horario> horario { get; set; }

        public cita cita { get; set; }

        public ddlUsuario Usuario { get; set; }

        public horario hora { get; set; }





    }
}
