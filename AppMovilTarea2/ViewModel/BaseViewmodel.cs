using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace AppMovilTarea2.ViewModel
{
    public class BaseViewModel : INotifyPropertyChanged
    {
       
        public BaseViewModel()
        {
           
        }
        bool isBusy = false;
        bool isEmpty = true;
        bool isNotConnect;
        bool wasChanged = false;
        string networkMessage;
        string title = string.Empty;
        /*Se utilizan para validar el estado de la conexión*/

        public bool IsNotConnect
        {
            get { return isNotConnect; }
            set { SetProperty(ref isNotConnect, value); }
        }

        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        public bool IsEmpty
        {
            get { return isEmpty; }
            set { SetProperty(ref isEmpty, value); }
        }


        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        public string NetworkMessage { get => networkMessage; set => SetProperty(ref networkMessage, value); }
        public bool WasChanged { get => wasChanged; set => SetProperty(ref wasChanged, value); }

        protected bool SetProperty<T>(ref T backingStore, T value, [CallerMemberName] string propertyName = "", Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

       
    }
}
