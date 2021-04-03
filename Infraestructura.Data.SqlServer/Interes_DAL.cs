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
    public class Interes_DAL
    {
        Conexion_DAL conexion = new Conexion_DAL();

        public string registrar(long animal,long interesado) {
            string msg;
            conexion.con.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO INTERES(ANIMAL,INTERESADO) VALUES(@ANIMAL,@INTERESADO)", conexion.con);
                cmd.Parameters.AddWithValue("@ANIMAL", animal);
                cmd.Parameters.AddWithValue("@INTERESADO", interesado);
                cmd.ExecuteNonQuery();
                msg = "Mascota en proceso de adopción. Esperar por respuesta del dueño.";

            }
            catch (Exception e)
            {
                msg = "Hubo un error: " + e.Message;
            }
            finally
            {
                conexion.con.Close();
            }


            return msg;

        }

        public List<Interes_Tuneado> listar(long codanimal) {
            List<Interes_Tuneado> temp = new List<Interes_Tuneado>();
            conexion.con.Open();
            SqlCommand cmd = new SqlCommand("SP_VER_INTERESADOS", conexion.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CODANIMAL",codanimal);
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                Interes_Tuneado it = new Interes_Tuneado();
                it.CODUSUARIO= sdr.GetInt64(0);
                it.INTERESADO = sdr.GetString(1);
                it.FECHAINTERES = sdr.GetString(2);
                temp.Add(it);
            }
            sdr.Close(); conexion.con.Close();
            return temp;
        } 

    }
}
