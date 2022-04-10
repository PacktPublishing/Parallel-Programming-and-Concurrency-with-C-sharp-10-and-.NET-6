using System.Windows;

namespace ProducerConsumerRssFeeds
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }

        private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            FeedAggregator aggregator = new();
            var items = await aggregator.GetAllMicrosoftBlogPosts();
            mainListView.ItemsSource = items;
        }
    }
}