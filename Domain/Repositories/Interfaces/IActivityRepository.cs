using Model.Entities;
using Model.Entities.per_User;

namespace Domain.Repositories.Interfaces;

public interface IActivityRepository : IRepository<Activity>
{
    // TODO ranked system for motivation
    
    /// <summary>
    /// Returns the activity with the given id
    /// </summary>
    /// <param name="activityId">Id of the activity you want</param>
    /// <returns>activity with specific activityId</returns>
    Task<Activity> GetActivityById(int activityId, CancellationToken ct = default);
    
    /// <summary>
    /// Returns all activities which correspond to the user given
    /// </summary>
    /// <param name="userId">Id of the user you want to get the activities from</param>
    /// <returns>all activities from the user with the userId</returns>
    Task<List<Activity>> GetActivitiesByUser(int userId, CancellationToken ct = default);
    
    /// <summary>
    /// Returns you all activities which correspond to the date given
    /// </summary>
    /// <param name="date">value of date you want to get the activities from</param>
    /// <returns>all activities trained on the given date</returns>
    Task<List<Activity>> GetActivitiesByDate(DateOnly date, CancellationToken ct = default);
    
    /// <summary>
    /// Returns you all activities which correspond to the given user and date (AND-GATE)
    /// </summary>
    /// <param name="userId">Id of the user you want to get the activities from</param>
    /// <param name="date">value of date you want to get the activities from</param>
    /// <returns>all activities where user and date conditions are met</returns>
    Task<List<Activity>> GetActivitiesByUserByDate(int userId, DateOnly date, CancellationToken ct = default);

    /// <summary>
    /// Returns the last activity for the exercise given.
    /// </summary>
    /// <param name="exerciseId">Exercise</param>
    /// <returns>Last activity</returns>
    Task<Activity?> GetLastActivityByExercise(int exerciseId, CancellationToken ct = default);
    
    /// <summary>
    /// Returns the last activities for each exercise given.
    /// </summary>
    /// <param name="exerciseIds">List of exercises</param>
    /// <returns>List of last activities</returns>
    Task<List<Activity>> GetLastActivitiesByExercises(IEnumerable<int> exerciseIds, CancellationToken ct = default);

    /// <summary>
    /// Returns a list of dates which are the last days where the user was at the gym.
    /// </summary>
    /// <param name="userId">Id of the user you want the last training days from</param>
    /// <returns>List of DateTime</returns>
    Task<List<DateOnly>> GetLastTrainingDays(int userId, CancellationToken ct = default);
}