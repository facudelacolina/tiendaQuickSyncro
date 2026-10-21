using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace SyncroTiendaQuick
{
    class Data
    {
        public static DataTable obtenerDatosIntegracion()
        {
            //Config con  = new Config();
            String Cadena = "";
            Cadena = Dato.getCadena();
            SqlConnection Conector = new SqlConnection(Cadena);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandTimeout = 0; //Wait indefinitely
            cmd.Connection = Conector;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM Integracion WHERE aplicacion = 'TQ'";

            using (SqlDataAdapter sda = new SqlDataAdapter())
            {
                cmd.Connection = Conector;
                sda.SelectCommand = cmd;
                using (DataSet ds = new DataSet())
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    return dt;
                }
            }
        }
    }
}
