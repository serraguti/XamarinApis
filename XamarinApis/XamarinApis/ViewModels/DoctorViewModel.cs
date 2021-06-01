﻿using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using XamarinApis.Base;
using XamarinApis.Models;
using XamarinApis.Services;

namespace XamarinApis.ViewModels
{
    public class DoctorViewModel: ViewModelBase
    {
        ServiceDoctores ServiceDoctores;
        
        public DoctorViewModel(ServiceDoctores serviceDoctores)
        {
            this.ServiceDoctores = serviceDoctores;
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

        public Command InsertarDoctor
        {
            get
            {
                return new Command(async() =>
                {
                    await this.ServiceDoctores
                    .InsertDoctorAsync(Doctor.IdDoctor
                    , Doctor.Apellido, Doctor.Especialidad
                    , Doctor.IdHospital, Doctor.Salario);
                    await Application.Current.MainPage.DisplayAlert("Alert"
                        , "Doctor insertado", "OK");
                });
            }
        }
    }
}