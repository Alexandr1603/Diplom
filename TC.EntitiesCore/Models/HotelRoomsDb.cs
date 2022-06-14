using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TA.EntitiesCore.Models
{
    [Table("HotelRoom")]
    public class HotelRoomsDb
    {
        [Column("id")]
        public Guid Id { get; set; }

        [Column("id_hotel")]
        public Guid Id_hotel { get; set; }

        [Column("name")]
        public String Name { get; set; }

        [Column("price")]
        public int Price { get; set; }

        [Column("count_room")]
        public int Count_room { get; set; }

        public HotelRoomsDb() { }

        public HotelRoomsDb(Guid id, Guid id_hotel, String name, int price, int count_room)
        {
            Id = id;
            Id_hotel = id_hotel;
            Name = name;
            Price = price;
            Count_room = count_room;
        }
    }
}
