using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIL2002Assignment_2
{
    class Session
    {
        public List<Seat> seats = new List<Seat>();
        public string MovieName { get; set; }
        public DateTime Date { get; set; }

        public Session(string movieName)
        {
            MovieName = movieName;
        }
        

        public void GetSessionInfo()
        {
            Console.WriteLine();
            Console.WriteLine(MovieName);


            //Printing a visual cinema seat plan
            int currentOrderNumber = 0;
            Console.WriteLine("                    [  SCREEN  ]                         ");
            foreach (Seat s in seats)
            {
                if (s.OrderNumber != currentOrderNumber)
                {
                    Console.WriteLine();
                    currentOrderNumber = s.OrderNumber;
                    Console.Write(currentOrderNumber + " ");
                }

                if (s.IsBooked == true)
                {
                    Console.Write(":o:  ");
                }
                else
                {
                    Console.Write(":_:  ");
                }

            }
            Console.WriteLine("\n   1    2    3    4    5    6    7    8    9    10");

            Console.WriteLine("\n\n:_: Available     :o: Booked");
        }
    }
}
