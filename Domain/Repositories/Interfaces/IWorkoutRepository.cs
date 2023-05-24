using Model.Entities;
using Model.Entities.per_User;

namespace Domain.Repositories.Interfaces;

public interface IWorkoutRepository : IRepository<Workout>
{
    // TODO share workouts
    
    Task<Workout> GetWorkoutById(int workoutId, CancellationToken ct = default);
    Task<List<Workout>> GetWorkoutsByUser(int userId, CancellationToken ct = default);
    Task<List<Workout>> GetWorkoutsByExercise(int exerciseId, CancellationToken ct = default);
}