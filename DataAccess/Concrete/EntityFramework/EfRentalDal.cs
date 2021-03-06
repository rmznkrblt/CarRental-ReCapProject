using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.DataAccess.EntityFramework;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental,CarRentalContext>,IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from r in context.Rentals 
                    join c in context.Cars on r.CarId equals c.Id
                    join cu in context.Customers on r.CustomerId equals cu.Id
                    join u in context.Users on cu.UserId equals u.Id
                    select new RentalDetailDto
                    {
                        CustomerName = u.FirstName + " " + u.LastName,
                        CarId = c.Id,
                        CarName = c.Description,
                        Id = r.Id,
                        RentDate = r.RentDate,
                        ReturnDate = r.ReturnDate
                    };
                return result.ToList();
            }
        }
    }
}
