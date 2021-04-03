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
    public class Animal_DAL
    {
        Conexion_DAL conexion = new Conexion_DAL();

        public string registrar(Animal a)
        {
            string msg;
            conexion.con.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("SP_REGISTRAR_ANIMAL", conexion.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NOMBRE", a.NOMBRE);
                cmd.Parameters.AddWithValue("@EDAD", a.EDAD);
                cmd.Parameters.AddWithValue("@SEXO", a.SEXO);
                cmd.Parameters.AddWithValue("@PESO", a.PESO);
                cmd.Parameters.AddWithValue("@TAMAÑO", a.TAMAÑO);
                cmd.Parameters.AddWithValue("@DESCRIPCION", a.DESCRIPCION);
                cmd.Parameters.AddWithValue("@TIPO", a.TIPO);
                cmd.Parameters.AddWithValue("@RAZA", a.RAZA);
                cmd.Parameters.AddWithValue("@DUEÑO", a.DUEÑO);
                cmd.Parameters.AddWithValue("@FOTO", a.FOTO);
                cmd.ExecuteNonQuery();
                msg = "Se registró su mascota correctamente.";

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

        public string editar(Animal a)
        {
            string msg;
            conexion.con.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("SP_EDITAR_ANIMAL", conexion.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CODANIMAL", a.CODANIMAL);
                cmd.Parameters.AddWithValue("@NOMBRE",          a.NOMBRE        );
                cmd.Parameters.AddWithValue("@EDAD",            a.EDAD         );
                cmd.Parameters.AddWithValue("@SEXO",            a.SEXO           );
                cmd.Parameters.AddWithValue("@PESO",            a.PESO           );
                cmd.Parameters.AddWithValue("@TAMAÑO",          a.TAMAÑO         );
                cmd.Parameters.AddWithValue("@DESCRIPCION",     a.DESCRIPCION    );
                cmd.Parameters.AddWithValue("@RAZA",            a.RAZA           );
                cmd.Parameters.AddWithValue("@FOTO", a.FOTO);

                cmd.ExecuteNonQuery();
                msg = "Se actualizó correctamente los datos de la mascota.";

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

        public List<Animal> listaAnimales()
        {
            List<Animal> temp = new List<Animal>();
            conexion.con.Open();
            SqlCommand cmd = new SqlCommand("select * from animal", conexion.con);
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                Animal a = new Animal();
                a.CODANIMAL = sdr.GetInt64(0);
                a.NOMBRE = sdr.GetString(1);
                a.ESTADO = sdr.GetInt32(2);
                a.EDAD = sdr.GetInt32(3);
                a.SEXO = sdr.GetInt32(4);
                a.PESO = sdr.GetDecimal(5);
                a.TAMAÑO = sdr.GetInt32(6);
                a.DESCRIPCION = sdr.GetString(7);
                a.TIPO = sdr.GetInt64(8);
                a.RAZA = sdr.GetInt64(9);
                a.DUEÑO = sdr.GetInt64(10);
                a.FOTO = sdr.GetString(11);
                temp.Add(a);
            }        
            sdr.Close(); conexion.con.Close();
            return temp;
        }

        public List<Animal_Tuneado> lista(long? dueño, long? tipo, long? raza)
        {
            long dueño_b, tipo_b, raza_b;
            if (dueño == null) dueño_b = 0;
            else dueño_b = dueño.Value;

            if (tipo == null) tipo_b = 0;
            else tipo_b = tipo.Value;

            if (raza == null) raza_b = 0;
            else raza_b = raza.Value;

            List<Animal_Tuneado> temp = new List<Animal_Tuneado>();
            //string query;
            //if (dueño == null && tipo == null && raza == null) query = "EXEC SP_VER_MASCOTAS_RAZA_TIPO 0,0,0";
            //else if (dueño == null)
            //    query = "EXEC SP_VER_MASCOTAS_RAZA_TIPO " + tipo + "," + raza + ",0";
            //else
            //    query = "EXEC SP_VER_MASCOTAS_RAZA_TIPO " + tipo + "," + raza + "," + dueño;
            //conexion.con.Open();
            //SqlCommand cmd = new SqlCommand(query, conexion.con); 
            conexion.con.Open();
            SqlCommand cmd = new SqlCommand("SP_VER_MASCOTAS_RAZA_TIPO", conexion.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@DUEÑO", dueño_b);
            cmd.Parameters.AddWithValue("@TIPO", tipo_b);
            cmd.Parameters.AddWithValue("@RAZA", raza_b);
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                Animal_Tuneado at = new Animal_Tuneado();                
                at.CODANIMAL = sdr.GetInt64(0);
                at.NOMBRE = sdr.GetString(1);
                at.CODESTADO = sdr.GetInt32(2);
                at.ESTADO = sdr.GetString(3);
                at.EDAD = sdr.GetString(4);
                at.SEXO = sdr.GetString(5);
                at.PESO = sdr.GetString(6);
                at.TAMAÑO = sdr.GetString(7);
                at.DESCRIPCION = sdr.GetString(8);
                at.TIPO = sdr.GetInt64(9);
                at.DESC_TIPO = sdr.GetString(10);
                at.RAZA = sdr.GetInt64(11);
                at.DESC_RAZA = sdr.GetString(12);
                at.CODUSUARIO = sdr.GetInt64(13);
                at.DUEÑO = sdr.GetString(14);
                at.FOTO = sdr.GetString(15);
                temp.Add(at);

            }
               
            
            sdr.Close(); conexion.con.Close();
            return temp;
  
        }

        public List<Animal_Tuneado> mis_mascotas_anadidas(long dueño) {

            List<Animal_Tuneado> temp = new List<Animal_Tuneado>();  
            conexion.con.Open();
            SqlCommand cmd = new SqlCommand("select * from VW_ANIMAL_TUNEADO where CODUSUARIO=@codusuario", conexion.con);
            cmd.Parameters.AddWithValue("@codusuario",dueño);
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                Animal_Tuneado at = new Animal_Tuneado();
                at.CODANIMAL = sdr.GetInt64(0);
                at.NOMBRE = sdr.GetString(1);
                at.CODESTADO = sdr.GetInt32(2);
                at.ESTADO = sdr.GetString(3);
                at.EDAD = sdr.GetString(4);
                at.SEXO = sdr.GetString(5);
                at.PESO = sdr.GetString(6);
                at.TAMAÑO = sdr.GetString(7);
                at.DESCRIPCION = sdr.GetString(8);
                at.TIPO = sdr.GetInt64(9);
                at.DESC_TIPO = sdr.GetString(10);
                at.RAZA = sdr.GetInt64(11);
                at.DESC_RAZA = sdr.GetString(12);
                at.CODUSUARIO = sdr.GetInt64(13);
                at.DUEÑO = sdr.GetString(14);
                at.FOTO = sdr.GetString(15);
                temp.Add(at);

            }


            sdr.Close(); conexion.con.Close();
            return temp;

        }


        public List<Animal_Tuneado> mis_mascotas_favoritas(long interesado)
        {

            List<Animal_Tuneado> temp = new List<Animal_Tuneado>();
            conexion.con.Open();
            SqlCommand cmd = new SqlCommand("SP_VER_MASCOTAS_FAVORITAS", conexion.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CODUSUARIO", interesado);
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                Animal_Tuneado at = new Animal_Tuneado();
                at.CODANIMAL = sdr.GetInt64(0);
                at.NOMBRE = sdr.GetString(1);
                at.CODESTADO = sdr.GetInt32(2);
                at.ESTADO = sdr.GetString(3);
                at.EDAD = sdr.GetString(4);
                at.SEXO = sdr.GetString(5);
                at.PESO = sdr.GetString(6);
                at.TAMAÑO = sdr.GetString(7);
                at.DESCRIPCION = sdr.GetString(8);
                at.TIPO = sdr.GetInt64(9);
                at.DESC_TIPO = sdr.GetString(10);
                at.RAZA = sdr.GetInt64(11);
                at.DESC_RAZA = sdr.GetString(12);
                at.CODUSUARIO = sdr.GetInt64(13);
                at.DUEÑO = sdr.GetString(14);
                at.FOTO = sdr.GetString(15);
                temp.Add(at);

            }


            sdr.Close(); conexion.con.Close();
            return temp;

        }


        public Animal_Tuneado detalle(long cod) {
            return lista(null,0,0).Where(x=>x.CODANIMAL == cod).FirstOrDefault();
        }

        public long cod_autogenerado() {
            if (conexion.con.State == ConnectionState.Open) conexion.con.Close();
            SqlCommand cmd = new SqlCommand("SP_AUTOGENEREA_ANIMAL", conexion.con);
            conexion.con.Open();
            long cod = long.Parse(cmd.ExecuteScalar().ToString());
            conexion.con.Close();
            return cod;           
        }
    }
}
