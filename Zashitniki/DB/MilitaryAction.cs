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
    
    public partial class MilitaryAction
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MilitaryAction()
        {
            this.MilitaryActionMember = new HashSet<MilitaryActionMember>();
        }
    
        public int ID { get; set; }
        public string Title { get; set; }
        public string YearStart { get; set; }
        public string YearEnd { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MilitaryActionMember> MilitaryActionMember { get; set; }
    }
}
