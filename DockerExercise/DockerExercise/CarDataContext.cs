using DockerExercise.Modell;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DockerExercise
{
    public class CarDataContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Booking> Bookings { get; set; }

        public CarDataContext(DbContextOptions<CarDataContext> options) : base(options)
        { }
    }
}
