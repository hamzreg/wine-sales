using WineSales.Domain.DTO;
using WineSales.Domain.ModelsBL;
using WineSales.Domain.Interactors;


namespace WineSales.Domain.ModelConverters
{
    public class UserConverter
    {
        private readonly IUserInteractor _userInteractor;

        public UserConverter(IUserInteractor userInteractor)
        {
            _userInteractor = userInteractor;
        }

        public UserBL ConvertUser(int id, UserBaseDTO user)
        {
            var existingUser = _userInteractor.GetByID(id);

            return new UserBL
            {
                ID = id,
                Login = user.Login ?? existingUser.Login,
                Role = user.Role ?? existingUser.Role
            };
        }
    }
}
