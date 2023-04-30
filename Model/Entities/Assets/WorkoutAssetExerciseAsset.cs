namespace Model.Entities.Assets;

[Table("WORKOUT_ASSET_HAS_EXERCISE_ASSETS_JT")]
public class WorkoutAssetExerciseAsset
{
    [Column("EXERCISE_ASSET_ID")] 
    public int ExerciseAssetId { get; set; }
    public ExerciseAsset ExerciseAsset { get; set; }
    
    [Column("WORKOUT_ASSET_ID")] 
    public int WorkoutAssetId { get; set; }
    public WorkoutAsset WorkoutAsset { get; set; }
}