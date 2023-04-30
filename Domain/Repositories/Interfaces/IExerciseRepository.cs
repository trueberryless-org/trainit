using Model.Entities;
using Model.Entities.per_User;

namespace Domain.Repositories.Interfaces;

public interface IExerciseRepository : IRepository<Exercise>
{
    /// <summary>
    /// Returns the exercise with the given id.
    /// </summary>
    /// <param name="exerciseId">Id of the exercise you want</param>
    /// <returns>exercise with the specific exerciseId</returns>
    Task<Exercise> GetExerciseById(int exerciseId, CancellationToken ct = default);

    /// <summary>
    /// Returns the exercise which corresponds to the given activity.
    /// </summary>
    /// <param name="activityId">Id of the activity you want to get the exercise from</param>
    /// <returns>exercise related to activity</returns>
    Task<Exercise> GetExerciseByActivity(int activityId, CancellationToken ct = default);
    
    /// <summary>
    /// Returns all exercises which correspond to the given activities.
    /// </summary>
    /// <param name="activityIds"></param>
    /// <returns></returns>
    Task<List<Exercise>> GetExercisesByActivities(IEnumerable<int> activityIds, CancellationToken ct = default);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    Task<List<Exercise>> GetExercisesByUser(int userId, CancellationToken ct = default);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="workoutId"></param>
    /// <returns></returns>
    Task<List<Exercise>> GetExercisesByWorkout(int workoutId, CancellationToken ct = default);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="workoutId"></param>
    /// <returns></returns>
    Task<List<Exercise>> GetExercisesByUserByWorkout(int userId, int workoutId, CancellationToken ct = default);
}