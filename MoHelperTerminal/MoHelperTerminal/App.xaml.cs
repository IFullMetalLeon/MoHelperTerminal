using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MoHelperTerminal.View;
using Plugin.Settings;

namespace MoHelperTerminal
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //CrossSettings.Current.AddOrUpdateValue("BarcodeEvent", "android.intent.ACTION_DECODE_DATA");
           // CrossSettings.Current.AddOrUpdateValue("BarcodeString", "barcode_string");
           // CrossSettings.Current.AddOrUpdateValue("TerminalNumber", "a_0");
            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
