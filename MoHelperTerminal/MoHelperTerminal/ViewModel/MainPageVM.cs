using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using Plugin.Settings;

namespace MoHelperTerminal.ViewModel
{
    public class MainPageVM : INotifyPropertyChanged
    {
        public MainPageVM()
        {
            TerminalNumber = CrossSettings.Current.GetValueOrDefault("TerminalNumber", "");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        private string _terminalNumber { get; set; }
        public string TerminalNumber
        {
            get
            {
                return _terminalNumber;
            }
            set
            {
                if (_terminalNumber != value)
                {
                    _terminalNumber = value;
                    OnPropertyChanged("TerminalNumber");
                }
            }
        }

        private string _magNumber { get; set; }
        public string MagNumber
        {
            get
            {
                return _magNumber;
            }
            set
            {
                if (_magNumber != value)
                {
                    _magNumber = value;
                    OnPropertyChanged("MagNumber");
                }
            }
        }
    }
}
