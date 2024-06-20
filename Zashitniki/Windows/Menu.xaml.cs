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
    /// Логика взаимодействия для Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        private int managerID;

        public Menu(int managerID)
        {
            InitializeComponent();
            this.managerID = managerID;
        }
        private void BtnVeteransList_Click(object sender, RoutedEventArgs e)
        {
            // Открыть окно со списком ветеранов
            VeteransList veteransList = new VeteransList(managerID);
            veteransList.Show();
            this.Close();
        }

        private void BtnEmployeesList_Click(object sender, RoutedEventArgs e)
        {
            // Открыть окно со списком сотрудников
            EmployessList employeesList = new EmployessList(managerID);
            employeesList.Show();
            this.Close();
        }

        private void BtnSupportRegistration_Click(object sender, RoutedEventArgs e)
        {
            // Открыть окно для записи на услугу
            ServiceMenu serviceMenu = new ServiceMenu(managerID);
            serviceMenu.Show();
            this.Close();
        }
    }
}
