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
        public DbSet<PlayerCharacter> PlayerCharacter { get; set; }
        public DbSet<Statistic> Statistic { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                 .UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Database=RPGDataBase;Trusted_Connection=True;");
                // .UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=RPGDataBase;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }

    }
    
}
