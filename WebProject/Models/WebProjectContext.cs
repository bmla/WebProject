﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace WebProject.Models
{
    public class WebProjectContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public WebProjectContext() : base("name=WebProjectContext")
        {
        }

        public System.Data.Entity.DbSet<WebProject.Models.Team> Teams { get; set; }

        public System.Data.Entity.DbSet<WebProject.Models.Player> Players { get; set; }

        public System.Data.Entity.DbSet<WebProject.Models.Match> Matches { get; set; }

        public System.Data.Entity.DbSet<WebProject.Models.Referee> Referees { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
        }
    }
}
