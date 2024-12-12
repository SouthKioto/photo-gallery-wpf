using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp1.Classes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        protected string file_path = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "data.txt");
        protected List<PhotoData> photos;

        public MainWindow()
        {
            InitializeComponent();

            //MessageBox.Show(file_path);

            photos = PhotoDataHandlers.GetDataFromTextFile(file_path);
            photos_listView.ItemsSource = photos;
        }

        private void DisplayDetails(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var photoData = button.CommandParameter as PhotoData;

            if(photoData != null)
            {
                MessageBox.Show($"Tytuł: {photoData.Photo_Title}\nOpis: {photoData.Photo_Description}\nData Utworzenia: {photoData.Photo_ReleaseData}", "Photo Details", MessageBoxButton.OK);
            }
        }
    }
}