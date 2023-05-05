using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Timers;
namespace Elevate
{
    public class ElevatorService
    {
        private const int noOfFloors = 9;
        public List<Elevator> elevatorsInternal { get; set; }
        private  int count = 0;
        public bool stopTimer = false;
        public List<Elevator> CreateElevators()
        {
            List<Elevator> elevators = new List<Elevator>();

            for (var i = 0; i < 3; i++)
            {
                elevators.Add(new Elevator()
                {
                    LiftID = i,
                    IsActive = true,
                    CurrentFloor = 0,
                    SelectedFloorsCount = 0,
                    TotalPeople = 0,
                });
            }

            return elevators;
        }
        public void MainDisplay(List<Elevator> elevators,int totalFloors)
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("********************************************");
            Console.WriteLine($"****** {noOfFloors} Floors! Max 6 People In A Elevator!!! ******");
            Console.WriteLine("********************************************");
            Console.WriteLine();
            Console.WriteLine(" Elevator         Floor      People");
            Console.WriteLine();
            elevatorsInternal = elevators;
            int index = 0;
            foreach (var el in elevators)
            {
                Console.WriteLine("    {0}                {1}        {2}", el.LiftID + 1, el.CurrentFloor, el.TotalPeople);
               if(el.TotalPeople > 0)
                startElevator(el.CurrentFloor,el.SelectedFloorsCount, index);
                ++index;
            };
            Console.WriteLine();
            Console.WriteLine();
        }    
        public  FloorRequest RequestFloor()
        {
            //capture information of where the floor the request comes from and from 
            var request = new FloorRequest();
            Console.WriteLine("Please Enter your Current floor number:");
            request.CurrentFloor = Int32.Parse(Console.ReadLine().ToString());
             
            Console.WriteLine("Please Enter your floor number:");
            request.SelectedFloor = Int32.Parse(Console.ReadLine().ToString());
            Console.WriteLine("Please Enter how many are climbing:");
            request.NoOfPeople = Int32.Parse(Console.ReadLine().ToString());

            return request;
        }
        public void startElevator(int floorSelected, int floor, int index)
        {


            
            var seconds = 1;
            if (floorSelected < floor)
            {
                if (floor - floorSelected > 0) {
                seconds = (floor - floorSelected) * 1000;
                }

            }
            else {
                if (floor - floorSelected > 0)  
                {
                    seconds = floorSelected - floor;
                    seconds = seconds * 10000;
                }
            }
            var timer = new System.Timers.Timer();
           

            if (count == seconds)
            {
                timer.Enabled = false;
            }
            else
            {
                timer.Interval = seconds;
                timer.Elapsed += new ElapsedEventHandler(RePrintDisplayData);

             
                timer.Start();
                if (count == seconds)
                {
                    timer.Stop();
                }
            }
           
        }
        public void reprint(List<Elevator> elevators)
        {
           
            
        }
        public  void RePrintDisplayData(object source, ElapsedEventArgs e)
        {
            if (count < 9 && stopTimer == false)
            { 
                ++count;
            if(count == 9)
            {
                stopTimer = true;
            }
                Console.SetCursorPosition(0, 10);
                
                Console.WriteLine("    {0}                {1}        {2}", elevatorsInternal[0].LiftID + 1, elevatorsInternal[0].CurrentFloor, elevatorsInternal[0].TotalPeople);

                Console.SetCursorPosition(0, 11);
                Console.WriteLine("    {0}                {1}        {2}", elevatorsInternal[1].LiftID + 1, elevatorsInternal[1].CurrentFloor, elevatorsInternal[1].TotalPeople);

                Console.SetCursorPosition(0, 12);
                Console.WriteLine("    {0}                {1}        {2}", elevatorsInternal[2].LiftID + 1, elevatorsInternal[2].CurrentFloor, elevatorsInternal[2].TotalPeople);
          
                Console.SetCursorPosition(0, Console.CursorTop + 3);
              
            }
            else {
                count = 0;
            }
        }
    }
}
