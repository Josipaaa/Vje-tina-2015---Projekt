using GuessMe.controller;
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
    public sealed partial class TeamPage : Page {
        int numOfTeams;
        public TeamPage() {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e) {

            numOfTeams = AppLogics.teams.Count;

            List<Team> timovi = AppLogics.teams.OrderByDescending(i => i.Points).ToList();
            team1.Text = timovi.ElementAt(0).TeamName;
            team1Points.Text = timovi.ElementAt(0).Points.ToString();

            team2.Text = timovi.ElementAt(1).TeamName;
            team2Points.Text = timovi.ElementAt(1).Points.ToString();

            if (numOfTeams < 5) {
                team5.Visibility = Visibility.Collapsed;
                team5Points.Visibility = Visibility.Collapsed;
            } else {
                team5.Text = timovi.ElementAt(4).TeamName;
                team5Points.Text = timovi.ElementAt(4).Points.ToString();
            }
            if (numOfTeams < 4) {
                team4.Visibility = Visibility.Collapsed;
                team4Points.Visibility = Visibility.Collapsed;
            } else {
                team4.Text = timovi.ElementAt(3).TeamName;
                team4Points.Text = timovi.ElementAt(3).Points.ToString();
            }
            if (numOfTeams < 3) {
                team3.Visibility = Visibility.Collapsed;
                team3Points.Visibility = Visibility.Collapsed;
            } else {
                team3.Text = timovi.ElementAt(2).TeamName;
                team3Points.Text = timovi.ElementAt(2).Points.ToString();
            }

        }

        private void Next_Click(object sender, RoutedEventArgs e) {
            if (Convert.ToInt32(team1Points.Text) > 50 || Convert.ToInt32(team2Points.Text) > 50 || Convert.ToInt32(team3Points.Text) > 50
                || Convert.ToInt32(team4Points.Text) > 50 || Convert.ToInt32(team5Points.Text) > 50) {
                Frame rootFrame = Window.Current.Content as Frame;
                rootFrame.Navigate(typeof(MainPage));
            } else {
                Team t = AppLogics.teams.Dequeue();
                AppLogics.teams.Enqueue(t);
                Frame rootFrame = Window.Current.Content as Frame;
                rootFrame.Navigate(typeof(GamePage));
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e) {
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(MainPage));
        }
    }
}
