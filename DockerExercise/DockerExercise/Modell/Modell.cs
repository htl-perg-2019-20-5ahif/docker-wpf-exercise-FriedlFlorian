using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DockerExercise.Modell
{
    public class Car
    {
        public int CarId { get; set; }

        [Required]
        public string Model { get; set; }

        [Required]
        public string Brand { get; set; }





        public List<Booking> Bookings { get; set; }
    }

    public class Booking
    {
        public int BookingId { get; set; }

        [Required]
        public DateTime BookedDate { get; set; }


        public int CarId { get; set; }

        [Required]
        public Car Car { get; set; }
    }
}
