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
    /// Interaction logic for UsersAdminMenu.xaml
    /// </summary>
    public partial class UsersAdminMenu : Window
    {
        private List<Users> lijstUsers = new List<Users>();

        public UsersAdminMenu()
        {
            InitializeComponent();
            UpdateCombobox();
        }

        private async void RdbAdmin_Checked(object sender, RoutedEventArgs e)
        {
            
            if(cmbUsersRoleEdit.SelectedIndex != -1)
            {
                Users rs = cmbUsersRoleEdit.SelectedValue as Users;
                using (var userDbContext = new MovieEntities())
                {
                    var q = userDbContext.Users.First(x => x.firstName == rs.firstName);
                    q.userRole = "Admin";
                    userDbContext.Entry(q).State = System.Data.Entity.EntityState.Modified;
                    await userDbContext.SaveChangesAsync();
                }
                UpdateCombobox();
            }
        }

        private async void RdbUser_Checked(object sender, RoutedEventArgs e)
        {
           
            if (cmbUsersRoleEdit.SelectedIndex != -1)
            {
                Users rs = cmbUsersRoleEdit.SelectedValue as Users;
                using (var userDbContext = new MovieEntities())
                {
                    var q = userDbContext.Users.First(x => x.firstName == rs.firstName);
                    q.userRole = "User";
                    userDbContext.Entry(q).State = System.Data.Entity.EntityState.Modified;
                    await userDbContext.SaveChangesAsync();
                }
                UpdateCombobox();
            }
        }
        private void UpdateCombobox()
        {
            using(var userDbContext = new MovieEntities())
            {
                lijstUsers = userDbContext.Users.ToList();
            }
            cmbUsersRoleEdit.ItemsSource = null;
            cmbUsersRoleEdit.ItemsSource = lijstUsers;
        }
    }
}
