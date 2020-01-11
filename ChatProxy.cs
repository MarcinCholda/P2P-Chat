using System;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.SelfHost;

namespace P2P_Chat
{

    public class ChatProxy
        {
            public bool Status { get; set; }

            public delegate void ShowReceivedMessage(Message m);
            public delegate void ShowStatus(string txt);

            private ShowReceivedMessage _srm;
            private ShowStatus _sst;
            private HttpClient _client;
            private HttpSelfHostServer _server; // pod asp.net domyślny self host

            //konstruktor
            public ChatProxy(ShowReceivedMessage srm, ShowStatus sst, string myport, string partneraddress)
            {
                StartChatServer(myport);
                if (Status)
                {
                    _srm = srm;
                    _sst = sst;
                    _client = new HttpClient() { BaseAddress = new Uri(partneraddress) };

                    ChatController.ThrowMessageArrivedEvent += (sender, args) => { ShowMessage(args.Message); };
                }
            }

            //private methods
            private void StartChatServer(string myport)
            {
                try
                {
                    string url = "http://localhost:" + myport + "/";
                    HttpSelfHostConfiguration config = new HttpSelfHostConfiguration(url);

                    config.Routes.MapHttpRoute(
                        name: "DefaultApi",
                        routeTemplate: "api/{controller}/{id}",
                        defaults: new { id = RouteParameter.Optional }
                    );

                    _server = new HttpSelfHostServer(config);
                    _server.OpenAsync().Wait();

                    Status = true;
                }
                catch (Exception e)
                {
                    Status = false;
                    ShowError("Kurwaaa!");
                }
            }

            private void stopChatServer()
            {
                _server.CloseAsync().Wait();
            }

            private void ShowMessage(Message m)
            {
                _srm(m); // odwołanie do chat proxy
            }

            private void ShowError(string txt)
            {
                _sst(txt);
            }

            //public methods
            public async void SendMessage(Message m)
            {
                try
                {
                    HttpResponseMessage response = await _client.PostAsync("api/chat", m.serializedMessage);
                    if (response.StatusCode != System.Net.HttpStatusCode.OK)
                        ShowError("Rozmówca odpowiedział");
                    ShowMessage(m);
                }
                catch (Exception e)
                {
                    stopChatServer();
                    ShowError("Rozmówca niedostępny, zamykanie aplikacji!");
                }
            }

        }
    }
