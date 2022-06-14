using System;

namespace TA.Domain.Rooms
{
    public class HotelRoomBlank
    {
        public Guid? Id { get; set; }
        public Guid? Id_hotel { get; set; }
        public String Name { get; set; }
        public int Price { get; set; }
        public int Count_room { get; set; }

        public HotelRoomBlank() { }

        public HotelRoomBlank(Guid? id, Guid? id_hotel, String name, int price, int count_room)
        {
            Id = id;
            Id_hotel = id_hotel;
            Name = name;
            Price = price;
            Count_room = count_room;
        }
    }
}
