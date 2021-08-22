using AppMovilTarea2.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppMovilTarea2.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListContenido : ContentPage
    {
        public ListContenido()
        {
            InitializeComponent();
            BindingContext = new ListviewModel(this);
        }
        
    }
}