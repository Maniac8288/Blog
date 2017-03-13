using DataModel;
using DataModel.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.SqlServer;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// The DataModel namespace.
/// </summary>
namespace DataModel
{
    /// <summary>
    /// Клас DataContext обрабатывает подключение к базе данных.
    /// </summary>
    /// <seealso cref="System.Data.Entity.DbContext" />
    public class DataContext:DbContext
    {
        /// <summary>
        /// Обрабатывает подключение к базе данных
        /// </summary>
        public DataContext() 
        : base("DefaultConnection")
    { }

        /// <summary>
        /// Таблица с пользователями
        /// </summary>
        /// <value>Пользователи.</value>
        public DbSet<User> Users { get; set; }
        /// <summary>
        /// Таблица с потверждением почты.
        /// </summary>
        /// <value>потверждение почты.</value>
        public DbSet<CheckEmail> ChecksEmail{get;set;}
        /// <summary>
        /// Таблица с ролями.
        /// </summary>
        /// <value>Роли.</value>
        public DbSet<Role> Roles { get; set; }
        /// <summary>
        /// Таблица с постами.
        /// </summary>
        /// <value>Посты.</value>
        public DbSet<Post> Posts { get; set; }
        /// <summary>
        ///Таблица с лайками.
        /// </summary>
        /// <value>Лайки.</value>
        public DbSet<PostLike> PostLikes { get; set;}
        /// <summary>
        /// Таблица с категориями.
        /// </summary>
        /// <value>Категории.</value>
        public DbSet<Category> Categories { get; set; }
        /// <summary>
        /// Таблица с просмотрами.
        /// </summary>
        /// <value>Просмотры.</value>
        public DbSet<PostViews> PostViews { get; set; }
        public DbSet<Tag> Tags { get; set; }
        /// <summary>
        /// Этот метод вызывается, когда модель производного контекста инициализирована
        /// </summary>
        /// <param name="modelBuilder">Конструктор, который определяет модель создаваемого контекста.</param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().
                Property(p => p.LastVisit)
                .HasColumnType("datetime2")
                .HasPrecision(0)
                .IsRequired();
            modelBuilder.Entity<User>().
                  Property(p => p.Datebirth)
                  .HasColumnType("datetime2")
                  .HasPrecision(0)
                  .IsRequired();
            modelBuilder.Entity<User>().
                Property(p => p.DateRegister)
                .HasColumnType("datetime2")
                .HasPrecision(0)
                .IsRequired();
            modelBuilder.Entity<Post>().
                Property(p => p.dateAddPost)
                .HasColumnType("datetime2")
                .HasPrecision(0)
                .IsRequired();
        }
  

    }
}
