﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HakatonProject.EntityModels
{
    public class UserCar
    {

        public User User { get; set; }
        public int UserId { get; set; }

        public Car Car { get; set; }
        public int CarId { get; set; }
    }
}
