using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace MoHelperTerminal.Model.IODoc
{
    public class IODocMark : INotifyPropertyChanged
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

        private string _pref { get; set; }
        public string Pref
        {
            get
            {
                return _pref;
            }
            set
            {
                if (_pref != value)
                {
                    _pref = value;
                    OnPropertyChanged("Pref");
                }
            }
        }

        private string _numb { get; set; }
        public string Numb
        {
            get
            {
                return _numb;
            }
            set
            {
                if (_numb != value)
                {
                    _numb = value;
                    OnPropertyChanged("Numb");
                }
            }
        }

        private string _modifName { get; set;}
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

        private bool _isScaned { get; set; }
        public bool IsScaned
        {
            get
            {
                return _isScaned;
            }
            set
            {
                if (_isScaned != value)
                {
                    _isScaned = value;
                    OnPropertyChanged("IsScaned");
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
