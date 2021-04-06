using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace seminar2.ViewModels
{
    public class ConvertorViewModel : INotifyPropertyChanged
    {
        Dictionary<string, Curs> dictCurs = new Dictionary<string, Curs>();
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string prop)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
        public string ValoareDeConvertit { get; set; }
        private string rezultat = string.Empty;
        public string Rezultat {
            get
            {
                return rezultat;
            }
            set
            {
                rezultat = value;
                OnPropertyChanged("Rezultat");
            }
        }
        public string ValutaSursa
        {
            get;set;
        }
        public string ValutaDestinatie { get; set; }
        List<Curs> listaCurs;


        public List<string> ListaValute { get; set; }
        public ICommand ConvertesteCommand { get; set; }

        public ConvertorViewModel()
        {
            listaCurs = new DaoCurs().ObtineCursDinData(DateTime.Now.ToString("yyyy-MM-dd"));

            this.listaCurs.Add(new Curs() { Valuta = "RON", Valoare = 1 });

            ListaValute = new List<string>();

            foreach (Curs c in listaCurs)
            {
                ListaValute.Add(c.Valuta);
                dictCurs.Add(c.Valuta, c);
            }

            ValutaSursa = "RON";
            Rezultat = "0";
            ValutaDestinatie = "RON";

            ConvertesteCommand = new Command(Converteste_Click);
        }

        private void Converteste_Click()
        {
            /* 1. obtinere valoare de convertit
             * 2. obtinere obiect de tip curs asociate valuetelor selectate
             * 3. edecutarea conversiei
             * 4. afisarea rezultatului
             */
            double valoare = 0;
            double.TryParse(ValoareDeConvertit, out valoare);

            Curs cursSursa, cursDestinatie;

            cursSursa = dictCurs[ValutaSursa];
            cursDestinatie = dictCurs[ValutaDestinatie];

            double rezultat = 0;
            //3.

            rezultat = valoare * cursSursa.Valoare * cursDestinatie.Multiplicatori / (cursDestinatie.Valoare * cursSursa.Multiplicatori);

            Rezultat = rezultat.ToString();

        }
    }
}
