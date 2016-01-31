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

            List<string> words = fetchWords();
           

            prvaRijecCheck.Content = words.ElementAt(0);
            drugaRijecCheck.Content = words.ElementAt(1);
            trecaRijecCheck.Content = words.ElementAt(2);
            cetvrtaRijecCheck.Content = words.ElementAt(3);
            petaRijecCheck.Content = words.ElementAt(4);

            prvaRijecCheck.IsEnabled = false;
            drugaRijecCheck.IsEnabled = false;
            trecaRijecCheck.IsEnabled = false;
            cetvrtaRijecCheck.IsEnabled = false;
            petaRijecCheck.IsEnabled = false;

            OK.IsEnabled = false;

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

            if (secondscount < startTime)
            {
                SecondsTextBlock.Text = (startTime - secondscount % 60).ToString();
                OK.IsEnabled = false;
                if(prvaRijecCheck.IsChecked == true &&
                    drugaRijecCheck.IsChecked == true &&
                    trecaRijecCheck.IsChecked == true &&
                    cetvrtaRijecCheck.IsChecked == true &&
                    petaRijecCheck.IsChecked == true)
                {
                    OK.IsEnabled = true;
                }
            }

            if (secondscount > startTime)
            {
                prvaRijecCheck.IsEnabled = false;
                drugaRijecCheck.IsEnabled = false;
                trecaRijecCheck.IsEnabled = false;
                cetvrtaRijecCheck.IsEnabled = false;
                petaRijecCheck.IsEnabled = false;
                SecondsTextBlock.Text = "Your time has expired!!!";

                OK.IsEnabled = true;

            }

        }
        private void Back_Click(object sender, RoutedEventArgs e) {
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(TeamNamingPage));
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            timer.Start();
            prvaRijecCheck.IsEnabled = true;
            drugaRijecCheck.IsEnabled = true;
            trecaRijecCheck.IsEnabled = true;
            cetvrtaRijecCheck.IsEnabled = true;
            petaRijecCheck.IsEnabled = true;

        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(TeamPage), teams);
        }

        private List<string> fetchWords()
        {
            HashSet<Word> hash = AppLogics.getAll();
            List<string> words = new List<string>();
            Random random = new Random();
            Word word;
            string str;
            DifficultyEnum tezina;
            int easy = 0;
            int medium = 0;
            int hard = 0;

            if (d == DifficultyEnum.EASY)
            {
                for (int i = 0; i < 5; i++)
                {
                    word = hash.ElementAt(random.Next(hash.Count));
                    str = word.Term;
                    tezina = word.Difficulty;
                    if (tezina == DifficultyEnum.EASY)
                        easy++;
                    if (tezina == DifficultyEnum.MEDIUM)
                        medium++;
                    if (tezina == DifficultyEnum.HARD)
                        hard++;
                    if (words.Contains(str) || (medium / (easy + medium + hard) > 0.25) || (hard / (easy + medium + hard) > 0.25))
                    {
                        if (tezina == DifficultyEnum.EASY)
                            easy--;
                        if (tezina == DifficultyEnum.MEDIUM)
                            medium--;
                        if (tezina == DifficultyEnum.HARD)
                            hard--;
                        i--;
                    }
                    else {
                        words.Add(str);
                    }
                }
                return words;
            }
            else if (d == DifficultyEnum.MEDIUM)
            {
                for (int i = 0; i < 5; i++)
                {
                    word = hash.ElementAt(random.Next(hash.Count));
                    str = word.Term;
                    tezina = word.Difficulty;
                    if (tezina == DifficultyEnum.EASY)
                        easy++;
                    if (tezina == DifficultyEnum.MEDIUM)
                        medium++;
                    if (tezina == DifficultyEnum.HARD)
                        hard++;
                    if (words.Contains(str) || (easy / (easy + medium + hard) > 0.25) || (hard / (easy + medium + hard) > 0.25))
                    {
                        if (tezina == DifficultyEnum.EASY)
                            easy--;
                        if (tezina == DifficultyEnum.MEDIUM)
                            medium--;
                        if (tezina == DifficultyEnum.HARD)
                            hard--;
                        i--;
                    }
                    else {
                        words.Add(str);
                    }
                }
                return words;
            }
            else if (d == DifficultyEnum.HARD)
            {
                for (int i = 0; i < 5; i++)
                {
                    word = hash.ElementAt(random.Next(hash.Count));
                    str = word.Term;
                    tezina = word.Difficulty;
                    if (tezina == DifficultyEnum.EASY)
                        easy++;
                    if (tezina == DifficultyEnum.MEDIUM)
                        medium++;
                    if (tezina == DifficultyEnum.HARD)
                        hard++;
                    if (words.Contains(str) || (easy / (easy + medium + hard) > 0.10) || (medium / (easy + medium + hard) > 0.25))
                    {
                        if (tezina == DifficultyEnum.EASY)
                            easy--;
                        if (tezina == DifficultyEnum.MEDIUM)
                            medium--;
                        if (tezina == DifficultyEnum.HARD)
                            hard--;
                        i--;
                    }
                    else {
                        words.Add(str);
                    }
                }
                return words;
            }
            else {
                for (int i = 0; i < 5; i++)
                {
                    word = hash.ElementAt(random.Next(hash.Count));
                    str = word.Term;
                    tezina = word.Difficulty;
                    if (tezina == DifficultyEnum.EASY)
                        easy++;
                    if (tezina == DifficultyEnum.MEDIUM)
                        medium++;
                    if (tezina == DifficultyEnum.HARD)
                        hard++;
                    if (words.Contains(str) || (easy / (easy + medium + hard) > 0.10) || (medium / (easy + medium + hard) > 0.25))
                    {
                        if (tezina == DifficultyEnum.EASY)
                            easy--;
                        if (tezina == DifficultyEnum.MEDIUM)
                            medium--;
                        if (tezina == DifficultyEnum.HARD)
                            hard--;
                        i--;
                    }
                    else {
                        words.Add(str);
                    }
                }
                return words;
            }
        }
    }
}

