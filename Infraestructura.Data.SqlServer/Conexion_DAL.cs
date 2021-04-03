using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Infraestructura.Data.SqlServer
{
    public class Conexion_DAL
    {
        //public SqlConnection con { get; } = new SqlConnection(@"Server=LAPTOPINFOR\SQLEXPRESS; DataBase=BD_SISTEMA_ADOPCION; Uid=sa; Pwd=sql;");

        public SqlConnection con { get; } = new SqlConnection("Server=PCINFOR\\SQLEXPRESS; DataBase=BD_SISTEMA_ADOPCION; Uid=sa; Pwd=sql;");

        //public SqlConnection con { get; } = new SqlConnection("Server=.; DataBase=BD_SISTEMA_ADOPCION; Uid=sa; Pwd=sql;");

    }
}
