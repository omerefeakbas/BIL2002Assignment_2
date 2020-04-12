using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIL2002Assignment_2
{
    class Seat
    {
        public int OrderNumber { get; set; }
        public int SeatNumber { get; set; }
        public bool IsBooked { get; set; }

        public Seat(int orderNumber, int seatNumber,string isBooked)
        {
            OrderNumber = orderNumber;
            SeatNumber = seatNumber;
            if (isBooked == "dolu")
                IsBooked = true;
            else
                IsBooked = false;
        }

        //Methot that books a seat if it's avavible
        //Returns a Seat
        public static Seat BookSeat(int orderNumber,int seatNumber,Session session)
        {
            bool isAvavible = false;
            foreach(Seat seat in session.seats)
            {
                if(seat.OrderNumber == orderNumber && seat.SeatNumber == seatNumber)
                {
                    isAvavible = true;
                    break;
                }
            }
            if (isAvavible)
                return new Seat(orderNumber, seatNumber, "dolu");
            else
            {
                Console.WriteLine("Sorry, that seat is already booked...");
                return null;
            }
                
        }

        //Static methot that automatically books nearby seats with given amount
        //Returns a Seat Array
        public static Seat[] BookSeat(int seatCount, Session session)
        {
            int currentSeatNumber = 0;
            int iterationNumber = 0;
            Seat[] seatsToBook = new Seat[seatCount];
            var random = new Random();
            
            while (true)
            {
                iterationNumber++;
                currentSeatNumber = random.Next(0, session.seats.Count);
                for (int i = 0; i < seatCount; i++)
                {   
                    if(currentSeatNumber + i == session.seats.Count() - 1)
                    {
                        Array.Clear(seatsToBook, 0, seatsToBook.Length);
                        break;
                    }

                    if(session.seats[currentSeatNumber+i].IsBooked != true && session.seats[currentSeatNumber + i].SeatNumber == session.seats[currentSeatNumber + i + 1].SeatNumber - 1)
                    {
                        seatsToBook[i] = session.seats[currentSeatNumber + i];
                    }
                    else
                    {
                        Array.Clear(seatsToBook, 0, seatsToBook.Length);
                        break;
                    }
                    
                }
                if (seatsToBook[seatsToBook.Length-1] != null)
                {
                    for (int i = 0; i < seatCount; i++)
                    {
                        session.seats[currentSeatNumber + i].IsBooked = true;
                    }
                    break;
                }

                    
                if(iterationNumber > 1000)
                {
                    Array.Clear(seatsToBook, 0, seatsToBook.Length);
                    Console.WriteLine("There aren't " + seatCount.ToString() + " seats next to each other");
                    break;
                }
            }
            
            
            return seatsToBook;
        }
    }
}
