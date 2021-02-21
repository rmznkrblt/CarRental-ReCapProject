using System;
using System.Collections.Generic;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {

            CarManager carManager = new CarManager(new EfCarDal());
            UserManager userManager=new UserManager(new EfUserDal());
            RentalManager rentalManager=new RentalManager(new EfRentalDal());
            CustomerManager customerManager=new CustomerManager(new EfCustomerDal());
            ColorManager colorManager=new ColorManager(new EfColorDal());
            BrandManager brandManager=new BrandManager(new EfBrandDal());

            userManager.Add(new User
            {
                Id = 7,
                FirstName = "Ramazan",
                LastName = "Karabulut",
                Email = "r.karabulut@outlook.com.tr",
                Password = "rk1234"
            });
            customerManager.Add(new Customer
            {
                Id=1,
                UserId = 7,
                CompanyName = "Karabulut A.Ş"
            });
            userManager.Add(new User
            {
                Id = 8,
                FirstName = "Ramazan",
                LastName = "Karabulut",
                Email = "r.karabulut@outlook.com.tr",
                Password = "rk1234"
            });
            customerManager.Add(new Customer
            {
                Id = 2,
                UserId = 8,
                CompanyName = "Karabulut A.Ş"
            });
            rentalManager.Add(new Rental
            {
                Id = 7,CarId = 1,CustomerId = 7,RentDate = DateTime.Now,
                ReturnDate = DateTime.Parse("07-03-2021"),
            });
            rentalManager.Add(new Rental
            {
                Id = 8,
                CarId = 1,
                CustomerId = 8,
                RentDate = DateTime.Now,
                ReturnDate = DateTime.Parse("09-06-2021"),
            });

            foreach (var rental in rentalManager.GetRentalDetails().Data)
            {
                Console.WriteLine(rental.Id + " / " + rental.CustomerFirstName + " / " + rental.CustomerLastName + " / " + rental.CarName + " / " + rental.RentDate + " / " + rental.ReturnDate);
            }
        }
    }
}