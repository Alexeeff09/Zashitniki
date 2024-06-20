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
using Zashitniki.ClassHelper;
using Zashitniki.DB;

namespace Zashitniki.Windows
{
    /// <summary>
    /// Логика взаимодействия для EmployessList.xaml
    /// </summary>
    public partial class EmployessList : Window
    {
        private int managerID;
        public EmployessList(int managerID)
        {
            InitializeComponent();
            this.managerID = managerID;
            var employeesListView = new EmployyesListView();
            DataContext = employeesListView;

        }
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Menu mainWindow = new Menu(managerID);
            mainWindow.Show();
            this.Close();
        }
    }
}
