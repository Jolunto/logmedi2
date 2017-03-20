namespace Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;


    public partial class ActualizarPaciente
    {
        public ActualizarPaciente()
        {
            antecedentes = new List<paciente_antecedente>();
        }

        public int id_tipo_antecedente { get; set; }

        public string descripcion { get; set; }
        
        public paciente paciente { get; set; }

        public List<paciente_antecedente> antecedentes { get; set; }

        public void AgregarAntecedente()
        {
            antecedentes.Add(new paciente_antecedente
            {   
                            
                id_tipo_antecedente = id_tipo_antecedente,
                descripcion = descripcion,               
            });

            Refrescar();
        }

        public void Refrescar()
        {
            id_tipo_antecedente = 0;
            descripcion = string.Empty;
        }

        public void RetirarAntecedente(string id)
        {
            if (antecedentes.Count > 0)
            {
                var retirarAntecedente = antecedentes.Where(x => x.descripcion == id).FirstOrDefault();


                antecedentes.Remove(retirarAntecedente);

            }
        }


    }

    
}
