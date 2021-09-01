using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoHelperTerminal.View.IODoc;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MoHelperTerminal.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : MasterDetailPage
    {
        public MainPage()
        {
            InitializeComponent();
            Detail = new NavigationPage(new IODocPage());
        }

        private void IODoc_Clicked(object sender, EventArgs e)
        {
            IsPresented = false;
            Detail = new NavigationPage(new IODocPage());
        }

        private void Setting_Clicked(object sender, EventArgs e)
        {
            IsPresented = false;
            Detail = new NavigationPage(new SettingPage());
        }
    }
}