using seminar2.ViewModels;
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
public partial class ConvertorPage : ContentPage
{
    List<Curs> listaCurs;
    List<string> listaValute = new List<string>();

    public ConvertorPage()
    {
            InitializeComponent();
            ConvertorViewModel convertorViewModel = new ConvertorViewModel();
            BindingContext = convertorViewModel;
         }
    }
}