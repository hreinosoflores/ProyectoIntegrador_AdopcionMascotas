//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProyectoIntegrador_AdopcionMascotas.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class BD_SISTEMA_ADOPCIONEntities : DbContext
    {
        public BD_SISTEMA_ADOPCIONEntities()
            : base("name=BD_SISTEMA_ADOPCIONEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ADOPCION> ADOPCION { get; set; }
        public virtual DbSet<ANIMAL> ANIMAL { get; set; }
        public virtual DbSet<RAZAANIMAL> RAZAANIMAL { get; set; }
        public virtual DbSet<TIPOANIMAL> TIPOANIMAL { get; set; }
        public virtual DbSet<USUARIO> USUARIO { get; set; }
    
        public virtual ObjectResult<SP_BUSQUEDA_RAZA_ANIMAL_Result> SP_BUSQUEDA_RAZA_ANIMAL(string rAZA)
        {
            var rAZAParameter = rAZA != null ?
                new ObjectParameter("RAZA", rAZA) :
                new ObjectParameter("RAZA", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_BUSQUEDA_RAZA_ANIMAL_Result>("SP_BUSQUEDA_RAZA_ANIMAL", rAZAParameter);
        }
    
        public virtual ObjectResult<SP_BUSQUEDA_TIPO_ANIMAL_Result> SP_BUSQUEDA_TIPO_ANIMAL(string tIPO)
        {
            var tIPOParameter = tIPO != null ?
                new ObjectParameter("TIPO", tIPO) :
                new ObjectParameter("TIPO", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_BUSQUEDA_TIPO_ANIMAL_Result>("SP_BUSQUEDA_TIPO_ANIMAL", tIPOParameter);
        }
    
        public virtual ObjectResult<SP_DETALLE_ANIMAL_Result> SP_DETALLE_ANIMAL()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_DETALLE_ANIMAL_Result>("SP_DETALLE_ANIMAL");
        }
    }
}
