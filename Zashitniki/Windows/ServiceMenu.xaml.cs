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
    /// Логика взаимодействия для ServiceMenu.xaml
    /// </summary>
    public partial class ServiceMenu : Window
    {
        private int managerID;

        public ServiceMenu(int managerID)
        {
            InitializeComponent();
            this.managerID = managerID;
        }
        private void BtnSocialService_Click(object sender, RoutedEventArgs e)
        {
            // Открыть окно со списком ветеранов
            SocialServiceReg socialService = new SocialServiceReg(managerID);
            socialService.Show();
            this.Close();
        }

        private void BtnToRegPsychologicalService_Click(object sender, RoutedEventArgs e)
        {
            // Открыть окно со списком сотрудников
            PsychologicalService psychologicalService = new PsychologicalService(managerID);
            psychologicalService.Show();
            this.Close();
        }

        private void BtnRegToEvent_Click(object sender, RoutedEventArgs e)
        {
            // Открыть окно для записи на услугу           
            EventService eventService = new EventService(managerID);
            eventService.Show();
            this.Close();
        }
        private void BtnBackToMenu_Click(object sender, RoutedEventArgs e)
        {
            Menu menu = new Menu(managerID);
            menu.Show();
            this.Close();
        }
    }
}
