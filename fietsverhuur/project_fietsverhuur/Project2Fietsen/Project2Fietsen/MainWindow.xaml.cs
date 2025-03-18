using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace Project2Fietsen
{
    /*
     * Klasse: Product
     * Eigenschappen: Naam, Prijs en Huurdagen
     */
    public class Product
    {
        public string name { get; set; }        //hiermee kan de de eigenschap waarde ophalen en opslaan (get=ophalen,set=opslaan)
        public double price { get; set; }
        public double number { get; set; }




        /* 
         * Met een contructor kan de klasse direct van waarde voorzien 
           ipv dit apart doen
         * IPV  -> new Product()
                -> product.name("x");
                -> product.prijs(100.00);
         
         *  Dit    -> new Product("x","100.00") //waarden worden meegegeven als kenemerk 
         */
        public Product(string name, double price)
        {
            this.name = name;
            this.price = price;
        }
    }

    public partial class MainWindow : Window
    {
        //Eigenschappen

        //lijsten
        private List<Product> fietsen = null;
        private List<Product> verzekeringen = null;
        private List<Product> services = null;
        private List<Product> selectedProducts = null;
        private Product selectedProduct = null;

        //algemeen
        private int maxWaitingTime = 60;     //bij 60 sec stopt het --> progress bar
        DispatcherTimer timerProgress = new DispatcherTimer(); //timers

        private double totalOrderPrice = 0;
        private double amountPaid = 0;


        DispatcherTimer timer = new DispatcherTimer();
        Stopwatch stopWatch = new Stopwatch();

        //bon


        public MainWindow()
        {
            //initialize
            InitializeComponent();

            //Het initializeren van de lijsten. Er wordt nog geen waarde toegekend maar we zeggen wel dat het een lijst is met producten.
            this.fietsen = new List<Product>();
            this.verzekeringen = new List<Product>();
            this.services = new List<Product>();

            //Hierin willen we laten geselecteerde product toevoegen.
            this.selectedProduct = null;

            //In dit lijstje willen we de huidige bestelling opslaan
            this.selectedProducts = new List<Product>();

            //Nu de lijsten zijn geinitialiseerd gaan ik de lijsten voorzien van data
            this.generateFietsen();          //deze functie zorgt ervoor dat de lijst this.fietsen voorziet wordt van fietsen, zie funtie.
            this.generateVerzekeringen();
            this.generateServices();

            //setup timer
            this.timerProgress.Interval = TimeSpan.FromMilliseconds(1000);
            this.timerProgress.Start();
            this.timerProgress.Tick += fillProgressBar;
            this.progress.Maximum = this.maxWaitingTime;

            //setup stopwatch
            this.timer.Interval = TimeSpan.FromMilliseconds(1000);
            this.timer.Tick += ticTac;

        }

        //functions
        private void fillProgressBar(object sender, EventArgs e)
        {
            if (this.progress.Value < this.maxWaitingTime)
            {          //als de prgresstimer kleiner is dan de maximale tijd telt hij weer verder 
                this.progress.Value++;
            }
            else
            {
                this.Close();
            }
        }


        private void sumUp(double d)    //berekeningen voor alle munten in 1 private void
                                        //en toevoegen aan list
        {
            this.amountPaid += d; //double d wordt opgeteld bij de huidige amountpaid
            this.tbTotaalbon.Text = (this.totalOrderPrice - this.amountPaid).ToString("F");

            StackPanel sp = new StackPanel();
            TextBlock tbBedrag = new TextBlock();
            TextBlock tbPayed = new TextBlock();
            TextBlock tbAantal = new TextBlock();


            tbBedrag.Text = "Te betalen:€" + this.tbTotaalbon.Text;
            tbPayed.Text = "Betaald:€" + this.amountPaid.ToString("F");
            tbAantal.Text = "Aantal:" + TxtEeneuro.Text +TxtTweeeuro.Text + TxtVijfeuro.Text + TxtTieneuro.Text + TxtTwintigeuro.Text + TxtVijftigeuro.Text;                //hoe voeg ik hier meer toe zonder te stapelen 

            //De textblocks worden nu toegevoegd aan de stackpanel.
            sp.Children.Add(tbBedrag);
            sp.Children.Add(tbPayed);
            sp.Children.Add(tbAantal);


            //En tot slot wordt de stackpanel wordt nu toegevoegd aan de visuele lijst met bestellingen.
            this.listboxBon.Items.Add(sp);

            if (tbTotaalbon.Text == "0,00")
            {
                Window2 window2 = new Window2();
                 // Window1 MessageBoxCustom = new Window2();
                emptyFields();
            }


        }

        private void ticTac(object sender, EventArgs e) //stopwatch 
        {

            // Get the elapsed time as a TimeSpan value.
            var ts = this.stopWatch.Elapsed;

            // Format and display the TimeSpan value.
            string elapsedTime = $"{ts.Hours}:{ts.Minutes}:{ts.Seconds}";

            //settime
            this.tbStopwatch.Text = elapsedTime;
        }

        private void generateFietsen()
        {
            //fietsen toevoen aan de lijst
            this.fietsen.Add(new Product("Aanhangfiets", 20.00));
            this.fietsen.Add(new Product("Bakfiets", 35.00));
            this.fietsen.Add(new Product("Driewielfiets", 30.00));
            this.fietsen.Add(new Product("Elektrischefiets", 30.00));
            this.fietsen.Add(new Product("Kinderfiets", 15.00));
            this.fietsen.Add(new Product("Ligfiets", 45.00));
            this.fietsen.Add(new Product("Omafiets", 12.50));
            this.fietsen.Add(new Product("Racefiets", 15.00));
            this.fietsen.Add(new Product("Speedpedelec", 12.50));
            this.fietsen.Add(new Product("Stadsfiets", 10.00));
            this.fietsen.Add(new Product("Vouwfiets", 15.00));
            this.fietsen.Add(new Product("Zitfiets", 15.00));

            //elke fiets nu toevoegen aan de zichtbare cmb
            foreach (Product p in this.fietsen)
            {
                this.cmbFietsen.Items.Add(p.name + "/dag: €" + p.price);
            }
        }

        private void generateVerzekeringen()
        {

            //verzekeringen toevoegen aan de lijst
            this.verzekeringen.Add(new Product("Beschadigingen", 5.00));
            this.verzekeringen.Add(new Product("Diefstal", 10.00));
            this.verzekeringen.Add(new Product("Rechtsbijstand", 5.00));
            this.verzekeringen.Add(new Product("Ongevallen", 2.50));

            //elke verzekering toevoen aan de zichtbare cmb
            foreach (Product p in this.verzekeringen)
            {
                this.cmbVerzekeringen.Items.Add(p.name + "/dag: €" + p.price);
            }
        }

        private void generateServices()
        {

            //services toevoegen aan de lijst
            this.services.Add(new Product("Ophaalservice", 15.00));
            this.services.Add(new Product("Regenpak", 10.00));
            this.services.Add(new Product("Lunchpakket basis", 12.50));
            this.services.Add(new Product("Lunchpakket uitgebreid", 20.00));

            //elke service toevoen aan de zichtbare cmb
            foreach (Product p in this.services)
            {
                this.cmbServices.Items.Add(p.name + "/dag: €" + p.price);
            }
        }

        private void resetFields()
        {
            //uitrekenen of er nog geld teruggeven moet worden
            double x = (this.totalOrderPrice - this.amountPaid);
            Boolean moneyback = x < 0 ? true : false;

            //zo ja dan tonen van een messagebox
            if (moneyback)
            {
                MessageBox.Show("U krijgt nog €" + Math.Abs(x) + " terug!");
            }

            //velden leegmaken
            emptyFields();

            //cmb heractiveren
            enableCMB(true, true, true);
        }

        /*
         * beschrijving : Hiermee kunnen de cmb fietsen, verzekeringen en services geactiveerd of gedeactiveerd worden.
         * resultaat    : Een actieve of gedeactiveerde cmb
         */
        private void enableCMB(Boolean f, Boolean v, Boolean s) //?
        {
            this.cmbFietsen.IsEnabled = f;
            this.cmbVerzekeringen.IsEnabled = v;
            this.cmbServices.IsEnabled = s;
        }

        /*
        * beschrijving : Een functie om velden velden te resetten.
        */
        private void emptyFields()
        {
            this.cmbFietsen.SelectedValue = "";
            this.cmbVerzekeringen.SelectedValue = "";
            this.cmbServices.SelectedValue = "";
            this.listboxBestel.Items.Clear();
            this.selectedProducts.Clear();
            this.txtTotal.Text = "";
            this.totalOrderPrice = 0;
            this.amountPaid = 0;
            this.tbTotaalbon.Text = "";
            this.listboxBon.Items.Clear();
        }


        private void resetProgressTimer()
        {
            this.progress.Value = 0; //zodat de timer steeds opnieuw begint bij activiteit
        }

        private void cmbFietsen_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            resetProgressTimer();
            enableCMB(true, false, false);   //zodat ze niet tegelijk beschikbaar zijn
        }

        private void cbVerzekering_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            resetProgressTimer();
            enableCMB(false, true, false);
        }

        private void cbService_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            resetProgressTimer();
            enableCMB(false, false, true);
        }

        private void Start_Tijd_Click(object sender, RoutedEventArgs e) //timers worden hier gestart 
        {
            this.timer.Start();
            this.stopWatch.Start();
        }

        /*
        * beschrijving : Door te klikken op toevoegen wordt het geselecteerde product toegevoegd aan de lijst met bestellingen.
        */
        private void btntoevoeg_Click(object sender, RoutedEventArgs e)
        {

            //De timer kan nu gepauzeerd gereset worden omdat er activiteit is

            //Is er uberhaupt een product geselecteerd uit een van de cmb?
            Boolean b = this.cmbFietsen.SelectedItem == null && cmbVerzekeringen.SelectedItem == null && this.cmbServices.SelectedItem == null ? true : false;

            if (b)
            {
                //niets geselecteerd...
                MessageBox.Show("Selecteer een product.");
            }
            else
            {
                //Er is een product geselecteerd :)
                //Nu wordt er achterhaald wat voor type product er geselecteerd is.
                Boolean f = this.cmbFietsen.Text != "" ? true : false;
                Boolean v = this.cmbVerzekeringen.Text != "" ? true : false;
                Boolean s = this.cmbServices.Text != "" ? true : false;

                //Is er een fiets geselecteerd ?
                if (f)
                {
                    /* 
                     * Dan gaan we opzoek naar het naam van het product. 
                     * De naam van het product is als volgt opgebouwd 'fiets/dag:prijs'. 
                     * Als de naam geslipts wordt op het teken '/' dan zit de naam in pieces[0].
                     */
                    string[] pieces = this.cmbFietsen.Text.Split('/');

                    /* 
                    * Nu de naam gevonden is wordt er gecontroleerd of de naam voorkomt de lijst.
                    * Het product dat is toegevoegd in de genereerfunctie wordt dan opgeslagen in this.selectedProduct
                    */
                    this.selectedProduct = this.fietsen.FirstOrDefault(p => p.name == pieces[0]);
                }

                //Is er een verzekering geselecteerd ?
                if (v)
                {
                    /* 
                    * Dan gaan we opzoek naar het naam van het product. 
                    * De naam van het product is als volgt opgebouwd 'fiets/dag:prijs'. 
                    * Als de naam geslipts wordt op het teken '/' dan zit de naam in pieces[0].
                    */
                    string[] pieces = this.cmbVerzekeringen.Text.Split('/');

                    /* 
                    * Nu de naam gevonden is wordt er gecontroleerd of de naam voorkomt de lijst.
                    * Het product dat is toegevoegd in de genereerfunctie wordt dan opgeslagen in this.selectedProduct
                    */
                    this.selectedProduct = this.verzekeringen.FirstOrDefault(p => p.name == pieces[0]);
                }

                //Is er een service geselecteerd ?
                if (s)
                {

                    /* 
                    * Nu de naam gevonden is wordt er gecontroleerd of de naam voorkomt de lijst.
                    * Het product dat is toegevoegd in de genereerfunctie wordt dan opgeslagen in this.selectedProduct
                    */
                    string[] pieces = this.cmbServices.Text.Split('/');

                    /* 
                    * Nu de naam gevonden is wordt er gecontroleerd of de naam voorkomt de lijst.
                    * Het product dat is toegevoegd in de genereerfunctie wordt dan opgeslagen in this.selectedProduct
                    */
                    this.selectedProduct = this.services.FirstOrDefault(p => p.name == pieces[0]);
                }

                //De aantal dagen dat het product wordt gehuurd zit in txtDays en deze slaan we op in het selectedProduct.number. Hierdoor kan de prijs berekend worden. 
                this.selectedProduct.number = int.Parse(this.txtDays.Text);

                //Het geselecteerde product wordt nu opgeslagen in de lijst met alle geselecteerde producten.
                this.selectedProducts.Add(selectedProduct);

                //Stackpanelmaken
                StackPanel sp = new StackPanel();
                TextBlock tbDesc = new TextBlock();
                TextBlock tbPrice = new TextBlock();
                TextBlock tbDays = new TextBlock();

                //Er worden 3 eigenschappen van het product getoond prijs, naam en aantal dagen huur. Deze eigenschappen worden nu toegekend aan de afzonderlijke stackpanel textblocks.
                tbDesc.Text = "Prijs:€" + this.selectedProduct.price.ToString();
                tbPrice.Text = this.selectedProduct.name;
                tbDays.Text = "Aantal dagen:" + this.selectedProduct.number.ToString();

                //De textblocks worden nu toegevoegd aan de stackpanel.
                sp.Children.Add(tbDesc);
                sp.Children.Add(tbPrice);
                sp.Children.Add(tbDays);

                //de stackpanel wordt nu toegevoegd aan de visuele lijst met bestellingen.
                this.listboxBestel.Items.Add(sp);

                //Er is een nieuw product toegevoegd aan de lijst en hierdoor moet de prijs herbekend worden.
                this.calculatePrice();

            }

            this.resetFieldsP();

        }

        private void resetFieldsP()
        {

            this.cmbFietsen.SelectedValue = "";
            this.cmbVerzekeringen.SelectedValue = "";
            this.cmbServices.SelectedValue = "";
            enableCMB(true, true, true);
        }



        private void calculatePrice()
        {
            double totalprice = 0;    //waarom werkt double niet?

            foreach (Product p in this.selectedProducts)
            {
                totalprice += p.price * p.number;
            }

            this.totalOrderPrice = totalprice;

            this.txtTotal.Text = totalprice.ToString("F"); //F zegt dat het om geld gaat 2 achter komma

        }

        private void btnvolgende_Click(object sender, RoutedEventArgs e)
        {
            this.resetFields();
        }

        private void lbBestel_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (this.listboxBestel.SelectedItem != null)
            {
                MessageBoxResult m = MessageBox.Show("Wilt u het product verwijderen?", "Confirm", MessageBoxButton.YesNo);
                if (m == MessageBoxResult.Yes)
                {
                    //bestelbox bestaat uit stackpanels dus moeten wij die gaan ophalen
                    StackPanel sp = (StackPanel)this.listboxBestel.SelectedItem;

                    //stackpanel bestaat uit twee textboxes en in nmr 1 zit de naam
                    string n = (sp.Children[1] as TextBlock).Text.Trim().ToString();

                    //met de naam kunnen wij nu het object opzoeken - firstordefault --> zoekt naar het obeject op basis van een naam uit de lijst met producten 
                    Product x = this.selectedProducts.FirstOrDefault(p => p.name == n);

                    //het verwijderen van het object
                    this.selectedProducts.Remove(x);
                    this.listboxBestel.Items.Remove(this.listboxBestel.SelectedItem);

                    //prijs opnieuw berekenen
                    this.calculatePrice();
                }
            }
        }


        private void Tweeeuro_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.sumUp(double.Parse(this.TxtTweeeuro.Text) * 2);
            }
            catch
            {
                MessageBox.Show("Voer een getal in aub");
            }
        }


        private void Eeneuro_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.sumUp(double.Parse(this.TxtEeneuro.Text) * 1);
            }
            catch
            {
                MessageBox.Show("Voer een getal in aub");
            }
        }

    private void Vijftigcent_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.sumUp(double.Parse(this.TxtVijftigcent.Text) * 0.50);
            }
            catch
            {
                MessageBox.Show("Voer een getal in aub");
            }
        }
    private void Twintigcent_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.sumUp(double.Parse(this.TxtTwintigcent.Text) * 0.20);
            }
            catch
            {
                MessageBox.Show("Voer een getal in aub");
            }
        }


        private void Tiencent_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.sumUp(double.Parse(this.TxtTiencent.Text) * 0.10);
            }
            catch
            {
                MessageBox.Show("Voer een getal in aub");
            }
        }

    private void Vijfcent_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.sumUp(double.Parse(this.TxtVijfcent.Text) * 0.05);
            }
            catch
            {
                MessageBox.Show("Voer een getal in aub");
            }
        }

        private void Vijftigeuro_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.sumUp(double.Parse(this.TxtVijftigeuro.Text) * 50);
            }
            catch
            {
                MessageBox.Show("Voer een getal in aub");
            }
        }


    private void Twintigeuro_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.sumUp(double.Parse(this.TxtTwintigeuro.Text) * 20);
            }
            catch
            {
                MessageBox.Show("Voer een getal in aub");
            }
        }

        private void Tieneuro_Click(object sender, RoutedEventArgs e)
        {
            try { 
            this.sumUp(double.Parse(this.TxtTieneuro.Text) * 10);
            }
            catch {
                MessageBox.Show("Voer een getal in aub");
            }
        }

        private void Vijfeuro_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.sumUp(double.Parse(this.TxtVijfeuro.Text) * 5);
            }
            catch
            {
                MessageBox.Show("Voer een getal in aub");
            }
        }

        private void rekenm_Click(object sender, RoutedEventArgs e)
        {
            Window1 calc = new Window1();
            calc.Show();
        }

        private void lbBestel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}