using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Entidades;
using Infraestructura.Data.SqlServer;

namespace Dominio.Repositorio
{
    public class Usuario_BL
    {
        Usuario_DAL u_dal = new Usuario_DAL();

        public string registrar(Usuario u)
        {
            return u_dal.registrar(u);
        }

        public string editar(Usuario u)
        {
            return u_dal.editar(u);
        }

        public List<Usuario_Tuneado> lista()
        {
            return u_dal.listar();
        }


            public Usuario logueo(string idlogin, string password)
        {
            return u_dal.logueo(idlogin, password);
        }
    }
}
