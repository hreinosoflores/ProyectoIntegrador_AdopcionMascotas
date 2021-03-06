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
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class ANIMAL
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ANIMAL()
        {
            this.ADOPCION = new HashSet<ADOPCION>();
        }

        public ANIMAL(int eSTADO, long tIPO, long dUEÑO)
        {
            ESTADO = eSTADO;
            TIPO = tIPO;
            DUEÑO = dUEÑO;
        }

        [DisplayName("Codigo del animal")]
        public long CODANIMAL { get; set; }
        [DisplayName("Nombre")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo obligatorio")]
        [MaxLength(100, ErrorMessage = "Ingresar maximo hasta 100 caracteres")]
        public string NOMBRE { get; set; }
        [DisplayName("Estado de adopción")]
        public int ESTADO { get; set; }
        [DisplayName("Edad")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo obligatorio")]
        [Range(0, 20, ErrorMessage = "Edad fuera del rango establecido")]
        public Nullable<int> EDAD { get; set; }
        [DisplayName("Sexo")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo obligatorio")]
        public string SEXO { get; set; }
        [DisplayName("Peso aproximado")]
        public Nullable<decimal> PESO { get; set; }
        [DisplayName("Tamaño")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo obligatorio")]
        public string TAMAÑO { get; set; }
        [DisplayName("Descripción")]
        [MaxLength(200, ErrorMessage = "Ingresar maximo hasta 200 caracteres")]
        [DataType(DataType.MultilineText)]
        public string DESCRIPCION { get; set; }
        [DisplayName("Tipo")]
        public long TIPO { get; set; }
        [DisplayName("Raza")]
        public long RAZA { get; set; }
        [DisplayName("Nombre del dueño")]
        public long DUEÑO { get; set; }
        [DisplayName("Foto")]
        public string FOTO { get; set; }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ADOPCION> ADOPCION { get; set; }
        public virtual RAZAANIMAL RAZAANIMAL { get; set; }


        
    }
}
