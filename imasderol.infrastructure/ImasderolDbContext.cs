using imasderol.domain.zombicide.skill;
using Microsoft.EntityFrameworkCore;

namespace imasderol.infrastructure;

public class ImasderolDbContext : DbContext
{
    public DbSet<Skill>? Skills { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        const string connectionString = "server=localhost; database=imasderol; user=imasderol; password=imasderol";

        options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
    }
}