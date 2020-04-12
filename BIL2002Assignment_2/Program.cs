using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIL2002Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Which movie do you want to buy tickets for:\n");
            string[] movies = { "Avatar 2", "Suicide Squad 2", "John Wick 4", "Shrek 6"};
            Console.WriteLine("1-Avatar 2\n2-Suicide Squad 2\n3-John Wick 4\n4-Shrek 6");
            int selection = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine(movies[selection - 1]);
            
            Console.WriteLine("Do you have a discount code? (Psst! it's DSCC0D3 Enter It!)");
            string dscCode = Console.ReadLine();
            Ticket ticket;
            if(dscCode == "DSCC0D3")
            {
                Console.WriteLine("Yayyy discount applied!!");
                ticket = new DiscountedTicket(dscCode,20);
                ticket.Price = -20;
            }
            else
            {
                Console.WriteLine("Nope, you'll get an ordinary ticket");
                ticket = new Ticket();
                ticket.Price = 0;
            }
            Session session = new Session(movies[selection - 1]);
            session.Date = DateTime.Today;
            Random r = new Random();
            session.Date = session.Date.AddHours(r.Next(12,18));
            ticket.Session = session;
            Console.WriteLine("Your Name:");
            ticket.CustomerName = Console.ReadLine();
            Console.WriteLine("Your Surname:");
            ticket.CustomerSurname = Console.ReadLine();
            Console.WriteLine("National ID number:");
            ticket.NationaID = Convert.ToInt64(Console.ReadLine());



            //Getting the file path
            DirectoryInfo currentDir = new DirectoryInfo(".").Parent.Parent;
            string filePath = currentDir.FullName + "\\sinema.txt";
            string[] bookingData;
            try
            {
                bookingData = System.IO.File.ReadAllLines(filePath);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("I couldn't fint the sinema.txt file, sorry...");
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
                return;
            }
            

            foreach (string line in bookingData)
            {
                string[] info = line.Split(',');

                if (Convert.ToInt32(info[0]) == selection)
                    session.seats.Add(new Seat(Convert.ToInt32(info[1]), Convert.ToInt32(info[2]),info[3]));    
            }

            session.GetSessionInfo();

            Console.WriteLine("How many seats do you want to book:");
            int seatCount = Convert.ToInt32(Console.ReadLine());

            if(seatCount < 2)
            {
                Console.WriteLine("OrderNumber:");
                int oNumber = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("SeatNumber:");
                int sNumber = Convert.ToInt32(Console.ReadLine());

                if (Seat.BookSeat(sNumber, oNumber, session) != null)
                {
                    ticket.seats.Add(Seat.BookSeat(sNumber, oNumber, session));
                }
            }
            else
            {
                Seat[] bookedSeats = Seat.BookSeat(seatCount, session);

                for (int i = 0; i < seatCount; i++)
                {
                    ticket.seats.Add(bookedSeats[i]);
                }
            }

            
            if(ticket.seats != null)
            {
                ticket.SetPrice();
                ticket.GetTicketDetails();
            }
                
            Console.ReadLine();

        }
        
    }
}
