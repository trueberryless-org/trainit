namespace Model.Entities.Assets;

[Table("MACHINE_ASSETS")]
public class MachineAsset
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("MACHINE_ASSET_ID")]
    public int Id { get; set; }
    
    [Required, StringLength(100)]
    [Column("NAME")]
    public string Name { get; set; }
    
    public List<ExerciseAsset> ExerciseAssets { get; set; }
}