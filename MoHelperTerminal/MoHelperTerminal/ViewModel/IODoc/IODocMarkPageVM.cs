using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using Xamarin.Forms;
using Acr.UserDialogs;
using MoHelperTerminal.Controller;
using Plugin.Settings;
using MoHelperTerminal.Model.IODoc;
using System.Collections.ObjectModel;
using static MoHelperTerminal.Controller.HttpJsonItem;
using Newtonsoft.Json;
using System.Linq;

namespace MoHelperTerminal.ViewModel.IODoc
{
    public class IODocMarkPageVM : INotifyPropertyChanged
    {
        //public ObservableCollection<IODocMark> MarkList { get; set; }
        public ObservableCollection<Grouping<string, IODocMark>> MarkList { get; set; }
        public IODocMarkPageVM(string doc_rn,string nommodif,string modif_name)
        {
            MarkList = new ObservableCollection<Grouping<string, IODocMark>>();
            TerminalNumber = CrossSettings.Current.GetValueOrDefault("TerminalNumber", "");
            DocRn = doc_rn;
            NommodifRn = nommodif;
            ModifName = modif_name;
        }

        public void startPage()
        {
            MessagingCenter.Subscribe<string, string>("MainActivity", "GetBarcode", (sender, arg) =>
            {
                work(arg.Trim());
            });
            MessagingCenter.Subscribe<string, string>("HttpControler", "GetIODocMark", (sender, arg) =>
            {
                fillList(arg.Trim());
            });
            MessagingCenter.Subscribe<string, string>("HttpControler", "Error", (sender, arg) =>
            {
                showError(arg.Trim());
            });
            HttpController.SendGetIODocMark(DocRn, NommodifRn);
        }

        public void endPage()
        {
            MessagingCenter.Unsubscribe<string, string>("MainActivity", "GetBarcode");
            MessagingCenter.Unsubscribe<string, string>("HttpControler", "Error");
        }

        public void fillList(string content)
        {
            MarkList.Clear();
            if (content.Length > 2)
            {
                List<GetIODocMarkResponce> resp = JsonConvert.DeserializeObject<List<GetIODocMarkResponce>>(content, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
                List<IODocMark> tmp = new List<IODocMark>();
                foreach (GetIODocMarkResponce cur in resp)
                {
                    tmp.Add(new IODocMark { Rn = cur.RN, Pref = cur.PREF, Numb = cur.NUMB, ModifName = cur.MODIF_NAME, BoxNum = cur.BOX_NUM });
                }
                var groups = tmp.GroupBy(p => p.BoxNum).Select(g => new Grouping<string, IODocMark>(g.Key, g));
                // передаем группы в PhoneGroups
                MarkList = new ObservableCollection<Grouping<string, IODocMark>>(groups);
                OnPropertyChanged("MarkList");
            }
            else
                showError("Ошибка получения марок");
        }

        public void work(string _barcode)
        {
            //UserDialogs.Instance.Loading("Обмен данными");
            //HttpController.SendPostDocSpec(TerminalNumber, _barcode, DocRn, boxRn, "1", quant, "PostIODocSend");
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

        private string _nommodifRn { get; set; }
        public string NommodifRn
        {
            get
            {
                return _nommodifRn;
            }
            set
            {
                if (_nommodifRn != value)
                {
                    _nommodifRn = value;
                    OnPropertyChanged("NommodifRn");
                }
            }
        }

        private string _modifName { get; set; }
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
