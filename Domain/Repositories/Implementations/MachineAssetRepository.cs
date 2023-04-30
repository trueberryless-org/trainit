using Model.Entities.Assets;

namespace Domain.Repositories.Implementations;

public class MachineAssetRepository : ARepository<MachineAsset>, IMachineAssetRepository
{
    public MachineAssetRepository(ModelDbContext context) : base(context)
    {
    }
}