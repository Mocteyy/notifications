using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Data.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<NotificationEF>? Notifications { get; set; }
        public DbSet<UserEF>? Users { get; set; }

        public string DbPath { get; set; }

        public ApplicationContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "db_notifications2.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options) 
            => options.UseSqlite($"DataSource={DbPath}");
    }
}