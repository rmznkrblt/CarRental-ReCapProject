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
                var result =
                    from r in context.Rentals
                    join car in context.Cars
                        on r.CarId equals car.Id
                    join c in context.Customers on r.CustomerId equals c.UserId
                    join b in context.Brands on car.BrandId equals b.Id
                    join u in context.Users on c.UserId equals u.Id
                    select new RentalDetailDto
                    {
                        Id = r.Id,
                        CarId = r.CarId,
                        CarName = b.Name,
                        RentDate = r.RentDate,
                        ReturnDate = r.ReturnDate,
                        CustomerFirstName = u.FirstName,
                        CustomerLastName = u.FirstName
                    };
                return result.ToList();
            }
        }
    }
}
