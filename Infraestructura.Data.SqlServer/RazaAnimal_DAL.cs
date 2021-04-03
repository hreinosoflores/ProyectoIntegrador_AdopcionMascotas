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
    public class RazaAnimal_DAL
    {
        Conexion_DAL conexion = new Conexion_DAL();

        public List<RazaAnimal> lista(long tipo) {
            List<RazaAnimal> temp = new List<RazaAnimal>();
            conexion.con.Open();
            SqlCommand cmd = new SqlCommand("select *  from RAZAANIMAL where CODTIPO=@tipo order by DESC_RAZA asc ", conexion.con);
            cmd.Parameters.AddWithValue("@tipo",tipo);
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                RazaAnimal r = new RazaAnimal
                {
                    CODTIPO = sdr.GetInt64(0),
                    CODRAZA = sdr.GetInt64(1),
                    DESC_RAZA = sdr.GetString(2)
                };
                temp.Add(r);

            }
            sdr.Close(); conexion.con.Close();
            return temp;
        }
    }
}
