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
using Zashitniki.DB;

namespace Zashitniki.Windows
{
    /// <summary>
    /// Логика взаимодействия для SocialServiceReg.xaml
    /// </summary>
    public partial class SocialServiceReg : Window
    {
        private int managerID;

        public SocialServiceReg(int managerID)
        {
            InitializeComponent();

            CmbTitleService.ItemsSource = ClassHelper.EF.Context.SocialService.ToList();
            CmbTitleService.DisplayMemberPath = "TitleService";



            var employees = ClassHelper.EF.Context.Employe
    .Where(emp => emp.PostID == 3 || emp.Post.PostName == "Работник")
    .ToList();

            CmbEmploye.ItemsSource = employees;
            CmbEmploye.DisplayMemberPath = "LastName";

            CmbVeteran.ItemsSource = ClassHelper.EF.Context.Veteran.ToList();
            CmbVeteran.DisplayMemberPath = "LastName";
            this.managerID = managerID;
        }

        public int ID { get; private set; }

        private void BtnSaveSocialService_Click(object sender, RoutedEventArgs e)
        {
            // Проверяем, выбраны ли все необходимые значения
            if (CmbTitleService.SelectedItem == null || CmbEmploye.SelectedItem == null || CmbVeteran.SelectedItem == null || DatePickerService.SelectedDate == null)
            {
                MessageBox.Show("Пожалуйста, выберите все значения перед сохранением.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Получаем выбранные объекты из ComboBox и DatePicker
            SocialService selectedService = CmbTitleService.SelectedItem as SocialService;
            Employe selectedEmployee = CmbEmploye.SelectedItem as Employe;
            Veteran selectedVeteran = CmbVeteran.SelectedItem as Veteran;
            DateTime selectedDate = DatePickerService.SelectedDate.Value;

            try
            {
                // Создаем новую запись в таблице SocialServiceVeteran с выбранными значениями
                SocialServiceVeteran newRecord = new SocialServiceVeteran
                {
                    SocialServiceID = selectedService.ID,
                    EmployeID = selectedEmployee.ID,
                    VeteranID = selectedVeteran.ID,
                    DateOfProvision = selectedDate
                };

                // Добавляем запись в контекст базы данных
                ClassHelper.EF.Context.SocialServiceVeteran.Add(newRecord);

                // Сохраняем изменения в базе данных
                ClassHelper.EF.Context.SaveChanges();

                MessageBox.Show("Данные успешно сохранены.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при сохранении данных: " + ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }


        private void BackToServiceMenu_Click(object sender, RoutedEventArgs e)
        {
            ServiceMenu serviceMenu = new ServiceMenu(managerID);
            serviceMenu.Show();
            this.Close();
        }
    }
}







