/*using System;
namespace P2P_Chat
{
 

    ///  logika do podpięcia pod xml- opiszę Ci dokładnie co do czego
   
    public partial class MainWindow //: Window - po zrobieniu okienek podepnę logikę
    {

        private P2P_Chat.ChatProxy _cp { get; set; }

        public MainWindow()
        {
           // InitializeComponent(); patrz wyżej
        }

        public void ShowMessage(Message m)
        {
            chatArea.Dispatcher.Invoke(
                DispatcherPriority.Normal,
                    new Action(
                        delegate ()
                        {
                            chatArea.Text += ("[" + m.Sent + "] " + m.Username + ": " + m.Text);
                            chatArea.Text += Environment.NewLine;
                            chatArea.ScrollToEnd();
                        }
                ));
        }

        public void ShowStatus(string txt)
        {
            chatArea.Dispatcher.Invoke(
                DispatcherPriority.Normal,
                    new Action(
                        delegate ()
                        {
                            MessageBox.Show(txt);
                        }
                ));
        }

        private void userInputText_KeyDown(object sender, KeyEventArgs e)  wysyłanie wiadomości pod enter -- to pod guzik send
        {
            if (e.Key == Key.Enter)
            {
                if (_cp != null)
                {
                    if (!string.IsNullOrEmpty(userName.Text) && !string.IsNullOrEmpty(inputText.Text))
                        sendMessage(new Message(userName.Text, inputText.Text));
                    else
                        ShowStatus("Nothing to send!");
                }
                else
                {
                    ShowStatus("Chat not started!");
                }
            }
        }

        private void click_sendMessage(object sender, RoutedEventArgs e) /// wysyłanie wiadomości pod klick
        {
            if (_cp != null)
            {
                if (!string.IsNullOrEmpty(userName.Text) && !string.IsNullOrEmpty(inputText.Text))
                    sendMessage(new Message(userName.Text, inputText.Text));
                else
                    ShowStatus("Nic nie wysłano!");
            }
            else
            {
                ShowStatus("Chat nie rozpoczęty!");
            }
        }

        private void sendMessage(Message m)
        {
            _cp.SendMessage(m);
            inputText.Clear();
        }

        private void startChat(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBoxMyPort.Text) && !string.IsNullOrWhiteSpace(textBoxPartnerAddress.Text))
            {
                _cp = new P2P_Chat.ChatProxy(this.ShowMessage, this.ShowStatus, textBoxMyPort.Text, textBoxPartnerAddress.Text);
                if (_cp.Status)
                {
                    chatArea.Text += ("Gotowy do rozmowu !");
                    chatArea.Text += Environment.NewLine;
                }
            }
            else
            {
                ShowStatus("Wypełnij wszystie pola !");
            }
        }
    }
}
//**