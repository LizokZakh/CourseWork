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
    
    public partial class tickets
    {
        public int num_ticket { get; set; }
        public int id_user { get; set; }
        public int entry_id { get; set; }
        public int seat_id { get; set; }
    
        public virtual poster poster { get; set; }
        public virtual seat seat { get; set; }
        public virtual users users { get; set; }
    }
}
