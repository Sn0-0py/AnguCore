using AnguCore.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnguCore.Infrastructure.Data.Contexts
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hero>().HasData(
                new Hero() { Id = 1, Name = "Mr. Nice" },
                new Hero() { Id = 2, Name = "Narco" },
                new Hero() { Id = 3, Name = "Bombasto" },
                new Hero() { Id = 4, Name = "Celeritas" },
                new Hero() { Id = 5, Name = "Magneta" },
                new Hero() { Id = 6, Name = "RubberMan" },
                new Hero() { Id = 7, Name = "Dynama" },
                new Hero() { Id = 8, Name = "Dr IQ" },
                new Hero() { Id = 9, Name = "Magma" },
                new Hero() { Id = 10, Name = "Tornado" }
                );
        }

        public static void DisableDeleteCascade(this ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
        }
    }
}
