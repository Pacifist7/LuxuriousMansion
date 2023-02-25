using LuxuriousMansion.Data;
using Microsoft.EntityFrameworkCore;

namespace LuxuriousMansion.Models
{
    public static class SeedData
    {
        public static void Initializer(IServiceProvider serviceProvider)
        {
            using (var context = new LuxuriousMansionContext(
                serviceProvider.GetRequiredService<DbContextOptions<LuxuriousMansionContext>>()))
            {
                //Look for any mansions
                if (context.Mansion.Any())
                {
                    return; //DB has been seeded
                }
                context.Mansion.AddRange(
                    new Mansion
                    {
                        Name = "Pacific Coast Highway",
                        Description="Malibu, CA",
                        Price=255000000M,
                        CreatedDate=DateTime.Parse("2023-2-24")
                    },
                    new Mansion
                    {
                        Name = "Mylestone at Meadow Lane",
                        Description = "Hamptons, NY",
                        Price = 175000000M,
                        CreatedDate = DateTime.Parse("2023-2-25")
                    },
                    new Mansion
                    {
                        Name = "Hunts Point Road",
                        Description = "Hunts Point, WA",
                        Price = 85000000M,
                        CreatedDate = DateTime.Parse("2023-2-26")
                    },
                    new Mansion
                    {
                        Name = "Highway 50",
                        Description = "Lake Tahoe, NV",
                        Price = 100000000M,
                        CreatedDate = DateTime.Parse("2023-2-27")
                    },
                    new Mansion
                    {
                        Name = "La Gorce Circle",
                        Description = "La Gorce Island, FL",
                        Price = 170000000M,
                        CreatedDate = DateTime.Parse("2023-2-28")
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
