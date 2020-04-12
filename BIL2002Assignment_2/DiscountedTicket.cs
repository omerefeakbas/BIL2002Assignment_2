using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIL2002Assignment_2
{
    class DiscountedTicket : Ticket
    {
        public string DiscountCode { get; set; }
        public int DiscountAmount { get; set; }

        public DiscountedTicket(string discountCode, int discountAmount)
        {
            DiscountCode = discountCode;
            DiscountAmount = discountAmount;
        }

        public static void ApplyDiscount(string discountCode,int discountAmount,Ticket ticket)
        {
            if(discountCode == "DCSC0D3")
            {
                ticket.Price = -discountAmount;
            }
        }
        

    }
}
