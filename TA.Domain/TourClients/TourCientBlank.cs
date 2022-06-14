using System;

namespace TA.Domain.TourClients
{
    public class TourClientBlank
    {
        public Guid? Id { get; set; }
        public Guid Id_client { get; set; }
        public Guid? Id_tour { get; set; }
        public TourClientBlank() { }
        public TourClientBlank(Guid? id, Guid id_client, Guid? id_tour)
        {
            Id = id;
            Id_client = id_client;
            Id_tour = id_tour;
        }
    }
}
