using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constans;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customer;

        public CustomerManager(ICustomerDal customer)
        {
            _customer = customer;
        }

        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customer.GetAll(), Messages.ValidMessage);
        }

        public IResult Add(Customer customer)
        {
            _customer.Add(customer);
            return new SuccessResult(Messages.InvalidMessage);
        }

        public IResult Delete(Customer customer)
        {
            _customer.Delete(customer);
            return new SuccessResult(Messages.InvalidMessage);
        }

        public IResult Update(Customer customer)
        {
            _customer.Update(customer);
            return new SuccessResult(Messages.InvalidMessage);
        }
    }
}
