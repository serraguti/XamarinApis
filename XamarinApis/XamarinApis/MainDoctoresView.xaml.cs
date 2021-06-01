using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinApis.Code;
using XamarinApis.Views;

namespace XamarinApis
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainDoctoresView : MasterDetailPage
    {
        public MainDoctoresView()
        {
            InitializeComponent();
            ObservableCollection<MasterPageItem> menu =
                new ObservableCollection<MasterPageItem>();
            MasterPageItem doctoresview =
                new MasterPageItem
                {
                    Titulo = "Doctores"
                ,
                    Tipo = typeof(DoctoresView),
                    Icono = "sable.png"
                };
            menu.Add(doctoresview);
            MasterPageItem favoritosView =
                new MasterPageItem
                {
                    Titulo = "Doctores favoritos"
                ,
                    Tipo = typeof(DoctoresFavoritosView),
                    Icono = "clone.png"
                };
            menu.Add(favoritosView);
            this.listviewMenu.ItemsSource = menu;
            //PONEMOS UNA PAGINA COMO PRESENTACION
            Detail =
            new NavigationPage((Page)
            Activator.CreateInstance(typeof(CochesView)));
            this.listviewMenu.ItemSelected += ListviewMenu_ItemSelected;
        }

        private void ListviewMenu_ItemSelected(object sender
            , SelectedItemChangedEventArgs e)
        {
            var item = (MasterPageItem)e.SelectedItem;
            var tipo = item.Tipo;
            Detail =
                new NavigationPage((Page)Activator.CreateInstance(tipo));
            IsPresented = false;
        }
    }
}