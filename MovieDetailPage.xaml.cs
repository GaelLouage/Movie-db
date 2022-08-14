using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MovieDatabase
{
    /// <summary>
    /// Interaction logic for MovieDetailPage.xaml
    /// </summary>
    public partial class MovieDetailPage : Window
    {
        private readonly Movie _movie;
        public MovieDetailPage(Movie mv)
        {
            InitializeComponent();
            _movie = mv;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            lblTitel.Content = _movie.Title;
            imgMovie.Source = new BitmapImage(new Uri(_movie.Img, UriKind.Relative));
            txtAbout.Text = _movie.ShortAbout;
            txtReleaseDate.Text = _movie.ShortDate;
           
        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            MainWindow mw = new MainWindow();
            mw.Show();
        }
    }
}
