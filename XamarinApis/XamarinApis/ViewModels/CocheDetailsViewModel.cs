using System;
using System.Collections.Generic;
using System.Text;
using XamarinApis.Base;
using XamarinApis.Models;

namespace XamarinApis.ViewModels
{
    public class CocheDetailsViewModel: ViewModelBase
    {
        private Coche _Coche;
        public Coche Coche
        {
            get { return this._Coche; }
            set
            {
                this._Coche = value;
                OnPropertyChanged("Coche");
            }
        }
    }
}
