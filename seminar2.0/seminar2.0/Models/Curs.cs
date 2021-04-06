using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace seminar2
{
    public class Curs
    {
        public Curs()
        {
            Multiplicatori = 1;
        }
        //[Column("id")]
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; } 
        public int Multiplicatori { get; set; } //1
        public string Valuta { get; set; } //USD
        public double Valoare{ get; set; } //4.10
        public string Data{ get; set; } //2021-03-10
        [Ignore]
        public string Drapel //us.png
        {
            get
            {
                return Valuta.Substring(0,2).ToLower() + ".png";
            }
        } 


    }
}
