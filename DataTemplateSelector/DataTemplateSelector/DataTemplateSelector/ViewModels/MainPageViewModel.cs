using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace DataTemplateSelector
{
    public class MainPageViewModel : BaseViewModel
    {

        private List<MessageViewModel> messagesList;

        public List<MessageViewModel> Messages
        {
            get { return messagesList; }
            set { messagesList = value; RaisePropertyChanged(); }
        }

        private string outgoingText;

        public string OutGoingText
        {
            get { return outgoingText; }
            set { outgoingText = value; RaisePropertyChanged(); }
        }

        public ICommand SendCommand { get; set; }


        public MainPageViewModel()
        {
              // Initialize with default values

            Messages = new List<MessageViewModel>
            {
                new MessageViewModel { Text = "Hi Squirrel! \uD83D\uDE0A", IsIncoming = true, MessagDateTime = DateTime.Now.AddMinutes(-25)},
                new MessageViewModel { Text = "Hi Baboon, How are you? \uD83D\uDE0A", IsIncoming = false, MessagDateTime = DateTime.Now.AddMinutes(-24)},
                new MessageViewModel { Text = "We've a party at Mandrill's. Would you like to join? We would love to have you there! \uD83D\uDE01", IsIncoming = true, MessagDateTime = DateTime.Now.AddMinutes(-23)},
                new MessageViewModel { Text = "You will love it. Don't miss.", IsIncoming = true, MessagDateTime = DateTime.Now.AddMinutes(-23)},
                new MessageViewModel { Text = "Sounds like a plan. \uD83D\uDE0E", IsIncoming = false, MessagDateTime = DateTime.Now.AddMinutes(-23)},

                new MessageViewModel { Text = "\uD83D\uDE48 \uD83D\uDE49 \uD83D\uDE49", IsIncoming = false, MessagDateTime = DateTime.Now.AddMinutes(-23)},


            };
            OutGoingText = null;
            SendCommand = new Command(() =>
            {
              Messages.Add(new MessageViewModel {Text =  OutGoingText, IsIncoming = false, MessagDateTime = DateTime.Now});
                OutGoingText = null;
            });
        }
       // public List<MessageViewModel> Messages { get; set; } = new List<MessageViewModel>();

    }

    
}
