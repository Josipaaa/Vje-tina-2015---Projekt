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
    public sealed partial class AddWordPage : Page {
        public AddWordPage() {
            this.InitializeComponent();
        }

        private void Back_Click(object sender, RoutedEventArgs e) {
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(MainPage));
        }

        private async void OK_Click(object sender, RoutedEventArgs e) {
            string word = WordText.Text;

            if (!this.checkWord(word)) {
                var dialog = new Windows.UI.Popups.MessageDialog(
               "Something went wrong " +
               "We are sorry.",
               "Your word cannot be added.");

                dialog.Commands.Add(new Windows.UI.Popups.UICommand("OK") { Id = 0 });
                dialog.DefaultCommandIndex = 0;
                var result = await dialog.ShowAsync();
                var btn = sender as Button;
                btn.Content = $"Result: {result.Label} ({result.Id})";
            }
            bool? difficulty = Hard.IsChecked;
            bool? questionable = QYes.IsChecked;
            bool? drawable = DYes.IsChecked;
            bool? pantomimable = PYes.IsChecked;
            if (difficulty.HasValue && questionable.HasValue && drawable.HasValue && pantomimable.HasValue) {
                Word neu = new Word(word, difficulty == true ? DifficultyEnum.HARD: DifficultyEnum.MEDIUM, questionable == true ? true : false, 
                    drawable == true ? true : false, pantomimable == true ? true : false);
                AppLogics.addWord(neu);
            }
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(MainPage));
        }

        private bool checkWord(string word) {
            if (word == null || word.Length < 1)
                return false;
            return true;
        }
    }
}
