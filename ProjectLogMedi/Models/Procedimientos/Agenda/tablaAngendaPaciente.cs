namespace Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;


    public partial class tablaAngendaPaciente
    {
        public tablaAngendaPaciente()
        {
            lista = new List<detalletabla>();
        }

        public string busqueda { get; set; }

        public List<detalletabla> lista { get; set; }




    }

    public partial class detalletabla
    {

        public string hora { get; set; }
        public string fecha { get; set; }
        public string id_paciente { get; set; }
        public string paciente { get; set; }
        public string contacto { get; set; }
        public int estado { get; set; }
        public string agenda { get; set; }


    }
}





