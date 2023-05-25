using Domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Model.Entities;
using Model.Entities.per_User;

namespace Domain.Repositories.Implementations;

public class WorkoutRepository : ARepository<Workout>, IWorkoutRepository
{
    public WorkoutRepository(ModelDbContext context) : base(context)
    {
    }

    public async Task<Workout> GetWorkoutById(int workoutId, CancellationToken ct = default)
    {
        return await Table
            .Where(p => p.Id == workoutId)
            .FirstAsync(cancellationToken: ct);
    }

    public async Task<List<Workout>> GetWorkoutsByUser(int userId, CancellationToken ct = default)
    {
        return await Table
            .Where(w => w.UserId == userId)
            .Include(w => w.WorkoutExercises)
            .ThenInclude(we => we.Exercise)
            .ToListAsync(cancellationToken: ct);
    }

    public async Task<List<Workout>> GetWorkoutsByExercise(int exerciseId, CancellationToken ct = default)
    {
        return await
            (Context.Set<Workout>()
                .Join(Context.Set<WorkoutExercise>(), workout => workout.Id, workoutExercise => workoutExercise.WorkoutId,
                    (workout, workoutExercise) => new { workout = workout, workoutExercise = workoutExercise })
                .Join(Context.Set<Exercise>(), @t => @t.workoutExercise.ExerciseId, exercise => exercise.Id,
                    (@t, exercise) => new { @t, exercise })
                .Where(@t => @t.exercise.Id == exerciseId)
                .Select(@t => @t.@t.workout))
            .ToListAsync(cancellationToken: ct);
    }
}