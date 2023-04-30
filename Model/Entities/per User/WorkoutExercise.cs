namespace Model.Entities.per_User;

[Table("WORKOUT_HAS_EXERCISES_JT")]
public class WorkoutExercise
{
    [Column("EXERCISE_ID")] 
    public int ExerciseId { get; set; }
    public Exercise Exercise { get; set; }
    
    [Column("WORKOUT_ID")] 
    public int WorkoutId { get; set; }
    public Workout Workout { get; set; }
}