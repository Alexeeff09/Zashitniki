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
    /// Логика взаимодействия для EventService.xaml
    /// </summary>
    public partial class EventService : Window
    {
        private int managerID;

        public EventService(int managerID)
        {
            InitializeComponent();

            this.managerID = managerID;
        
            CmbTitleEvent.ItemsSource = ClassHelper.EF.Context.Event.ToList();
            CmbTitleEvent.DisplayMemberPath = "Title";


            CmbVeteranEvent.ItemsSource = ClassHelper.EF.Context.Veteran.ToList();
            CmbVeteranEvent.DisplayMemberPath = "LastName";
        }

        public int ID { get; private set; }

        private void BtnSaveEvent_Click(object sender, RoutedEventArgs e)
        {
            // Проверяем, выбраны ли все необходимые значения
            if (CmbTitleEvent.SelectedItem == null ||   CmbVeteranEvent.SelectedItem == null || DatePickerEvent.SelectedDate == null)
            {
                MessageBox.Show("Пожалуйста, выберите все значения перед сохранением.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Получаем выбранные объекты из ComboBox и DatePicker
            
            Event selectedEvent = CmbTitleEvent.SelectedItem as Event;
            Veteran selectedVeteran = CmbVeteranEvent.SelectedItem as Veteran;
            DateTime selectedDate = DatePickerEvent.SelectedDate.Value;

            try
            {
                // Создаем новую запись в таблице SocialServiceVeteran с выбранными значениями
                EventVeteran newRecord = new EventVeteran
                {
                    EventID = selectedEvent.ID,
                    EmployeID = managerID,
                    VeteranID = selectedVeteran.ID,
                    DateOfEvent = selectedDate
                };

                // Добавляем запись в контекст базы данных
                ClassHelper.EF.Context.EventVeteran.Add(newRecord);

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

