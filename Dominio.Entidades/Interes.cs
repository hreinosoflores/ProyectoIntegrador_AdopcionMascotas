using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class Interes
    {
      public long  ANIMAL       {get;set;}
      public long  INTERESADO   {get;set;}
      public int  ESTADO        {get;set;}
      public DateTime  FEC_INI  {get;set;}
      public DateTime FEC_ATE   {get;set;}
      public DateTime FEC_RESP { get; set; }

    }
}
