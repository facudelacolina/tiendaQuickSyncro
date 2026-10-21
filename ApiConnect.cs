using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Data;
using System.Web;
using System.IO;
using System.Text;

namespace SyncroTiendaQuick
{
    class ApiConnect
    {
        public static String SendRequest(string link, string json, string contentType, string method)
        {
            Uri Uri = new Uri(link);
            string data = json;

            string data1 = "";
            data1 = data.Replace(@"\u0027", "'");

            System.Net.ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(Uri);
            req.ContentType = contentType;
            req.Method = method;

            var res = "";

            try
            {
                if (method == "POST")
                {
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append(data);

                    System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();

                    byte[] bytes = encoding.GetBytes(data);
                    req.ContentLength = bytes.Length;
                    using (Stream writeStream = req.GetRequestStream())
                    {
                        writeStream.Write(bytes, 0, bytes.Length);
                    }
                }


                ConResponse obj = new ConResponse();

                var response = req.GetResponse().GetResponseStream();
                HttpWebResponse resp = (HttpWebResponse)req.GetResponse();

                System.Text.StringBuilder sb1 = new System.Text.StringBuilder();
                sb1.Append(resp.StatusCode);

                Stream receiveStream = resp.GetResponseStream();

                // Pipes the stream to a higher level stream reader with the required encoding format.
                StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);

                if (resp.StatusCode.ToString() == "OK")
                {
                    res = readStream.ReadToEnd();
                }
                else
                {
                    res = "ERROR";
                }
            }
            catch (Exception ex)
            {
                res = "ERROR";
            }

            return res;
        }
    }
}
