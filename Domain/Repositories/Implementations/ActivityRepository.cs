using Domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Model.Entities;
using Model.Entities.per_User;
using MudBlazor;

namespace Domain.Repositories.Implementations;

public class ActivityRepository : ARepository<Activity>, IActivityRepository
{
    public ActivityRepository(ModelDbContext context) : base(context) { }


    public async Task<Activity> GetActivityById(int activityId, CancellationToken ct = default)
    {
        return await Table
            .Where(s => s.Id == activityId)
            .FirstAsync(cancellationToken: ct);
    }

    public async Task<List<Activity>> GetActivitiesByUser(int userId, CancellationToken ct = default)
    {
        return await Table
            .Include(s => s.Exercise)
            .Where(s => s.Exercise.UserId == userId)
            .ToListAsync(cancellationToken: ct);
    }

    public async Task<List<Activity>> GetActivitiesByDate(DateTime datetime, CancellationToken ct = default)
    {
        return await Table
            .Include(s => s.Exercise)
            .Where(s => s.DateValue == DateOnly.FromDateTime(datetime))
            .ToListAsync(cancellationToken: ct);
    }

    public async Task<List<Activity>> GetActivitiesByUserByDate(int userId, DateTime datetime, CancellationToken ct = default)
    {
        return await Table
            .Where(s => s.DateValue == DateOnly.FromDateTime(datetime))
            .Include(s => s.Exercise)
            .Where(s => s.Exercise.UserId == userId)
            .ToListAsync(cancellationToken: ct);
    }

    public async Task<Activity?> GetLastActivityByExercise(int exerciseId, CancellationToken ct = default)
    {
        return await
            (from exercise in Context.Set<Exercise>()
                join activity in Context.Set<Activity>()
                    on exercise.Id equals activity.ExerciseId
                where exerciseId == activity.ExerciseId
                where activity.DateValue == (
                    from activity2 in Context.Set<Activity>()
                    where activity2.ExerciseId == exercise.Id
                    select activity2.DateValue
                ).Max()
                select activity
            ).FirstOrDefaultAsync(cancellationToken: ct);
    }
    
    public async Task<List<Activity>> GetLastActivitiesByExercises(IEnumerable<int> exerciseIds, CancellationToken ct = default)
    {
        return await
            (from exercise in Context.Set<Exercise>()
                join activity in Context.Set<Activity>()
                    on exercise.Id equals activity.ExerciseId
                where exerciseIds.Contains(activity.ExerciseId)
                where activity.DateValue == (
                    from activity2 in Context.Set<Activity>()
                    where activity2.ExerciseId == exercise.Id
                    select activity2.DateValue
                ).Max()
                select activity
            ).ToListAsync(cancellationToken: ct);
    }

    public async Task<List<DateOnly>> GetLastTrainingDays(int userId, CancellationToken ct = default)
    {
        return await
            Context.Activities
                .Join(Context.Exercises,
                    a => a.ExerciseId,
                    e => e.Id,
                    (a, e) => new { Activity = a, Exercise = e })
                .Where(ae => ae.Exercise.UserId == userId)
                .GroupBy(ae => ae.Activity.DateValue)
                .OrderByDescending(ae => ae.Key)
                .Take(4)
                .Select(ae => ae.Key)
                .ToListAsync(cancellationToken: ct);

    }

    public async Task<List<Activity>> GetAllActivitiesWithExercises(CancellationToken ct = default)
    {
        return await Table.Include(a => a.Exercise).ToListAsync(cancellationToken: ct);
    }
}