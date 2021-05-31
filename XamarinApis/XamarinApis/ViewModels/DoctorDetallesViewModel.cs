using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using XamarinApis.Base;
using XamarinApis.Models;
using XamarinApis.Services;

namespace XamarinApis.ViewModels
{
    public class DoctorDetallesViewModel: ViewModelBase
    {
        ServiceDoctores ServiceDoctores;

        public DoctorDetallesViewModel()
        {
            this.ServiceDoctores = new ServiceDoctores();
        }

        private Doctor _Doctor;
        public Doctor Doctor
        {
            get { return this._Doctor; }
            set
            {
                this._Doctor = value;
                OnPropertyChanged("Doctor");
            }
        }

        public Command EliminarDoctor
        {
            get
            {
                return new Command(async() =>
                {
                    await this.ServiceDoctores.DeleteDoctorAsync(Doctor.IdDoctor);
                    await Application.Current.MainPage.Navigation
                                        .PopModalAsync();
                });
            }
        }
    }
}
