using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Entities.DTOs
{
    public class RentalDetailDto : IDto
    {
        public int Id { get; set; }
        public int CarId  { get; set; }
        public string CarName { get; set; }
        public string CustomerLastName { get; set; }
        public string CustomerFirstName { get; set; }
        
        public DateTime RentDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}
