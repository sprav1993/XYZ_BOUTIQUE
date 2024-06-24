using XYZ.BOUTIQUE.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XYZ.BOUTIQUE.Domain.Interface
{
    public interface IUsersDomain
    {
        Users Authenticate(string username, string password);

    }
}
