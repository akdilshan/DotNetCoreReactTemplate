using AuthServer.Data;
using IdentityModel;
using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Mappers;
using IdentityServer4.EntityFramework.Storage;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace AuthServer
{
    public class SeedData
    {
        public static void EnsureSeedData(string connectionString)
        {
            var services = new ServiceCollection();
            services.AddLogging();
            services.AddDbContext<AspNetIdentityDbContext>(
                options => options.UseSqlServer(connectionString)
            );

            services
                .AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<AspNetIdentityDbContext>()
                .AddDefaultTokenProviders();

            services.AddOperationalDbContext(
                options =>
                {
                    options.ConfigureDbContext = DbContext =>
                        DbContext.UseSqlServer(connectionString, sql => sql.MigrationsAssembly(typeof(SeedData).Assembly.FullName));
                }
           );

            services.AddConfigurationDbContext(
                options =>
                {
                    options.ConfigureDbContext = db =>
                        db.UseSqlServer(connectionString, sql => sql.MigrationsAssembly(typeof(SeedData).Assembly.FullName));
                }
                );

            var serviceProvider = services.BuildServiceProvider();
            using var scope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope();
            scope.ServiceProvider.GetService<PersistedGrantDbContext>().Database.Migrate();

            var context = scope.ServiceProvider.GetService<ConfigurationDbContext>();
            context.Database.Migrate();

            EnsureSeedData(context);

            var ctx = scope.ServiceProvider.GetService<AspNetIdentityDbContext>();
            ctx.Database.Migrate();
            EnsureUsers(scope);
        }

        private static void EnsureUsers(IServiceScope scope)
        {
            var userMgr = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
            var test1 = userMgr.FindByNameAsync("test1").Result;
            if (test1 == null)
            {
                test1 = new IdentityUser
                {
                    UserName = "test1",
                    Email = "test111@gmail.com",
                    EmailConfirmed = true,
                };
                var result = userMgr.CreateAsync(test1, "Pass123$").Result;
                if (!result.Succeeded)
                {
                    throw new Exception(result.Errors.FirstOrDefault().Description);
                }

                result = userMgr.AddClaimsAsync(
                    test1,
                    new Claim[]
                        {
                            new Claim(JwtClaimTypes.Name, "Test1 Test1"),
                            new Claim(JwtClaimTypes.GivenName, "test1"),
                            new Claim(JwtClaimTypes.FamilyName, "testFamily"),
                            new Claim(JwtClaimTypes.WebSite, "https://testone.com"),
                            new Claim("location", "Singapore")
                        }
                    ).Result;
                if (!result.Succeeded)
                {
                    throw new Exception(result.Errors.FirstOrDefault().Description);
                }
            }
        }

        private static void EnsureSeedData(ConfigurationDbContext context)
        {
            if (!context.Clients.Any())
            {
                foreach (var client in Config.Clients.ToList())
                {
                    context.Clients.Add(client.ToEntity());
                }

                context.SaveChanges();
            }

            if (!context.IdentityResources.Any())
            {
                foreach (var resource in Config.IdentityResources.ToList())
                {
                    context.IdentityResources.Add(resource.ToEntity());
                }

                context.SaveChanges();
            }

            if (!context.ApiScopes.Any())
            {
                foreach (var resource in Config.ApiScopes.ToList())
                {
                    context.ApiScopes.Add(resource.ToEntity());
                }

                context.SaveChanges();
            }

            if (!context.ApiResources.Any())
            {
                foreach (var resource in Config.ApiResources.ToList())
                {
                    context.ApiResources.Add(resource.ToEntity());
                }

                context.SaveChanges();
            }
        }


    }
}
