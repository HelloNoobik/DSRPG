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
    
    public partial class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Class { get; set; }
        public int Strength { get; set; }
        public int Agility { get; set; }
        public int Stamina { get; set; }
        public int Intellect { get; set; }
        public int Souls { get; set; }
        public int Position { get; set; }
        public int EstusCount { get; set; }
    }
}