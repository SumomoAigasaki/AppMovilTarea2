using AppMovilTarea2.Modelos;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppMovilTarea2
{
    public partial class App : Application
    {
        public static string UbicacionDB = string.Empty;

        static BaseDatos BD;
        public static BaseDatos InstanciaBD
        {
            get
            {
                if (BD == null)
                {
                    BD = new BaseDatos(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "archivo.db3"));
                }
                return BD;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }
        public App(String DBLocal)
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
            UbicacionDB = DBLocal;
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
