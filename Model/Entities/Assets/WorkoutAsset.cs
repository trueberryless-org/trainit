namespace Model.Entities.Assets;

[Table("WORKOUT_ASSETS")]
public class WorkoutAsset
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("WORKOUT_ASSET_ID")]
    public int Id { get; set; }
    
    [Required, StringLength(100)]
    [Column("NAME")] 
    public string Name { get; set; }
    
    [DataType(DataType.Text)]
    [Column("DESCRIPTION")]
    public string? Description { get; set; }
    
    public List<WorkoutAssetExerciseAsset> WorkoutAssetExerciseAssets { get; set; }
}