﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCorePersonel.Models
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-68S784Q; database=CorePersonel; integrated security=true;");
        }
        public DbSet<Departmanlar> Departmanlars { get; set; }
        public DbSet<Personel> Personels { get; set; }
    }
}