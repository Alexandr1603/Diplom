using System;
using TA.Domain.Results;
using TA.Domain.Rooms;
using TA.EntitiesCore.Repositories;

namespace TA.Services.HotelRooms
{
    public class HotelRoomsService
    {
        private readonly HotelRoomsRepository _hotelRoomsRepository;

        public HotelRoomsService()
        {
            _hotelRoomsRepository = new HotelRoomsRepository();
        }

        public HotelRoom? GetHotelRoom(Guid roomId)
        {
            return _hotelRoomsRepository.GetHotelRoom(roomId);
        }

        public HotelRoom[] GetRoomsHotel(Guid hotelId)
        {
            return _hotelRoomsRepository.GetRoomsHotel(hotelId);
        }

        public HotelRoom[] GetAllHotelRooms()
        {
            return _hotelRoomsRepository.GetAllHotelRooms();
        }
        public void DeleteHotelRoom(Guid roomId)
        {
            _hotelRoomsRepository.DeleteHotelRoom(roomId);
        }
        public Result SaveHotelRoomEntry(HotelRoomBlank blank)
        {
            if (blank.Name == "") throw new Exception("Введите имя");
            if (blank.Count_room == 0) throw new Exception("Введите кол-во комнат");
            if (blank.Price == 0) throw new Exception("Введите цену номера");
            if (blank.Id is null) blank.Id = Guid.NewGuid();

            _hotelRoomsRepository.SaveHotelRoomEntry(blank);
            return Result.Success();
        }
    }
}
