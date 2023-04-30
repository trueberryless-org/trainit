using Model.Entities.Assets;

namespace Domain.Repositories.Implementations;

public class ExerciseAssetMuscleAssetRepository : ARepository<ExerciseAssetMuscleAsset>, IExerciseAssetMuscleAssetRepository
{
    public ExerciseAssetMuscleAssetRepository(ModelDbContext context) : base(context)
    {
    }
}