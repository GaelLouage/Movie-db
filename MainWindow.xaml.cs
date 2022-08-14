using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace MovieDatabase
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Movie> lijstMovies = null;
        private DispatcherTimer dispatcherTimer;
        public static Users _user = new Users();
        private int counter = 0;
        private string[] imgheader = { "Images/jurassicWorld.jpg", "Images/thbatman.jpg", "Images/red2.png", "Images/matrix.png" };
        public MainWindow(Users user)
        {
            InitializeComponent();

            if (Login.connected)
            {
                _user = user;
                this.Show();
            }
            else
            {
                Login lg = new Login();
                lg.Show();
                this.Hide();
            }
        }
        public MainWindow()
        {
            InitializeComponent();
            if (Login.connected)
            {
                this.Show();
            }
            else
            {
                Login lg = new Login();
                lg.Show();
                this.Hide();
            }
        }
        // admin menu
        private void BtnAdminMenu_Click(object sender, RoutedEventArgs e)
        {
            FrmMovieAdder frmMovie = new FrmMovieAdder(lijstMovies);
            frmMovie.Show();
            this.Hide();
        }
        private void BtnAdminMenuUsers_Click(object sender, RoutedEventArgs e)
        {
            UsersAdminMenu uadm = new UsersAdminMenu();
            uadm.Show();
            this.Close();
        }
        private void btnDropDownTwo_Loaded(object sender, RoutedEventArgs e)
        {
            // custom button on user when user is admin
            if(_user.userRole == "Admin")
            {
                Button btn = new Button();
                btn.Name = "btnAdminMenuTester";
                btn.Content = "Admin menu";
                btn.Click += BtnAdminMenu_Click;
                btn.Height = 50;
                btn.BorderBrush = Brushes.White;
                btn.Background = Brushes.Green;
                stckDropDownMenuHeader.Children.Add(btn);
                // btn users
                Button btnUsers = new Button();
                btnUsers.Name = "btnShowUsers";
                btnUsers.Content = "Users";
                btnUsers.Click += BtnAdminMenuUsers_Click;
                btnUsers.Height = 50;
                btnUsers.BorderBrush = Brushes.White;
                btnUsers.Background = Brushes.Green;
                stckDropDownMenuHeader.Children.Add(btnUsers);
            }
           
            stckDropDownMenuHeader.Visibility = Visibility.Hidden;
            dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, minutes: 0, 1);
            dispatcherTimer.Start();
            using (var movieWorldDBEntities = new MovieEntities())
            {
                lijstMovies = movieWorldDBEntities.Movie.ToList();
            }
            lbMovies.ItemsSource = null;
            lbMovies.ItemsSource = lijstMovies;

            lblUser.Content = "Welkom "+_user.firstName;
            // combobox sort
            cmbSort.Items.Add("Titel A-Z");
            cmbSort.Items.Add("Titel Z-A");
            cmbSort.Items.Add("Releasedate");
        }
        // menu button
        private void btnMenu_Click(object sender, RoutedEventArgs e)
        {
            stckDropDownMenuHeader.Visibility = Visibility.Visible;
        }
        // timer event one
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
          
            counter++;
           
            string theHeaderImage = imgHeader.Source.ToString().Split('/')[imgHeader.Source.ToString().Split('/').Length-1];
            if(counter == 3)
            {
                counter = 0;
                theHeaderImage = theHeaderImage.Replace(" ", "");
                switch(theHeaderImage)
                {
                    case "jurassicWorld.jpg":
                        imgHeader.Source = new BitmapImage(new Uri(imgheader[1], UriKind.Relative));
                        lbHeaderTitle.Content = "The Batman";
                        lbHeaderText.Content = "Batman finds himself in the underworld of Gotham City when \n a sadistic killer leaves a trail of cryptic clues.";
                        break;
                    case "thbatman.jpg":
                        imgHeader.Source = new BitmapImage(new Uri(imgheader[2], UriKind.Relative));
                        lbHeaderTitle.Content = "Red 2";
                        lbHeaderText.Content = "Ex-CIA agent Frank Moses and his crew return for another high-stakes mission, \n scouring the globe for a missing nuclear device.";
                        break;
                    case "red2.png":
                        imgHeader.Source = new BitmapImage(new Uri(imgheader[3], UriKind.Relative));
                        lbHeaderTitle.Content = "The Matrix";
                        lbHeaderText.Content = "Computerhacker Thomas A. Anderson komt op een vreemde manier in contact met Morpheus.";
                        break;
                    case "matrix.png":
                        imgHeader.Source = new BitmapImage(new Uri(imgheader[0], UriKind.Relative));
                        lbHeaderTitle.Content = "Jurassic World";
                        lbHeaderText.Content = "Isla Nublar and its park have been destroyed, but the trouble is not over.";
                        break;
                }
            }
        }
        private void btnDropDownO_Click(object sender, RoutedEventArgs e)
        {
            stckDropDownMenuHeader.Visibility = Visibility.Collapsed;
        }
        // bullets on click
        private void Ellipse_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            dispatcherTimer.Stop();
            imgHeader.Source = new BitmapImage(new Uri(imgheader[0], UriKind.Relative));
            lbHeaderTitle.Content = "Jurassic World";
            lbHeaderText.Content = "Isla Nublar and its park have been destroyed, but the trouble is not over.";
        }

        private void Ellipse_MouseLeftButtonUp_1(object sender, MouseButtonEventArgs e)
        {
            dispatcherTimer.Stop();
            imgHeader.Source = new BitmapImage(new Uri(imgheader[1], UriKind.Relative));
            lbHeaderTitle.Content = "The Batman";
            lbHeaderText.Content = "Batman finds himself in the underworld of Gotham City when \n a sadistic killer leaves a trail of cryptic clues.";
        }

        private void Ellipse_MouseLeftButtonUp_2(object sender, MouseButtonEventArgs e)
        {
            dispatcherTimer.Stop();
            imgHeader.Source = new BitmapImage(new Uri(imgheader[2], UriKind.Relative));
            lbHeaderTitle.Content = "Red 2";
            lbHeaderText.Content = "Ex-CIA agent Frank Moses and his crew return for another high-stakes mission, \n scouring the globe for a missing nuclear device.";
        }
        private void Ellipse_MouseLeftButtonUp_3(object sender, MouseButtonEventArgs e)
        {
            dispatcherTimer.Stop();
            imgHeader.Source = new BitmapImage(new Uri(imgheader[3], UriKind.Relative));
            lbHeaderTitle.Content = "Matrix";
            lbHeaderText.Content = "Computerhacker Thomas A.Anderson komt op een vreemde manier in contact met Morpheus.";
        }
        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSearch.Text))
            {
                lijstMovies = lijstMovies.Where(x => x.Title.ToLower().Contains(txtSearch.Text)).ToList();
                lbMovies.ItemsSource = null;
                lbMovies.ItemsSource = lijstMovies;
            }
            else 
            {
                using (var movieWorldDBEntities = new MovieEntities())
                {
                    lijstMovies = movieWorldDBEntities.Movie.ToList();
                }
                lbMovies.ItemsSource = null;
                lbMovies.ItemsSource = lijstMovies;
            }
        }


        private void lbMovies_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Movie mv = lbMovies.SelectedItem as Movie;
            MovieDetailPage movieD = new MovieDetailPage(mv);
            movieD.Show();
            this.Hide();

        }
        private void cmbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            switch (cmbSort.SelectedValue)
            {
                case "Titel A-Z":
                    lijstMovies = lijstMovies.OrderBy(x => x.Title).ToList();
                    break;
                case "Titel Z-A":
                    lijstMovies = lijstMovies.OrderByDescending(x => x.Title).ToList();
                    break;
                case "Releasedate":
                    lijstMovies = lijstMovies.OrderBy(x => x.ReleaseDate).ToList();
                    break;
                default:
                  
                    break;
            }
            lbMovies.ItemsSource = null;
            lbMovies.ItemsSource = lijstMovies;
        }
    }
}
