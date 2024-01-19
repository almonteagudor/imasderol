using imasderol.application.zombicide.skill.createSkillCommand;
using imasderol.application.zombicide.skill.deleteSkillCommand;
using imasderol.application.zombicide.skill.findSkillByIdQuery;
using imasderol.application.zombicide.skill.getSkillsQuery;
using imasderol.domain.zombicide.skill;
using imasderol.infrastructure.zombicide.skill;

namespace imasderol.api;

public static class ServicesManager
{
    public static void AddImasderolDependencies(this IServiceCollection services)
    {
        services.AddHandlers();
        services.AddServices();
        services.AddImplementations();
    }

    private static void AddHandlers(this IServiceCollection services)
    {
        services.AddScoped<CreateSkillCommandHandler>();
        services.AddScoped<DeleteSkillCommandHandler>();
        services.AddScoped<FindSkillByIdQueryHandler>();
        services.AddScoped<GetSkillsQueryHandler>();
    }
    
    private static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<SkillCreator>();
    }
    
    private static void AddImplementations(this IServiceCollection services)
    {
        services.AddScoped<ISkillRepository, SkillRepository>();
    }
}