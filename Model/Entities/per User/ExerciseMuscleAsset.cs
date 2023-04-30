using Model.Entities.Assets;

namespace Model.Entities.per_User;

[Table("EXERCISE_HAS_MUSCLE_ASSETS_JT")]
public class ExerciseMuscleAsset
{
    [Column("EXERCISE_ID")] 
    public int ExerciseId { get; set; }
    public Exercise Exercise { get; set; }
    
    [Column("MUSCLE_ASSET_ID")] 
    public int MuscleAssetId { get; set; }
    public MuscleAsset MuscleAsset { get; set; }
}