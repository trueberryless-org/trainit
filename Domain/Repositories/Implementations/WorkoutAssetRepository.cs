using Model.Entities.Assets;

namespace Domain.Repositories.Implementations;

public class WorkoutAssetRepository : ARepository<WorkoutAsset>, IWorkoutAssetRepository
{
    public WorkoutAssetRepository(ModelDbContext context) : base(context)
    {
    }
}