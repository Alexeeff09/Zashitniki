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
    
    public partial class AwardVeteran
    {
        public int VeteranID { get; set; }
        public int AwardID { get; set; }
        public System.DateTime DateOfDelivery { get; set; }
    
        public virtual Award Award { get; set; }
        public virtual Veteran Veteran { get; set; }
    }
}
