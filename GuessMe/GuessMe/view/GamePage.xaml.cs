using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace GuessMe {
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class GamePage : Page {
        //timer
        DispatcherTimer timer = new DispatcherTimer(); 
        public static List<Team> teams;
        int secondscount = 0;
        int startTime = 60;

        public GamePage() {
            this.InitializeComponent();

            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += Secondstimer_Tick;

            string diff = PlayPage.difficulty.ToString();
           
            if (diff.Equals("EXTREME"))
                startTime = 30;
            SecondsTextBlock.Text = startTime.ToString();
            timer.Start();

        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //game has just started
            if (e.Parameter is List<Team>)
            {
                teams = (List<Team>)e.Parameter;
                CurrentTeam.Text = teams.ElementAt(0).TeamName;
            }
        }

        private void Secondstimer_Tick(object sender, object e) {
            secondscount++;
            SecondsTextBlock.Text = (startTime - secondscount % 60).ToString();
           
        }
        private void Back_Click(object sender, RoutedEventArgs e) {
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(TeamNamingPage));
        }

        private void OK_Click(object sender, RoutedEventArgs e) {
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(TeamPage));
        }

        private void fetchWords()
        {

        }
    }
}
