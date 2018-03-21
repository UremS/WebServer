using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServer
{
    class Program
    {
        static void Main(string[] args)
        {
          HttpListener httplistener = new HttpListener();
            httplistener.Prefixes.Add("http://localhost:3030/");
            httplistener.Start();

            while (true)
            {
                Console.WriteLine("İstemci belkeniyor...");
                HttpListenerContext cx = httplistener.GetContext();

                Console.WriteLine("İstemci bağlandı.");

                HttpListenerRequest req = cx.Request;
                HttpListenerResponse res = cx.Response;

                Console.WriteLine("İstenen Adres: ");
                Console.WriteLine(req.Url);

                string veri = "Hosgeldiniz. Saat: " + DateTime.Now.ToLongTimeString();
                veri += "<br/>";
                veri += "Istediginiz Adres: " + req.RawUrl;

                byte[] gonderilecekVeri = Encoding.UTF8.GetBytes(veri);

                res.AddHeader("Content-Type", "text/html; charset=uft-8");

                res.OutputStream.Write(gonderilecekVeri, 0, gonderilecekVeri.Length);

                cx.Response.Close();
        }
    }
}
