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
    /// Логика взаимодействия для PsychologicalService.xaml
    /// </summary>
    public partial class PsychologicalService : Window
    {
        private int managerID;
        public PsychologicalService(int managerID)
        {
            InitializeComponent();

            this.managerID = managerID;


            CmbVeteranPsycho.ItemsSource = ClassHelper.EF.Context.Veteran.ToList();
            CmbVeteranPsycho.DisplayMemberPath = "LastName";

            var employees = ClassHelper.EF.Context.Employe
                .Where(emp => emp.PostID == 2 || emp.Post.PostName == "Психолог")
                .ToList();

            CmbPsycholog.ItemsSource = employees;
            CmbPsycholog.DisplayMemberPath = "LastName";


        }

        private void BtnSavePsychologicalSeans_Click(object sender, RoutedEventArgs e)
        {
            // Проверяем, выбраны ли все необходимые значения
            if (string.IsNullOrEmpty(TbSeansName.Text) || CmbPsycholog.SelectedItem == null || CmbVeteranPsycho.SelectedItem == null || DatePickerPsychoService.SelectedDate == null)
            {
                MessageBox.Show("Пожалуйста, выберите все значения перед сохранением.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Получаем выбранные объекты из ComboBox и DatePicker
            string seansName = TbSeansName.Text;
            Employe selectedPsychologist = CmbPsycholog.SelectedItem as Employe;
            Veteran selectedVeteran = CmbVeteranPsycho.SelectedItem as Veteran;
            DateTime selectedDate = DatePickerPsychoService.SelectedDate.Value;

            try
            {
                // Создаем новую запись в таблице PsychologicalServiceVeteran с выбранными значениями
                PsychologicalSupport newRecord = new PsychologicalSupport
                {                   
                    SessionTheme = seansName,
                    EmployeID = selectedPsychologist.ID,
                    VeteranID = selectedVeteran.ID,
                    DateSession = selectedDate
                };

                // Добавляем запись в контекст базы данных
                ClassHelper.EF.Context.PsychologicalSupport.Add(newRecord);

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
