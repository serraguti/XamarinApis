using Plugin.SharedTransitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinApis.Models;
using XamarinApis.ViewModels;

namespace XamarinApis.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CochesCollectionView : ContentPage
    {
        public CochesCollectionView()
        {
            InitializeComponent();
            //this.collectionViewCoches.SelectionChanged += CollectionViewCoches_SelectionChanged;
        }

        //private async void CollectionViewCoches_SelectionChanged(object sender
        //    , SelectionChangedEventArgs e)
        //{
        //    if (e.CurrentSelection.Any())
        //    {
        //        Coche car = e.CurrentSelection.FirstOrDefault() as Coche;
        //        CocheDetailsViewModel viewmodel =
        //        new CocheDetailsViewModel();
        //        viewmodel.Coche = car;
        //        CocheDetailsView view =
        //        new CocheDetailsView();
        //        view.BindingContext = viewmodel;
        //        SharedTransitionNavigationPage.SetTransitionSelectedGroup
        //        (this, car.IdCoche.ToString());
        //        await Navigation.PushAsync(view);
        //    }
        //}
    }
}