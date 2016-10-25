using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using Newtonsoft.Json;

namespace Cezium.SmartHome.Api.Models.OpenHab
{
    public class OpenHabService
    {
        private readonly string _serviceUrl = Config.OpenHabServerUrl;

        public OpenHabService(string serviceUrl)
        {
            _serviceUrl = serviceUrl;
        }

        private string ReadItem(string name)
        {
            string service_response = "";
            string url = _serviceUrl + "/rest/items/" + name;

            HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(url);
            myRequest.Timeout = 100 * 60 * 60;
            myRequest.UserAgent = "Mozilla/5.0 (Windows; U; Windows NT 6.1; en-US) AppleWebKit/533.4 (KHTML, like Gecko) Chrome/5.0.375.126 Safari/533.4";
            CookieContainer cCookie = new CookieContainer();
            myRequest.CookieContainer = cCookie;
            myRequest.ContentType = "application/json";
            myRequest.Accept = "application/json";
            myRequest.Method = "GET";

            using (var resp = myRequest.GetResponse())
            {
                using (var responseStream = resp.GetResponseStream())
                {
                    using (var responseReader = new StreamReader(responseStream))
                    {
                        service_response = responseReader.ReadToEnd();
                    }
                }
            }
            
            return service_response;
        }


        private string PostItemState(string name, string state)
        {
            string service_response = "";
            string url = _serviceUrl + "/rest/items/" + name;

            if (!String.IsNullOrEmpty(url))
            {
                HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(url);
                myRequest.Timeout = 100 * 60 * 60;
                myRequest.UserAgent = "Mozilla/5.0 (Windows; U; Windows NT 6.1; en-US) AppleWebKit/533.4 (KHTML, like Gecko) Chrome/5.0.375.126 Safari/533.4";
                CookieContainer cCookie = new CookieContainer();
                myRequest.CookieContainer = cCookie;
                myRequest.ContentType = "text/plain";
                myRequest.Accept = "text/plain";
                myRequest.Method = "POST";

                byte[] buf = Encoding.ASCII.GetBytes(state);
                myRequest.ContentLength = buf.Length;
                myRequest.GetRequestStream().Write(buf, 0, buf.Length);


                using (HttpWebResponse resp = (HttpWebResponse)myRequest.GetResponse())
                {
                    if (resp.StatusCode == HttpStatusCode.Created)
                        return state;
                    else
                        throw new HttpException("OpenaHAB REST API returned status: " + ((int)resp.StatusCode).ToString());
                }
            }

            return service_response;
        }


        private string PutItemState(string name, string state)
        {
            string service_response = "";
            string url = _serviceUrl + "/rest/items/" + name + "/state";

            if (!String.IsNullOrEmpty(url))
            {
                HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(url);
                myRequest.Timeout = 100 * 60 * 60;
                myRequest.UserAgent = "Mozilla/5.0 (Windows; U; Windows NT 6.1; en-US) AppleWebKit/533.4 (KHTML, like Gecko) Chrome/5.0.375.126 Safari/533.4";
                CookieContainer cCookie = new CookieContainer();
                myRequest.CookieContainer = cCookie;
                myRequest.ContentType = "text/plain";
                myRequest.Accept = "text/plain";
                myRequest.Method = "PUT";

                byte[] buf = Encoding.ASCII.GetBytes(state);
                myRequest.ContentLength = buf.Length;
                myRequest.GetRequestStream().Write(buf, 0, buf.Length);


                using (HttpWebResponse resp = (HttpWebResponse)myRequest.GetResponse())
                {
                    if (resp.StatusCode == HttpStatusCode.OK)
                        return state;
                    else
                        throw new HttpException("OpenaHAB REST API returned status: " + ((int)resp.StatusCode).ToString());
                }
            }

            return service_response;
        }

        public string GetAllItem()
        {
            return ReadItem("");
        }


        public string GetItem(string item)
        {
            return ReadItem(item);
        }

        public string Switch(string item)
        {
            dynamic itemObj = (dynamic)JsonConvert.DeserializeObject(GetItem(item));
            string currentState = itemObj.state;

            string newState = currentState == "ON" ? "OFF" : "ON";

            try
            {
                PostItemState(item, newState);
            }
            catch (Exception ex)
            {
                newState = currentState;
            }

            return newState;
        }

        public string ChangeState(string item, string command)
        {
            return PutItemState(item, command);
        }
    }
}