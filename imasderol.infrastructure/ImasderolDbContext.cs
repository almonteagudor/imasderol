using imasderol.domain.zombicide.skill;
using Microsoft.EntityFrameworkCore;

namespace imasderol.infrastructure;

public class ImasderolDbContext : DbContext
{
    public DbSet<Skill>? Skills { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=imasderol.db");
    }
}