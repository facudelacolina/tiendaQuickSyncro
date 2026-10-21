using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncroTiendaQuick
{
    class ConResponse
    {
        public String _error { get; set; }
        public String mensaje { get; set; }
        public String valor { get; set; }
        public String VALIDO { get; set; }
    }

    public class Integracion
    {
        public String _fecha { get; set; }
        public String link_api { get; set; }
    }
}
