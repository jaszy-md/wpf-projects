using System.Windows;
using System.Windows.Controls;

namespace Project2Fietsen
{
    public partial class Window1 : Window{
        string output = "";
        double tempnr = 0;
        string operation = "";

        public Window1(){
            InitializeComponent();
            this.DataContext = this;
        }

        private void btNumber_Click(object sender, RoutedEventArgs e){
            string name = ((Button)sender).Name;

            switch(name)
            {
                case "btn0":
                    output += "0";
                    tbTotal.Text = output;
                    break;
                case "btn1":
                    output += "1";
                    tbTotal.Text = output;
                    break;
                case "btn2":
                    output += "2";
                    tbTotal.Text = output;
                    break;
                case "btn3":
                    output += "3";
                    tbTotal.Text = output;
                    break;
                case "btn4":
                    output += "4";
                    tbTotal.Text = output;
                    break;
                case "btn5":
                    output += "5";
                    tbTotal.Text = output;
                    break;
                case "btn6":
                    output += "6";
                    tbTotal.Text = output;
                    break;
                case "btn7":
                    output += "7";
                    tbTotal.Text = output;
                    break;
                case "btn8":
                    output += "8";
                    tbTotal.Text = output;
                    break;
                case "btn9":
                    output += "9";
                    tbTotal.Text = output;
                    break;
            }
        }

        private void btnResult_Click(object sender, RoutedEventArgs e){
            double outputtempo;

            switch (operation)
            {
                case "Min":
                    outputtempo = tempnr - double.Parse(output);
                    output = outputtempo.ToString();
                    tbTotal.Text = output;
                    break;

                case "Plus":
                    outputtempo = tempnr + double.Parse(output);
                    output = outputtempo.ToString();
                    tbTotal.Text = output;
                    break;

                case "Keer":
                    outputtempo = tempnr * double.Parse(output);
                    output = outputtempo.ToString();
                    tbTotal.Text = output;
                    break;

                case "Delen":
                    outputtempo = tempnr / double.Parse(output);
                    output = outputtempo.ToString();
                    tbTotal.Text = output;
                    break;
            }
        }

        private void btnmin_Click(object sender, RoutedEventArgs e) {
            if (output != "")
            {
                tempnr = double.Parse(output);

                output = "";
                operation = "Min";
            }
        }
        private void btnPlus_Click(object sender, RoutedEventArgs e){
            if (output != "")
            {
                tempnr = double.Parse(output);
                output = "";
                operation = "Plus";
            }
        }

        private void btnDelen_Click(object sender, RoutedEventArgs e){
            if (output != "")
            {
                tempnr = double.Parse(output);
                output = "";
                operation = "Delen";
            }
        }

        private void btnKeer_Click(object sender, RoutedEventArgs e){
            if (output != "")
            {
                tempnr = double.Parse(output);
                output = "";
                operation = "Keer";
            }
        }

        private void btClear_Click(object sender, RoutedEventArgs e){
            output = "";
            tbTotal.Text = output;
        }
    }
}
