using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CarCenter.Models;

namespace CarCenter.Data
{
    public class CarCenterContext : DbContext
    {
        public CarCenterContext (DbContextOptions<CarCenterContext> options)
            : base(options)
        {
        }

        public DbSet<CarCenter.Models.Carro> Carro { get; set; } = default!;

        public DbSet<CarCenter.Models.Cliente>? Cliente { get; set; }

        public DbSet<CarCenter.Models.Vendedor>? Vendedor { get; set; }

        public DbSet<CarCenter.Models.Nota>? Nota { get; set; }
    }
}
