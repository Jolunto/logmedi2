namespace Models
{
    using System.Collections.Generic;


    public partial class alertasListas
    {
        public int alerta { get; set; }

        public List<presentacion> presentacion { get; set; }
        public List<medicamento> DirectorioMedicamento { get; set; }
        public List<medicamentoTable> medicamento { get; set; }
        public List<ConsultarVentaTabla> venta { get; set; }
        public List<movimiento> Compra { get; set; }
        public List<usuario> Usuario { get; set; }
        public List<rol> Rol { get; set; }
        public List<empleado> Empleado { get; set; }

        public alertasListas()
        {
            presentacion = new List<presentacion>();
            DirectorioMedicamento = new List<medicamento>();
            medicamento = new List<medicamentoTable>();
            venta = new List<ConsultarVentaTabla>();
            Compra = new List<movimiento>();
            Usuario = new List<usuario>();
            Rol = new List<rol>();
            Empleado = new List<empleado>();
        }

        


    }
}
