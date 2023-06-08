using Model.Entities.Authentication;
using Model.Entities.Authentication.Models;
using Model.Entities.Log;

namespace Domain.Repositories.Implementations;

public class UserRepository : ARepository<User>, IUserRepository {
    private readonly ILoginRepository _loginRepository;

    public UserRepository(ModelDbContext context, ILoginRepository loginRepository) : base(context)
    {
        _loginRepository = loginRepository;
    }


    public async Task<User?> FindByEmailAsync(string email, CancellationToken ct = default) {
        var user = await Table
            .Include(u => u.RoleClaims)
            .ThenInclude(rc => rc.Role)
            .AsSplitQuery() // <--- this is the magic
            .FirstOrDefaultAsync(u => u.Email == email, ct);

        return user?.ClearSensitiveData();
    }

    public async Task<User?> AuthorizeAsync(int id, CancellationToken ct = default) {
        var user = await Table
            .Include(u => u.RoleClaims)
            .ThenInclude(rc => rc.Role)
            .AsSplitQuery() // <--- this is the magic
            .FirstOrDefaultAsync(u => u.Id == id, ct);

        return user?.ClearSensitiveData();
    }

    public Task<User?> AuthorizeAsync(string token, CancellationToken ct = default) {
        throw new NotImplementedException("Bababum");
/*
        var user = await Table
            .Include(u => u.RoleClaims)
            .ThenInclude(rc => rc.Role)
            .AsSplitQuery() // <--- this is the magic
            .FirstOrDefaultAsync(u => false, ct);
        
        return user?.ClearSensitiveData();
*/
    }

    public async Task<User?> AuthorizeAsync(LoginModel model, CancellationToken ct = default) {
        var user = await Table
            .Include(u => u.RoleClaims)
            .ThenInclude(rc => rc.Role)
            .AsSplitQuery() // <--- this is the magic
            .FirstOrDefaultAsync(u => u.Email == model.Email, ct);

        if (user is null) return null;

        if (!User.VerifyPassword(model.Password, user.PasswordHash))
        {
            await _loginRepository.CreateAsync(new Login()
            {
                User = user,
                LoginStatus = ELoginStatus.WRONG_PASSWORD,
                DateTime = DateTime.Now
            }, ct);
            return null!;
        }
        
        await _loginRepository.CreateAsync(new Login()
        {
            User = user,
            LoginStatus = ELoginStatus.SUCCESS,
            DateTime = DateTime.Now
        }, ct);

        return user.ClearSensitiveData();
    }
    
    public async Task UpdateInfoAsync(User user, CancellationToken ct = default) {
        // check if email is already taken
        var emailExists = await Table.AnyAsync(u => u.Email == user.Email && u.Id != user.Id, ct);
        if (emailExists) throw new DuplicateEmailException();

        // update user
        await UpdateAsync(user, ct);
    }
    
}