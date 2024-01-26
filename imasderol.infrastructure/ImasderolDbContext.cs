using imasderol.infrastructure.zombicide.skill;
using imasderol.infrastructure.zombicide.weapon;
using Microsoft.EntityFrameworkCore;

namespace imasderol.infrastructure;

public class ImasderolDbContext : DbContext
{
    public DbSet<SkillEntity>? Skills { get; set; }
    public DbSet<WeaponEntity>? Weapons { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        const string connectionString = "server=localhost; database=imasderol; user=imasderol; password=imasderol";

        options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
    }
}