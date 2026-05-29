using System;
using System.Collections.Generic;
using System.Data.Entity;
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

namespace WpfApp111
{
    /// <summary>
    /// Логика взаимодействия для EditUser.xaml
    /// </summary>
    public partial class EditUser : Window
    {
        DemoTestEntities db = new DemoTestEntities();
        public EditUser(Users user)
        {
            InitializeComponent();
            this.user = user;
            db.Role.Load();
            cbRoles.ItemsSource = db.Role.Local;
            cbRoles.DisplayMemberPath = "RoleName";
            cbRoles.SelectedValuePath = "Id";
            tbLogin.Text = user.Login.Trim();
            tbPassword.Text = user.Password.Trim();
            cbRoles.Text = db.Role.Find(user.RoleID).RoleName;
            ckBan.IsChecked = user.Blocked;
        }

        public Users user { get; private set; }
        public object[] UserID { get; private set; }

        private void Button_AddClick(object sender, RoutedEventArgs e)
        {
            Users updatedUser = db.Users.Find(UserID);
            EditSelectedUser(updatedUser);
            db.SaveChanges();
        }
        private void EditSelectedUser(Users updatedUser)
        {
            updatedUser.Login = tbLogin.Text;
            updatedUser.Password = tbPassword.Text;
            updatedUser.RoleID = Convert.ToInt32(cbRoles.SelectedValue);
            updatedUser.Blocked = ckBan.IsChecked;

            db.SaveChanges();
            StaticObject.dataGrid.ItemsSource = db.Users.ToList();
            this.Close();
        }
    }
}
