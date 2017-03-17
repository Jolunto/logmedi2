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
    public class agendaRepository
    {
        LogmediContext db = new LogmediContext();
        public agenda index()
        {
            agenda index = new agenda();

            try
            {
                index.ddlUsuario = db.Database.SqlQuery<ddlUsuario>("Call spUsuarioAgenda(0)").ToList();
            }
            catch (Exception)
            {
                return index= null;
               
            }

            return index;
        }

        public List<ddlUsuario> ddlUsuario(int  id = 0)
        {
            List<ddlUsuario> usuario = new List<ddlUsuario>();
            try
            {
                usuario = db.Database.SqlQuery<ddlUsuario>("Call spUsuarioAgenda("+id+")").ToList();
            }
            catch (Exception)
            {
                return usuario = null;

            }

            return usuario;
        }

        public List<tablaAgendaUsuario> ConsultaUsuario(agenda agenda)
        {
            List<tablaAgendaUsuario> consulta = new List<tablaAgendaUsuario>();
            try
            {
                
                consulta = db.Database.SqlQuery<tablaAgendaUsuario>("Call spAgendaUsuario('"+agenda.fechaConsulta+"',"+agenda.id_usuario+")").ToList();
               
            }
            catch (Exception)
            {

                consulta= null;
            }
            return consulta;
        }

        public ddlUsuario obtenerUsuario(agenda agenda)
        {
            ddlUsuario consulta = new ddlUsuario();
            try
            {
                consulta = db.Database.SqlQuery<ddlUsuario>("Call spUsuarioCrearCita(" + agenda.id_usuario + ")").Single();
               
            }
            catch (Exception)
            {

                consulta = null;
            }
            return consulta;
        }

        public horario obtenerHora(agenda agenda)
        {
            horario consulta = new horario();
            try
            {
                consulta = db.horario.Where(u => u.id_horario == agenda.id_horario).Single();
               
            }
            catch (Exception)
            {

                consulta = null;
            }
            return consulta;
        }

        public void Agregar(agenda agenda)
        {
            cita cita = new cita();
            cita.fecha = Convert.ToDateTime(agenda.fechaConsulta);
            cita.id_estado_cita = 1;
            cita.id_horario = agenda.id_horario;
            cita.id_usuario = agenda.Usuario.id_usuario;
            cita.id_paciente = agenda.cita.id_paciente;
            cita.observaciones = agenda.cita.observaciones;


            try
            {
                db.cita.Add(cita);
                db.SaveChanges();

            }
            catch (Exception)
            {

                throw;
            }

        }

        public DetallesCita Detalles(int id)
        {
            DetallesCita detalles = new DetallesCita();
            try
            {
                detalles = db.Database.SqlQuery<DetallesCita>("Call spDetallesCita (" + id + ")").Single();
                detalles.horario = db.horario.Where(h => h.id_horario == detalles.id_horario).Single();
                detalles.usuario = db.Database.SqlQuery<ddlUsuario>("Call spUsuarioCrearCita(" + detalles.id_usuario + ")").Single();
                detalles.paciente = db.paciente.Where(p => p.id_paciente == detalles.id_paciente).Single();
                detalles.estado_cita = db.Database.SqlQuery<estado_cita>("Call spEstadoCita(" + detalles.id_estado_cita + ")").ToList();
                
            }
            catch (Exception)
            {

                detalles = null;
            }
            return detalles;
        }

        public void Actualizar(DetallesCita agregar)
        {
            cita cita = new cita();
            cita.id_cita = agregar.id_cita;
            cita.id_estado_cita = agregar.id_estado_cita;
            cita.fecha = Convert.ToDateTime(agregar.fecha);
            cita.id_horario = agregar.id_horario;
            cita.id_paciente = agregar.id_paciente;
            cita.id_usuario = agregar.id_usuario;
            cita.observaciones = agregar.observaciones;
            

            try
            {
                db.Entry(cita).State = EntityState.Modified;
                db.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<detalletabla> ConsultaPaciente(tablaAngendaPaciente agenda)
        {
            List<detalletabla> consulta = new List<detalletabla>();
            try
            {
                 consulta = db.Database.SqlQuery<detalletabla>("Call spAgendaPaciente('" + agenda.busqueda + "')").ToList();
            }
            catch (Exception)
            {
                consulta = null;
            }

            return consulta;
        }
    }
}
