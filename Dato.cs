using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace SyncroTiendaQuick
{
    class Dato
    {
        public static String getCadena()
        {
            string link = "";
            using (var reader = new StreamReader("C:/appSyncroWc/config.txt"))
            {
                int i = 0;
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (i == 0)
                    {
                        link = line;
                    }
                    i++;
                }
            }

            return link;
        }
    }
}
