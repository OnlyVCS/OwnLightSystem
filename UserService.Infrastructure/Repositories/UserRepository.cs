using Microsoft.EntityFrameworkCore;
using UserService.Domain.Entities;
using UserService.Domain.Interfaces;
using UserService.Infrastructure.Data;

namespace UserService.Infrastructure.Repositories;

public class UserRepository(DataContext context) : IUserRepository
{
    private readonly DbSet<User> _dbSet = context.Set<User>();

    public async Task<int> CountAsync() => await _dbSet.CountAsync();

    public async Task<IEnumerable<User>> FindAllAsync(int page, int pageSize)
    {
        var skipAmount = (page - 1) * pageSize;
        return await _dbSet.Skip(skipAmount).Take(pageSize).ToListAsync();
    }

    public async Task<User?> FindByIdAsync(Guid id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task<User?> FindByUserNameAsync(string userName)
        => await _dbSet.FirstOrDefaultAsync(u => u.UserName == userName);

    public async Task<User> RegisterAsync(User user)
    {
        await _dbSet.AddAsync(user);
        await context.SaveChangesAsync();
        return user;
    }

    public async Task<User?> UpdateAsync(User user)
    {
        _dbSet.Update(user);
        await context.SaveChangesAsync();
        return user;
    }

    public Task<User?> UpdatePasswordAsync(Guid id, string password)
    {
        var user = _dbSet.Find(id);
        if (user != null)
        {
            user.UpdatePassword(password);
            return UpdateAsync(user);
        }
        return Task.FromResult<User?>(null);
    }

    public async Task<User?> DeleteAsync(Guid id)
    {
        var user = await _dbSet.FindAsync(id);
        if (user is null)
            return null;
        _dbSet.Remove(user);
        await context.SaveChangesAsync();
        return user;
    }

    public async Task<User> DeleteAllAsync()
    {
        var users = await _dbSet.ToListAsync();
        foreach (var user in users)
        {
            _dbSet.Remove(user);
        }
        await context.SaveChangesAsync();
        return users.FirstOrDefault();
    }
}
