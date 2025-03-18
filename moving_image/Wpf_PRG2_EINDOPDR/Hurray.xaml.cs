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

namespace Wpf_PRG2_EINDOPDR
{
    /// <summary>
    /// Interaction logic for Hurray.xaml
    /// </summary>
    public partial class Hurray : Window
    {


        DispatcherTimer tmCount = new DispatcherTimer();
        public int sec;



        public Hurray(string count)
        {
            InitializeComponent();
            tbWin.Text = count;

            tmCount.Interval = new TimeSpan(0, 0, 0, 1);
            tmCount.Tick += tmCount_Tick;
            tbTime.Focus();
            //timer voor tijd
            tmCount.Start();

            
        }

        private void tmCount_Tick(object sender, EventArgs e)
        {
            
            
            sec = int.Parse(tbTime.Text);
            sec--;
            tbTime.Text = sec.ToString();

            string txt1 = "Je hebt het spel gewonnen in ";
            string txt2 = " seconden!";

            tbWin2.Text = txt1 + tbWin.Text + txt2;

            if(tbTime.Text == "0")
            {
                tmCount.Stop();
                this.Close();
            }
        }

     
    }
}
