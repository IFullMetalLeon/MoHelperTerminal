using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoHelperTerminal.ViewModel.IODoc;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MoHelperTerminal.View.IODoc
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class IODocPage : ContentPage
    {
        public IODocPageVM iodpvm { get; set; }
        public IODocPage()
        {
            InitializeComponent();
            iodpvm = new IODocPageVM() { Navigation = this.Navigation};
            this.BindingContext = iodpvm;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            iodpvm.startPage();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            iodpvm.endPage();
        }

        private void ioDocSpec_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            iodpvm.showMark();
        }
    }
}