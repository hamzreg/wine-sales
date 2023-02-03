using WineSales.Config;
using WineSales.Domain.Exceptions;
using WineSales.Domain.Models;
using WineSales.Domain.RepositoryInterfaces;


namespace WineSales.Domain.Interactors
{
    public interface IUserInteractor
    {
        void CreateUser(User user);
        List<User> GetAll();
        int GetNowUserID();
        int GetNowUserRoleID();
        void UpdateUser(User user);
        void DeleteUser(User user);
        void RegisterUser(LoginDetails loginDetails, string role, int roleID);
        void AuthorizeUser(LoginDetails loginDetails);
    }

    public class UserInteractor : IUserInteractor
    {
        private readonly IUserRepository _userRepository;
        private User _nowUser;

        public UserInteractor(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _nowUser = new User(UserConfig.Default,
                                UserConfig.Default,
                                UserConfig.Roles["guest"]);
        }

        public User NowUser
        {
            get => _nowUser;
            set => _nowUser = value;
        }

        public int GetNowUserID()
        {
            return _nowUser.ID;
        }

        public int GetNowUserRoleID()
        {
            return _nowUser.RoleID;
        }

        public void CreateUser(User user)
        {
            if (IsExistByLogin(user.Login))
                throw new UserException("This user already exists.");

            _userRepository.Create(user);
        }

        public List<User> GetAll()
        {
            return _userRepository.GetAll();
        }

        public void UpdateUser(User user)
        {
            if (!IsExistById(user.ID))
                throw new UserException("This user doesn't exist.");

            if (IsLoginTaken(user.ID, user.Login))
                throw new UserException("This login is already in use.");

            if (!IsPasswordCorrect(user.Password))
                throw new UserException("Invalid input of password.");

            _userRepository.Update(user);
        }

        public void DeleteUser(User user)
        {
            if (!IsExistById(user.ID))
                throw new UserException("This user doesn't exist.");

            _userRepository.Delete(user);
        }

        public void RegisterUser(LoginDetails loginDetails, string role, int roleID)
        {
            if (IsExistByLogin(loginDetails.Login))
                throw new UserException("This user already exists.");

            if (!IsPasswordCorrect(loginDetails.Password))
                throw new UserException("Invalid input of password.");

            var newUser = new User(loginDetails.Login, loginDetails.Password, role);
            newUser.RoleID = roleID;
            _userRepository.Register(newUser);
        }

        public void AuthorizeUser(LoginDetails loginDetails)
        {
            var authorizedUser = _userRepository.GetByLogin(loginDetails.Login);

            if (authorizedUser == null)
                throw new UserException("This user doesn't exist.");

            if (loginDetails.Password != authorizedUser.Password)
                throw new UserException("Invalid password.");

            NowUser = authorizedUser;
        }

        private bool IsExistByLogin(string login)
        {
            return _userRepository.GetByLogin(login) != null;
        }

        private bool IsExistById(int id)
        {
            return _userRepository.GetByID(id) != null;
        }

        private bool IsPasswordCorrect(string password)
        {
            return UserConfig.MinPasswordLen <= password.Length;
        }

        private bool IsLoginTaken(int id, string login)
        {
            return _userRepository.GetAll().Any(obj =>
                                                obj.ID != id &&
                                                obj.Login == login);
        }
    }
}
