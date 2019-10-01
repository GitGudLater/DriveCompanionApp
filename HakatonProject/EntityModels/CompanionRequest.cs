using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HakatonProject.EntityModels
{
    public class CompanionRequest
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public User User { get; set; }
        public int UserId { get; set; }

        public Car Car { get; set; }
        public int CarId { get; set; }
    }
}
