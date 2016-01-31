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
        List<string> words;
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

            words = fetchWords();


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

        protected override void OnNavigatedTo(NavigationEventArgs e) {

            CurrentTeam.Text = AppLogics.teams.Peek().TeamName;

        }

        private void Secondstimer_Tick(object sender, object e) {
            secondscount++;
            if (secondscount == startTime) {
                SecondsTextBlock.Text = "0";
            }

            if (secondscount < startTime) {
                SecondsTextBlock.Text = (startTime - secondscount % 60).ToString();
                OK.IsEnabled = false;
                if (prvaRijecCheck.IsChecked == true &&
                    drugaRijecCheck.IsChecked == true &&
                    trecaRijecCheck.IsChecked == true &&
                    cetvrtaRijecCheck.IsChecked == true &&
                    petaRijecCheck.IsChecked == true) {
                    OK.IsEnabled = true;
                }
            }

            if (secondscount > startTime) {
                prvaRijecCheck.IsEnabled = false;
                drugaRijecCheck.IsEnabled = false;
                trecaRijecCheck.IsEnabled = false;
                cetvrtaRijecCheck.IsEnabled = false;
                petaRijecCheck.IsEnabled = false;
                SecondsTextBlock.Text = "Your time has expired!!!";

                OK.IsEnabled = true;

            }

        }

        private void Start_Click(object sender, RoutedEventArgs e) {
            timer.Start();
            prvaRijecCheck.IsEnabled = true;
            drugaRijecCheck.IsEnabled = true;
            trecaRijecCheck.IsEnabled = true;
            cetvrtaRijecCheck.IsEnabled = true;
            petaRijecCheck.IsEnabled = true;

        }

        private void OK_Click(object sender, RoutedEventArgs e) {
            Frame rootFrame = Window.Current.Content as Frame;

            //calculate team points - 1 easy, 2 medium, 3 hard, time bonus
            timer.Stop();
            int points = 0;
            if (prvaRijecCheck.IsChecked == true)
                points += findDifficulty(words.ElementAt(0));

            if (drugaRijecCheck.IsChecked == true)
                points += findDifficulty(words.ElementAt(1));
            if (trecaRijecCheck.IsChecked == true)
                points += findDifficulty(words.ElementAt(2));
            if (cetvrtaRijecCheck.IsChecked == true)
                points += findDifficulty(words.ElementAt(3));
            if (petaRijecCheck.IsChecked == true)
                points += findDifficulty(words.ElementAt(4));

            //time bonus - 1 point for every 15 seconds
            points += (startTime - secondscount) / 15;
            AppLogics.teams.ElementAt(0).Points += points;
            rootFrame.Navigate(typeof(TeamPage));
        }

        private List<string> fetchWords() {
            HashSet<Word> hash = AppLogics.getAll();
            List<string> words = new List<string>();
            Random random = new Random();
            Word word;
            string str;
            DifficultyEnum tezina;

            if (d == DifficultyEnum.EASY) {
                int easy = 3;
                int medium = 1;
                int hard = 1;
                int i = 0;
                while (i < 5) {
                    word = hash.ElementAt(random.Next(hash.Count));
                    str = word.Term;
                    tezina = word.Difficulty;
                    if (tezina == DifficultyEnum.EASY && easy > 0 && !words.Contains(str)) {
                        i++;
                        easy--;
                        words.Add(str);
                    } else if (tezina == DifficultyEnum.MEDIUM && medium > 0 && !words.Contains(str)) {
                        i++;
                        medium--;
                        words.Add(str);
                    } else if (tezina == DifficultyEnum.HARD && hard > 0 && !words.Contains(str)) {
                        i++;
                        hard--;
                        words.Add(str);
                    }
                }
                return words;
            } else if (d == DifficultyEnum.MEDIUM) {
                int easy = 1;
                int medium = 2;
                int hard = 2;
                int i = 0;
                while (i < 5) {
                    word = hash.ElementAt(random.Next(hash.Count));
                    str = word.Term;
                    tezina = word.Difficulty;
                    if (tezina == DifficultyEnum.EASY && easy > 0 && !words.Contains(str)) {
                        i++;
                        easy--;
                        words.Add(str);
                    } else if (tezina == DifficultyEnum.MEDIUM && medium > 0 && !words.Contains(str)) {
                        i++;
                        medium--;
                        words.Add(str);
                    } else if (tezina == DifficultyEnum.HARD && hard > 0 && !words.Contains(str)) {
                        i++;
                        hard--;
                        words.Add(str);
                    }
                }
                return words;
            } else if (d == DifficultyEnum.HARD) {
                int easy = 1;
                int medium = 1;
                int hard = 3;
                int i = 0;
                while (i < 5) {
                    word = hash.ElementAt(random.Next(hash.Count));
                    str = word.Term;
                    tezina = word.Difficulty;
                    if (tezina == DifficultyEnum.EASY && easy > 0 && !words.Contains(str)) {
                        i++;
                        easy--;
                        words.Add(str);
                    } else if (tezina == DifficultyEnum.MEDIUM && medium > 0 && !words.Contains(str)) {
                        i++;
                        medium--;
                        words.Add(str);
                    } else if (tezina == DifficultyEnum.HARD && hard > 0 && !words.Contains(str)) {
                        i++;
                        hard--;
                        words.Add(str);
                    }
                }
                return words;
            } else {
                int easy = 0;
                int medium = 1;
                int hard = 4;
                int i = 0;
                while (i < 5) {
                    word = hash.ElementAt(random.Next(hash.Count));
                    str = word.Term;
                    tezina = word.Difficulty;
                    if (tezina == DifficultyEnum.EASY && easy > 0 && !words.Contains(str)) {
                        i++;
                        easy--;
                        words.Add(str);
                    } else if (tezina == DifficultyEnum.MEDIUM && medium > 0 && !words.Contains(str)) {
                        i++;
                        medium--;
                        words.Add(str);
                    } else if (tezina == DifficultyEnum.HARD && hard > 0 && !words.Contains(str)) {
                        i++;
                        hard--;
                        words.Add(str);
                    }
                }
                return words;
            }
        }
        private int findDifficulty(string word) {
            HashSet<Word> hash = AppLogics.getAll();

            Word w = hash.Single(i => i.Term == word);

            if (w.Difficulty == DifficultyEnum.EASY)
                return 1;
            if (w.Difficulty == DifficultyEnum.MEDIUM)
                return 2;
            if (w.Difficulty == DifficultyEnum.HARD)
                return 3;
            return 0;
        }
    }
}

