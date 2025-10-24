using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;

namespace Redox_Code_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Enumerable.Range(1, 100).ToList();

            var evenNumbers = numbers.Where(n => n % 2 == 0);

            Console.WriteLine("Even Numbers:");
            Console.WriteLine(string.Join(",", evenNumbers));

            List<int> divisibleBy3Or5 = new List<int>();

            foreach (int num in numbers)
            {
                bool divBy3 = num % 3 == 0;
                bool divBy5 = num % 5 == 0;

                if (divBy3 ^ divBy5)
                {
                    divisibleBy3Or5.Add(num);
                }
            }

            Console.WriteLine("\nNumbers divisible by 3 or 5 but not both:");
            Console.WriteLine(string.Join(",", divisibleBy3Or5));

            EventScheduler scheduler = new EventScheduler();
            scheduler.LoadEvents();

            scheduler.ScheduleEvent(new Event
            {
                Name = "Team Meeting",
                Location = "Room 101",
                DateTime = new DateTime(2025, 10, 25, 14, 0, 0)
            });

            scheduler.ScheduleEvent(new Event
            {
                Name = "Workshop",
                Location = "Lab 3",
                DateTime = new DateTime(2025, 10, 26, 10, 0, 0)
            });

            Console.WriteLine("\nUpcoming Events:");
            foreach (var ev in scheduler.GetUpcomingEvents())
            {
                Console.WriteLine(ev);
            }

        }
    }
}
