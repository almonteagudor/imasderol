using imasderol.infrastructure.zombicide.skill;
using Microsoft.EntityFrameworkCore;

namespace imasderol.infrastructure;

public class ImasderolDb : DbContext
{
    public ImasderolDb(DbContextOptions options) : base(options) { }
    
    public ImasderolDb() { }
    
    public DbSet<SkillDto>? Skills { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=C:\\imasderol\\imasderol.db");
    }
}