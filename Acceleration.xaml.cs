using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for Acceleration.xaml
    /// </summary>
    public partial class Acceleration : Window
    {
        public Acceleration()
        {
            this.DataContext = new AccelerationViewModel();
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
    }
    public class AccelerationViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        public AccelerationViewModel()
        {
            Angle = -85;
            Value = 0;
        }

        int _angle;
        public int Angle
        {
            get
            {
                return _angle;
            }

            private set
            {
                _angle = value;
                NotifyPropertyChanged("Angle");
            }
        }

        int _value;
        public int Value
        {
            get
            {
                return _value;
            }

            set
            {
                if (value >= 0 && value <= 170)
                {
                    _value = value;
                    Angle = value - 85;
                    NotifyPropertyChanged("Value");
                }
            }
        }
    }
}
