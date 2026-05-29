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
    /// Логика взаимодействия для AddUser.xaml
    /// </summary>
    public partial class AddUser : Window
    {
        DemoTestEntities db = new DemoTestEntities();
        public AddUser()
        {
            InitializeComponent();
            db.Role.Load();
            cbRoles.ItemsSource = db.Role.Local;
            cbRoles.DisplayMemberPath = "RoleName";
            cbRoles.SelectedValuePath = "Id";
        }

        private void Button_AddClick(object sender, RoutedEventArgs e)
        {
            db.Users.Add(new Users
            {
                Login = tbLogin.Text,
                Password = tbPassword.Text,
                RoleID = Convert.ToInt32(cbRoles.SelectedValue),
                Blocked = ckBan.IsChecked
            });
            db.SaveChanges();
            MessageBox.Show("Сохранилось");
            StaticObject.dataGrid.ItemsSource = db.Users.ToList();
            this.Close();
        }
    }
}
