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
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class SP_DETALLE_ANIMAL_Result
    {
        [Display(Name ="Codigo identificador")]
        public long CODANIMAL { get; set; }
        [Display(Name = "Nombre")]
        public string NOMBRE { get; set; }
        [Display(Name = "Estado de adopción")]
        public string ESTADO { get; set; }
        [Display(Name = "Edad")]
        public Nullable<int> EDAD { get; set; }
        [Display(Name = "Sexo")]
        public string SEXO { get; set; }
        [Display(Name = "Peso Aproximado")]
        public Nullable<decimal> PESO { get; set; }
        [Display(Name = "Tamaño")]
        public string TAMAÑO { get; set; }
        [Display(Name = "Descripción")]
        public string DESCRIPCION { get; set; }
        [Display(Name = "Tipo")]
        public string DESC_TIPO { get; set; }
        [Display(Name = "Raza")]
        public string DESC_RAZA { get; set; }
        [Display(Name = "Nombre del dueño")]
        public string DUEÑO { get; set; }
        [Display(Name = "Foto")]
        public string FOTO { get; set; }
    }
}
