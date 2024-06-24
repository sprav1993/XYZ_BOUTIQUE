using Dapper;
using XYZ.BOUTIQUE.Domain.Entity;
using XYZ.BOUTIQUE.Infrastructure.Interface;
using XYZ.BOUTIQUE.Transversal.Common;
using System.Data;

namespace XYZ.BOUTIQUE.Infrastructure.Repository
{
    public class UsersRepository : IUsersRepository
    {
        private readonly IConnectionFactory _connectionFactory;
        public UsersRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        public Users Authenticate(string codigo_trabajador, string password)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "USP_GET_USUARIO";
                var parameters = new DynamicParameters();
                parameters.Add("CODIGO_TRABAJADOR", codigo_trabajador);
                parameters.Add("PASSWORD", password);

                var user = connection.QuerySingle<Users>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return user;
            }
        }
    }
}
 