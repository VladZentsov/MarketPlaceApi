using MarketPlaceDAL.DBContext;
using Microsoft.EntityFrameworkCore;

namespace MarketPlaceApi.Extensions
{
    public static class MigrationExtensions
    {
        public static void ApplyMigrations(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<MarketPlaceDBContext>();
                //context.Database.EnsureDeleted();
                context.Database.Migrate();
            }
        }
    }
}
