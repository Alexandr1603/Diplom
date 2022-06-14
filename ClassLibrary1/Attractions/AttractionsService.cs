using System;
using TA.Domain.Results;
using TA.Domain.Attractions;
using TA.EntitiesCore.Repositories;

namespace TA.Services.Attractions
{
    public class AttractionsService
    {
        private readonly AttractionsRepository _attractionsRepository;

        public AttractionsService()
        {
            _attractionsRepository = new AttractionsRepository();
        }

        public Attraction? GetAttraction(Guid AttractionId)
        {
            return _attractionsRepository.GetAttraction(AttractionId);
        }

        public Attraction? GetAttraction(String AttractionName)
        {
            return _attractionsRepository.GetAttraction(AttractionName);
        }

        public Attraction[] GetAllAttractions()
        {
            return _attractionsRepository.GetAllAttractions();
        }
        public void DeleteAttraction(Guid AttractionId)
        {
            _attractionsRepository.DeleteAttraction(AttractionId);
        }
        public Attraction[] GetCityAttractions(Guid attractionId)
        {
            return _attractionsRepository.GetCityAttractions(attractionId);
        }
        public Result SaveAttractionEntry(AttractionBlank blank)
        {
            if (blank.Name == "") throw new Exception("Введите название");
            if (blank.Id is null) blank.Id = Guid.NewGuid();

            _attractionsRepository.SaveAttractionEntry(blank);
            return Result.Success();
        }
    }
}
