using System;
using System.Collections.Generic;
using TA.Domain.Customers;
using TA.Domain.Results;
using TA.Domain.TourClients;
using TA.EntitiesCore.Repositories;

namespace TA.Services.TourClientsService
{
    public class TourClientsService
    {
        private readonly TourClientsRepository _tourClientsRepository;

        public TourClientsService()
        {
            _tourClientsRepository = new TourClientsRepository();
        }
        public TourClient[] GetTourClients(Guid tourId)
        {
            return _tourClientsRepository.GetTourClients(tourId);
        }
        public void DeleteTourClient(Guid roomId)
        {
            _tourClientsRepository.DeleteTourClient(roomId);
        }
        public Result SaveTourClientEntry(List<TourClientBlank> blanks, Guid tourId)
        {
            foreach (var blank in blanks)
            {
                blank.Id_tour = tourId;
                if (blank.Id is null) blank.Id = Guid.NewGuid();

                _tourClientsRepository.SaveTourClientEntry(blank);
            }
            return Result.Success();
        }
    }
}
