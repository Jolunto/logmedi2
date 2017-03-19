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
    public class usuarioRepository
    {
        LogmediContext db = new LogmediContext();

        public List<usuario> Listar()
        {
            var usuarios = new List<usuario>();

            try
            {               
                    usuarios = db.usuario.ToList();               
            }
            catch (Exception)
            {

                throw;
            }

            return usuarios;
        }

      

        public void Registrar (usuario usuario)
        {
            try
            {
                db.usuario.Add(usuario);
                db.SaveChanges();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public usuario Detalles(usuario usuario)
        {
            usuario detalles = new usuario();
            int algo = usuario.id_usuario;

            try
            {
                detalles = db.usuario.Where(u => u.id_usuario == usuario.id_usuario).Single();
                detalles.empleado = db.empleado.Where(e => e.id_empleado == detalles.id_empleado).ToList();
                detalles.rol = db.rol.Where(e => e.id_rol == detalles.id_rol).ToList();
                detalles.permisos =db.Database.SqlQuery<modulos>("Call spPermisos(" + detalles.id_rol + ")").ToList();

            }
            catch (Exception)
            {

                throw;
            }
            return detalles;
        }

        public usuario Editar(usuario usuario)
        {
            var editar = new usuario();
            try
            {
                editar = db.usuario.Where(u => u.id_usuario == usuario.id_usuario).Single();
                editar.empleado = db.Database.SqlQuery<empleado>("Call spEmpleadousuario(" + editar.id_empleado + ")").ToList();
                editar.rol = db.Database.SqlQuery<rol>("Call spRolusuario(" + editar.id_rol + ")").ToList();
            }
            catch (Exception)
            {

                throw;
            }
            return editar;
        }

        public void Actualizar(usuario usuario)
        {
            try
            {
                db.Entry(usuario).State = EntityState.Modified;
                db.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }
        
        public bool CambiarContrasena(int id,string NewPassword)
        {
            var usuario = new usuario();
            try
            {

                int bandera = db.Database.ExecuteSqlCommand("Call spCambiar(" + id + "," + NewPassword + ")");
                if(bandera > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
        public Array CompararContrasena(int id)
        {
            var traer =
     (from db in db.usuario
      where db.id_usuario == id
      select db.contraseña).ToArray();

            return traer;
        }
    }
}
