namespace Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class LogmediContext : DbContext
    {
        public LogmediContext()
            : base("name=LogmediContext")
        {
        }

        public virtual DbSet<cita> cita { get; set; }
        public virtual DbSet<empleado> empleado { get; set; }
        public virtual DbSet<enfermedad> enfermedad { get; set; }
        public virtual DbSet<enfermedad_seguimiento> enfermedad_seguimiento { get; set; }
        public virtual DbSet<estado_cita> estado_cita { get; set; }
        public virtual DbSet<formula> formula { get; set; }
        public virtual DbSet<genero> genero { get; set; }
        public virtual DbSet<horario> horario { get; set; }
        public virtual DbSet<medicamento> medicamento { get; set; }
        public virtual DbSet<medicamento_presentacion> medicamento_presentacion { get; set; }
        public virtual DbSet<modulos> modulos { get; set; }
        public virtual DbSet<movimiento> movimiento { get; set; }
        public virtual DbSet<movimiento_medicamento> movimiento_medicamento { get; set; }
        public virtual DbSet<paciente> paciente { get; set; }
        public virtual DbSet<paciente_antecedente> paciente_antecedente { get; set; }
        public virtual DbSet<permiso> permiso { get; set; }
        public virtual DbSet<posologia> posologia { get; set; }
        public virtual DbSet<presentacion> presentacion { get; set; }
        public virtual DbSet<rol> rol { get; set; }
        public virtual DbSet<seguimiento_clinico> seguimiento_clinico { get; set; }
        public virtual DbSet<servicio> servicio { get; set; }
        public virtual DbSet<tipo_antecedente> tipo_antecedente { get; set; }
        public virtual DbSet<tipo_documento> tipo_documento { get; set; }
        public virtual DbSet<tratamiento> tratamiento { get; set; }
        public virtual DbSet<tratamiento_seguimiento> tratamiento_seguimiento { get; set; }
        public virtual DbSet<usuario> usuario { get; set; }
        public virtual DbSet<venta> venta { get; set; }
        public virtual DbSet<venta_medicamento> venta_medicamento { get; set; }
        public virtual DbSet<venta_servicio> venta_servicio { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<cita>()
                .Property(e => e.fecha)
                .HasPrecision(6);

            modelBuilder.Entity<cita>()
                .Property(e => e.observaciones)
                .IsUnicode(false);

           

            modelBuilder.Entity<empleado>()
                .Property(e => e.primer_nombre)
                .IsUnicode(false);

            modelBuilder.Entity<empleado>()
                .Property(e => e.segundo_nombre)
                .IsUnicode(false);

            modelBuilder.Entity<empleado>()
                .Property(e => e.primer_apellido)
                .IsUnicode(false);

            modelBuilder.Entity<empleado>()
                .Property(e => e.segundo_apellido)
                .IsUnicode(false);

            modelBuilder.Entity<empleado>()
                .Property(e => e.telefono)
                .IsUnicode(false);

            modelBuilder.Entity<empleado>()
                .Property(e => e.celular)
                .IsUnicode(false);

           

            modelBuilder.Entity<enfermedad>()
                .Property(e => e.descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<enfermedad>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<enfermedad>()
                .HasMany(e => e.enfermedad_seguimiento)
                .WithRequired(e => e.enfermedad)
                .HasForeignKey(e => e.id_nfermedad)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<enfermedad_seguimiento>()
                .Property(e => e.observaciones)
                .IsUnicode(false);

            modelBuilder.Entity<estado_cita>()
                .Property(e => e.nombre)
                .IsUnicode(false);

           

            modelBuilder.Entity<formula>()
                .Property(e => e.observacion)
                .IsUnicode(false);

            modelBuilder.Entity<formula>()
                .HasMany(e => e.posologia)
                .WithRequired(e => e.formula)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<formula>()
                .HasMany(e => e.seguimiento_clinico)
                .WithRequired(e => e.formula)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<genero>()
                .Property(e => e.nombre)
                .IsUnicode(false);

          


           

            modelBuilder.Entity<medicamento>()
                .Property(e => e.nombre)
                .IsUnicode(false);

           

            modelBuilder.Entity<medicamento_presentacion>()
                .Property(e => e.contenido)
                .IsUnicode(false);

            modelBuilder.Entity<medicamento_presentacion>()
                .HasMany(e => e.movimiento_medicamento)
                .WithRequired(e => e.medicamento_presentacion)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<medicamento_presentacion>()
                .HasMany(e => e.posologia)
                .WithRequired(e => e.medicamento_presentacion)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<medicamento_presentacion>()
                .HasMany(e => e.venta_medicamento)
                .WithRequired(e => e.medicamento_presentacion)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<modulos>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<modulos>()
                .HasMany(e => e.permiso)
                .WithRequired(e => e.modulos)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<movimiento>()
                .Property(e => e.observacion)
                .IsUnicode(false);

            modelBuilder.Entity<movimiento>()
                .HasMany(e => e.movimiento_medicamento)
                .WithRequired(e => e.movimiento)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<paciente>()
                .Property(e => e.primer_nombre)
                .IsUnicode(false);

            modelBuilder.Entity<paciente>()
                .Property(e => e.segundo_nombre)
                .IsUnicode(false);

            modelBuilder.Entity<paciente>()
                .Property(e => e.primer_apellido)
                .IsUnicode(false);

            modelBuilder.Entity<paciente>()
                .Property(e => e.segundo_apellido)
                .IsUnicode(false);

            modelBuilder.Entity<paciente>()
                .Property(e => e.correo)
                .IsUnicode(false);

            modelBuilder.Entity<paciente>()
                .Property(e => e.direccion)
                .IsUnicode(false);

            modelBuilder.Entity<paciente>()
                .Property(e => e.tipo_sangre)
                .IsUnicode(false);


            modelBuilder.Entity<paciente>()
                .HasMany(e => e.paciente_antecedente)
                .WithRequired(e => e.paciente)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<paciente>()
                .HasMany(e => e.venta)
                .WithRequired(e => e.paciente)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<paciente_antecedente>()
                .Property(e => e.descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<posologia>()
                .Property(e => e.dosis)
                .IsUnicode(false);

            modelBuilder.Entity<posologia>()
                .Property(e => e.frecuencia)
                .IsUnicode(false);

            modelBuilder.Entity<presentacion>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            

            modelBuilder.Entity<rol>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<rol>()
                .HasMany(e => e.permiso)
                .WithRequired(e => e.rol)
                .WillCascadeOnDelete(false);

            

            modelBuilder.Entity<seguimiento_clinico>()
                .Property(e => e.motivo_consulta)
                .IsUnicode(false);

            modelBuilder.Entity<seguimiento_clinico>()
                .Property(e => e.sintomatologia)
                .IsUnicode(false);

            modelBuilder.Entity<seguimiento_clinico>()
                .HasMany(e => e.enfermedad_seguimiento)
                .WithRequired(e => e.seguimiento_clinico)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<seguimiento_clinico>()
                .HasMany(e => e.tratamiento_seguimiento)
                .WithRequired(e => e.seguimiento_clinico)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<servicio>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<servicio>()
                .Property(e => e.descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<servicio>()
                .HasMany(e => e.venta_servicio)
                .WithRequired(e => e.servicio)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tipo_antecedente>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<tipo_antecedente>()
                .HasMany(e => e.paciente_antecedente)
                .WithRequired(e => e.tipo_antecedente)
                .HasForeignKey(e => e.id_tipo_antecedente)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tipo_documento>()
                .Property(e => e.nombre)
                .IsUnicode(false);

           

          

            modelBuilder.Entity<tratamiento>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<tratamiento>()
                .Property(e => e.descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<tratamiento>()
                .HasMany(e => e.tratamiento_seguimiento)
                .WithRequired(e => e.tratamiento)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tratamiento_seguimiento>()
                .Property(e => e.observaciones)
                .IsUnicode(false);

            modelBuilder.Entity<usuario>()
                .Property(e => e.nombre_usuario)
                .IsUnicode(false);

            modelBuilder.Entity<usuario>()
                .Property(e => e.contraseña)
                .IsUnicode(false);

            modelBuilder.Entity<usuario>()
                .Property(e => e.correo)
                .IsUnicode(false);

           
            modelBuilder.Entity<venta>()
                .HasMany(e => e.venta_medicamento)
                .WithRequired(e => e.venta)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<venta>()
                .HasMany(e => e.venta_servicio)
                .WithRequired(e => e.venta)
                .WillCascadeOnDelete(false);

           
        }
    }
}
