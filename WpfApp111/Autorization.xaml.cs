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

namespace WpfApp111
{
    /// <summary>
    /// Логика взаимодействия для Autorization.xaml
    /// </summary>
    public partial class Autorization : Window
    {

        Image image;
        Border border;
        bool match1 = false;
        bool match2 = false;
        bool match3 = false;
        bool match4 = false;
        public Autorization()
        {
            InitializeComponent();
        }
        private void Border_DragEnter(object sender, DragEventArgs e)
        {
            border = (Border)sender;
            border.Background = Brushes.Yellow;
        }
        private void Border_DragLeave(object sender, DragEventArgs e)
        {
            border = (Border)sender;
            border.Background = Brushes.LightGray;
            e.Effects = DragDropEffects.Move;
        }
        private void Border_Drop(object sender, DragEventArgs e)
        {
            border = (Border)sender;
            border.Background = Brushes.Green;
            image.Margin = border.Margin;
            if (image.Tag.ToString() == border.Tag.ToString())
            {
                if (image.Tag.ToString() == "1")
                    match1 = true;
                if (image.Tag.ToString() == "2")
                    match2 = true;
                if (image.Tag.ToString() == "3")
                    match3 = true;
                if (image.Tag.ToString() == "4")
                    match4 = true;
            }
        }
        private void MouseMove_Click(object sender, MouseEventArgs e)
        {
            image = (Image)sender;
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragDrop.DoDragDrop(image, image, DragDropEffects.Move);
            }
        }
        private bool CheckCapcha()
        {
            return match1 && match2 && match3 && match4;
        }
        private void ResetCapcha()
        {
            Image1.Margin = new Thickness(459, 233, 0, 0);
            Image2.Margin = new Thickness(424, 233, 0, 0);
            Image3.Margin = new Thickness(349, 247, 0, 0);
            Image4.Margin = new Thickness(312, 247, 0, 0);
            match1 = false;
            match2 = false;
            match3 = false;
            match4 = false;
            if (border != null)
                border.Background = Brushes.LightGray;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            {
                DemoTestEntities db = new DemoTestEntities();
                string login = TbLogin.Text;
                string password = TbPass.Text;
                Users user = db.Users.FirstOrDefault(u => u.Login == login && u.Password == password);
                StaticObject.user = user;
                if (user.Password.Trim() == TbPass.Text)
                {
                    MessageBox.Show("Вы успешно авторизовались");
                    StaticObject.user = user;
                    if (user.RoleID == 1)
                    {
                        StaticObject.DesktopFrame.Navigate(new AdminPage());
                        this.Close();
                    }
                    else if (user.RoleID == 2)
                    {
                        StaticObject.DesktopFrame.Navigate(new UserPage());
                        this.Close();
                    }
                }

            }
        }
    }
}

