using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinApis.Base;
using XamarinApis.Models;
using XamarinApis.Services;
using XamarinApis.Views;

namespace XamarinApis.ViewModels
{
    public class DoctoresViewModel: ViewModelBase
    {
        ServiceDoctores ServiceDoctores;

        public DoctoresViewModel(ServiceDoctores servicedoctores)
        {
            this.ServiceDoctores = servicedoctores;
            Task.Run(async () =>
            {
                await this.CargarDoctoresAsync();
            });
            MessagingCenter.Subscribe<DoctoresViewModel>
                (this, "REFRESH", async(sender) => {
                    await this.CargarDoctoresAsync();
                });
        }

        private ObservableCollection<Doctor> _Doctores;
        public ObservableCollection<Doctor> Doctores
        {
            get { return this._Doctores; }
            set
            {
                this._Doctores = value;
                OnPropertyChanged("Doctores");
            }
        }

        private async Task CargarDoctoresAsync()
        {
            List<Doctor> doctores =
                await this.ServiceDoctores.GetDoctoresAsync();
            this.Doctores = new ObservableCollection<Doctor>(doctores);
        }

        public Command DetallesDoctor
        {
            get
            {

                return new Command((doctor) =>
                {
                    //RECIBIMOS EL DOCTOR Y LO MANDAMOS A 
                    //OTRA VISTA/VIEWMODEL
                    //CREAMOS EL VIEWMODEL
                    DoctorDetallesViewModel viewmodel =
                    App.ServiceLocator.DoctorDetallesViewModel;
                    //CREAMOS LA VISTA
                    DoctorDetallesView view = new DoctorDetallesView();
                    view.BindingContext = viewmodel;
                    viewmodel.Doctor = doctor as Doctor;
                    Application.Current.MainPage.Navigation.PushModalAsync
                    (view);
                });
            }
        }

        public Command MarcarFavorito
        {
            get
            {
                return new Command(async (doctor) =>
                {
                    SessionService session =
                    App.ServiceLocator.SessionService;
                    session.Favoritos.Add(doctor as Doctor);
                    await Application.Current.MainPage.DisplayAlert("Alert"
                        , "Doctor almacenado", "OK");
                });
            }
        }

        public Command MostrarFavoritos
        {
            get
            {
                return new Command(async() =>
                {
                    DoctoresFavoritosView view =
                    new DoctoresFavoritosView();
await Application.Current.MainPage.Navigation.PushModalAsync(view);
                });
            }
        }
    }
}
