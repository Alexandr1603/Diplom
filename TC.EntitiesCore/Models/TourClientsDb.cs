using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TA.EntitiesCore.Models
{
    [Table("TourClients")]
    public class TourClientsDb
    {
        [Column("id")]
        public Guid Id { get; set; }

        [Column("id_client")]
        public Guid Id_client { get; set; }

        [Column("id_tour")]
        public Guid Id_tour { get; set; }

        public TourClientsDb() { }

        public TourClientsDb(Guid id, Guid id_client, Guid id_tour)
        {
            Id = id;
            Id_client = id_client;
            Id_tour = id_tour;
        }
    }
}
