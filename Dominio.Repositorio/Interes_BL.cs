using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Entidades;
using Infraestructura.Data.SqlServer;

namespace Dominio.Repositorio
{
    public class Interes_BL
    {
        Interes_DAL i_dal = new Interes_DAL();

        public string registrar(long animal, long interesado) {
            return i_dal.registrar(animal,interesado);
        }

        public List<Interes_Tuneado> listar(long codanimal) {
            return i_dal.listar(codanimal);
        }

    }
}
