using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using MySql.Data.MySqlClient;
using MySql.Data;
using System.Data.Entity;


namespace BusinessLogic
{
    public class seguimientoRepository
    {
        LogmediContext db = new LogmediContext();

        public List<IndexSeguimiento> Index(int id)
        {
            List<IndexSeguimiento> citas = new List<IndexSeguimiento>();
            DateTime fecha = DateTime.Now;
            string hoy = fecha.ToString("yyyy/MM/dd");            
            try
            {
                citas = db.Database.SqlQuery<IndexSeguimiento>("Call spCitasSeguimiento('"+hoy+"',"+id+")").ToList();
            }
            catch (Exception)
            {

                citas= new List<IndexSeguimiento>();
            }
            return citas;
        }

        public paciente General(int id)
        {
            Seguimiento general = new Seguimiento();
            paciente paciente = new paciente();
            try
            {
                general = db.Database.SqlQuery<Seguimiento>("Call spIdSeguimiento(" + id + ")").Single();
                paciente = db.Database.SqlQuery<paciente>("Call spObtenerPaciente('" + general.id_paciente + "')").Single();
                paciente.generos = db.genero.Where(r => r.id_genero == paciente.id_genero).ToList(); 
                paciente.documentos = db.tipo_documento.Where(r => r.idtipo_documento == paciente.idtipo_documento).ToList();
              



            }
            catch (Exception)
            {

                paciente = null;
            }

            return paciente;
        }

        public void Prioritaria (cita cita, int id)
        {
            DateTime fecha = DateTime.Now;
            string hoy = fecha.ToString("yyyy/MM/dd");            
                     
            try
            {
                db.Database.ExecuteSqlCommand("Call spCitaPrioritaria('" + hoy + "','" + cita.observaciones + "','" + cita.id_paciente + "'," + 5 + "," + id + ")");            
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public List<CompraMedicamento> BuscarProducto(string nombre)
        {
            List<CompraMedicamento> producto = new List<CompraMedicamento>();
            try
            {
                producto = db.Database.SqlQuery<CompraMedicamento>("Call spMedicamentoF('" + nombre + "')").ToList();
                foreach (var item in producto)
                {
                    int algo = item.existencia;
                }
            }


            catch (Exception)
            {

                producto = null;
            }

            return producto;
        }

        public void AgregarEnfermedad(enfermedad enfermedad)
        {
            try
            {
                db.enfermedad.Add(enfermedad);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public List<enfermedad> ObternerEnfermedad(int id)
        {
            var enfermedad = db.enfermedad.SqlQuery("Call spObternerEnfermedad(" + id + ")").ToList();
            return enfermedad;
        }
        public List<tratamiento> ObternerTratamiento(int id)
        {
            var tratamiento = db.tratamiento.SqlQuery("Call spObternerTratamiento(" + id + ")").ToList();
            return tratamiento;
        }

        public List<seguimientos> seguimientos(string id)
        {
            var seguimientos = db.Database.SqlQuery<seguimientos>("Call spSeguimientos('" + id + "')").ToList();
            return seguimientos;
        }


        public void Registrar (Seguimiento seguimiento)
        {
            int id_formula = 0;
            if (seguimiento.formula.vigencia != null || seguimiento.formula.observacion != null || seguimiento.posologia.Count>0)
            {
                formula formula = new formula();
                formula.observacion = seguimiento.formula.observacion;
                formula.estado =1;
                formula.vigencia = seguimiento.formula.vigencia;
                try
                {
                    db.formula.Add(formula);
                    db.SaveChanges();
                    //db.Database.ExecuteSqlCommand("Call spAgregarFormula('" + formula.vigencia + "','" + formula.observacion + "'," + formula.estado + ")");
                }
                catch (Exception e)
                {

                    throw e;
                }
               
                formula = null;
                formula = db.Database.SqlQuery<formula>("Call spObtenerFormula()").Single();
                id_formula = formula.id_formula;
                if (seguimiento.posologia.Count > 0)
                {
                    posologia posologia = new posologia();
                    foreach (var p in seguimiento.posologia)
                    {
                        posologia.id_formula = formula.id_formula;
                        posologia.id_medicamento_presentacion = p.id_medicamento;
                        posologia.cantidad = Convert.ToInt32(p.cantidad);
                        posologia.frecuencia = p.frecuencia;
                        posologia.dosis = p.dosis;
                        try
                        {
                            db.posologia.Add(posologia);
                            db.SaveChanges();
                        //    db.Database.ExecuteSqlCommand("Call spAgregarPosologia(" + posologia.id_formula + "," + posologia.id_medicamento_presentacion + "," + posologia.cantidad + ",'" + posologia.frecuencia + "','" + posologia.dosis + "')");
                        }
                        catch (Exception e)
                        {

                            throw e;
                        }
                        
                    }
                }

            }

            seguimiento_clinico control = new seguimiento_clinico();
            control.id_cita = seguimiento.id_cita;
            if (id_formula != 0)
            {
                control.id_formula = id_formula;
            }
            control.peso = seguimiento.control.peso;
            control.presion = seguimiento.control.presion;
            control.sintomatologia = seguimiento.control.sintomatologia;
            control.motivo_consulta = seguimiento.control.motivo_consulta;
            control.estado_seguimiento = 1; 
            try
            {
                db.seguimiento_clinico.Add(control);
                db.SaveChanges();
                db.Database.ExecuteSqlCommand("Call spCitaAtendida(" + seguimiento.id_cita + ")");
                control = null;
                control = db.Database.SqlQuery<seguimiento_clinico>("Call spObtenerSeguimiento()").Single();
                if (seguimiento.id_tratamiento !=0)
                {
                    tratamiento_seguimiento tratamiento = new tratamiento_seguimiento();
                    tratamiento.id_seguimiento = control.id_seguimiento;
                    tratamiento.id_tratamiento = seguimiento.id_tratamiento;
                    tratamiento.observaciones = seguimiento.observacion_tratamiento;
                    try
                    {
                        db.tratamiento_seguimiento.Add(tratamiento);
                        db.SaveChanges();
                    }
                    catch (Exception e)
                    {

                        throw e;
                    }
                }
                if (seguimiento.id_enfermedad !=0)
                {
                    enfermedad_seguimiento enfermedad = new enfermedad_seguimiento();
                    enfermedad.id_seguimiento = control.id_seguimiento;
                    enfermedad.id_nfermedad = seguimiento.id_enfermedad;
                    enfermedad.observaciones = seguimiento.observacion_enfermedad;
                    try
                    {
                        db.enfermedad_seguimiento.Add(enfermedad);
                        db.SaveChanges();
                    }
                    catch (Exception e)
                    {

                        throw e;
                    }
                }

                 
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
