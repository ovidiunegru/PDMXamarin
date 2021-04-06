using Microcharts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace seminar2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class IstoricPage : ContentPage
    {
        public IstoricPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            List<Curs> listaCurs = new DaoCurs().ObtineCursValuta("EUR");
            List<ChartEntry> dateGrafic = new List<ChartEntry>();

            foreach(Curs curs in listaCurs)
            {
                dateGrafic.Add(
                    new ChartEntry((float)curs.Valoare)
                    {
                        Label = curs.Data,
                        ValueLabel = curs.Valoare.ToString()
                    });
            }

            chartViewCurs.Chart = new LineChart();
            chartViewCurs.Chart.Entries = dateGrafic;
        }
    }
}