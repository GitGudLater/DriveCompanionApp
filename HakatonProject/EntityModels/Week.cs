using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HakatonProject.EntityModels
{
    public class Week
    {
        public int Id { get; set; }
        public bool Monday {get; set;}
        public bool Tuesday {get; set;}
        public bool Wensday {get; set;}
        public bool Thursday {get; set;}
        public bool Friday {get; set;}
        public bool Saturday {get; set;}
        public bool Sunday {get; set;}
        public int CarId { get; set; }
        public Car Car { get; set; }
    }
}
