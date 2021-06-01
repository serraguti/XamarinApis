using Plugin.SharedTransitions;
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
    public class CochesCollectionViewModel:ViewModelBase
    {
        ServiceCoches ServiceCoches;
        public CochesCollectionViewModel()
        {
            this.ServiceCoches = new ServiceCoches();
            Task.Run(async () =>
            {
                await this.LoadCarsAsync();
            });
        }

        private Coche _SelectedCoche;
        public Coche SelectedCoche
        {
            get { return this._SelectedCoche; }
            set
            {
                this._SelectedCoche = value;
                OnPropertyChanged("SelectedCoche");
            }
        }

        public Command MostrarDetalles
        {
            get
            {
                return new Command(async (coche) => {
                    //Coche car = coche as Coche;
                    CocheDetailsViewModel viewmodel =
                    new CocheDetailsViewModel();
                    viewmodel.Coche = this.SelectedCoche;
                    CocheDetailsView view =
                    new CocheDetailsView();
                    view.BindingContext = viewmodel;
                    SharedTransitionNavigationPage.SetTransitionSelectedGroup
                    (view, SelectedCoche.IdCoche.ToString());
                    await Application.Current.MainPage.Navigation
                    .PushAsync(view);
                });
            }
        }

        private async Task LoadCarsAsync()
        {
            List<Coche> coches = await this.ServiceCoches.GetCochesAsync();
            this.Coches =
                new ObservableCollection<Coche>(coches);
        }

        private ObservableCollection<Coche> _Coches;
        public ObservableCollection<Coche> Coches
        {
            get { return this._Coches; }
            set
            {
                this._Coches = value;
                OnPropertyChanged("Coches");
            }
        }
    }
}
