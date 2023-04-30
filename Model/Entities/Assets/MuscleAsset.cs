namespace Model.Entities.Assets;

[Table("MUSCLE_ASSETS")]
public class MuscleAsset
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("MUSCLE_ASSET_ID")]
    public int Id { get; set; }
    
    [Required, StringLength(100)]
    [Column("NAME")] 
    public string Name { get; set; }
    
    public List<ExerciseAssetMuscleAsset> ExerciseAssetMuscleAssets { get; set; }
}