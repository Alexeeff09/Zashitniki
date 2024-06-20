using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zashitniki.ClassHelper
{
    public class EmployyesListView
    {
        public ObservableCollection<EmployeeData> Employees { get; set; }

        public EmployyesListView()
        {
            var getEmployeesList = new GetEmployesList();
            var employeesWithServices = getEmployeesList.GetEmployees();
            Employees = new ObservableCollection<EmployeeData>(employeesWithServices);
        }
    }
}
