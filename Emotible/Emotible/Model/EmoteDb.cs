using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Emotible.Model
{
    public class EmoteContext : DbContext
    {
        private const string sqlFile = "emotedb.db";

        public DbSet<EmoteModel> Emotes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename={sqlFile}");
        }

        public async Task Seed(IEnumerable<EmoteModel> seedData)
        {
            foreach (var emote in seedData)
            {
                Emotes.Add(emote);
            }
            await SaveChangesAsync();
        }
    }
}
