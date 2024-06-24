using XYZ.BOUTIQUE.Domain.Entity;
using XYZ.BOUTIQUE.Domain.Interface;
using XYZ.BOUTIQUE.Infrastructure.Interface;

namespace XYZ.BOUTIQUE.Domain.Core
{
    public class UsersDomain : IUsersDomain
    {
        private readonly IUsersRepository _usersRepository;
        public UsersDomain(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }
        public Users Authenticate(string codigo_trabajador, string password)
        {
            return _usersRepository.Authenticate(codigo_trabajador, password);
        }
    }
}
