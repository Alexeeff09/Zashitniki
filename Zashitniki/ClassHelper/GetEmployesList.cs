using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zashitniki.DB;

namespace Zashitniki.ClassHelper
{
    internal class GetEmployesList
    {
        public List<EmployeeData> GetEmployees()
        {
            using (var dbContext = new DB.Entitiess()) // Замените YourDbContext на ваш класс контекста данных
            {
                return dbContext.Employe
                    .Include("Post") // Включаем связанные данные из таблицы Post
                    .Include("PsychologicalSupport") // Включаем связанные данные из таблицы PsychologicalSupport
                    .Include("SocialServiceVeteran") // Включаем связанные данные из таблицы SocialServiceVeteran
                    .Select(e => new EmployeeData
                    {
                        LastName = e.LastName,
                        FirstName = e.FirstName,
                        Patronymic = e.Patronymic,
                        DateOfBirthday = e.DataOfBirthday,
                        PostName = e.Post.PostName,
                        Phone = e.Phone,
                        ServiceDate = e.PsychologicalSupport.Any() ? e.PsychologicalSupport.FirstOrDefault().DateSession :
                                      e.SocialServiceVeteran.Any() ? e.SocialServiceVeteran.FirstOrDefault().DateOfProvision :
                                      (DateTime?)null
                    })
                    .ToList();
            }
        }
    }

    public class EmployeeData
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Patronymic { get; set; }
        public DateTime DateOfBirthday { get; set; }
        public string PostName { get; set; }
        public string Phone { get; set; }
        public DateTime? ServiceDate { get; set; }
    }
}







