using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Dominio.Entidades;

namespace Infraestructura.Data.SqlServer
{
    public class TipoAnimal_DAL
    {
        Conexion_DAL conexion = new Conexion_DAL();

        public List<TipoAnimal> lista()
        {
            List<TipoAnimal> temp = new List<TipoAnimal>();

            conexion.con.Open();
            SqlCommand cmd = new SqlCommand("select *  from TIPOANIMAL order by DESC_TIPO asc", conexion.con);
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                TipoAnimal t = new TipoAnimal
                {
                    CODTIPO = sdr.GetInt64(0),
                    DESC_TIPO = sdr.GetString(1)
                };
                temp.Add(t);

            }
            sdr.Close(); conexion.con.Close();
            return temp;
        }
    }
}
