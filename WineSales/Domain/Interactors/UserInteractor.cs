using AutoMapper;

using WineSales.Config;
using WineSales.Domain.Exceptions;
using WineSales.Domain.Models;
using WineSales.Domain.ModelsBL;
using WineSales.Domain.RepositoryInterfaces;


namespace WineSales.Domain.Interactors
{
    public interface IUserInteractor
    {
        UserBL CreateUser(UserBL user);
        List<UserBL> GetAll();
        UserBL GetByID(int id);
        int GetNowUserID();
        int GetNowUserRoleID();
        UserBL UpdateUser(UserBL user);
        UserBL DeleteUser(int id);
        UserBL RegisterUser(LoginDetailsBL loginDetails, string role, int roleID);
        UserBL AuthorizeUser(LoginDetailsBL loginDetails);
    }

    public class UserInteractor : IUserInteractor
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private UserBL _nowUser;

        public UserInteractor(IUserRepository userRepository,
                              IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;

            _nowUser = new UserBL(UserConfig.Default,
                                  UserConfig.Default,
                                  UserConfig.Roles["guest"]);
        }

        public UserBL NowUser
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

        public UserBL CreateUser(UserBL user)
        {
            if (IsExistByLogin(user.Login))
                throw new UserException("This user already exists.");

            var transmittedUser = _mapper.Map<User>(user);
            return _mapper.Map<UserBL>(_userRepository.Create(transmittedUser));
        }

        public List<UserBL> GetAll()
        {
            return _mapper.Map<List<UserBL>>(_userRepository.GetAll());
        }

        public UserBL GetByID(int id)
        {
            return _mapper.Map<UserBL>(_userRepository.GetByID(id));
        }

        public UserBL UpdateUser(UserBL user)
        {
            if (!IsExistById(user.ID))
                return null;

            if (IsLoginTaken(user.ID, user.Login))
                throw new UserException("This login is already in use.");

            if (!IsPasswordCorrect(user.Password))
                throw new UserException("Invalid input of password.");

            var transmittedUser = _mapper.Map<User>(user);
            return _mapper.Map<UserBL>(_userRepository.Update(transmittedUser));
        }

        public UserBL DeleteUser(int id)
        {
            if (!IsExistById(id))
                return null;

            return _mapper.Map<UserBL>(_userRepository.Delete(id));
        }

        public UserBL RegisterUser(LoginDetailsBL loginDetails, string role, int roleID)
        {
            if (IsExistByLogin(loginDetails.Login))
                throw new UserException("This user already exists.");

            if (!IsPasswordCorrect(loginDetails.Password))
                throw new UserException("Invalid input of password.");

            var newUser = new User(loginDetails.Login, loginDetails.Password, role);
            newUser.RoleID = roleID;
            return _mapper.Map<UserBL>(_userRepository.Register(newUser));
        }

        public UserBL AuthorizeUser(LoginDetailsBL loginDetails)
        {
            var authorizedUser = _userRepository.GetByLogin(loginDetails.Login);

            if (authorizedUser == null)
                throw new UserException("This user doesn't exist.");

            if (loginDetails.Password != authorizedUser.Password)
                throw new UserException("Invalid password.");

            NowUser = _mapper.Map<UserBL>(authorizedUser);

            return _mapper.Map<UserBL>(authorizedUser);
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
