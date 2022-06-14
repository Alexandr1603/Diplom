using System;
using TA.Domain.Results;
using TA.Domain.Hotels;
using TA.EntitiesCore.Repositories;

namespace TA.Services.Hotels
{
    public class HotelsService
    {
        private readonly HotelsRepository _hotelsRepository;

        public HotelsService()
        {
            _hotelsRepository = new HotelsRepository();
        }

        public Hotel? GetHotel(Guid HotelId)
        {
            return _hotelsRepository.GetHotel(HotelId);
        }

        public Hotel? GetHotel(String HotelName)
        {
            return _hotelsRepository.GetHotel(HotelName);
        }

        public Hotel[] GetAllHotels()
        {
            return _hotelsRepository.GetAllHotels();
        }
        public void DeleteHotel(Guid HotelId)
        {
            _hotelsRepository.DeleteHotel(HotelId);
        }
        public Hotel[] GetCityHotels(Guid cityId)
        {
            return _hotelsRepository.GetCityHotels(cityId);
        }
        public Result SaveHotelEntry(HotelBlank blank)
        {
            if (blank.Name == "") throw new Exception("Введите название");
            if (blank.Stars == 0) throw new Exception("Дайте оценку отелю");
            if (blank.Id is null) blank.Id = Guid.NewGuid();

            _hotelsRepository.SaveHotelEntry(blank);
            return Result.Success();
        }
    }
}
