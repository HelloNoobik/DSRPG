﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DSRPGEntities : DbContext
    {
        public DSRPGEntities()
            : base("name=DSRPGEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Armors> Armors { get; set; }
        public virtual DbSet<Items> Items { get; set; }
        public virtual DbSet<ItemTypes> ItemTypes { get; set; }
        public virtual DbSet<Spells> Spells { get; set; }
        public virtual DbSet<Weapons> Weapons { get; set; }
        public virtual DbSet<Armor> Armor { get; set; }
        public virtual DbSet<Item> Item { get; set; }
        public virtual DbSet<Spell> Spell { get; set; }
        public virtual DbSet<Weapon> Weapon { get; set; }
        public virtual DbSet<Records> Records { get; set; }
        public virtual DbSet<ItemsList> ItemsList { get; set; }
        public virtual DbSet<Players> Players { get; set; }
        public virtual DbSet<ItemList> ItemList { get; set; }
        public virtual DbSet<Classes> Classes { get; set; }
        public virtual DbSet<Player> Player { get; set; }
    }
}