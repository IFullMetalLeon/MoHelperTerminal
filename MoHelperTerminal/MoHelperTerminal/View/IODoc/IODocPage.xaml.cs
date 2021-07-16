using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoHelperTerminal.ViewModel.IODoc;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MoHelperTerminal.Model.IODoc;

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
            MessagingCenter.Subscribe<string, IODocSpec>("IODocPageXaml", "Scroll", (sender, arg) => {
                myScroll(arg);
            });
        }

        

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            iodpvm.endPage();
            MessagingCenter.Unsubscribe<string, IODocSpec>("IODocPageXaml", "Scroll");
        }
        public void myScroll(IODocSpec item)
        {
            foreach (IODocSpec q in this.ioDocSpec.ItemsSource)
            {
                if (q.Rn == item.Rn)
                {
                    this.ioDocSpec.SelectedItem = q;
                    this.ioDocSpec.ScrollTo(q, ScrollToPosition.MakeVisible, false);                   
                    break;
                }
            }
        }
    }
}