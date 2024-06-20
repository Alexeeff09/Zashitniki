using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Zashitniki.ClassHelper
{
    internal class EF
    {

        public static DB.Entitiess Context { get; } = new DB.Entitiess();
        public static Frame frame;
    }
}
