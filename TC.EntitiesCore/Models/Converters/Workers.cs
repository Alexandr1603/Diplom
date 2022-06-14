using System.Collections.Generic;
using System.Linq;
using TA.Domain.Workers;

namespace TA.EntitiesCore.Models.Converters
{
    internal static class Workers
    {
        internal static Worker ToWorker(this WorkersDb db)
        {
            return new(db.Id, db.Login, db.Password, db.Role);
        }

        internal static Worker[] ToWorkers(this IEnumerable<WorkersDb> dbs)
        {
            return dbs.Select(ToWorker).ToArray();
        }

        internal static WorkersDb ToDb(this WorkerBlank blank)
        {
            return new WorkersDb(blank.Id.Value, blank.Login, blank.Password, blank.Role);
        }
    }
}