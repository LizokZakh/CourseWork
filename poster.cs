//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CourseWork
{
    using System;
    using System.Collections.Generic;
    
    public partial class poster
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public poster()
        {
            this.tickets = new HashSet<tickets>();
        }
    
        public int entry_id { get; set; }
        public int spectacle_id { get; set; }
        public int hall_id { get; set; }
        public System.DateTime date { get; set; }
        public Nullable<System.TimeSpan> time { get; set; }
    
        public virtual hall hall { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tickets> tickets { get; set; }
        public virtual repertoire repertoire { get; set; }
    }
}
