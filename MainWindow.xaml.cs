using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace WPF_Project_WSEI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private WPF_Project_WSEI.ChatProxy _cp { get; set; }
        public MainWindow()
        {
            InitializeComponent();
        }
        #region TopRightCornerButtons
        /// <summary>
        /// This Part is responsible for handling events for Maximize, Minimize and TurnOff Buttons
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Window3Button_Click(object sender, RoutedEventArgs e)
        {
            Button btnSender = (Button)sender;
            if (btnSender.Name == "MaximizeButton")
            {
                if (this.WindowState == WindowState.Normal)
                    this.WindowState = WindowState.Maximized;
                else
                    this.WindowState = WindowState.Normal;
            }
            else if (btnSender.Name == "MinimizeButton")
                this.WindowState = WindowState.Minimized;
            else if(btnSender.Name == "TurnOffButton")
                this.Close();
        }
        #endregion

        protected void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }


        private void Templates_Click(object sender, RoutedEventArgs e)
        {
            Button btnSender = (Button)sender;
            switch(btnSender.Name)
            {
                case "ClientBill":
                    ClientBill templateWindowOne = new ClientBill();
                    templateWindowOne.Show();
                    break;
                case "Acceleration":
                    Acceleration accelerationWindow = new Acceleration();
                    accelerationWindow.Show();
                    break;
                case "TicTacToe":
                    TicTacToe tictactoeWindow = new TicTacToe();
                    tictactoeWindow.Show();
                    break;
                default:
                    break;
            }
        }

        #region Chat
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

        private void userInputText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (_cp != null)
                {
                    if (!string.IsNullOrEmpty(userName.Text) && !string.IsNullOrEmpty(inputText.Text))
                        sendMessage(new Message(userName.Text, inputText.Text));
                    else
                        ShowStatus("Nic do wysłania!");
                }
                else
                {
                    ShowStatus("Chat nie rozpoczęty!");
                }
            }
        }

        private void click_sendMessage(object sender, RoutedEventArgs e)
        {
            if (_cp != null)
            {
                if (!string.IsNullOrEmpty(userName.Text) && !string.IsNullOrEmpty(inputText.Text))
                    sendMessage(new Message(userName.Text, inputText.Text));
                else
                    ShowStatus("Nic do wysłania!");
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
                _cp = new WPF_Project_WSEI.ChatProxy(this.ShowMessage, this.ShowStatus, textBoxMyPort.Text, textBoxPartnerAddress.Text);
                if (_cp.Status)
                {
                    chatArea.Text += ("Gotowy!");
                    chatArea.Text += Environment.NewLine;
                }
            }
            else
            {
                ShowStatus("Wypełnij wszystkie pola!");
            }
        }
        #endregion

        private void Documentation_Click(object sender, RoutedEventArgs e)
        {
            Button butnSender = (Button)sender;
            if (butnSender.Name == "Github")
            {
                System.Diagnostics.Process.Start("https://github.com/MarcinCholda/P2P-Chat");
            }
        }
    }

}
