using System;
using TA.Domain.Results;
using TA.Domain.Countries;
using TA.EntitiesCore.Repositories;

namespace TA.Services.Countries
{
    public class CountriesService
    {
        private readonly CountriesRepository _countriesRepository;

        public CountriesService()
        {
            _countriesRepository = new CountriesRepository();
        }

        public Country? GetCountry(Guid CountryId)
        {
            return _countriesRepository.GetCountry(CountryId);
        }

        public Country? GetCountry(String CountryName)
        {
            return _countriesRepository.GetCountry(CountryName);
        }

        public Country[] GetAllCountries()
        {
            return _countriesRepository.GetAllCountries();
        }
        public void DeleteCountry(Guid workerId)
        {
            _countriesRepository.DeleteCountry(workerId);
        }
        public Result SaveCountryEntry(CountryBlank blank)
        {
            if (blank.Name == "") throw new Exception("Введите название");
            if (blank.Id is null) blank.Id = Guid.NewGuid();

            _countriesRepository.SaveCountryEntry(blank);
            return Result.Success();
        }
    }
}