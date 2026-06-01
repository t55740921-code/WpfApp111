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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp111
{
    /// <summary>
    /// Логика взаимодействия для AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        DemoTestEntities1 db = new DemoTestEntities1();
        public AdminPage()
        {
            InitializeComponent();
            StaticObject.dataGrid = DtGrid;
            StaticObject.dataGrid.ItemsSource = db.Users.ToList();
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new AddUser().ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Users user = DtGrid.SelectedItem as Users;
            if (user != null)
            {
                EditUser editUser = new EditUser(user);
                editUser.ShowDialog();
            }
            else
            {
                MessageBox.Show("Пользователь не выбран");
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Users user = DtGrid.SelectedItem as Users;
            if(MessageBox.Show("Удалить?", "Удаление", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Users users = db.Users.Remove(user);
                db.SaveChanges();
                StaticObject.dataGrid.ItemsSource = db.Users.ToList();
            }
        }
    }
}
