using Domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Model.Entities;
using Model.Entities.per_User;

namespace Domain.Repositories.Implementations;

public class ExerciseRepository : ARepository<Exercise>, IExerciseRepository
{
    public ExerciseRepository(ModelDbContext context) : base(context)
    {
    }

    public async Task<Exercise> GetExerciseById(int exerciseId, CancellationToken ct = default)
    {
        return await Table
            .Where(e => e.Id == exerciseId)
            .FirstAsync(cancellationToken: ct);
    }

    public async Task<Exercise> GetExerciseByActivity(int activityId, CancellationToken ct = default)
    {
        return await Context.Set<Exercise>()
            .Join(Context.Set<Activity>(), exercise => exercise.Id, activity => activity.ExerciseId,
                (exercise, activity) => new { exercise, activity = activity })
            .Where(@t => @t.activity.Id == activityId)
            .Select(@t => @t.exercise)
            .FirstAsync(cancellationToken: ct);
    }

    public async Task<List<Exercise>> GetExercisesByActivities(IEnumerable<int> activityIds,
        CancellationToken ct = default)
    {
        return await Context.Set<Exercise>()
            .Join(Context.Set<Activity>(), exercise => exercise.Id, activity => activity.ExerciseId,
                (exercise, activity) => new { exercise, activity = activity })
            .Where(@t => activityIds.Contains(@t.activity.Id))
            .Select(@t => @t.exercise)
            .ToListAsync(cancellationToken: ct);
    }

    public async Task<List<Exercise>> GetExercisesByUser(int userId, CancellationToken ct = default)
    {
        return await Table
            .Include(e => e.User)
            .Where(e => e.User.Id == userId)
            .ToListAsync(cancellationToken: ct);
    }

    public async Task<List<Exercise>> GetExercisesByWorkout(int workoutId, CancellationToken ct = default)
    {
        return await Context.Set<Exercise>()
            .Join(Context.Set<WorkoutExercise>(), exercise => exercise.Id,
                workoutExercise => workoutExercise.ExerciseId,
                (exercise, workoutExercise) => new { exercise, workoutExercise })
            .Where(@t => @t.workoutExercise.WorkoutId == workoutId)
            .Select(@t => @t.exercise)
            .ToListAsync(cancellationToken: ct);
    }

    public async Task<List<Exercise>> GetExercisesByUserByWorkout(int userId, int workoutId,
        CancellationToken ct = default)
    {
        return await Context.Set<Exercise>()
            .Join(Context.Set<WorkoutExercise>(), exercise => exercise.Id,
                workoutExercise => workoutExercise.ExerciseId,
                (exercise, workoutExercise) => new { exercise, workoutExercise = workoutExercise })
            .Join(Context.Set<Workout>(), @t => @t.workoutExercise.ExerciseId, workout => workout.Id,
                (@t, workout) => new { @t, workout = workout })
            .Where(@t => @t.workout.Id == workoutId)
            .Where(@t => @t.@t.exercise.UserId == userId)
            .Select(@t => @t.@t.exercise)
            .ToListAsync(cancellationToken: ct);
    }
}