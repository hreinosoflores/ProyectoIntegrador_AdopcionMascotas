using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Entidades;
using Infraestructura.Data.SqlServer;

namespace Dominio.Repositorio
{
    public class TipoAnimal_BL
    {
        TipoAnimal_DAL t_dal = new TipoAnimal_DAL();

        public List<TipoAnimal> lista()
        {
            return t_dal.lista();
        }
    }
}
