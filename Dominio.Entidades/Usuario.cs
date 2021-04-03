using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Dominio.Entidades
{
    public class Usuario
    {
        [DisplayName("Código de Usuario")]
        public long CODUSUARIO       {get;set;}
        [DisplayName("Nombres")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo obligatorio")]
        [RegularExpression(@"^[a-zA-Z\s]{3,100}$", ErrorMessage = "Escriba nombres validos, no debe contener numeros ni caracteres especiales, entre 3 y 100 caracteres")]
        public string NOMBRES        {get;set;}
        [DisplayName("Apellidos")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo obligatorio")]
        [RegularExpression(@"^[a-zA-Z\s]{3,100}$", ErrorMessage = "Escriba apellidos validos, no debe contener numeros ni caracteres especiales, entre 3 y 100 caracteres")]
        public string APELLIDOS      {get;set;}
        [DisplayName("Fecha de nacimiento")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo obligatorio")]
        public DateTime FEC_NAC      {get;set;}
        [DisplayName("DNI")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo obligatorio")]
        [RegularExpression(@"^[0-9]{8}$", ErrorMessage = "DNI debe contener 8 digitos numericos")]
        public string DNI            {get;set;}
        [DisplayName("Sexo")]
        public int SEXO              {get;set;}
        [DisplayName("Dirección")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo obligatorio")]
        [MaxLength(200, ErrorMessage = "Ingresar maximo hasta 200 caracteres")]
        public string DIRECCION      {get;set;}
        [DisplayName("E-mail")]      
        [RegularExpression(@"^(.{0,50}@[a-z]{0,10}\.[a-z]{0,3})*$",ErrorMessage ="Ingresar una dirección de E-mail válida")]
        public string EMAIL          {get;set;}
        [DisplayName("Teléfono")]        
        [RegularExpression(@"^([0-9]{9,11})*$", ErrorMessage = "Ingrese un numero telefonico válido")]
        public string TELEFONO       {get;set;}
        [DisplayName("Id de Usuario")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo obligatorio")]
        [RegularExpression(@"^[a-zA-Z0-9]{5,20}$",ErrorMessage ="Cree un id de 5 a 20 caracteres alfanuméricos. No se permiten espacios ni caracteres especiales.")]
        public string IDLOGIN        {get;set;}
        [DisplayName("Contraseña")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo obligatorio")]
        [RegularExpression(@"^[0-9a-zA-Z]{5,100}$", ErrorMessage = "Minimo 8 caracteres y máximo 100 caracteres")]
        public string PASS           {get;set;}
       public bool ESTADO           {get;set;}
       public string FOTO { get; set; }

        public Usuario(bool eSTADO)
        {
            ESTADO = eSTADO;
        }

        public Usuario()
        {
        }
    }
}
