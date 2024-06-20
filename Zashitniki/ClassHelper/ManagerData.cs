using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zashitniki.ClassHelper
{
    internal class ManagerData
    {
        public static DB.Manager manager { get; set; } = new DB.Manager();
        public static DB.SocialService socialService { get; set; } = new DB.SocialService();
        public static DB.Employe employe { get; set;} = new DB.Employe();
        public static DB.PsychologicalSupport psychologicalSupport { get; set;} =new DB.PsychologicalSupport();


    }
}
