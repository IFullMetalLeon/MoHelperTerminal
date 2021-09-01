using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using Plugin.Settings;
using System.Windows.Input;
using Xamarin.Forms;

namespace MoHelperTerminal.ViewModel
{
    public class SettingPageVM : INotifyPropertyChanged
    {
        public ICommand SaveSetting { get; set; }
        public SettingPageVM()
        {
            SaveSetting = new Command(SaveSettingC); 

            TerminalNumber = CrossSettings.Current.GetValueOrDefault("TerminalNumber","");
            ShopNumber = CrossSettings.Current.GetValueOrDefault("ShopNumber", "");
            BarcodeEvent = CrossSettings.Current.GetValueOrDefault("BarcodeEvent", "android.intent.ACTION_DECODE_DATA");
            BarcodeString = CrossSettings.Current.GetValueOrDefault("BarcodeString", "barcode_string");
        }

        public void SaveSettingC()
        {
            CrossSettings.Current.AddOrUpdateValue("TerminalNumber", TerminalNumber);
            CrossSettings.Current.AddOrUpdateValue("ShopNumber", ShopNumber);
            CrossSettings.Current.AddOrUpdateValue("BarcodeEvent", BarcodeEvent);
            CrossSettings.Current.AddOrUpdateValue("BarcodeString", BarcodeString);
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

        private string _shopNumber { get; set; }
        public string ShopNumber
        {
            get
            {
                return _shopNumber;
            }
            set
            {
                if (_shopNumber != value)
                {
                    _shopNumber = value;
                    OnPropertyChanged("ShopNumber");
                }
            }
        }

        private string _barcodeEvent { get; set; }
        public string BarcodeEvent
        {
            get
            {
                return _barcodeEvent;
            }
            set
            {
                if (_barcodeEvent != value)
                {
                    _barcodeEvent = value;
                    OnPropertyChanged("BarcodeEvent");
                }
            }
        }

        private string _barcodeString { get; set; }
        public string BarcodeString
        {
            get
            {
                return _barcodeString;
            }
            set
            {
                if (_barcodeString != value)
                {
                    _barcodeString = value;
                    OnPropertyChanged("BarcodeString");
                }
            }
        }
    }
}
