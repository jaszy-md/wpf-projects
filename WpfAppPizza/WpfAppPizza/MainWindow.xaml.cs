using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;


namespace WpfAppPizza
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public double _prijs = 0;
        public double _prijs25cmpizza = 0;
        public double _totaalprijs = 0;
        public double _prijstoevoegen = 0;
        public double _grandTotal = 0;
        public double _totaalOverzicht;
        public double totaal = 0;
        string[] prijzen = new string[] { "10,00", "8,00", "9,00", "10,50", "10,00", "11,00", "11,00", "10,50", "10,00", "12,00", "14,00", "8,00", "9,50", "12,50", "7,00", "11,00" };
        private List<Bonregel> regels = new List<Bonregel>();


        private void cmbPizzaPasta_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            string[] pasta = new string[] { "Macaroni Bolognese", "Farfalle Gorgonzola", "Spaghetti Vongole", "Fusilli Pesto", "Lasagne Classico" };

            int index;
            index = cmbPizzaPasta.SelectedIndex;
            if (index != -1)
            {
                tbPrijs.Text = "€" + prijzen[index];

                string prijsStr = prijzen[index];       // 
                _prijs = Convert.ToDouble(prijsStr); // je veranderd het naar een komma getal met double (dat wat je tussen haakjes zet)

                ComboBoxItem selectedItem = (ComboBoxItem)cmbPizzaPasta.SelectedItem;

                if (pasta.Contains(selectedItem.Content))
                {
                    spFormaat.Visibility = Visibility.Hidden;    // wanneer ik een pasta selecteer wordt formaat onzichtbaar
                    tbFormaat.Visibility = Visibility.Hidden;

                }
                else
                {
                    spFormaat.Visibility = Visibility.Visible;
                    tbFormaat.Visibility = Visibility.Visible;
                }

                tbAantal.IsEnabled = true;
            }
        }

        private void textchanged(object sender, TextChangedEventArgs e)
        {
            try

            {
                int aantal = int.Parse(tbAantal.Text);    //je gaat van een getal naar een tekst 

                // omdat je een komma getal wil

                if (rb35Cm.IsChecked == true)             // wanneer de 35 cm is aangevinkt berekend hij de prijs voor deze pizza
                {
                    totaal = aantal * _prijs;

                }

                else if (rb25Cm.IsChecked == true)
                {
                    totaal = aantal * _prijs25cmpizza;
                }

                else if (rb25Cm.IsChecked == false && rb35Cm.IsChecked == false)
                {
                    totaal = aantal * _prijs;
                }

                tbtoevoegen.Foreground = Brushes.Black;
                tbtoevoegen.Text = totaal.ToString("0.00");              //resultaat weergeven in textbox

            }


            catch (Exception)
            {
                tbtoevoegen.Text = "ERROR!";                        //error weergeven als er geen getal wordt ingevoerd
                tbtoevoegen.Foreground = Brushes.Red;
            }

            return;
        }


        private void rb25checked(object sender, RoutedEventArgs e)
        {

            _prijs25cmpizza = _prijs * 0.7;                                 //70% korting berekenen voor de 25cm pizza
            tbPrijs.Text = _prijs25cmpizza.ToString("0.00");
        }

        private void rb35checked(object sender, RoutedEventArgs e)
        {
            tbPrijs.Text = _prijs.ToString("0.00");
        }

        private void btToevoegen_click(object sender, RoutedEventArgs e)       
        {
            try
            {

                if (cmbPizzaPasta.SelectedIndex > -1 && tbAantal.Text != "" && int.Parse(tbAantal.Text) != 0)
                {
                    string comboText = ((ComboBoxItem)cmbPizzaPasta.SelectedItem).Content.ToString();
                    string totaal2 = comboText + Environment.NewLine + tbAantal.Text + "x" + tbPrijs.Text + "=" + tbtoevoegen.Text;
                    lbLijst.Items.Add(totaal2);


                    Bonregel regel = new Bonregel();   // door regels te maken in een class kan ik de item verwijderen en daardoor de berekening juist maken
                    regel.naam = comboText;
                    regel.aantal = int.Parse(tbAantal.Text);  // hiermee maak ik de tekst een heel getal 
                    regel.prijs = double.Parse(tbPrijs.Text); // want dit is een komma getal
                    regels.Add(regel);
                    _grandTotal += regel.totaal();

                    tbtotaalOverzicht.Text = $"€{_grandTotal}";
                    cmbPizzaPasta.SelectedValue = "";
                    tbPrijs.Text = "€ 0,00";
                    rb25Cm.IsChecked = false;
                    rb35Cm.IsChecked = false;
                    tbAantal.Text = "";
                    tbtoevoegen.Text = "€ 0,00";
                    tbtoevoegen.Foreground = Brushes.Black;
                }
                        
              
                else
                {
                    MessageBox.Show("Selecteer een gerecht...");
                }
                

            }
            catch (Exception)
            {
                                 
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string error = "";
            

            // 1: naam
            // 2: plaats
            // 3: postcode : extra check
            // 4: adres

            if (tbnaam.Text == "")
            {
                error += "***ERROR***" + " " + "Vul een naam in \r\n";
                
            }

            if (tbplaats.Text == "")
            {
                error += "***ERROR***" + " " + "Vul een plaats in \r\n";

            }

            if (tbAdres.Text == "")
            {
                error += "***ERROR***" + " " + "Vul een adres in \r\n";

            }

            // Create a Regex
            // split
            // checken op max 2 items
            // eerste item alleen cijfer met lengte van 4
            // tweede item 2 hoofdletters

            string[] postcodeChecker = tbpostcode.Text.Split(' ');

            if (postcodeChecker.Length == 2)
            {
                if (!Regex.IsMatch(postcodeChecker[0], @"^[1-9]{4}$") || !Regex.IsMatch(postcodeChecker[1], @"^[A-Z]{2}$"))
                {
                  
                    error += "***ERROR***" + " " + "Vul een correcte postcode in \r\n";
                }
            }
            else
            {
                error += "***ERROR***" + " " + "Vul een correcte postcode in \r\n";
            }

            ///bestelling afronden en reset van bestelling 
            
            if (error == "")
            {
                MessageBoxResult m = MessageBox.Show("Bedankt voor uw bestelling. Het totaal bedrag van uw bestelling is €" + _grandTotal + "\r\n" + "Klik op ja als u wilt betalen.", "Betaling:", MessageBoxButton.YesNo);


                if (m == MessageBoxResult.Yes)
                {
                    MessageBox.Show("Bedankt uw bestelling is bevestigd!");

                    
                    lbLijst.Items.Clear();
                    tbAantal.Text = "";
                    tbPrijs.Text = "€ 0,00";
                    tbtotaalOverzicht.Text = "€ 0,00";
                    tbAdres.Text = "";
                    tbnaam.Text = "";
                    tbplaats.Text = "";
                    tbpostcode.Text = "";
                    tbtoevoegen.Text = "€ 0,00";
                    tbtoevoegen.Foreground = Brushes.Black;
                    rb25Cm.IsChecked = false;
                    rb35Cm.IsChecked = false;
                    _grandTotal = 0;
                    cmbPizzaPasta.SelectedValue = "";


                }
            }
            else
            {   
                Window1 window1 = new Window1(error);
               
                

            }
           
        }

        private void doublemouse_Click(object sender, MouseButtonEventArgs e)
        {


            MessageBoxResult m = MessageBox.Show("Wilt u ....." + lbLijst.SelectedItem + " verwijderen?", "...", MessageBoxButton.YesNo,MessageBoxImage.Question);




            if (m == MessageBoxResult.Yes)
            {
                string totaal = tbtotaalOverzicht.Text.Replace("€", string.Empty);
                //string[] item = lbLijst.SelectedItem;

                //item ophalen
                string item = lbLijst.Items[lbLijst.SelectedIndex].ToString();
                string[] itemSplit = item.Split('=');
                double itemBedrag = double.Parse(itemSplit[1]);

                //bedrag van item
                double _totaal = double.Parse(totaal);
                _totaal = (_totaal - itemBedrag);
                _grandTotal = _totaal;

                //totaal overzicht berekenen na verwijdering item
                tbtotaalOverzicht.Text = _totaal.ToString();

                //item verwijderen
                lbLijst.Items.RemoveAt(lbLijst.SelectedIndex);


            }

        }
    }
}
