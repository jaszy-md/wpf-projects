namespace WpfAppPizza
{
    internal class Bonregel
    {
        public double prijs;
        public string naam;
        public int aantal;
        public double totaal() { return prijs * aantal;}
    }
}
