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
    public class servicioRepository
    {
        LogmediContext db = new LogmediContext();

        public List<servicio> Listar()
        {
            var servicios = new List<servicio>();

            try
            {
                servicios = db.servicio.ToList();

            }
            catch (Exception)
            {

                throw;
            }

            return servicios;
        }


        public void Agregar(servicio servicio)
        {

            try
            {
                db.servicio.Add(servicio);
                db.SaveChanges();

            }
            catch (Exception)
            {

                throw;
            }

        }

        public servicio Detalles(servicio servicio)
        {
            servicio detalles = new servicio();
           
            try
            {
                detalles = db.servicio.Where(s => s.id_servicio == servicio.id_servicio).Single();

            }
            catch (Exception)
            {

                throw;
            }
            return detalles;
        }


        public void Actualizar(servicio servicio)
        {
            try
            {
                db.Entry(servicio).State = EntityState.Modified;
                db.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
