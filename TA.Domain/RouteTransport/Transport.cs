using System;
using System.ComponentModel.DataAnnotations;

namespace TA.Domain.RouteTransport
{
    public enum Transport
    {
        Bus = 1,
        Train = 2,
        Plane = 3
    }
    public static class TransportExtensions
    {
        public static String GetDisplayName(this Transport transport)
        {
            switch (transport)
            {
                case Transport.Bus: return "Автобус";
                case Transport.Train: return "Поезд";
                case Transport.Plane: return "Самолет";

                default: throw new Exception("Транспорт не найден");
            }
        }
    }
}