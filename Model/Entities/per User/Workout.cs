using Model.Entities.Authentication;

namespace Model.Entities.per_User;

[Table("WORKOUTS")]
public class Workout
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("WORKOUT_ID")]
    public int Id { get; set; }
    
    [Required, StringLength(100)]
    [Column("NAME")] 
    public string Name { get; set; }
    
    [DataType(DataType.Text)]
    [Column("DESCRIPTION")]
    public string? Description { get; set; }
    
    [Required]
    [Column("USER_ID")]
    public int UserId { get; set; }
    
    public User User { get; set; }
    
    public List<WorkoutExercise> WorkoutExercises { get; set; }

    [NotMapped]
    public bool IsSelected { get; set; }
    
}