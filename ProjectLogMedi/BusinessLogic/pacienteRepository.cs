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
    public class pacienteRepository
    {


        LogmediContext db = new LogmediContext();

        public List<paciente> Listar(pacienteTable busqueda)
        {

            var pacientes = new List<paciente>();

            if (busqueda == null)
            {
                return pacientes;
            }
            else
            {
                try
                {
                    pacientes = db.Database.SqlQuery<paciente>("Call spConsultarPaciente('" + busqueda.busqueda+"')").ToList();

                }
                catch (Exception)
                {

                    throw;
                }

                return pacientes;

            }

            
        }

        public paciente loadRegistrar()
        {
            paciente Loads = new paciente();


            Loads.generos = db.genero.ToList();
            Loads.documentos = db.tipo_documento.ToList();
            return Loads;
        }

        public void Agregar(paciente paciente)
        {

            try
            {
                db.paciente.Add(paciente);
                db.SaveChanges();

            }
            catch (Exception)
            {

                throw;
            }

        }

        public paciente Detalles(paciente paciente)
        {
            paciente detalles = new paciente();

            try
            {
                detalles = db.Database.SqlQuery<paciente>("Call spObtenerPaciente('" + paciente.id_paciente + "')").Single();
                detalles.generos = db.genero.Where(r => r.id_genero == detalles.id_genero).ToList(); ;
                detalles.documentos = db.tipo_documento.Where(r => r.idtipo_documento == detalles.idtipo_documento).ToList();
            }
            catch (Exception)
            {

                throw;
            }
            return detalles;
        }

        public paciente Editar(paciente paciente)
        {
            paciente pacienteditar = new paciente();
            try
            {
                pacienteditar = db.Database.SqlQuery<paciente>("Call spObtenerPaciente('" + paciente.id_paciente + "')").Single();
                pacienteditar.generos = db.Database.SqlQuery<genero>("Call spGeneros(" + pacienteditar.id_genero + ")").ToList();
                pacienteditar.documentos = db.Database.SqlQuery<tipo_documento>("Call spDocumentos(" + pacienteditar.idtipo_documento + ")").ToList();
            }
            catch (Exception)
            {

                throw;
            }
            return pacienteditar;
        }

        public void Actualizar(paciente paciente)
        {
            try
            {
                db.Entry(paciente).State = EntityState.Modified;
                db.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
