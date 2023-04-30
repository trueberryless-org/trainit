namespace Model.Entities.Assets;

[Table("EXERCISE_ASSET_HAS_MUSCLE_ASSETS_JT")]
public class ExerciseAssetMuscleAsset
{
    [Column("EXERCISE_ASSET_ID")] 
    public int ExerciseAssetId { get; set; }
    public ExerciseAsset ExerciseAsset { get; set; }
    
    [Column("MUSCLE_ASSET_ID")] 
    public int MuscleAssetId { get; set; }
    public MuscleAsset MuscleAsset { get; set; }
}