namespace Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;


    public partial class pacienteTable
    {
        public pacienteTable()
        {

        }

        public int alerta { get; set; }

        public string busqueda { get; set; }

        public List<paciente> paciente { get; set; }

        
    }
}
