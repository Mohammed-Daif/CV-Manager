using Microsoft.Extensions.DependencyInjection;
using System;

namespace CV_Manager.DB
{
    public class DbIntitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<ApplicationDbContext>();
            //  context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

        }
    }
}
