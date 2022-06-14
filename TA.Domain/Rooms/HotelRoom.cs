using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TA.Domain.Rooms
{
    public class HotelRoom
    {
        public Guid Id { get; }
        public Guid Id_hotel { get; }
        public String Name { get; }
        public int Price { get; }
        public int Count_room { get; }

        public HotelRoom(Guid id, Guid id_hotel, String name, int price, int count_room)
        {
            Id = id;
            Id_hotel = id_hotel;
            Name = name;
            Price = price;
            Count_room = count_room;
        }
    }
}
