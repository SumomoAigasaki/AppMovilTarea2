using AppMovilTarea2;
using AppMovilTarea2.Modelos;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppMovilTarea2.ViewModel
{
    public class ListviewModel:BaseViewModel
    {
        Page Page;
        ObservableCollection<Empleado> empleado;

        public Empleado PagoSelected { get => empleadoSelected; set { SetProperty(ref empleadoSelected, value); } }


        public Command DeleteServiceCommand { protected set; get; }
        public Command DeleteInformation { get; }
        Empleado empleadoSelected;
        ObservableCollection<Empleado> listEmpleadoSelected;

        public ObservableCollection<Empleado> ListaEmpleadoSelected { get => listEmpleadoSelected; set => SetProperty(ref listEmpleadoSelected, value); }
        public Command UpdateCommand { get; }
        public Command SelectedCommand { get; }
        Empleado empleadoselect;
        
        //private string urlphoto;
        //private string descripcion;
        //private double monto;
        //private string fecha;
        //private int idpago;

        int idEmpleado;
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
        public ObservableCollection<Empleado> ListaEmpleado
        {
            get => empleado; set => SetProperty(ref empleado, value);
        }
        



        public ListviewModel(Page pag)
        {
            Page = pag;

            cargar();
            ListaEmpleadoSelected = new ObservableCollection<Empleado>();
            eliminar();
            //DeleteServiceCommand = new Command<Empleado>((empleadoselect) => {
            //    if (ListaEmpleadoSelected != null)
            //    {

            //        App.InstanciaBD.EliminarEmpleado(empleadoselect);
                                       
            //        ListaEmpleadoSelected.Remove(empleadoselect);
            //    }
            //});

            UpdateCommand = new Command<Empleado>((empleadoselect) => {
                if (ListaEmpleadoSelected != null)
                {

                    App.InstanciaBD.InsertarEmpleado(empleadoselect);

                }
            });
        }

        public async void eliminar()
        {
            DeleteServiceCommand = new Command<Empleado>(async (empleadoselect) => {
                if (ListaEmpleadoSelected != null)
                {
                    App.InstanciaBD.EliminarEmpleado(empleadoselect);
                    await Page.DisplayAlert("Aviso", "Se borro el  dato " + empleadoselect.Nombre +" "+ empleadoselect.Apellido, "Ok");
                    ListaEmpleadoSelected.Remove(empleadoselect);
                    cargar();
                }
            });

           
        }
        public async void cargar()
        {
            var list = await App.InstanciaBD.ObtenerEmpleado();
            if (list != null)

                ListaEmpleado = new ObservableCollection<Empleado>(list);

        }

        public async void selected()
        {
            var selected = await App.InstanciaBD.ObtenerEmpleado();
            
        }
        public async void Delete()
        {
            await App.InstanciaBD.EliminarEmpleado(empleadoselect);
        }
        


    }
}
