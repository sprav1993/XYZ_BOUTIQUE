using XYZ.BOUTIQUE.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XYZ.BOUTIQUE.Infrastructure.Interface
{
    public interface IUsersRepository
    {
        Users Authenticate(string codigo_trabajador, string password);

    }
}
