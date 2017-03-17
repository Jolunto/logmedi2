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
    public class rolRepository
    {
        LogmediContext db = new LogmediContext();

        public List<rol> Listar()
        {
            var roles = new List<rol>();

            try
            {              
                roles = db.rol.Where(r => r.id_rol != 1 ).ToList();

            }
            catch (Exception)
            {

                throw;
            }

            return roles;
        }

        public rol modulos()
        {
            var Completo = new rol();
            List<modulos> lista = new List<modulos>();
            using (var context = new LogmediContext())
            {

                lista = context.Database.SqlQuery<modulos>("Call spPermisosAll").ToList();

            }
            Completo.modulos = lista;
            return Completo;
        }

        public rol Editar(rol rol)
        {
            var Basico = new rol();
            var Completo = new rol();
            List<modulos> lista1 = new List<modulos>();
            List<modulos> lista2 = new List<modulos>();
            try
            {
                using (var context = new LogmediContext())
                {
                    Basico = context.rol.Where(r => r.id_rol == rol.id_rol).Single();

                }
            }

            catch (Exception)
            {

                throw;
            }
            Completo.id_rol = Basico.id_rol;
            Completo.nombre = Basico.nombre;
            Completo.estado = Basico.estado;

            using (var context = new LogmediContext())
            {
                lista1 = context.Database.SqlQuery<modulos>("Call spPermisos(" + rol.id_rol + ")").ToList();
                lista2 = context.Database.SqlQuery<modulos>("Call spPermisosAll").ToList();
            }
            Completo.Allmodulos = lista2;
            Completo.modulos = lista1;
            return Completo;
        }

        public void Agregar(rol rol)
        {

            try
            {
                using (var context = new LogmediContext())
                {
                    context.rol.Add(rol);
                    context.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        public rol getIdrol(rol rol)
        {
            var rolId = new rol();
            try
            {
                using (var context = new LogmediContext())
                {
                    rolId = context.rol.Where(r => r.nombre == rol.nombre).Single();

                }
            }

            catch (Exception)
            {

                throw;
            }
            return rolId;
        }

        public rol Detalles(rol rol)
        {
            var Basico = new rol();
            var Completo = new rol();
            List<modulos> lista = new List<modulos>();



            try
            {
                using (var context = new LogmediContext())
                {
                    Basico = context.rol.Where(r => r.id_rol == rol.id_rol).Single();

                }
            }

            catch (Exception)
            {

                throw;
            }
            Completo.id_rol = Basico.id_rol;
            Completo.nombre = Basico.nombre;
            Completo.estado = Basico.estado;


            using (var context = new LogmediContext())
            {

                lista = context.Database.SqlQuery<modulos>("Call spPermisos(" + rol.id_rol + ")").ToList();

            }
            Completo.modulos = lista;
            return Completo;
        }

        public void EstablecerPermisos(rol rol, int[] Permisos)
        {
            permiso permiso = new permiso();

            try
            {
                foreach (var p in Permisos)
                {
                    using (var context = new LogmediContext())
                    {
                        permiso.id_rol = rol.id_rol;
                        permiso.id_modulo = p;
                        context.permiso.Add(permiso);
                        context.SaveChanges();
                    }
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void eliminarPermisos(rol rol)
        {                       
            try
            {
                List<permiso> permisos = db.permiso.Where(p => p.id_rol == rol.id_rol).ToList();
                foreach (var permiso in permisos)
                {
                    db.permiso.Remove(permiso);
                    db.SaveChanges();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Actualizar(rol rol)
        {
            try
            {
                db.Entry(rol).State = EntityState.Modified;
                db.SaveChanges();           
                            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}
