namespace Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;


    public partial class Seguimiento
    {
        public Seguimiento()
        {
            posologia = new List<Detalleformula>();
            enfermedades = new List<enfermedad>();
            tratamientos = new List<tratamiento>();
            seguimientos = new List<seguimientos>();
        }

        

        public int id_cita { get; set; }

        public string id_paciente { get; set; }

        public int pestaña { get; set; }

        public cita cita { get; set; }

        public paciente paciente { get; set; }

        public seguimiento_clinico control { get; set; }

        public formulaSeguimiento formula { get; set; }

        #region Tratamiento

        public int id_enfermedad { get; set; }

        public int id_tratamiento { get; set; }

        public string observacion_enfermedad { get; set; }

        public string observacion_tratamiento { get; set; }

        public List<enfermedad> enfermedades { get; set; }

        public List<tratamiento> tratamientos { get; set; }

        public List<seguimientos> seguimientos { get; set; }

        #endregion


        #region formula

        public int id_medicamento { get; set; }

        public string nombre { get; set; }

        public string existencia { get; set; }

        public string cantidad { get; set; }

        public string dosis { get; set; }

        public string frecuencia { get; set; }

        public string observacion { get; set; }

        public string vigencia { get; set; }

        public List<Detalleformula> posologia { get; set; }

        public void AgregarPosologiaDetalle()
        {
            posologia.Add(new Detalleformula
            {
                id_medicamento = id_medicamento,
                nombre = nombre,
                cantidad = cantidad,
                dosis = dosis,
                frecuencia = frecuencia,

            });

            Refrescar();
        }
        public void Refrescar()
        {
            id_medicamento = 0;
            nombre = null;
            cantidad = null;
            existencia = null;
            dosis = null;
            frecuencia = null;

        }

        public int SeAgregoUnProductoValido()
        {
            if (id_medicamento != 0 & nombre != null & cantidad != null)
            {
                return 1;
            }
            return 0;
        }

        public int ExisteEnDetalle(int ProductoId)
        {
            if (posologia.FindAll(x => x.id_medicamento == ProductoId).Count > 0)
            {
                return 0;
            }
            return 1;
        }

        public void RetirarProductoDetalle(int id)
        {
            if (posologia.Count > 0)
            {
                var detalleARetirar = posologia.Where(x => x.id_medicamento == id)
                                                        .SingleOrDefault();

                posologia.Remove(detalleARetirar);
            }
        }

        #endregion




    }

    public partial class Detalleformula
    {

        public int id_medicamento { get; set; }

        public string nombre { get; set; }

        public string cantidad { get; set; }

        public string dosis { get; set; }

        public string frecuencia { get; set; }

        public bool Retirar { get; set; }
    }
}
