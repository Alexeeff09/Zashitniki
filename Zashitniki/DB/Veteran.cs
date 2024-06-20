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
    
    public partial class Veteran
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Veteran()
        {
            this.AwardVeteran = new HashSet<AwardVeteran>();
            this.EventVeteran = new HashSet<EventVeteran>();
            this.MilitaryActionMember = new HashSet<MilitaryActionMember>();
            this.PsychologicalSupport = new HashSet<PsychologicalSupport>();
            this.SocialServiceVeteran = new HashSet<SocialServiceVeteran>();
        }
    
        public int ID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Patronymic { get; set; }
        public System.DateTime DataOfBirthday { get; set; }
        public string Phone { get; set; }
        public string Adress { get; set; }
        public int MilitaryRankID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AwardVeteran> AwardVeteran { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EventVeteran> EventVeteran { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MilitaryActionMember> MilitaryActionMember { get; set; }
        public virtual MilitaryRank MilitaryRank { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PsychologicalSupport> PsychologicalSupport { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SocialServiceVeteran> SocialServiceVeteran { get; set; }
    }
}
