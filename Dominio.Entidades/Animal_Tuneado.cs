using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;



namespace Dominio.Entidades
{
    public class Animal_Tuneado
    {
        [Display(Name = "Codigo identificador")]
        public long CODANIMAL { get; set; }
        [Display(Name = "Nombre")]
        public string NOMBRE { get; set; }
        [Display(Name = "Estado de adopción")]
        public string ESTADO { get; set; }
        [Display(Name = "Edad")]
        public string EDAD { get; set; }
        [Display(Name = "Sexo")]
        public string SEXO { get; set; }
        [Display(Name = "Peso Aproximado")]
        public string PESO { get; set; }
        [Display(Name = "Tamaño")]
        public string TAMAÑO { get; set; }
        [Display(Name = "Descripción")]
        public string DESCRIPCION { get; set; }
        

        public long TIPO { get; set; }


        [Display(Name = "Tipo")]
        public string DESC_TIPO { get; set; }
        

        public long RAZA { get; set; }

        [Display(Name = "Raza")]
        public string DESC_RAZA { get; set; }
        [Display(Name = "Nombre del dueño")]
        public string DUEÑO { get; set; }
        [Display(Name = "Foto")]
        public string FOTO { get; set; }

        public int CODESTADO { get; set; }
        public long CODUSUARIO { get; set; }

    }
}
