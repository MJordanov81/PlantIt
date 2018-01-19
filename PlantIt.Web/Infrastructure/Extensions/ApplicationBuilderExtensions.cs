namespace PlantIt.Web.Infrastructure.Extensions
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using PlantIt.Data;

    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder MigrateDatabase(this IApplicationBuilder builder)
        {
            using (IServiceScope serviceScope = builder.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                serviceScope.ServiceProvider.GetService<PlantItDbContext>().Database.Migrate();
            }

            return builder;
        }

        //public static IApplicationBuilder SeedRoles(this IApplicationBuilder builder, IList<string> rolesNames)
        //{

        //    using (IServiceScope serviceScope = builder.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
        //    {
        //        var roleManager = serviceScope.ServiceProvider.GetService<RoleManager<Role>>();

        //        foreach (string roleName in rolesNames)
        //        {
        //            if (!roleManager.RoleExistsAsync(roleName).Result)
        //            {
        //                var result = roleManager.CreateAsync(new Role { Name = roleName }).Result;
        //            }
        //        }
        //    }

        //    return builder;
        //}
    }
}
