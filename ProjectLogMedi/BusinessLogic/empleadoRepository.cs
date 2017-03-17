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
    public class empleadoRepository
    {
        LogmediContext db = new LogmediContext();

        public List<empleado> Listar()
        {
            var empleados = new List<empleado>();
           
            try
            {
              empleados = db.empleado.ToList();
                
            }
            catch (Exception)
            {

                throw;
            }

            return empleados;
        }


        public empleado loadRegistrar()
        {
            empleado Loads = new empleado();         

            Loads.generos = db.genero.ToList();
            Loads.documentos = db.tipo_documento.ToList();
            return Loads;
        }

        public void Agregar(empleado empleado)
        {

            try
            {
                    db.empleado.Add(empleado);
                    db.SaveChanges();
                registrarUsuario(empleado);
                    

               
            }
            catch (Exception)
            {

                throw;
            }

        }

        public empleado Detalles(empleado empleado)
        {
            empleado detalles = new empleado();

            try
            {
                detalles = db.empleado.Where(r => r.id_empleado == empleado.id_empleado).Single();
                detalles.generos = db.genero.Where(r => r.id_genero == detalles.id_genero).ToList(); ;
                detalles.documentos = db.tipo_documento.Where(r => r.idtipo_documento == detalles.id_tipodocumento).ToList();
            }
            catch (Exception)
            {

                throw;
            }
            return detalles;
        }


        public empleado Editar(empleado empleado)
        {
            empleado empleadoeditar = new empleado();
            try
            {
            empleadoeditar= db.empleado.Where(r => r.id_empleado == empleado.id_empleado).Single();
            empleadoeditar.generos= db.Database.SqlQuery<genero>("Call spGeneros(" + empleadoeditar.id_genero + ")").ToList();
            empleadoeditar.documentos=db.Database.SqlQuery<tipo_documento>("Call spDocumentos(" + empleadoeditar.id_tipodocumento + ")").ToList();
            }
            catch (Exception)
            {

                throw;
            }
            return empleadoeditar;
        }

        public void Actualizar(empleado empleado)
        {
            try
            {
                db.Entry(empleado).State = EntityState.Modified;
                db.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void registrarUsuario(empleado empleado)
        {
            usuario usuario = new usuario();
            usuario.id_empleado = empleado.id_empleado;
            usuario.estado = 2;
            usuario.contraseña = empleado.id_empleado.ToString();
            usuario.nombre_usuario = empleado.primer_nombre + empleado.primer_apellido + empleado.id_empleado;
            try
            {
                db.Database .ExecuteSqlCommand("Call spCrearUsuario('" + usuario.id_empleado + "','" + usuario.nombre_usuario + "','" + usuario.contraseña + "'," + usuario.estado + ")");
               
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
