using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HakatonProject.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string CoordStart { get; set; }
        public string CoordFin { get; set; }
        public string TBegin { get; set; }
        public int MaxSeats { get; set; }
        public string Description { get; set; }
        public string CarModel { get; set; }

        public Week Week { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public ICollection<UserCar> UserCar { get; set; }

        public Car()
        {
            UserCar = new List<UserCar>();
        }

    }
}
