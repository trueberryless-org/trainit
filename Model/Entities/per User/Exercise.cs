using Model.Entities.Assets;
using Model.Entities.Authentication;

namespace Model.Entities.per_User;

[Table("EXERCISES")]
public class Exercise
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("EXERCISE_ID")]
    public int Id { get; set; }
    
    [Required, StringLength(100)]
    [Column("NAME")]
    public string Name { get; set; }
    
    [Column("MACHINE_ASSET_ID")]
    public int? MachineAssetId { get; set; }
    public MachineAsset? MachineAsset { get; set; }
    
    [DataType(DataType.Text)]
    [Column("DESCRIPTION")]
    public string? Description { get; set; }

    [Required]
    [Column("USER_ID")]
    public int UserId { get; set; }
    public User User { get; set; }
    
    public List<WorkoutExercise> WorkoutExercises { get; set; }
    public List<Activity> Activities { get; set; }
    public List<ExerciseMuscleAsset> ExerciseMuscleAssets { get; set; }

    [NotMapped]
    public bool IsSelected { get; set; }
    
    
}