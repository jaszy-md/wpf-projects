using Microsoft.Win32;
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
using System.Windows.Threading;

namespace Wpf_prg2_timers
{
    /// <summary>
    /// Interaction logic for Countdown.xaml
    /// </summary>
    public partial class Countdown : Window
    {
        DispatcherTimer tmCountdown = new DispatcherTimer();
        private int seconds;

        public Countdown()
        {
            InitializeComponent();
            tmCountdown.Interval = new TimeSpan(0,0,0,1);
            tmCountdown.Tick += tmCountdown_Tick;
            tmCountdown.Start();


        }

        private void tmCountdown_Tick(object sender, EventArgs e)
        {
            seconds = int.Parse(txtNumber.Text);
            seconds--;
            txtNumber.Text = seconds.ToString();

            if (seconds == 0)
            {
                tmCountdown.Stop();
                string sMessageBoxText = "uhhhh, for your name?";
                string sCaption = "Think really harder now...";
                MessageBoxButton btnMsgBox = MessageBoxButton.OK;
                MessageBoxImage iconMsBox = MessageBoxImage.Question;

                MessageBoxResult resultMsBox = MessageBox.Show(sMessageBoxText, sCaption, btnMsgBox, iconMsBox);
                {
                    txtNumber.Text = "10";
                    tmCountdown.Start();
                }

            }
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            tmCountdown.Stop();
            string sMyName = txtName.Text;
            WordRocket win = new WordRocket(sMyName);
            win.Show();
            this.Close();
            
        }
    }
}
