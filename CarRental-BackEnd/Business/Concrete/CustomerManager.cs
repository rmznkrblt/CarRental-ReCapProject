﻿using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constans;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

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

        [ValidationAspect(typeof(CustomerValidator))]
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

        public IDataResult<List<CustomerDetailDto>> GetCustomerDetails()
        {
            return new SuccessDataResult<List<CustomerDetailDto>>(_customer.GetCustomerDetails());
        }
    }
}
