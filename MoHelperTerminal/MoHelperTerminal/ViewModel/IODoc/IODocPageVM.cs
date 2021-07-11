using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;
using Plugin.Settings;
using Xamarin.Forms;
using MoHelperTerminal.Controller;
using Newtonsoft.Json;
using Acr.UserDialogs;
using MoHelperTerminal.Model;
using MoHelperTerminal.Model.IODoc;
using MoHelperTerminal.View.IODoc;
using static MoHelperTerminal.Controller.HttpJsonItem;

namespace MoHelperTerminal.ViewModel.IODoc
{
    public class IODocPageVM : INotifyPropertyChanged
    {

        public ObservableCollection<IODocSpec> ListSpec { get; set; }
        public INavigation Navigation { get; set; }

        public string boxRn { get; set; }
        public string quant { get; set; }

        public IODocPageVM()
        {
            TerminalNumber = CrossSettings.Current.GetValueOrDefault("TerminalNumber", "");
            ListSpec = new ObservableCollection<IODocSpec>();
            SelectedSpec = new IODocSpec();

            DocRn = "0";
            boxRn = "0";
            quant = "0";
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
            MessagingCenter.Subscribe<string, string>("HttpControler", "GetIODocHead", (sender, arg) =>
            {
                fillHead(arg.Trim());
            });
            MessagingCenter.Subscribe<string, string>("HttpControler", "GetIODocSpec", (sender, arg) =>
            {
                fillList(arg.Trim());
            });
            MessagingCenter.Subscribe<string, string>("HttpControler", "Error", (sender, arg) =>
            {
                showError(arg.Trim());
            });
        }

        public void endPage()
        {
            MessagingCenter.Unsubscribe<string, string>("MainActivity", "GetBarcode");
            MessagingCenter.Unsubscribe<string, string>("HttpControler", "PostIODocSend");
            MessagingCenter.Unsubscribe<string, string>("HttpControler", "GetIODocHead");
            MessagingCenter.Unsubscribe<string, string>("HttpControler", "GetIODocSpec");
            MessagingCenter.Unsubscribe<string, string>("HttpControler", "Error");
        }

        public void work(string _barcode)
        {
            //UserDialogs.Instance.Loading("Обмен данными");
            HttpController.SendPostDocSpec(TerminalNumber, _barcode, DocRn, boxRn, "1", quant, "PostIODocSend");
        }

        public void PostResponce(string content)
        {
            if (content.Length > 2)
            {
                PostIODocResponce resp = JsonConvert.DeserializeObject<PostIODocResponce>(content, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
                if (resp.type == "1")  //Документ
                {
                    DocRn = resp.doc_rn;
                    HttpController.SendGetIODocHead(DocRn);

                }
                HttpController.SendGetIODocSpec(DocRn);
            }
            else
                showError("Ошибка распознования штрихкода");
        }

        public void fillHead(string content)
        {
            if (content.Length > 2)
            {
                List<GetIODocHeadResponce> resp = JsonConvert.DeserializeObject<List<GetIODocHeadResponce>>(content, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
                
                DocNumb = resp[0].DOC_NUM;
                DocDate = resp[0].DOC_DATE;
            }
            else
                showError("Ошибка получения шапки документа");
            UserDialogs.Instance.HideLoading();
        }

        public void fillList(string content)
        {
            ListSpec.Clear();
            if (content.Length > 2)
            {
                List<GetIODocSpecResponce> resp = JsonConvert.DeserializeObject<List<GetIODocSpecResponce>>(content, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
                foreach(GetIODocSpecResponce cur in resp)
                {
                    ListSpec.Add(new IODocSpec { Rn = cur.NOMMODIF, ModifName = cur.MODIF_NAME, QuantFact = cur.QUANT_FACT, Quant = cur.QUANT_TCS });
                }              
            }
            else
                showError("Ошибка получения спецификаций документа");
            UserDialogs.Instance.HideLoading();
        }

        public void showMark()
        {
            if (SelectedSpec != null && SelectedSpec.Rn != null)
                Navigation.PushAsync(new IODocMarkPage(DocRn,SelectedSpec.Rn,SelectedSpec.ModifName));
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

        private IODocSpec _selectedSpec { get; set; }
        public IODocSpec SelectedSpec
        {
            get
            {
                return _selectedSpec;
            }
            set
            {
                if (_selectedSpec != value)
                {
                    if (_selectedSpec != null) _selectedSpec.IsSelected = false;

                    value.IsSelected = true;

                    _selectedSpec = value;
                    OnPropertyChanged("SelectedSpec");
                }
            }
        }

    }
}
