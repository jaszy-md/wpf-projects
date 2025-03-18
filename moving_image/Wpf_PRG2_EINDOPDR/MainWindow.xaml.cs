using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace Wpf_PRG2_EINDOPDR
{
    public partial class MainWindow : Window
    {
        private double _ballPositionX = 100;
        private double _ballPositionY = 100;
        private double _ballSpeedX = 150;
        private double _ballSpeedY = 150;
        private double _delta = 0;

        public string _start = "Start";
        public string _stop = "Stop";

        private TimeSpan _previousTime;

        private readonly Stopwatch _stopwatch = Stopwatch.StartNew();

        DispatcherTimer tmCountdown = new DispatcherTimer();
        public int seconds;

        DispatcherTimer tmCountdownMin = new DispatcherTimer();
        public int seconden;

        public MainWindow()
        {
            InitializeComponent();
            _previousTime = _stopwatch.Elapsed;

            UpdateBall(0);

            tmCountdown.Interval = new TimeSpan(0, 0, 0, 1);
            tmCountdown.Tick += tmCountdown_Tick;
            tbTimer.Focus();

            tmCountdownMin.Interval = new TimeSpan(0, 0, 0, 1);
            tmCountdownMin.Tick += tmCountdownMin_Tick;
            tbTimer.Focus();

        }

        private void tmCountdownMin_Tick(object sender, EventArgs e)
        {
            seconden = int.Parse(tbTimer.Text);
            seconden--;
            tbTimer.Text = seconden.ToString();
        }

        private void tmCountdown_Tick(object sender, EventArgs e)
        {
            seconds = int.Parse(tbTimer.Text);
            seconds++;
            tbTimer.Text = seconds.ToString();
        }

        private void bt_start_Click(object sender, RoutedEventArgs e)
        {
            CompositionTarget.Rendering += Update;
            tmCountdown.Start();

            if ((string)bt_start.Content == _start)
            {
                _stopwatch.Start();
                bt_start.Content = _stop;
            }
            else if((string) bt_start.Content == _stop)
            {
                _stopwatch.Stop();
                tmCountdown.Stop();
                bt_start.Content = _start;
                
            }
        }

        private void bt_Slower_Click(object sender, RoutedEventArgs e)
        {
            _ballSpeedX = - 100;
        }

        private void bt_Faster_Click(object sender, RoutedEventArgs e)
        {
            _ballSpeedX = + _ballSpeedX +300;

            if(_ballSpeedX > 2000)
            {
                MessageBox.Show("You're going to fast, we are going to reset the speed to default. ");
                _ballSpeedX = 150;
            }
        }

        private void bt_Party_Click(object sender, RoutedEventArgs e)
        {

            CompositionTarget.Rendering += Update;
            tbTimer.Text = "30";
            tmCountdownMin.Start();
            _stopwatch.Start();

            _ballSpeedX = +_ballSpeedX + 30000;

            this.Width = System.Windows.SystemParameters.PrimaryScreenWidth;
            this.Height = System.Windows.SystemParameters.PrimaryScreenHeight;
            this.Margin = new Thickness(0, 0, 0, 0);
            this.WindowStartupLocation = WindowStartupLocation.Manual;
            this.Left = 0;
            this.Top = 0;


            string timerText = tbTimer.Text;

            switch (timerText)
            {
                case "0":
                    MessageBox.Show("Helaas, je hebt de partymodus niet gehaald. You suck");
                    break;

            }

            this.Width = System.Windows.SystemParameters.PrimaryScreenWidth;
            this.Height = System.Windows.SystemParameters.PrimaryScreenHeight;
            this.Margin = new Thickness(0, 0, 0, 0);
            this.WindowStartupLocation = WindowStartupLocation.Manual;
            this.Left = 0;
            this.Top = 0;

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem selectedItem = (ComboBoxItem)cb_Runner.SelectedItem;

            int select = cb_Runner.SelectedIndex;
            

            switch (select)
            {
                case 0:
                    Ball.Source = new BitmapImage(new Uri("Assets/roadrunner.jpg", UriKind.Relative));
                    break;

                case 1:
                    Ball.Source = new BitmapImage(new Uri("Assets/Rock.jpg", UriKind.Relative));
                    break;

                case 2:
                    Ball.Source = new BitmapImage(new Uri("Assets/Speedy.jpg", UriKind.Relative));
                    break;
            }
        }

        private void Ball_MouseEnter(object sender, MouseEventArgs e)
        {
            string count = tbTimer.Text;

            if (Ball.IsMouseOver)
            {
                
                Hurray win = new Hurray(count);
                win.Show();
            }
            _stopwatch.Stop();
            tmCountdown.Stop();
            tmCountdownMin.Stop();
            _ballPositionX = 0;
            _ballPositionY = 0;
            _ballSpeedX = 150;

            bt_start.Content = _start;

            tbTimer.Text = "0";
        }

        private void Update(object sender, EventArgs e)
        {
            var currentTime = _stopwatch.Elapsed;

             _delta = (currentTime - _previousTime).TotalSeconds;
            _previousTime = currentTime;

            UpdateBall(_delta);
        }

        private void UpdateBall(double _delta)
        {
            // ensure that the ball moves by using the deltatime.
            _ballPositionX += _ballSpeedX * _delta;
            _ballPositionY += _ballSpeedY * _delta;


            if (_ballPositionX < 0)
            {
                _ballSpeedX = -_ballSpeedX;
                _ballPositionX = 0;
            }   
            else if (_ballPositionX > MapCanvas.ActualWidth - Ball.ActualWidth)
            {
                _ballSpeedX = -_ballSpeedX;
                _ballPositionX = MapCanvas.ActualWidth - Ball.ActualWidth;
            }

            // check bounds Y
            if (_ballPositionY < 0)
            {
                _ballSpeedY = -_ballSpeedY;
                _ballPositionY = 0;
            }
            else if (_ballPositionY > MapCanvas.ActualHeight - Ball.ActualHeight)
            {
                _ballSpeedY = -_ballSpeedY;
                _ballPositionY = MapCanvas.ActualHeight - Ball.ActualHeight;
            }

            // update the position
            Canvas.SetLeft(Ball, _ballPositionX);
            Canvas.SetTop(Ball, _ballPositionY);

        }

        
    }
}
