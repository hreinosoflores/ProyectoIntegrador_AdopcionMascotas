using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Dominio.Entidades
{
    public class Animal
    {
        [DisplayName("Codigo del animal")]
        public long CODANIMAL { get; set; }
        [DisplayName("Nombre")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo obligatorio")]
        [RegularExpression(@"^[a-zA-Z\s]{3,100}$", ErrorMessage = "Escriba un nombre valido, no debe contener numeros ni caracteres especiales, entre 3 y 100 caracteres")]
        public string NOMBRE { get; set; }
        [DisplayName("Estado de adopción")]
        public int ESTADO { get; set; }
        [DisplayName("Edad(años)")]
        [Range(0, 20, ErrorMessage = "Edad fuera del rango establecido")]
        public int? EDAD { get; set; }
        [DisplayName("Sexo")]
        public int SEXO { get; set; }
        [DisplayName("Peso aproximado en Kg.")]
        [DataType(DataType.Currency)]
        public decimal? PESO          {get;set;}
        [DisplayName("Tamaño")]
        public int TAMAÑO            {get;set;}
        [DisplayName("Descripción")]
        [MaxLength(200, ErrorMessage = "Ingresar maximo hasta 200 caracteres")]
        [DataType(DataType.MultilineText)]
        public string DESCRIPCION    {get;set;}
        [DisplayName("Tipo")]
        public long TIPO             {get;set;}
        [DisplayName("Raza")]
        public long RAZA             {get;set;}
        [DisplayName("Dueño")]
        public long DUEÑO            {get;set;}
        [DisplayName("Foto")]
        public string FOTO { get; set; }

        public Animal()
        {
        }

       
        public Animal(long tIPO,long dUEÑO)
        {   
            TIPO = tIPO;
            DUEÑO = dUEÑO;
        }
    }
}
