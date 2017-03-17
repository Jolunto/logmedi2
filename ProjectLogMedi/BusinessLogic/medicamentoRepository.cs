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
    public class medicamentoRepository
    {
        LogmediContext db = new LogmediContext();


        public List<medicamentoTable> Listar()
        {
            var medicamentos = new List<medicamentoTable>();

            try
            {          
                medicamentos = db.Database.SqlQuery<medicamentoTable>("Call spTablaMedicamentos()").ToList();
            }
            catch (Exception)
            {

                throw;
            }

            return medicamentos;
        }

        public medicamento_presentacion obtenerDdl()
        {
            medicamento_presentacion Dropdawnlist = new medicamento_presentacion();
            try
            {
                Dropdawnlist.medicamento = db.Database.SqlQuery<medicamento>("Call spDdlDirectorioCrear()").ToList();
                Dropdawnlist.presentacion = db.Database.SqlQuery<presentacion>("Call spDdlPresentacionCrear()").ToList();
            }
            catch (Exception)
            {

                throw;
            }

            return Dropdawnlist;
        }

        public void Agregar(medicamento_presentacion medicamento)
        {

            try
            {
                db.medicamento_presentacion.Add(medicamento);
                db.SaveChanges();

            }
            catch (Exception)
            {

                throw;
            }

        }

        public medicamento_presentacion ObenerMedicamento(int  id_medicamento)
        {
           
            medicamento_presentacion obtener = new medicamento_presentacion();
            try
            {
                obtener = db.medicamento_presentacion.Where(m => m.id_medicamento_presentacion == id_medicamento).Single();
                obtener.medicamento = db.Database.SqlQuery<medicamento>("Call spDdlDirectorioEditar("+obtener.id_medicamento+")").ToList();
                obtener.presentacion = db.Database.SqlQuery<presentacion>("Call spDdlPresentacionoEditar("+obtener.id_presentacion+")").ToList();
            }
            catch (Exception)
            {

                throw;
            }
            return obtener;

        }

        public void ActualizarMedicamento(medicamento_presentacion medicamento)
        {
            try
            {
                db.Entry(medicamento).State = EntityState.Modified;
                db.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        #region Presentacion
        public List<presentacion> ListarPresentacion()
        {
            List<presentacion> lista = new List<presentacion>();
           
            try
            {
                lista = db.presentacion.ToList();
            }
            catch (Exception)
            {

                throw;
            }

            return lista;
        }

        public presentacion ObenerPresentacion(presentacion presentacion)
        {
            presentacion obtener = new presentacion();
            try
            {
                obtener = db.presentacion.Where(p => p.id_presentacion == presentacion.id_presentacion).Single();
            }
            catch (Exception)
            {

                throw;
            }
            return obtener;

        }

        public void ActualizarPresentacion(presentacion presentacion)
        {
            try
            {
                db.Entry(presentacion).State = EntityState.Modified;
                db.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Agregarpresentacion(presentacion presentacion)
        {

            try
            {
                db.presentacion.Add(presentacion);
                db.SaveChanges();

            }
            catch (Exception)
            {

                throw;
            }

        }

        #endregion

        #region Directorio
        public List<medicamento> ListarDirectorio()
        {
            var medicamentos = new List<medicamento>();

            try
            {
                medicamentos = db.medicamento.ToList();
            }
            catch (Exception)
            {

                throw;
            }

            return medicamentos;
        }

        public void AgregarDirectorio(medicamento medicamento)
        {

            try
            {
                db.medicamento.Add(medicamento);
                db.SaveChanges();

            }
            catch (Exception)
            {

                throw;
            }

        }

        public medicamento ObenerDirectorio(medicamento medicamento)
        {
            medicamento obtener = new medicamento();
            try
            {
                obtener= db.medicamento.Where(m => m.id_medicamento == medicamento.id_medicamento).Single();
               }
            catch (Exception)
            {

                throw;
            }
            return obtener;

        }

        public void ActualizarDirectorio(medicamento medicamento)
        {
            try
            {
                db.Entry(medicamento).State = EntityState.Modified;
                db.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion


    }
}
