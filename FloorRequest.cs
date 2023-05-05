using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elevate
{
    public class FloorRequest
    {
        public int CurrentFloor { get; set; }
        public int SelectedFloor { get; set; }
        public int NoOfPeople { get; set; }
        public bool Accepted { get; set; }
    }
}
