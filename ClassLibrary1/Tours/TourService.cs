using System;
using System.Collections.Generic;
using TA.Domain.Customers;
using TA.Domain.Results;
using TA.Domain.Routes;
using TA.Domain.Tours;
using TA.EntitiesCore.Repositories;

namespace TA.Services
{
    public class TourService
    {
        private readonly TourRepository _tourRepository;

        public TourService()
        {
            _tourRepository = new TourRepository();
        }

        public Tour? GetTour(Guid TourId)
        {
            return _tourRepository.GetTour(TourId);
        }

        public Tour? GetTour(String TourName)
        {
            return _tourRepository.GetTour(TourName);
        }

        public Tour[] GetAllTours()
        {
            return _tourRepository.GetAllTours();
        }
        public void DeleteTour(Guid TourId)
        {
            _tourRepository.DeleteTour(TourId);
        }
        public Tour[] GetWorkerTours(Guid workerId)
        {
            return _tourRepository.GetWorkerTours(workerId);
        }
        public Result SaveTourEntry(TourBlank blank)
        {
            if (blank.Name == "") throw new Exception("Введите название");
            if (blank.Price == 0) throw new Exception("Заполните тур");
            if (blank.Id is null) blank.Id = Guid.NewGuid();

            _tourRepository.SaveTourEntry(blank);
            return Result.Success();
        }
    }
}
