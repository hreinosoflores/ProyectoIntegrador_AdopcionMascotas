using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Dominio.Entidades
{
    public class Usuario_Tuneado
    {

        [DisplayName("Código identificador")]
        public long CODUSUARIO { get; set; }
        [DisplayName("Nombres y apellidos")]
        public string NOMBRES { get; set; }
        [DisplayName("Fecha de nacimiento")]
        public string FEC_NAC { get; set; }

        public string DNI { get; set; }
        [DisplayName("Sexo")]
        public string SEXO { get; set; }
        [DisplayName("Domicilio Fiscal")]
        public string DIRECCION { get; set; }
        [DisplayName("Correo electrónico")]
        public string EMAIL { get; set; }
        [DisplayName("Nro. de telefóno")]
        public string TELEFONO { get; set; }
        public string FOTO { get; set; }
        [DisplayName("Estado Actual")]
        public string ESTADO { get; set; }
    }
}
