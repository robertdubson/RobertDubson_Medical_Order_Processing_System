﻿using System;
using System.Collections.Generic;
using System.Text;
using DataLayer.UnitOfWork;
using BusinessLogic;
using Mappers;
using System.Linq;
using Services.Abstract;
namespace Services
{
    public class CityService : ICityService
    {
        private readonly IUnitOfWork _unitOfWork;

        private CityMapper _cityMapper;

        private DeliveryCompanyAndCityMapper _deliveryCompanyAndCityMapper;

        public CityService(IUnitOfWork uof, CityMapper mapper, DeliveryCompanyAndCityMapper companyAndCityMapper)
        {
            _unitOfWork = uof;

            _cityMapper = mapper;

            _deliveryCompanyAndCityMapper = companyAndCityMapper;

        }

        public List<City> GetAllCities() 
        {
            return _unitOfWork.CityRepository.GetAll().Select(ct => _cityMapper.FromEntityToDomain(ct)).ToList();
        }

        public List<DeliveryCompanyAndCity> GetAllCompanyAndCity() 
        {
            return _unitOfWork.CompanyAndCityRepository.GetAll().Select(compAndCity => _deliveryCompanyAndCityMapper.FromEntityToDomain(compAndCity)).ToList();
        }

        public City GetCityById(int Id) 
        {
            return _cityMapper.FromEntityToDomain(_unitOfWork.CityRepository.GetByID(Id));
        }
    }
}
