using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;

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

        public string MarkTC
        {
            get
            {
                if (IsScaned)
                    return "Green";
                else
                    return "Orange";
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

    public class Grouping<K, T> : ObservableCollection<T>
    {
        public K Name { get; private set; }
        public Grouping(K name, IEnumerable<T> items)
        {
            Name = name;
            foreach (T item in items)
                Items.Add(item);
        }
    }
}
