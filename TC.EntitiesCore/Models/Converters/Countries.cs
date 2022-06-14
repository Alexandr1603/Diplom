using System.Collections.Generic;
using System.Linq;
using TA.Domain.Countries;

namespace TA.EntitiesCore.Models.Converters
{
    internal static class Countries
    {
        internal static Country ToCountry(this CountriesDb db)
        {
            return new(db.Id, db.Name);
        }

        internal static Country[] ToCountries(this IEnumerable<CountriesDb> dbs)
        {
            return dbs.Select(ToCountry).ToArray();
        }

        internal static CountriesDb ToDb(this CountryBlank blank)
        {
            return new CountriesDb(blank.Id.Value, blank.Name);
        }
    }
}