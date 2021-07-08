using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace MoHelperTerminal.Model.IODoc
{
    public class IODocBox : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        private string _rn { get; set; }
        public string Rn
        {
            get
            {
                return _rn;
            }
            set
            {
                if (_rn != value)
                {
                    _rn = value;
                    OnPropertyChanged("Rn");
                }
            }
        }

        private string _boxNum { get; set; }
        public string BoxNum
        {
            get
            {
                return _boxNum;
            }
            set
            {
                if (_boxNum != value)
                {
                    _boxNum = value;
                    OnPropertyChanged("BoxNum");
                }
            }
        }

        private string _modifName { get; set; }
        public string ModifName
        {
            get
            {
                return _modifName;
            }
            set
            {
                if (_modifName != value)
                {
                    _modifName = value;
                    OnPropertyChanged("ModifName");
                }
            }
        }

        private string _quant { get; set; }
        public string Quant
        {
            get
            {
                return _quant;
            }
            set
            {
                if (_quant != value)
                {
                    _quant = value;
                    OnPropertyChanged("Quant");
                }
            }
        }

        private string _quantFact { get; set; }
        public string QuantFact
        {
            get
            {
                return _quantFact;
            }
            set
            {
                if (_quantFact != value)
                {
                    _quantFact = value;
                    OnPropertyChanged("QuantFact");
                }
            }
        }

        private bool _isSelected { get; set; }
        public bool IsSelected
        {
            get
            {
                return _isSelected;
            }
            set
            {
                if (_isSelected != value)
                {
                    _isSelected = value;
                    OnPropertyChanged("IsSelected");
                }
            }
        }
    }
}
