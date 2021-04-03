using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace Dominio.Entidades
{
    public class Interes_Tuneado
    {
        [DisplayName("Código identificador")]
        public long  CODUSUARIO           {get;set;}
        [DisplayName("Nombre del interesado")]
        public string      INTERESADO     {get;set;}
        [DisplayName("Fecha y hora de Interés")]
        public string FECHAINTERES { get; set; }
    }
}
