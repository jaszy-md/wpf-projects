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

namespace WpfAppEindprojectOp12021
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {  
        int _count = 0;

        private int _countr = 0;
        private DispatcherTimer _timer;
        private int _Millieseconds = 50;
        private bool _started = false;
        private int _clicks = 0;
        public MainWindow()
        {
            InitializeComponent();
            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromMilliseconds(100);
            _timer.Tick += _timer_Tick;

        }
        
        private void btOne_Click(object sender, RoutedEventArgs e)
        {
            if ((string)btOne.Content == "Button1")

            {
                btOne.Content = "Button one pressed";
                btOne.Background = Brushes.LightGray;
            }
            else
            {
                btOne.Content = "Button1";
                btOne.Background = Brushes.DarkGray;
            }
            DoMyThing();
        }


        private void btTwo_Click(object sender, RoutedEventArgs e)
        {
            if ((string)btTwo.Content == "Button2")
            {
                btTwo.Content = "Button two pressed";
                btTwo.Background = Brushes.LightGray;
            }
            else
            {
                btTwo.Content = "Button2";
                btTwo.Background = Brushes.DarkGray;
            }
            DoMyThing();
        }

        private void btThree_Click(object sender, RoutedEventArgs e)
        {
            if ((string)btThree.Content == "Button3")
            {
                btThree.Content = "Button three pressed";
                btThree.Background = Brushes.LightGray;
            }
            else
            {
                btThree.Content = "Button3";
                btThree.Background = Brushes.DarkGray;
            }
            DoMyThing();
        }
        private void btFour_Click(object sender, RoutedEventArgs e)
        {
            if ((string)btFour.Content == "Button4")
            {
                btFour.Content = "Button four pressed";
                btFour.Background = Brushes.LightGray;
            }
            else
            {
                btFour.Content = "Button4";
                btFour.Background = Brushes.DarkGray;
            }
            DoMyThing();
        }
        private void DoMyThing()
        {
            if (btOne.Content == "Button one pressed" && btTwo.Content == "Button two pressed" && btThree.Content == "Button three pressed" && btFour.Content == "Button four pressed")
            {
                gridColor.Background = Brushes.Black;
            }

            else if (btOne.Content == "Button one pressed" && btTwo.Content != "Button two pressed" && btThree.Content != "Button three pressed" && btFour.Content != "Button four pressed")
            {
                gridColor.Background = Brushes.Red;
            }

            else if (btOne.Content == "Button one pressed" && btTwo.Content == "Button two pressed" && btThree.Content == "Button three pressed" && btFour.Content != "Button four pressed")
            {
                gridColor.Background = Brushes.Green;
            }

            else if (btOne.Content == "Button one pressed" && btTwo.Content == "Button two pressed" && btThree.Content != "Button three pressed" && btFour.Content != "Button four pressed")
            {
                gridColor.Background = Brushes.Yellow;

            }
            else if (btOne.Content != "Button one pressed" && btTwo.Content != "Button two pressed" && btThree.Content == "Button three pressed" && btFour.Content == "Button four pressed")
            {
                gridColor.Background = Brushes.Blue;
            }

            else
            {
                gridColor.Background = Brushes.Purple;
            }
        }

        private void BtVak1_Click(object sender, RoutedEventArgs e)
        {
            int counter = int.Parse(tbCounter.Text);

            if (counter < 4)
            {
                ///MessageBox.Show("het getal is " + counter);
                counter++;
                tbCounter.Text = counter.ToString();

            }
            else
            {
                tbCounter.Text = "0";


            }

        }

        private void btGo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int getal = int.Parse(tbGetal.Text);
                int macht = int.Parse(tbPower.Text);

                string resultaat = "";

                for (int i = 1; i <= macht; i++)
                {
                    resultaat += " " + Math.Pow(getal, i) + ",";
                }

                tbReeks.Text = resultaat;
            }
            catch (Exception)
            {

                throw;
            }



        }

        private void btAnimals_Click(object sender, RoutedEventArgs e)
        {
            ComboBox myComboBox = cmbAnimals;
            bool isFound = false;                    //
            int numberOfAnimalsFound = 0; // numberofanimalsfound in uitleg foundindex - je wil het gevonden steeds optellen
            String text = tbAnimal.Text.ToLower();


            for (int i = 0; i < myComboBox.Items.Count; i++)
            {
                ComboBoxItem item = (ComboBoxItem)myComboBox.Items[i];
                String value = item.Content.ToString().ToLower(); // Dit zorgt ervoor dat het niet uitmaakt of het een hoofdletter is of niet

                if (value == text)
                {
                    isFound = true;
                    numberOfAnimalsFound = i;
                }

            }
            if (isFound)
            {
                //Typ wat je wil in de messagebox, als er een dier is gevonden in de combobox
                MessageBox.Show("Het te zoeken dier is gevonden" + numberOfAnimalsFound.ToString());

            }
            else
            {
                //Typ wat je wil in de messagebox, als er geen dier is gevonden in de combobox
                MessageBoxResult result = MessageBox.Show("Helaas, het dier is niet gevonden", "Wil je deze toevoegen?", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    myComboBox.Items.Add(text);
                }
                else
                {
                    // niks unvullen want het antwoord is dan gewoon nee
                }
            }

        }

        private void cmbGridColor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem comboxItemColor = (ComboBoxItem)cmbGridColor.SelectedItem;
            string comboBoxColor = comboxItemColor.Content.ToString();
            switch (comboBoxColor)

            {

                case "Pink":
                    cmbGridColor.Foreground = Brushes.Pink;

                    break;
                case "Blue":
                    cmbGridColor.Foreground = Brushes.Blue;
                    MessageBox.Show("Dit is ook mijn lieveingskleur!");

                    break;
                case "Purple":
                    cmbGridColor.Foreground = Brushes.Purple;

                    break;
                case "Red":
                    cmbGridColor.Foreground = Brushes.Red;

                    break;
                default:
                    MessageBox.Show("Error, probeer opnieuw");
                    break;
            }
        }

        private void tbBlue_Click(object sender, RoutedEventArgs e)
        {
            string _getal = tbWhile.Text;
            int _Number = 0;

            try
            {
                _Number = int.Parse(_getal);
            }
            catch (Exception)
            {
                MessageBox.Show(" Type hier a number ");
                return;
                //throw;
            }

            while (_Number > 0)
            {
                MessageBox.Show("nummer:" + _Number);
                _Number = _Number - 1;
            }
        }

        private void btcounterR_Click(object sender, RoutedEventArgs e)
        {
            {
                if (_count < 5)
                {
                    MessageBox.Show("Not ready Yet, integer counter has now the value " + _count);
                    _count++;
                }
                else
                {
                    MessageBox.Show("donee! ;-)");
                    _count = _count = 0;
                }



            }


        }

        private void btClickIt_Click(object sender, RoutedEventArgs e)
        {
            if (!_started)
            {
                _timer.Start();
            }
            _clicks++;
            tbClicks.Text = _clicks.ToString();
        }
        private void _timer_Tick(object sender, EventArgs e)
        {
            if (_Millieseconds > 0)
            {
                _Millieseconds--;
                tbCountr.Text = _Millieseconds.ToString();
            }
            else
            {
                MessageBox.Show("The time is over, your number of clicks is " + _clicks);
                _timer.Stop();
                _clicks = 0;
                _started = false;
                _Millieseconds = 50;
            }

        }
    }
}



