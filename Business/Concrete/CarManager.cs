using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Business.Abstract;
using Business.Constans;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
         ICarDal _cars;

        public CarManager(ICarDal cars)
        {
            _cars = cars;
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_cars.GetAll(p => p.BrandId == id));
        }

        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(_cars.GetAll(p => p.ColorId == id));
        }

        public IDataResult<List<Car>> GetAll()
        {
            //if (DateTime.Now.Hour==22)
            //{
            //    return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            //}
            return new DataResult<List<Car>>(_cars.GetAll(),true,Messages.InvalidMessage);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_cars.GetCarDetails(),Messages.InvalidMessage);
        }

        public IResult Add(Car car)
        {
            if (car.Description.Length>2 && car.DailyPrice>0)
            {
                _cars.Add(car);
                return new SuccessResult(Messages.ValidMessage);
            }
            return new ErrorResult(Messages.InvalidMessage);
            
        }

        public IResult Delete(Car car)
        {
            _cars.Delete(car);
            return new SuccessResult(Messages.ValidMessage);
        }

        public IResult Update(Car car)
        {
            _cars.Update(car);
            return new SuccessResult(Messages.ValidMessage);
        }
    }
}
