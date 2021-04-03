using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Entidades;
using Infraestructura.Data.SqlServer;

namespace Dominio.Repositorio
{
    public class Adopcion_BL
    {
        Adopcion_DAL a_dal = new Adopcion_DAL();

        public string registrar(Adopcion a)
        {
            return a_dal.registrar(a);
        }
    }
}
