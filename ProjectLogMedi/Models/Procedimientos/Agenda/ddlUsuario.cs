namespace Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;


    public partial class ddlUsuario
    {
        public ddlUsuario()
        {

        }

        public int id_usuario { get; set; }        
        public string usuario { get; set; }







    }
}
