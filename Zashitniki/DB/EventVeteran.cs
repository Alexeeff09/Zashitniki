//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Zashitniki.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class EventVeteran
    {
        public int VeteranID { get; set; }
        public int EventID { get; set; }
        public int EmployeID { get; set; }
        public Nullable<System.DateTime> DateOfEvent { get; set; }
    
        public virtual Employe Employe { get; set; }
        public virtual Event Event { get; set; }
        public virtual Veteran Veteran { get; set; }
    }
}
