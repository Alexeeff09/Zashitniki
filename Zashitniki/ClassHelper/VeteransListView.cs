using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zashitniki.DB;

namespace Zashitniki.ClassHelper
{
    public class VeteransListView
    {
        public ObservableCollection<Veteran> Veterans { get; set; }

        public VeteransListView()
        {
            var getVeteransList = new GetVeteransList(); // Создаем экземпляр класса для получения списка ветеранов
            var veterans = getVeteransList.GetVeterans(); // Получаем список ветеранов из базы данных
            Veterans = new ObservableCollection<Veteran>(veterans);
        }
            
    }
}
