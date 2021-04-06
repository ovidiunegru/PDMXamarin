using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using SQLite;

namespace seminar2
{
    public class DaoCurs
    {

        SQLiteConnection connection;
        public DaoCurs() 
        {
            string caleBazaDeDate = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) , "curs_valutar.db");
            connection = new SQLiteConnection(caleBazaDeDate);
            connection.CreateTable<Curs>();

        }

        public int AdaugaCurs(Curs curs)
        {
            return connection.Insert(curs);
        }

        public int AdaugaListaCurs(List<Curs> listaCurs)
        {
            return connection.InsertAll(listaCurs);
        }

        public List<Curs> ObtineCursDinData(string data)
        {
            return connection.Query<Curs>("Select * from Curs where Data = ?", data);

        }
        public List<Curs> ObtineCursValuta(string valuta)
        {
            return connection.Query<Curs>("Select * from Curs where Valuta = ?", valuta);
        }


    }
}
