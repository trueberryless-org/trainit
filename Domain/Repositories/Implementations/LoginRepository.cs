using Model.Entities.Log;

namespace Domain.Repositories.Implementations;

public class LoginRepository : ARepository<Login>, ILoginRepository
{
    public LoginRepository(ModelDbContext context) : base(context)
    {
    }
}