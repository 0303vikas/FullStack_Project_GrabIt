using GrabIt.Core.src.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace GrabIt.Infrastructure.src.Database
{
    public class TimeStampInterceptor : SaveChangesInterceptor
    {
        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            var addedEntries = eventData.Context!.ChangeTracker.Entries().Where(e => e.State == EntityState.Added);
            foreach (var entry in addedEntries)
            {
                if (entry.Entity is BaseEntityWithDate refEntity)
                {
                    refEntity.CreatedAt = DateTime.Now;
                    refEntity.UpdatedAt = DateTime.Now;
                }
            }

            var updateEntries = eventData.Context!.ChangeTracker.Entries().Where(e => e.State == EntityState.Modified);
            foreach (var entry in updateEntries)
            {
                if (entry.Entity is BaseEntityWithDate refEntity)
                {
                    refEntity.UpdatedAt = DateTime.Now;
                }
            }

            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }

    }
}