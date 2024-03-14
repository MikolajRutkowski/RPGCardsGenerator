using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RPGCardsGenerator.Variables
{
    public class BoardsContext : DbContext
    {
        public DbSet<PlayerCharacter> PlayerCharacters { get; set; }
        public DbSet<Statistic> Statistics { get; set; }

        public DbSet<NPC> NPCs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                 .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=RPGDataBase;Trusted_Connection=True");
                // .UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=RPGDataBase;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Statistic>(eb =>
            { 
                eb.Property(x => x.Name).IsRequired(); 
              eb.Property(x => x.Value).IsRequired().HasMaxLength(2);
                eb.Property(x => x.Description).HasDefaultValue("Opis");
            });

            modelBuilder.Entity<PlayerCharacter>(pc =>
            {
                pc.HasMany(p => p.Stats).WithOne(s => (PlayerCharacter)s.Character).HasForeignKey(s => s.CharaterId);
            });

            modelBuilder.Entity<NPC>(pc =>
            {
                
            });
        }

    }
}
