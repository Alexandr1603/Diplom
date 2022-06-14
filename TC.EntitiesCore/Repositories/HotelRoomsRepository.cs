using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using TA.Domain.Rooms;
using TA.EntitiesCore.Models;
using TA.EntitiesCore.Models.Converters;

namespace TA.EntitiesCore.Repositories
{
    public class HotelRoomsRepository : BaseRepository
    {
        public HotelRoom? GetHotelRoom(Guid roomId)
        {
            return UseContext(context =>
            {
                return context.HotelRooms.FirstOrDefault(c => c.Id == roomId)?.ToHotelRoom();
            });
        }

        public HotelRoom[] GetAllHotelRooms()
        {
            return UseContext(context =>
            {
                return context.HotelRooms.ToHotelRooms();
            });
        }
        public void DeleteHotelRoom(Guid roomId)
        {
            UseContext(context =>
            {
                HotelRoomsDb db = context.HotelRooms.FirstOrDefault(ce => ce.Id == roomId);
                if (db is null) return;

                context.HotelRooms.Remove(db);
                context.Entry(db).State = EntityState.Deleted;
                context.SaveChanges();
            });
        }
        public HotelRoom[] GetRoomsHotel(Guid hotelId)
        {
            return UseContext(context =>
            {
                return context.HotelRooms.Where(c => c.Id_hotel == hotelId).ToHotelRooms();
            });
        }
        public void SaveHotelRoomEntry(HotelRoomBlank entryBlank)
        {
            UseContext(context =>
            {
                HotelRoomsDb db = entryBlank.ToDb();
                HotelRoomsDb existEntry = context.HotelRooms.FirstOrDefault(ce => ce.Id == db.Id);
                if (existEntry is null)
                {
                    context.HotelRooms.Add(db);
                    context.Entry(db).State = EntityState.Added;
                    context.SaveChanges();
                }
                else
                {
                    existEntry.Name = db.Name;
                    existEntry.Id_hotel = db.Id_hotel;
                    existEntry.Price = db.Price;
                    existEntry.Count_room = db.Count_room;
                    context.Entry(existEntry).State = EntityState.Modified;
                    context.SaveChanges();
                }
            });
        }
    }
}
