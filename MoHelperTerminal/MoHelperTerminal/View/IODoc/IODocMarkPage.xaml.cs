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
    public partial class IODocMarkPage : ContentPage
    {
        public IODocMarkPageVM iodmpvm { get; set; }
        public IODocMarkPage(string doc_rn,string nommodif,string modif_name)
        {
            InitializeComponent();
            iodmpvm = new IODocMarkPageVM(doc_rn, nommodif, modif_name);
            this.BindingContext = iodmpvm;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            iodmpvm.startPage();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            iodmpvm.endPage();
        }
    }
}