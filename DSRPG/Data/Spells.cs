//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DSRPG.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Spells
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public int ManaCost { get; set; }
    
        public virtual Items Items { get; set; }
    }
}
