using Model.Entities.Assets;

namespace Domain.Repositories.Implementations;

public class WorkoutAssetExerciseAssetRepository : ARepository<WorkoutAssetExerciseAsset>, IWorkoutAssetExerciseAssetRepository
{
    public WorkoutAssetExerciseAssetRepository(ModelDbContext context) : base(context)
    {
    }
}