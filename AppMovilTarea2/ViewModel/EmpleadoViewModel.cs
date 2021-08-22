
using AppMovilTarea2;
using AppMovilTarea2.Modelos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppMovilTarea2.ViewModel
{
    public class EmpleadoViewModel : BaseViewModel
    {
        Page Page;

        public Command SaveInformation { get; }
        public Command TakePhotoCommand { get; }
        public Command OpenGalleryCommand { get; }
        public Command SelectMedia { get; }
        public Command ClearCommand { get; }
        public Command SendVerifyCommand { get; }

        //String UrlFoto;
      
        string nombre;
        string apellido;
        double edad;
        string puesto;
        string direccion;

        public string Nombre
        {
            get => nombre;
            set => SetProperty(ref nombre, value);
        }
        public string Apellido
        {
            get => apellido;
            set => SetProperty(ref apellido, value);
        }
        public string Puesto
        {
            get => puesto;
            set => SetProperty(ref puesto, value);
        }
        public string Direccion
        {
            get => direccion;
            set => SetProperty(ref direccion, value);
        }
        public double Edad
        {
            get => edad;
            set => SetProperty(ref edad, value);
        }

        public EmpleadoViewModel(Page pag)
        {
            Page = pag;

            SaveInformation = new Command(SalvarPago);
            SendVerifyCommand = new Command(SalvarPago);
            ClearCommand= new Command(Clear);
        }
        
        public async void SalvarPago(object obj)
        {

            if (string.IsNullOrEmpty(Nombre) || string.IsNullOrEmpty(Apellido) || string.IsNullOrEmpty(Direccion) || string.IsNullOrEmpty(Puesto) || Edad==0)
            {
                await Page.DisplayAlert("Campos Vacios", "Verificacion de datos enviados" +Nombre+ "-- "+ Apellido+" "+ Direccion + " " + Puesto + " " + edad +" Si los datos no coinciden con los ingresados rectifique bien", "Ok");
            }
            else
            {
                var empleados = new Empleado
                {
                    Nombre= Nombre,
                    Apellido= Apellido,
                    Direccion= Direccion,
                    Puesto= Puesto,
                    Edad = Convert.ToDouble(Edad)
                };

                {
                    int resultado = await App.InstanciaBD.InsertarEmpleado(empleados);

                    if (resultado > 0)
                    {
                        await Page.DisplayAlert("Aviso", "Felicidades :D ! Se ah guardado exitosamente", "Ok");

                        Clear();
                    }
                        
                    else
                        await Page.DisplayAlert("Aviso", "Error", "Ok");
                }
            }
        }

        private async void Clear()
        {
            Nombre = " ";
            Apellido = " ";
            Direccion = " ";
            Puesto = " ";
            Direccion = " ";
            Edad = 0;
        }


       

       
    }
}
