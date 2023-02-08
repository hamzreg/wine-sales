using WineSales.Domain.Exceptions;
using WineSales.Domain.Models;
using WineSales.Domain.RepositoryInterfaces;


namespace WineSales.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataBaseContext _context;

        public UserRepository(DataBaseContext context)
        {
            _context = context;
        }

        public User Create(User user)
        {
            try
            {
                _context.Users.Add(user);
                _context.SaveChanges();

                return GetByID(user.ID);
            }
            catch
            {
                throw new UserException("Failed to create user.");
            }
        }

        public List<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public User GetByID(int id)
        {
            return _context.Users.Find(id);
        }

        public User GetByLogin(string login)
        {
            return _context.Users.FirstOrDefault(user => user.Login == login);
        }

        public List<User> GetByRole(string role)
        {
            return _context.Users.Where(user => user.Role == role)
                .ToList();
        }

        public void Register(User user)
        {
            try
            {
                _context.Users.Add(user);
                _context.SaveChanges();
            }
            catch
            {
                throw new UserException("Failed to register user");
            }
        }

        public User Update(User user)
        {
            try
            {
                _context.Users.Update(user);
                _context.SaveChanges();

                return GetByID(user.ID);
            }
            catch
            {
                throw new UserException("Failed to update user.");
            }
        }

        public User Delete(User user)
        {
            try
            {
                var foundUser = GetByID(user.ID);

                if (foundUser == null)
                    return null;
                else
                {
                    _context.Users.Remove(foundUser);
                    _context.SaveChanges();

                    return foundUser;
                }
            }
            catch
            {
                throw new UserException("Failed to delete user.");
            }
        }
    }
}
