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
using GuessMe.controller;

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
        DifficultyEnum d;
        public GamePage() {
            this.InitializeComponent();

            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += Secondstimer_Tick;

            d = PlayPage.difficulty;
            string diff = d.ToString();

            if (diff.Equals("EXTREME"))
                startTime = 30;
            SecondsTextBlock.Text = startTime.ToString();
            

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
            if(secondscount == startTime)
            {
                SecondsTextBlock.Text = "0";
            }

            if(secondscount < startTime)
                SecondsTextBlock.Text = (startTime - secondscount % 60).ToString();

            if (secondscount > startTime)
            {
                SecondsTextBlock.Text = "Your time has expired!!!";

                if (secondscount == startTime + 5)
                {
                    Frame rootFrame = Window.Current.Content as Frame;
                    rootFrame.Navigate(typeof(TeamPage));
                }
            }

        }
        private void Back_Click(object sender, RoutedEventArgs e) {
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(TeamNamingPage));
        }

        private void OK_Click(object sender, RoutedEventArgs e) {
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(TeamPage));
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
                timer.Start();
        }

        private List<string> fetchWords()
        {
            List<string> w = new List<string>();
            HashSet<Word> words = AppLogics.getAllDifficulty(d);
            Random random = new Random();
            
            for(int i = 0; i < 5; i++)
            {
                string str = words.ElementAt(random.Next(words.Count)).Term;
                if (w.Contains(str))
                    i--;
                else w.Add(str);
            }
            return w;
        }
    }
}
