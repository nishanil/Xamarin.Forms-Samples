using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Client;
using Xamarin.Forms;

namespace SignalRChatBox
{
    public class HomePage : ContentPage
    {
        public HomePage()
        {
            var goButton = new Button()
            {
                Text = "Go",
            };
            var user = new Entry()
            {

                Placeholder = "enter name",
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.FillAndExpand,
            };

            Title = "Home";
            Content = new StackLayout
            {
                Padding = 20,
                Orientation = StackOrientation.Horizontal,
                VerticalOptions = LayoutOptions.Center,
                Children =
                {
                    user,
                    goButton
                }
            };

            goButton.Clicked += async (sender, args) =>
            {
                var chatPage = new ChatPage {ChatUser = user.Text};

                await Navigation.PushAsync(chatPage);

            };

        }

        

    }
}
