using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncroTiendaQuick
{
    class Program
    {
        static void Main(string[] args)
        {
            Integracion objIntegracion = new Integracion();
            objIntegracion = Controller.obtenerDatosIntegracion();
            String resp = "";

            Console.WriteLine("SINCRO PEDIDOS");
            if (objIntegracion != null)
            {
                Console.WriteLine("OBJETO CON DATOS DE INTEGRACION");
                Console.WriteLine("Link API - " + objIntegracion.link_api);
                Console.WriteLine("Fecha - " + objIntegracion._fecha);
                resp = ApiConnect.SendRequest(objIntegracion.link_api + "pedidosQuick", "", "application/json", "GET");

                if (resp != "ERROR" && resp != "[]" && resp != "null")
                {
                    ConResponse objResp = new ConResponse();
                    var valido = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ConResponse>>(resp);
                    objResp = valido.Find(x => x.VALIDO == "N");
                }

                Console.WriteLine(resp);
                string createText = "SINCRO PEDIDOS " + resp + " Hora sincro: " + DateTime.Now + Environment.NewLine;
                File.WriteAllText("C:/appSyncroTq/log.txt", createText);
            }
        }
    }
}
