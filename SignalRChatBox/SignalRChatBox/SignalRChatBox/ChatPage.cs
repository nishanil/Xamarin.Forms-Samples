using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Client;
using Xamarin.Forms;

namespace SignalRChatBox
{
    public class ChatPage : ContentPage
    {
        public ObservableCollection<string> Messages { get; set; }
        public string ChatUser { get; set; }

        private HubConnection chatHubConnection;
        private IHubProxy chatHubProxy;

        private Button sendButton;
        public ChatPage()
        {
             
            Title = "Chat";
            sendButton = new Button {
                HorizontalOptions = LayoutOptions.End,
                VerticalOptions = LayoutOptions.Center,
                Text = "Send",
                IsEnabled = false
            };

            var messageEntry = new Entry {
                Placeholder = "enter your Message",
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.FillAndExpand,

            };

            sendButton.Clicked += async (sender, args) => {
                IsBusy = true;

                try
                {
                    await chatHubProxy.Invoke<string>("Send", ChatUser, messageEntry.Text);
                }
                catch (Exception ex)
                {
                                                                  
                   Debug.WriteLine(ex);
                }
              
                IsBusy = false;
            };


            var messageBarLayout = new StackLayout{
                Spacing = 12,
                Orientation = StackOrientation.Horizontal,
                Padding = new Thickness(5, 0, 5, 0),
                Children = {
                    messageEntry,
                    sendButton,
                }
            };

            var messageList = new ListView{
                ItemsSource = Messages = new ObservableCollection<string>(),
            };

            Content = new StackLayout {
                Padding = new Thickness(5, 5, 5, 5),
                Children = {messageBarLayout, messageList}
            };

        }

        protected override async void OnAppearing()
        {
            IsBusy = true;
            chatHubConnection = new HubConnection("http://nishsignalrchat.azurewebsites.net/");
            chatHubProxy = chatHubConnection.CreateHubProxy("ChatHub");
            chatHubProxy.On<string, string>("broadcastMessage", (n, m) => {
                Messages.Add(string.Format("{0} says: {1}", n, m));
            });
            await chatHubConnection.Start();
            IsBusy = false;
            sendButton.IsEnabled = true;
        }
    }
}
