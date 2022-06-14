using System;
using TA.Domain.Results;
using TA.Domain.Cities;
using TA.EntitiesCore.Repositories;

namespace TA.Services.Cities
{
    public class CitiesService
    {
        private readonly CitiesRepository _citiesRepository;

        public CitiesService()
        {
            _citiesRepository = new CitiesRepository();
        }

        public City? GetCity(Guid CityId)
        {
            return _citiesRepository.GetCity(CityId);
        }

        public City? GetCity(String CityName)
        {
            return _citiesRepository.GetCity(CityName);
        }

        public City[] GetAllCities()
        {
            return _citiesRepository.GetAllCities();
        }
        public void DeleteCity(Guid CityId)
        {
            _citiesRepository.DeleteCity(CityId);
        }
        public City[] GetCountryCities(Guid countryId)
        {
            return _citiesRepository.GetCountryCities(countryId);
        }
        public Result SaveCountryEntry(CityBlank blank)
        {
            if (blank.Name == "") throw new Exception("Введите название");
            if (blank.Width == null) throw new Exception("Введите широту");
            if (blank.Long == null) throw new Exception("Введите долготу");
            if (blank.Id is null) blank.Id = Guid.NewGuid();

            _citiesRepository.SaveCityEntry(blank);
            return Result.Success();
        }
    }
}
