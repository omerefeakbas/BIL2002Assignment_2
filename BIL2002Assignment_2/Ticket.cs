using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIL2002Assignment_2
{
    class Ticket : ITicket
    {
        public long NationaID { get; set; }
        public string CustomerName { get; set; }
        public string CustomerSurname { get; set; }
        public Session Session { get; set; }
        public List<Seat> seats = new List<Seat>();
        public int Price { get; set; }
        public void GetTicketDetails()
        {
            try
            {
                Console.WriteLine("\n\n");
                Console.WriteLine(CustomerName + " " + CustomerSurname);
                Console.WriteLine(Session.MovieName);
                Console.WriteLine(Session.Date);

                Console.WriteLine("Your Seat(s): ");


                foreach (Seat seat in seats)
                {
                    Console.Write(seat.OrderNumber.ToString() + "-" + seat.SeatNumber.ToString() + "  ");
                }
                Console.WriteLine("\nPrice: " + Price.ToString() + " USD");
                Console.WriteLine("Enjoy the movie!");
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("I can't book your seat(s) now please try again...");
            }
            


        }
        public void SetPrice()
        {
            foreach(Seat seat in seats)
            {
                Price += 30;
            }
        }
    }
}
