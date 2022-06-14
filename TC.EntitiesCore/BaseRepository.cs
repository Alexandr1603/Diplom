using System;

namespace TA.EntitiesCore
{
    public abstract class BaseRepository
    {
        internal void UseContext(Action<TouristAgencyContext> action)
        {
            using (TouristAgencyContext _context = new())
            {
                action(_context);
            }
        }

        internal T UseContext<T>(Func<TouristAgencyContext, T> action)
        {
            using (TouristAgencyContext _context = new())
            {
                T result = action(_context);
                return result;
            }
        }
    }
}
