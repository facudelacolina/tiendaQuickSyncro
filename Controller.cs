using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Data;
using System.Web;
using System.Threading.Tasks;

namespace SyncroTiendaQuick
{
    class Controller
    {
        public static Integracion obtenerDatosIntegracion()
        {
            Integracion objIntegracion = new Integracion();

            try
            {
                DataTable dt = Data.obtenerDatosIntegracion();
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow fila in dt.Rows)
                    {
                        objIntegracion._fecha = fila["ultima_actualizacion"].ToString();
                        objIntegracion.link_api = fila["link_api"].ToString();
                    }
                }
            }
            catch (Exception e)
            {
                objIntegracion = null;
                Console.WriteLine("ERROR AL BUSCAR DATOS DE INTEGRACION");
                Console.WriteLine(e.Message.ToString());
            }

            return objIntegracion;
        }
    }
}