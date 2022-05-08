using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ParallelExtras.BlockingCollection
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async Task<List<string>> GetWordsByLetter(char letter)
        {
            BlockingCollection<string> lines = await LoadBookLinesFromFile();
            BlockingCollection<string> words = GetWords(lines);

            // 275,506 words in total
            return words.GetConsumingPartitioner().AsParallel()
                .Where(w => w.StartsWith(letter) || w.StartsWith(char.ToLower(letter)))
                .ToList();
        }

        private async Task<BlockingCollection<string>> LoadBookLinesFromFile()
        {
            var lines = new BlockingCollection<string>();
            using var reader = File.OpenText(Path.Combine(
                Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "ulysses.txt"));

            string line;
            while ((line = await reader.ReadLineAsync()) != null)
            {
                lines.Add(line);
            }

            lines.CompleteAdding();
            return lines;
        }

        private BlockingCollection<string> GetWords(BlockingCollection<string> lines)
        {
            var words = new BlockingCollection<string>();

            Parallel.ForEach(lines.GetConsumingPartitioner(), (line) =>
            {
                var matches = Regex.Matches(line, @"\b[\w']*\b");
                foreach (var m in matches.Cast<Match>())
                {
                    if (!string.IsNullOrEmpty(m.Value))
                    {
                        words.TryAdd(TrimSuffix(m.Value, '\''));
                    }
                }
            });

            words.CompleteAdding();
            return words;
        }

        private string TrimSuffix(string word, char charToTrim)
        {
            int charLocation = word.IndexOf(charToTrim);
            if (charLocation != -1)
            {
                word = word[..charLocation];
            }
            return word;
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            if (LettersComboBox.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a letter.");
                return;
            }

            WordsListView.ItemsSource = await GetWordsByLetter(
                char.Parse(GetComboBoxValue(LettersComboBox.SelectedValue)));
        }

        private string GetComboBoxValue(object item)
        {
            var comboxItem = item as ComboBoxItem;
            return comboxItem.Content.ToString();
        }
    }
}
