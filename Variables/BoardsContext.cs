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
        public DbSet<Character> Characters { get; set; }
        public DbSet<PlayerCharacter> PlayerCharacters { get; set; }

        public DbSet<NPC> NPCs { get; set; }

        public DbSet<Statistic> Statistics { get; set; }

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
                eb.Property(x => x.Value).IsRequired().HasDefaultValue(1);
                eb.Property(x => x.Description).HasDefaultValue("Opis");
                eb.HasOne(x => x.Character).WithMany(c => c.Stats).HasForeignKey(c => c.CharaterId);
            });


            modelBuilder.Entity<Character>(eb => {
                eb.Property(x => x.Name).IsRequired();
            }) ;
            modelBuilder.Entity<PlayerCharacter>(pc =>
            {
               // pc.Property(Cotokurwajest => Cotokurwajest.Expiries).HasDefaultValue(0);
              
            });

            modelBuilder.Entity<NPC>(nop =>
            {
              //  nop.Property(Cotokurwajest => Cotokurwajest.reputacja).HasDefaultValue("Neutralny");
            });
        }

    }
}
