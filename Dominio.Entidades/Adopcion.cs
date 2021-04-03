using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class Adopcion
    {
       public long CODADOPCION  {get;set;}
       public long ANIMAL       {get;set;}
       public long INTERESADO   {get;set;}
       public DateTime FEC_ADOP { get; set; }
    }
}
