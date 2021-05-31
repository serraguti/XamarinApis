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

        public DoctoresViewModel()
        {
            this.ServiceDoctores = new ServiceDoctores();
            Task.Run(async () =>
            {
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
                    new DoctorDetallesViewModel();
                    //CREAMOS LA VISTA
                    DoctorDetallesView view = new DoctorDetallesView();
                    view.BindingContext = viewmodel;
                    viewmodel.Doctor = doctor as Doctor;
                    Application.Current.MainPage.Navigation.PushModalAsync
                    (view);
                });
            }
        }
    }
}
