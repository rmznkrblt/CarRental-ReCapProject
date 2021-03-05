using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constans;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        ICarService _carService;

        public CarImageManager(ICarImageDal carImageDal, ICarService carServiceDal)
        {
            _carImageDal = carImageDal;
            _carService = carServiceDal;
        }

        public IResult Update(CarImage carImage)
        {
            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.ValidMessage);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new DataResult<List<CarImage>>(_carImageDal.GetAll(), true, Messages.InvalidMessage);
        }

        public IDataResult<List<CarImage>> GetCarImagesById(int id)
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarId == id), Messages.ValidMessage);
        }

        public IDataResult<CarImage> GetById(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.Id == id));
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckIfCarExists(carImage.CarId), CheckCarImageLimit(carImage.CarId));

            if (result != null)
            {
                return result;
            }
            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.ValidMessage);
        }

        public IResult Delete(CarImage carImage)
        {
            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.ValidMessage);
        }

        private IResult CheckCarImageLimit(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId);
            if (result.Count > 4)
            {
                return new ErrorResult(Messages.CarImageLimitExceeded);
            }

            return new SuccessResult();

        }

        private IResult CheckIfCarExists(int carId)
        {
            var result = _carService.GetById(carId).Success;
            if (result)
            {
                return new SuccessResult();
            }
            return new ErrorResult(Messages.CarNotExists);
        }
    }
}
