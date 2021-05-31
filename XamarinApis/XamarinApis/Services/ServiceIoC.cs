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
            //SERVICIO API
            builder.RegisterType<ServiceDoctores>();
            this.container = builder.Build();
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
