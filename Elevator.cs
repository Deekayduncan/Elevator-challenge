using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elevate
{
    public class Elevator
    {
        public int LiftID { get; set; }
        public int CurrentFloor { get; set; }
        public bool IsActive { get; set; }
        public int TotalPeople { get; set; }
        public List<Floor> SelectedFloors { get; set; }
        public int SelectedFloorsCount { get; set; }

    }
}
