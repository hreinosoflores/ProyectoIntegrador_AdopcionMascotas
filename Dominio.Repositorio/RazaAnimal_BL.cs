using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Entidades;
using Infraestructura.Data.SqlServer;

namespace Dominio.Repositorio
{
    public class RazaAnimal_BL
    {
        RazaAnimal_DAL r_dal = new RazaAnimal_DAL();

        public List<RazaAnimal> lista(long tipo) {
            return r_dal.lista(tipo);
        }
    }
}
