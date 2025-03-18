using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for WordRocket.xaml
    /// </summary>
    public partial class WordRocket : Window
    {

        //De timer die de linker margin van de raket aanpast
        DispatcherTimer timer = new DispatcherTimer();
        //De lijst waarin de woorden komen te staan
        List<string> lstwords = new List<string>();
        //Een random waarmee we random woorden uit de lijst kunnen kiezen
        Random rRandom = new Random();
        //de eindwaarde van de raket
        double dEndpoint = 0;

        public WordRocket(string sNamePlayer)
        {
            InitializeComponent();
            lblName.Content = sNamePlayer;

            timer.Interval = new TimeSpan(0, 0, 0, 0, 50);
            timer.Tick += Timer_Tick;

            dEndpoint = this.Width - rEndGame.Width - lblWord.Width;



            //bewegen stopt bij breedte scherm - zwarte rectangle - lengte raket           
        }

        private void Timer_Tick(object sender, EventArgs e)
        {

            lblWord.Margin = new Thickness(lblWord.Margin.Left + 10, lblWord.Margin.Top, 0, 0);

            //stop met bewegen al de linkerkant van de raket het eindpunt raakt
            if (lblWord.Margin.Left == dEndpoint)
            {
                timer.Stop();
                MessageBoxResult result = MessageBox.Show("wilt u opnieuw spelen??", "...", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    SetInitialPosition();


                }
                if (result == MessageBoxResult.No)
                {
                    MessageBoxResult m = MessageBox.Show("wilt u een ander spelen??", "...", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (m == MessageBoxResult.No)
                    {
                        Close();
                    }
                }
            }
        }
        private void txtWordToCheck_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (lblWord != null && txtWordToCheck != null)
            {
                if (txtWordToCheck.Text.Length == 0)
                {
                    return;
                }

                else if (lblWord.Content.ToString().ToLower() == txtWordToCheck.Text.ToLower())
                {
                  int punt = int.Parse(lblNrCorrect.Content.ToString());
                    punt++;
                    lblNrCorrect.Content = punt.ToString();
                    
                    NextWord();
                    lblWord.Margin = new Thickness(0, lblWord.Margin.Top, 0, 0);

                }

                
                //Is het label gelijk aan het tekstvak en houdt geen rekening met hoofdletters
                //punt erbij
                //het volgende woord   
            }


        }



        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            btnStart.Visibility = Visibility.Hidden;
            timer.Start();
            newgame();
            NextWord();
        }


        private void newgame()
        {
            lstwords.AddRange(File.ReadAllLines("resources\\woorden.txt"));
        }

        private void NextWord()
        {
            //zijn er nog woorden in de lijst
            if (lstwords.Count > 0)
            {
                //maak het invoerveld leeg
                txtWordToCheck.Text = null;

                //kies een random woord uit de lijst
                int lstword = rRandom.Next(0, lstwords.Count);



                lblWord.Content = lstwords[lstword];
                lstwords.RemoveAt(lstword);
                //Haal het gekozen woord uit de lijst zodat deze niet nogmaals gekozen wordt
                //Zorg ervoor dat het label weer naar de startpositie links verschuift
            }

            else 
            {
                //Alle woorden zijn goed
                
                //Stop de timer
                timer.Stop();
                //Vraag of speler nog een keer wil spelen
                MessageBoxResult result = MessageBox.Show("wilt u opnieuw spelen??", "...", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    SetInitialPosition();


                }
                if (result == MessageBoxResult.No)
                {
                    MessageBoxResult m = MessageBox.Show("wilt u een ander spelen??", "...", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (m == MessageBoxResult.No)
                    {
                        Close();
                    }
                }
            }
        }
        private void SetInitialPosition()
        {
            btnStart.Visibility = Visibility.Visible;
            lblWord.Margin = new Thickness(0, lblWord.Margin.Top, 0, 0);
            lblWord.Content = string.Empty;
            txtWordToCheck.Text = string.Empty;
            lblNrCorrect.Content = "0";
        }
    }
}


