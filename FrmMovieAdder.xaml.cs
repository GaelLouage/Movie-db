using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
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
    /// Interaction logic for FrmMovieAdder.xaml
    /// </summary>
    public partial class FrmMovieAdder : Window
    {
        private List<Movie> _movieList = null;
        private Movie _movie = null;
        private string _movieTitle;
        public FrmMovieAdder(List<Movie> movieList)
        {
            InitializeComponent();
            _movieList = movieList;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateMovieList();
        }
        // go back to menu
        private void btnMenu_Click(object sender, RoutedEventArgs e)
        {
           
            MainWindow mw = new MainWindow(MainWindow._user);
            mw.Show();
            this.Hide();
        }

        private async void btnAddMovie_Click(object sender, RoutedEventArgs e)
        {
            if(!string.IsNullOrEmpty(txtTitle.Text)  &&
               !string.IsNullOrEmpty(txtAbout.Text) && 
               !string.IsNullOrEmpty(txtGenre.Text) &&
               !string.IsNullOrEmpty(txtImg.Text))
            {
                int moviesCount = _movieList.Count;
                if (dPReleasedate.SelectedDate.Value != null)
                {
                    Movie mv = new Movie
                    {
                        Title = txtTitle.Text,
                        ReleaseDate = dPReleasedate.SelectedDate.Value,
                        About = txtAbout.Text,
                        Genre = txtGenre.Text,
                        Img = txtImg.Text
                    };
                    using (var movieWorldDBEntities = new MovieEntities())
                    {
                        movieWorldDBEntities.Movie.Add(mv);
                        await movieWorldDBEntities.SaveChangesAsync();
                        if (moviesCount + 1 == movieWorldDBEntities.Movie.ToList().Count)
                        {
                            MessageBox.Show("Movie succesfully added");
                        }
                    }
                    UpdateMovieList();
                }
            } else
            {
                MessageBox.Show("Not all text fields are filled in!", "Info", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if(cmbDeleteMovies.SelectedIndex != -1)
            {
                Movie movie = cmbDeleteMovies.SelectedItem as Movie;

                using (var movieWorldDBEntities = new MovieEntities())
                {
                    var q = movieWorldDBEntities.Movie.FirstOrDefault(x => x.Title == movie.Title);
                    movieWorldDBEntities.Movie.Remove(q);
                    movieWorldDBEntities.SaveChanges();
                }
                UpdateMovieList();
            }
            else
            {
                MessageBox.Show("Select a movie pls.", "Info", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private async void btnEditMovie_Click(object sender, RoutedEventArgs e)
        {
            if(cmbEditMovies.SelectedIndex != -1)
            {
                if (!string.IsNullOrEmpty(txtTitleEdit.Text) &&
              !string.IsNullOrEmpty(txtAboutEdit.Text) &&
              !string.IsNullOrEmpty(txtGenreEdit.Text) &&
              !string.IsNullOrEmpty(txtImgEdit.Text))
                {
                    UpdateMovieList();
                    if(dPReleasedateEdit.SelectedDate.Value != null)
                    {
                        using (var movieWorldBEntitites = new  MovieEntities())
                        {
                            var q = movieWorldBEntitites.Movie.First(x => x.Title == _movieTitle);
                            q.Title = txtTitleEdit.Text;
                            q.About = txtAboutEdit.Text;
                            q.Genre = txtGenreEdit.Text;
                            q.Img = txtImgEdit.Text;
                            q.ReleaseDate = dPReleasedateEdit.SelectedDate.Value;
                            if (q != null)
                            {
                                movieWorldBEntitites.Entry(q).State = System.Data.Entity.EntityState.Modified;
                                await movieWorldBEntitites.SaveChangesAsync();
                            }
                        }
                        UpdateMovieList();
                      
                    } else
                    {
                        MessageBox.Show("Change date pls.", "Info", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show("Not all text fields are filled in!", "Info", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
            } else
            {
                MessageBox.Show("Select a movie pls.", "Info", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void cmbEditMovies_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

                _movie = cmbEditMovies.SelectedItem as Movie;
                if(_movie != null)
                {
                     _movieTitle = _movie.Title;
                    txtTitleEdit.Text = _movie.Title;
                    txtImgEdit.Text = _movie.Img;
                    txtAboutEdit.Text = _movie.About;
                    txtGenreEdit.Text = _movie.Genre;
                    dPReleasedateEdit.SelectedDate = _movie.ReleaseDate;
                }
        }
        private void UpdateMovieList()
        {
            using (var movieWorldDBEntities = new MovieEntities())
            {
              
                    _movieList = movieWorldDBEntities.Movie.ToList();
                    cmbDeleteMovies.ItemsSource = null;
                    cmbDeleteMovies.ItemsSource = _movieList;

                    cmbEditMovies.ItemsSource = null;
                    cmbEditMovies.ItemsSource = _movieList;
            }
        }
        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSearch.Text))
            {
                using(var movieWorldDBEntities = new MovieEntities())
                 {

                    _movieList = movieWorldDBEntities.Movie.Where(x => x.Title.Contains(txtSearch.Text)).ToList();
                    cmbDeleteMovies.ItemsSource = null;
                    cmbDeleteMovies.ItemsSource = _movieList;

                    cmbEditMovies.ItemsSource = null;
                    cmbEditMovies.ItemsSource = _movieList;
                }
            } else
            {
                using (var movieWorldDBEntities = new MovieEntities())
                {

                    _movieList = movieWorldDBEntities.Movie.ToList();
                    cmbDeleteMovies.ItemsSource = null;
                    cmbDeleteMovies.ItemsSource = _movieList;

                    cmbEditMovies.ItemsSource = null;
                    cmbEditMovies.ItemsSource = _movieList;
                }
            }
        }
    }
}
