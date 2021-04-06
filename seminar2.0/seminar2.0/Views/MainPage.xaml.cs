using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace seminar2
{
    public partial class MainPage : ContentPage
    {
        List<Curs> listaCurs;

        public  MainPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            DaoCurs daoCurs = new DaoCurs();

            listaCurs = daoCurs.ObtineCursDinData(DateTime.Now.ToString("yyyy-MM-dd")); 

            if (listaCurs.Count == 0)
            {
                // await Task.Run(async () =>
                // {
                listaCurs = await Net.PreiaCurs(Net.URL);
                daoCurs.AdaugaListaCurs(listaCurs);
                //});
            }
            listViewCurs.ItemsSource = listaCurs;

            BindingContext = listaCurs[0];
        }




        //https://bnr.ro/nbrfxrates.xml
        void InitializeazaListaCurs()
        {
            listaCurs = new List<Curs>();


            //Curs cursRON = new Curs() { Data = "2021-03-10", Valuta = "RON", Valoare = 1 };
            Curs cursEUR = new Curs() { Data = "2021-03-10", Valuta = "EUR", Valoare = 4.88 };
            Curs cursUSD = new Curs() { Data = "2021-03-10", Valuta = "USD", Valoare = 4.10 };
            Curs cursHUF = new Curs() { Data = "2021-03-10", Valuta = "HUF", Valoare = 1.33, Multiplicatori = 100 };

            //listaCurs.Add(cursRON);
            listaCurs.Add(cursEUR);
            listaCurs.Add(cursUSD);
            listaCurs.Add(cursHUF);
        }
    }
}
