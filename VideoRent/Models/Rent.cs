using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VideoRent.Models
{
    public class Rent
    {
        public int RentId { get; set; }
        public RentStatus RentStatus { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int MovieId { get; set; }
        public string MovieTitle { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public Int64 timeDifference { get; set; }
    }
}
