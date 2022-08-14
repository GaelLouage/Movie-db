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
    /// Interaction logic for RegisterForm.xaml
    /// </summary>
    public partial class RegisterForm : Window
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private async void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            if(!string.IsNullOrEmpty(txtFirstname.Text) && !string.IsNullOrEmpty(txtPassword.Password) &&
                !string.IsNullOrEmpty(txtLastName.Text))
            {
                Users usr = new Users()
                {
                    firstName = txtFirstname.Text,
                    lastName = txtLastName.Text,
                    userPassword = txtPassword.Password,
                    userRole = "User"
                };
                using(var MovieDbContext = new MovieEntities())
                {
                    MovieDbContext.Users.Add(usr);
                    await MovieDbContext.SaveChangesAsync();
                }
                MessageBox.Show("Registration succesfull");

            } else
            {
                MessageBox.Show("Not all field are filed in.", "Input fields!!!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Login lgn = new Login();
            lgn.Show();
            this.Close();
        }
    }
}
