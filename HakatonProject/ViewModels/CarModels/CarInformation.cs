﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HakatonProject.ViewModels.CarModels
{
    public class CarInformation
    {
        public string CoordStart { get; set; }
        public string CoordFin { get; set; }
        public string TBegin { get; set; }
        public int EmptySeats { get; set; }
        public string Description { get; set; }
        public string CarModel { get; set; }
        public List<bool> WeekDays { get; set; }
        public string DriverDescription { get; set; }
        public List<string> CompanionsNames { get; set; }
    }
}
