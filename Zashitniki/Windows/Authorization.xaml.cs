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

namespace Zashitniki.Windows
{
    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Window
    {
        public static readonly DependencyProperty PlaceholderTextProperty =
            DependencyProperty.Register("PlaceholderText", typeof(string), typeof(VeteransList), new PropertyMetadata(""));

        public string PlaceholderText
        {
            get { return (string)GetValue(PlaceholderTextProperty); }
            set { SetValue(PlaceholderTextProperty, value); }
        }
        public Authorization()
        {
            InitializeComponent();
        }
        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (TbLogin.Text == "Введите логин")
            {
                TbLogin.Text = "";
                TbLogin.Foreground = Brushes.Black; // Изменяем цвет текста на черный при фокусировке
            }
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TbLogin.Text))
            {
                TbLogin.Text = "Введите логин";
                TbLogin.Foreground = Brushes.Gray; // Возвращаем цвет текста в серый при расфокусировке, если поле пустое
            }
        }
        private void PbPassword_GotFocus(object sender, RoutedEventArgs e)
        {
            if (PbPassword.Text == "Введите пароль")
            {
                PbPassword.Text = "";
                PbPassword.Foreground = Brushes.Black;
            }    
        }

        private void PbPassword_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(PbPassword.Text)) {
                PbPassword.Text = "Введите пароль";
                PbPassword.Foreground = Brushes.Gray;
            
            }
        }
        private void BtnSignIn_Click(object sender, RoutedEventArgs e)
        {
            var userAuth = ClassHelper.EF.Context.Manager.ToList().
            Where(i => i.UserName == TbLogin.Text && i.Password == PbPassword.Text).
            FirstOrDefault();
            if (userAuth != null)
            {

                int managerID = userAuth.ID;

                Menu menuWindow = new Menu(managerID);
                menuWindow.Show();
                this.Close();
            }
            else
            {
                // если пользователь не найден
                MessageBox.Show("Введен неверный логин или пароль", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
