﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Hotel
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class HotelEntities : DbContext
    {
        private static HotelEntities _context;

        public HotelEntities()
            : base("name=Hotel_altEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }

        public static HotelEntities GetContext()
        {
            if (_context == null)
            {
                _context = new HotelEntities();
            }
            return _context;
        }

        public virtual DbSet<Заявки> Заявки { get; set; }
        public virtual DbSet<Клиенты> Клиенты { get; set; }
        public virtual DbSet<Отель> Отель { get; set; }
        public virtual DbSet<Отзывы> Отзывы { get; set; }
        public virtual DbSet<Пользователи> Пользователи { get; set; }
        public virtual DbSet<Роли> Роли { get; set; }
        public virtual DbSet<Страны> Страны { get; set; }
        public virtual DbSet<ТипыТуров> ТипыТуров { get; set; }
        public virtual DbSet<Туры> Туры { get; set; }
    }
}
