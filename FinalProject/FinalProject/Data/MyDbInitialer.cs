using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace FinalProject.Data
{
    public class MyDbInitialer
    {
        public static void Seed(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ShopDbContext>();

                if (!context.Sizes.Any())
                {
                    context.AddRange(new Size
                    {
                        Name = "M"
                    },
                    new Size
                    {
                        Name = "L"
                    }, new Size
                    {
                        Name = "XL"
                    },
                    new Size
                    {
                        Name = "M"
                    });
                }

                context.SaveChanges();
            }

        }
    }
}
