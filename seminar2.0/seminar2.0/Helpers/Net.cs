using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace seminar2
{
    class Net
    {
        //https://bnr.ro/nbrfxrates10days.xml
        //https://bnr.ro/nbrfxrates.xml
        public static string URL10 = "https://bnr.ro/nbrfxrates10days.xml";
        public static string URL = "https://bnr.ro/nbrfxrates.xml";


        public async static Task<List<Curs>> PreiaCurs(string url)
        {
            List<Curs> listaCurs = new List<Curs>();

            HttpClient httpClient = new HttpClient();
            Stream stream = await httpClient.GetStreamAsync(url);

            XmlReader reader = XmlReader.Create(stream);

            Curs curs = null;
            string data=null;

            while (reader.Read())
            {
                if (reader.IsStartElement())
                {
                    //if(reader.Name == "PublishingDate")
                    //{
                    //    //preluam data
                    //    reader.Read(); ;
                    //    data = reader.Value;

                    //}
                    if (reader.Name == "Cube")
                    {

                        data = reader["date"];

                    }
                    if (reader.Name == "Rate")
                    {
                        //preluam cursului curent
                        curs = new Curs();

                        curs.Valuta = reader["currency"];
                        if(reader["multiplier"] != null)
                        {
                            curs.Multiplicatori = int.Parse(reader["multiplier"]);
                        }

                        reader.Read();

                        curs.Valoare = double.Parse(reader.Value);
                        curs.Data = data;

                        listaCurs.Add(curs);
                    }
                }
            }
            
            return listaCurs;
        }
    }
}
