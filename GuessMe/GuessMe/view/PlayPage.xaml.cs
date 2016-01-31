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
    public sealed partial class PlayPage : Page {

        public static int teamNumber { get; set; }
        public static DifficultyEnum difficulty { get; set;}
        public PlayPage() {
            this.InitializeComponent();
        }

        private void Back_Click(object sender, RoutedEventArgs e) {
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(MainPage));
        }

        private void OK_Click(object sender, RoutedEventArgs e) {
            Frame rootFrame = Window.Current.Content as Frame;
            RadioButton rb = sender as RadioButton;

            //selected number of teams
            bool? twoTeams = _2Team.IsChecked;
            bool? threeTeams = _3Team.IsChecked;
            bool? fourTeams = _4Team.IsChecked;
            bool? fiveTeams = _5Team.IsChecked;

            if(twoTeams == true)
                teamNumber = 2;
            if (threeTeams == true)
                teamNumber = 3;
            if (fourTeams == true)
                teamNumber = 4;
            if (fiveTeams == true)
                teamNumber = 5;

            //selectes difficulty
            bool? easy = Easy.IsChecked;
            bool? hard = Hard.IsChecked;
            bool? medium = Medium.IsChecked;
            bool? extr = Extreme.IsChecked;

            if (easy == true)
                difficulty = DifficultyEnum.EASY;
            if (hard == true)
                difficulty = DifficultyEnum.HARD;
            if (medium == true)
                difficulty = DifficultyEnum.MEDIUM;
            if (extr == true)
                difficulty = DifficultyEnum.EXTREME;

            rootFrame.Navigate(typeof(TeamNamingPage), teamNumber);

        }
    }
}
