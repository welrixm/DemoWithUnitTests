//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DelusTests1
{
    using System;
    using System.Collections.Generic;
    
    public partial class Shop
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Address { get; set; }
        public int AgentID { get; set; }
    
        public virtual Agent Agent { get; set; }
    }
}
