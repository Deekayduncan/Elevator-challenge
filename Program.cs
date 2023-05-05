using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elevate
{
    public class Program
    {
        private const int NoOfFloors = 9;
       public static void Main(string[] args)
        {
            ElevatorService service = new ElevatorService();

            //Create new elevators to work with
            List<Elevator> elevators = service.CreateElevators();

            var request = Display(service, elevators);

            elevators = CheckRequests(service, elevators, request);
            var notDone = true;
            while (notDone)
            {
                Console.Clear();
                request = Display(service, elevators);
                elevators = CheckRequests(service, elevators, request);
              
            }
         

            Console.ReadLine();
        }

        private static List<Elevator> CheckRequests(ElevatorService service, List<Elevator> elevators, FloorRequest request)
        {
            if (request.CurrentFloor < 10 && request.NoOfPeople < 6)
            {
                foreach (var item in elevators.OrderBy(t => t.TotalPeople))

                {
                    if (request.NoOfPeople < 7 && (item.TotalPeople + request.NoOfPeople) <= 7)
                    {
                        item.TotalPeople += request.NoOfPeople;
                        item.SelectedFloorsCount += 1;
                        item.IsActive = true;
                       
                        request.Accepted = true;
                        break;
                    }

                }
                if (request.Accepted == false)
                {
                    Console.Clear();
                    if (request.NoOfPeople > 6)
                        Console.WriteLine("#########   Enter Valid Numbers! ");
                    if (request.SelectedFloor == request.CurrentFloor)
                        Console.WriteLine("#########   You are on the same floor! ");
                    if (request.SelectedFloor > 9 || request.SelectedFloor < 0)
                        Console.WriteLine("#########   Enter Valid Floor! ");

                }

            }
            else
            {
                Console.Clear();
                if (request.NoOfPeople > 6)
                    Console.WriteLine("#########   Too Many People for an elevator! ");
                if (request.SelectedFloor == request.CurrentFloor)
                    Console.WriteLine("#########   You are on the same floor! ");
                if (request.SelectedFloor > 9 || request.SelectedFloor < 0)
                    Console.WriteLine("#########   Enter Valid Floor! ");

            }

            return elevators;
        }

        private static FloorRequest Display(ElevatorService service, List<Elevator> elevators)
        {
            //show all elevators and where they are
            service.MainDisplay(elevators, NoOfFloors);

            //give user an option to request an elevator
            var request = service.RequestFloor();
            return request;
        }

    }
}
