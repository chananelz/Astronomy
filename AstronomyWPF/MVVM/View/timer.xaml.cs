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
using System.Windows.Media.Animation;
using System.Threading;

namespace AstronomyWPF.MVVM.View
{
    /// <summary>
    /// Interaction logic for timer.xaml
    /// </summary>
    public partial class timer : UserControl
    {
        public timer()
        {
            InitializeComponent();
            StartTimer();
            StartAnimation();
        }
        // Start / Stop Timer

        DispatcherTimer _timer = new DispatcherTimer();
        int counter = 0;

        private void timer_Tick(object sender, EventArgs e)
        {
            counter++;
            TimerLabel.Text = counter.ToString();


            if (counter == 100)
            {
                _timer.Stop();
                TimerLabel.Text = "0".ToString();
                //MessageBox.Show("For your safetythe app will Shoutdonw in 1 minit.\n You can send messages again tomorrow ", "Alert", MessageBoxButton.OK, MessageBoxImage.);
                Thread.Sleep(500);
                Application.Current.Shutdown();
            }

        }

        private void StartTimer()
        {
            cpb_uc.Visibility = Visibility.Visible;

            if (counter > 0)
            {
                _timer.Tick -= timer_Tick;
                counter = 0;
            }

            _timer.Interval = TimeSpan.FromMilliseconds(1580);
            _timer.Tick += timer_Tick;
            _timer.Start();
        }

        private void StopTimer()
        {
            if (counter > 0)
            {
                _timer.Tick -= timer_Tick;
                counter = 0;
            }

            _timer.Stop();
            cpb_uc.Visibility = Visibility.Collapsed;
            TimerLabel.Text = "0".ToString();
        }

        private void StartAnimation()
        {
            ((Storyboard)cpb_uc.Resources["ProgressBarAnimation"]).Begin();
        }

        private void StopAnimation()
        {
            ((Storyboard)cpb_uc.Resources["ProgressBarAnimation"]).Stop();
        }

        private void Start_Btn_Checked(object sender, RoutedEventArgs e)
        {
            StartTimer();
            StartAnimation();
        }

        private void Start_Btn_Unchecked(object sender, RoutedEventArgs e)
        {
            StopTimer();
            StopAnimation();
        }

        private void Uncheck_Stop(object sender, RoutedEventArgs e)
        {
            Start_Btn.IsChecked = false;
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
