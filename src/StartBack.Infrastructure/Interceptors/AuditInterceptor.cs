// AuditInterceptor.cs
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using StartBack.Domain.Interfaces;
using StartBack.Infrastructure.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;


namespace StartBack.Infrastructure.Interceptors
{
    public class AuditInterceptor : SaveChangesInterceptor
    {
        private readonly ICurrentUserService _currentUserService;

        public AuditInterceptor(ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;
        }

        public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
        {
            ApplyAuditRules(eventData.Context);
            return base.SavingChanges(eventData, result);
        }

        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
            DbContextEventData eventData,
            InterceptionResult<int> result,
            CancellationToken cancellationToken = default)
        {
            ApplyAuditRules(eventData.Context);
            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }

        private void ApplyAuditRules(DbContext context)
        {
            if (context == null) return;

            var currentUserId = _currentUserService.Username ?? "system";
            var currentTime = DateTime.Now;


            foreach (var entry in context.ChangeTracker.Entries())
            {
                if (entry.State == EntityState.Added)
                {
                    if (entry.Entity is IAuditableEntity auditableEntity)
                    {
                        auditableEntity.CreatedAt = currentTime;
                        auditableEntity.CreatedBy = currentUserId;
                    }
                }
                else if (entry.State == EntityState.Modified)
                {
                    if (entry.Entity is IAuditableEntity auditableEntity)
                    {
                        auditableEntity.UpdatedAt = currentTime;
                        auditableEntity.UpdatedBy = currentUserId;
                    }

                    if (entry.Entity is ISoftDeletable softDeletable && softDeletable.IsDeleted)
                    {
                        softDeletable.DeletedAt = currentTime;
                        softDeletable.DeletedBy = currentUserId;
                    }
                }
            }
        }
    }
}