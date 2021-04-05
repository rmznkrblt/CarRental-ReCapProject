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
                             join ca in context.Cars on r.CarId equals ca.Id
                             join b in context.Brands on ca.BrandId equals b.Id
                             join co in context.Colors on ca.ColorId equals co.Id
                             join c3 in context.Customers on r.CustomerId equals c3.Id
                             join u in context.Users on c3.UserId equals u.Id
                             select new RentalDetailDto 
                             {
                                 Id = r.Id, 
                                 BrandName = b.Name,
                                 ColorName = co.Name, 
                                 ModelYear = ca.ModelYear, 
                                 DailyPrice =  ca.DailyPrice, 
                                 Description = ca.Description, 
                                 FirstName = u.FirstName, 
                                 LastName = u.LastName, 
                                 RentDate = r.RentDate, 
                                 ReturnDate = r.ReturnDate, 
                                 CompanyName = c3.CompanyName 
                             };
                return result.ToList();

            }
        }
    }
}
