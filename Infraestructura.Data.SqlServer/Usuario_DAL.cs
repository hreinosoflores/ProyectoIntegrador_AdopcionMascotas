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
    public class Usuario_DAL
    {
        Conexion_DAL conexion = new Conexion_DAL();

        public string registrar(Usuario u) {
            string msg;
            conexion.con.Open();
            try {
                SqlCommand cmd = new SqlCommand("SP_REGISTRAR_USUARIO", conexion.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NOMBRES",u.NOMBRES);
                cmd.Parameters.AddWithValue("@APELLIDOS", u.APELLIDOS);
                cmd.Parameters.AddWithValue("@FEC_NAC", u.FEC_NAC);
                cmd.Parameters.AddWithValue("@DNI", u.DNI);
                cmd.Parameters.AddWithValue("@SEXO",u.SEXO);
                cmd.Parameters.AddWithValue("@DIRECCION", u.DIRECCION);
                cmd.Parameters.AddWithValue("@EMAIL",u.EMAIL);
                cmd.Parameters.AddWithValue("@TELEFONO", u.TELEFONO);
                cmd.Parameters.AddWithValue("@IDLOGIN", u.IDLOGIN);
                cmd.Parameters.AddWithValue("@PASS",u.PASS);
                cmd.Parameters.AddWithValue("@FOTO", u.FOTO);
                cmd.ExecuteNonQuery();
                msg = "Se registró correctamente. Bienvenido(a).";

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

        public string editar(Usuario u) {
            string msg;
            conexion.con.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("SP_EDITAR_USUARIO", conexion.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CODUSUARIO", u.CODUSUARIO);
                cmd.Parameters.AddWithValue("@DIRECCION", u.DIRECCION);
                cmd.Parameters.AddWithValue("@EMAIL", u.EMAIL);
                cmd.Parameters.AddWithValue("@TELEFONO", u.TELEFONO);
                cmd.Parameters.AddWithValue("@IDLOGIN", u.IDLOGIN);
                cmd.Parameters.AddWithValue("@PASS", u.PASS);
                cmd.ExecuteNonQuery();
                msg = "Sus datos han sido correctamente actualizados";

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

        public List<Usuario_Tuneado> listar() {
            List<Usuario_Tuneado> temp = new List<Usuario_Tuneado>();
            conexion.con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM VW_USUARIO_TUNEADO", conexion.con);
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                Usuario_Tuneado u = new Usuario_Tuneado();
                u.CODUSUARIO = sdr.GetInt64(0);
                u.NOMBRES = sdr.GetString(1);
                u.FEC_NAC = sdr.GetString(2);
                u.DNI = sdr.GetString(3);
                u.SEXO = sdr.GetString(4);
                u.DIRECCION = sdr.GetString(5);
                u.EMAIL = sdr.GetString(6);
                u.TELEFONO = sdr.GetString(7);
                u.FOTO = sdr.GetString(8);
                u.ESTADO= sdr.GetString(9);
                temp.Add(u);
            }
            sdr.Close(); conexion.con.Close();
            return temp;
        
        }

        public Usuario logueo(string idlogin, string password) {
            Usuario u=null;
            conexion.con.Open();
            SqlCommand cmd = new SqlCommand("select * from USUARIO where (IDLOGIN=@idlogin OR EMAIL=@idlogin) and PASS=@password", conexion.con);
            cmd.Parameters.AddWithValue("@idlogin", idlogin);
            cmd.Parameters.AddWithValue("@password", password);
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.Read())
            {
                u = new Usuario();
                u.CODUSUARIO = sdr.GetInt64(0);
                u.NOMBRES = sdr.GetString(1);
                u.APELLIDOS = sdr.GetString(2);
                u.FEC_NAC = sdr.GetDateTime(3);
                u.DNI = sdr.GetString(4);
                u.SEXO = sdr.GetInt32(5);
                u.DIRECCION = sdr.GetString(6);
                u.EMAIL = sdr.GetString(7);
                u.TELEFONO = sdr.GetString(8);
                u.IDLOGIN = sdr.GetString(9);
                u.PASS = sdr.GetString(10);
                u.ESTADO = sdr.GetBoolean(11);
                u.FOTO = sdr.GetString(12);
            }
            sdr.Close(); conexion.con.Close();
            return u;
        
        }

    }
}
