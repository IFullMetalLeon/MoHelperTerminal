using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using Plugin.Settings;
using Xamarin.Forms;
using MoHelperTerminal.Controller;
using Newtonsoft.Json;
using Acr.UserDialogs;
using MoHelperTerminal.Model;
using static MoHelperTerminal.Controller.HttpJsonItem;

namespace MoHelperTerminal.ViewModel.IODoc
{
    public class IODocPageVM : INotifyPropertyChanged
    {

        public string boxRn { get; set; }
        public string quant { get; set; }

        public IODocPageVM()
        {
            TerminalNumber = CrossSettings.Current.GetValueOrDefault("TerminalNumber", "");
            DocRn = "0";            
        }

        public void startPage()
        {
            MessagingCenter.Subscribe<string, string>("MainActivity", "GetBarcode", (sender, arg) =>
            {
                work(arg.Trim());
            });
            MessagingCenter.Subscribe<string, string>("HttpControler", "PostIODocSend", (sender, arg) =>
            {
                PostResponce(arg.Trim());
            });
        }

        public void endPage()
        {
            MessagingCenter.Unsubscribe<string, string>("MainActivity", "GetBarcode");
            MessagingCenter.Unsubscribe<string, string>("HttpControler", "PostIODocSend");
        }

        public void work(string _barcode)
        {
            UserDialogs.Instance.Loading("Обмен данными");
            HttpController.SendPostDocSpec(TerminalNumber, _barcode, DocRn, boxRn, "1", quant, "PostIODocSend");
        }

        public void PostResponce(string content)
        {
            if (content.Length > 2)
            {
                PostIODocResponce resp = JsonConvert.DeserializeObject<PostIODocResponce>(content, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
                DocRn = resp.doc_rn;
                
            }
            else
                showError("Ошибка распознования штрихкода");
        }

        public void showError(string error)
        {
            UserDialogs.Instance.HideLoading();
            UserDialogs.Instance.Alert(error, "Ошибка", "Ок");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        private string _docRn { get; set; }
        public string DocRn
        {
            get
            {
                return _docRn;
            }
            set
            {
                if (_docRn != value)
                {
                    _docRn = value;
                    OnPropertyChanged("DocRn");
                }
            }
        }

        private string _docNumb { get; set; }
        public string DocNumb
        {
            get
            {
                if (DocRn == "0")
                    return "Сканируйте штрихкод на документе";
                else
                    return _docNumb;
            }
            set
            {
                if (_docNumb != value)
                {
                    _docNumb = value;
                    OnPropertyChanged("DocNumb");
                }
            }
        }

        private string _docDate { get; set; }
        public string DocDate
        {
            get
            {
                return _docDate;
            }
            set
            {
                if (_docDate != value)
                {
                    _docDate = value;
                    OnPropertyChanged("DocDate");
                }
            }
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
    }
}
