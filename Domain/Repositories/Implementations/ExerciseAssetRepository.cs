using Model.Entities.Assets;

namespace Domain.Repositories.Implementations;

public class ExerciseAssetRepository : ARepository<ExerciseAsset>, IExerciseAssetRepository
{
    public ExerciseAssetRepository(ModelDbContext context) : base(context)
    {
    }
}