using AppMovilTarea2.View;
using AppMovilTarea2.ViewModel;
using AppMovilTarea2.Modelos;

using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System;

namespace AppMovilTarea2
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new EmpleadoViewModel(this);
        }

        private async void list_Clicked(object sender, EventArgs e)
        {
               await Navigation.PushAsync(new ListContenido());
            
        }
    }
}
