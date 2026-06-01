using System;
using System.Collections.Generic;
using System.Data.Entity;
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

namespace WpfApp111
{
    /// <summary>
    /// Логика взаимодействия для EditUser.xaml
    /// </summary>
    public partial class EditUser : Window
    {
        public Users editingUser;
        DemoTestEntities1 db = new DemoTestEntities1();
        public EditUser(Users user)
        {
            InitializeComponent();
            editingUser = user;
            this.user = user;
            db.Role.Load();
            cbRoles.ItemsSource = db.Role.Local;
            cbRoles.DisplayMemberPath = "RoleName";
            cbRoles.SelectedValuePath = "RoleId";
            tbLogin.Text = user.Login?.Trim();
            tbPassword.Text = user.Password?.Trim();
            
            cbRoles.Text = db.Role.Find(user.RoleID).RoleName;
            ckBan.IsChecked = user.Blocked;
        }

        public Users user { get; private set; }
        public object[] UserID { get; private set; }

        private void Button_AddClick(object sender, RoutedEventArgs e)
        {
            editingUser.Login = tbLogin.Text;
            editingUser.Password = tbPassword.Text;
            editingUser.RoleID = Convert.ToInt32(cbRoles.SelectedValue);
            editingUser.Blocked = ckBan.IsChecked;
            db.SaveChanges();
            StaticObject.dataGrid.ItemsSource = db.Users.ToList();
            this.Close();
        }
      
        }
           
        }
    

