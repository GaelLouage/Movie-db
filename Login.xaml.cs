using System;
using System.Linq;
using System.Windows;

namespace MovieDatabase
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public static bool connected = false;
        public Login()
        {
            InitializeComponent();
        }
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtUserName.Text) && !string.IsNullOrEmpty(txtPassword.Password))
            {
                using (var db = new MovieEntities())
                {
                    var user = db.Users.FirstOrDefault(x => x.firstName == txtUserName.Text);
                    if (user != null)
                    {
                        if (txtUserName.Text == user.firstName && txtPassword.Password == user.userPassword)
                        {
 
                            connected = true;

                            MainWindow mrn = new MainWindow(user);
                            mrn.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Wrong username or password");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Wrong username or password");
                    }
                }
            }
            else
            {
                MessageBox.Show("Fields are empty.");
            }

        }
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void TextBlock_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            RegisterForm rgf = new RegisterForm();
            rgf.Show();
            this.Hide();
        }
    }


}