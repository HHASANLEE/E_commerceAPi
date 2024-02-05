using E_commerceAPi.Dtoes;

namespace E_commerceAPi.Interfaces
{
    public interface IUser
    {
        public Task<bool> CreateUser(UserPostDto dto);
    }
}
