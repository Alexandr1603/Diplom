using System;

namespace TA.Domain.TourClients
{
    public class TourClient
    {
        public Guid Id { get; }
        public Guid Id_client { get; }
        public Guid Id_tour { get; }
        public TourClient(Guid id, Guid id_client, Guid id_tour)
        {
            Id = id;
            Id_client = id_client;
            Id_tour = id_tour;
        }
    }
}
