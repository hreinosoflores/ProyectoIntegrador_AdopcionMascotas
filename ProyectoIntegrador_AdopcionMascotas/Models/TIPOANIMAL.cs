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
    using System.Collections.Generic;
    
    public partial class TIPOANIMAL
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TIPOANIMAL()
        {
            this.RAZAANIMAL = new HashSet<RAZAANIMAL>();
        }
    
        public long CODTIPO { get; set; }
        public string DESC_TIPO { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RAZAANIMAL> RAZAANIMAL { get; set; }
    }
}
