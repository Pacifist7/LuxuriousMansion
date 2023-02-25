using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LuxuriousMansion.Models;

namespace LuxuriousMansion.Data
{
    public class LuxuriousMansionContext : DbContext
    {
        public LuxuriousMansionContext (DbContextOptions<LuxuriousMansionContext> options)
            : base(options)
        {
        }

        public DbSet<LuxuriousMansion.Models.Mansion> Mansion { get; set; } = default!;
    }
}
