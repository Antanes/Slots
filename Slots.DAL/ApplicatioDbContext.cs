using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Slots.Domain.Entity;
using Slots.Domain.Enum;


namespace Slots.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
            Database.EnsureCreated();
        }

        public DbSet<Drink> Drink { get; set; }

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
                
                
                modelBuilder.Entity<Drink>(builder =>
                {
                    builder.ToTable("Drinks").HasKey(x => x.Id);

                    builder.HasData(new Drink[]
                   {
                        new Drink()
                        {
                        Id = 1,
                        Name = "Cola",
                        Quantity = 7,
                        Price = 13,
                        Avatar = null,
                        },

                        new Drink()
                        {
                        Id = 2,
                        Name = "Fanta",
                        Quantity = 5,
                        Price = 12,
                        Avatar = null,
                        },

                        new Drink()
                        {
                        Id = 3,
                        Name = "Sprite",
                        Quantity = 4,
                        Price = 11,
                        Avatar = null,
                        },

                        new Drink()
                        {
                        Id = 4,
                        Name = "Лимонад",
                        Quantity = 8,
                        Price = 7,
                        Avatar = null,
                        }
                   
                });

                builder.Property(x => x.Id).ValueGeneratedOnAdd();

                
                builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
            });
        }
    }
}
    
     

