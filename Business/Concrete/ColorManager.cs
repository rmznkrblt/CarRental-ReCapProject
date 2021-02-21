using System;
using System.Collections.Generic;
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
    public class ColorManager:IColorService
    {
        IColorDal _color;

        public ColorManager(IColorDal color)
        {
            _color = color;
        }

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_color.GetAll(),Messages.ValidMessage);
        }

        public IResult Add(Color color)
        {
            _color.Add(color);
            return new SuccessResult(Messages.InvalidMessage);
        }

        public IResult Delete(Color color)
        {
            _color.Delete(color);
            return new SuccessResult(Messages.InvalidMessage);
        }

        public IResult Update(Color color)
        {
            _color.Update(color);
            return new SuccessResult(Messages.InvalidMessage);
        }
    }
}
