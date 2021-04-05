using System;
using System.Collections.Generic;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarImageDal : EfEntityRepositoryBase<CarImage, CarRentalContext>, ICarImageDal
    {
        public List<CarImageDetailDto> GetCarImageDetails()
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from ci in context.CarImages
                             join ca in context.Cars on ci.CarId equals ca.Id
                             join b in context.Brands on ca.BrandId equals b.Id
                             join co in context.Colors on ca.ColorId equals co.Id
                             select new CarImageDetailDto
                             { 
                                 Id = ci.Id, 
                                 BrandName = b.Name, 
                                 ColorName = co.Name, 
                                 ModelYear = ca.ModelYear, 
                                 DailyPrice = ca.DailyPrice, 
                                 Description = ca.Description, 
                                 ImagePath = ci.ImagePath, 
                                 Date = ci.Date 
                             };
                return result.ToList();
            }
        }
    }
}
