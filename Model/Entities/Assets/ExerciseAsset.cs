namespace Model.Entities.Assets;

[Table("EXERCISE_ASSETS")]
public class ExerciseAsset
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("EXERCISE_ASSET_ID")]
    public int Id { get; set; }
    
    [Required, StringLength(100)]
    [Column("NAME")]
    public string Name { get; set; }
    
    [DataType(DataType.Text)]
    [Column("DESCRIPTION")]
    public string? Description { get; set; }
    
    [Column("MACHINE_ASSET_ID")]
    public int? MachineAssetId { get; set; }
    public MachineAsset? MachineAsset { get; set; }
    
    public List<ExerciseAssetMuscleAsset> ExerciseAssetMuscleAssets { get; set; }
    
    public List<WorkoutAssetExerciseAsset> WorkoutAssetExerciseAssets { get; set; }
}