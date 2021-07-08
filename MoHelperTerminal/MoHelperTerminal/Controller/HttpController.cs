using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Xamarin.Forms;

namespace MoHelperTerminal.Controller
{
    public class HttpController
    {
        public static string httpMainUrl = "http://markscan.sibatom.com/";
        public static async void SendPostDocSpec(string t_name, string barcode, string doc_rn, string box_rn, string oper_sign, string quant, string channel_name)
        {
            try
            {

                HttpClient http = new HttpClient();
                http.Timeout = TimeSpan.FromMinutes(5);

                http.BaseAddress = new Uri(httpMainUrl);
                http.DefaultRequestHeaders.Accept.Clear();

                var values = new Dictionary<string, string>();

                values.Add("type", "io_doc");
                values.Add("t_name", t_name);
                values.Add("bar", barcode);
                values.Add("in_doc_rn", doc_rn);
                values.Add("in_box_rn", box_rn);
                values.Add("in_oper_sign", oper_sign);
                values.Add("in_quant", quant);

                var response = await http.PostAsync(http.BaseAddress, new FormUrlEncodedContent(values));
                response.EnsureSuccessStatusCode();

                string content = await response.Content.ReadAsStringAsync();
                MessagingCenter.Send<string, string>("HttpControler", channel_name, content);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("address associated with hostname"))
                    MessagingCenter.Send<string, string>("HttpControler", "Error", "Нет подключения к интернету");
                else
                    MessagingCenter.Send<string, string>("HttpControler", "Error", ex.Message);
            }

        }

        public static async void SendGetIODocHead(string doc_rn)
        {
            try
            {
                HttpClient http = new HttpClient();
                http.Timeout = TimeSpan.FromMinutes(5);

                string param = "?type=io_doc_head&doc_rn=" + doc_rn;

                http.BaseAddress = new Uri(httpMainUrl + param);
                http.DefaultRequestHeaders.Accept.Clear();

                var response = await http.GetAsync(http.BaseAddress);

                response.EnsureSuccessStatusCode();

                string content = await response.Content.ReadAsStringAsync();

                MessagingCenter.Send<string, string>("HttpControler", "GetIODocHead", content);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("address associated with hostname"))
                    MessagingCenter.Send<string, string>("HttpControler", "Error", "Нет подключения к интернету");
                else
                    MessagingCenter.Send<string, string>("HttpControler", "Error", ex.Message);
            }
        }

        public static async void SendGetIODocSpec(string doc_rn)
        {
            try
            {
                HttpClient http = new HttpClient();
                http.Timeout = TimeSpan.FromMinutes(5);

                string param = "?type=io_doc_spec&doc_rn=" + doc_rn;

                http.BaseAddress = new Uri(httpMainUrl + param);
                http.DefaultRequestHeaders.Accept.Clear();

                var response = await http.GetAsync(http.BaseAddress);

                response.EnsureSuccessStatusCode();

                string content = await response.Content.ReadAsStringAsync();

                MessagingCenter.Send<string, string>("HttpControler", "GetIODocSpec", content);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("address associated with hostname"))
                    MessagingCenter.Send<string, string>("HttpControler", "Error", "Нет подключения к интернету");
                else
                    MessagingCenter.Send<string, string>("HttpControler", "Error", ex.Message);
            }
        }

        public static async void SendGetIODocBox(string doc_rn)
        {
            try
            {
                HttpClient http = new HttpClient();
                http.Timeout = TimeSpan.FromMinutes(5);

                string param = "?type=io_doc_box&doc_rn=" + doc_rn + "&";

                http.BaseAddress = new Uri(httpMainUrl + param);
                http.DefaultRequestHeaders.Accept.Clear();

                var response = await http.GetAsync(http.BaseAddress);

                response.EnsureSuccessStatusCode();

                string content = await response.Content.ReadAsStringAsync();

                MessagingCenter.Send<string, string>("HttpControler", "GetIODocBox", content);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("address associated with hostname"))
                    MessagingCenter.Send<string, string>("HttpControler", "Error", "Нет подключения к интернету");
                else
                    MessagingCenter.Send<string, string>("HttpControler", "Error", ex.Message);
            }
        }

        public static async void SendGetIODocMark(string doc_rn,string box_rn)
        {
            try
            {
                HttpClient http = new HttpClient();
                http.Timeout = TimeSpan.FromMinutes(5);

                string param = "?type=io_doc_mark&doc_rn=" + doc_rn + "&box_rn=" + box_rn;

                http.BaseAddress = new Uri(httpMainUrl + param);
                http.DefaultRequestHeaders.Accept.Clear();

                var response = await http.GetAsync(http.BaseAddress);

                response.EnsureSuccessStatusCode();

                string content = await response.Content.ReadAsStringAsync();

                MessagingCenter.Send<string, string>("HttpControler", "GetIODocMark", content);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("address associated with hostname"))
                    MessagingCenter.Send<string, string>("HttpControler", "Error", "Нет подключения к интернету");
                else
                    MessagingCenter.Send<string, string>("HttpControler", "Error", ex.Message);
            }
        }
    }
}
