using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.presentation.common.inputView
{
    class InputViewModel : BaseViewModel
    {
        private string propertyInput;

        public string PropertyInput
        {
            get
            {
                return propertyInput;
            }
            set
            {
                propertyInput = value;
                NotifyPropertyChanged("PropertyInput");
            }
        }
    }
}
