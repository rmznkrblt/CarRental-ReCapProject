using System;
using System.Collections.Generic;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Linq;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, CarRentalContext>, ICustomerDal
    {
        public List<CustomerDetailDto> GetCustomerDetails()
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from c in context.Customers
                             join u in context.Users on c.UserId equals u.Id
                             select new CustomerDetailDto 
                             { 
                                 Id = c.Id, 
                                 FirstName = u.FirstName, 
                                 LastName = u.LastName, 
                                 Email = u.Email, 
                                 Password = u.PasswordHash.ToString(), 
                                 CompanyName = c.CompanyName
                             };
                return result.ToList();


            }
        }
    }
}
