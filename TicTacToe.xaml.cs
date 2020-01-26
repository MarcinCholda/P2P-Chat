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
    /// Interaction logic for TicTacToe.xaml
    /// </summary>
    /// 


    public enum TicTacToeMarks
    {
        // Unclicked Button
        Empty,
        // Button clicked by Player1
        Cross,
        // Button clicked by Player2
        Nought
    }
    public partial class TicTacToe : Window
    {
        #region TicTacToe Members

        private TicTacToeMarks[] results;

        private bool player1Turn;

        private bool gameEnded;

        private int player1Score = 0;

        private int player2Score = 0;
        #endregion
        public TicTacToe()
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
        private void PlayButton_Click(object sender, RoutedEventArgs e)
        {

            // Starting new game, making sure that every cell is empty, the Player1 starts the game and setting gameEnded to false
            results = new TicTacToeMarks[9];

            for (var i = 0; i < results.Length; i++)
                results[i] = TicTacToeMarks.Empty;

            player1Turn = true;


            TicTacToeBox.Children.Cast<Button>().ToList().ForEach(button =>
            {
                button.Content = string.Empty;
                button.Background = Brushes.White;
                button.Foreground = Brushes.Black;
            });

            Player1Score.Text = Convert.ToString(player1Score);
            Player2Score.Text = Convert.ToString(player2Score);
            gameEnded = false;
        }
        private void TTTBoxButton_Click(object sender, RoutedEventArgs e)
        {
            //Start a new game on the click after it finished
            if (gameEnded)
            {
                //PlayButton_Click();
                Curtain.Visibility = Visibility.Visible;
                return;
            }
            // cast the sender to a button
            var button = (Button)sender;
            var column = Grid.GetColumn(button);
            var row = Grid.GetRow(button);
            var index = column + (row * 3);

            //Ignoring click event if the cell is already taken
            if (results[index] != TicTacToeMarks.Empty)
                return;

            //Setting cell value
            results[index] = player1Turn ? TicTacToeMarks.Cross : TicTacToeMarks.Nought;

            button.Content = player1Turn ? "X" : "O";

            button.Background = Brushes.DarkGray;

            // Changing players turns - if player1 is true it change to false and vice versa
            player1Turn ^= true;

            CheckForWinner();
        }
        private void CheckForWinner()
        {
            if (results[0] != TicTacToeMarks.Empty && (results[0] & results[1] & results[2]) == results[0])
            {
                if (results[0] == TicTacToeMarks.Cross)
                    player1Score += 1;
                else
                    player2Score += 1;

                Player1Score.Text = Convert.ToString(player1Score);
                Player2Score.Text = Convert.ToString(player2Score);
                gameEnded = true;
            }
            else if (results[3] != TicTacToeMarks.Empty && (results[3] & results[4] & results[5]) == results[3])
            {
                if (results[3] == TicTacToeMarks.Cross)
                    player1Score += 1;
                else
                    player2Score += 1;

                Player1Score.Text = Convert.ToString(player1Score);
                Player2Score.Text = Convert.ToString(player2Score);
                gameEnded = true;
            }
            if (results[6] != TicTacToeMarks.Empty && (results[6] & results[7] & results[8]) == results[6])
            {
                if (results[6] == TicTacToeMarks.Cross)
                    player1Score += 1;
                else
                    player2Score += 1;

                Player1Score.Text = Convert.ToString(player1Score);
                Player2Score.Text = Convert.ToString(player2Score);
                gameEnded = true;
            }
            if (results[0] != TicTacToeMarks.Empty && (results[0] & results[3] & results[6]) == results[0])
            {
                if (results[0] == TicTacToeMarks.Cross)
                    player1Score += 1;
                else
                    player2Score += 1;

                Player1Score.Text = Convert.ToString(player1Score);
                Player2Score.Text = Convert.ToString(player2Score);
                gameEnded = true;
            }
            if (results[1] != TicTacToeMarks.Empty && (results[1] & results[4] & results[7]) == results[1])
            {
                if (results[1] == TicTacToeMarks.Cross)
                    player1Score += 1;
                else
                    player2Score += 1;

                Player1Score.Text = Convert.ToString(player1Score);
                Player2Score.Text = Convert.ToString(player2Score);
                gameEnded = true;
            }
            if (results[2] != TicTacToeMarks.Empty && (results[2] & results[5] & results[8]) == results[2])
            {
                if (results[2] == TicTacToeMarks.Cross)
                    player1Score += 1;
                else
                    player2Score += 1;

                Player1Score.Text = Convert.ToString(player1Score);
                Player2Score.Text = Convert.ToString(player2Score);
                gameEnded = true;
            }
            if (results[0] != TicTacToeMarks.Empty && (results[0] & results[4] & results[8]) == results[0])
            {
                if (results[0] == TicTacToeMarks.Cross)
                    player1Score += 1;
                else
                    player2Score += 1;

                Player1Score.Text = Convert.ToString(player1Score);
                Player2Score.Text = Convert.ToString(player2Score);
                gameEnded = true;
            }
            if (results[2] != TicTacToeMarks.Empty && (results[2] & results[4] & results[6]) == results[2])
            {
                if (results[2] == TicTacToeMarks.Cross)
                    player1Score += 1;
                else
                    player2Score += 1;

                Player1Score.Text = Convert.ToString(player1Score);
                Player2Score.Text = Convert.ToString(player2Score);
                gameEnded = true;
            }
            else if (!results.Any(e => e == TicTacToeMarks.Empty))
            {
                Player1Score.Text = Convert.ToString(player1Score);
                Player2Score.Text = Convert.ToString(player2Score);
                gameEnded = true;
            }
        }
    }
}
