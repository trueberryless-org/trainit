using Model.Entities.Assets;

namespace Domain.Repositories.Implementations;

public class MuscleAssetRepository : ARepository<MuscleAsset>, IMuscleAssetRepository
{
    public MuscleAssetRepository(ModelDbContext context) : base(context)
    {
    }
}