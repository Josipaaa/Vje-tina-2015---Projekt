using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessMe.controller {
    public static class AppLogics {

        private static HashSet<Word> hash = new HashSet<Word>();

        public async static void addWord(Word word) {
            hash.Add(word);
            string term = word.Term + "|" + word.Difficulty + "|" + word.IsGuessable + "|" + word.IsDrawable + "|" + word.IsPantomimable;
            await Task.Run(() => addToFile(term));
        }
        
        private static void addToFile(string term) {
            File.AppendAllText(@"WordBase.txt",
            term + Environment.NewLine);
        }

        public static HashSet<Word> getAll() {
            return hash;
        }

        public static Word get(string word) {
            foreach (Word w in hash) {
                if (w.Term.Equals(word))
                    return w;
            }
            return null;
        }

        public static HashSet<Word> getAllDifficulty(DifficultyEnum diff)
        {
            HashSet<Word> words = new HashSet<Word>();
            foreach(Word w in hash)
            {
                if (w.Difficulty.Equals(diff))
                    words.Add(w);
            }
            return words;
        }

        public static void init() {
            string[] lines = File.ReadAllLines(@"WordBase.txt", Encoding.UTF8);
          
            foreach (string s in lines) {
                var parts = s.Split('|');
                if (parts.Length != 5 && parts.Length > 1) {
                    Word nop = new Word(parts[0]);
                    hash.Add(nop);
                }
                Word neu = new Word(parts[0], parts[1] == "0" ? DifficultyEnum.EASY : parts[1] == "1" ? DifficultyEnum.MEDIUM : DifficultyEnum.HARD,
                    parts[2] == "0" ? false : true, parts[3] == "0" ? false : true, parts[4] == "0" ? false : true);
                hash.Add(neu);
            }
        }
    }

}
