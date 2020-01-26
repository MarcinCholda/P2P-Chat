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
using System.Windows.Shapes;

namespace WPF_Project_WSEI
{
    /// <summary>
    /// Interaction logic for EoTM_Certificate.xaml
    /// </summary>
    public partial class ClientBill
    {
        public ClientBill()
        {
            InitializeComponent();
        }
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
            else if (btnSender.Name == "TurnOffButton")
                this.Close();
        }
        protected void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
        #region Validation of records
        /// <summary>
        /// This part is responsible for checking if the records are not empty
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ValidateTB(object sender,EventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox.Text == "")
                Submit.IsEnabled = false;
            else
                Submit.IsEnabled = true;
            
        }
        private void ClientData_TextChanged(object sender, TextChangedEventArgs e)
        {
            ValidateTB(TXDate, EventArgs.Empty);
            ValidateTB(TXClientID, EventArgs.Empty);
            ValidateTB(TXFullLegalName, EventArgs.Empty);
            ValidateTB(TXStreetName, EventArgs.Empty);
            ValidateTB(TXZipCode, EventArgs.Empty);
            ValidateTB(TXCity, EventArgs.Empty);
            ValidateTB(TXCountry, EventArgs.Empty);
            ValidateTB(TXService, EventArgs.Empty);
            ValidateTB(TXPrice, EventArgs.Empty);
            ValidateTB(TXCurency, EventArgs.Empty);
        }
        #endregion
        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            string[] str = new string[10];

            try
            {
                str[0] = TXDate.Text;
                str[1] = TXClientID.Text;
                str[2] = TXFullLegalName.Text;
                str[3] = TXStreetName.Text;
                str[4] = TXZipCode.Text;
                str[5] = TXCity.Text;
                str[6] = TXCountry.Text;
                str[7] = TXService.Text;
                str[8] = TXPrice.Text;
                str[9] = TXCurency.Text;
            }
            catch
            {
                MessageBox.Show("Error");
                this.Close();
            }

            TBDate.Text = str[0];
            TBClientID.Text = str[1];
            TBClientName.Text = str[2];
            TBStreetname.Text = str[3];
            TBZipCode.Text = str[4];
            TBCity.Text = str[5];
            TBCountry.Text = str[6];
            TBDescription.Content = str[7];
            TBPrice.Text = str[8];
            TBCurrency.Text = str[9];


        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.IsEnabled = false;
                PrintDialog printDialog = new PrintDialog();
                if (printDialog.ShowDialog() == true)
                {
                    printDialog.PrintVisual(print, "invoice");
                }
            }
            finally
            {
                this.IsEnabled = true;
            }
        }






    }
}
