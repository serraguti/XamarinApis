using Autofac;
using System;
using System.Collections.Generic;
using System.Text;
using XamarinApis.ViewModels;

namespace XamarinApis.Services
{
    public class ServiceIoC
    {
        IContainer container;

        public ServiceIoC()
        {
            this.RegisterDependencies();
        }

        private void RegisterDependencies()
        {
            ContainerBuilder builder = new ContainerBuilder();
            //EMPEZAMOS A DECLARAR OBJETOS QUE NECESITAMOS QUE
            //TENGAN COMUNICACION
            //VIEWMODELS
            builder.RegisterType<DoctoresViewModel>();
            builder.RegisterType<DoctorDetallesViewModel>();
            builder.RegisterType<DoctoresFavoritosViewModel>();
            builder.RegisterType<DoctorViewModel>();
            //SERVICIO API
            builder.RegisterType<ServiceDoctores>();
            //ELEMENTOS DE SESSION
            builder.RegisterType<SessionService>().SingleInstance();
            this.container = builder.Build();
        }

        public DoctorViewModel DoctorViewModel
        {
            get
            {
                return this.container.Resolve<DoctorViewModel>();
            }
        }

        public DoctoresFavoritosViewModel DoctoresFavoritosViewModel
        {
            get
            {
                return this.container.Resolve<DoctoresFavoritosViewModel>();
            }
        }

        public SessionService SessionService
        {
            get
            {
                return this.container.Resolve<SessionService>();
            }
        }

        //NECESITAMOS PROPIEDADES PARA PODER HACER LOS BINDING
        //DENTRO DE XAML SOBRE LAS VISTAS
        public DoctoresViewModel DoctoresViewModel
        {
            get
            {
                return this.container.Resolve<DoctoresViewModel>();
            }
        }

        public DoctorDetallesViewModel DoctorDetallesViewModel
        {
            get
            {
                return this.container.Resolve<DoctorDetallesViewModel>();
            }
        }
    }
}
