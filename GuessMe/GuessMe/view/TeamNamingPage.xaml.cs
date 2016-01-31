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
    /// 
    public sealed partial class TeamNamingPage : Page {
        public static List<Team> teams;
        public TeamNamingPage() {
            this.InitializeComponent();
                    
        }

        int teamNum;
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if(e.Parameter != null)
                teamNum = (int) e.Parameter;
            if(teamNum < 5)
                Team5Name.IsEnabled = false;

            if(teamNum < 4)
                Team4Name.IsEnabled = false;

            if (teamNum < 3)
                Team3Name.IsEnabled = false;
        }

        private void Back_Click(object sender, RoutedEventArgs e) {
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(PlayPage));
        }

        private void OK_Click(object sender, RoutedEventArgs e) {
            Frame rootFrame = Window.Current.Content as Frame;
            teams = new List<Team>();
            teams.Add(new Team(Team1Name.Text));
            teams.Add(new Team(Team2Name.Text));

            if(Team3Name.IsEnabled)
                teams.Add(new Team(Team3Name.Text));
            if (Team4Name.IsEnabled)
                teams.Add(new Team(Team4Name.Text));
            if (Team5Name.IsEnabled)
                teams.Add(new Team(Team5Name.Text));

            for(int i = 0; i < teamNum; i++)
            {
                
                if (!teamInputCheck(teams.ElementAt(i).TeamName))
                {
                    teams.ElementAt(i).TeamName = "Team " + (i+1);
                }
            }
            rootFrame.Navigate(typeof(GamePage), teams);
        }

        private bool teamInputCheck(string team)
        {
            if (team == null || team.Length < 1)
                return false;
            else
                return true;
        }


    }
}
